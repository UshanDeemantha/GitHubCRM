using Common.BL;
using System.Data;
using DevExpress.Web;
using DevExpress.Web.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.EmployeePortal
{
    public partial class LeadPyament : System.Web.UI.Page
    {
        Lead objLead = new Lead();
        DataTable dt = new DataTable();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            popDiv.Visible = false;
            popDivv.Visible = false;

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }
            if (!IsPostBack)
            {

                InitializeControls1();
                InitializeControls();
                if (Request.QueryString["PaymentId"] != null)
                {
                    Int32 PaymentId = Convert.ToInt32(Request.QueryString["PaymentId"].ToString());
                    getLeadPayment(PaymentId);

                    Session["PaymentIdEdit"] = PaymentId;
                }

            }

            
        }


        public void InitializeControls1()
        {
            txtLeadName.Text = string.Empty;
            txtQuotationNo.Text = string.Empty;
            txtContactNo.Text = string.Empty;
            lblResult.Text = string.Empty;
            lblstatus.Visible = false;

        }

        public void InitializeControls()
        {
            txtContactNo.Text = string.Empty;
            txtLeadName.Text = string.Empty;
            txtQuotationNo.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            txtSalesName.Text = string.Empty;
            txtReceiptNo.Text = string.Empty;
            txtProductName.Text = string.Empty;
            xMDescription.Text = string.Empty;
            dxcbRemarks.Text = string.Empty;
            Session["Amount"] = string.Empty;
            lblResult.Text = string.Empty;
            Session["PaymentId"] = null;
            Session["PaymentIdEdit"] = null;
            carTabPage.ActiveTabIndex = 0;
            TabClearControls();
            lblstatus.Visible = false;
            btnSave.Text = "Save";
            lblResult.ForeColor = Color.Red;
            lblResult.Text = string.Empty;
            Label18.ForeColor = Color.Red;
            Label18.Text = string.Empty;
            Session["LocId"] = null;
        }



        public void TabClearControls()
        {
            txtCashAmount.Text = string.Empty;
            txtDirectAmount.Text = string.Empty;
            txtChequeAmount.Text = string.Empty;
            txtBank.Text = string.Empty;
            txtChequeNo.Text = string.Empty;
            txtBranch.Text = string.Empty;
            txtCreditAmount.Text = string.Empty;
            dxDepositDate.Text = "01/01/2018";
            txtDirectBank.Text = string.Empty;
        }


        private void getLeadPayment(Int32 PaymentId)
        {

            dt = objLead.getLeadPaymentInfo(Convert.ToInt32(PaymentId));
            if (dt.Rows.Count > 0)
            {
                txtContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                txtQuotationNo.Text = Convert.ToString(dt.Rows[0]["QuotationNo"]);
                txtLeadName.Text = Convert.ToString(dt.Rows[0]["LeadNo"]);
                txtCustomerName.Text = Convert.ToString(dt.Rows[0]["CuName"]);
                txtSalesName.Text = Convert.ToString(dt.Rows[0]["Name"]);
                txtProductName.Text = Convert.ToString(dt.Rows[0]["ProductName"]);
                xMDescription.Text = Convert.ToString(dt.Rows[0]["Description"]);
                dxcbRemarks.Text = Convert.ToString(dt.Rows[0]["Payment"]);
                txtReceiptNo.Text = Convert.ToString(dt.Rows[0]["ReceiptNo"]);
                string Amount = Convert.ToString(dt.Rows[0]["Amount"]);

                string PaymentMethodId = Convert.ToString(dt.Rows[0]["PaymentMethodId"]);

              if(PaymentMethodId=="0")
              {
                  carTabPage.ActiveTabIndex = 0;
                  txtCashAmount.Text = Amount;
              }
              if (PaymentMethodId == "1")
              {
                  carTabPage.ActiveTabIndex = 1;
                  txtDirectAmount.Text = Amount;
                  dxDepositDate.Text = Convert.ToString(dt.Rows[0]["DepositDate"]);
                  txtDirectBank.Text = Convert.ToString(dt.Rows[0]["DepositBank"]);
              }
              if (PaymentMethodId == "2")
              {
                  carTabPage.ActiveTabIndex = 2;
                  txtChequeAmount.Text = Amount;
                  txtChequeNo.Text = Convert.ToString(dt.Rows[0]["ChequeNo"]);
                  txtBank.Text = Convert.ToString(dt.Rows[0]["Bank"]);
                  txtBranch.Text = Convert.ToString(dt.Rows[0]["Branch"]);
              }
              if (PaymentMethodId == "3")
              {
                  carTabPage.ActiveTabIndex = 3;
                  txtCreditAmount.Text = Amount;
              }

            }
            btnSave.Text = "Update";

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dtLeadPayment = new DataTable();
            DataTable dtCount = new DataTable();

            dtLeadPayment = objLead.GetLeadPayment(txtLeadName.Text, txtQuotationNo.Text, txtContactNo.Text, Convert.ToInt32(Session["LocationId"].ToString()));
            dtCount = objLead.GetLeadsCount(txtLeadName.Text, txtQuotationNo.Text, Convert.ToInt32(Session["LocationId"].ToString()));

            if(dtLeadPayment.Rows.Count>0)
            {

                string Payment = dtLeadPayment.Rows[0]["HeaderPyment"].ToString();
                
                if (Payment != "Full Payment")
                {
                    string productList = "";
                    for (int a = 0; a < dtLeadPayment.Rows.Count; a++)
                    {
                        productList = productList + dtLeadPayment.Rows[0]["ItemName"].ToString() + '/';
                    }

                    lblResult.Text = Payment;
                    txtCustomerName.Text = dtLeadPayment.Rows[0]["CustomerName"].ToString();
                    txtSalesName.Text = dtLeadPayment.Rows[0]["Name"].ToString();
                    txtQuotationNo.Text = dtLeadPayment.Rows[0]["QuotationNo"].ToString();
                    txtContactNo.Text = dtLeadPayment.Rows[0]["ContactNo"].ToString();
                    txtProductName.Text = productList.Remove(productList.Length - 1); ;
                    txtLeadName.Text = dtLeadPayment.Rows[0]["LeadNo"].ToString();
                    Session["CustomerId"] = dtLeadPayment.Rows[0]["CustomerId"].ToString();
                    Session["LocId"] = dtLeadPayment.Rows[0]["LocationId"].ToString();
                    lblstatus.Visible = true;

                }
                else
                {
                    lblResult.Text = Payment;
                    lblstatus.Visible = true;
                }
                if (Payment == null || Payment == "")
                {
                    lblstatus.Visible = false;
                }
                //if (dtCount.Rows.Count == 0)
                //{
                //    dxcbRemarks.SelectedIndex = 1;
                //}
                //if (dtCount.Rows.Count == 1)
                //{
                //    DataTable dt = (DataTable)dxcbRemarks.DataSource;
                //    dt.Rows.RemoveAt(0);
                //    dt.AcceptChanges();
                //    dxcbRemarks.DataSource = dt;
                //    DataBind();

                //    dxcbRemarks.SelectedIndex = 2;
                  
                //}
                //if (dtCount.Rows.Count == 2)
                //{
                //    DataTable dt = (DataTable)dxcbRemarks.DataSource;
                //    dt.Rows.RemoveAt(0);
                //    dt.AcceptChanges();
                //    dt.Rows.RemoveAt(0);
                //    dt.AcceptChanges();
                //    dxcbRemarks.DataSource = dt;
                //    DataBind();

                //    dxcbRemarks.SelectedIndex = 3;
            
                //}
                //if (dtCount.Rows.Count == 3)
                //{
                //    DataTable dt = (DataTable)dxcbRemarks.DataSource;
                //    dt.Rows.RemoveAt(0);
                //    dt.AcceptChanges();
                //    dt.Rows.RemoveAt(0);
                //    dt.AcceptChanges();
                //    dt.Rows.RemoveAt(0);
                //    dt.AcceptChanges();
                //    dxcbRemarks.DataSource = dt;
                //    DataBind();

                //    dxcbRemarks.SelectedIndex = 4;

                //}
        }

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitializeControls1();
            InitializeControls();
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
           try
            {
                if (btnSave.Text == "Save")
                {
                    if (dxcbRemarks.Text != string.Empty)
                    {
                    int TabIndex = carTabPage.ActiveTabIndex;

                    if (TabIndex == 0)
                    {
                        Session["Amount"] = txtCashAmount.Text;
                        objLead.AddLeadPayment(Convert.ToInt32(txtLeadName.Text), Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), Session["Amount"].ToString(), Session["UserName"].ToString(), Convert.ToInt32(Session["LocId"].ToString()));

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            lbSuccess.Text = " Lead Payment Successfully Saved.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }
                    
                    }
                    if (TabIndex == 1)
                    {

                        objLead.AddLeadPaymentDirect(Convert.ToInt32(txtLeadName.Text), Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), txtDirectAmount.Text, txtDirectBank.Text, dxDepositDate.Text, Session["UserName"].ToString(), Convert.ToInt32(Session["LocId"].ToString()));

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            lbSuccess.Text = " Lead Payment Successfully Saved.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }

                    }
                    if (TabIndex == 3)
                    {
                        Session["Amount"] = txtCreditAmount.Text;
                        objLead.AddLeadPayment(Convert.ToInt32(txtLeadName.Text), Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), Session["Amount"].ToString(), Session["UserName"].ToString(), Convert.ToInt32(Session["LocId"].ToString()));

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            lbSuccess.Text = " Lead Payment Successfully Saved.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }
                    }

                    if (TabIndex == 2)
                    {
                        objLead.AddLeadPayment(Convert.ToInt32(txtLeadName.Text), Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), txtChequeAmount.Text, Session["UserName"].ToString(), Convert.ToInt32(Session["LocId"].ToString()));

                        int PaymentId = Convert.ToInt32(objLead.PaymentId);

                        Session["PaymentId"] = PaymentId;

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {
                            AddChequePayment();
                            lbSuccess.Text = "Lead Payment Successfully Saved.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }
                    }
                    }
                    else
                    {
                        Label18.Text = "Select Payment Method";
                    }
                }
                else
                {
                    int TabIndex = carTabPage.ActiveTabIndex;

                    if (TabIndex == 0)
                    {

                        objLead.UpdateLeadPayment(Convert.ToInt32(Session["PaymentIdEdit"].ToString()), Convert.ToInt32(txtLeadName.Text), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), txtCashAmount.Text, Session["UserName"].ToString());

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            lbSuccess.Text = " Lead Payment Successfully Updated.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }

                    }
                    if (TabIndex == 1)
                    {

                        objLead.UpdateLeadPaymentDirect(Convert.ToInt32(Session["PaymentIdEdit"].ToString()),Convert.ToInt32(txtLeadName.Text), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), txtDirectAmount.Text, txtDirectBank.Text, dxDepositDate.Text, Session["UserName"].ToString());

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            lbSuccess.Text = "Lead Payment Successfully Updated.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }

                    }
                    if (TabIndex == 3)
                    {
                        Session["Amount"] = txtCreditAmount.Text;
                        objLead.UpdateLeadPayment(Convert.ToInt32(Session["PaymentIdEdit"].ToString()),Convert.ToInt32(txtLeadName.Text), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), Session["Amount"].ToString(), Session["UserName"].ToString());

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            lbSuccess.Text = "Lead Payment Successfully Updated.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }
                    }

                    if (TabIndex == 2)
                    {
                        objLead.UpdateLeadPaymentCheque(Convert.ToInt32(Session["PaymentIdEdit"].ToString()), Convert.ToInt32(txtLeadName.Text), Convert.ToInt32(TabIndex.ToString()), txtReceiptNo.Text, xMDescription.Text, dxcbRemarks.Text.Trim(), txtChequeAmount.Text, txtBank.Text,txtBranch.Text,txtChequeNo.Text, Session["UserName"].ToString());

                        int PaymentId = Convert.ToInt32(objLead.PaymentId);

                        Session["PaymentId"] = PaymentId;

                        if (objLead.IsError == true)
                        {

                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {
                            lbSuccess.Text = "Lead Payment Successfully Updated.";
                            popDivv.Visible = true;
                            InitializeControls();
                        }
                    }
                }
               
            }
           catch (Exception ex)
           {
               lberror.Text = ex.ToString();
               ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
           }
        }

        private void AddChequePayment()
        {
            objLead.AddChequePayment(Convert.ToInt32(Session["PaymentId"].ToString()), Convert.ToInt32(txtLeadName.Text), txtChequeNo.Text, txtBank.Text, txtBranch.Text, " ", Session["UserName"].ToString()); 
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            InitializeControls1();
            InitializeControls();
        }

      
        protected void carTabPage_TabClick(object source, TabControlCancelEventArgs e)
        {
            TabClearControls();
        }

        protected void lkViewPayment_Click(object sender, EventArgs e)
        {
            if(txtLeadName.Text==string.Empty)
            {
              Response.Redirect("PaymentDetail.aspx?LeadNo=" + 0 + "");
            }
            else
            {
                int LeadNo = Convert.ToInt32(txtLeadName.Text);
                Response.Redirect("PaymentDetail.aspx?LeadNo=" + LeadNo + "");
            }
           
        }
    }
}
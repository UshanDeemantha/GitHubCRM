using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.BL;
using DevExpress.Web.Rendering;
using HRM.EmployeePortal.ESMSWS;
using System.Drawing;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Utils;

namespace HRM.EmployeePortal
{
    public partial class AssigningLeads : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        User objUser = new User();
        bool isCheckBoxChange = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            popDiv.Visible = false;
            popDivv.Visible = false;
            popDivvv.Visible = false;


            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }

             if (!IsPostBack)
            {
               
                InitializeControls();

                if (Request.QueryString["ExecutiveId"] != null)
                {

                    txtOwner.Text = Request.QueryString["ExecutiveId"].ToString();

                    
                }
             
            }
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (Session["SearchEmpLead"] != null)
            {
                gvLeadSearch.DataSource = (DataTable)Session["SearchEmpLead"];
                gvLeadSearch.DataBind();
            }
           
        }

        public void InitializeControls()
        {
            txtLeadName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtCusName.Text = string.Empty;
            txtCusName2.Text = string.Empty;
            txtOwner.Text = string.Empty;
            cbStatus.Text = string.Empty;
            txtCustAdd.Text = string.Empty;
            txtProduct.Text = string.Empty;
            txtLeadName.IsValid = true;
            txtPhone.IsValid = true;
            txtOwner.IsValid = true;
            cbQuotation.ReadOnly = false;
            lblResult.Visible = false;
            cbQuotation.Checked = false;
            Session["IsQuootation"] = string.Empty;
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Save")
                {
                    if (cbQuotation.Checked == true)
                    {
                        objUser.AssingLeads(txtLeadName.Text, Convert.ToInt32(Session["LeadId"].ToString()), Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(txtOwner.Value), cbStatus.Value.ToString().Trim(), cbQuotation.Checked, Session["UserName"].ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
                        if (objUser.IsError == true)
                        {

                            lberror.Text = objUser.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            DataBind();
                            //SendSMS();
                            InitializeControls();
                            lbSuccess.Text = "  Assigning Leads Successfully Saved.";
                            popDivv.Visible = true;
                        }
                    }
                    else
                    {
                        objUser.AssingLeads(txtLeadName.Text, Convert.ToInt32(Session["LeadId"].ToString()), Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(txtOwner.Value), cbStatus.Value.ToString().Trim(), cbQuotation.Checked, Session["UserName"].ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
                        if (objUser.IsError == true)
                        {

                            lberror.Text = objUser.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            DataBind();
                            SendSMS();
                            InitializeControls();
                            //lbSuccess.Text = "  Assigning Leads Successfully Saved.";
                            //popDivv.Visible = true;
                        }

                    }
                }
                else
                {

                    if (cbQuotation.Checked == true)
                    {

                        objUser.UpdateLeadsExecutive(Convert.ToInt64(Session["AssignId"].ToString()), txtLeadName.Text, Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(txtOwner.Value), cbStatus.Value.ToString().Trim(), cbQuotation.Checked,Convert.ToInt32(Session["LocationId"].ToString()), Session["UserName"].ToString());
                        if (objUser.IsError == true)
                        {

                            lberror.Text = objUser.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            DataBind();
                            //SendSMS();
                            InitializeControls();
                            lbSuccess.Text = "Leads Executive Successfully Updated.";
                            popDivv.Visible = true;
                        }
                    }
                    else
                    {
                        objUser.UpdateLeadsExecutive(Convert.ToInt64(Session["AssignId"].ToString()), txtLeadName.Text, Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(txtOwner.Value), cbStatus.Value.ToString().Trim(),Convert.ToBoolean( cbQuotation.Checked),Convert.ToInt32(Session["LocationId"].ToString()), Session["UserName"].ToString());
                        if (objUser.IsError == true)
                        {

                            lberror.Text = objUser.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }
                        else
                        {

                            DataBind();
                            SendSMS();
                            InitializeControls();
                            //lbSuccess.Text = "Leads Executive Successfully Updated.";
                            //popDivv.Visible = true;

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

        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitializeControls();
        }
        protected void Grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "Status" )
            {
                if (e.CellValue.ToString().Trim() == "Open")
                    e.Cell.BackColor = System.Drawing.Color.OrangeRed;
            }
            if (e.DataColumn.FieldName == "Status")
            {
                if (e.CellValue.ToString().Trim() == "Assigned" )
                    e.Cell.BackColor = System.Drawing.Color.Green;
            }
            if (e.DataColumn.FieldName == "Status")
            {
                if (e.CellValue.ToString().Trim() == "Completed")
                    e.Cell.BackColor = System.Drawing.Color.Green;
            }
        }
     
        protected void lkSearch_Click(object sender, EventArgs e)
        {
           // GetLead();
            ScriptManager.RegisterStartupScript(this, GetType(), "show()", "show();", true);
        }
        protected void lkSelect_Click(object sender, EventArgs e)
        {

            try
            {
                
                var gridView = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).Grid;
                var index = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).VisibleIndex;

                var leadName = gridView.GetRowValues(index, "LeadNo").ToString();
                var phoneNU = gridView.GetRowValues(index, "ContactNo").ToString();
                var phoneNU2 = gridView.GetRowValues(index, "ContactNo2").ToString();
                var name = gridView.GetRowValues(index, "CustomerName").ToString();
                var name2 = gridView.GetRowValues(index, "SecondName").ToString();
                var Address = gridView.GetRowValues(index, "Address").ToString();
                var itemName = gridView.GetRowValues(index, "ItemName").ToString();


           

                hfCustomerId.Value = gridView.GetRowValues(index, "CustomerId").ToString();

                Session["CustomerId"] = hfCustomerId.Value;

                var LeadId = gridView.GetRowValues(index, "LeadId").ToString();

                Session["LeadId"] = LeadId;


                txtLeadName.Text = leadName.ToString();
                txtPhone.Text = phoneNU.ToString();
                txtPhone2.Text = phoneNU2.ToString();
                txtCusName.Text = name.ToString();
                txtCusName2.Text = name2.ToString();
                txtCustAdd.Text = Address.ToString();
                txtProduct.Text = itemName.ToString();

                cbStatus.Text = "2";

               

               
            }
            catch
            {
            }

        }


        protected void lkSelect_ClickEx(object sender, EventArgs e)
        {

            try
            {

                var gridView = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).Grid;
                var index = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).VisibleIndex;

                var leadName = gridView.GetRowValues(index, "LeadName").ToString();
                var phoneNU = gridView.GetRowValues(index, "ContactNo").ToString();
                var phoneNU2 = gridView.GetRowValues(index, "ContactNo2").ToString();
                var name = gridView.GetRowValues(index, "CustomerName").ToString();
                var name2 = gridView.GetRowValues(index, "SecondName").ToString();
                var Address = gridView.GetRowValues(index, "Address").ToString();
                var ExName = gridView.GetRowValues(index, "LeadOwnerId").ToString();
                var status = gridView.GetRowValues(index, "LeadStatus").ToString();
                var itemName = gridView.GetRowValues(index, "ProductList").ToString();

                bool IsQuootation = Convert.ToBoolean(gridView.GetRowValues(index, "IsMessageSend").ToString());

                Session["IsQuootation"] = IsQuootation;


                isCheckBoxChange = IsQuootation;

                hfAssignId.Value = gridView.GetRowValues(index, "Id").ToString();
                Session["AssignId"] = hfAssignId.Value;

                hfCustomerId.Value = gridView.GetRowValues(index, "CustomerId").ToString();
                Session["CustomerId"] = hfCustomerId.Value;

                txtLeadName.Text = leadName.ToString();
                txtPhone.Text = phoneNU.ToString();
                txtPhone2.Text = phoneNU2.ToString();
                txtCusName.Text = name.ToString();
                txtCusName2.Text = name2.ToString();
                txtCustAdd.Text = Address.ToString();
                cbStatus.Text = "2";
                txtOwner.Value = ExName.ToString();
                txtProduct.Text = itemName.ToString();
                cbQuotation.Value = IsQuootation;
                btnAdd.Text = "Update";

                if (cbQuotation.Checked == false)
                {
                    cbQuotation.ReadOnly = true;
                }

                if (cbQuotation.Checked == true)
                {
                    cbQuotation.ReadOnly = false;
                }
            }
            catch
            {
            }

        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = dt = objUser.GetLeadForSearch(Convert.ToInt32(Session["LocationId"].ToString()));
                Session["SearchEmpLead"] = dt;
                gvLeadSearch.DataSource = dt;
                gvLeadSearch.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "show()", "show();", true);
            }
            catch (Exception ex)
            {

            }
          
            
        }

        protected void lkSearchLeads_Click(object sender, EventArgs e)
        {
            GetLead();
            ScriptManager.RegisterStartupScript(this, GetType(), "show()", "show();", true);
        }


        private void GetLead()
        {
            try
            {

                DataTable dt = dt = objUser.GetLeadForSearch(Convert.ToInt32(Session["LocationId"].ToString()));
                Session["SearchEmpLead"] = dt;
                gvLeadSearch.DataSource = dt;
                gvLeadSearch.DataBind();
                ScriptManager.RegisterStartupScript(this, GetType(), "show()", "show();", true);

            }
            catch (Exception ex)
            {

            }
        }

        private void SendSMS()
        {
         bool Internet=   System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

         if (Internet == true)
         {
             dt = objUser.GetLeadOwner(txtLeadName.Text, Convert.ToInt32(Session["LocationId"].ToString()));

             #region  send msg to exceutive
             if (dt.Rows.Count > 0)
             {
                 string ExecutiveNo = Convert.ToString(dt.Rows[0]["ExecutiveNo"]);
                 string LeadNo = Convert.ToString(dt.Rows[0]["LeadName"]);
                 string CustoomerName = Convert.ToString(dt.Rows[0]["CustomerName"]);
                 string CustoomerNo = Convert.ToString(dt.Rows[0]["ContactNo"]);
                 string CustoomerAddress = Convert.ToString(dt.Rows[0]["Address"]);
                 string Product = Convert.ToString(dt.Rows[0]["ProductList"]);


                 ESMSWS.user user = new ESMSWS.user();
                 ESMSWS.alias alias = new ESMSWS.alias();
                 user.username = "esmsusr_1ouv";
                 user.password = "1kfavt6";
                 alias.alias1 = "CRM";

                 smsMessage msg = new smsMessage();

                 msg.sender = alias;
                 msg.message = "You have been assigned Lead No: " + LeadNo + " & Product: " + Product+ ". Customer: " + CustoomerName + ", " + CustoomerAddress + ". " +
                                "Tel : " + CustoomerNo + ". Thank you. " + " Industries (Pvt) Ltd. ";
                 msg.recipients = new string[] { ExecutiveNo };


                 EnterpriseSMSWSClient client = new EnterpriseSMSWSClient();
                 createGroupResponse dd = new createGroupResponse();
                 dd.ToString();

                 session s = client.createSession(user);
                 client.sendMessages(s, msg);
             #endregion

                 #region cust sms

                 if (Session["IsQuootation"].ToString() == string.Empty)
                 {
                     Session["IsQuootation"] = true;
                 }
                 if (Convert.ToBoolean(Session["IsQuootation"].ToString()) != Convert.ToBoolean(cbQuotation.Checked))
                 {
                     dt = objUser.GetLeadCustomer(txtLeadName.Text, Convert.ToInt32(Session["LocationId"].ToString()));

                     if (dt.Rows.Count > 0)
                     {
                         {
                             string CustomerName = Convert.ToString(dt.Rows[0]["CustomerName"]);
                             string CustomerNo = Convert.ToString(dt.Rows[0]["ContactNo"]);
                             string DueDate = Convert.ToString(dt.Rows[0]["DueDate"]);
                             string EXName = Convert.ToString(dt.Rows[0]["Name"]);
                             string ExecutiveNu = Convert.ToString(dt.Rows[0]["ExecutiveNo"]);



                             msg.sender = alias;
                             msg.message = CustomerName + ". Thank you for contacting . Your inquiry has been assigned to " + EXName + ". " +
                                             "Tel :" + ExecutiveNu + ".  We will get in touch with you soon. -  Your Most Trusted Service Provider. ";
                             msg.recipients = new string[] { CustomerNo };


                             client.sendMessages(s, msg);
                         }
                     }
                 }

                 #endregion
                

             }

             lbSuccess.Text = "Leads Executive Successfully Updated.";
             popDivv.Visible = true;
         }
         else
         {
             lbwarning.Text = "You're not connected to the Network and the Executive message was not sent. Assigning data saved successfully.";
             popDivvv.Visible = true;
         }
        }

        protected void gvAssignOwner_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Assigned")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#99d6ff");
            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Lost")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ff9999");

            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Won")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#adebad");
            }
        }

        protected void lkSelect_Init(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "LeadName", "LeadStatus" });
            string a = values[1].ToString();

          
            if (a == "Won")
            {
                btn.Enabled = false;
            }
            if (a == "Lost")
            {
                btn.Enabled = false;
            }
        }

        protected void cbQuotation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQuotation.Checked == true)
            {
                lblResult.Visible = true;
            }
            else
            {
                lblResult.Visible = false;
            }
        }

        protected void gvAssignOwner_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

            if (e.GetValue("LeadStatus") == null)
            {

            }
            else
            {

                string status = (e.GetValue("LeadStatus")).ToString();

                if (status.Equals("Lost"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ff9999");

                }
                if (status.Equals("Won"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#adebad");

                }
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            try
            {

                exportGrid2.WriteXlsToResponse("CRM-AssignCustomerLeads-" + DateTime.Now.ToString("MM-dd-yyyy"));

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
        }


    }
}
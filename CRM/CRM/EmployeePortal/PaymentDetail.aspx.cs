using Common.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using DevExpress.Web;

namespace HRM.EmployeePortal
{
    public partial class PaymentDetail : System.Web.UI.Page
    {

        DataTable dtVwCustomerPayments = new DataTable();
        Lead objLead = new Lead();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }
            if (!IsPostBack)
            {

                if (Request.QueryString["LeadNo"] != null)
                {
                    txtLeadName.Text = Request.QueryString["LeadNo"];
                    dtVwCustomerPayments = objLead.viewCustomerPayments(Convert.ToInt32(txtLeadName.Text.ToString()), "0", Convert.ToInt32(dxCbSalesPerson.Value), Convert.ToInt32(dxCbCustomer.Value), Convert.ToInt32(Session["LocationId"].ToString()));
                    Session["Searchpayments"] = dtVwCustomerPayments;
                    gvViewCustomerPayment.DataSource = Session["SearchPayments"];
                    gvViewCustomerPayment.DataBind();
                }
                else
                {

                    string leadName = txtLeadName.Text;
                    string QuoName = txtQuoName.Text;

                    if (leadName == "")
                    {
                        leadName = "0";
                    }
                    if (QuoName == "")
                    {
                        QuoName = "0";
                    }

                    dtVwCustomerPayments = objLead.viewCustomerPayments(Convert.ToInt32(leadName.ToString()), QuoName.ToString(), Convert.ToInt32(dxCbSalesPerson.Value), Convert.ToInt32(dxCbCustomer.Value), Convert.ToInt32(Session["LocationId"].ToString()));
                        Session["Searchpayments"] = dtVwCustomerPayments;
                        gvViewCustomerPayment.DataSource = Session["SearchPayments"];
                        gvViewCustomerPayment.DataBind();
                   
                  
                }
            }

            gvViewCustomerPayment.DataSource = Session["SearchPayments"];
            gvViewCustomerPayment.DataBind();

        }


        public void InitializeControls()
        {
            txtLeadName.Text = string.Empty;
            txtQuoName.Text = string.Empty;
            dxCbCustomer.Text = string.Empty;
            dxCbSalesPerson.Text = string.Empty;
            Session["LeadNo"] = string.Empty;
            Session["PaymentId"] = string.Empty;
        }


        public void FilData()
        {
            dtVwCustomerPayments = objLead.viewCustomerPayments(0, "0", Convert.ToInt32(dxCbSalesPerson.Value), Convert.ToInt32(dxCbCustomer.Value), Convert.ToInt32(Session["LocationId"].ToString()));
            Session["Searchpayments"] = dtVwCustomerPayments;
            gvViewCustomerPayment.DataSource = Session["SearchPayments"];
            gvViewCustomerPayment.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string leadName = txtLeadName.Text;
            string QuoName = txtQuoName.Text;

            if (leadName == "")
            {
                 leadName = "0";
            }
            if (QuoName == "")
            {
                 QuoName = "0";
            }

            dtVwCustomerPayments = objLead.viewCustomerPayments(Convert.ToInt32(leadName.ToString()), QuoName.ToString(), Convert.ToInt32(dxCbSalesPerson.Value), Convert.ToInt32(dxCbCustomer.Value), Convert.ToInt32(Session["LocationId"].ToString()));
                Session["Searchpayments"] = dtVwCustomerPayments;
                gvViewCustomerPayment.DataSource = Session["SearchPayments"];
                gvViewCustomerPayment.DataBind();
           

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitializeControls();
            FilData();
        }

        protected void gvViewCustomerPayment_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("Payment") == null)
            {

            }
            else
            {
                string status = (e.GetValue("Payment")).ToString();

                if (status.Equals("Full Payment"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#adebad");

                }

                //if (status.Equals("Balance Payment"))
                //{
                //    e.Row.BackColor = ColorTranslator.FromHtml("#adebad");
                //}
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "PaymentId", "LeadNo" });


            int PaymentId = Convert.ToInt32(values[0].ToString());

            string Lead;

            Lead = values[1].ToString();

            Response.Redirect("LeadPyament.aspx?PaymentId=" + PaymentId + " " );
            {

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "PaymentId", "LeadNo" });


            int PaymentId = Convert.ToInt32(values[0].ToString());
            Session["PaymentId"] = PaymentId;

            int LeadNo = Convert.ToInt32(values[1].ToString());
            Session["LeadNo"] = LeadNo;

            confirmpopup.ShowOnPageLoad = true;
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            try
            {
                objLead.DeleteLeadPayment(Convert.ToInt32(Session["PaymentId"].ToString()), Convert.ToInt32(Session["LeadNo"].ToString()));

                if (objLead.IsError == true)
                {

                }
                else
                {
                    InitializeControls();
                    confirmpopup.ShowOnPageLoad = false;
                    FilData();
             
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            confirmpopup.ShowOnPageLoad = false;
        }

    }
}
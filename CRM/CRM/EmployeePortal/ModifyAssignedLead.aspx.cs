using Common.BL;
using DevExpress.Web;
using DevExpress.Web.Rendering;
using HRM.EmployeePortal.ESMSWS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HRM.EmployeePortal
{
    public partial class ModifyAssignedLead : System.Web.UI.Page
    {
        User objUser = new User();
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
               
                InitializeControls();

            }
        }

        public void InitializeControls()
        {
            //txtLeadName.Text = string.Empty;
            //cbStatus.Text = string.Empty;
            //txtComment.Text = string.Empty;
            //txtLeadName.IsValid = true;
            //cbStatus.IsValid = true;
            //lblResult.ForeColor = Color.Red;
            //lblResult.Text = string.Empty;
            //txtQuotation.Text = string.Empty;
            //txtQuotation.Visible = false;
            //cbQuotation.Checked = false;
            //cbQuotation.Visible = false;
         
        }


        public void ValidateUser()
        {
           

        }

        protected void btnEdit_Init(object sender, EventArgs e)
        {
            //ASPxButton link = (ASPxButton)sender;
            //GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)link.NamingContainer;
            //object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] {"LeadStatus", "Comment"});
            //string a = values[0].ToString();

            //if (a == "Quotation")
            //{
            //    link.Enabled = false;
            //}
            //if (a == "Won")
            //{
            //    link.Enabled = false;
            //}
            //if (a == "Lost")
            //{
            //    link.Enabled = false;
            //}
        }

    

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            //ASPxButton btn = (ASPxButton)sender;
            //GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            //object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Id", "LeadName", "LeadStatus", "Comment", "LeadOwnerId", "CustomerId", "ContactNo", "CreatedDate", "QuotationNo", "IsQuootation" });



            //Session["id"] = values[0].ToString();

            //txtLeadName.Text = values[1].ToString();
            //cbStatus.Text = values[2].ToString();
            //txtComment.Text = values[3].ToString();
            //Session["LeadOwnerId"] = values[4].ToString();
            //Session["CustomerId"] = values[5].ToString();
            //Session["CreatedDate"] = values[7].ToString();
            //txtQuotation.Text = values[8].ToString();
            //cbQuotation.Visible = true;
            //cbQuotation.Checked = Convert.ToBoolean(values[9].ToString());

            //if (cbQuotation.Checked == true)
            //{
            //    txtQuotation.Visible = true;
            //}

            //if (txtQuotation.Text != string.Empty)
            //{
            //    txtQuotation.Visible = true;
            //    cbQuotation.Checked = true;
            //}

            //Page.SetFocus(cbStatus);

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //if (txtLeadName.Text == string.Empty )
            //{

            //    lblResult.Text = "Select Lead No!";

            //}
            //else
            //{
            //    if (cbQuotation.Checked == true)
            //    {

            //      // objUser.AddQuotationNo(txtLeadName.Text, , Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(Session["LeadOwnerId"].ToString()), txtComment.Text, Session["UserName"].ToString());
            //        objUser.UpdateAssingLeadsQuotation(Convert.ToInt64(Session["id"].ToString()), txtLeadName.Text, Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(Session["LeadOwnerId"].ToString()), cbStatus.Value.ToString(), txtComment.Text, Session["UserName"].ToString(), Convert.ToDateTime(Session["CreatedDate"].ToString()), txtQuotation.Text, Convert.ToInt32(Session["LocationId"].ToString()));
            //    }
            //    else

            //        objUser.UpdateAssingLeads(Convert.ToInt64(Session["id"].ToString()), txtLeadName.Text, Convert.ToInt64(Session["CustomerId"].ToString()), Convert.ToInt32(Session["LeadOwnerId"].ToString()), cbStatus.Value.ToString(), txtComment.Text, Session["UserName"].ToString(), Convert.ToDateTime(Session["CreatedDate"].ToString()), Convert.ToInt32(Session["LocationId"].ToString()));

            //    if (objUser.IsError == true)
            //    {

            //        lberror.Text = "Error Occured";
            //        popDiv.Visible = true;

            //    }
            //    else
            //    {
            //        lbSuccess.Text = "Updated Assigning Leads Successfully Updated.";
            //        popDivv.Visible = true;
            //        DataBind();
            //    }
            //}
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitializeControls();
        }

        protected void btnviewLead_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "CustomerId", "LeadNo" });


            Session["id"] = values[0].ToString();

            string Lead;

            Lead = values[1].ToString();

            Response.Redirect("LeadRegistration.aspx?LeadNo=" + Lead + "");
            {

            }
        }

        protected void cbQuotation_CheckedChanged(object sender, EventArgs e)
        {
            //if (cbQuotation.Checked == true)
            //{
            //    txtQuotation.Visible = true;
            //}
            //else
            //{
            //    txtQuotation.Text = string.Empty;
            //    txtQuotation.Visible = false;
            //}

        }

       
        //protected void gvAssignLead_SearchPanelEditorInitialize(object sender, ASPxGridViewSearchPanelEditorEventArgs e)
        //{
        //    if (gvAssignLead.SearchPanelFilter != null && gvAssignLead.SearchPanelFilter.Length > 0 && gvAssignLead.SearchPanelFilter[0] != '"')
        //        gvAssignLead.SearchPanelFilter = "\"" + e.Value.ToString().Trim() + "\"";
        //}

       
        

   

     
    }
}
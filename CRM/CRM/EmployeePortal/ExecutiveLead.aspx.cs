using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.BL;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Utils;


namespace HRM.EmployeePortal
{
    public partial class ExecutiveLead : System.Web.UI.Page
    {
        DataTable dtExecutiveLead = new DataTable();
        Lead objLead = new Lead();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }
            if (!IsPostBack)
            {
                var now = DateTime.Now;
                var startOfMonth = new DateTime(now.Year, 1, 1);
                dxFromDate.Value = DateTime.Now;
                dxToDate.Value = DateTime.Now;
                dtExecutiveLead = objLead.GetExecutiveLeads(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), Convert.ToInt32(Session["LocationId"].ToString()));
                Session["SearchExecutive"] = dtExecutiveLead;
                gvExecutiveLead.DataSource = Session["SearchExecutive"];
                gvExecutiveLead.DataBind();
            }

            gvExecutiveLead.DataSource = Session["SearchExecutive"];
            gvExecutiveLead.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dtExecutiveLead = objLead.GetExecutiveLeads(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), Convert.ToInt32(Session["LocationId"].ToString()));
            Session["SearchExecutive"] = dtExecutiveLead;
            gvExecutiveLead.DataSource = Session["SearchExecutive"];
            gvExecutiveLead.DataBind();
        }

        protected void btnviewLead_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "LeadOwnerId", "Name" });

            int LeadOwnerId;

            LeadOwnerId = Convert.ToInt32(values[0].ToString());

            Response.Redirect("AssigningLeads.aspx?ExecutiveId=" + LeadOwnerId + "");
            {

            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            try
            {
                exportGrid4.WriteXlsToResponse("CRM-ExecutiveLeads-" + DateTime.Now.ToString("MM-dd-yyyy"));

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
        }

        //protected void gvExecutiveLead_SearchPanelEditorInitialize(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorEventArgs e)
        //{
        //    if (gvExecutiveLead.SearchPanelFilter != null && gvExecutiveLead.SearchPanelFilter.Length > 0 && gvExecutiveLead.SearchPanelFilter[0] != '"')
        //        gvExecutiveLead.SearchPanelFilter = "\"" + e.Value.ToString().Trim() + "\"";
        //}
    }
}
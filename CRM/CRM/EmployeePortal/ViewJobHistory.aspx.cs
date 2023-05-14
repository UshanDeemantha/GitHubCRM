using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.BL;
using System.Data;
using DevExpress.XtraGrid;
using System.Drawing;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Utils;

namespace HRM.EmployeePortal
{
    public partial class ViewJobHistory : System.Web.UI.Page
    {
        DataTable dtLeadHistory = new DataTable();
        Lead objLead = new Lead();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }
            if (!IsPostBack)
            {
                cbStatus.SelectedIndex = 0;
                var now = DateTime.Now;
                var startOfMonth = new DateTime(now.Year, 1, 1);
                dxFromDate.Value = (DateTime)(startOfMonth);
                dxToDate.Value = DateTime.Now;
                dtLeadHistory = objLead.GetJobHistory(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), cbStatus.Value.ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
                Session["SearchJobHis"] = dtLeadHistory;
                gvAssignJobHistory.DataSource = Session["SearchJobHis"];
                gvAssignJobHistory.DataBind();
            }

            gvAssignJobHistory.DataSource = Session["SearchJobHis"];
            gvAssignJobHistory.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            dtLeadHistory = objLead.GetJobHistory(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), cbStatus.Value.ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
            Session["SearchJobHis"] = dtLeadHistory;
            gvAssignJobHistory.DataSource = Session["SearchJobHis"];
            gvAssignJobHistory.DataBind();
        }

        protected void gvAssignJobHistory_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Assigned")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ccffff");
            }

            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Confirmed")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#adebad");
            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Rejected")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ff9999");
            }

            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Pending")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ffffb3");
            }
            if (e.DataColumn.FieldName == "Activity")
            {
                if (e.CellValue.ToString().Trim() == "Calling Customer")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#b3ffb3");
            }
            if (e.DataColumn.FieldName == "Activity")
            {
                if (e.CellValue.ToString().Trim() == "Visiting Customer")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ccffff");
            }
            if (e.DataColumn.FieldName == "Activity")
            {
                if (e.CellValue.ToString().Trim() == "Mailing Customer")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ccddff");
            }
            if (e.DataColumn.FieldName == "Activity")
            {
                if (e.CellValue.ToString().Trim() == "Changing Executive")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#dda5e6");
            }
       
        }

        protected void gvAssignJobHistory_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("LeadStatus") == null)
            {

            }
            else
            {


                string status = (e.GetValue("LeadStatus")).ToString();

                if (status.Equals("Confirmed"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#adebad");

                }
                if (status.Equals("Rejected"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ff9999");

                }
                if (status.Equals("Pending"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ffffb3");

                }
            }
            
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            try
            {

                exportGrid3.WriteXlsToResponse("CRM-JobHistory-" + DateTime.Now.ToString("MM-dd-yyyy"));

            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, 1, 1);
            dxFromDate.Value = (DateTime)(startOfMonth);
            dxToDate.Value = DateTime.Now;
            dtLeadHistory = objLead.GetJobHistory(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), cbStatus.Value.ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
            Session["SearchJobHis"] = dtLeadHistory;
            gvAssignJobHistory.DataSource = Session["SearchJobHis"];
            gvAssignJobHistory.DataBind();
        }
    }
}
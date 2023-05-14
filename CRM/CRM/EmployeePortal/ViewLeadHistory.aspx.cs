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

namespace HRM.EmployeePortal
{
    public partial class ViewLeadHistory : System.Web.UI.Page
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
                dtLeadHistory = objLead.GetLeadHistory(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), cbStatus.Value.ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
                Session["SearchEmpHis"] = dtLeadHistory;
                gvAssignLeadHistory.DataSource = Session["SearchEmpHis"];
                gvAssignLeadHistory.DataBind();
              
            }

            gvAssignLeadHistory.DataSource = Session["SearchEmpHis"];
            gvAssignLeadHistory.DataBind();
        }

 

        protected void btnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void btnviewLead_Click(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            dtLeadHistory = objLead.GetLeadHistory(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), cbStatus.Value.ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
            Session["SearchEmpHis"] = dtLeadHistory;
            gvAssignLeadHistory.DataSource = Session["SearchEmpHis"];
            gvAssignLeadHistory.DataBind();

        }



        //protected void gvAssignLeadHistory_SearchPanelEditorInitialize(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorEventArgs e)
        //{
        //    if (gvAssignLeadHistory.SearchPanelFilter != null && gvAssignLeadHistory.SearchPanelFilter.Length > 0 && gvAssignLeadHistory.SearchPanelFilter[0] != '"')
        //        gvAssignLeadHistory.SearchPanelFilter = "\"" + e.Value.ToString().Trim() + "\"";
        //}

        protected void gvAssignLeadHistory_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
        {
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Assigned")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ccffff");
            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Lost")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ffcccc");

            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Won")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ccffcc");
            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Quotation")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ffa366");
            }
            if (e.DataColumn.FieldName == "Payment")
            {
                if (e.CellValue.ToString().Trim() == "Advance Payment")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#cce6ff");
            }
            if (e.DataColumn.FieldName == "Payment")
            {
                if (e.CellValue.ToString().Trim() == "Full Payment")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ccffcc");
            }
            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Payment")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#e6e6ff");
            }

            if (e.DataColumn.FieldName == "LeadStatus")
            {
                if (e.CellValue.ToString().Trim() == "Open")
                    e.Cell.BackColor = ColorTranslator.FromHtml("#ffffcc");
            }
        }

        protected void gvAssignLeadHistory_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            if (e.GetValue("LeadStatus") == null)
            {

            }
            else
            {
                string status = (e.GetValue("LeadStatus")).ToString();

                //if (status.Equals("Assigned"))
                //{
                //    e.Row.BackColor = ColorTranslator.FromHtml("#99d6ff");

                //}
                if (status.Equals("Lost"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ff9999");

                }
                if (status.Equals("Won"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#adebad");

                }

                if (status.Equals("Quotation"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ffa366");

                }
                //if (status.Equals("Open"))
                //{
                //    e.Row.BackColor = ColorTranslator.FromHtml("#ffffcc");

                //}
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            cbStatus.SelectedIndex = 0;
            var now = DateTime.Now;
            var startOfMonth = new DateTime(now.Year, 1, 1);
            dxFromDate.Value = (DateTime)(startOfMonth);
            dxToDate.Value = DateTime.Now;
            dtLeadHistory = objLead.GetLeadHistory(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), cbStatus.Value.ToString(), Convert.ToInt32(Session["LocationId"].ToString()));
            Session["SearchEmpHis"] = dtLeadHistory;
            gvAssignLeadHistory.DataSource = Session["SearchEmpHis"];
            gvAssignLeadHistory.DataBind();
        }
    }
}
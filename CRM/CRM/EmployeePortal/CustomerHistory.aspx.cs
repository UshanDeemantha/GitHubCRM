using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.Utils;


namespace HRM.EmployeePortal
{
    public partial class CustomerHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }
          
            if (!IsPostBack)
            {
              
            }
        }

       

      

        protected void Grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
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

        protected void gvCusHis_HtmlRowPrepared(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
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
                if (status.Equals("Open"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ffffcc");

                }
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            try
            {
                exportGrid1.WriteXlsxToResponse("CRM-CustomerHistory-" + DateTime.Now.ToString("MM-dd-yyyy"));
             
            }
            catch (Exception ex)
            {
                string a = ex.ToString();
            }
        }

        //protected void gvCusHis_SearchPanelEditorInitialize(object sender, DevExpress.Web.ASPxGridViewSearchPanelEditorEventArgs e)
        //{
        //    if (gvCusHis.SearchPanelFilter != null && gvCusHis.SearchPanelFilter.Length > 0 && gvCusHis.SearchPanelFilter[0] != '"')
        //    gvCusHis.SearchPanelFilter = "\"" + e.Value.ToString() + "\"";
        //}



       
    }
}
using Common.BL;

using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HRM.EmployeePortal
{
    public partial class ModifyAssignedActivity : System.Web.UI.Page
    {
        DataTable dtLeadGet = new DataTable();
        User objUser = new User();
        Lead objLead = new Lead();
        
      
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

                
                if (Session["SearchJob"] != null)
                {
                    gvAssignActivity.DataSource = Session["SearchJob"];
                    gvAssignActivity.DataBind();
                }
                else
                {
                    InitializeControls();
                    var now = DateTime.Now;
                    var startOfMonth = new DateTime(now.Year, 1, 1);
                    dxFromDate.Value = (DateTime)(startOfMonth);
                    var dateAndTime = DateTime.Now;
                    var date = dateAndTime.Date;
                    dxToDate.Value = new DateTime(now.Year, 12, 31);
                    string FromLead = "0";
                    string ToLead = "0";
                    dtLeadGet = objLead.GetJobActivity(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), FromLead, ToLead, Convert.ToInt32(Session["LocationId"].ToString()));
                    Session["SearchJob"] = dtLeadGet;
                    gvAssignActivity.DataSource = Session["SearchJob"];
                    gvAssignActivity.DataBind();
                }
            }

            gvAssignActivity.DataSource = Session["SearchJob"];
            gvAssignActivity.DataBind();
        }

        public void InitializeControls()
        {
            txtLeadName.Text = string.Empty;
            dxcomActivity.Text = string.Empty;
            txtOwner.Text = string.Empty;
            cbStatus.Text = string.Empty;
            txtComment.Text = string.Empty;
            txtLeadRenge.Text = string.Empty;
            dtStartDate.Value = string.Empty;
            lblResult.ForeColor = Color.Red;
            lblResult.Text = string.Empty;
            txtProduct.Text = string.Empty;
            txtCutomerNmae.Text = string.Empty;
            txtCustomerNo.Text = string.Empty;
            var now = DateTime.Now;
            dxFromDate.Value = new DateTime(now.Year, 1, 1);
            dxToDate.Value = new DateTime(now.Year, 12, 31);
            FillGrid();
            cbQuotation.Checked = false;
            txtQuotation.Text = "";
            txtQuotation.Visible = false;

        }


        private void FillGrid()
        {
            string FromLead = "0";
            string ToLead = "0";
            string[] func = txtLeadRenge.Text.Split('-');
            if (func.Length > 1)
            {
                FromLead = func[0].ToString();
                ToLead = func[1].ToString();
            }
            dtLeadGet = objLead.GetJobActivity(Convert.ToDateTime(dxFromDate.Value), Convert.ToDateTime(dxToDate.Value), FromLead, ToLead, Convert.ToInt32(Session["LocationId"].ToString()));
            Session["SearchJob"] = dtLeadGet;
            gvAssignActivity.DataSource = Session["SearchJob"];
            gvAssignActivity.DataBind();
        }


        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            confirmpopup.ShowOnPageLoad = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLeadName.Text == string.Empty)
            {

                lblResult.Text = "Select Lead No!";

            }
            else
            {
              // objUser.UpdateAssighActivity(Convert.ToInt64(Session["Id"].ToString()), txtLeadName.Text, Session["Subject"].ToString(), Convert.ToInt64(Session["CustomerId"].ToString()), dxcomActivity.Text, Convert.ToInt32(txtOwner.Value),Convert.ToString(cbStatus.Value), txtComment.Text, Convert.ToDateTime(dtStartDate.Text),Session["UserName"].ToString(),);

                objUser.UpdateAssighActivity(Convert.ToInt64(Session["Id"].ToString()), txtLeadName.Text, Session["Subject"].ToString(), Convert.ToInt64(Session["CustomerId"].ToString()), dxcomActivity.Text, Convert.ToInt32(txtOwner.Value), Convert.ToString(cbStatus.Value), txtComment.Text, Convert.ToDateTime(dtStartDate.Text), Session["UserName"].ToString(), Convert.ToBoolean(cbQuotation.Checked), txtQuotation.Text, Convert.ToInt32(Session["LocationId"].ToString()));

                if (objUser.IsError == true)
                {
                    lberror.Text = objUser.ErrorMsg.ToString();
                    popDiv.Visible = true;

                }
                else
                {
                    lbSuccess.Text = "Assigning Activity Updated Successfully.";
                    popDivv.Visible = true;
                    InitializeControls();
                    gvAssignActivity.DataBind();
                 

                   
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitializeControls();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Id", "LeadName", "Activity", "Name", "LeadStatus", "ActivityOwnerId", "Comment", "DueDate", "CustomerId", "Subject", "CustomerName", "ProductList", "ContactNo","IsQuootation","QuotationNo" });


            Session["Id"] = values[0].ToString();
            Session["CustomerId"] = values[8].ToString();
            Session["Subject"] = values[9].ToString();
            txtLeadName.Text = values[1].ToString();
            dxcomActivity.Text = values[2].ToString();
            txtOwner.Text = values[5].ToString();
            cbStatus.Text = values[4].ToString();
            txtComment.Text = values[6].ToString();
            txtCutomerNmae.Text = values[10].ToString();
            txtProduct.Text = values[11].ToString();
            txtCustomerNo.Text = values[12].ToString();

            if (values[7].ToString() != null)
            {
                dtStartDate.Value = Convert.ToDateTime(values[7].ToString());
            }
            cbQuotation.Checked = Convert.ToBoolean(values[13].ToString());
            txtQuotation.Text = values[14].ToString();




            if (cbQuotation.Checked == true)
            {
                txtQuotation.Visible = true;
            }
            else
            {
                txtQuotation.Visible = false;
                txtQuotation.Text = "";
            }

            if (txtQuotation.Text != string.Empty)
            {
                txtQuotation.Visible = true;
                cbQuotation.Checked = true;
            }

            Page.SetFocus(cbStatus);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            confirmpopup.ShowOnPageLoad = true;
            ASPxButton btn = (ASPxButton)sender;
            GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;

            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Id", "LeadName", "LeadStatus" });



            Session["id"] = values[0].ToString();
        }

   
        protected void Grid_HtmlDataCellPrepared(object sender, DevExpress.Web.ASPxGridViewTableDataCellEventArgs e)
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
                    e.Cell .BackColor = ColorTranslator.FromHtml("#dda5e6");
            }
       

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            objUser.DeleteAssingActivity(Convert.ToInt64(Session["id"].ToString()));

            if (objUser.IsError == true)
            {

                lberror.Text = "Error Occured";
                popDiv.Visible = true;

            }
            else
            {
                lbSuccess.Text = " Updated Assigning Activity Successfully Deleted.";
                popDivv.Visible = true;
                DataBind();
            }
        }

        protected void gvAssignActivity_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            
                if (e.RowType != GridViewRowType.Data) return;

                DateTime Date = Convert.ToDateTime(e.GetValue("DueDate"));
                string status = (e.GetValue("LeadStatus")).ToString();
                DateTime Today = System.DateTime.Now;

                if ((Date <= Today) && status.Equals("Assigned"))
                {
                    e.Row.BackColor = ColorTranslator.FromHtml("#ffcccc");
                }
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
                    if ((Date <= Today) && status.Equals("Pending"))
                    {
                        e.Row.BackColor = ColorTranslator.FromHtml("#ffcccc");
                    }
                    else
                    {
                       e.Row.BackColor = ColorTranslator.FromHtml("#ffffb3");
                    }
                    

                }

           
        }

        protected void btnEdit_Init(object sender, EventArgs e)
        {
            //ASPxButton btn = (ASPxButton)sender;
            //GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
            //object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "LeadName", "LeadStatus" });

            //string a = values[1].ToString();

            //if (a == "Confirmed")
            //{
            //    btn.Enabled = false;
            //}
            //if (a == "Rejected")
            //{
            //    btn.Enabled = false;
            //}

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           FillGrid();
          
        }

        protected void btnClr_Click(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            dxFromDate.Value = new DateTime(now.Year, 1, 1);
            dxToDate.Value = new DateTime(now.Year, 12, 31);
            FillGrid();
        }

        protected void cbQuotation_CheckedChanged(object sender, EventArgs e)
        {
            if (cbQuotation.Checked == true)
            {
                txtQuotation.Visible = true;
            }
            else
            {
                txtQuotation.Text = string.Empty;
                txtQuotation.Visible = false;
            }
        }

       
    }
}
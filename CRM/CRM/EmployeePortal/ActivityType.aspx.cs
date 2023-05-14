using DevExpress.Web.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.BL;
using System.Data;


namespace HRM.EmployeePortal
{
    public partial class ActivityType : System.Web.UI.Page
    {
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
               
                InitializeControls();
               
            }

        }


        public void InitializeControls()
        {
            txtProcessCode.Text = string.Empty;
            //txtProcessDescription.Text = string.Empty;
            txtType.Text = string.Empty;
            txtDescriptio.Text = string.Empty;
            txtProcessCode.IsValid = true;
            txtType.IsValid = true;
            btnAdd.Text = "Save";
        }


        protected void lkSelect_Click(object sender, EventArgs e)
        {

            try
            {
                var gridView = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).Grid;
                var index = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).VisibleIndex;

                var processCode = gridView.GetRowValues(index, "ProcessCode").ToString();
                var activityDes = gridView.GetRowValues(index, "ProcessActivityDes").ToString();
                var type = gridView.GetRowValues(index, "Type").ToString();
                var description = gridView.GetRowValues(index, "Description").ToString();
                bool isActive =Convert.ToBoolean( gridView.GetRowValues(index, "Active").ToString());

                hfitemId.Value = gridView.GetRowValues(index, "Id").ToString();

                Session["id"] = hfitemId.Value;

                txtProcessCode.Text = processCode.ToString();
                //txtProcessDescription.Text = activityDes.ToString();
                txtType.Text = type.ToString();
                txtDescriptio.Text = description.ToString();
                cbActive.Value = isActive;


                btnAdd.Text = "Update";


            }
            catch
            {
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (btnAdd.Text == "Save")
                {
                    bool a = IsValid;
                    objLead.AddActivityType(txtProcessCode.Text,"",txtType.Text,txtDescriptio.Text,cbActive.Checked);
                    if (objLead.IsError == true)
                    {

                        lberror.Text = objLead.ErrorMsg.ToString();
                        popDiv.Visible = true;
                    }
                    else
                    {
                        lbSuccess.Text = " ActivityType Successfully Saved.";
                        popDivv.Visible = true;
                        DataBind();
                        InitializeControls();
                    }
                }
                else
                {
                    objLead.UpdateActivityType(Convert.ToInt32(Session["id"].ToString()),txtProcessCode.Text," ",txtType.Text,txtDescriptio.Text,cbActive.Checked);

                    if (objLead.IsError == true)
                    {

                        lberror.Text = "Error Occured";
                        popDiv.Visible = true;
                        
                    }
                    else
                    {
                        lbSuccess.Text = " ActivityType Successfully Updated.";
                        popDivv.Visible = true;
                        DataBind();
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
    }
}
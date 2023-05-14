using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.BL;
using System.Data;
using DevExpress.Web.Rendering;
using DevExpress.Web;
using System.Drawing;

namespace HRM.EmployeePortal
{
    public partial class LeadRegistration : System.Web.UI.Page
    {
        Lead objLead = new Lead();
        DataTable dtLead = new DataTable();
        DataTable dt = new DataTable();
        public int namesCounter;
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }
            dtLead.Columns.Add("Id", typeof(int));
            dtLead.Columns.Add("ProductId", typeof(int));
            dtLead.Columns.Add("ProductName", typeof(string));
            dtLead.Columns.Add("ProductDescription", typeof(string));
            dtLead.Columns.Add("Quantity", typeof(string));
            dtLead.Columns.Add("Comment", typeof(string));
            dtLead.Columns.Add("LeadDetailId", typeof(int));

            ASPxPopupControl1.ShowOnPageLoad = false;
            popDiv.Visible = false;
            popDivv.Visible = false;

          
            if (!IsPostBack)
            {
                int i = 0;
                ViewState["recordIndex"] = i;
                PopulateForm(i);
                ViewState["Number"] = 0;
                ViewState["table"] = dtLead;
                InitializeControls();
                InitializeControls2();
                DataBind();
                dxcbLeadSource.SelectedIndex = 0;
               
                if (Request.QueryString["LeadNo"] != null)
                {

                    Int32 LeadNo = Convert.ToInt32(Request.QueryString["LeadNo"].ToString());

                    ViewState["LeadNo"] = LeadNo;
                    getLeadDetails(LeadNo);


                }
                else
                {
                   
                    dtStartDate.Value = DateTime.Now;
                   

                }
                 
            }

        }

        private void getLeadDetails(Int32 LeadNo)
        {

            dt = objLead.getLeadDetailsInfo(Convert.ToInt32(LeadNo), Convert.ToInt32(Session["LocationId"].ToString()));
            if (dt.Rows.Count > 0)
            {

                txtLeadNo.Text = Convert.ToString(dt.Rows[0]["LeadNo"]);
                dxcbLeadSource.Text = Convert.ToString(dt.Rows[0]["LeadSources"]);
                txtContactNo.Text = Convert.ToString(dt.Rows[0]["ContactNo"]);
                txtContactNo2.Text = Convert.ToString(dt.Rows[0]["ContactNo2"]);
                txtName.Text = Convert.ToString(dt.Rows[0]["FirstName"]);
                txtName2.Text = Convert.ToString(dt.Rows[0]["SecondName"]);
                txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
                cbMR.Text = Convert.ToString(dt.Rows[0]["NameTitle"]);
                txtSpecialInstruction.Text = Convert.ToString(dt.Rows[0]["SpecialInstruction"]);
                cbQuotation.Checked = Convert.ToBoolean(dt.Rows[0]["IsQuootation"]);
                if (cbQuotation.Checked != true)
                {
                    cbQuotation.ReadOnly = true;
                }
                dxCheckBox.Checked = true;
                dtLead = (DataTable)ViewState["table"];
                if (txtContactNo2.Text != string.Empty)
                {
                    CBChange.Visible = true;
                    
                }
                else
                {
                    CBChange.Visible = false;
                }
                if (cbMR.Text == "Com." || cbMR.Text == "Site.")
                {
                    btnADDCOM.Visible = true;
                    btnNEXTCOM.Visible = true;
                    btnPRVICOM.Visible = true;
                }
                else
                {
                    btnADDCOM.Visible = false;
                    btnNEXTCOM.Visible = false;
                    btnPRVICOM.Visible = false;
                }

                for (int a = 0; a < dt.Rows.Count; a++)
                {
                    namesCounter = Convert.ToInt32(ViewState["Number"]) + 1;
                    ViewState["Number"] = namesCounter;
                    DataRow dtrow = dtLead.NewRow();

                    dtrow[a] = namesCounter;
                    dtrow["Id"] = namesCounter;
                    dtrow["ProductName"] = Convert.ToString(dt.Rows[a]["ProductName"]);
                    dtrow["ProductId"] = Convert.ToString(dt.Rows[a]["ItemId"]);
                    dtrow["ProductDescription"] = Convert.ToString(dt.Rows[a]["ProductDescription"]);
                    dtrow["Quantity"] = Convert.ToString(dt.Rows[a]["Quantity"]);
                    dtrow["Comment"] = Convert.ToString(dt.Rows[a]["Comment"]);
                    dtrow["LeadDetailId"] = Convert.ToString(dt.Rows[a]["LeadDetailId"]);
                    dtStartDate.Value = Convert.ToDateTime(dt.Rows[a]["CreatedDate"]);
                    dtLead.Rows.Add(dtrow);
                }
            }
            ViewState["table"] = dtLead;
            gvProductDetails.DataSource = dtLead;
            gvProductDetails.DataBind();

            btnSave.Text = "Update";
    
        }

    

        public void InitializeControls()
        {
            txtContactNo2.Text = string.Empty;
            txtLeadNo.Text = string.Empty;
            dxcbLeadSource.SelectedIndex = 1;
            txtContactNo.Text = string.Empty;
            cbMR.Text = "0";
            txtName.Text = string.Empty;
            txtName2.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSpecialInstruction.Text = string.Empty;
            InitializeControls2();
            dxcbLeadSource.IsValid = true;
            txtContactNo.IsValid = true;
            txtName.IsValid = true;
            txtContactNo2.IsValid = true;
            dtLead.Clear();
            Label4.Visible = false;
            dxCheckBox.Checked = false;
            gvProductDetails.DataSource = null;
            gvProductDetails.DataBind();
            cbQuotation.Checked = false;
            cbQuotation.ReadOnly = false;
            btnADDCOM.Visible = false;
            btnNEXTCOM.Visible = false;
            btnPRVICOM.Visible = false;
            lblResult.ForeColor = Color.Red;
            lblResult.Text = string.Empty;
            CBChange.Visible = false;
           

        }

        public void InitializeControls2()
        {
            dxCbProductName.Text = string.Empty;
            ASPxProductDes.Text = string.Empty;
            txtquantity.Text = string.Empty;
            ASPxComment.Text = string.Empty;
            dxcbLeadSource.IsValid = true;
            txtContactNo.IsValid = true;
            txtName.IsValid = true;
            txtContactNo2.IsValid = true;
        
         
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Add")
                {
                    txtContactNo2.IsValid = true;
                    if(ViewState["table"] != "")
                    dtLead = (DataTable)ViewState["table"];
                    namesCounter = Convert.ToInt32(ViewState["Number"]) + 1;
                    ViewState["Number"] = namesCounter;
                    DataRow dtrow = dtLead.NewRow();
                    dtrow[0] = namesCounter;
                    dtrow["Id"] = namesCounter;
                    dtrow["ProductName"] = dxCbProductName.Text;
                    dtrow["ProductId"] = dxCbProductName.Value;
                    dtrow["ProductDescription"] = ASPxProductDes.Text;
                    dtrow["Quantity"] = txtquantity.Text;
                    dtrow["Comment"] = ASPxComment.Text;

                    dtLead.Rows.Add(dtrow);
                    ViewState["table"] = dtLead;
                    gvProductDetails.DataSource = dtLead;
                    gvProductDetails.DataBind();


                    InitializeControls2();

                }

                else
                {


                    if (Session["id"] != null)
                    {
                        for (int i = ((DataTable)ViewState["table"]).Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = ((DataTable)ViewState["table"]).Rows[i];
                            if (dr["id"].ToString() == Session["id"].ToString())
                                dr.Delete();
                            ((DataTable)ViewState["table"]).AcceptChanges();
                        }
                    }

                    dtLead = (DataTable)ViewState["table"];
                    namesCounter = Convert.ToInt32(ViewState["Number"]) + 1;
                    ViewState["Number"] = namesCounter;
                    DataRow dtrow = dtLead.NewRow();
                    dtrow[0] = namesCounter;
                    dtrow["Id"] = namesCounter;
                    dtrow["ProductName"] = dxCbProductName.Text;
                    dtrow["ProductId"] = dxCbProductName.Value;
                    dtrow["ProductDescription"] = ASPxProductDes.Text;
                    dtrow["Quantity"] = txtquantity.Text;
                    dtrow["Comment"] = ASPxComment.Text;

                    dtLead.Rows.Add(dtrow);
                    ViewState["table"] = dtLead;
                    gvProductDetails.DataSource = dtLead;
                    gvProductDetails.DataBind();


                    InitializeControls2();
                }

            }

            catch (Exception ex)
            {
                //lberror.Text = ex.ToString();
                //popDiv.Visible = true;
            }

        }


        
        

        protected void btnClear_Click(object sender, EventArgs e)
        {

                    InitializeControls2();
            
        }

        protected void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            if (CBChange.Checked == false)
            {
                Lead objLead = new Lead();
                dtLead = objLead.GetCustomerDetail(txtContactNo.Text);
                if (dtLead.Rows.Count > 0)
                {
                    txtContactNo.Text = dtLead.Rows[0]["ContactNo"].ToString();
                    txtContactNo2.Text = dtLead.Rows[0]["ContactNo2"].ToString();
                    txtName.Text = dtLead.Rows[0]["FirstName"].ToString();
                    txtName2.Text = dtLead.Rows[0]["SecondName"].ToString();
                    cbMR.Text = dtLead.Rows[0]["NameTitle"].ToString();
                    txtAddress.Text = dtLead.Rows[0]["Address"].ToString();
                    dxCheckBox.Checked = true;

                    if (cbMR.Text == "Com." || cbMR.Text == "Site.")
                    {
                        btnADDCOM.Visible = true;
                        btnNEXTCOM.Visible = true;
                        btnPRVICOM.Visible = true;
                    }
                    else
                    {
                        btnADDCOM.Visible = false;
                        btnNEXTCOM.Visible = false;
                        btnPRVICOM.Visible = false;
                    }
                    if (txtContactNo2.Text != String.Empty)
                    {
                        CBChange.Visible = true;
                    }
                    else
                    {
                        CBChange.Visible = false;
                    }
                }
            }
          
        }

     

        protected void btnSave_Click(object sender, EventArgs e)
        {
          
            try
            {
                if (dxCheckBox.Checked == false)
                {
                    Label4.Visible = true;
                    txtContactNo2.IsValid = true;
                }
                else
                {
                    if (btnSave.Text == "Save")
                    {
                        if (((DataTable)(ViewState["table"])).Rows.Count >0)
                        {
                            AddLeadCustomer();
                            AddLead();
                            AddDetails((DataTable)(ViewState["table"]));

                            if (objLead.IsError == true)
                            {
                                lberror.Text = objLead.ErrorMsg.ToString();
                                popDiv.Visible = true;
                            }

                            else
                            {
                                ASPxPopupControl1.ShowOnPageLoad = true;
                                lbSuccess.Text = " Lead Registration Successfully Saved.";
                                popDivv.Visible = true;
                                InitializeControls();
                                ViewState["table"] = "";
                            }
                        }
                        else
                        {
                            lblResult.Text = "Select Product Name";
                        }

                      
                    }
                    else
                    {
                        UpdateLeadCustomer();
                        UpdateLead();
                        UpdateLeadProduct((DataTable)(ViewState["table"]));
                        if (objLead.IsError == true)
                        {
                            lberror.Text = objLead.ErrorMsg.ToString();
                            popDiv.Visible = true;
                        }

                        else
                        {
                            lbSuccess.Text = " Updated Product Details Registration Successfully Saved.";
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
        private void AddDetails(DataTable  tbl)
        {
            try
            {

                objLead.AddDetails(Session["LeadNo"].ToString(), tbl, Convert.ToInt32(Session["LocationId"].ToString()));

                long CustomerId = Convert.ToInt64(objLead.CustomerId);

                Session["CustomerId"] = CustomerId;
            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        private void UpdateLeadProduct(DataTable tbl)
        {
            try
            {
                objLead.UpdateLeadProduct(txtLeadNo.Text, tbl, Convert.ToInt32(Session["LocationId"].ToString()));

                long CustomerId = Convert.ToInt64(objLead.CustomerId);

                Session["CustomerId"] = CustomerId;
            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }


        private void AddLeadCustomer()
        {
            try
            {
                if (cbMR.Text == "Com." || cbMR.Text == "Site.")
                {
                    objLead.AddLeadCustomerCOM(txtContactNo.Text, txtContactNo2.Text, txtName.Text, txtName2.Text, cbMR.Text.Trim(), txtAddress.Text);

                    long CustomerId = Convert.ToInt64(objLead.CustomerId);

                    Session["CustomerId"] = CustomerId;
                }
                else
                {
                    objLead.AddLeadCustomer(txtContactNo.Text, txtContactNo2.Text, txtName.Text, txtName2.Text, cbMR.Text.Trim(), txtAddress.Text);

                    long CustomerId = Convert.ToInt64(objLead.CustomerId);

                    Session["CustomerId"] = CustomerId;
                }
            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        private void UpdateLeadCustomer()
        {
            try
            {
                objLead.UpdateLeadCustomer(txtLeadNo.Text, txtContactNo.Text, txtContactNo2.Text, txtName.Text, txtName2.Text, cbMR.Text.Trim(), txtAddress.Text, Session["UserName"].ToString());

                long CustomerId = Convert.ToInt64(objLead.CustomerId);

                Session["CustomerId"] = CustomerId;
            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        private void UpdateLead()
        {
            try
            {
               
                //DataTable isquation = objLead.getQuationLead(Convert.ToInt32( txtLeadNo.Text));           
                //if(isquation.Rows.Count >0)
                //{                 
                //    objLead.UpdateLeadfalse(txtLeadNo.Text, Convert.ToInt64(Session["CustomerId"].ToString()), dxcbLeadSource.Text.Trim(), txtSpecialInstruction.Text, Convert.ToDateTime(dtStartDate.Value), cbQuotation.Checked, Session["UserName"].ToString());
                //}

                //if (cbQuotation.Checked == false && isquation.Rows.Count==0)
                //{
                    objLead.UpdateLead(txtLeadNo.Text, Convert.ToInt64(Session["CustomerId"].ToString()), dxcbLeadSource.Text.Trim(), txtSpecialInstruction.Text, Convert.ToDateTime(dtStartDate.Value),  Session["UserName"].ToString());
                
            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        private void AddLead()
        {
            try
            {
                //if (cbQuotation.Checked == true)
                //{
                //    dtLead = objLead.GetLeadCode();
                //    string a = dtLead.Rows[0]["CRMLeadNo"].ToString();
                //    string LeadNo;
                //    if (a == "")
                //    {
                //        LeadNo = "1";
                //    }
                //    else
                //    {
                //        LeadNo = a;
                //    }
                //    Label5.InnerText = LeadNo;
                //    Session["LeadNo"] = LeadNo;
                //    objLead.AddLeadFalse(LeadNo, Convert.ToInt64(Session["CustomerId"].ToString()), dxcbLeadSource.Text.Trim(), txtSpecialInstruction.Text, Convert.ToDateTime(dtStartDate.Value), cbQuotation.Checked, Session["UserName"].ToString());
                //}
                //else
                //{
                    dtLead = objLead.GetLeadCode(Convert.ToInt32(Session["LocationId"].ToString()));
                    string a = dtLead.Rows[0]["CRMLeadNo"].ToString();
                    string LeadNo;
                    if (a == "")
                    {
                        LeadNo = "1";
                    }
                    else
                    {
                        LeadNo = a;
                    }
                    Label5.InnerText = LeadNo;
                    Session["LeadNo"] = LeadNo;
                    objLead.AddLead(LeadNo, Convert.ToInt64(Session["CustomerId"].ToString()), dxcbLeadSource.Text.Trim(), txtSpecialInstruction.Text, Convert.ToDateTime(dtStartDate.Value), cbQuotation.Checked, Convert.ToInt32(Session["LocationId"].ToString()), Session["UserName"].ToString());
                
               
            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        protected void btnClear1_Click(object sender, EventArgs e)
        {
            InitializeControls();
            ViewState["table"] = "";
           
           
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                 ASPxButton btn = (ASPxButton)sender;
                GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
                object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] {"Id", "ProductName", "ProductDescription","Quantity","Comment"});



                Session["id"] = values[0].ToString();

                 dxCbProductName.Text = values[1].ToString();
                 ASPxProductDes.Text = values[2].ToString();
                 txtquantity.Text = values[3].ToString();
                 ASPxComment.Text = values[4].ToString();
                 //dxCbProductName.Value = values[7].ToString();
                 txtContactNo2.IsValid = true;
                
                 btnAdd.Text = "Update";
                

            }
            catch
            {
            }
      
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            confirmpopup.ShowOnPageLoad = true;

               ASPxButton btn = (ASPxButton)sender;
                GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
                object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] {"Id", "ProductName", "ProductDescription","Quantity","Comment"});



                Session["id"] = values[0].ToString();
                txtContactNo2.IsValid = true;
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
                 
                for (int i = ((DataTable)ViewState["table"]).Rows.Count - 1; i >= 0; i--)
                {
                    string Id = Session["id"].ToString();
                    DataRow dr = ((DataTable)ViewState["table"]).Rows[i];

                    int LeadDetailId = Convert.ToInt32(dr["LeadDetailId"].ToString());

                    if (Id != "")
                    {
                        if (dr["id"].ToString() == Session["id"].ToString())
                            dr.Delete();

                        ((DataTable)ViewState["table"]).AcceptChanges();

                        dtLead = (DataTable)ViewState["table"];
                        objLead.DeleteLeadProduct(LeadDetailId, txtLeadNo.Text, Convert.ToInt32(Session["LocationId"].ToString()));

                        ViewState["table"] = dtLead;
                        gvProductDetails.DataSource = dtLead;
                        gvProductDetails.DataBind();
                        Session["id"] = string.Empty;
                    }
                    confirmpopup.ShowOnPageLoad = false;
                }
               

        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            confirmpopup.ShowOnPageLoad = false;
        }

        //protected void txtContactNo2_Validation(object sender, ValidationEventArgs e)
        //{ 
        //    e.IsValid = true;
        //}

        protected void btnOk_Click1(object sender, EventArgs e)
        {
            ASPxPopupControl1.ShowOnPageLoad = false;
            dxcbLeadSource.Value = "1";
        }

        protected void btnADDCOM_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtContactNo2.Text = string.Empty;
            txtName2.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtSpecialInstruction.Text = string.Empty;

        }

        protected void btnNEXTCOM_Click(object sender, EventArgs e)
        {
             Lead objLead = new Lead();
            dtLead = objLead.GetCustomerDetail(txtContactNo.Text);

            int i = (int)ViewState["recordIndex"];
            i = i >= dtLead.Rows[0].Table.Rows.Count - 1 ? 0 : i + 1;
            PopulateForm(i);

         

        }

        protected void PopulateForm(int i)
        {
            if (i != 0)
            {

                ViewState["recordIndex"] = i;
                System.Data.DataRow row = dtLead.Rows[0].Table.Rows[i];
                txtContactNo.Text = row["ContactNo"].ToString();
                txtContactNo2.Text = row["ContactNo2"].ToString();
                txtName.Text = row["FirstName"].ToString();
                txtName2.Text = row["SecondName"].ToString();
                cbMR.Text = row["NameTitle"].ToString();
                txtAddress.Text = row["Address"].ToString();
            }
            else
            {

            }
 
       }

        protected void btnPRVICOM_Click(object sender, EventArgs e)
        {
            Lead objLead = new Lead();
            dtLead = objLead.GetCustomerDetail(txtContactNo.Text);
             int i = (int)ViewState["recordIndex"];
             i = i - 1;

            if (i >= 0)
            {
                              
                ViewState["recordIndex"] = i;
                System.Data.DataRow row = dtLead.Rows[0].Table.Rows[i];
                txtContactNo.Text = row["ContactNo"].ToString();
                txtContactNo2.Text = row["ContactNo2"].ToString();
                txtName.Text = row["FirstName"].ToString();
                txtName2.Text = row["SecondName"].ToString();
                cbMR.Text = row["NameTitle"].ToString();
                txtAddress.Text = row["Address"].ToString();
            }
         
        }

        protected void CBChange_CheckedChanged(object sender, EventArgs e)
        {
            if (CBChange.Checked == false)
            {
               string Contact1 = txtContactNo.Text;
               string Contact2 = txtContactNo2.Text;
               txtContactNo.Text = Contact2;
               txtContactNo2.Text = Contact1;
            }
            else
            {
                string Contact1 = txtContactNo.Text;
                string Contact2 = txtContactNo2.Text;
                txtContactNo.Text = Contact2;
                txtContactNo2.Text = Contact1;
            }

        }

    }
}
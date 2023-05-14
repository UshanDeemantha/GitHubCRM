using DevExpress.Web.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.BL;
using DevExpress.Web.Rendering;
using DevExpress.Web;
using System.Drawing;
using System.Globalization;
using HRM.EmployeePortal.ESMSWS;

namespace HRM.EmployeePortal
{
    public partial class AssigningActivity : System.Web.UI.Page
    {
        DataTable dt = new DataTable();
        DataTable dtActivity = new DataTable();
        User objUser = new User();
        public int namesCounter;
        public int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            popDiv.Visible = false;
            popDivv.Visible = false;
            popDivvv.Visible = false;

            if (Session["UserName"] == null)
            {
                Response.Redirect("~/SessionTimeout.aspx?DoRedirect=" + System.Web.HttpContext.Current.Request.Url.AbsolutePath);
            }


            dtActivity.Columns.Add("Id", typeof(int));
            dtActivity.Columns.Add("LeadNo", typeof(string));
            dtActivity.Columns.Add("PhoneNo", typeof(string));
            dtActivity.Columns.Add("PhoneNo2", typeof(string));
            dtActivity.Columns.Add("ActivityId", typeof(int));
            dtActivity.Columns.Add("Subject", typeof(string));
            dtActivity.Columns.Add("Activity", typeof(string));
            dtActivity.Columns.Add("DueDate", typeof(DateTime));
            dtActivity.Columns.Add("ActivityOwnerID", typeof(string));
            dtActivity.Columns.Add("ActivityOwner", typeof(string));
            dtActivity.Columns.Add("Status", typeof(string));
            dtActivity.Columns.Add("StatusID", typeof(string));

            if (!IsPostBack)
            {
                ViewState["table"] = null;
                ViewState["Number"] = 0;


                ViewState["table"] = dtActivity;
                InitializeControls();
                InitializeControls2();
                DataBind();


            }


        }


        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            if (Session["SearchEmpAssign"] != null)
            {
                gvLeadSearch.DataSource = (DataTable)Session["SearchEmpAssign"];
                gvLeadSearch.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Add")
            {


                if (ViewState["table"] != "")
                    dtActivity = (DataTable)ViewState["table"];
                namesCounter = Convert.ToInt32(ViewState["Number"]) + 1;
                ViewState["Number"] = namesCounter;
                DataRow dtrow = dtActivity.NewRow();
                dtrow[0] = namesCounter;
                dtrow["Id"] = namesCounter;
                dtrow["LeadNo"] = txtLeadName.Text;
                dtrow["PhoneNo"] = txtPhone.Value;
                dtrow["PhoneNo2"] = txtPhone2.Value;
                dtrow["Activity"] = dxcomActivity.Text;
                dtrow["ActivityId"] = dxcomActivity.Value;
                dtrow["Subject"] = txtSubject.Text;
                dtrow["DueDate"] = dtStartDate.Value;
                dtrow["ActivityOwner"] = txtOwner.Text;
                dtrow["ActivityOwnerID"] = txtOwner.Value;
                dtrow["Status"] = cbStatus.Text;
                dtrow["StatusID"] = cbStatus.Value;

                if (dtActivity.Rows.Count == 0)
                {
                    dtActivity.Rows.Add(dtrow);

                }
                else
                {

                    DataRow[] dr = null;
                    DataTable dtModifyActivity = dtActivity.Copy();
                    foreach (DataRow row in dtModifyActivity.Rows)
                    {

                        dr = dtModifyActivity.Select("ActivityId = " + dxcomActivity.Value.ToString());

                        if (dr.Length == 0)
                        {
                            dtActivity.Rows.Add(dtrow);

                        }
                        else
                        {
                            lblResult.Text = "Job Activity duplicate!";
                        }

                    }
                }

                ViewState["table"] = dtActivity;
                gvAssigningActivity.DataSource = dtActivity;
                gvAssigningActivity.DataBind();

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

                dtActivity = (DataTable)ViewState["table"];
                namesCounter = Convert.ToInt32(ViewState["Number"]) + 1;
                ViewState["Number"] = namesCounter;
                DataRow dtrow = dtActivity.NewRow();
                dtrow[0] = namesCounter;
                dtrow["Id"] = namesCounter;
                dtrow["LeadNo"] = txtLeadName.Text;
                dtrow["PhoneNo"] = txtPhone.Value;
                dtrow["PhoneNo2"] = txtPhone.Value;
                dtrow["Activity"] = dxcomActivity.Text;
                dtrow["ActivityId"] = dxcomActivity.Value;
                dtrow["Subject"] = txtSubject.Text;
                dtrow["DueDate"] = dtStartDate.Text;
                dtrow["ActivityOwner"] = txtOwner.Text;
                dtrow["ActivityOwnerID"] = txtOwner.Value;
                dtrow["Status"] = cbStatus.Text;
                dtrow["StatusID"] = cbStatus.Value;

                dtActivity.Rows.Add(dtrow);
                ViewState["table"] = dtActivity;
                gvAssigningActivity.DataSource = dtActivity;
                gvAssigningActivity.DataBind();
            }
        }

        public void InitializeControls()
        {
            txtLeadName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtPhone2.Text = string.Empty;
            txtOwner.Text = string.Empty;
            cbStatus.Text = string.Empty;
            lblResult.Text = string.Empty;
            cbQuotation.Checked = false;
            InitializeControls2();
            dtActivity.Clear();
            gvAssigningActivity.DataSource = null;
            gvAssigningActivity.DataBind();
            txtLeadName.IsValid = true;
            txtPhone.IsValid = true;
            ViewState["table"] = "";
            Button1.Enabled = true;
            btnAdd.Text = "Add";
        }


        public void InitializeControls2()
        {

            txtSubject.Text = string.Empty;
            dxcomActivity.Text = string.Empty;
            dtStartDate.Value = string.Empty;
            txtLeadName.IsValid = true;
            txtPhone.IsValid = true;
            lblResult.Text = string.Empty;

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            InitializeControls2();
        }


        private void GetLead()
        {
            try
            {

                DataTable dt = dt = objUser.GetLeadActivityForSearch(Convert.ToInt32(Session["LocationId"].ToString()));
                gvLeadSearch.DataSource = dt;
                gvLeadSearch.DataBind();
                Session["SearchEmpAssign"] = dt;

            }
            catch (Exception ex)
            {

            }
        }

        protected void lkSelectSearch_Click(object sender, EventArgs e)
        {

            try
            {

                var gridView = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).Grid;
                var index = ((GridViewTableDataRow)(((LinkButton)sender).Parent.Parent.Parent.Parent)).VisibleIndex;

                var leadNo = gridView.GetRowValues(index, "LeadNo").ToString();
                var CotNo = gridView.GetRowValues(index, "ContactNo").ToString();
                var CotNo2 = gridView.GetRowValues(index, "ContactNo2").ToString();
                var owner = gridView.GetRowValues(index, "LeadOwnerId").ToString();
                bool isActive = Convert.ToBoolean(gridView.GetRowValues(index, "IsMessageSend").ToString());

                hfCustomerId.Value = gridView.GetRowValues(index, "CustomerId").ToString();

                Session["CustomerId"] = hfCustomerId.Value;

                txtLeadName.Text = leadNo;
                txtPhone.Text = CotNo;
                txtPhone2.Text = CotNo2;
                cbQuotation.Value = isActive;
                txtOwner.Value = owner;
                cbStatus.SelectedIndex = 0;

                Button1.Enabled = false;
                Button1.CssClass = "btn btn-info";
            }
            catch
            {
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetLead();
            ScriptManager.RegisterStartupScript(this, GetType(), "show()", "show();", true);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxButton btn = (ASPxButton)sender;
                GridViewDataItemTemplateContainer container = (GridViewDataItemTemplateContainer)btn.NamingContainer;
                object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Id", "LeadNo", "PhoneNo", "PhoneNo2", "Activity", "Subject", "DueDate", "ActivityOwner", "Status" });



                Session["id"] = values[0].ToString();

                txtLeadName.Text = values[1].ToString();
                txtPhone.Text = values[2].ToString();
                txtPhone2.Text = values[3].ToString();
                dxcomActivity.Text = values[4].ToString();
                txtSubject.Text = values[5].ToString();
                dtStartDate.Value = Convert.ToDateTime(values[6].ToString());
                txtOwner.Text = values[7].ToString();
                cbStatus.Text = values[8].ToString();


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
            object[] values = (object[])container.Grid.GetRowValues(container.VisibleIndex, new string[] { "Id", "LeadNo", "PhoneNo", "PhoneNo2", "Activity", "Subject", "DueDate", "ActivityOwner", "Status" });


            Session["id"] = values[0].ToString();



        }

        private void AssingActivity(DataTable tbl)
        {
            try
            {
                objUser.AssingActivity(Convert.ToInt64(Session["CustomerId"].ToString()), tbl, Session["UserName"].ToString(), Convert.ToInt32(Session["LocationId"].ToString()));

            }
            catch (Exception ex)
            {
                lberror.Text = ex.ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Error();", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                AssingActivity((DataTable)(ViewState["table"]));

                if (objUser.IsError == true)
                {
                    lberror.Text = objUser.ErrorMsg.ToString();
                    popDiv.Visible = true;
                }
                else
                {

                    //lbSuccess.Text = " Assigning Activity Successfully Saved.";
                    //popDivv.Visible = true;
                    if (cbQuotation.Checked == false)
                    {
                        SendSMS((DataTable)(ViewState["table"]));
                    }
                    else
                    {
                        lbwarning.Text = "Customer message was not sent. Job Activity saved successfully.";
                        popDivvv.Visible = true;
                    }
                    InitializeControls();
                    ViewState["table"] = "";
                }



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
        }

        protected void btnDelete_Click1(object sender, EventArgs e)
        {
            for (int i = ((DataTable)ViewState["table"]).Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = ((DataTable)ViewState["table"]).Rows[i];
                if (dr["id"].ToString() == Session["id"].ToString())
                    dr.Delete();
                ((DataTable)ViewState["table"]).AcceptChanges();

                dtActivity = (DataTable)ViewState["table"];

                ViewState["table"] = dtActivity;
                gvAssigningActivity.DataSource = dtActivity;
                gvAssigningActivity.DataBind();
            }
            confirmpopup.ShowOnPageLoad = false;
        }

        protected void btnDeleteNo_Click(object sender, EventArgs e)
        {
            confirmpopup.ShowOnPageLoad = false;
        }

        protected void lkSearchLeads_Click(object sender, EventArgs e)
        {
            GetLead();
            ScriptManager.RegisterStartupScript(this, GetType(), "show()", "show();", true);
        }

        private void SendSMS(DataTable tbl)
        {
            bool Internet = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (Internet == true)
            {

                for (int a = 0; a < tbl.Rows.Count; a++)
                {
                    string Acticity = Convert.ToString(tbl.Rows[a]["Activity"]);

                    if (Acticity == "Calling Customer")
                    {
                        dt = objUser.GetLeadCustomer(txtLeadName.Text, Convert.ToInt32(Session["LocationId"].ToString()));

                        if (dt.Rows.Count > 0)
                        {
                            {
                                string CustomerName = Convert.ToString(dt.Rows[0]["CustomerName"]);
                                string CustomerNo = Convert.ToString(dt.Rows[0]["ContactNo"]);
                                string DueDate = Convert.ToString(dt.Rows[0]["DueDate"]);
                                string EXName = Convert.ToString(dt.Rows[0]["Name"]);
                                string ExecutiveNo = Convert.ToString(dt.Rows[0]["ExecutiveNo"]);

                                ESMSWS.user user = new ESMSWS.user();
                                ESMSWS.alias alias = new ESMSWS.alias();
                                user.username = "esmsusr_1ouv";
                                user.password = "1kfavt6";
                                alias.alias1 = "CRM";

                                smsMessage msg = new smsMessage();

                                msg.sender = alias;
                                msg.message = CustomerName + ". Thank you for contacting . Your inquiry has been assigned to " + EXName + ". " +
                                                "Tel :" + ExecutiveNo + ".  We will get in touch with you soon. -  Your Most Trusted Service Provider. ";
                                msg.recipients = new string[] { CustomerNo };


                                EnterpriseSMSWSClient client = new EnterpriseSMSWSClient();
                                createGroupResponse dd = new createGroupResponse();
                                dd.ToString();

                                session s = client.createSession(user);
                                client.sendMessages(s, msg);

                            }

                            lbSuccess.Text = " Assigning Activity Successfully Saved.";
                            popDivv.Visible = true;


                        }

                    }

                    if (Acticity == "Changing Executive")
                    {

                        dt = objUser.GetLeadCustomer(txtLeadName.Text, Convert.ToInt32(Session["LocationId"].ToString()));

                        if (dt.Rows.Count > 0)
                        {

                            {
                                string CustomerName = Convert.ToString(dt.Rows[0]["CustomerName"]);
                                string CustomerNo = Convert.ToString(dt.Rows[0]["ContactNo"]);
                                string DueDate = Convert.ToString(dt.Rows[0]["DueDate"]);
                                string EXName = Convert.ToString(dt.Rows[0]["Name"]);
                                string ExecutiveNo = Convert.ToString(dt.Rows[0]["ExecutiveNo"]);

                                ESMSWS.user user = new ESMSWS.user();
                                ESMSWS.alias alias = new ESMSWS.alias();
                                user.username = "esmsusr_1ouv";
                                user.password = "1kfavt6";
                                alias.alias1 = "CRM";

                                smsMessage msg = new smsMessage();

                                msg.sender = alias;
                                msg.message = CustomerName + ". Please accept our Sincere apologies. Your inquiry has been changed to " + EXName + ". " +
                                                "Tel: " + ExecutiveNo + ".  We will get in touch with you soon. Thank you. -  Your Most Trusted Service Provider. ";

                                msg.recipients = new string[] { CustomerNo };


                                EnterpriseSMSWSClient client = new EnterpriseSMSWSClient();
                                createGroupResponse dd = new createGroupResponse();
                                dd.ToString();

                                session s = client.createSession(user);
                                client.sendMessages(s, msg);
                            }

                            lbSuccess.Text = " Changing Executive Successfully Saved.";
                            popDivv.Visible = true;

                        }

                    }
                    else
                    {
                        lbSuccess.Text = " Assigning Activity Successfully Saved.";
                        popDivv.Visible = true;
                    }

                }

            }
            else
            {
                lbwarning.Text = "You're not connected to the Network and the Customer message was not sent. Changing Executive saved successfully.";
                popDivvv.Visible = true;
            }
        }

        protected void dxcomActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dxcomActivity.Text == "Changing Executive")
            {
                txtOwner.ReadOnly = false;
            }
        }
    }
}


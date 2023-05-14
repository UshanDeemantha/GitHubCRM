using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using System.Data;
using System.ComponentModel;

namespace Common.BL
{
   public class Lead
    {
       #region Fields

        DAL.Lead objLeadDAL;
        DataTable dtLead;
        private bool _isError;
        private string _errorMsg;

        private long _customerId;
        private long _paymentId;
        private int _leadId;
        private int _leadDetailId;
        private int _quantity;
        private string _leadNo;
        private string _leadsource;
        private string _name;
        private string _address;
        private string _specialinstruction;
        private string _productName;
        private string _productDescription;
        private string _comment;
     

        #endregion

        #region Propreties

        public bool IsError
        {
            get { return _isError; }
        }

        public string ErrorMsg
        {
            get { return _errorMsg; }
        }

        public long CustomerId
        {
            get { return _customerId; }
            set { _customerId = value; }
        }

        public long PaymentId
        {
            get { return _paymentId; }
            set { _paymentId = value; }
        }

  
        public int LeadId
        {
            get { return _leadId; }
            set { _leadId = value; }
        }

        public int LeadDetailId
        {
            get { return _leadDetailId; }
            set { _leadDetailId = value; }
        }

        public string LeadNo
        {
            get { return _leadNo; }
            set { _leadNo = value; }
        }

        public string LeadSource
        {
            get { return _leadsource; }
            set { _leadsource = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string SpecialInstruction
        {
            get { return _specialinstruction; }
            set { _specialinstruction = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }


        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        #endregion

        # region Constructor
        public Lead()
        {
            objLeadDAL = new DAL.Lead();
        }
        # endregion

        # region Methods

        public void SetValues()
        {
            _isError = objLeadDAL.IsError;
            _errorMsg = objLeadDAL.ErrorMsg;
        }


        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataTable GetLeadCode(int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetLeadCode(LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable getLeadDetailsInfo(int LeadNo, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.getLeadDetailsInfo(LeadNo, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable getLeadPaymentInfo(int PaymentId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.getLeadPaymentInfo(PaymentId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable getQuationLead(int LeadNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.getQuationLead(LeadNo);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }


        public void AddLead(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leaddate, bool IsQuotation, int LocationId, string CreateUser)
        {
            try
            {
                objLeadDAL.AddLead(leadNo, customerId, leadSource, specialInstruction, leaddate, IsQuotation, LocationId, CreateUser);
            
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadfalse(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leaddate, bool IsQuotation, string UpdateUser)
        {
            try
            {
                objLeadDAL.UpdateLeadfalse(leadNo, customerId, leadSource, specialInstruction, leaddate, IsQuotation, UpdateUser);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLead(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leaddate, string UpdateUser)
        {
            try
            {
                objLeadDAL.UpdateLead(leadNo, customerId, leadSource, specialInstruction, leaddate, UpdateUser);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AddLeadFalse(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leaddate, bool IsQuotation, string CreateUser)
        {
            try
            {
                objLeadDAL.AddLeadFalse(leadNo, customerId, leadSource, specialInstruction, leaddate, IsQuotation, CreateUser);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AddLeadPayment(int leadNo, long CustomerId, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Createuser, int LocationId)
        {
            try
            {
                objLeadDAL.AddLeadPayment(leadNo, CustomerId, PaymentmethodId, ReceiptNo, Description, Payment, Amount, Createuser, LocationId);

                _paymentId = objLeadDAL.PaymentId;
              

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadPayment(int PaymentId, int leadNo, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Createuser)
        {
            try
            {
                objLeadDAL.UpdateLeadPayment(PaymentId, leadNo, PaymentmethodId, ReceiptNo, Description, Payment, Amount, Createuser);

                _paymentId = objLeadDAL.PaymentId;


                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AddLeadPaymentDirect(int leadNo, long CustomerId, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Bank, string DepositDate, string Createuser, int LocationId)
        {
            try
            {
                objLeadDAL.AddLeadPaymentDirect(leadNo, CustomerId, PaymentmethodId, ReceiptNo, Description, Payment, Amount, Bank, DepositDate, Createuser, LocationId);

                _paymentId = objLeadDAL.PaymentId;


                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadPaymentDirect(int PaymentId,int leadNo, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Bank, string DepositDate, string Createuser)
        {
            try
            {
                objLeadDAL.UpdateLeadPaymentDirect(PaymentId,leadNo, PaymentmethodId, ReceiptNo, Description, Payment, Amount, Bank, DepositDate, Createuser);

                _paymentId = objLeadDAL.PaymentId;


                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void UpdateLeadPaymentCheque(int PaymentId, int leadNo, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Bank, string Branch, string ChequeNo, string Createuser)
        {
            try
            {
                objLeadDAL.UpdateLeadPaymentCheque(PaymentId, leadNo, PaymentmethodId, ReceiptNo, Description, Payment, Amount, Bank, Branch, ChequeNo, Createuser);

                _paymentId = objLeadDAL.PaymentId;


                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void AddChequePayment(int PaymentId, int leadNo, string ChequeNo, string Bank, string Branch, string Comment, string Createuser)
        {
            try
            {
                objLeadDAL.AddChequePayment(PaymentId,leadNo, ChequeNo, Bank, Branch, Comment, Createuser);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }
        public DataTable viewCustomerPayments(int PLeadNo, string PQuoNu, int PSalesPerson, int PCustomerName, int LocationId)
        {
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = objLeadDAL.viewCustomerPayments(PLeadNo, PQuoNu, PSalesPerson, PCustomerName, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;

        }

        public DataTable GetLeadPayment(string LeadNo, string QuotationNo, string ContactNo, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (QuotationNo.Length == 0)
                    QuotationNo = "0";

                dataTable = objLeadDAL.GetLeadPayment(LeadNo, QuotationNo, ContactNo, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable GetLeadsCount(string LeadNo, string QuotationNo, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetLeadsCount(LeadNo, QuotationNo, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }
        public void AddDetails(string leadNo, DataTable tbl, int LocationId)
        {
            try
            {
                
                foreach (DataRow row in tbl.Rows)
                {
                    
                    objLeadDAL.AddLeadProduct(leadNo, Convert.ToInt32(row["ProductId"].ToString()), row["ProductDescription"].ToString(), row["Quantity"].ToString(),
                        row["Comment"].ToString(), LocationId);
                  
                }
               
                 
                
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadProduct(string leadNo, DataTable tbl, int LocationId)
        {
            try
            {

                objLeadDAL.DeleteLeadDetail(leadNo, LocationId);

                foreach (DataRow row in tbl.Rows)
                {

                    objLeadDAL.UpdateLeadProduct(leadNo, Convert.ToInt32(row["ProductId"].ToString()), row["ProductDescription"].ToString(), row["Quantity"].ToString(),
                        row["Comment"].ToString(), LocationId);

                }



                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void DeleteLeadPayment(int PaymentId, int LeadNo)
        {
            try
            {

                objLeadDAL.DeleteLeadPayment(PaymentId, LeadNo);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AddLeadCustomerCOM(string contactNo, string contactNo2, string name, string name2, string nameTitle, string address)
        {
            try
            {
                objLeadDAL.AddLeadCustomerCOM(contactNo, contactNo2, name, name2, nameTitle, address);
                _customerId = objLeadDAL.CustomerId;
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AddLeadCustomer(string contactNo, string contactNo2, string name, string name2, string nameTitle, string address)
        {
            try
            {
                objLeadDAL.AddLeadCustomer(contactNo,contactNo2, name,name2,nameTitle, address);
                _customerId = objLeadDAL.CustomerId;
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadCustomer(string LeadNo,string contactNo, string contactNo2, string name, string name2, string nameTitle, string address,string UpdateUser)
        {
            try
            {
                objLeadDAL.UpdateLeadCustomer(LeadNo, contactNo, contactNo2, name, name2, nameTitle, address, UpdateUser);
                _customerId = objLeadDAL.CustomerId;
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public DataTable GetCustomerDetail(string contactNo)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetCustomerDetail(contactNo);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public void AddLeadProduct(string leadNo, int productId, string productDescription, string quantity, string comment, int LocationId)
        {
            try
            {
                objLeadDAL.AddLeadProduct(leadNo, productId, productDescription, quantity, comment, LocationId);
                
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadProduct(int leadDetailId, string leadNo, int productId, string productDescription, string quantity, string comment, int LocationId)
        {
            try
            {
                objLeadDAL.UpdateLeadProduct(leadDetailId, leadNo, productId, productDescription, quantity, comment, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void DeleteLeadProduct(int leadDetailId, string LeadNo, int LocationId)
        {
            try
            {
                objLeadDAL.DeleteLeadProduct(leadDetailId, LeadNo, LocationId);
            }
            catch (Exception ex)
            {
                _isError = objLeadDAL.IsError;
                _errorMsg = objLeadDAL.ErrorMsg;
            }
        }

        #endregion

        # region Activity

        public void AddActivityType(string ProcessCode, string ProcessActivityDes, string ActivityType, string Description,bool Active)
        {
            try
            {
                objLeadDAL.AddActivityType(ProcessCode, ProcessActivityDes, ActivityType, Description, Active);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void UpdateActivityType(int ActivityId, string ProcessCode, string ProcessActivityDes, string ActivityType, string Description, bool Active)
        {
            try
            {
                objLeadDAL.UpdateActivityType(ActivityId, ProcessCode, ProcessActivityDes, ActivityType, Description, Active);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        #endregion

        # region Product

        public void AddProduct(string ItemCode, string ItemName, string ItemDescription, string SpecialDescription, bool Active)
        {
            try
            {
                objLeadDAL.AddProduct(ItemCode, ItemName, ItemDescription, SpecialDescription, Active);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void UpdateProduct(int ItemId, string ItemCode, string ItemName, string ItemDescription, string SpecialDescription, bool Active)
        {
            try
            {
                objLeadDAL.UpdateProduct(ItemId, ItemCode, ItemName, ItemDescription, SpecialDescription, Active);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public DataTable GetLeadHistory(DateTime fromDate, DateTime todate, string status, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetLeadHistory(fromDate, todate, status, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable GetJobHistory(DateTime fromDate, DateTime todate, string status, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetJobHistory(fromDate, todate, status, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable GetJobActivity(DateTime fromDate, DateTime todate, string fromLead, string toLead, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetJobActivity(fromDate, todate, fromLead,toLead, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }


        #endregion

        # region Company Location

        public void AddLocation(string LocationCode, string LocationName, bool IsActive, string CreateUser)
        {
            try
            {
                objLeadDAL.AddLocation(LocationCode, LocationName, IsActive, CreateUser);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void UpdateLocation(int LocationId, string LocationCode, string LocationName, bool IsActive, string UpdateUser)
        {
            try
            {
                objLeadDAL.UpdateLocation(LocationId, LocationCode, LocationName, IsActive, UpdateUser);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        #endregion
        # region Executive

        public void AddExecutive(string EPFNo, string Name, string ContactNo, string Designation, int LocationId, string Email, bool Active)
        {
            try
            {
                objLeadDAL.AddExecutive(EPFNo, Name, ContactNo, Designation, LocationId, Email, Active);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void UpdateExecutive(int ExecutiveId, string EPFNo, string Name, string ContactNo, string Designation, int LocationId, string Email, bool Active)
        {
            try
            {
                objLeadDAL.UpdateExecutive(ExecutiveId, EPFNo, Name, ContactNo, Designation, LocationId, Email, Active);

                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public DataTable GetExecutiveLeads(DateTime fromDate, DateTime todate, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objLeadDAL.GetExecutiveLeads(fromDate, todate, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }


        #endregion
    }
}

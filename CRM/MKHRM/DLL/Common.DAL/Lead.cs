﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
   public class Lead
    {
        #region Fields

        private SqlConnection _dbConnection;
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
        private long _executiveID = 0;
        private long _locationID = 0;
        private long _activityID = 0;
        private long _productID = 0;

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

        public long ExecutiveID
        {
            get { return _executiveID; }
        }

        public long LocationID
        {
            get { return _locationID; }
        }

        public long ActivityID
        {
            get { return _activityID; }
        }

        public long ProductID
        {
            get { return _productID; }
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

            #region Constructor
      #region Constructor
            public Lead()
            {
                _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            }
        #endregion
        #endregion

          #region Methods

            public void OpenDb()
            {
                if (_dbConnection.State != ConnectionState.Open)
                {
                    _dbConnection.Open();
                }
            }

         #endregion


            public DataTable GetLeadCode(int LocationId)
            {
                DataTable dtTable = new DataTable();
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_GETLeadNo", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@LocationId", LocationId);
                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();

                }
                return dtTable;
            }

            public DataTable getLeadDetailsInfo(int LeadNo, int LocationId)
            {
                DataTable dtTable = new DataTable();
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_GetLeadDetails", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@LeadNo", LeadNo);
                        command.Parameters.AddWithValue("@LocationId", LocationId);
                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();

                }
                return dtTable;
            }

            public DataTable getLeadPaymentInfo(int PaymentId)
            {
                DataTable dtTable = new DataTable();
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_GetLeadPayment", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@PaymentId", PaymentId);
                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();

                }
                return dtTable;
            }



            public void AddLead(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leadDate, bool IsQuotation, int LocationId, string CreateUser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_AddLead",_dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@LeadNo",leadNo);
                        command.Parameters.AddWithValue("@CustomerId",customerId);
                        command.Parameters.AddWithValue("@LeadSource",leadSource);
                        command.Parameters.AddWithValue("@SpecialInstruction",specialInstruction);
                        command.Parameters.AddWithValue("@LeadDate", leadDate);
                        command.Parameters.AddWithValue("@IsQuotation", IsQuotation);
                        command.Parameters.AddWithValue("@LocationId", LocationId);
                        command.Parameters.AddWithValue("@CreateUser", CreateUser);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally 
                { 
                    _dbConnection.Close();
                }
            }


            public void UpdateLead(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leadDate, string UpdateUser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_UpdateLead", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@LeadSource", leadSource);
                        command.Parameters.AddWithValue("@SpecialInstruction", specialInstruction);
                        command.Parameters.AddWithValue("@LeadDate", leadDate);
                        command.Parameters.AddWithValue("@UpdateUser", UpdateUser);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public DataTable getQuationLead(int LeadNo)
            {
                DataTable dtTable = new DataTable();
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_GetQuationLead", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@LeadNo", LeadNo);
                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();

                }
                return dtTable;
            }



            public void UpdateLeadfalse(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leadDate, bool IsQuotation, string UpdateUser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_UpdateLeadfalse", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@LeadSource", leadSource);
                        command.Parameters.AddWithValue("@SpecialInstruction", specialInstruction);
                        command.Parameters.AddWithValue("@LeadDate", leadDate);
                        command.Parameters.AddWithValue("@IsQuotation", IsQuotation);
                        command.Parameters.AddWithValue("@UpdateUser", UpdateUser);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public void AddLeadFalse(string leadNo, long customerId, string leadSource, string specialInstruction, DateTime leadDate, bool IsQuotation, string CreateUser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_AddLeadFalse", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@CustomerId", customerId);
                        command.Parameters.AddWithValue("@LeadSource", leadSource);
                        command.Parameters.AddWithValue("@SpecialInstruction", specialInstruction);
                        command.Parameters.AddWithValue("@LeadDate", leadDate);
                        command.Parameters.AddWithValue("@IsQuotation", IsQuotation);
                        command.Parameters.AddWithValue("@CreateUser", CreateUser);
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public void AddLeadPayment(int leadNo, long CustomerId, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Createuser, int LocationId)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_UpdateLeadPayment", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@PaymentmethodId", PaymentmethodId);
                        command.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Payemnt", Payment);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Createuser", Createuser);
                        command.Parameters.AddWithValue("@LocationId", LocationId);

                        SqlParameter paymentId = new SqlParameter("@paymentId", SqlDbType.Int, 16);
                        paymentId.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paymentId);

                        command.ExecuteNonQuery();
                        _paymentId = Convert.ToInt64(paymentId.Value);

                        if (_paymentId < 0)
                        {
                            _isError = true;
                            _errorMsg = "Record Already Exists!";
                        }

                    

                       

                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }


            public void UpdateLeadPayment(int PaymentId, int leadNo, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string UpdateUser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_LeadUpdatePayment", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@paymentId", PaymentId);
                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@PaymentmethodId", PaymentmethodId);
                        command.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Payemnt", Payment);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@UpdateUser", UpdateUser);
                        command.ExecuteNonQuery();
                       
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public void AddLeadPaymentDirect(int leadNo, long CustomerId, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Bank, string DepositDate, string Createuser, int LocationId)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_ADDLeadPaymentDirect", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@CustomerId", CustomerId);
                        command.Parameters.AddWithValue("@PaymentmethodId", PaymentmethodId);
                        command.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Payemnt", Payment);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Bank", Bank);
                        command.Parameters.AddWithValue("@DepositDate", DepositDate);
                        command.Parameters.AddWithValue("@Createuser", Createuser);
                        command.Parameters.AddWithValue("@LocationId", LocationId);

                        SqlParameter paymentId = new SqlParameter("@paymentId", SqlDbType.Int, 16);
                        paymentId.Direction = ParameterDirection.Output;
                        command.Parameters.Add(paymentId);

                        command.ExecuteNonQuery();
                        _paymentId = Convert.ToInt64(paymentId.Value);

                        if (_paymentId < 0)
                        {
                            _isError = true;
                            _errorMsg = "Record Already Exists!";
                        }





                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }


            public void UpdateLeadPaymentDirect(int PaymentId, int leadNo, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Bank, string DepositDate, string Createuser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_UpdateLeadPaymentDirect", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@PaymentId", PaymentId);
                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@PaymentmethodId", PaymentmethodId);
                        command.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Payemnt", Payment);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Bank", Bank);
                        command.Parameters.AddWithValue("@DepositDate", DepositDate);
                        command.Parameters.AddWithValue("@Createuser", Createuser);
                        command.ExecuteNonQuery();
                     

                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }


            public void UpdateLeadPaymentCheque(int PaymentId, int leadNo, int PaymentmethodId, string ReceiptNo, string Description, string Payment, string Amount, string Bank, string Branch, string ChequeNo, string Createuser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_UpdateLeadPaymentCheque", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@PaymentId", PaymentId);
                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@PaymentmethodId", PaymentmethodId);
                        command.Parameters.AddWithValue("@ReceiptNo", ReceiptNo);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@Payemnt", Payment);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Bank", Bank);
                        command.Parameters.AddWithValue("@Branch", Branch);
                        command.Parameters.AddWithValue("@ChequeNo", ChequeNo);
                        command.Parameters.AddWithValue("@Createuser", Createuser);
                        command.ExecuteNonQuery();


                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }



            public void AddChequePayment(int PaymentId,int leadNo, string ChequeNo, string Bank, string Branch, string Comment, string Createuser)
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_AddChequePayment", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@PaymentId", PaymentId);
                        command.Parameters.AddWithValue("@LeadNo", leadNo);
                        command.Parameters.AddWithValue("@ChequeNo", ChequeNo);
                        command.Parameters.AddWithValue("@Bank", Bank);
                        command.Parameters.AddWithValue("@Branch", Branch);
                        command.Parameters.AddWithValue("@Comment", Comment);
                        command.Parameters.AddWithValue("@Createuser", Createuser);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();
                }
            }

            public DataTable viewCustomerPayments(int PLeadNo, string PQuoNu, int PSalesPerson, int PCustomerName, int LocationId)
            {

                DataTable dtTable = new DataTable();

                try
                {

                    using (SqlCommand command = new SqlCommand("CRM_GetPaymentDetail", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@PLeadNo", PLeadNo);
                        command.Parameters.AddWithValue("@PQuoNu", PQuoNu);
                        command.Parameters.AddWithValue("@PSalesPersonId", PSalesPerson);
                        command.Parameters.AddWithValue("@PCustomerId", PCustomerName);
                        command.Parameters.AddWithValue("@LocationId", LocationId);

                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();


                }
                return dtTable;

            }




            public DataTable GetLeadPayment(string LeadNo, string QuotationNo, string ContactNo, int LocationId)
            {
                DataTable dtTable = new DataTable();
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_GetLeadsPayment", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@LeadNo", LeadNo);
                        command.Parameters.AddWithValue("@QuotationNo", QuotationNo);
                        command.Parameters.AddWithValue("@ContactNo", ContactNo);
                        command.Parameters.AddWithValue("@LocationId", LocationId);
                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();

                }
                return dtTable;
            }

            public DataTable GetLeadsCount(string LeadNo, string QuotationNo, int LocationId)
            {
                DataTable dtTable = new DataTable();
                try
                {
                    using (SqlCommand command = new SqlCommand("CRM_GetLeadsCount", _dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();
                        command.Parameters.AddWithValue("@LeadNo", LeadNo);
                        command.Parameters.AddWithValue("@QuotationNo", QuotationNo);
                        command.Parameters.AddWithValue("@LocationId", LocationId);
                        using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                        {
                            daAdapter.Fill(dtTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally
                {
                    _dbConnection.Close();

                }
                return dtTable;
            }

        public void AddDetails(DataTable tbl)
        {
            try
            {

                using (SqlCommand command = new SqlCommand("CRM_AddLead", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                  //  command.Parameters.AddWithValue("@LeadNo", leadNo);
                  //  command.Parameters.AddWithValue("@CustomerId", customerId);
                   // command.Parameters.AddWithValue("@LeadSource", leadSource);
                  //  command.Parameters.AddWithValue("@SpecialInstruction", specialInstruction);
                   // command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

        public void AddLeadCustomerCOM(string contactNo, string contactNo2, string name, string name2, string nameTitle, string address)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CRM_AddLeadCustomerCOM", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@ContactNo2", contactNo2);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Name2", name2);
                    command.Parameters.AddWithValue("@NameTitle", nameTitle);
                    command.Parameters.AddWithValue("@Address", address);

                    SqlParameter customerId = new SqlParameter("@CustomerId", SqlDbType.BigInt, 16);
                    customerId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(customerId);

                    command.ExecuteNonQuery();
                    _customerId = Convert.ToInt64(customerId.Value);
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }

            //return _customerId;
        }

        public void AddLeadCustomer(string contactNo, string contactNo2, string name, string name2, string nameTitle, string address)
        {
            try
                {
                    using (SqlCommand command = new SqlCommand("CRM_AddLeadCustomer",_dbConnection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        OpenDb();

                        command.Parameters.AddWithValue("@ContactNo",contactNo);
                        command.Parameters.AddWithValue("@ContactNo2", contactNo2);
                        command.Parameters.AddWithValue("@Name",name);
                        command.Parameters.AddWithValue("@Name2", name2);
                        command.Parameters.AddWithValue("@NameTitle", nameTitle);
                        command.Parameters.AddWithValue("@Address",address);

                        SqlParameter customerId = new SqlParameter("@CustomerId", SqlDbType.BigInt,16);
                        customerId.Direction = ParameterDirection.Output;
                        command.Parameters.Add(customerId);

                        command.ExecuteNonQuery();
                        _customerId = Convert.ToInt64(customerId.Value);
                    }
                }
                catch (Exception ex)
                {
                    _isError = true;
                    _errorMsg = ex.Message;
                }
                finally 
                { 
                    _dbConnection.Close();
                }

            //return _customerId;
        }

        public void UpdateLeadCustomer(string LeadNo, string contactNo, string contactNo2, string name, string name2, string nameTitle, string address, string UpdateUser)
        {
            try
            {
                using (SqlCommand command = new SqlCommand("CRM_UpdateLeadCustomer", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@LeadNo", LeadNo);
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    command.Parameters.AddWithValue("@ContactNo2", contactNo2);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Name2", name2);
                    command.Parameters.AddWithValue("@NameTitle", nameTitle);
                    command.Parameters.AddWithValue("@Address", address);
                    command.Parameters.AddWithValue("@UpdateUser", UpdateUser);
                    SqlParameter customerId = new SqlParameter("@CustomerId", SqlDbType.BigInt, 16);
                    customerId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(customerId);

                    command.ExecuteNonQuery();
                    _customerId = Convert.ToInt64(customerId.Value);
                   
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }

           
        }
        public DataTable GetCustomerDetail(string contactNo)
        {
            DataTable dtTable = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("CRM_GetCustomerDetail", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();
                    command.Parameters.AddWithValue("@ContactNo", contactNo);
                    using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                    {
                        daAdapter.Fill(dtTable);
                    }
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();

            }
            return dtTable;
        }



        public void AddLeadProduct(string leadNo, int productId, string productDescription, string quantity, string comment, int LocationId)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("CRM_AddLeadProduct", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@LeadNo", leadNo);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@ProductDescription", productDescription);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Comment", comment);
                    command.Parameters.AddWithValue("@LocationId", LocationId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        public void UpdateLeadProduct(string leadNo, int productId, string productDescription, string quantity, string comment, int LocationId)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("CRM_UpdateLeadProduct", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@LeadNo", leadNo);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@ProductDescription", productDescription);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Comment", comment);
                    command.Parameters.AddWithValue("@LocationId", LocationId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        public void UpdateLeadProduct(int leadDetailId, string leadNo, int productId, string productDescription, string quantity, string comment, int LocationId)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("CRM_UpdateLeadProduct", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@LeadDetailId", leadDetailId);
                    command.Parameters.AddWithValue("@LeadNo", leadNo);
                    command.Parameters.AddWithValue("@ProductName", productId);
                    command.Parameters.AddWithValue("@ProductDescription", productDescription);
                    command.Parameters.AddWithValue("@Quantity", quantity);
                    command.Parameters.AddWithValue("@Comment", comment);
                    command.Parameters.AddWithValue("@LocationId", LocationId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        public void DeleteLeadDetail(string LeadNo, int LocationId)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("CRM_DeleteLeadDetail", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();
                    command.Parameters.AddWithValue("@LeadNo", LeadNo);
                    command.Parameters.AddWithValue("@LocationId", LocationId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }


        public void DeleteLeadPayment(int PaymentId, int LeadNo)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("CRM_DeleteLeadPayment", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@PaymentId", PaymentId);
                    command.Parameters.AddWithValue("@LeadNo", LeadNo);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

         public void DeleteLeadProduct(int leadDetailId,string LeadNo, int LocationId)
        {

            try
            {
                using (SqlCommand command = new SqlCommand("CRM_DeleteLeadProduct", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    OpenDb();

                    command.Parameters.AddWithValue("@LeadDetailId", leadDetailId);
                    command.Parameters.AddWithValue("@LeadNo", LeadNo);
                    command.Parameters.AddWithValue("@LocationId", LocationId);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
        }

         # region Activity

         public void AddActivityType(string ProcessCode, string ProcessActivityDes, string ActivityType, string Description,bool Active)
         {
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_AddActivityType", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@ProcessCode", ProcessCode);
                     command.Parameters.AddWithValue("@ProcessActivityDes", ProcessActivityDes);
                     command.Parameters.AddWithValue("@Type", ActivityType);
                     command.Parameters.AddWithValue("@Description", Description);
                     command.Parameters.AddWithValue("@Active", Active);

                     SqlParameter activityId = new SqlParameter("@ActivityId", SqlDbType.Int, 16);
                     activityId.Direction = ParameterDirection.Output;
                     command.Parameters.Add(activityId);
                     command.ExecuteNonQuery();
                     _activityID = Convert.ToInt64(activityId.Value);

                     if (_activityID < 0)
                     {
                         _isError = true;
                         _errorMsg = "Record Already Exists!";
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         public void UpdateActivityType(int ActivityId, string ProcessCode, string ProcessActivityDes, string ActivityType, string Description, bool Active)
         {

             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_UpdateActivityType", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@ActivityId", ActivityId);
                     command.Parameters.AddWithValue("@ProcessCode", ProcessCode);
                     command.Parameters.AddWithValue("@ProcessActivityDes", ProcessActivityDes);
                     command.Parameters.AddWithValue("@Type", ActivityType);
                     command.Parameters.AddWithValue("@Description", Description);
                     command.Parameters.AddWithValue("@Active", Active);
                     command.ExecuteNonQuery();
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         #endregion

        # region Product

         public void AddProduct(string ItemCode, string ItemName, string ItemDescription, string SpecialDescription,bool Active)
         {
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_AddProduct", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@ItemCode", ItemCode);
                     command.Parameters.AddWithValue("@ItemName", ItemName);
                     command.Parameters.AddWithValue("@ItemDescription", ItemDescription);
                     command.Parameters.AddWithValue("@SpecialDescription", SpecialDescription);
                     command.Parameters.AddWithValue("@Active", Active);


                     SqlParameter productId = new SqlParameter("@Product", SqlDbType.Int, 16);
                     productId.Direction = ParameterDirection.Output;
                     command.Parameters.Add(productId);
                     command.ExecuteNonQuery();
                     _productID = Convert.ToInt64(productId.Value);

                     if (_productID < 0)
                     {
                         _isError = true;
                         _errorMsg = "Record Already Exists!";
                     }

                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         public void UpdateProduct(int ItemId, string ItemCode, string ItemName, string ItemDescription, string SpecialDescription,bool Active)
         {

             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_UpdateProduct", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@ItemId", ItemId);
                     command.Parameters.AddWithValue("@ItemCode", ItemCode);
                     command.Parameters.AddWithValue("@ItemName", ItemName);
                     command.Parameters.AddWithValue("@ItemDescription", ItemDescription);
                     command.Parameters.AddWithValue("@SpecialDescription", SpecialDescription);
                     command.Parameters.AddWithValue("@Active", Active);

                     command.ExecuteNonQuery();
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }
         public DataTable GetLeadHistory(DateTime fromDate,DateTime todate,string status,int LocationId)
         {
             DataTable dtTable = new DataTable();
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_GetLeadHistory", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();
                     command.Parameters.AddWithValue("@FromDate", fromDate);
                     command.Parameters.AddWithValue("@ToDate", todate);
                     command.Parameters.AddWithValue("@status", status);
                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                     {
                         daAdapter.Fill(dtTable);
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();

             }
             return dtTable;
         }


         public DataTable GetJobHistory(DateTime fromDate, DateTime todate, string status, int LocationId)
         {
             DataTable dtTable = new DataTable();
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_GetJobHistory", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();
                     command.Parameters.AddWithValue("@FromDate", fromDate);
                     command.Parameters.AddWithValue("@ToDate", todate);
                     command.Parameters.AddWithValue("@status", status);
                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                     {
                         daAdapter.Fill(dtTable);
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();

             }
             return dtTable;
         }


         public DataTable GetJobActivity(DateTime fromDate, DateTime todate, string fromLead, string toLead, int LocationId)
         {
             DataTable dtTable = new DataTable();
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_AssignActivityType", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();
                     command.Parameters.AddWithValue("@FromDate", fromDate);
                     command.Parameters.AddWithValue("@ToDate", todate);
                     command.Parameters.AddWithValue("@FromLead", fromLead);
                     command.Parameters.AddWithValue("@ToLead", toLead);
                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                     {
                         daAdapter.Fill(dtTable);
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();

             }
             return dtTable;
         }


        #endregion

         # region Company Location

         public void AddLocation(string LocationCode, string LocationName, bool IsActive, string CreateUser)
         {
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_AddLocation", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@LocationCode", LocationCode);
                     command.Parameters.AddWithValue("@LocationName", LocationName);
                     command.Parameters.AddWithValue("@IsActive", IsActive);
                     command.Parameters.AddWithValue("@CreateUser", CreateUser);

                     SqlParameter LocationID = new SqlParameter("@LocationID", SqlDbType.Int, 16);
                     LocationID.Direction = ParameterDirection.Output;
                     command.Parameters.Add(LocationID);
                     command.ExecuteNonQuery();
                     _locationID = Convert.ToInt64(LocationID.Value);

                     if (_locationID < 0)
                     {
                         _isError = true;
                         _errorMsg = "Record Already Exists!";
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         public void UpdateLocation(int LocationId, string LocationCode, string LocationName, bool IsActive, string UpdateUser)
         {

             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_UpdateLocation", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     command.Parameters.AddWithValue("@LocationCode", LocationCode);
                     command.Parameters.AddWithValue("@LocationName", LocationName);
                     command.Parameters.AddWithValue("@IsActive", IsActive);
                     command.Parameters.AddWithValue("@UpdateUser", UpdateUser);

                     command.ExecuteNonQuery();
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         #endregion

         # region Product

         public void AddExecutive(string EPFNo, string Name, string ContactNo, string Designation, int LocationId, string Email ,bool Active)
         {
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_AddExecutive", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@EPFNo", EPFNo);
                     command.Parameters.AddWithValue("@Name", Name);
                     command.Parameters.AddWithValue("@ContactNo", ContactNo);
                     command.Parameters.AddWithValue("@Designation", Designation);
                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     command.Parameters.AddWithValue("@Email", Email);
                     command.Parameters.AddWithValue("@Active", Active);


                     SqlParameter ExecutiveID = new SqlParameter("@ExecutiveID", SqlDbType.Int, 16);
                     ExecutiveID.Direction = ParameterDirection.Output;
                     command.Parameters.Add(ExecutiveID);
                     command.ExecuteNonQuery();
                     _executiveID = Convert.ToInt64(ExecutiveID.Value);

                     if (_executiveID < 0)
                     {
                         _isError = true;
                         _errorMsg = "Employee Code Already Exists!";
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         public void UpdateExecutive(int ExecutiveId, string EPFNo, string Name, string ContactNo, string Designation, int LocationId, string Email,bool Active)
         {

             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_UpdateExecutive", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();

                     command.Parameters.AddWithValue("@ExecutiveId", ExecutiveId);
                     command.Parameters.AddWithValue("@EPFNo", EPFNo);
                     command.Parameters.AddWithValue("@Name", Name);
                     command.Parameters.AddWithValue("@ContactNo", ContactNo);
                     command.Parameters.AddWithValue("@Designation", Designation);
                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     command.Parameters.AddWithValue("@Email", Email);
                     command.Parameters.AddWithValue("@Active", Active);

                     command.ExecuteNonQuery();
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();
             }
         }

         public DataTable GetExecutiveLeads(DateTime fromDate, DateTime todate, int LocationId)
         {
             DataTable dtTable = new DataTable();
             try
             {
                 using (SqlCommand command = new SqlCommand("CRM_GetExecutiveLeads", _dbConnection))
                 {
                     command.CommandType = CommandType.StoredProcedure;
                     OpenDb();
                     command.Parameters.AddWithValue("@FromDate", fromDate);
                     command.Parameters.AddWithValue("@ToDate", todate);
                     command.Parameters.AddWithValue("@LocationId", LocationId);
                     using (SqlDataAdapter daAdapter = new SqlDataAdapter(command))
                     {
                         daAdapter.Fill(dtTable);
                     }
                 }
             }
             catch (Exception ex)
             {
                 _isError = true;
                 _errorMsg = ex.Message;
             }
             finally
             {
                 _dbConnection.Close();

             }
             return dtTable;
         }

         #endregion
    }
}

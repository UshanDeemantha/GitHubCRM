using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAL;
using System.Data;
using System.Configuration;


namespace Common.BL
{
    public class User
    {

        #region Fields
        private string _errorMsg = string.Empty;
        private int _errorNo = 0;
        private bool _isError = false;
        private bool _isSuccess = false;
        private string _result = string.Empty;
        DAL.User objUserDAL;
        #endregion

        #region Logged User Fields
        private long _loggedUserEmployeeId;
        private string _loggedUserEmployeeCode;
        private string _loggedUserEmployeeName;
        private int _loggedUserUserType;
        private string _loggedUserUserName;
        private int _loggedUserCompanyId;
        #endregion

        #region Properties
        public string ErrorMsg
        {
            get { return _errorMsg; }
        }

        public int ErrorNo
        {
            get { return _errorNo; }
        }

        public bool IsError
        {
            get { return _isError; }
        }

        public bool IsSuccess
        {
            get { return _isSuccess; }
        }

        public string Result
        {
            get { return _result; }
        }

        #region Logged User Properties
        public long LoggedUserEmployeeId
        {
            get { return _loggedUserEmployeeId; }
        }

        public string LoggedUserEmployeeCode
        {
            get { return _loggedUserEmployeeCode; }
        }

        public string LoggedUserEmployeeName
        {
            get { return _loggedUserEmployeeName; }
        }

        public int LoggedUserUserType
        {
            get { return _loggedUserUserType; }
        }

        public string LoggedUserUserName
        {
            get { return _loggedUserUserName; }
        }

        public int LoggedUserCompanyId
        {
            get { return _loggedUserCompanyId; }
        }
        #endregion
        #endregion

        #region Constructor
        public User()
        {
            objUserDAL = new DAL.User();
        }
        #endregion

        #region Methods
        private void SetValues()
        {
            if (objUserDAL.IsSuccess)
            {
                _isSuccess = true;
            }
            else
            {
                _isSuccess = false;
            }
            if (_isError == true)
            {
                switch (_errorNo)
                {
                    case 2601: _errorMsg = ConfigurationManager.AppSettings["Duplicate"].ToString();
                        break;
                    case 2627: _errorMsg = ConfigurationManager.AppSettings["Duplicate"].ToString();
                        break;
                    default:
                        break;
                }
            }
            _isError = objUserDAL.IsError;
            _errorNo = objUserDAL.ErrorNo;
            _errorMsg = objUserDAL.ErrorMsg;
            _loggedUserEmployeeCode = objUserDAL.LoggedUserEmployeeCode;
            _loggedUserEmployeeId = objUserDAL.LoggedUserEmployeeId;
            _loggedUserEmployeeName = objUserDAL.LoggedUserEmployeeName;
            _loggedUserUserName = objUserDAL.LoggedUserUserName;
            _loggedUserUserType = objUserDAL.LoggedUserUserType;
            _loggedUserCompanyId = objUserDAL.LoggedUserCompanyId;
        }
        #region User Authentication
        public string UserAuthentication(string UserName, string Password)
        {
            try
            {
                _result = objUserDAL.UserAuthentication(UserName, Password);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _isSuccess = false;
                _errorMsg = ex.Message;
            }
            return _result;
        }

        public DataTable GetUserLoginLocation(string UserName)
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetUserLoginLocation(UserName);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        #endregion

         public string UserAuthenticationPassword(string Password)
        {
            try
            {
                _result = objUserDAL.UserAuthenticationPassword(Password);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _isSuccess = false;
                _errorMsg = ex.Message;
            }
            return _result;
        }
        #endregion

        public void ValidateUserName(string EmployeeNo, string UserName)
        {
            try
            {
                objUserDAL.ValidateUserName(EmployeeNo, UserName);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void ValidateUserPassport(string EmployeeNo, string Passport)
        {
            try
            {
                objUserDAL.ValidateUserPassport(EmployeeNo, Passport);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public int Save_UserRole(int UserRoleid, string Level)
        {
            int a = 0;
            try
            {
                a = objUserDAL.Save_UserRole(UserRoleid, Level);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return a;
        }

        public int Delete_UserRoleList(int UserId, int LocationId)
        {
            int a = 0;
            try
            {
                a = objUserDAL.Delete_UserRoleList(UserId, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return a;
        }

        public void ValidateSecurityQuestion(long EmployeeId, string SecurityQuestion, string Answer)
        {
            try
            {
                objUserDAL.ValidateSecurityQuestion(EmployeeId, SecurityQuestion, Answer);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public string GetSecurityQuestion(long EmployeeId)
        {
            string SecurityQuestion = string.Empty;
            try
            {
                SecurityQuestion = objUserDAL.GetSecurityQuestion(EmployeeId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return SecurityQuestion;
        }

        public DataTable GetUserLoginDetails(long EmployeeId)
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetUserLoginDetails(EmployeeId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public void AddUserLoginDetails(long EmployeeId, string SecurityQuestion, string Answer, long ModifiedUser, DateTime ModifiedDate, string Password, string Newpassword)
        {
            try
            {
                objUserDAL.AddUserLoginDetails(EmployeeId, SecurityQuestion, Answer, ModifiedUser, ModifiedDate, Password, Newpassword);
                _result = objUserDAL.Result;
                _isSuccess = objUserDAL.IsSuccess;
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }

        }

        public void AddUserLoginDetails(int UserTypeId, string UserName, long ModifiedUser, DateTime ModifiedDate, string Password, bool Bloked, int LocationId)
        {
            try
            {
                objUserDAL.AddUserLoginDetails(UserTypeId, UserName, ModifiedUser, ModifiedDate, Password, Bloked, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateUserLoginDetails(int UserTypeId, string UserName, long ModifieddUser, DateTime ModifiedDate, bool Bloked)
        {
            try
            {
                objUserDAL.UpdateUserLoginDetails(UserTypeId, UserName, ModifieddUser, ModifiedDate, Bloked);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public int AddUserType(string UserTypeName, bool Active)
        {
           try
            {
             return   objUserDAL.AddUserType(UserTypeName, Active);
            }
           catch (Exception ex)
            {
               _isError = true;
                _errorMsg = ex.Message;
                return 2;
            }
          
        }


        public void UpdateUserType(int UserTypeId,string UserTypeName, bool Active)
        {
            try
            {
                objUserDAL.UpdateUserType(UserTypeId,UserTypeName, Active);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public DataTable GetUserDetails()
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetUserDetails();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public void UpadteUserLoginDetails(long EmployeeId, string SecurityQuestion, string Answer, long ModifiedUser, DateTime ModifiedDate, string Password, string UserName, int UserTypeId)
        {
            try
            {
                objUserDAL.UpadteUserLoginDetails(EmployeeId, SecurityQuestion, Answer, ModifiedUser, ModifiedDate, Password, UserName, UserTypeId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void RestrictUser(long EmployeeId, long ModifiedUser, DateTime ModifiedDate)
        {
            try
            {
                objUserDAL.RestrictUser(EmployeeId, ModifiedUser, ModifiedDate);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public DataTable GetPORSystemForms()
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetPORSystemForms();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public DataTable GetPORLoginTypes()
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetPORLoginTypes();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public DataTable GetPORUserPermissions(int UserTypeId, int UserId, int LocationId)
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetPORUserPermissions(UserTypeId, UserId, LocationId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public void DeletePORUserPermission(int UserTypeId, int FormId)
        {
            try
            {
                objUserDAL.DeletePORUserPermission(UserTypeId, FormId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AddPORUserPermission(int UserTypeId, int FormId)
        {
            try
            {
                objUserDAL.AddPORUserPermission(UserTypeId, FormId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public DataSet GetSystemForms()
        {
            DataSet dtUser = new DataSet();
            try
            {
                dtUser = objUserDAL.GetSystemForms();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public int Save_UserRoleList(int UserTypeId, int UserId, int LocationId, int PageId, bool UserCreate, bool UserView, bool UserDelete, int TrnFlag)
        {
            try
            {
                return objUserDAL.Save_UserRoleList(UserTypeId, UserId, LocationId, PageId, UserCreate, UserView, UserDelete, TrnFlag);
            }
            catch (Exception ex)
            {

                // ErrHandler.WriteError(ex.Message);
                return 0;
            }
        }



        public DataSet GetUserRoleList(int userroleid)
        {
            DataSet dtUser = new DataSet();
            try
            {
                dtUser = objUserDAL.GetUserRoleList(userroleid);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }


        public DataSet GetMainMenu()
        {
            DataSet dtUser = new DataSet();
            try
            {
                dtUser = objUserDAL.GetMainMenu();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }


        public DataSet GetMenubyUser(int UserTypeId, int UserId, int LocationId, string menucode)
        {
            DataSet dtUser = new DataSet();
            try
            {
                dtUser = objUserDAL.GetMenubyUser(UserTypeId, UserId, LocationId, menucode);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public DataTable GetLeadForSearch(int LocationId)
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetLeadForSearch(LocationId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }

        public DataTable GetLeadActivityForSearch(int LocationId)
        {
            DataTable dtUser = new DataTable();
            try
            {
                dtUser = objUserDAL.GetLeadActivityForSearch(LocationId);
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
            return dtUser;
        }


        public void AssingActivity(long CustomerId, DataTable tbl, string CreateUser, int LocationId)
        {
            try
            {

                foreach (DataRow row in tbl.Rows)
                {
                    objUserDAL.AssighActivity(CustomerId,row["LeadNo"].ToString(), row["Subject"].ToString(), row["Activity"].ToString(), Convert.ToDateTime(row["DueDate"].ToString()), Convert.ToInt32(row["ActivityOwnerID"].ToString()),
                        row["StatusID"].ToString(), CreateUser, LocationId);
                }


                SetValues();
            }
            catch (Exception ex)
            {

                _isError = true;
                _errorMsg = ex.Message;
            }
        }



        //public void AssingActivity(string LeadNu, string CusNu,string Subject,string Activity,DateTime DuDate,string owner,string Status,string modifyUser)
        //{
        //    try
        //    {
        //        objUserDAL.AssighActivity(LeadNu, CusNu, Subject, Activity, DuDate, owner, Status, modifyUser);
        //        SetValues();
        //    }
        //    catch (Exception ex)
        //    {
        //        _isError = true;
        //        _errorMsg = ex.Message;
        //    }
        //}
        public void UpdateAssighActivity(long ActivityId, string LeadNo, string subject, long CustmerId, string Activity, int owner, string Status, string Comment, DateTime DuDate, string modifyUser, int LocationId)
        {
            try
            {
                objUserDAL.UpdateAssighActivity(ActivityId, LeadNo, subject, CustmerId, Activity, owner, Status, Comment, DuDate, modifyUser, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateAssighActivity(long ActivityId, string LeadNo, string subject, long CustmerId, string Activity, int owner, string Status, string Comment, DateTime DuDate, string modifyUser,bool isQuatation,string quation, int LocationId)
        {
            try
            {
                objUserDAL.UpdateAssighActivity(ActivityId, LeadNo, subject, CustmerId, Activity, owner, Status, Comment, DuDate, modifyUser, isQuatation, quation, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }



        public void DeleteAssingActivity(long AssingLeadsId)
        {
            try
            {
                objUserDAL.DeleteAssingActivity(AssingLeadsId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void AssingLeads(string LeadName, int LeadId, long CustomerId, int LeadOwner, string Status, bool Quatation, string createUser, int LocationId)
        {
            try
            {
                objUserDAL.AssingLeads(LeadName, LeadId, CustomerId, LeadOwner, Status, Quatation, createUser, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateLeadsExecutive(long AssingLeadsId, string LeadNo, long CustomerId, int LeadOwner, string Status, bool Quatation, int LocationId, string UpdateUser)
        {
            try
            {
                objUserDAL.UpdateLeadsExecutive(AssingLeadsId, LeadNo, CustomerId, LeadOwner, Status, Quatation, LocationId, UpdateUser);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }


        public void UpdateAssingLeadsQuotation(long AssingLeadsId, string LeadName, long CustomerId, int LeadOwner, string Status, string Comment, string UpdateUser, DateTime ModifiedUser, string QuotationNo, int LocationId)
        {
            try
            {
                objUserDAL.UpdateAssingLeadsQuotation(AssingLeadsId, LeadName, CustomerId, LeadOwner, Status, Comment, UpdateUser, ModifiedUser, QuotationNo, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public void UpdateAssingLeads(long AssingLeadsId, string LeadName, long CustomerId, int LeadOwner, string Status, string Comment, string UpdateUser, DateTime ModifiedUser, int LocationId)
        {
            try
            {
                objUserDAL.UpdateAssingLeads(AssingLeadsId, LeadName, CustomerId, LeadOwner, Status, Comment, UpdateUser, ModifiedUser, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }
        public void DeleteAssingLeads(long AssingLeadsId)
        {
            try
            {
                objUserDAL.DeleteAssingLeads(AssingLeadsId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
            }
        }

        public DataTable GetLeadOwner(string LeadNo, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objUserDAL.GetLeadOwner(LeadNo, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

        public DataTable GetLeadCustomer(string LeadNo, int LocationId)
        {
            DataTable dataTable = new DataTable();
            try
            {
                dataTable = objUserDAL.GetLeadCustomer(LeadNo, LocationId);
                SetValues();
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;

            }
            return dataTable;
        }

    }
}

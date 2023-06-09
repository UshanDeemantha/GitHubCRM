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
    public class User
    {
        #region Fields
        private SqlConnection _dbConnection;
        private string _errorMsg = string.Empty;
        private int _errorNo = 0;
        private bool _isError = false;
        private bool _sqlError = false;
        private bool _isSuccess = false;
        private string _result = string.Empty;
        private string _sqlException;
        private long _assignId = 0;
        private long _activId = 0;


        #region Logged User Fields
        private long _loggedUserEmployeeId;
        private string _loggedUserEmployeeCode;
        private string _loggedUserEmployeeName;
        private int _loggedUserUserType;
        private string _loggedUserUserName;
        private int _loggedUserCompanyId;
        #endregion
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

        public bool SqlError
        {
            get { return _sqlError; }
        }

        public bool IsSuccess
        {
            get { return _isSuccess; }
        }

        public string Result
        {
            get { return _result; }
        }

        public string SqlException
        {
            get { return _sqlException; }
        }

        public long AssingId
        {
            get { return _assignId; }
        }


          public long ActivityId
        {
            get { return _activId; }
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
            _dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        #endregion

        #region Methods
        #region Internal
        private void OpenDb()
        {
            if (_dbConnection.State != ConnectionState.Open)
            {
                _dbConnection.Open();
            }
            InitializeFields();
        }

        private void InitializeFields()
        {
            _isError = false;
            _errorMsg = string.Empty;
            _errorNo = int.MinValue;
            _isSuccess = true;
            _result = string.Empty;
            _sqlException = string.Empty;
            _sqlError = false;
        }

        private void SetError(SqlException Ex)
        {
            _isSuccess = false;
            _isError = true;
            _errorMsg = Ex.Message;
            _result = string.Empty;
            _errorNo = Ex.Number;
            _sqlException = Ex.Message;
            _sqlError = true;
        }
        #endregion

        public string UserAuthentication(string Username, string Password)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UserAuthentication", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Usernameinput", Username);
                    command.Parameters.AddWithValue("@Password", Password);

                    SqlParameter EmployeeId = new SqlParameter("@Id", SqlDbType.Int, 64);
                    EmployeeId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(EmployeeId);

                    SqlParameter UserType = new SqlParameter("@UserType", SqlDbType.Int, 32);
                    UserType.Direction = ParameterDirection.Output;
                    command.Parameters.Add(UserType);
                    SqlParameter UserName = new SqlParameter("@UserName", SqlDbType.VarChar, 50);
                    UserName.Direction = ParameterDirection.Output;
                    command.Parameters.Add(UserName);
                    SqlParameter Result = new SqlParameter("@Result", SqlDbType.VarChar, 50);
                    Result.Direction = ParameterDirection.Output;
                    command.Parameters.Add(Result);

                    SqlParameter Success = new SqlParameter("@Success", SqlDbType.Bit);
                    Success.Direction = ParameterDirection.Output;
                    command.Parameters.Add(Success);

                    //SqlParameter CompId = new SqlParameter("@CompanyId", SqlDbType.Int, 32);
                    //Success.Direction = ParameterDirection.Output;
                    //command.Parameters.Add(CompId);

                    command.ExecuteNonQuery();

                    if (Convert.ToBoolean(Success.Value) == true)
                    {
                        _isSuccess = true;
                        _loggedUserEmployeeId = Convert.ToInt64(EmployeeId.Value);
                        _loggedUserUserType = Convert.ToInt32(UserType.Value);
                        _loggedUserUserName = UserName.Value.ToString();
                        _result = Result.Value.ToString();
                       
                    }
                    else
                    {
                        _isSuccess = false;
                        _result = Result.Value.ToString();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                SetError(sqlEx);
            }
            catch (Exception ex)
            {
                _isError = true;
                _isSuccess = false;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
            return _result;
        }

        public DataTable GetUserLoginLocation(string UserName)
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_GetUserLoginLocation", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserName", UserName);

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }

        public string UserAuthenticationPassword(string Password)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UserAuthenticationPassword", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                 
                    command.Parameters.AddWithValue("@Password", Password);
                    
                    SqlParameter Result = new SqlParameter("@Result", SqlDbType.VarChar, 50);
                    Result.Direction = ParameterDirection.Output;
                    command.Parameters.Add(Result);

                    SqlParameter Success = new SqlParameter("@Success", SqlDbType.Bit);
                    Success.Direction = ParameterDirection.Output;
                    command.Parameters.Add(Success);

                    command.ExecuteNonQuery();

                    if (Convert.ToBoolean(Success.Value) == true)
                    {
                    
                        _result = Result.Value.ToString();

                    }
                    else
                    {
                        _isSuccess = false;
                        _result = Result.Value.ToString();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                SetError(sqlEx);
            }
            catch (Exception ex)
            {
                _isError = true;
                _isSuccess = false;
                _errorMsg = ex.Message;
            }
            finally
            {
                _dbConnection.Close();
            }
            return _result;
        }



        public void ValidateUserName(string EmployeeNo, string UserName)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_ValidateUserName", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeNo", EmployeeNo);
                    command.Parameters.AddWithValue("@UserName", UserName);

                    SqlParameter employeeId = new SqlParameter("@EmployeeId", SqlDbType.BigInt);
                    employeeId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(employeeId);

                    SqlParameter success = new SqlParameter("@Success", SqlDbType.Bit);
                    success.Direction = ParameterDirection.Output;
                    command.Parameters.Add(success);

                    command.ExecuteNonQuery();
                    _loggedUserEmployeeId = Convert.ToInt64(employeeId.Value);
                    _isSuccess = Convert.ToBoolean(success.Value);
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

        public void ValidateUserPassport(string EmployeeNo, string Passport)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_ValidateUserPassport", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeNo", EmployeeNo);
                    command.Parameters.AddWithValue("@Passport", Passport);

                    SqlParameter employeeId = new SqlParameter("@EmployeeId", SqlDbType.BigInt);
                    employeeId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(employeeId);

                    SqlParameter success = new SqlParameter("@Success", SqlDbType.Bit);
                    success.Direction = ParameterDirection.Output;
                    command.Parameters.Add(success);

                    command.ExecuteNonQuery();
                    _loggedUserEmployeeId = Convert.ToInt64(employeeId.Value);
                    _isSuccess = Convert.ToBoolean(success.Value);
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

        public void ValidateSecurityQuestion(long EmployeeId, string SecurityQuestion, string Answer)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_ValidateSecurityQuestion", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    command.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
                    command.Parameters.AddWithValue("@Answer", Answer);

                    SqlParameter success = new SqlParameter("@Success", SqlDbType.Bit);
                    success.Direction = ParameterDirection.Output;
                    command.Parameters.Add(success);

                    command.ExecuteNonQuery();
                    _result = success.Value.ToString();
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

        public string GetSecurityQuestion(long EmployeeId)
        {
            string SecurityQuestion = string.Empty;
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_GetSecurityQuestion", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                    SqlParameter question = new SqlParameter("@SecurityQuestion", SqlDbType.NVarChar, 500);
                    question.Direction = ParameterDirection.Output;
                    command.Parameters.Add(question);

                    command.ExecuteNonQuery();
                    SecurityQuestion = question.Value.ToString();
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
            return SecurityQuestion;
        }

        public DataTable GetUserLoginDetails(long EmployeeId)
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_GetUserLoginDetails", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }

        public void AddUserLoginDetails(long EmployeeId, string SecurityQuestion, string Answer, long ModifiedUser, DateTime ModifiedDate, string Password, string NewPassword)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_AddUserPassword", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    command.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
                    command.Parameters.AddWithValue("@Answer", Answer);
                    command.Parameters.AddWithValue("@ModifiedUser", ModifiedUser);
                    command.Parameters.AddWithValue("@ModifiedDate", ModifiedDate);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@NewPassword", NewPassword);

                    SqlParameter success = new SqlParameter("@IsSucces", SqlDbType.Bit);
                    success.Direction = ParameterDirection.Output;
                    command.Parameters.Add(success);

                    //string ss="";

                    SqlParameter result = new SqlParameter("@Result", SqlDbType.VarChar, 50);
                    result.Direction = ParameterDirection.Output;
                    command.Parameters.Add(result);

                    command.ExecuteNonQuery();
                    _isSuccess = Convert.ToBoolean(success.Value);
                    _result = result.Value.ToString();
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

        public void AddUserLoginDetails(int UserTypeId, string UserName, long CreatedUser, DateTime CreatedDate, string Password, bool Bloked, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_AddUserLoginDetails", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@CreatedUser", CreatedUser);
                    command.Parameters.AddWithValue("@CreatedDate", CreatedDate);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Active", Bloked);
                    command.Parameters.AddWithValue("@LocationId", LocationId);


                    SqlParameter createId = new SqlParameter("@CreateID", SqlDbType.Int, 16);
                    createId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(createId);
                    command.ExecuteNonQuery();

                    _loggedUserEmployeeId = Convert.ToInt64(createId.Value);

                    if (_loggedUserEmployeeId < 0)
                    {
                        _isError = true;
                        _errorMsg = "User Name Is  Already Exists!";
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

        public void UpdateUserLoginDetails(int UserTypeId, string UserName, long ModifieddUser, DateTime ModifiedDate, bool Bloked)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateUserLoginDetails", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LoginTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@ModifiedUser", ModifieddUser);
                    command.Parameters.AddWithValue("@ModifiedDate", ModifiedDate);
                    command.Parameters.AddWithValue("@Bloked", Bloked);
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



        public int AddUserType(string UserTypeName, bool Active)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_AddUserType", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeName", UserTypeName);
                    command.Parameters.AddWithValue("@Active", Active);

                    SqlParameter UserTypeNames = new SqlParameter("@sss", SqlDbType.Int);
                    UserTypeNames.Direction = ParameterDirection.Output;
                    command.Parameters.Add(UserTypeNames);

                    command.ExecuteNonQuery();
                    int s = Convert.ToInt32(UserTypeNames.Value);
                    return Convert.ToInt32(UserTypeNames.Value);
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
            return 2;
        }

        public void UpdateUserType(int UserTypeId, string UserTypeName, bool Active)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateUserType", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeid", UserTypeId);
                    command.Parameters.AddWithValue("@UserTypeName", UserTypeName);
                    command.Parameters.AddWithValue("@Active", Active);


                    command.ExecuteNonQuery();
                    //_isSuccess = Convert.ToBoolean(success.Value);
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

        public DataTable GetUserType()
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_GetUser", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }


        public DataTable GetUserDetails()
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_GetUser", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }

        public void UpadteUserLoginDetails(long EmployeeId, string SecurityQuestion, string Answer, long ModifiedUser, DateTime ModifiedDate, string Password, string UserName, int UserTypeId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_UpdateUser", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    command.Parameters.AddWithValue("@SecurityQuestion", SecurityQuestion);
                    command.Parameters.AddWithValue("@Answer", Answer);
                    command.Parameters.AddWithValue("@ModifiedUser", ModifiedUser);
                    command.Parameters.AddWithValue("@ModifiedDate", ModifiedDate);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@UserName", UserName);
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);


                    //SqlParameter success = new SqlParameter("@IsSucces", SqlDbType.Bit);
                    //success.Direction = ParameterDirection.Output;
                    //command.Parameters.Add(success);

                    //SqlParameter result = new SqlParameter("@Result", SqlDbType.VarChar,50);
                    //success.Direction = ParameterDirection.Output;
                    //command.Parameters.Add(result);

                    command.ExecuteNonQuery();
                    //_isSuccess = Convert.ToBoolean(success.Value);
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

        public void RestrictUser(long EmployeeId, long ModifiedUser, DateTime ModifiedDate)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_RestrictUser", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                    command.Parameters.AddWithValue("@ModifiedUser", ModifiedUser);
                    command.Parameters.AddWithValue("@ModifiedDate", ModifiedDate);

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

        public DataTable GetPORSystemForms()
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_GetPORSystemForms", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }


        public DataTable GetPORLoginTypes()
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_GetLoginTypes", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }


        public DataTable GetPORUserPermissions(int UserTypeId,int UserId, int LocationId)
        {
            DataTable dtUser = new DataTable();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_GetUserPermissions", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@UserID", UserId);
                    command.Parameters.AddWithValue("@LocationId", LocationId);
                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }



        public void DeletePORUserPermission(int UserTypeId, int FormId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_DeletePORUserPermission", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@FormId", FormId);


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


        public void AddPORUserPermission(int UserTypeId, int FormId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("POR_AddPORUserPermission", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@FormId", FormId);


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
        public DataSet GetSystemForms()
        {
            DataSet dtforms = new DataSet();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_GetForms", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtforms);
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
            return dtforms;
        }

        public DataSet GetUserRoleList(int userroleid)
        {
            DataSet dtforms = new DataSet();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UserRoleList_S", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserRoleID", userroleid);

                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtforms);
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
            return dtforms;
        }

        public int Save_UserRole(int UserRoleid, string UserLvl)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("PRO_UserRole_UI", _dbConnection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserRoleID", UserRoleid);
                    command.Parameters.AddWithValue("@UserRole", UserLvl);

                    SqlParameter NewID = new SqlParameter("@NewID", SqlDbType.Int);
                    NewID.Direction = ParameterDirection.Output;
                    command.Parameters.Add(NewID);

                    SqlParameter RetCode = new SqlParameter("@RetCode", SqlDbType.Int);
                    RetCode.Direction = ParameterDirection.Output;
                    command.Parameters.Add(RetCode);

                    SqlParameter RetText = new SqlParameter("@RetText", SqlDbType.VarChar, 255);
                    RetText.Direction = ParameterDirection.Output;
                    command.Parameters.Add(RetText);


                    command.ExecuteNonQuery();
                    return Convert.ToInt32(NewID.Value);

                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
                return 0;
            }
            finally
            {
                _dbConnection.Close();

            }
        }

        public int Delete_UserRoleList(int UserId, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_DeleteUserRoleList_UI", _dbConnection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@LocationId", LocationId);

                    command.ExecuteNonQuery();
                    return 1;

                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
                return 0;
            }
            finally
            {
                _dbConnection.Close();

            }
        }

        public int Save_UserRoleList(int UserTypeId, int UserId, int LocationId, int PageId, bool UserCreate, bool UserView, bool UserDelete, int TrnFlag)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UserRoleList_UI", _dbConnection))
                {


                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@LocationId", LocationId);
                    command.Parameters.AddWithValue("@PageId", PageId);
                    command.Parameters.AddWithValue("@UserCreate", UserCreate);
                    command.Parameters.AddWithValue("@UserView", UserView);
                    command.Parameters.AddWithValue("@UserDelete", UserDelete);
                    command.Parameters.AddWithValue("@TrnFlag", TrnFlag);

                    command.ExecuteNonQuery();
                    return 1;

                }
            }
            catch (Exception ex)
            {
                _isError = true;
                _errorMsg = ex.Message;
                return 0;
            }
            finally
            {
                _dbConnection.Close();

            }
        }

        public DataSet GetMainMenu()
        {
            DataSet dtforms = new DataSet();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_GetMenu", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;



                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtforms);
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
            return dtforms;
        }

        public DataSet GetMenubyUser(int UserTypeId, int UserId, int LocationId, string menucode)
        {
            DataSet dtforms = new DataSet();

            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_View_UserForms", _dbConnection))
                {

                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserTypeId", UserTypeId);
                    command.Parameters.AddWithValue("@UserId", UserId);
                    command.Parameters.AddWithValue("@LocationId", LocationId);
                    command.Parameters.AddWithValue("@MenuCode", menucode);


                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtforms);
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
            return dtforms;
        }

        public void AssighActivity(long CustomerId,string LeadNu, string Subject, string Activity, DateTime DateTime, int owner, string Status, string CreateUser,int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_AssighActivity", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LeadNumber", LeadNu);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@Subject", Subject);
                    command.Parameters.AddWithValue("@Activity", Activity);
                    command.Parameters.AddWithValue("@Duedate", DateTime);
                    command.Parameters.AddWithValue("@owner", owner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@ModifiedUser", CreateUser);
                    command.Parameters.AddWithValue("@LocationId", LocationId);


                    SqlParameter activId = new SqlParameter("@Activ", SqlDbType.Int, 16);
                    activId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(activId);
                    command.ExecuteNonQuery();
                    _activId = Convert.ToInt64(activId.Value);

                    if (_activId < 0)
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

        public void UpdateAssighActivity(long ActivityId,string LeadNo, string subject, long CustmerId, string Activity, int owner, string Status, string Comment, DateTime DuDate, string ModifiedUser, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateAssighActivity", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ActivityId", ActivityId);
                    command.Parameters.AddWithValue("@LeadNo", LeadNo);
                    command.Parameters.AddWithValue("@Subject", subject);
                    command.Parameters.AddWithValue("@CustmerId", CustmerId);
                    command.Parameters.AddWithValue("@Activity", Activity);
                    command.Parameters.AddWithValue("@owner", owner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Comment", Comment);
                    command.Parameters.AddWithValue("@DuDate", DuDate);
                    command.Parameters.AddWithValue("@ModifiedUser", ModifiedUser);
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

        public void UpdateAssighActivity(long ActivityId, string LeadNo, string subject, long CustmerId, string Activity, int owner, string Status, string Comment, DateTime DuDate, string ModifiedUser, bool Isquation, string Quation, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateAssighActivityWithQuation", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ActivityId", ActivityId);
                    command.Parameters.AddWithValue("@LeadNo", LeadNo);
                    command.Parameters.AddWithValue("@Subject", subject);
                    command.Parameters.AddWithValue("@CustmerId", CustmerId);
                    command.Parameters.AddWithValue("@Activity", Activity);
                    command.Parameters.AddWithValue("@owner", owner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Comment", Comment);
                    command.Parameters.AddWithValue("@DuDate", DuDate);
                    command.Parameters.AddWithValue("@ModifiedUser", ModifiedUser);
                    command.Parameters.AddWithValue("@Isquation", Isquation);
                    command.Parameters.AddWithValue("@Quation", Quation);
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


        public void DeleteAssingActivity(long AssingLeadsId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_DeleteAssingActivity", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AssingLeadsId", AssingLeadsId);


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

        public void AssingLeads(string LeadName, int LeadId, long CustomerId, int LeadOwner, string Status, bool Quatation, string createUser, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_AssingLeads", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LeadName", LeadName);
                    command.Parameters.AddWithValue("@LeadId", LeadId);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@LeadOwner", LeadOwner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Quatation", Quatation);
                    command.Parameters.AddWithValue("@CreateUser", createUser);
                    command.Parameters.AddWithValue("@LocationId", LocationId);

                    SqlParameter assingId = new SqlParameter("@AssignId", SqlDbType.Int, 16);
                    assingId.Direction = ParameterDirection.Output;
                    command.Parameters.Add(assingId);
                    command.ExecuteNonQuery();
                    _assignId = Convert.ToInt64(assingId.Value);

                    if (_assignId < 0)
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

        public void UpdateLeadsExecutive(long AssingLeadsId, string LeadNo, long CustomerId, int LeadOwner, string Status, bool Quatation, int LocationId, string UpdateUser)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateExecutiveInLeads", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AssingLeadsId", AssingLeadsId);
                    command.Parameters.AddWithValue("@LeadName", LeadNo);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@LeadOwner", LeadOwner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Quatation", Quatation);
                    command.Parameters.AddWithValue("@LocationId", LocationId);
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

        public void AddQuotationNo(string LeadName, bool Quotation, string QuotationNo, long CustomerId, int LeadOwner, string Comment, string UpdateUser)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_AddQuotationNo", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@LeadName", LeadName);
                    command.Parameters.AddWithValue("@Quotation", Quotation);
                    command.Parameters.AddWithValue("@QuotationNo", QuotationNo);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@LeadOwner", LeadOwner);
                    command.Parameters.AddWithValue("@Comment", Comment);
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


        public void UpdateAssingLeadsQuotation(long AssingLeadsId, string LeadName, long CustomerId, int LeadOwner, string Status, string Comment, string UpdateUser, DateTime ModifiedUser, string QuotationNo, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateAssingLeadsQuotation", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AssingLeadsId", AssingLeadsId);
                    command.Parameters.AddWithValue("@LeadName", LeadName);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@LeadOwner", LeadOwner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Comment", Comment);
                    command.Parameters.AddWithValue("@UpdateUser", UpdateUser);
                    command.Parameters.AddWithValue("@ModifiedDate", ModifiedUser);
                    command.Parameters.AddWithValue("@QuotationNo", QuotationNo);
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





        public void UpdateAssingLeads(long AssingLeadsId, string LeadName, long CustomerId, int LeadOwner, string Status, string Comment, string UpdateUser, DateTime ModifiedUser, int LocationId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_UpdateAssingLeads", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AssingLeadsId", AssingLeadsId);
                    command.Parameters.AddWithValue("@LeadName", LeadName);
                    command.Parameters.AddWithValue("@CustomerId", CustomerId);
                    command.Parameters.AddWithValue("@LeadOwner", LeadOwner);
                    command.Parameters.AddWithValue("@Status", Status);
                    command.Parameters.AddWithValue("@Comment", Comment);
                    command.Parameters.AddWithValue("@UpdateUser", UpdateUser);
                    command.Parameters.AddWithValue("@ModifiedDate", ModifiedUser);
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

        public void DeleteAssingLeads(long AssingLeadsId)
        {
            try
            {
                OpenDb();
                using (SqlCommand command = new SqlCommand("CRM_DeleteAssingLeads", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@AssingLeadsId", AssingLeadsId);


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

        public DataTable GetLeadForSearch(int LocationId)
        {
            DataTable dtUser = new DataTable();

            try
            {
               
                using (SqlCommand command = new SqlCommand("CRM_GetLeadForSearch", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    OpenDb();
                    command.Parameters.AddWithValue("@LocationId", LocationId);
                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }


        public DataTable GetLeadActivityForSearch(int LocationId)
        {
            DataTable dtUser = new DataTable();

            try
            {
                
                using (SqlCommand command = new SqlCommand("CRM_GetLeadActivityForSearch", _dbConnection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    OpenDb();
                    command.Parameters.AddWithValue("@LocationId", LocationId);
                    using (SqlDataAdapter daUser = new SqlDataAdapter(command))
                    {
                        daUser.Fill(dtUser);
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
            return dtUser;
        }

        public DataTable GetLeadOwner(string LeadNo, int LocationId)
        {
            DataTable dtTable = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("CRM_GetLeadOwner", _dbConnection))
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


        public DataTable GetLeadCustomer(string LeadNo, int LocationId)
        {
            DataTable dtTable = new DataTable();
            try
            {
                using (SqlCommand command = new SqlCommand("CRM_GetLeadCustomer", _dbConnection))
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


        #endregion

    }
}


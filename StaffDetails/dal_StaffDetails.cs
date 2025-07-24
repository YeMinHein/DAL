using BOL;
using BOL.GM;
using BOL.StaffDetails;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.StaffDetails
{
    public class dal_StaffDetails
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_StaffDetails() { }

        public IEnumerable<bol_StaffDetails> GetPOSCustomerList(bol_StaffDetails bol)
        {
            List<bol_StaffDetails> imgsetups = new List<bol_StaffDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_StaffDetails imgsetup = new bol_StaffDetails();
                        imgsetup.customerAccountNumber = dr["CustomerAccNo"] == null ? null : dr["CustomerAccNo"].ToString();
                        imgsetups.Add(imgsetup);
                    }
                }

            }
            catch (Exception ex)
            {
                string s=ex.Message.ToString();
                Console.Write(s);
            }
            return imgsetups;


        }

        public ResultMsg POSCustomerInsertStaffID(bol_StaffDetails bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }
        public IEnumerable<bol_StaffDetails_Progress> GetProgress(bol_StaffDetails bol)
        {
            List<bol_StaffDetails_Progress> imgsetups = new List<bol_StaffDetails_Progress>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_StaffDetails_Progress imgsetup = new bol_StaffDetails_Progress();
                        imgsetup.AllCount = dr["AllCount"] == null ? 0 : Convert.ToInt32(dr["AllCount"].ToString());
                        imgsetup.HaveStaffIDCount = dr["HaveStaffIDCount"] == null ? 0 : Convert.ToInt32(dr["HaveStaffIDCount"].ToString());
                        imgsetup.CurrentProgress = dr["CurrentProgress"] == null ? 0 : Convert.ToInt32(dr["CurrentProgress"].ToString());
                        imgsetups.Add(imgsetup);
                    }
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Console.Write(s);
            }
            return imgsetups;


        }

        public IEnumerable<bol_StaffDetails> GetPOSCustomerDataByCustAccNo(bol_StaffDetails bol)
        {
            List<bol_StaffDetails> imgsetups = new List<bol_StaffDetails>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_StaffDetails imgsetup = new bol_StaffDetails();
                        imgsetup.customerAccountNumber = dr["CustomerAccNo"] == null ? null : dr["CustomerAccNo"].ToString();
                        imgsetup.CustomerName = dr["CustomerName"] == null ? null : dr["CustomerName"].ToString();
                        imgsetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                        imgsetup.POS_ExternalId = dr["POS_ExternalId"] == null ? null : dr["POS_ExternalId"].ToString();
                        imgsetup.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                        imgsetups.Add(imgsetup);
                    }
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Console.Write(s);
            }
            return imgsetups;


        }
        public IEnumerable<bol_GetStaffData> GetStaffData(bol_GetStaffData bol)
        {
            List<bol_GetStaffData> imgsetups = new List<bol_GetStaffData>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 5);
                    cmd.Parameters.AddWithValue("@username", bol.username);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetStaffData imgsetup = new bol_GetStaffData();
                        imgsetup.fullName = dr["fullName"] == null ? null : dr["fullName"].ToString();
                        imgsetup.externalId = dr["externalId"] == null ? null : dr["externalId"].ToString();
                        imgsetup.TeamID = dr["TeamID"] == null ? 0 : Convert.ToInt32(dr["TeamID"].ToString());
                        imgsetup.IsSetOwner = dr["IsSetOwner"] == null ? false : Convert.ToBoolean(dr["IsSetOwner"].ToString());
                        imgsetups.Add(imgsetup);
                    }
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Console.Write(s);
            }
            return imgsetups;


        }

        public IEnumerable<bol_GetStaffData> GetSalesStaffList(bol_GetStaffData bol)
        {
            List<bol_GetStaffData> imgsetups = new List<bol_GetStaffData>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 6);
                    cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetStaffData imgsetup = new bol_GetStaffData();
                        imgsetup.fullName = dr["StaffName"] == null ? null : dr["StaffName"].ToString();
                        imgsetup.externalId = dr["POS_ExternalId"] == null ? null : dr["POS_ExternalId"].ToString();
                        imgsetups.Add(imgsetup);
                    }
                }

            }
            catch (Exception ex)
            {
                string s = ex.Message.ToString();
                Console.Write(s);
            }
            return imgsetups;


        }
        public ResultMsg UpdateOwner(bol_StaffDetails bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@POS_ExternalId", bol.POS_ExternalId);
                    cmd.Parameters.AddWithValue("@username", bol.UpdatedBy);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg UpdatePasswordValidity(bol_GM_SysParams bol)
        {
            string resp_code = "0";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_UpdatePasswordValidityPeriod", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@iStrValue", bol.KeyValue ?? (object)DBNull.Value);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = (string)cmd.ExecuteScalar();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            return new ResultMsg() { Result = resp_code };
        }        

        public ResultMsg GetStaffLoginHistory(bol_StaffLoginHistory bol)
        {
            string resp_code = "0";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {                    
                    SqlCommand cmd = new SqlCommand("sp_StaffLogInHistory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.userName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@loginDate", bol.loginDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@logoutDate", bol.logoutDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@status", bol.status ?? (object)DBNull.Value);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = (string)cmd.ExecuteScalar();
                    con.Close();                                     
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            return new ResultMsg() { Result = resp_code };           
        }
    }
}

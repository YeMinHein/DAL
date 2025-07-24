using BOL;
using BOL.URM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.URM
{
    public class dal_URM_Setup
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

     
        public IEnumerable<bol_URM_Setup> GetList(bol_URM_Setup bol)
        {
            List<bol_URM_Setup> csetups = new List<bol_URM_Setup>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_URM_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@userName", bol.userName);
                cmd.Parameters.AddWithValue("@UserRole", bol.userrole);
                cmd.Parameters.AddWithValue("@departmentName", bol.departmentName);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                cmd.Parameters.AddWithValue("@SearchIsActive", bol.SearchIsActive);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_URM_Setup csetup = new bol_URM_Setup();
                    //csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    csetup.userName = dr["userName"] == null ? null : dr["userName"].ToString();
                    csetup.fullName = dr["fullName"] == null ? null : dr["fullName"].ToString();
                    csetup.mobileNo = dr["mobileNo"] == null ? null : dr["mobileNo"].ToString();
                    csetup.email = dr["email"] == null ? null : dr["email"].ToString();
                    csetup.role = dr["role"] == null ? null : dr["role"].ToString();
                    csetup.status = dr["status"] == null ? null : dr["status"].ToString();
                    csetup.IsActive = dr["status"] == DBNull.Value ? false : bool.Parse(dr["status"].ToString());
                    csetup.BillingArea = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
                    csetup.departmentName = dr["departmentName"] == null ? null : dr["departmentName"].ToString();
                    csetup.POS_ExternalId = dr["POS_ExternalId"] == null ? null : dr["POS_ExternalId"].ToString();
                    csetup.slackID = dr["slackID"] == null ? null : dr["slackID"].ToString();
                    if (dr["employeeID"] == DBNull.Value)
                    {
                        csetup.employeeID = null;
                    }
                    else
                    {
                        csetup.employeeID = Convert.ToInt32(dr["employeeID"]);
                    }
                    if (dr["joinDate"] == DBNull.Value)
                    {
                        csetup.joinDate = null;
                    }
                    else
                    {
                        csetup.joinDate = Convert.ToDateTime(dr["joinDate"]);
                        //csetup.joinDatestring = ((DateTime)dr["joinDate"]).ToString("dd/MM/yyyy");  
                        csetup.joinDatestring = ((DateTime)dr["joinDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    if (dr["resignDate"] == DBNull.Value)
                    {
                        csetup.resignDate = null;
                    }
                    else
                    {
                        csetup.resignDate = Convert.ToDateTime(dr["resignDate"]);
                        //csetup.resignDatestring = ((DateTime)dr["resignDate"]).ToString("dd/MM/yyyy");
                        csetup.resignDatestring = ((DateTime)dr["resignDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }                    
                    csetup.location = dr["LocationName"] == null ? null : dr["LocationName"].ToString();
                    csetup.city = dr["CityName"] == null ? null : dr["CityName"].ToString();
                    csetup.position = dr["PositionName"] == null ? null : dr["PositionName"].ToString();
                    csetup.team = dr["TeamName"] == null ? null : dr["TeamName"].ToString();
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        public bol_URM_Setup GetByUserName(bol_URM_Setup bol)
        {
            bol_URM_Setup csetup = new bol_URM_Setup();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_URM_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@userName", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    csetup.userName = dr["userName"] == null ? null : dr["userName"].ToString();
                    csetup.fullName = dr["fullName"] == null ? null : dr["fullName"].ToString();
                    csetup.password = dr["password"] == null ? null : dr["password"].ToString();
                    csetup.mobileNo = dr["mobileNo"] == null ? null : dr["mobileNo"].ToString();
                    csetup.email = dr["email"] == null ? null : dr["email"].ToString();
                    csetup.role = dr["role"] == null ? null : dr["role"].ToString();
                    csetup.roleName = dr["roleName"] == null ? null : dr["roleName"].ToString();
                    csetup.isSuperAdmin = dr["isSuperAdmin"] == null ? false : Convert.ToBoolean(dr["isSuperAdmin"]);
                    csetup.isDepartmentAdmin = dr["isDepartmentAdmin"] == null ? false : Convert.ToBoolean(dr["isDepartmentAdmin"]);
                    csetup.status = dr["status"] == null ? null : dr["status"].ToString();
                    csetup.IsActive = dr["status"] == DBNull.Value ? false : bool.Parse(dr["status"].ToString());
                    csetup.BillingArea = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
                    csetup.departmentName = dr["departmentName"] == null ? null : dr["departmentName"].ToString();
                    csetup.POS_ExternalId = dr["POS_ExternalId"] == null ? null : dr["POS_ExternalId"].ToString().Trim();
                    //csetup.employeeID = Convert.ToInt32(dr["employeeID"] == null ? "0" : dr["employeeID"]);
                    string employeeID = dr["employeeID"].ToString();
                    if (employeeID == null || employeeID == "")
                    {
                        csetup.employeeID = 0;
                    }
                    else
                    {
                        csetup.employeeID = Convert.ToInt32(dr["employeeID"]);
                    }
                    //csetup.joinDate = Convert.ToDateTime(dr["joinDate"] == null ? null : dr["joinDate"]);
                    string joinDate = dr["joinDate"].ToString();
                    if (joinDate == null || joinDate == "")
                    {
                        csetup.joinDate = null;
                    }
                    else
                    {
                        csetup.joinDate = Convert.ToDateTime(dr["joinDate"]);
                    }
                    //csetup.resignDate = Convert.ToDateTime(dr["resignDate"] == null ? null : dr["resignDate"]);
                    string resigndate = dr["resignDate"].ToString();
                    if (resigndate == null || resigndate == "")
                    {
                        csetup.resignDate = null;
                    }
                    else
                    {
                        csetup.resignDate = Convert.ToDateTime(dr["resignDate"]);
                    }
                    csetup.location = dr["locationName"] == null ? null : dr["locationName"].ToString().Trim();
                    csetup.city = dr["cityName"] == null ? null : dr["cityName"].ToString().Trim();
                    csetup.slackID = dr["slackID"] == null ? null : dr["slackID"].ToString().Trim();
                    csetup.position = dr["positionName"] == null ? null : dr["positionName"].ToString().Trim();
                    csetup.team = dr["teamName"] == null ? null : dr["teamName"].ToString().Trim();
                }
            }
            return csetup;
        }


        public bol_URM_Setup GetByUserRole(bol_URM_Setup bol)
        {
            bol_URM_Setup csetup = new bol_URM_Setup();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_URM_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@userName", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    csetup.userrole = dr["Role"] == null ? null : dr["Role"].ToString();

                }
            }
            return csetup;
        }

        public ResultMsg Insert(bol_URM_Setup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_URM_Setup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);
                    cmd.Parameters.AddWithValue("@password", bol.password);
                    cmd.Parameters.AddWithValue("@fullName", bol.fullName);
                    cmd.Parameters.AddWithValue("@mobileNo", bol.mobileNo);
                    cmd.Parameters.AddWithValue("@email", bol.email);
                    cmd.Parameters.AddWithValue("@role", bol.role);
                    cmd.Parameters.AddWithValue("@departmentName", bol.departmentName);
                    cmd.Parameters.AddWithValue("@status", bol.status);
                    cmd.Parameters.AddWithValue("@is_POS_Staff", bol.is_POS_Staff);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@POS_ExternalId", bol.POS_ExternalId);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@employeeID", bol.employeeID);
                    cmd.Parameters.AddWithValue("@joinDate", bol.joinDate);
                    cmd.Parameters.AddWithValue("@resignDate", bol.resignDate);
                    cmd.Parameters.AddWithValue("@location", bol.location);
                    cmd.Parameters.AddWithValue("@city", bol.city);
                    cmd.Parameters.AddWithValue("@slackID", bol.slackID);
                    cmd.Parameters.AddWithValue("@position", bol.position);
                    cmd.Parameters.AddWithValue("@team", bol.team);

                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg Update(bol_URM_Setup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_URM_Setup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Connection = con;
                    //SqlParameter parameter = new SqlParameter();
                    //parameter.ParameterName = "@RegionName";
                    //parameter.SqlDbType = System.Data.SqlDbType.Structured;
                    //parameter.Value = bol.RegionName;
                    //cmd.Parameters.Add(parameter);

                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);
                    cmd.Parameters.AddWithValue("@password", bol.password);
                    cmd.Parameters.AddWithValue("@fullName", bol.fullName);
                    cmd.Parameters.AddWithValue("@mobileNo", bol.mobileNo);
                    cmd.Parameters.AddWithValue("@email", bol.email);
                    cmd.Parameters.AddWithValue("@role", bol.role);
                    cmd.Parameters.AddWithValue("@departmentName", bol.departmentName);
                    cmd.Parameters.AddWithValue("@status", bol.status);
                    cmd.Parameters.AddWithValue("@is_POS_Staff", bol.is_POS_Staff);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@POS_ExternalId", bol.POS_ExternalId);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@ModifyBy", bol.ModifyBy); 
                    cmd.Parameters.AddWithValue("@employeeID", bol.employeeID);
                    cmd.Parameters.AddWithValue("@joinDate", bol.joinDate);
                    cmd.Parameters.AddWithValue("@resignDate", bol.resignDate);
                    cmd.Parameters.AddWithValue("@location", bol.location);
                    cmd.Parameters.AddWithValue("@city", bol.city);
                    cmd.Parameters.AddWithValue("@slackID", bol.slackID);
                    cmd.Parameters.AddWithValue("@position", bol.position);
                    cmd.Parameters.AddWithValue("@team", bol.team);

                    //cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                //return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };

            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg GetURMCount(bol_URM_Setup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_URM_Setup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);
                    cmd.Parameters.AddWithValue("@UserRole", bol.userrole);
                    cmd.Parameters.AddWithValue("@departmentName", bol.departmentName);
                    cmd.Parameters.AddWithValue("@SearchIsActive", bol.SearchIsActive);
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

        public ResultMsg GetAppRole(bol_App_Role bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_App_Role", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@App", bol.App);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);

                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }
    }
}

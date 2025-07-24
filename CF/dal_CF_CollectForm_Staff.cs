using BOL;
using BOL.CF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CF
{
   public class dal_CF_CollectForm_Staff
    {
        private string conn_str = dal_ConfigManager.GTG;
        private ResultMsg result = new ResultMsg();

        public dal_CF_CollectForm_Staff()
        {
        }

        public ResultMsg InsertStaffALL(bol_CF_CollectForm_Staff_Model bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_Staff", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam",bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@IsAdmin", bol.IsAdmin);
                    cmd.Parameters.AddWithValue("@IsChkListPermission", bol.IsChkListPermission);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
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

        public ResultMsg CheckListPermission(bol_CF_CollectForm_Staff_Model bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_Staff", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@UserName", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@IsAdmin", bol.IsAdmin);
                    cmd.Parameters.AddWithValue("@IsChkListPermission", bol.IsChkListPermission);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
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

        public ResultMsg InsertStaffByCity(bol_CF_CollectForm_Staff_Model bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_Staff", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@IsAdmin", bol.IsAdmin);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
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

        public List<bol_CF_CollectForm_Staff> GetAllStaffBySearchText(bol_CF_CollectForm_Staff_Model bol)
        {
            List<bol_CF_CollectForm_Staff> staffs = new List<bol_CF_CollectForm_Staff>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam",6);
                cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@IsAdmin", bol.IsAdmin);
                //cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@LeadAssignDepartmentID", bol.LeadAssignDepartmentID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_CF_CollectForm_Staff st = new bol_CF_CollectForm_Staff();
                    st.UserName = dr["UserName"].ToString();
                    st.FullName = dr["FullName"].ToString();
                    st.MobileNo = dr["MobileNo"].ToString();
                    st.Email = dr["Email"].ToString();
                    st.RoleName = dr["RoleName"].ToString();
                    st.DepartmentID = Convert.ToInt32(dr["DepartmentID"].ToString());
                    st.DepartmentName = dr["DepartmentName"].ToString();
                    st.IsSuperAdmin = Convert.ToBoolean(dr["IsSuperAdmin"].ToString());
                    st.IsDepartmentAdmin = Convert.ToBoolean(dr["IsDepartmentAdmin"].ToString());
                    staffs.Add(st);
                }
            }
            if (staffs.Count <= 0)
            {
                return null;
            }
            return staffs;
        }

        //Action 4 CF Staffcount ,5 only city township
        public List<bol_CF_CollectForm_Staf_CityTownship> GetAllCityTownship(bol_CF_CollectForm_Staff_Model bol)
        {
            List<bol_CF_CollectForm_Staf_CityTownship> staffs = new List<bol_CF_CollectForm_Staf_CityTownship>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@IsAdmin", bol.IsAdmin);
                //cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_CF_CollectForm_Staf_CityTownship st = new bol_CF_CollectForm_Staf_CityTownship();
                    st.City_ID =Convert.ToInt32(dr["City_ID"].ToString());
                    st.Township_ID = Convert.ToInt32(dr["Township_ID"].ToString());
                    st.CityName = dr["CityName"].ToString();
                    st.TownshipName = dr["TownshipName"].ToString();
                    st.StaffCounts = dr["StaffCounts"].ToString();
                    st.StaffNames = dr["StaffNames"].ToString();
                    st.StaffBind = dr["StaffBind"].ToString();
                    st.CityActive = Convert.ToBoolean(dr["CityActive"].ToString());
                    st.TSActive =Convert.ToBoolean(dr["TSActive"].ToString());
                    staffs.Add(st);
                }
            }
            if (staffs.Count <= 0)
            {
                return null;
            }
            return staffs;
        }

        public List<bol_CF_CollectForm_Staf_CityTownship> GetAllCityByUsername(bol_CF_CollectForm_Staff_Model bol)
        {
            List<bol_CF_CollectForm_Staf_CityTownship> staffs = new List<bol_CF_CollectForm_Staf_CityTownship>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@IsAdmin", bol.IsAdmin);
               // cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_CF_CollectForm_Staf_CityTownship st = new bol_CF_CollectForm_Staf_CityTownship();
                    st.City_ID = Convert.ToInt32(dr["City_ID"].ToString());
                    st.Township_ID = Convert.ToInt32(dr["Township_ID"].ToString());
                    st.CityName = dr["CityName"].ToString();
                    st.TownshipName = dr["TownshipName"].ToString();
                    st.IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                    st.IsChkListPermission = Convert.ToBoolean(dr["IsChkListPermission"].ToString());
                    staffs.Add(st);
                }
            }
            //if (staffs.Count <= 0)
            //{
            //    return null;
            //}
            return staffs;
        }

        public List<bol_CF_GetAllStaffChkPermission_Model> GetAllStaffChkPermission(bol_CF_GetAllStaffChkPermission_Model bol)
        {
            List<bol_CF_GetAllStaffChkPermission_Model> staffs = new List<bol_CF_GetAllStaffChkPermission_Model>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_CF_GetAllStaffChkPermission_Model st = new bol_CF_GetAllStaffChkPermission_Model();
                    st.UserName = dr["UserName"].ToString();
                    staffs.Add(st);
                }
            }
            if (staffs.Count <= 0)
            {
                return null;
            }
            return staffs;
        }
    }
}

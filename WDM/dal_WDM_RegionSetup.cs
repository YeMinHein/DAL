using BOL;
using BOL.WDM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WDM
{
    public class dal_WDM_RegionSetup
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_WDM_RegionSetup() { }

        public IEnumerable<bol_WDM_RegionSetup> GetList(bol_WDM_RegionSetup bol)
        {
            List<bol_WDM_RegionSetup> rsetups = new List<bol_WDM_RegionSetup>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_RegionSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_RegionSetup rsetup = new bol_WDM_RegionSetup();
                    rsetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    rsetup.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    rsetup.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    rsetup.Prefix = dr["Prefix"] == null ? null : dr["Prefix"].ToString();
                    rsetup.City = dr["City"] == null ? null : dr["City"].ToString();
                    rsetup.SortOrder = dr["SortOrder"] == DBNull.Value ? 0 : int.Parse(dr["SortOrder"].ToString());
                    rsetup.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    rsetups.Add(rsetup);
                }
            }
            return rsetups;


        }

        public bol_WDM_RegionSetup GetByID(bol_WDM_RegionSetup bol)
        {
            bol_WDM_RegionSetup rsetup = new bol_WDM_RegionSetup();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_RegionSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rsetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    rsetup.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    rsetup.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    rsetup.Prefix = dr["Prefix"] == null ? null : dr["Prefix"].ToString();
                    rsetup.City = dr["City"] == null ? null : dr["City"].ToString();
                    rsetup.SortOrder = dr["SortOrder"] == DBNull.Value ? 0 : int.Parse(dr["SortOrder"].ToString());
                    rsetup.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                }
            }
            return rsetup;
        }

        public ResultMsg Insert(bol_WDM_RegionSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_RegionSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@RegionName", bol.RegionName);
                    cmd.Parameters.AddWithValue("@Prefix", bol.Prefix);
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
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

        public ResultMsg Update(bol_WDM_RegionSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_RegionSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@RegionName", bol.RegionName);
                    cmd.Parameters.AddWithValue("@Prefix", bol.Prefix);
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@UpdatedDate", bol.UpdatedDate);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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

        public ResultMsg GetRegionSetupCount(bol_WDM_RegionSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_RegionSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
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
    }
}

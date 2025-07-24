using BOL;
using BOL.DD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DD
{
    public class dal_DD_RegionSetup
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_DD_RegionSetup() { }

        public IEnumerable<bol_DD_RegionSetup> GetList(bol_DD_RegionSetup bol)
        {
            List<bol_DD_RegionSetup> rsetups = new List<bol_DD_RegionSetup>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_RegionSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DD_RegionSetup rsetup = new bol_DD_RegionSetup();
                    rsetup.ID = dr["ID"] == null ? 0 : int.Parse(dr["ID"].ToString());
                    rsetup.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    rsetup.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    rsetup.Prefix = dr["Prefix"] == null ? null : dr["Prefix"].ToString();
                    rsetup.City = dr["City"] == null ? null : dr["City"].ToString();
                    rsetup.SortOrder = dr["SortOrder"] == null ? 0 : int.Parse(dr["SortOrder"].ToString());
                    rsetup.IsActive = dr["IsActive"] == null ? false : bool.Parse(dr["IsActive"].ToString());
                    rsetups.Add(rsetup);
                }
            }
            return rsetups;


        }

        public bol_DD_RegionSetup GetByID(bol_DD_RegionSetup bol)
        {
            bol_DD_RegionSetup rsetup = new bol_DD_RegionSetup();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_RegionSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rsetup.ID = dr["ID"] == null ? 0 : int.Parse(dr["ID"].ToString());
                    rsetup.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    rsetup.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    rsetup.Prefix = dr["Prefix"] == null ? null : dr["Prefix"].ToString();
                    rsetup.City = dr["City"] == null ? null : dr["City"].ToString();
                    rsetup.SortOrder = dr["SortOrder"] == null ? 0 : int.Parse(dr["SortOrder"].ToString());
                    rsetup.IsActive = dr["IsActive"] == null ? false : bool.Parse(dr["IsActive"].ToString());
                }
            }
            return rsetup;
        }

        public ResultMsg Insert(bol_DD_RegionSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_RegionSetup", con);
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

        public ResultMsg Update(bol_DD_RegionSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_RegionSetup", con);
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
    }
}

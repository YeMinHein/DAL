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
    public class dal_WDM_ComplaintSetup
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_WDM_ComplaintSetup() { }

        public IEnumerable<bol_WDM_ComplaintSetup> GetList(bol_WDM_ComplaintSetup bol)
        {
            List<bol_WDM_ComplaintSetup> csetups = new List<bol_WDM_ComplaintSetup>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_ComplaintSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_ComplaintSetup csetup = new bol_WDM_ComplaintSetup();
                    csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    csetup.Desc_eng = dr["Desc_eng"] == null ? null : dr["Desc_eng"].ToString();
                    csetup.Desc_mm = dr["Desc_mm"] == null ? null : dr["Desc_mm"].ToString();
                    csetup.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
                    csetup.Solution = dr["Solution"] == null ? null : dr["Solution"].ToString();
                    csetup.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    csetup.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        public bol_WDM_ComplaintSetup GetByID(bol_WDM_ComplaintSetup bol)
        {
            bol_WDM_ComplaintSetup csetup = new bol_WDM_ComplaintSetup();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_ComplaintSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    csetup.Desc_eng = dr["Desc_eng"] == null ? null : dr["Desc_eng"].ToString();
                    csetup.Desc_mm = dr["Desc_mm"] == null ? null : dr["Desc_mm"].ToString();
                    csetup.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
                    csetup.Solution = dr["Solution"] == null ? null : dr["Solution"].ToString();
                    csetup.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    csetup.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                }
            }
            return csetup;
        }

        public ResultMsg Insert(bol_WDM_ComplaintSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_ComplaintSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Desc_eng", bol.Desc_eng);
                    cmd.Parameters.AddWithValue("@Desc_mm", bol.Desc_mm);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@Solution", bol.Solution);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
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

        public ResultMsg Update(bol_WDM_ComplaintSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_ComplaintSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@Desc_eng", bol.Desc_eng);
                    cmd.Parameters.AddWithValue("@Desc_mm", bol.Desc_mm);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@Solution", bol.Solution);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@ModifiedDate", bol.ModifiedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", bol.ModifiedBy);
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
        public ResultMsg GetCSCount(bol_WDM_ComplaintSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_ComplaintSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
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

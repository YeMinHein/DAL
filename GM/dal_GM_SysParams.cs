using BOL;
using BOL.GM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GM
{
    public class dal_GM_SysParams
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_GM_SysParams() { }


        public IEnumerable<bol_GM_SysParams> GetList(bol_GM_SysParams bol)
        {
            List<bol_GM_SysParams> sparams = new List<bol_GM_SysParams>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_GM_SysParams sparam = new bol_GM_SysParams();
                    sparam.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    sparam.KeyName = dr["KeyName"] == null ? null : dr["KeyName"].ToString();
                    sparam.KeyValue = dr["KeyValue"] == null ? null : dr["KeyValue"].ToString();
                    sparam.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    sparam.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    sparams.Add(sparam);
                }
            }
            return sparams;
        }

        public bol_GM_SysParams GetByID(bol_GM_SysParams bol)
        {
            bol_GM_SysParams sparam = new bol_GM_SysParams();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sparam.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    sparam.KeyName = dr["KeyName"] == null ? null : dr["KeyName"].ToString();
                    sparam.KeyValue = dr["KeyValue"] == null ? null : dr["KeyValue"].ToString();
                    sparam.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    sparam.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                }
            }
            return sparam;
        }

        public ResultMsg Insert(bol_GM_SysParams bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@KeyName", bol.KeyName);
                    cmd.Parameters.AddWithValue("@KeyValue", bol.KeyValue);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
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

        public ResultMsg Update(bol_GM_SysParams bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@KeyName", bol.KeyName);
                    cmd.Parameters.AddWithValue("@KeyValue", bol.KeyValue);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
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
        
        public ResultMsg GetSysParamsCount(bol_GM_SysParams bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
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

        public bol_GM_SysParams GetSystemParamValue(bol_GM_SysParams bol)
        {
            bol_GM_SysParams sparam = new bol_GM_SysParams();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@KeyName", bol.KeyName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sparam.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    sparam.KeyName = dr["KeyName"] == null ? null : dr["KeyName"].ToString();
                    sparam.KeyValue = dr["KeyValue"] == null ? null : dr["KeyValue"].ToString();
                    sparam.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    sparam.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                }
            }
            return sparam;
        }

    }
}

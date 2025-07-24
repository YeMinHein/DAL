using BOL;
using BOL.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public class dal_API_Token
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public async Task<ResultMsg> Insert(bol_API_Token bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_API_Token", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 5; //seconds = 5sec
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@Token", bol.Token);
                    cmd.Parameters.AddWithValue("@ResponseStatus", bol.ResponseStatus);


                    cmd.Connection = con;
                    await con.OpenAsync();
                    resp_code = (int)await cmd.ExecuteScalarAsync();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };

        }


        public bol_API_Token GetToken(bol_API_Token bol)
        {
            bol_API_Token bol_t = new bol_API_Token();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_API_Token", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bol_t.Token = dr["Token"] == null ? null : dr["Token"].ToString();
                    bol_t.ResponseStatus = dr["ResponseStatus"] == null ? null : dr["ResponseStatus"].ToString();
                }
            }
            return bol_t;
        }




        public bol_API_StaffAccount POSStaffIntegration(bol_API_StaffAccount bol)
        {
            bol_API_StaffAccount bol_sa = new bol_API_StaffAccount();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_StaffDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@username", bol.UserName);  //UserName from Spectrum
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_sa.POS_userName = dr["POS_userName"] == null ? null : dr["POS_userName"].ToString();
                    bol_sa.POS_PWD = dr["POS_PWD"] == null ? null : dr["POS_PWD"].ToString();
                }
            }
            return bol_sa;
        }
    }
}

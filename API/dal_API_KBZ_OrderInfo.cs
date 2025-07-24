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
    public class dal_API_KBZ_OrderInfo
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> Insert(bol_API_KBZ_OrderInfo bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_OrderInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@appid", bol.appid);
                    cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
                    cmd.Parameters.AddWithValue("@prepay_id", bol.prepay_id);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
                    cmd.Parameters.AddWithValue("@sign", bol.sign);
                    cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
                    cmd.Parameters.AddWithValue("@timestamp", bol.timestamp);


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

        public async Task<ResultMsg> EvoInsert(bol_API_KBZ_OrderInfo bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_OrderInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@appid", bol.appid);
                    cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
                    cmd.Parameters.AddWithValue("@prepay_id", bol.prepay_id);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
                    cmd.Parameters.AddWithValue("@sign", bol.sign);
                    cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
                    cmd.Parameters.AddWithValue("@timestamp", bol.timestamp);


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
    }
}

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
    public class dal_API_KBZ_Refund
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> Insert(bol_API_KBZ_Refund bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_Refund", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
                    cmd.Parameters.AddWithValue("@trans_order_id", bol.trans_order_id);
                    cmd.Parameters.AddWithValue("@refund_status", bol.refund_status);
                    cmd.Parameters.AddWithValue("@refund_order_id", bol.refund_order_id);
                    cmd.Parameters.AddWithValue("@refund_amount", bol.refund_amount);
                    cmd.Parameters.AddWithValue("@refund_currency", bol.refund_currency);
                    cmd.Parameters.AddWithValue("@refund_time", bol.refund_time);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.sign);
                    cmd.Parameters.AddWithValue("@reason", bol.reason);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);

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


        public async Task<ResultMsg> InsertLog(bol_API_KBZ_Refund_Log bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_Refund", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@timestamp", bol.timestamp);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
                    cmd.Parameters.AddWithValue("@method", bol.method);
                    cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.sign);
                    cmd.Parameters.AddWithValue("@version", bol.version);
                    cmd.Parameters.AddWithValue("@appid", bol.appid);
                    cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@refund_request_no", bol.refund_request_no);
                    cmd.Parameters.AddWithValue("@refund_reason", bol.refund_reason);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);

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

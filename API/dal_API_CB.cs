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
    public class dal_API_CB
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> dal_API_CB_Callback_Insert(bol_API_CB_CallBack bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CB_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@generateRefOrder", bol.generateRefOrder);
                    cmd.Parameters.AddWithValue("@transactionId", bol.transactionId);
                    cmd.Parameters.AddWithValue("@transactionDateTime", bol.transactionDateTime);
                    cmd.Parameters.AddWithValue("@ecommerceId", bol.ecommerceId);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@feeAmount", bol.feeAmount);
                    cmd.Parameters.AddWithValue("@discount", bol.discount);
                    cmd.Parameters.AddWithValue("@totalAmount", bol.totalAmount);
                    cmd.Parameters.AddWithValue("@signature", bol.signature);
                    cmd.Parameters.AddWithValue("@transactionStatus", bol.transactionStatus);
                    cmd.Parameters.AddWithValue("@responseCode", bol.responseCode);
                    cmd.Parameters.AddWithValue("@responseMsg", bol.responseMsg);

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

        public async Task<ResultMsg> dal_API_CB_RequestPaymentOrderLog(bol_API_CB_RequestPaymentOrderLog bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CB_RequestPaymentOrder", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@orderId", bo.orderId);
                    cmd.Parameters.AddWithValue("@generateRefOrder", bo.generateRefOrder);
                    cmd.Parameters.AddWithValue("@code", bo.code);
                    cmd.Parameters.AddWithValue("@msg", bo.msg);
                    cmd.Parameters.AddWithValue("@RequestJSON", bo.RequestJSON);
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

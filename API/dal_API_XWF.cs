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
    public class dal_API_XWF
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> InsertMakePayment(bol_API_XWF_MakePayment bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_XWF_MakePayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@hmac", bol.hmac);
                    cmd.Parameters.AddWithValue("@payment_id", bol.payment_id);
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


        public async Task<ResultMsg> InsertMobilePayments(bol_API_XWF_MobilePayments bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_XWF_MobilePayments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@partner_id", bol.partner_id);
                    cmd.Parameters.AddWithValue("@access_token", bol.access_token);
                    cmd.Parameters.AddWithValue("@payment_id", bol.payment_id);
                    cmd.Parameters.AddWithValue("@hmac", bol.hmac);
                    cmd.Parameters.AddWithValue("@status", bol.status);
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

        public bol_API_XWF_PaymentStatus GetPaymentStatus(bol_API_XWF_PaymentStatus bol)
        {
            bol_API_XWF_PaymentStatus xwf_ps = new bol_API_XWF_PaymentStatus();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_XWF_PaymentStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@partner_id", bol.partner_id);
                cmd.Parameters.AddWithValue("@payment_id", bol.payment_id);  
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    xwf_ps.status = dr["status"] == null ? null : dr["status"].ToString();
                }
            }
            return xwf_ps;


        }
    }
}

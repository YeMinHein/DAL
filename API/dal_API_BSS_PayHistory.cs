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
    public class dal_API_BSS_PayHistory
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public ResultMsg Insert(bol_API_BSS_PayHistory bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_PAY_History", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@BillingAccountNo", bol.BillingAccountNo);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TransactionAmount", bol.TransactionAmount);
                    cmd.Parameters.AddWithValue("@DocumentAlias", bol.DocumentAlias);
                    cmd.Parameters.AddWithValue("@CurrencyAlias", bol.CurrencyAlias);
                    cmd.Parameters.AddWithValue("@ChannelAlias", bol.ChannelAlias);
                    cmd.Parameters.AddWithValue("@PaymentMode", bol.PaymentMode);
                    cmd.Parameters.AddWithValue("@PaymentDocumentNo", bol.PaymentDocumentNo);
                    cmd.Parameters.AddWithValue("@CreditDocumentID", bol.CreditDocumentID);
                    cmd.Parameters.AddWithValue("@RefNumber", bol.RefNumber);
                    cmd.Parameters.AddWithValue("@InstituteMaster", bol.InstituteMaster);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@PaymentDate", bol.PaymentDate);
                    cmd.Parameters.AddWithValue("@TransactionDate", bol.TransactionDate);

                    cmd.Parameters.AddWithValue("@MultiFlag", bol.MultiFlag);
                    cmd.Parameters.AddWithValue("@TotalAmount", bol.TotalAmount);
                    cmd.Connection = con;
                    con.Open();
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

        public async Task<ResultMsg> InsertAsync(bol_API_BSS_PayHistory bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_PAY_History", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@BillingAccountNo", bol.BillingAccountNo);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TransactionAmount", bol.TransactionAmount);
                    cmd.Parameters.AddWithValue("@DocumentAlias", bol.DocumentAlias);
                    cmd.Parameters.AddWithValue("@CurrencyAlias", bol.CurrencyAlias);
                    cmd.Parameters.AddWithValue("@ChannelAlias", bol.ChannelAlias);
                    cmd.Parameters.AddWithValue("@PaymentMode", bol.PaymentMode);
                    cmd.Parameters.AddWithValue("@PaymentDocumentNo", bol.PaymentDocumentNo);
                    cmd.Parameters.AddWithValue("@CreditDocumentID", bol.CreditDocumentID);
                    cmd.Parameters.AddWithValue("@RefNumber", bol.RefNumber);
                    cmd.Parameters.AddWithValue("@InstituteMaster", bol.InstituteMaster);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@PaymentDate", bol.PaymentDate);
                    cmd.Parameters.AddWithValue("@TransactionDate", bol.TransactionDate);

                    cmd.Parameters.AddWithValue("@MultiFlag", bol.MultiFlag);
                    cmd.Parameters.AddWithValue("@TotalAmount", bol.TotalAmount);
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

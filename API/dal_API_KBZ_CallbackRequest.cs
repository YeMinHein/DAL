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
    public class dal_API_KBZ_CallbackRequest
    {
        string conn_str = dal_ConfigManager.GTG;
        //public ResultMsg Insert(bol_API_KBZ_CallbackRequest bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_KBZ_CallbackRequest", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@notify_time", bol.notify_time);
        //            cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
        //            cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
        //            cmd.Parameters.AddWithValue("@mm_order_id", bol.mm_order_id);
        //            cmd.Parameters.AddWithValue("@total_amount", bol.total_amount);
        //            cmd.Parameters.AddWithValue("@trans_currency", bol.trans_currency);
        //            cmd.Parameters.AddWithValue("@trade_status", bol.trade_status);
        //            cmd.Parameters.AddWithValue("@trans_end_time", bol.trans_end_time);
        //            cmd.Parameters.AddWithValue("@callback_info", bol.callback_info);
        //            cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
        //            cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
        //            cmd.Parameters.AddWithValue("@sign", bol.sign);
        //            cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}


        public async Task<ResultMsg> dal_Insert(bol_API_KBZ_CallbackRequest bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_CallbackRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@notify_time", bol.notify_time);
                    cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@mm_order_id", bol.mm_order_id);
                    cmd.Parameters.AddWithValue("@total_amount", bol.total_amount);
                    cmd.Parameters.AddWithValue("@trans_currency", bol.trans_currency);
                    cmd.Parameters.AddWithValue("@trade_status", bol.trade_status);
                    cmd.Parameters.AddWithValue("@trans_end_time", bol.trans_end_time);
                    cmd.Parameters.AddWithValue("@callback_info", bol.callback_info);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.sign);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);

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


        public async Task<ResultMsg> dal_UpdateKBZTransactionStatus(bol_API_KBZ_CallbackRequest bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_CallbackRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);

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

        #region Evo
        public async Task<ResultMsg> dal_EvoInsert(bol_API_KBZ_CallbackRequest bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_CallbackRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@notify_time", bol.notify_time);
                    cmd.Parameters.AddWithValue("@merch_code", bol.merch_code);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@mm_order_id", bol.mm_order_id);
                    cmd.Parameters.AddWithValue("@total_amount", bol.total_amount);
                    cmd.Parameters.AddWithValue("@trans_currency", bol.trans_currency);
                    cmd.Parameters.AddWithValue("@trade_status", bol.trade_status);
                    cmd.Parameters.AddWithValue("@trans_end_time", bol.trans_end_time);
                    cmd.Parameters.AddWithValue("@callback_info", bol.callback_info);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.sign);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);

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

        public async Task<ResultMsg> dal_EvoUpdateKBZTransactionStatus(bol_API_KBZ_CallbackRequest bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_CallbackRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);

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

        public async Task<ResultMsg> dal_EvoUpdateKBZTransaction(bol_API_KBZ_Transaction bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_Transaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@BankID", bol.BankID);
                    cmd.Parameters.AddWithValue("@BankName", bol.BankName);
                    cmd.Parameters.AddWithValue("@PartyTypeCode", bol.PartyTypeCode);
                    cmd.Parameters.AddWithValue("@PartyType", bol.PartyType);

                    cmd.Parameters.AddWithValue("@ContactChannelID", bol.ContactChannelID);
                    cmd.Parameters.AddWithValue("@ContactChannelName", bol.ContactChannelName);
                    cmd.Parameters.AddWithValue("@PaymentMethodID", bol.PaymentMethodID);
                    cmd.Parameters.AddWithValue("@PaymentMethodName", bol.PaymentMethodName);
                    cmd.Parameters.AddWithValue("@AcctResID", bol.AcctResID);
                    cmd.Parameters.AddWithValue("@AcctResName", bol.AcctResName);

                    cmd.Parameters.AddWithValue("@PartnerSn", bol.PartnerSn);
                    cmd.Parameters.AddWithValue("@PartyCode", bol.PartyCode);
                    cmd.Parameters.AddWithValue("@msisdn", bol.msisdn);
                    cmd.Parameters.AddWithValue("@Amount", bol.Amount);
                    cmd.Parameters.AddWithValue("@Voucher", bol.Voucher);
                    cmd.Parameters.AddWithValue("@CheckNbr", bol.CheckNbr);

                    cmd.Parameters.AddWithValue("@CheckOwnerName", bol.CheckOwnerName);
                    cmd.Parameters.AddWithValue("@CheckIssueDate", bol.CheckIssueDate);
                    cmd.Parameters.AddWithValue("@CheckExpDate", bol.CheckExpDate);
                    cmd.Parameters.AddWithValue("@vcpin", bol.vcpin);
                    cmd.Parameters.AddWithValue("@Remarks", bol.Remarks);
                    cmd.Parameters.AddWithValue("@ClearanceDate", bol.ClearanceDate);

                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@CustCode", bol.CustCode);
                    cmd.Parameters.AddWithValue("@Account", bol.Account);
                    cmd.Parameters.AddWithValue("@OfferCode", bol.OfferCode);
                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    cmd.Parameters.AddWithValue("@BatchPaymentID", bol.BatchPaymentID);

                    cmd.Parameters.AddWithValue("@subsID", bol.subsID);
                    cmd.Parameters.AddWithValue("@billType", bol.billType);

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

        #endregion
    }
}

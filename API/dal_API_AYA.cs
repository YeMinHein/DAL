using BOL;
using BOL.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BOL.API.bol_API_AYA;

namespace DAL.API
{
    public class dal_API_AYA
    {
        string conn_str = dal_ConfigManager.GTG;
        public async Task<ResultMsg> InsertToken(bol_API_AYAToken bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_Token", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 5; //seconds = 5sec
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@token", bol.token);


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


        public bol_API_AYAToken GetToken(bol_API_AYAToken bol)
        {
            bol_API_AYAToken bol_t = new bol_API_AYAToken();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AYA_Token", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bol_t.token = dr["token"] == null ? null : dr["token"].ToString();
                }
            }
            return bol_t;
        }


        public async Task<ResultMsg> dal_Insert_RPPayment(bol_API_AYA_requestPushPayment bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_RequestPushPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@customerPhone", bol.customerPhone);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@externalTransactionId", bol.externalTransactionId);
                    cmd.Parameters.AddWithValue("@externalAdditionalData", bol.externalAdditionalData);
                    cmd.Parameters.AddWithValue("@serviceCode", bol.serviceCode);

                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TradeType", bol.TradeType);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);

                    cmd.Parameters.AddWithValue("@responseReferenceNumber", bol.responseReferenceNumber);
                    if (bol.PaymentType == "Web_AdvPay" && bol.TradeType == "PAY_BY_QRCODE")
                    {
                        cmd.Parameters.AddWithValue("@responseQRData", bol.responseQRData);
                    }

                    cmd.Parameters.AddWithValue("@Type", bol.PXType);

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

        public async Task<ResultMsg> dal_API_AYA_PayRequestLog(bol_API_AYA_PayRequestLog bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_RequestPushPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@externalTransactionId", bo.externalTransactionId);
                    cmd.Parameters.AddWithValue("@Status", bo.Status);
                    cmd.Parameters.AddWithValue("@Message", bo.Message);
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

        public async Task<ResultMsg> dal_Insert_AYA_Callback(bol_API_AYA_Callback bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@name", bo.name);
                    cmd.Parameters.AddWithValue("@desc", bo.desc);
                    cmd.Parameters.AddWithValue("@currency", bo.currency);
                    cmd.Parameters.AddWithValue("@fees_debitFee", bo.fees_debitFee);
                    cmd.Parameters.AddWithValue("@fees_creditFee", bo.fees_creditFee);
                    cmd.Parameters.AddWithValue("@status", bo.status);
                    cmd.Parameters.AddWithValue("@createdAt", bo.createdAt);
                    cmd.Parameters.AddWithValue("@transRefId", bo.transRefId);
                    cmd.Parameters.AddWithValue("@code", bo.code);
                    cmd.Parameters.AddWithValue("@extMachId", bo.extMachId);
                    cmd.Parameters.AddWithValue("@externalTransactionId", bo.externalTransactionId);
                    cmd.Parameters.AddWithValue("@referenceNumber", bo.referenceNumber);
                    cmd.Parameters.AddWithValue("@totalAmount", bo.totalAmount);
                    cmd.Parameters.AddWithValue("@amount", bo.amount);
                    cmd.Parameters.AddWithValue("@externalAdditionalData", bo.externalAdditionalData);
                    cmd.Parameters.AddWithValue("@customer_id", bo.customer_id);
                    cmd.Parameters.AddWithValue("@customer_name", bo.customer_name);
                    cmd.Parameters.AddWithValue("@customer_phone", bo.customer_phone);
                    cmd.Parameters.AddWithValue("@merchant_id", bo.merchant_id);
                    cmd.Parameters.AddWithValue("@merchant_name", bo.merchant_name);
                    cmd.Parameters.AddWithValue("@merchant_phone", bo.merchant_phone);
                    cmd.Parameters.AddWithValue("@checksum", bo.checksum);
                    cmd.Parameters.AddWithValue("@paymentResult", bo.paymentResult);
                    cmd.Parameters.AddWithValue("@refundResult", bo.refundResult);

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

        public async Task<ResultMsg> dal_Insert_AYA_Callback_Log(bol_API_AYA_Callback_Log bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@checksum", bo.checksum);
                    cmd.Parameters.AddWithValue("@paymentResult", bo.paymentResult);
                    cmd.Parameters.AddWithValue("@refundResult", bo.refundResult);
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
        public bol_API_AYA_requestPushPayment dal_GetByExternalTransactionId(bol_API_AYA_requestPushPayment bol)
        {
            bol_API_AYA_requestPushPayment aya_rpp = new bol_API_AYA_requestPushPayment();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AYA_RequestPushPayment", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@externalTransactionId", bol.externalTransactionId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aya_rpp.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    aya_rpp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    aya_rpp.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    aya_rpp.TradeType = dr["TradeType"] == null ? null : dr["TradeType"].ToString();
                    aya_rpp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    aya_rpp.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    aya_rpp.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    aya_rpp.PaymentType = dr["PaymentType"] == null ? null : dr["PaymentType"].ToString();

                    aya_rpp.PXType = dr["Type"] == null ? null : dr["Type"].ToString();      //Prepaid Enhancement
                }
            }
            return aya_rpp;
        }

        public async Task<ResultMsg> dal_CheckSuccessPayment(bol_API_AYA_requestPushPayment bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_RequestPushPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@order_id", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);

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

        public async Task<ResultMsg> dal_UpdateAYATransactionStatus(bol_API_AYA_Callback bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AYA_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@externalTransactionId", bol.externalTransactionId);

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

        public API_AYA_Callback dal_GetAYAQueryOrder(bol_API_AYA_Callback bol)
        {
            API_AYA_Callback aya_qo = new API_AYA_Callback();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AYA_Callback", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@externalTransactionId", bol.externalTransactionId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    aya_qo.name = dr["name"] == null ? null : dr["name"].ToString();
                    aya_qo.desc = dr["desc"] == null ? null : dr["desc"].ToString();
                    aya_qo.currency = dr["currency"] == null ? null : dr["currency"].ToString();
                    aya_qo.fees_debitFee = dr["fees_debitFee"] == DBNull.Value ? 0 : int.Parse(dr["fees_debitFee"].ToString());
                    aya_qo.fees_creditFee = dr["fees_creditFee"] == DBNull.Value ? 0 : int.Parse(dr["fees_creditFee"].ToString());
                    aya_qo.status = dr["status"] == null ? null : dr["status"].ToString();
                    if (dr["createdAt"] != DBNull.Value)
                    {
                        aya_qo.createdAt = DateTime.Parse(dr["createdAt"].ToString());
                    }
                    aya_qo.transRefId = dr["transRefId"] == null ? null : dr["transRefId"].ToString();
                    aya_qo.code = dr["code"] == null ? null : dr["code"].ToString();
                    aya_qo.extMachId = dr["extMachId"] == null ? null : dr["extMachId"].ToString();
                    aya_qo.externalTransactionId = dr["externalTransactionId"] == null ? null : dr["externalTransactionId"].ToString();
                    aya_qo.referenceNumber = dr["referenceNumber"] == null ? null : dr["referenceNumber"].ToString();
                    aya_qo.totalAmount = dr["totalAmount"] == DBNull.Value ? 0 : int.Parse(dr["totalAmount"].ToString());
                    aya_qo.amount = dr["amount"] == DBNull.Value ? 0 : int.Parse(dr["amount"].ToString());
                    aya_qo.externalAdditionalData = dr["externalAdditionalData"] == null ? null : dr["externalAdditionalData"].ToString();
                    aya_qo.customer_id = dr["customer_id"] == null ? null : dr["customer_id"].ToString();
                    aya_qo.customer_name = dr["customer_name"] == null ? null : dr["customer_name"].ToString();
                    aya_qo.customer_phone = dr["customer_phone"] == null ? null : dr["customer_phone"].ToString();
                    //aya_qo.merchant_id = dr["merchant_id"] == null ? null : dr["merchant_id"].ToString();
                    //aya_qo.merchant_name = dr["merchant_name"] == null ? null : dr["merchant_name"].ToString();
                    //aya_qo.merchant_phone = dr["merchant_phone"] == null ? null : dr["merchant_phone"].ToString();
                    //aya_qo.checksum = dr["checksum"] == null ? null : dr["checksum"].ToString();
                    //aya_qo.paymentResult = dr["paymentResult"] == null ? null : dr["paymentResult"].ToString();
                    //aya_qo.refundResult = dr["refundResult"] == null ? null : dr["refundResult"].ToString();
                }
            }
            return aya_qo;
        }
    }
}

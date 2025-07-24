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
    public class dal_API_WM
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> dal_Insert_WMCallback(bol_API_WM_CallBack bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WM_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@status", bol.status);
                    cmd.Parameters.AddWithValue("@merchantId", bol.merchantId);
                    cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                    cmd.Parameters.AddWithValue("@merchantReferenceId", bol.merchantReferenceId);
                    cmd.Parameters.AddWithValue("@frontendResultUrl", bol.frontendResultUrl);
                    cmd.Parameters.AddWithValue("@backendResultUrl", bol.backendResultUrl);
                    cmd.Parameters.AddWithValue("@initiatorMsisdn", bol.initiatorMsisdn);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@timeToLiveSeconds", bol.timeToLiveSeconds);
                    cmd.Parameters.AddWithValue("@paymentDescription", bol.paymentDescription);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@hashValue", bol.hashValue);
                    cmd.Parameters.AddWithValue("@additionalField1", bol.additionalField1);
                    cmd.Parameters.AddWithValue("@additionalField2", bol.additionalField2);
                    cmd.Parameters.AddWithValue("@additionalField3", bol.additionalField3);
                    cmd.Parameters.AddWithValue("@additionalField4", bol.additionalField4);
                    cmd.Parameters.AddWithValue("@additionalField5", bol.additionalField5);
                    cmd.Parameters.AddWithValue("@transactionId", bol.transactionId);
                    cmd.Parameters.AddWithValue("@paymentRequestId", bol.paymentRequestId);
                    cmd.Parameters.AddWithValue("@requestTime", bol.requestTime);

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
        public async Task<ResultMsg> dal_Insert_WMPayment(bol_API_WM bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WM_PaymentRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@merchant_id", bol.merchant_id);
                    cmd.Parameters.AddWithValue("@order_id", bol.order_id);
                    cmd.Parameters.AddWithValue("@merchant_reference_id", bol.merchant_reference_id);
                    cmd.Parameters.AddWithValue("@frontend_result_url", bol.frontend_result_url);
                    cmd.Parameters.AddWithValue("@backend_result_url", bol.backend_result_url);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@time_to_live_in_seconds", bol.time_to_live_in_seconds);
                    cmd.Parameters.AddWithValue("@payment_description", bol.payment_description);
                    cmd.Parameters.AddWithValue("@merchant_name", bol.merchant_name);
                    cmd.Parameters.AddWithValue("@items", bol.items);
                    cmd.Parameters.AddWithValue("@hash", bol.hash);
                    cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@response_transaction_id", bol.response_transaction_id);

                    cmd.Parameters.AddWithValue("@CustAccNo", bol.detail.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.detail.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.detail.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TradeType", bol.detail.TradeType);
                    cmd.Parameters.AddWithValue("@Title", bol.detail.Title);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.detail.PaymentAlias);
                    cmd.Parameters.AddWithValue("@BillMonth", bol.detail.BillMonth);
                    cmd.Parameters.AddWithValue("@PaymentType", bol.detail.PaymentType);
                    cmd.Parameters.AddWithValue("@Type", bol.detail.PXType);
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

        public async Task<ResultMsg> dal_API_WM_PayRequestLog(bol_API_WM_PayRequestLog bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WM_PaymentRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@merchant_reference_id", bo.merchant_reference_id);
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

        public async Task<ResultMsg> dal_API_WM_PayRequestLogV2(bol_API_WM_PayRequestLogV2 bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WM_PaymentRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@merchant_reference_id", bo.merchant_reference_id);
                    cmd.Parameters.AddWithValue("@Status", bo.Status);
                    cmd.Parameters.AddWithValue("@Message", bo.Message);
                    cmd.Parameters.AddWithValue("@RequestJSON", bo.RequestJSON);
                    cmd.Parameters.AddWithValue("@GTG_RequestJSON", bo.GTG_RequestJSON);
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

        public bol_API_WM_Detail dal_GetByMerchOrderID(bol_API_WM bol)
        {
            bol_API_WM_Detail wm_d = new bol_API_WM_Detail();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WM_PaymentRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merchant_reference_id", bol.merchant_reference_id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    wm_d.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    wm_d.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    wm_d.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    wm_d.TradeType = dr["TradeType"] == null ? null : dr["TradeType"].ToString();
                    wm_d.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    wm_d.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    wm_d.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    wm_d.PaymentType = dr["PaymentType"] == null ? null : dr["PaymentType"].ToString();

                    wm_d.PXType = dr["Type"] == null ? null : dr["Type"].ToString();      //Prepaid Enhancement
                }
            }
            return wm_d;
        }

        public async Task<ResultMsg> dal_CheckSuccessPayment(bol_API_WM bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WM_PaymentRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@order_id", bol.order_id);
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

        public async Task<ResultMsg> dal_UpdateWMTransactionStatus(bol_API_WM_CallBack bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WM_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merchantReferenceId", bol.merchantReferenceId);

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

        public bol_API_WM_CallBack dal_GetWMQueryOrder(bol_API_WM bol)
        {
            bol_API_WM_CallBack wm_qo = new bol_API_WM_CallBack();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WM_PaymentRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merchant_reference_id", bol.merchant_reference_id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    wm_qo.status = dr["status"] == null ? null : dr["status"].ToString();
                    wm_qo.orderId = dr["orderId"] == null ? null : dr["orderId"].ToString();
                    wm_qo.merchantReferenceId = dr["merchantReferenceId"] == null ? null : dr["merchantReferenceId"].ToString();
                    wm_qo.frontendResultUrl = dr["frontendResultUrl"] == null ? null : dr["frontendResultUrl"].ToString();
                    wm_qo.backendResultUrl = dr["backendResultUrl"] == null ? null : dr["backendResultUrl"].ToString();
                    wm_qo.initiatorMsisdn = dr["initiatorMsisdn"] == null ? null : dr["initiatorMsisdn"].ToString();
                    wm_qo.amount = dr["amount"] == DBNull.Value ? 0 : int.Parse(dr["amount"].ToString());
                    wm_qo.timeToLiveSeconds = dr["timeToLiveSeconds"] == DBNull.Value ? 0 : int.Parse(dr["timeToLiveSeconds"].ToString());
                    wm_qo.paymentDescription = dr["paymentDescription"] == null ? null : dr["paymentDescription"].ToString();
                    wm_qo.currency = dr["currency"] == null ? null : dr["currency"].ToString();
                    wm_qo.hashValue = dr["hashValue"] == null ? null : dr["hashValue"].ToString();
                    wm_qo.transactionId = dr["transactionId"] == null ? null : dr["transactionId"].ToString();
                    wm_qo.paymentRequestId = dr["paymentRequestId"] == null ? null : dr["paymentRequestId"].ToString();
                    if (dr["requestTime"] != DBNull.Value)
                    {
                        wm_qo.requestTime = DateTime.Parse(dr["requestTime"].ToString());
                    }
                    wm_qo.additionalField1 = dr["additionalField1"] == null ? null : dr["additionalField1"].ToString();
                    wm_qo.additionalField2 = dr["additionalField2"] == null ? null : dr["additionalField2"].ToString();
                    wm_qo.additionalField3 = dr["additionalField3"] == null ? null : dr["additionalField3"].ToString();
                    wm_qo.additionalField4 = dr["additionalField4"] == null ? null : dr["additionalField4"].ToString();
                    wm_qo.additionalField5 = dr["additionalField5"] == null ? null : dr["additionalField5"].ToString();
                }
            }
            return wm_qo;
        }

        #region Evo
        public async Task<ResultMsg> dal_Insert_Evo_WMPayment(bol_API_Evo_WM bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_WM_PaymentRequest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merchant_id", bol.merchant_id);
                    cmd.Parameters.AddWithValue("@order_id", bol.order_id);
                    cmd.Parameters.AddWithValue("@merchant_reference_id", bol.merchant_reference_id);
                    cmd.Parameters.AddWithValue("@frontend_result_url", bol.frontend_result_url);
                    
                    cmd.Parameters.AddWithValue("@backend_result_url", bol.backend_result_url);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@time_to_live_in_seconds", bol.time_to_live_in_seconds);
                    cmd.Parameters.AddWithValue("@payment_description", bol.payment_description);
                    cmd.Parameters.AddWithValue("@merchant_name", bol.merchant_name);
                    
                    cmd.Parameters.AddWithValue("@items", bol.items);
                    cmd.Parameters.AddWithValue("@hash", bol.hash);
                    cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@response_transaction_id", bol.response_transaction_id);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TradeType", bol.TradeType);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    
                    cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
                    cmd.Parameters.AddWithValue("@Type", bol.PXType);
                    cmd.Parameters.AddWithValue("@CustCode", bol.CustCode);
                    cmd.Parameters.AddWithValue("@Account", bol.Account);
                    cmd.Parameters.AddWithValue("@OfferCode", bol.OfferCode);
                    
                    cmd.Parameters.AddWithValue("@subsID", bol.subsID);
                    cmd.Parameters.AddWithValue("@effType", bol.effType);
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

        public bol_API_Evo_WM dal_Evo_GetByMerchOrderID(bol_API_WM bol)
        {
            bol_API_Evo_WM wm_d = new bol_API_Evo_WM();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_WM_PaymentRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merchant_reference_id", bol.merchant_reference_id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    wm_d.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    wm_d.payment_description = dr["payment_description"] == null ? null : dr["payment_description"].ToString();
                    wm_d.merchant_reference_id = dr["merchant_reference_id"] == null ? null : dr["merchant_reference_id"].ToString();
                    wm_d.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    wm_d.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();

                    wm_d.TradeType = dr["TradeType"] == null ? null : dr["TradeType"].ToString();
                    wm_d.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    wm_d.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    wm_d.PaymentType = dr["PaymentType"] == null ? null : dr["PaymentType"].ToString();
                    wm_d.PXType = dr["Type"] == null ? null : dr["Type"].ToString();      //Prepaid Enhancement

                    wm_d.CustCode = dr["CustCode"] == null ? null : dr["CustCode"].ToString();
                    wm_d.Account = dr["Account"] == null ? null : dr["Account"].ToString();
                    wm_d.OfferCode = dr["OfferCode"] == null ? null : dr["OfferCode"].ToString();
                    wm_d.subsID = dr["subsID"] == null ? null : dr["subsID"].ToString();
                    wm_d.effType = dr["effType"] == null ? null : dr["effType"].ToString();

                    wm_d.billType = dr["billType"] == null ? null : dr["billType"].ToString();
                }
            }
            return wm_d;
        }

        public async Task<ResultMsg> dal_Insert_Evo_WMCallback(bol_API_WM_CallBack bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_WM_Callback", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@status", bol.status);
                    cmd.Parameters.AddWithValue("@merchantId", bol.merchantId);
                    cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                    cmd.Parameters.AddWithValue("@merchantReferenceId", bol.merchantReferenceId);
                    
                    cmd.Parameters.AddWithValue("@frontendResultUrl", bol.frontendResultUrl);
                    cmd.Parameters.AddWithValue("@backendResultUrl", bol.backendResultUrl);
                    cmd.Parameters.AddWithValue("@initiatorMsisdn", bol.initiatorMsisdn);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@timeToLiveSeconds", bol.timeToLiveSeconds);
                    
                    cmd.Parameters.AddWithValue("@paymentDescription", bol.paymentDescription);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@hashValue", bol.hashValue);
                    cmd.Parameters.AddWithValue("@additionalField1", bol.additionalField1);
                    cmd.Parameters.AddWithValue("@additionalField2", bol.additionalField2);
                    
                    cmd.Parameters.AddWithValue("@additionalField3", bol.additionalField3);
                    cmd.Parameters.AddWithValue("@additionalField4", bol.additionalField4);
                    cmd.Parameters.AddWithValue("@additionalField5", bol.additionalField5);
                    cmd.Parameters.AddWithValue("@transactionId", bol.transactionId);
                    cmd.Parameters.AddWithValue("@paymentRequestId", bol.paymentRequestId);
                    
                    cmd.Parameters.AddWithValue("@requestTime", bol.requestTime);
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

        public bol_API_WM_CallBack dal_Evo_GetWMQueryOrder(bol_API_WM bol)
        {
            bol_API_WM_CallBack wm_qo = new bol_API_WM_CallBack();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_WM_PaymentRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merchant_reference_id", bol.merchant_reference_id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    wm_qo.status = dr["status"] == null ? null : dr["status"].ToString();
                    wm_qo.merchantId = dr["merchantId"] == null ? null : dr["merchantId"].ToString();
                    wm_qo.orderId = dr["orderId"] == null ? null : dr["orderId"].ToString();
                    wm_qo.merchantReferenceId = dr["merchantReferenceId"] == null ? null : dr["merchantReferenceId"].ToString();
                    wm_qo.frontendResultUrl = dr["frontendResultUrl"] == null ? null : dr["frontendResultUrl"].ToString();
                    
                    wm_qo.backendResultUrl = dr["backendResultUrl"] == null ? null : dr["backendResultUrl"].ToString();
                    wm_qo.initiatorMsisdn = dr["initiatorMsisdn"] == null ? null : dr["initiatorMsisdn"].ToString();
                    wm_qo.amount = dr["amount"] == DBNull.Value ? 0 : int.Parse(dr["amount"].ToString());
                    wm_qo.timeToLiveSeconds = dr["timeToLiveSeconds"] == DBNull.Value ? 0 : int.Parse(dr["timeToLiveSeconds"].ToString());
                    wm_qo.paymentDescription = dr["paymentDescription"] == null ? null : dr["paymentDescription"].ToString();
                    
                    wm_qo.currency = dr["currency"] == null ? null : dr["currency"].ToString();
                    wm_qo.hashValue = dr["hashValue"] == null ? null : dr["hashValue"].ToString();
                    wm_qo.transactionId = dr["transactionId"] == null ? null : dr["transactionId"].ToString();
                    wm_qo.paymentRequestId = dr["paymentRequestId"] == null ? null : dr["paymentRequestId"].ToString();
                    if (dr["requestTime"] != DBNull.Value)
                    {
                        wm_qo.requestTime = DateTime.Parse(dr["requestTime"].ToString());
                    }

                    wm_qo.additionalField1 = dr["additionalField1"] == null ? null : dr["additionalField1"].ToString();
                    wm_qo.additionalField2 = dr["additionalField2"] == null ? null : dr["additionalField2"].ToString();
                    wm_qo.additionalField3 = dr["additionalField3"] == null ? null : dr["additionalField3"].ToString();
                    wm_qo.additionalField4 = dr["additionalField4"] == null ? null : dr["additionalField4"].ToString();
                    wm_qo.additionalField5 = dr["additionalField5"] == null ? null : dr["additionalField5"].ToString();
                }
            }
            return wm_qo;
        }

        public async Task<ResultMsg> dal_EvoCheckSuccessPayment(bol_API_WM bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_QueryOrder", con);//same store procedure with KBZ
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merchant_reference_id);

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

        public async Task<bol_API_WMGetCallBackRequest> dal_Evo_GetWM_CallBackRequest(bol_API_WM bol)
        {
            bol_API_WMGetCallBackRequest callBackReq = new bol_API_WMGetCallBackRequest();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_WM_Callback", con);//the same proc with KBZ
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@transactionId", bol.response_transaction_id);
                cmd.Parameters.AddWithValue("@merchantReferenceId", bol.merchant_reference_id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    callBackReq.status = dr["status"] == null ? null : dr["status"].ToString();
                    callBackReq.transactionId = dr["transactionId"] == null ? null : dr["transactionId"].ToString();
                }
            }
            return callBackReq;
        }

        public async Task<ResultMsg> dal_EvoUpdateWMTransaction(bol_API_WM_Transaction bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_WM_Transaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merchantReferenceId", bol.MerchantReferenceID);
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
                    cmd.Parameters.AddWithValue("@merchant_id", bol.MerchantID);
                    cmd.Parameters.AddWithValue("@frontend_result_url", bol.FrontendResultURL);
                    
                    cmd.Parameters.AddWithValue("@backend_result_url", bol.BackendResultURL);
                    cmd.Parameters.AddWithValue("@initiatorMsisdn", bol.initiatorMsisdn);

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

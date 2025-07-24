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
    public class dal_API_Logger
    {
        string conn_str = dal_ConfigManager.GTG;

        public void Insert_BELog(bol_API_BELog bo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);                    
                    cmd.Parameters.AddWithValue("@URL", bo.URL);
                    cmd.Parameters.AddWithValue("@AppID", bo.AppID);
                    cmd.Parameters.AddWithValue("@Request", bo.Request);
                    cmd.Parameters.AddWithValue("@Response", bo.Response);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Insert_PILog(bol_API_PILog bo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@URL", bo.URL);
                    cmd.Parameters.AddWithValue("@AppID", bo.AppID);
                    cmd.Parameters.AddWithValue("@Request", bo.Request);
                    cmd.Parameters.AddWithValue("@Response", bo.Response);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Insert_SMSLog(bol_API_BELog bo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SMS_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@URL", bo.URL);
                    cmd.Parameters.AddWithValue("@AppID", bo.AppID);
                    cmd.Parameters.AddWithValue("@Request", bo.Request);
                    cmd.Parameters.AddWithValue("@Response", bo.Response);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bol_API_CheckTxnLog GetCheckTxnLog(bol_API_CheckTxnLog bol)
        {
            bol_API_CheckTxnLog bol_ctl = new bol_API_CheckTxnLog();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                cmd.Parameters.AddWithValue("@DocumentAlias", bol.DocumentAlias);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    if (dr["Counts"] != DBNull.Value)
                    {
                        bol_ctl.Counts = Convert.ToInt32(dr["Counts"].ToString());
                    }
                    else
                    {
                        bol_ctl.Counts = 0;
                    }
                }
            }
            return bol_ctl;
        }

        public ResultMsg Insert_TxnLog(bol_API_TxnLog bo)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@BillingAccountNo", bo.BillingAccountNo);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bo.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TransactionAmount", bo.TransactionAmount);
                    cmd.Parameters.AddWithValue("@DocumentAlias", bo.DocumentAlias);
                    cmd.Parameters.AddWithValue("@ReceivableChannelAlias", bo.ReceivableChannelAlias);
                    cmd.Parameters.AddWithValue("@PaymentSource", bo.PaymentSource);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bo.PaymentOperator);
                    cmd.Parameters.AddWithValue("@InternetRefNo", bo.InternetRefNo);
                    cmd.Parameters.AddWithValue("@CRNo", bo.CRNo);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CurrencyAlias", bo.CurrencyAlias);
                    cmd.Parameters.AddWithValue("@merch_order_id", bo.merch_order_id);
                    cmd.Parameters.AddWithValue("@BillMonth", bo.BillMonth);
                    cmd.Parameters.AddWithValue("@OrderCode", bo.OrderCode);
                    cmd.Parameters.AddWithValue("@PromoPlanID", bo.PromoPlanID);
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

        public ResultMsg Insert_HistoryLog(bol_API_HistoryLog bo)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_API_History_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@UserAgent", bo.UserAgent);
                    cmd.Parameters.AddWithValue("@IsBOT", bo.IsBOT);
                    cmd.Parameters.AddWithValue("@IsCrawler", bo.IsCrawler);
                    cmd.Parameters.AddWithValue("@Browser", bo.Browser);
                    cmd.Parameters.AddWithValue("@IPAddress", bo.IPAddress);
                    cmd.Parameters.AddWithValue("@Device", bo.Device);
                    cmd.Parameters.AddWithValue("@Platform", bo.Platform);
                    cmd.Parameters.AddWithValue("@Website", bo.Website);
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


        public async Task<ResultMsg> Insert_API_AdvPayHistoryLog(bol_API_AdvPayHistoryLog bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@SA_ID", bo.SA_ID);
                    cmd.Parameters.AddWithValue("@OrderCode", bo.OrderCode);
                    cmd.Parameters.AddWithValue("@merch_order_id", bo.merch_order_id);
                    cmd.Parameters.AddWithValue("@prepay_id", bo.prepay_id);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bo.PaymentOperator);
                    cmd.Parameters.AddWithValue("@PaymentMethod", bo.PaymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bo.PaymentAlias);

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


        public async Task<ResultMsg> Insert_API_AdvPayHistoryLogV2(bol_API_AdvPayHistoryLog bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@SA_ID", bo.SA_ID);
                    cmd.Parameters.AddWithValue("@OrderCode", bo.OrderCode);
                    cmd.Parameters.AddWithValue("@merch_order_id", bo.merch_order_id);
                    cmd.Parameters.AddWithValue("@prepay_id", bo.prepay_id);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bo.PaymentOperator);
                    cmd.Parameters.AddWithValue("@PaymentMethod", bo.PaymentMethod);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bo.PaymentAlias);
                    cmd.Parameters.AddWithValue("@Bank", bo.Bank);

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

        public ResultMsg Insert_RechargeTxnLog(bol_API_RechargeTxnLog bo)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@BillingAccountNo", bo.BillingAccountNo);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bo.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TransactionAmount", bo.TransactionAmount);
                    cmd.Parameters.AddWithValue("@DocumentAlias", bo.DocumentAlias);
                    cmd.Parameters.AddWithValue("@ReceivableChannelAlias", bo.ReceivableChannelAlias);
                    cmd.Parameters.AddWithValue("@PaymentSource", bo.PaymentSource);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bo.PaymentOperator);
                    cmd.Parameters.AddWithValue("@InternetRefNo", bo.InternetRefNo);
                    cmd.Parameters.AddWithValue("@CRNo", bo.CRNo);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CurrencyAlias", bo.CurrencyAlias);
                    cmd.Parameters.AddWithValue("@merch_order_id", bo.merch_order_id);
                    if (bo.BillMonth == null || bo.BillMonth == "null" || bo.BillMonth == "")
                    {
                        
                    }
                    else 
                    {
                        cmd.Parameters.AddWithValue("@BillMonth", bo.BillMonth);
                    }
                    

                    cmd.Parameters.AddWithValue("@DDNo", bo.DDNo);
                    cmd.Parameters.AddWithValue("@packageId", bo.packageId);
                    cmd.Parameters.AddWithValue("@rechargePackageName", bo.rechargePackageName);
                    cmd.Parameters.AddWithValue("@denominationAmount", bo.denominationAmount);
                    cmd.Parameters.AddWithValue("@creditLimit", bo.creditLimit);
                    cmd.Parameters.AddWithValue("@expiryDate", bo.expiryDate);
                    cmd.Parameters.AddWithValue("@limitType", bo.limitType);
                    cmd.Parameters.AddWithValue("@quota", bo.quota);
                    cmd.Parameters.AddWithValue("@rechargeRequestNo", bo.rechargeRequestNo);

                    cmd.Parameters.AddWithValue("@udt_LTE_PAY_RechargeDetail", bo.Detail);

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

        public bol_API_PaymentQueryOrder GetPaymentQueryOrder(bol_API_PaymentQueryOrder bol)
        {
            bol_API_PaymentQueryOrder bol_pqo = new bol_API_PaymentQueryOrder();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Log", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@OrderCode", bol.orderCode);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_pqo.orderCode = dr["OrderCode"] == DBNull.Value ? null : dr["OrderCode"].ToString();
                    bol_pqo.transactionID = dr["CRNo"] == DBNull.Value ? null : dr["CRNo"].ToString();
                    bol_pqo.billingAccountNo = dr["BillingAccountNo"] == DBNull.Value ? null : dr["BillingAccountNo"].ToString();
                    bol_pqo.billInvoiceNo = dr["BillInvoiceNo"] == DBNull.Value ? null : dr["BillInvoiceNo"].ToString();
                    bol_pqo.transactionAmount = dr["TransactionAmount"] == DBNull.Value ? 0 : double.Parse(dr["TransactionAmount"].ToString());
                    bol_pqo.documentAlias = dr["DocumentAlias"] == DBNull.Value ? null : dr["DocumentAlias"].ToString();
                    bol_pqo.receivableChannelAlias = dr["ReceivableChannelAlias"] == DBNull.Value ? null : dr["ReceivableChannelAlias"].ToString();
                    bol_pqo.paymentSource = dr["PaymentSource"] == DBNull.Value ? null : dr["PaymentSource"].ToString();
                    bol_pqo.paymentOperator = dr["PaymentOperator"] == DBNull.Value ? null : dr["PaymentOperator"].ToString();
                    bol_pqo.internetRefNo = dr["InternetRefNo"] == DBNull.Value ? null : dr["InternetRefNo"].ToString();
                    bol_pqo.currencyAlias = dr["CurrencyAlias"] == DBNull.Value ? null : dr["CurrencyAlias"].ToString();
                    bol_pqo.merch_order_id = dr["merch_order_id"] == DBNull.Value ? null : dr["merch_order_id"].ToString();
                    bol_pqo.billMonth = dr["BillMonth"] == DBNull.Value ? null : dr["BillMonth"].ToString();
                    bol_pqo.promoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());

                }
            }
            return bol_pqo;
        }

        public ResultMsg Insert_PrepaidTxnLog(bol_API_SyncPXChangeServicePlanModel bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@serviceInstanceNumber", bol.serviceInstanceNumber);
                    cmd.Parameters.AddWithValue("@effectiveDate", bol.effectiveDate);
                    cmd.Parameters.AddWithValue("@currencyAlias", bol.currencyAlias);
                    cmd.Parameters.AddWithValue("@packageName", bol.packageName);
                    cmd.Parameters.AddWithValue("@remarks", bol.remarks);
                    cmd.Parameters.AddWithValue("@PMRVO_paymentMode", bol.PMRVO_paymentMode);
                    cmd.Parameters.AddWithValue("@PMRVO_CMR_paymentMode", bol.PMRVO_CMR_paymentMode);
                    cmd.Parameters.AddWithValue("@PMRVO_manualReceiptNumber", bol.PMRVO_manualReceiptNumber);
                    cmd.Parameters.AddWithValue("@PMRVO_description", bol.PMRVO_description);
                    cmd.Parameters.AddWithValue("@PMRVO_paymentDate", bol.PMRVO_paymentDate);
                    cmd.Parameters.AddWithValue("@PMRVO_totalTransactionAmount", bol.PMRVO_totalTransactionAmount);
                    cmd.Parameters.AddWithValue("@PMRVO_otherBankName", bol.PMRVO_otherBankName);
                    cmd.Parameters.AddWithValue("@PMRVO_otherBranchName", bol.PMRVO_otherBranchName);
                    cmd.Parameters.AddWithValue("@partnerAccountNumber", bol.partnerAccountNumber);
                    cmd.Parameters.AddWithValue("@organizationId", bol.organizationId);
                    cmd.Parameters.AddWithValue("@packageId", bol.packageId);
                    cmd.Parameters.AddWithValue("@modulename", bol.modulename);
                    cmd.Parameters.AddWithValue("@CRDRNRVO_billingAccountNumber", bol.CRDRNRVO_billingAccountNumber);
                    cmd.Parameters.AddWithValue("@CRDRNRVO_subtotal", bol.CRDRNRVO_subtotal);
                    cmd.Parameters.AddWithValue("@noofyears", bol.noofyears);
                    cmd.Parameters.AddWithValue("@eventType", bol.eventType);

                    cmd.Parameters.AddWithValue("@CDRVO_chargeId", bol.CDRVO_chargeId);
                    cmd.Parameters.AddWithValue("@CDRVO_chargeName", bol.CDRVO_chargeName);
                    cmd.Parameters.AddWithValue("@CDRVO_canOverride", bol.CDRVO_canOverride);
                    cmd.Parameters.AddWithValue("@CDRVO_actualAmount", bol.CDRVO_actualAmount);
                    cmd.Parameters.AddWithValue("@CDRVO_overriddenBy", bol.CDRVO_overriddenBy);
                    cmd.Parameters.AddWithValue("@CDRVO_overrideLimitMin", bol.CDRVO_overrideLimitMin);
                    cmd.Parameters.AddWithValue("@CDRVO_overrideLimitMax", bol.CDRVO_overrideLimitMax);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);


                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);       //From Internal Call
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@DocumentAlias", bol.DocumentAlias);
                    cmd.Parameters.AddWithValue("@ReceivableChannelAlias", bol.ReceivableChannelAlias);
                    cmd.Parameters.AddWithValue("@PaymentSource", bol.PaymentSource);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
                    cmd.Parameters.AddWithValue("@InternetRefNo", bol.InternetRefNo);
                    cmd.Parameters.AddWithValue("@CRNo", bol.CRNo);                         //Fron Internal Call

                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    if (bol.AmendLogID != 0) {
                        cmd.Parameters.AddWithValue("@AmendLogID", bol.AmendLogID);
                    }

                    cmd.Parameters.AddWithValue("@OldPackageName", bol.OldPlanName); 

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

        public ResultMsg Insert_Evo_PrepaidTxnLog(bol_API_SyncChangeServicePlanModel bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@custCode", bol.custCode);
                    cmd.Parameters.AddWithValue("@accountCode", bol.accountCode);
                    cmd.Parameters.AddWithValue("@offerCode", bol.offerCode);
                    cmd.Parameters.AddWithValue("@effectiveDate", bol.effectiveDate);
                    cmd.Parameters.AddWithValue("@currencyAlias", bol.currencyAlias);
                    cmd.Parameters.AddWithValue("@packageName", bol.packageName);
                    cmd.Parameters.AddWithValue("@remarks", bol.remarks);
                    cmd.Parameters.AddWithValue("@PMRVO_paymentMode", bol.PMRVO_paymentMode);
                    cmd.Parameters.AddWithValue("@PMRVO_CMR_paymentMode", bol.PMRVO_CMR_paymentMode);
                    cmd.Parameters.AddWithValue("@PMRVO_manualReceiptNumber", bol.PMRVO_manualReceiptNumber);
                    cmd.Parameters.AddWithValue("@PMRVO_description", bol.PMRVO_description);
                    cmd.Parameters.AddWithValue("@PMRVO_paymentDate", bol.PMRVO_paymentDate);
                    cmd.Parameters.AddWithValue("@PMRVO_totalTransactionAmount", bol.PMRVO_totalTransactionAmount);
                    cmd.Parameters.AddWithValue("@PMRVO_otherBankName", bol.PMRVO_otherBankName);
                    cmd.Parameters.AddWithValue("@PMRVO_otherBranchName", bol.PMRVO_otherBranchName);
                    cmd.Parameters.AddWithValue("@partnerAccountNumber", bol.partnerAccountNumber);
                    cmd.Parameters.AddWithValue("@organizationId", bol.organizationId);
                    cmd.Parameters.AddWithValue("@packageId", bol.packageId);
                    cmd.Parameters.AddWithValue("@modulename", bol.modulename);
                    cmd.Parameters.AddWithValue("@CRDRNRVO_billingAccountNumber", bol.CRDRNRVO_billingAccountNumber);
                    cmd.Parameters.AddWithValue("@CRDRNRVO_subtotal", bol.CRDRNRVO_subtotal);
                    cmd.Parameters.AddWithValue("@noofyears", bol.noofyears);
                    cmd.Parameters.AddWithValue("@eventType", bol.eventType);

                    cmd.Parameters.AddWithValue("@CDRVO_chargeId", bol.CDRVO_chargeId);
                    cmd.Parameters.AddWithValue("@CDRVO_chargeName", bol.CDRVO_chargeName);
                    cmd.Parameters.AddWithValue("@CDRVO_canOverride", bol.CDRVO_canOverride);
                    cmd.Parameters.AddWithValue("@CDRVO_actualAmount", bol.CDRVO_actualAmount);
                    cmd.Parameters.AddWithValue("@CDRVO_overriddenBy", bol.CDRVO_overriddenBy);
                    cmd.Parameters.AddWithValue("@CDRVO_overrideLimitMin", bol.CDRVO_overrideLimitMin);
                    cmd.Parameters.AddWithValue("@CDRVO_overrideLimitMax", bol.CDRVO_overrideLimitMax);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);


                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);       //From Internal Call
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@DocumentAlias", bol.DocumentAlias);
                    cmd.Parameters.AddWithValue("@ReceivableChannelAlias", bol.ReceivableChannelAlias);
                    cmd.Parameters.AddWithValue("@PaymentSource", bol.PaymentSource);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
                    cmd.Parameters.AddWithValue("@InternetRefNo", bol.InternetRefNo);
                    cmd.Parameters.AddWithValue("@CRNo", bol.CRNo);                         //Fron Internal Call

                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    if (bol.AmendLogID != 0)
                    {
                        cmd.Parameters.AddWithValue("@AmendLogID", bol.AmendLogID);
                    }

                    cmd.Parameters.AddWithValue("@OldPackageName", bol.OldPlanName);

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

        public ResultMsg Insert_PrepaidAmendLog(bol_API_PrepaidAmendLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.UserName);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);

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

        public async Task<ResultMsg> Insert_PrepaidActivityLog(bol_API_PrepaidActivityLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);

                    cmd.Connection = con;
                    await con.OpenAsync();
                    resp_code = (string)await cmd.ExecuteScalarAsync();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg Insert_PXSyncData(bol_API_PXSyncData bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@udt_PXSyncData", bol.udt_PXSyncData);
                    //cmd.Parameters.AddWithValue("@transactionNumber", bol.transactionNumber);
                    //cmd.Parameters.AddWithValue("@date", bol.date);
                    //cmd.Parameters.AddWithValue("@paymentMode", bol.paymentMode);
                    //cmd.Parameters.AddWithValue("@amount", bol.amount);
                    //cmd.Parameters.AddWithValue("@paymentStatus", bol.paymentStatus);
                    //cmd.Parameters.AddWithValue("@currencyName", bol.currencyName);
                    //cmd.Parameters.AddWithValue("@channelAlias", bol.channelAlias);
                    //cmd.Parameters.AddWithValue("@creditDocumentNumber", bol.creditDocumentNumber);

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

        #region Evo
        public void Insert_EvoPaymentLog(bol_API_BELog bo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@URL", bo.URL);
                    cmd.Parameters.AddWithValue("@AppID", bo.AppID);
                    cmd.Parameters.AddWithValue("@Request", bo.Request);
                    cmd.Parameters.AddWithValue("@Response", bo.Response);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Insert_EvoWMPaymentLog(bol_API_BELog bo)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_WM_PAY_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@URL", bo.URL);
                    cmd.Parameters.AddWithValue("@AppID", bo.AppID);
                    cmd.Parameters.AddWithValue("@Request", bo.Request);
                    cmd.Parameters.AddWithValue("@Response", bo.Response);
                    cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public ResultMsg Insert_TxnLog(bol_API_RechargeTxnLog bo)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Evo_PAY_Log", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 300; //seconds = 5mins
        //            cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
        //            cmd.Parameters.AddWithValue("@BillingAccountNo", bo.BillingAccountNo);
        //            cmd.Parameters.AddWithValue("@BillInvoiceNo", bo.BillInvoiceNo);
        //            cmd.Parameters.AddWithValue("@TransactionAmount", bo.TransactionAmount);
        //            cmd.Parameters.AddWithValue("@DocumentAlias", bo.DocumentAlias);
        //            cmd.Parameters.AddWithValue("@ReceivableChannelAlias", bo.ReceivableChannelAlias);
        //            cmd.Parameters.AddWithValue("@PaymentSource", bo.PaymentSource);
        //            cmd.Parameters.AddWithValue("@PaymentOperator", bo.PaymentOperator);
        //            cmd.Parameters.AddWithValue("@InternetRefNo", bo.InternetRefNo);
        //            cmd.Parameters.AddWithValue("@CRNo", bo.CRNo);
        //            cmd.Parameters.AddWithValue("@CreatedDate", DateTime.Now);
        //            cmd.Parameters.AddWithValue("@CurrencyAlias", bo.CurrencyAlias);
        //            cmd.Parameters.AddWithValue("@merch_order_id", bo.merch_order_id);
        //            if (bo.BillMonth == null || bo.BillMonth == "null" || bo.BillMonth == "")
        //            {

        //            }
        //            else
        //            {
        //                cmd.Parameters.AddWithValue("@BillMonth", bo.BillMonth);
        //            }


        //            cmd.Parameters.AddWithValue("@DDNo", bo.DDNo);
        //            cmd.Parameters.AddWithValue("@packageId", bo.packageId);
        //            cmd.Parameters.AddWithValue("@rechargePackageName", bo.rechargePackageName);
        //            cmd.Parameters.AddWithValue("@denominationAmount", bo.denominationAmount);
        //            cmd.Parameters.AddWithValue("@creditLimit", bo.creditLimit);
        //            cmd.Parameters.AddWithValue("@expiryDate", bo.expiryDate);
        //            cmd.Parameters.AddWithValue("@limitType", bo.limitType);
        //            cmd.Parameters.AddWithValue("@quota", bo.quota);
        //            cmd.Parameters.AddWithValue("@rechargeRequestNo", bo.rechargeRequestNo);

        //            cmd.Parameters.AddWithValue("@udt_LTE_PAY_RechargeDetail", bo.Detail);

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
        #endregion
    }
}

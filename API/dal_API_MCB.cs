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
    public class dal_API_MCB
    {
        string conn_str = dal_ConfigManager.GTG;
        public async Task<ResultMsg> dal_Insert_EMoneyPayments(bol_API_MCB_EMoneyPayments bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EMoneyPayments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@redirectUrl", bol.redirectUrl);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);
                    cmd.Parameters.AddWithValue("@order", bol.order);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@payerFsp", bol.payerFsp);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TradeType", bol.TradeType);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
                    //cmd.Parameters.AddWithValue("@response_result", bol.response_result);
                    //cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@contextId", bol.contextId);
                    cmd.Parameters.AddWithValue("@merchantId", bol.merchantId);

                    cmd.Parameters.AddWithValue("@paymentGatewayUrl", bol.detail.paymentGatewayUrl);
                    cmd.Parameters.AddWithValue("@contextStatus", bol.detail.contextStatus);
                    cmd.Parameters.AddWithValue("@createTime", bol.detail.createTime);
                    cmd.Parameters.AddWithValue("@createTimeUnix", bol.detail.createTimeUnix);
                    cmd.Parameters.AddWithValue("@expiryTime", bol.detail.expiryTime);
                    cmd.Parameters.AddWithValue("@expiryTimeUnix", bol.detail.expiryTimeUnix);
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

        public async Task<ResultMsg> dal_Update_RetrieveEmoneyPayment(bol_API_MCB_EMoneyPayments bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EMoneyPayments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@redirectUrl", bol.redirectUrl);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);
                    cmd.Parameters.AddWithValue("@order", bol.order);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@payerFsp", bol.payerFsp);
                    //cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    //cmd.Parameters.AddWithValue("@Name", bol.Name);
                    //cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    //cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    //cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    //cmd.Parameters.AddWithValue("@response_result", bol.response_result);
                    //cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@contextId", bol.contextId);
                    cmd.Parameters.AddWithValue("@merchantId", bol.merchantId);

                    cmd.Parameters.AddWithValue("@paymentGatewayUrl", bol.detail.paymentGatewayUrl);
                    cmd.Parameters.AddWithValue("@contextStatus", bol.detail.contextStatus);
                    cmd.Parameters.AddWithValue("@payerId", bol.detail.payerId);
                    cmd.Parameters.AddWithValue("@transactionRef", bol.detail.transactionRef);
                    cmd.Parameters.AddWithValue("@transactionTimestamp", bol.detail.transactionTimestamp);
                    cmd.Parameters.AddWithValue("@payerFspTransactionRef", bol.detail.payerFspTransactionRef);
                    cmd.Parameters.AddWithValue("@payerFspTransactionTimestamp", bol.detail.payerFspTransactionTimestamp);
                    cmd.Parameters.AddWithValue("@createTime", bol.detail.createTime);
                    cmd.Parameters.AddWithValue("@createTimeUnix", bol.detail.createTimeUnix);
                    cmd.Parameters.AddWithValue("@expiryTime", bol.detail.expiryTime);
                    cmd.Parameters.AddWithValue("@expiryTimeUnix", bol.detail.expiryTimeUnix);
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

        public bol_API_MCB_EMoneyPayments dal_Get_EMoneyPayments(bol_API_MCB_EMoneyPayments bol)
        {
            bol_API_MCB_EMoneyPayments mcb_emp = new bol_API_MCB_EMoneyPayments();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EMoneyPayments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@contextId", bol.contextId);
                cmd.Parameters.AddWithValue("@merchantId", bol.merchantId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mcb_emp.redirectUrl = dr["redirectUrl"] == null ? null : dr["redirectUrl"].ToString();
                    mcb_emp.merchantPaymentRef = dr["merchantPaymentRef"] == null ? null : dr["merchantPaymentRef"].ToString();
                    mcb_emp.amount = dr["amount"] == null ? 0 : Convert.ToDecimal(dr["amount"].ToString());
                    mcb_emp.currency = dr["currency"] == null ? null : dr["currency"].ToString();
                    mcb_emp.payerFsp = dr["payerFsp"] == null ? null : dr["payerFsp"].ToString();
                    mcb_emp.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    mcb_emp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    mcb_emp.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    mcb_emp.TradeType = dr["TradeType"] == null ? null : dr["TradeType"].ToString();
                    mcb_emp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    mcb_emp.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    mcb_emp.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    mcb_emp.contextId = dr["contextId"] == null ? null : dr["contextId"].ToString();
                    mcb_emp.merchantId = dr["merchantId"] == null ? null : dr["merchantId"].ToString();
                }
            }
            return mcb_emp;
        }

        public async Task<ResultMsg> dal_UpdateMCBTransactionStatus(bol_API_MCB_EMoneyPayments bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EMoneyPayments", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@contextId", bol.contextId);

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

        public bol_API_MCB_EMoneyPayments dal_Get_EMoneyPaymentsContextID(bol_API_MCB_EMoneyPayments bol)
        {
            bol_API_MCB_EMoneyPayments mcb_emp = new bol_API_MCB_EMoneyPayments();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EMoneyPayments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mcb_emp.contextId = dr["contextId"] == null ? null : dr["contextId"].ToString();
                }
            }
            return mcb_emp;
        }

        public bol_API_MCB_EMoneyPayments dal_Get_PaymentCounts(bol_API_MCB_EMoneyPayments bol)
        {
            bol_API_MCB_EMoneyPayments mcb_emp = new bol_API_MCB_EMoneyPayments();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EMoneyPayments", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mcb_emp.PaymentCounts = dr["PaymentCounts"] == DBNull.Value ? 0 : int.Parse(dr["PaymentCounts"].ToString());
                }
            }
            return mcb_emp;
        }

        public async Task<ResultMsg> dal_CheckSuccessPayment(bol_API_MCB_EMoneyPayments bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_RetrieveEMoneyPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);

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

        public async Task<ResultMsg> dal_CheckSuccessPaymentV2(bol_API_MCB_EMoneyPayments bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_RetrieveEMoneyPayment", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);

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

        public IEnumerable<bol_API_MCB_EMoneyPayments> dal_Get_PendingList(bol_API_MCB_EOD bol)
        {
            List<bol_API_MCB_EMoneyPayments> emps = new List<bol_API_MCB_EMoneyPayments>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_MCB_EMoneyPayments emp = new bol_API_MCB_EMoneyPayments();
                    emp.merchantPaymentRef = dr["merchantPaymentRef"] == null ? null : dr["merchantPaymentRef"].ToString();
                    emps.Add(emp);
                }
            }
            return emps;
        }

        public IEnumerable<bol_API_MCB_EMoneyPayments> dal_Get_KBZPendingList(bol_API_MCB_EOD bol)
        {
            List<bol_API_MCB_EMoneyPayments> emps = new List<bol_API_MCB_EMoneyPayments>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 11);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_MCB_EMoneyPayments emp = new bol_API_MCB_EMoneyPayments();
                    //csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    emp.merchantPaymentRef = dr["merchantPaymentRef"] == null ? null : dr["merchantPaymentRef"].ToString();
                    //csetup.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    //csetup.SentDate = dr["SentDate"] == null ? DateTime.Now : Convert.ToDateTime(dr["SentDate"].ToString());
                    emps.Add(emp);
                }
            }
            return emps;
        }

        public async Task<ResultMsg> dal_ActionEOD(bol_API_MCB_EOD bol)
        {
            int resp_code = 0;      //return Latest EODID

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    if (bol.ActionParam == 2) 
                    {
                        //cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                        //cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                        cmd.Parameters.AddWithValue("@StartDate", bol.StartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@EndDate", bol.EndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                        cmd.Parameters.AddWithValue("@Records", bol.Records);
                        cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
                    }
                    else if(bol.ActionParam == 4)
                    {
                        cmd.Parameters.AddWithValue("@EODID", bol.EODID);
                    }

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

        public async Task<ResultMsg> dal_InsertEODDetail(bol_API_MCB_EOD bol)
        {
            int resp_code = 0;     

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@EODID", bol.EODID);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);
                    cmd.Parameters.AddWithValue("@contextStatus", bol.contextStatus);

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

        public async Task<ResultMsg> dal_InsertEODLog(bol_API_MCB_EOD bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@EODID", bol.EODID);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);

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
        public bol_API_MCBEODProgress dal_GetMCBEODProgress(bol_API_MCBEODProgress bol)
        {
            bol_API_MCBEODProgress pro = new bol_API_MCBEODProgress();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@EODID", bol.ID);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pro.Records = dr["Records"] == DBNull.Value ? 0 : int.Parse(dr["Records"].ToString());
                    pro.ProgressRecords = dr["ProgressRecords"] == DBNull.Value ? 0 : int.Parse(dr["ProgressRecords"].ToString());
                    pro.CreatedDate = dr["CreatedDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["CreatedDate"].ToString());
                    pro.CompleteRecords = dr["CompleteRecords"] == DBNull.Value ? 0 : int.Parse(dr["CompleteRecords"].ToString());
                    if (dr["CompletedDate"] != DBNull.Value)
                    {
                        pro.CompletedDate = DateTime.Parse(dr["CompletedDate"].ToString());
                    }
                    pro.FormattedCreatedDate = dr["FormattedCreatedDate"] == DBNull.Value ? "" : dr["FormattedCreatedDate"].ToString();
                    pro.FormattedCompletedDate = dr["FormattedCompletedDate"] == DBNull.Value ? "" : dr["FormattedCompletedDate"].ToString();
                    pro.EODStartDate = dr["EODStartDate"] == DBNull.Value ? "" : dr["EODStartDate"].ToString();
                    pro.EODEndDate = dr["EODEndDate"] == DBNull.Value ? "" : dr["EODEndDate"].ToString();
                }
            }

            return pro;
        }

        public ResultMsg dal_GetEODDtailListCount(bol_API_MCBGetEODDtailList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@EODID", bol.EODID);
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

        public IEnumerable<bol_API_MCBGetEODDtailList> dal_GetEODDtailList(bol_API_MCBGetEODDtailList bol)
        {
            List<bol_API_MCBGetEODDtailList> eodlist = new List<bol_API_MCBGetEODDtailList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@EODID", bol.EODID);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_MCBGetEODDtailList eod = new bol_API_MCBGetEODDtailList();
                    //eod.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    eod.merchantPaymentRef = dr["merchantPaymentRef"] == null ? null : dr["merchantPaymentRef"].ToString();
                    eod.payerId = dr["payerId"] == null ? null : dr["payerId"].ToString();
                    eod.preContextStatus = dr["preContextStatus"] == null ? null : dr["preContextStatus"].ToString();
                    eod.contextStatus = dr["contextStatus"] == null ? null : dr["contextStatus"].ToString();
                   
                    eod.transactionRef = dr["transactionRef"] == null ? null : dr["transactionRef"].ToString();
                    try
                    {
                        eod.IsSyncBSS = bool.Parse(dr["IsSyncBSS"].ToString()) == false ? false : true;
                    }
                    catch (Exception ex) {
                        eod.IsSyncBSS = false;
                    }
                    eod.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();

                    eod.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    eod.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    eod.amount = dr["amount"] == DBNull.Value ? 0 : double.Parse(dr["amount"].ToString());
                    eod.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();

                    eodlist.Add(eod);
                }
            }
            return eodlist;
        }

        public ResultMsg dal_GetEODListCount(bol_API_GetEODList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
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

        public IEnumerable<bol_API_GetEODList> dal_GetEODList(bol_API_GetEODList bol)
        {
            List<bol_API_GetEODList> eodlist = new List<bol_API_GetEODList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_GetEODList eod = new bol_API_GetEODList();
                    eod.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    eod.StartDate = dr["StartDate"] == null ? null : dr["StartDate"].ToString();
                    eod.EndDate = dr["EndDate"] == null ? null : dr["EndDate"].ToString();
                    eod.FormattedStartDate = dr["FormattedStartDate"] == null ? null : dr["FormattedStartDate"].ToString();
                    eod.FormattedEndDate = dr["FormattedEndDate"] == null ? null : dr["FormattedEndDate"].ToString();
                    eod.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    eod.FormattedCompletedDate = dr["FormattedCompletedDate"] == null ? null : dr["FormattedCompletedDate"].ToString();
                    eod.Records = dr["Records"] == DBNull.Value ? 0 : int.Parse(dr["Records"].ToString());
                    eod.UpdateRecords = dr["UpdateRecords"] == DBNull.Value ? 0 : int.Parse(dr["UpdateRecords"].ToString());
                    eodlist.Add(eod);
                }
            }
            return eodlist;
        }


        public async Task<ResultMsg> dal_InsertEODIssueLog(bol_API_MCB_EOD bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@EODID", bol.EODID);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);

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

        public async Task<ResultMsg> dal_Insert_PaymentStep1PG(bol_API_MCB_PaymentStep1PG bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_PaymentStep1PG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@userIdentifier", bol.userIdentifier);
                    cmd.Parameters.AddWithValue("@serviceId", bol.serviceId);
                    cmd.Parameters.AddWithValue("@productId", bol.productId);
                    cmd.Parameters.AddWithValue("@remarks", bol.remarks);
                    cmd.Parameters.AddWithValue("@mpin", bol.mpin);
                    cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                    cmd.Parameters.AddWithValue("@languageCode", bol.languageCode);

                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@exponent", bol.exponent);
                    cmd.Parameters.AddWithValue("@currency", bol.currency);
                    cmd.Parameters.AddWithValue("@unitType", bol.unitType);

                    cmd.Parameters.AddWithValue("@responseCode", bol.responseCode);
                    cmd.Parameters.AddWithValue("@responseMessage", bol.responseMessage);
                    cmd.Parameters.AddWithValue("@responseTransactionID", bol.responseTransactionID);
                    cmd.Parameters.AddWithValue("@responseToken", bol.responseToken);

                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@TradeType", bol.TradeType);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);

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

        public async Task<ResultMsg> dal_API_MCB_PayRequestLog(bol_API_MCB_PayRequestLog bo)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_PaymentStep1PG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@orderId", bo.orderId);
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

        public async Task<ResultMsg> dal_Update_MCBCallback(bol_API_MCB_PaymentStep1PG bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_PaymentStep1PG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                    cmd.Parameters.AddWithValue("@transactionId", bol.transactionId);
                    cmd.Parameters.AddWithValue("@transactionCode", bol.transactionCode);

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

        public bol_API_MCB_Detail dal_GetByOrderID(bol_API_MCB_PaymentStep1PG bol)
        {
            bol_API_MCB_Detail mcb_d = new bol_API_MCB_Detail();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MCB_PaymentStep1PG", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    mcb_d.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    mcb_d.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    mcb_d.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    mcb_d.TradeType = dr["TradeType"] == null ? null : dr["TradeType"].ToString();
                    mcb_d.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    mcb_d.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    mcb_d.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    mcb_d.PaymentType = dr["PaymentType"] == null ? null : dr["PaymentType"].ToString();

                    mcb_d.amount = dr["amount"] == DBNull.Value ? 0 : int.Parse(dr["amount"].ToString());
                    mcb_d.currency = dr["currency"] == null ? null : dr["currency"].ToString();

                    mcb_d.transactionStatus = dr["transactionStatus"] == null ? null : dr["transactionStatus"].ToString();
                }
            }
            return mcb_d;
        }

        public async Task<ResultMsg> dal_CheckSuccessPayment(bol_API_MCB_PaymentStep1PG bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_PaymentStep1PG", con);
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

        public async Task<ResultMsg> dal_UpdateMCBTransactionStatus(bol_API_MCB_PaymentStep1PG bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MCB_PaymentStep1PG", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@orderId", bol.orderId);

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

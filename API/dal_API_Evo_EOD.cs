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
    public class dal_API_Evo_EOD
    {
        string conn_str = dal_ConfigManager.GTG;

        public IEnumerable<bol_API_KBZ_EMoneyPayments> dal_Get_PendingList(bol_API_Evo_EOD bol)
        {
            List<bol_API_KBZ_EMoneyPayments> emps = new List<bol_API_KBZ_EMoneyPayments>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate.ToString("yyyy/MM/dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate.ToString("yyyy/MM/dd HH:mm:ss"));
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_KBZ_EMoneyPayments emp = new bol_API_KBZ_EMoneyPayments();
                    emp.merchantPaymentRef = dr["merchantPaymentRef"] == null ? null : dr["merchantPaymentRef"].ToString();
                    emp.IsSyncBSS = dr["IsSyncBSS"] == null ? null : dr["IsSyncBSS"].ToString();
                    emps.Add(emp);
                }
            }
            return emps;
        }

        public async Task<ResultMsg> dal_ActionEOD(bol_API_Evo_EOD bol)
        {
            int resp_code = 0;      //return Latest EODID

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
                    else if (bol.ActionParam == 4)
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

        public async Task<ResultMsg> dal_InsertEODLog(bol_API_Evo_EOD bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@EODID", bol.EODID);
                    cmd.Parameters.AddWithValue("@merchantPaymentRef", bol.merchantPaymentRef);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);

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

        public async Task<ResultMsg> dal_InsertEODDetail(bol_API_Evo_EOD bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
        public ResultMsg dal_GetEODListCount(bol_API_GetEODList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
                SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
        public bol_API_EvoEODProgress dal_GetMCBEODProgress(bol_API_EvoEODProgress bol)
        {
            bol_API_EvoEODProgress pro = new bol_API_EvoEODProgress();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
        public ResultMsg dal_GetEODDtailListCount(bol_API_EvoGetEODDtailList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
        public IEnumerable<bol_API_EvoGetEODDtailList> dal_GetEODDtailList(bol_API_EvoGetEODDtailList bol)
        {
            List<bol_API_EvoGetEODDtailList> eodlist = new List<bol_API_EvoGetEODDtailList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_EOD", con);
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
                    bol_API_EvoGetEODDtailList eod = new bol_API_EvoGetEODDtailList();
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
                    catch (Exception ex)
                    {
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
    }
}

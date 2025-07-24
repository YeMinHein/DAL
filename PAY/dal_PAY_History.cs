using BOL;
using BOL.General;
using BOL.PAY;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PAY
{
    public class dal_PAY_History
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_PAY_History()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }
        #region Payment Refund

        //public IQueryable<bol_PAY_History> PayHistoryList12(bol_PAY_History bol)
        //{
        //    List<bol_PAY_History> csetups = new List<bol_PAY_History>();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_PAY_History", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
        //        cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
        //        cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
        //        cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
        //        cmd.Parameters.AddWithValue("@PaymentMethod", bol.PaymentMethod);
        //        cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
        //        cmd.Parameters.AddWithValue("@UserName", bol.UserName);
        //        cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
        //        cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            bol_PAY_History csetup = new bol_PAY_History();
        //            if (bol.PaymentType == "Initial")
        //            {
        //                csetup.SA_ID = dr["SA_ID"] == null ? 0 : Convert.ToInt32(dr["SA_ID"].ToString());
        //                csetup.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
        //            }
        //            else if (bol.PaymentType == "Bill" || bol.PaymentType == "all" || bol.PaymentType == "Advance" || bol.PaymentType == null)
        //            {
        //                csetup.customerAccountNo = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
        //                csetup.BillingArea = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
        //            }
        //            else if (bol.PaymentType.Contains("Recharge"))
        //            {
        //                csetup.customerAccountNo = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
        //                csetup.BillingArea = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
        //            }

        //            csetup.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
        //            csetup.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
        //            csetup.PaymentMethod = dr["PaymentMethod"] == null ? null : dr["PaymentMethod"].ToString();
        //            csetup.PaymentOperator = dr["PaymentOperator"] == null ? null : dr["PaymentOperator"].ToString();
        //            csetup.PaymentStatus = dr["PaymentStatus"] == null ? null : dr["PaymentStatus"].ToString();
        //            // csetup.CreatedDate = dr["CreatedDate"] == null ? null : Convert.ToDateTime(dr["CreatedDate"]);
        //            csetup.transaction_id = dr["transaction_id"] == null ? null : dr["transaction_id"].ToString();
        //            csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
        //            csetup.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
        //            csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
        //            csetup.NRC = dr["NRC"] == null ? null : dr["NRC"].ToString();

        //            csetup.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
        //            csetup.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
        //            csetup.PaymentDateStr = dr["PaymentDateStr"] == null ? "" : Convert.ToString(dr["PaymentDateStr"]);
        //            csetup.CreatedDateStr = dr["CreatedDateStr"] == null ? "" : Convert.ToString(dr["CreatedDateStr"]);
        //            csetup.UpdatePaymentStatus = dr["UpdatePaymentStatus"] == null ? "" : Convert.ToString(dr["UpdatePaymentStatus"]);
        //            // csetup.CreatedDate= dr["CreatedDate"] == null || dr["CreatedDate"] == "" || dr["CreatedDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["CreatedDate"]);
        //            //csetup.PaymentDate= dr["PaymentDate"] == null || dr["PaymentDate"] == "" || dr["PaymentDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["PaymentDate"]);
        //            if (dr["CreatedDate"] != DBNull.Value)
        //            {
        //                csetup.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
        //            }
        //            if (dr["PaymentDate"] != DBNull.Value)
        //            {
        //                csetup.PaymentDate = DateTime.Parse(dr["PaymentDate"].ToString());
        //            }
        //            try
        //            {
        //                csetup.PaymentDocumentNo = dr["PaymentDocumentNo"] == null ? null : dr["PaymentDocumentNo"].ToString();
        //            }
        //            catch
        //            {

        //            }

        //            csetups.Add(csetup);
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //    return csetups.AsQueryable();
        //}

        public async Task<IQueryable<bol_PAY_History>> PayHistoryList(bol_PAY_History bol)
        {
            List<bol_PAY_History> csetups = new List<bol_PAY_History>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();

                var result = await SqlMapper.QueryAsync<bol_PAY_History>(
                                 con, "sp_PAY_History",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }

        public async Task<IQueryable<bol_PAY_History>> PXPayHistoryList(bol_PAY_History bol)
        {
            List<bol_PAY_History> csetups = new List<bol_PAY_History>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SearchDateCategory", bol.SearchDateCategory);
                con.Open();

                var result = await SqlMapper.QueryAsync<bol_PAY_History>(
                                 con, "sp_PX_PAY_History",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        public async Task<ResultMsg> PXPayHistoryCount(bol_PAY_History bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                //ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                //ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Counts", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SearchDateCategory", bol.SearchDateCategory);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_PX_PAY_History",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }

        #region Evo
        public async Task<IQueryable<bol_PAY_History>> EvoPayHistoryList(bol_PAY_History bol)
        {
            List<bol_PAY_History> csetups = new List<bol_PAY_History>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@IsOnlyFailed", bol.IsOnlyFailed);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();

                var result = await SqlMapper.QueryAsync<bol_PAY_History>(
                                 con, "sp_Evo_PAY_History",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }

        public async Task<ResultMsg> EvoPayHistoryCount(bol_PAY_History bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@IsOnlyFailed", bol.IsOnlyFailed);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Counts", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_Evo_PAY_History",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }

        #region evo remark update
        public async Task<ResultMsg> EvoUpdateRemark(bol_PAY_Update_Remark bol)
        { 
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@merch_order_id", bol.merch_order_id);
                ObjParm.Add("@SearchText", bol.ServiceNo);
                ObjParm.Add("@Remark", bol.Remark);
                ObjParm.Add("@UserName", bol.UserName);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_Evo_PAY_History",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }
        #endregion

        #endregion
        #region payment failed count
        public async Task<ResultMsg> EvoPayHistoryFailedCount(bol_PAY_History bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@IsOnlyFailed", bol.IsOnlyFailed);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Counts", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_Evo_PAY_History",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }

        public async Task<IQueryable<bol_PAY_Failed_Detail>> EvoPayHistoryDetail(bol_PAY_History bol)
        {
            List<bol_PAY_Failed_Detail> csetups = new List<bol_PAY_Failed_Detail>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@IsOnlyFailed", bol.IsOnlyFailed);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();

                var result = await SqlMapper.QueryAsync<bol_PAY_Failed_Detail>(
                                 con, "sp_Evo_PAY_History",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        #endregion

        //public ResultMsg PayHistoryCount(bol_PAY_History bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_PAY_History", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
        //            cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
        //            cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
        //            cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
        //            cmd.Parameters.AddWithValue("@PaymentMethod", bol.PaymentMethod);
        //            cmd.Parameters.AddWithValue("@UserName", bol.UserName);
        //            cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
        //            cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
        //            cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
        //            con.Open();
        //            // cmd.ExecuteNonQuery();
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

        public async Task<ResultMsg> PayHistoryCount(bol_PAY_History bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PaymentType", bol.PaymentType);
                ObjParm.Add("@PaymentMethod", bol.PaymentMethod);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Counts", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }

        #endregion


        public IEnumerable<bol_BillingArea> GetPAYBillingAreaList()
        {
            List<bol_BillingArea> billingareas = new List<bol_BillingArea>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_History", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 0);
                cmd.Parameters.AddWithValue("@PaymentType", "billingArea");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BillingArea billingarea = new bol_BillingArea();
                    billingarea.BillingArea = dr["BillingArea"] == DBNull.Value ? null : dr["BillingArea"].ToString();
                    billingareas.Add(billingarea);
                }
            }
            return billingareas;
        }

    }
}

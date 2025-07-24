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
    public class dal_API_KBZ_Precreate
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> Insert(bol_API_KBZ_Precreate bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_Precreate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@timestamp", bol.Request.timestamp);
                    cmd.Parameters.AddWithValue("@method", bol.Request.method);
                    cmd.Parameters.AddWithValue("@notify_url", bol.Request.notify_url);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.Request.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.Request.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.Request.sign);
                    cmd.Parameters.AddWithValue("@version", bol.Request.version);

                    cmd.Parameters.AddWithValue("@merch_order_id", bol.Request.biz_content.merch_order_id);
                    cmd.Parameters.AddWithValue("@merch_code", bol.Request.biz_content.merch_code);
                    cmd.Parameters.AddWithValue("@appid", bol.Request.biz_content.appid);
                    cmd.Parameters.AddWithValue("@trade_type", bol.Request.biz_content.trade_type);
                    cmd.Parameters.AddWithValue("@title", bol.Request.biz_content.title);
                    cmd.Parameters.AddWithValue("@total_amount", bol.Request.biz_content.total_amount);
                    cmd.Parameters.AddWithValue("@trans_currency", bol.Request.biz_content.trans_currency);
                    cmd.Parameters.AddWithValue("@timeout_express", bol.Request.biz_content.timeout_express);
                    cmd.Parameters.AddWithValue("@callback_info", bol.Request.biz_content.callback_info);
                    cmd.Parameters.AddWithValue("@operator_id", bol.Request.biz_content.operator_id);
                    cmd.Parameters.AddWithValue("@store_id", bol.Request.biz_content.store_id);
                    cmd.Parameters.AddWithValue("@terminal_id", bol.Request.biz_content.terminal_id);
                    cmd.Parameters.AddWithValue("@business_param", bol.Request.biz_content.business_param);

                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@response_result", bol.response_result);
                    cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@response_prepay_id", bol.response_prepay_id);
                    cmd.Parameters.AddWithValue("@response_nonce_str", bol.response_nonce_str);
                    cmd.Parameters.AddWithValue("@response_sign", bol.response_sign);
                    cmd.Parameters.AddWithValue("@response_qrCode", bol.response_qrCode);

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

        public async Task<ResultMsg> InsertV2(bol_API_KBZ_PrecreateV2 bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_Precreate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@timestamp", bol.Request.timestamp);
                    cmd.Parameters.AddWithValue("@method", bol.Request.method);
                    cmd.Parameters.AddWithValue("@notify_url", bol.Request.notify_url);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.Request.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.Request.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.Request.sign);
                    cmd.Parameters.AddWithValue("@version", bol.Request.version);

                    cmd.Parameters.AddWithValue("@merch_order_id", bol.Request.biz_content.merch_order_id);
                    cmd.Parameters.AddWithValue("@merch_code", bol.Request.biz_content.merch_code);
                    cmd.Parameters.AddWithValue("@appid", bol.Request.biz_content.appid);
                    cmd.Parameters.AddWithValue("@trade_type", bol.Request.biz_content.trade_type);
                    cmd.Parameters.AddWithValue("@title", bol.Request.biz_content.title);
                    cmd.Parameters.AddWithValue("@total_amount", bol.Request.biz_content.total_amount);
                    cmd.Parameters.AddWithValue("@trans_currency", bol.Request.biz_content.trans_currency);
                    cmd.Parameters.AddWithValue("@timeout_express", bol.Request.biz_content.timeout_express);
                    cmd.Parameters.AddWithValue("@callback_info", bol.Request.biz_content.callback_info);
                    cmd.Parameters.AddWithValue("@operator_id", bol.Request.biz_content.operator_id);
                    cmd.Parameters.AddWithValue("@store_id", bol.Request.biz_content.store_id);
                    cmd.Parameters.AddWithValue("@terminal_id", bol.Request.biz_content.terminal_id);
                    cmd.Parameters.AddWithValue("@business_param", bol.Request.biz_content.business_param);

                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@response_result", bol.response_result);
                    cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@response_prepay_id", bol.response_prepay_id);
                    cmd.Parameters.AddWithValue("@response_nonce_str", bol.response_nonce_str);
                    cmd.Parameters.AddWithValue("@response_sign", bol.response_sign);
                    cmd.Parameters.AddWithValue("@response_qrCode", bol.response_qrCode);

                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);

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
        public async Task<ResultMsg> InsertV2_1(bol_API_KBZ_PrecreateV2 bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_Precreate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@timestamp", bol.Request.timestamp);
                    cmd.Parameters.AddWithValue("@method", bol.Request.method);
                    cmd.Parameters.AddWithValue("@notify_url", bol.Request.notify_url);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.Request.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.Request.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.Request.sign);
                    cmd.Parameters.AddWithValue("@version", bol.Request.version);

                    cmd.Parameters.AddWithValue("@merch_order_id", bol.Request.biz_content.merch_order_id);
                    cmd.Parameters.AddWithValue("@merch_code", bol.Request.biz_content.merch_code);
                    cmd.Parameters.AddWithValue("@appid", bol.Request.biz_content.appid);
                    cmd.Parameters.AddWithValue("@trade_type", bol.Request.biz_content.trade_type);
                    cmd.Parameters.AddWithValue("@title", bol.Request.biz_content.title);
                    cmd.Parameters.AddWithValue("@total_amount", bol.Request.biz_content.total_amount);
                    cmd.Parameters.AddWithValue("@trans_currency", bol.Request.biz_content.trans_currency);
                    cmd.Parameters.AddWithValue("@timeout_express", bol.Request.biz_content.timeout_express);
                    cmd.Parameters.AddWithValue("@callback_info", bol.Request.biz_content.callback_info);
                    cmd.Parameters.AddWithValue("@operator_id", bol.Request.biz_content.operator_id);
                    cmd.Parameters.AddWithValue("@store_id", bol.Request.biz_content.store_id);
                    cmd.Parameters.AddWithValue("@terminal_id", bol.Request.biz_content.terminal_id);
                    cmd.Parameters.AddWithValue("@business_param", bol.Request.biz_content.business_param);

                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@response_result", bol.response_result);
                    cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@response_prepay_id", bol.response_prepay_id);
                    cmd.Parameters.AddWithValue("@response_nonce_str", bol.response_nonce_str);
                    cmd.Parameters.AddWithValue("@response_sign", bol.response_sign);
                    cmd.Parameters.AddWithValue("@response_qrCode", bol.response_qrCode);

                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);

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
        public bol_API_KBZ_Precreate GetByMerchOrderID(bol_API_KBZ_Precreate bol)
        {
            bol_API_KBZ_Precreate kbz_pc = new bol_API_KBZ_Precreate();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_KBZ_Precreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merch_order_id", bol.BillInvoiceNo);  //use Real BillInvoiceNo as Timestamp BillInvoiceNo
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                bol_API_KBZ_Precreate_Request kbz_r = new bol_API_KBZ_Precreate_Request();
                bol_API_Precreate_biz_content kbz_bc = new bol_API_Precreate_biz_content();

                while (dr.Read())
                {
                    kbz_pc.response_prepay_id = dr["response_prepay_id"] == null ? null : dr["response_prepay_id"].ToString();
                    kbz_pc.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    kbz_pc.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();                   
                    kbz_r.version = dr["version"] == null ? null : dr["version"].ToString();
                    kbz_pc.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    kbz_pc.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    kbz_bc.trade_type = dr["trade_type"] == null ? null : dr["trade_type"].ToString();
                    kbz_bc.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();

                    //kbz_pc.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                }
                kbz_pc.Request = kbz_r;
                kbz_pc.Request.biz_content = kbz_bc;
            }
            return kbz_pc;
        }

        public bol_API_KBZ_PrecreateV2 GetByMerchOrderIDV2(bol_API_KBZ_PrecreateV2 bol) //V2 - For Bill Month
        {
            bol_API_KBZ_PrecreateV2 kbz_pc = new bol_API_KBZ_PrecreateV2();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_KBZ_Precreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merch_order_id", bol.BillInvoiceNo);  //use Real BillInvoiceNo as Timestamp BillInvoiceNo
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                bol_API_KBZ_Precreate_Request kbz_r = new bol_API_KBZ_Precreate_Request();
                bol_API_Precreate_biz_content kbz_bc = new bol_API_Precreate_biz_content();

                while (dr.Read())
                {
                    kbz_pc.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    kbz_pc.response_prepay_id = dr["response_prepay_id"] == null ? null : dr["response_prepay_id"].ToString();
                    kbz_pc.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    kbz_pc.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    kbz_r.version = dr["version"] == null ? null : dr["version"].ToString();
                    kbz_pc.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    kbz_pc.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    kbz_bc.trade_type = dr["trade_type"] == null ? null : dr["trade_type"].ToString();
                    kbz_bc.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();

                    kbz_pc.PXType = dr["Type"] == null ? null : dr["Type"].ToString();      //Prepaid Enhancement
                }
                kbz_pc.Request = kbz_r;
                kbz_pc.Request.biz_content = kbz_bc;
            }
            return kbz_pc;
        }


        public bol_API_KBZ_Precreate_Check GetKBZPrecreateCheck(bol_API_KBZ_Precreate_Check bol)
        {
            bol_API_KBZ_Precreate_Check pc = new bol_API_KBZ_Precreate_Check();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_KBZ_Precreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pc.Counts = dr["Counts"] == DBNull.Value ? 0 : int.Parse(dr["Counts"].ToString());
                }
            }
            return pc;
        }

        #region Evo

        public bol_API_KBZ_Precreate_Check GetEvoKBZPrecreateCheck(bol_API_Evo_KBZ_Precreate_Check bol)
        {
            bol_API_KBZ_Precreate_Check pc = new bol_API_KBZ_Precreate_Check();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_Precreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merch_order_id", bol.BillInvoiceNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pc.Counts = dr["Counts"] == DBNull.Value ? 0 : int.Parse(dr["Counts"].ToString());
                }
            }
            return pc;
        }
        public async Task<ResultMsg> EvoInsert(bol_API_Evo_KBZ_Precreate bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_Precreate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@timestamp", bol.Request.timestamp);
                    cmd.Parameters.AddWithValue("@method", bol.Request.method);
                    cmd.Parameters.AddWithValue("@notify_url", bol.Request.notify_url);
                    cmd.Parameters.AddWithValue("@nonce_str", bol.Request.nonce_str);
                    cmd.Parameters.AddWithValue("@sign_type", bol.Request.sign_type);
                    cmd.Parameters.AddWithValue("@sign", bol.Request.sign);
                    cmd.Parameters.AddWithValue("@version", bol.Request.version);

                    cmd.Parameters.AddWithValue("@merch_order_id", bol.Request.biz_content.merch_order_id);
                    cmd.Parameters.AddWithValue("@merch_code", bol.Request.biz_content.merch_code);
                    cmd.Parameters.AddWithValue("@appid", bol.Request.biz_content.appid);
                    cmd.Parameters.AddWithValue("@trade_type", bol.Request.biz_content.trade_type);
                    cmd.Parameters.AddWithValue("@title", bol.Request.biz_content.title);
                    cmd.Parameters.AddWithValue("@total_amount", bol.Request.biz_content.total_amount);
                    cmd.Parameters.AddWithValue("@trans_currency", bol.Request.biz_content.trans_currency);
                    cmd.Parameters.AddWithValue("@timeout_express", bol.Request.biz_content.timeout_express);
                    cmd.Parameters.AddWithValue("@callback_info", bol.Request.biz_content.callback_info);
                    cmd.Parameters.AddWithValue("@operator_id", bol.Request.biz_content.operator_id);
                    cmd.Parameters.AddWithValue("@store_id", bol.Request.biz_content.store_id);
                    cmd.Parameters.AddWithValue("@terminal_id", bol.Request.biz_content.terminal_id);
                    cmd.Parameters.AddWithValue("@business_param", bol.Request.biz_content.business_param);

                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
                    cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
                    cmd.Parameters.AddWithValue("@response_result", bol.response_result);
                    cmd.Parameters.AddWithValue("@response_message", bol.response_message);
                    cmd.Parameters.AddWithValue("@response_prepay_id", bol.response_prepay_id);
                    cmd.Parameters.AddWithValue("@response_nonce_str", bol.response_nonce_str);
                    cmd.Parameters.AddWithValue("@response_sign", bol.response_sign);
                    cmd.Parameters.AddWithValue("@response_qrCode", bol.response_qrCode);

                    cmd.Parameters.AddWithValue("@BillMonth", bol.BillMonth);
                    cmd.Parameters.AddWithValue("@CustCode", bol.CustCode);
                    cmd.Parameters.AddWithValue("@Account", bol.Account);
                    cmd.Parameters.AddWithValue("@OfferCode", bol.OfferCode);
                    cmd.Parameters.AddWithValue("@Type", bol.PXType);
                    cmd.Parameters.AddWithValue("@PWAUrl", bol.PWAURL);

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

        public bol_API_KBZ_PrecreateV2 EvoGetByMerchOrderID(bol_API_KBZ_PrecreateV2 bol) //V2 - For Bill Month
        {
            bol_API_KBZ_PrecreateV2 kbz_pc = new bol_API_KBZ_PrecreateV2();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_Precreate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@merch_order_id", bol.BillInvoiceNo);  //use Real BillInvoiceNo as Timestamp BillInvoiceNo
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                bol_API_KBZ_Precreate_Request kbz_r = new bol_API_KBZ_Precreate_Request();
                bol_API_Precreate_biz_content kbz_bc = new bol_API_Precreate_biz_content();

                while (dr.Read())
                {
                    kbz_pc.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                    kbz_pc.response_prepay_id = dr["response_prepay_id"] == null ? null : dr["response_prepay_id"].ToString();
                    kbz_pc.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    kbz_r.version = dr["version"] == null ? null : dr["version"].ToString();
                    kbz_pc.Name = dr["Name"] == null ? null : dr["Name"].ToString();

                    kbz_pc.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    kbz_bc.trade_type = dr["trade_type"] == null ? null : dr["trade_type"].ToString();
                    kbz_bc.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
                    kbz_pc.PXType = dr["Type"] == null ? null : dr["Type"].ToString();      //Prepaid Enhancement
                    kbz_pc.CustCode = dr["CustCode"] == null ? null : dr["CustCode"].ToString();

                    kbz_pc.Account = dr["Account"] == null ? null : dr["Account"].ToString(); 
                    kbz_pc.OfferCode = dr["OfferCode"] == null ? null : dr["OfferCode"].ToString();
                    kbz_pc.subsID = dr["subsID"] == null ? null : dr["subsID"].ToString();
                    kbz_pc.effType = dr["effType"] == null ? null : dr["effType"].ToString();
                    kbz_pc.billType = dr["billType"] == null ? null : dr["billType"].ToString();

                    kbz_pc.response_prepay_id = dr["response_prepay_id"] == null ? null : dr["response_prepay_id"].ToString();
                    kbz_pc.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                }
                kbz_pc.Request = kbz_r;
                kbz_pc.Request.biz_content = kbz_bc;
            }
            return kbz_pc;
        }
        #endregion
    }
}
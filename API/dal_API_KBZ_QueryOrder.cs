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
    public class dal_API_KBZ_QueryOrder
    {
        string conn_str = dal_ConfigManager.GTG;

        //public bol_API_KBZ_QueryOrder GetByBillInvoiceNo(bol_API_KBZ_QueryOrder bol)  //No Use
        //{
        //    bol_API_KBZ_QueryOrder qo = new bol_API_KBZ_QueryOrder();

        //    using (SqlConnection con = new SqlConnection(conn_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_KBZ_QueryOrder", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@BillInvoiceNo", bol.BillInvoiceNo);
        //        cmd.Parameters.AddWithValue("@PaymentAlias", bol.PaymentAlias);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            qo.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
        //            qo.get_merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
        //        }
        //    }
        //    return qo;
        //}


        public async Task<ResultMsg> dal_CheckStatus(bol_API_KBZ_QueryOrder bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_QueryOrder", con);
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

        public async Task<ResultMsg> dal_CheckSuccessPayment(bol_API_KBZ_QueryOrder bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_KBZ_QueryOrder", con);
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
        
        public async Task<ResultMsg> dal_EvoCheckSuccessPayment(bol_API_KBZ_QueryOrder bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_QueryOrder", con);//the same proc with KBZ
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

        #endregion
    }
}

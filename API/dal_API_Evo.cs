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
    public class dal_API_Evo
    {
        string conn_str = dal_ConfigManager.GTG;
        public async Task<bol_API_GetCallBackRequest> dal_GetKBZ_CallBackRequest(bol_API_GetCallBackRequest bol)
        {
            int resp_code = 0;
            bol_API_GetCallBackRequest callBackReq = new bol_API_GetCallBackRequest();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Evo_KBZ_CallbackRequest", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@prepayID", bol.prepay_id);
                cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    callBackReq.mm_order_id = dr["mm_order_id"] == null ? null : dr["mm_order_id"].ToString();
                    callBackReq.trade_status = dr["trade_status"] == null ? null : dr["trade_status"].ToString();
                }
            }
            return callBackReq;
        }

    }
}

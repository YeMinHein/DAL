using BOL;
using BOL.NOTI;
using BOL.WebNoti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WebNoti
{
    public class dal_WebNOTI_EventBillGeneration
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_WebNOTI_EventBillGeneration() { }

        public IEnumerable<bol_WebNOTI_EventBillGeneration> GetUnpaidBillList()
        {
            List<bol_WebNOTI_EventBillGeneration> param_list = new List<bol_WebNOTI_EventBillGeneration>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_EventBillGeneration", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_EventBillGeneration ebg = new bol_WebNOTI_EventBillGeneration();
                    ebg.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    ebg.DeviceID = dr["DeviceID"] == null ? null : dr["DeviceID"].ToString();
                    ebg.BillingAccountNo = dr["BillingAccountNo"] == null ? null : dr["BillingAccountNo"].ToString();
                    param_list.Add(ebg);
                }
            }
            return param_list;


        }
    }
}

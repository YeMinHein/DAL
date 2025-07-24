using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NOTI
{
    public class dal_NOTI_Log
    {
        string conn_str = dal_ConfigManager.GTG;
        public void Insert_NotiProgressLog(int NotiSendID, string CustAccNo, string DeviceID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@NotiSendID", NotiSendID);
                    cmd.Parameters.AddWithValue("@CustAccNo", CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", DeviceID);
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

        public void Insert_NotiExcepLog(int NotiSendID, string CustAccNo, string DeviceID, string ExceptionType, string ExceptionMessage)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Log", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@NotiSendID", NotiSendID);
                    cmd.Parameters.AddWithValue("@CustAccNo", CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", DeviceID);
                    cmd.Parameters.AddWithValue("@ExceptionType", ExceptionType);
                    cmd.Parameters.AddWithValue("@ExceptionMessage", ExceptionMessage);
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
    }
}

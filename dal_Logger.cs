using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class dal_Logger
    {
        string conn_str = dal_ConfigManager.GTG;

        public void Insert(int Level, string Message, string Exception, int Module, string TargetLocation)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Log_Excep", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@ExceptionDateTime", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Level", Level);
                    cmd.Parameters.AddWithValue("@Message", Message);
                    cmd.Parameters.AddWithValue("@Exception", Exception);
                    cmd.Parameters.AddWithValue("@Module", Module);
                    cmd.Parameters.AddWithValue("@TargetLocation", TargetLocation);
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

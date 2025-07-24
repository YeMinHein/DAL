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
    public class dal_API_SystemParam
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
       
        #region GetSystemParamValue
        public String GetSystemParamValue(string KeyName)
        {
            string KeyValue = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GM_SysParams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 6);
                    cmd.Parameters.AddWithValue("@KeyName", KeyName);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        KeyValue = dr["KeyValue"] == null ? null : dr["KeyValue"].ToString();
                       
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }

            return KeyValue;
        }
        #endregion

    }
}

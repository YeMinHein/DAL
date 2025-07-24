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
    public class dal_API_UserAuthentication
    {
        string conn_str = dal_ConfigManager.GTG;

        public bol_API_UserAuthentication GetUserAuthentication(bol_API_UserAuthentication bol)
        {
            bol_API_UserAuthentication ua = new bol_API_UserAuthentication();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_API_UserAuthentication", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@userName", bol.UserName);
                cmd.Parameters.AddWithValue("@password", bol.Password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ua.UserName = dr["userName"] == null ? null : dr["userName"].ToString();
                    ua.FullName = dr["fullName"] == null ? null : dr["fullName"].ToString();
                    ua.UserRole = dr["role"] == null ? null : dr["role"].ToString();
                }
            }
            return ua;
        }
    }
}

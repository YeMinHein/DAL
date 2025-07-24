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
    public class dal_API_CF_CollectForm
    {
        string conn_str = dal_ConfigManager.GTG;

        public async Task<ResultMsg> Insert(bol_API_CF_CollectForm bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@name", bol.name);
                    cmd.Parameters.AddWithValue("@phone", bol.phone);
                    cmd.Parameters.AddWithValue("@email", bol.email);

                    cmd.Parameters.AddWithValue("@city", bol.city);
                    cmd.Parameters.AddWithValue("@township", bol.township);
                    cmd.Parameters.AddWithValue("@address", bol.address);
                    cmd.Parameters.AddWithValue("@house_hold_type", bol.house_hold_type);
                    cmd.Parameters.AddWithValue("@collect_from", bol.collect_from);
                    cmd.Parameters.AddWithValue("@messenger_user_id", bol.messenger_user_id);
                    cmd.Parameters.AddWithValue("@interested", bol.interested);
                    cmd.Parameters.AddWithValue("@other", bol.other);

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

            //--department,--username,staffid,


        }
    }
}

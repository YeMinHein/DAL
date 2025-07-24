using BOL;
using BOL.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public class dal_API_CustInfo
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        #region[GetCustomerInfo]
        public bol_API_GetCustomerInfo GetCustomerInfo(bol_API_GetCustomerInfo bol)
        {
            bol_API_GetCustomerInfo csetup = new bol_API_GetCustomerInfo();
            int ActionParam = 4;
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CustomerAccountDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();                
                while (dr.Read())
                {
                    csetup.CustAccNo = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
                    csetup.Email = dr["emailAddress"] == null ? null : dr["emailAddress"].ToString();       
                }
            }
            return csetup;
        }
        #endregion

        #region[GetBSCustomerInfo]
        public bol_API_GetCustomerInfo GetBSCustomerInfo(bol_API_GetCustomerInfo bol)
        {
            bol_API_GetCustomerInfo csetup = new bol_API_GetCustomerInfo();
            int ActionParam = 25;
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    csetup.CustAccNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                    csetup.Email = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                }
            }
            return csetup;
        }
        #endregion   
    }
}

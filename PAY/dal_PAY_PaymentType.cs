using BOL;
using BOL.PAY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PAY
{
   public class dal_PAY_PaymentType
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_PAY_PaymentType()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        #region PaymentTypeList

        public IQueryable<bol_PAY_PaymentType> PaymentTypeList(bol_PAY_PaymentType bol)
        {
            List<bol_PAY_PaymentType> csetups = new List<bol_PAY_PaymentType>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_PaymentMethod", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", bol.actionParam);             
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PAY_PaymentType csetup = new bol_PAY_PaymentType();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();                 
                    csetups.Add(csetup);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        #endregion

        #region Payment Method
        public IQueryable<bol_PAY_PaymentMethod> PaymentMethodList(bol_PAY_PaymentMethod bol)
        {
            List<bol_PAY_PaymentMethod> csetups = new List<bol_PAY_PaymentMethod>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_PaymentMethod", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", bol.actionParam);
                cmd.Parameters.AddWithValue("@Status", bol.Status);
                cmd.Parameters.AddWithValue("@IsInitial", bol.IsInitial);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PAY_PaymentMethod csetup = new bol_PAY_PaymentMethod();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.BankName = dr["BankName"] == null ? null : dr["BankName"].ToString();
                    csetup.Value = dr["Value"] == null ? null : dr["Value"].ToString();
                    csetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                    csetups.Add(csetup);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        #endregion
    }
}

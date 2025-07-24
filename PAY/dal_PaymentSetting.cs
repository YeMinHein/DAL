using BOL;
using BOL.General;
using BOL.GM;
using BOL.LSM;
using BOL.PAY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PAY
{
    public class dal_PaymentSetting
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;

        public dal_PaymentSetting()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        public IEnumerable<bol_PaymentSetting> GetPaymentSetting(bol_PaymentSetting bol)
        {
            List<bol_PaymentSetting> lst = new List<bol_PaymentSetting>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PaymentSetting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PaymentSetting bolList = new bol_PaymentSetting();
                    bolList.ID = dr["ID"] == DBNull.Value ? 0 : (int)dr["ID"];
                    bolList.ServiceType = dr["ServiceType"] == DBNull.Value ? null : dr["ServiceType"].ToString();
                    bolList.PaymentType = dr["PaymentType"] == null ? null : dr["PaymentType"].ToString();
                    bolList.PaymentMethod = dr["PaymentMethod"] == null ? null : dr["PaymentMethod"].ToString();
                    bolList.IsOpen = dr["IsOpen"] == DBNull.Value ? false : bool.Parse(dr["IsOpen"].ToString());
                    lst.Add(bolList);
                }
            }
            return lst;
        }        

        public ResultMsg Insert(bol_PaymentSetting bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PaymentSetting", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
                    cmd.Parameters.AddWithValue("@PaymentMethod", bol.PaymentMethod);
                    cmd.Parameters.AddWithValue("@IsOpen", bol.IsOpen);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }


        public ResultMsg Update(bol_PaymentSetting bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PaymentSetting", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
                    cmd.Parameters.AddWithValue("@PaymentMethod", bol.PaymentMethod);
                    cmd.Parameters.AddWithValue("@IsOpen", bol.IsOpen);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public bol_PaymentSetting GetByID(bol_PaymentSetting bol)
        {
            bol_PaymentSetting sparam = new bol_PaymentSetting();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PaymentSetting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    sparam.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    sparam.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    sparam.PaymentType = dr["PaymentType"] == null ? null : dr["PaymentType"].ToString();
                    sparam.PaymentMethod = dr["PaymentMethod"] == null ? null : dr["PaymentMethod"].ToString();
                    sparam.IsOpen = dr["IsOpen"] == DBNull.Value ? false : bool.Parse(dr["IsOpen"].ToString());
                }
            }
            return sparam;
        }
    }
}

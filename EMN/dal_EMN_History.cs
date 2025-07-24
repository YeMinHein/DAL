using BOL;
using BOL.EMN;
using BOL.General;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EMN
{
    public class dal_EMN_History
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_EMN_History() { }

        public ResultMsg Insert(bol_EMN_History bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_History", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@FromAddress", bol.FromAddress);
                    cmd.Parameters.AddWithValue("@ToAddress", bol.ToAddress);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@SendDate", bol.SendDate);
                   
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
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

        public ResultMsg EmailLogInsert(bol_EMN_History bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EmailLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@FromEmail", bol.FromAddress);
                    cmd.Parameters.AddWithValue("@ToEmail", bol.ToAddress);
                    cmd.Parameters.AddWithValue("@CcEmail", bol.CCAddress);
                    cmd.Parameters.AddWithValue("@Subject", bol.Title);
                    cmd.Parameters.AddWithValue("@Body", bol.Content);
                    cmd.Parameters.AddWithValue("@ActivityType", bol.ActivityTypeID);
                    cmd.Parameters.AddWithValue("@SendDate", bol.SendDate);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@PaymentDocumentNo", bol.PaymentDocumentNo);//same as CRNo
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
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

        public ResultMsg GNReminderFailInsert(bol_EMN_History bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GNReminderFail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@ReminderID", bol.ReminderID);
                    cmd.Parameters.AddWithValue("@EMNSendID", bol.EMNSendID);
                    cmd.Parameters.AddWithValue("@ToEmail", bol.ToAddress);
                    cmd.Parameters.AddWithValue("@CcEmail", bol.CCAddress);
                    cmd.Parameters.AddWithValue("@Date", bol.SendDate);
                    cmd.Parameters.AddWithValue("@ExcelNo", bol.ExcelNo);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
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

        public ResultMsg GetEMNReminderCount(bol_EMN_History bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GNReminderFail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@ReminderID", bol.ReminderID);
                    cmd.Parameters.AddWithValue("@EMNSendID", bol.EMNSendID);
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

        public IEnumerable<bol_EMN_History> GetEMNReminderList(bol_EMN_History bol)
        {
            List<bol_EMN_History> templates = new List<bol_EMN_History>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GNReminderFail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 3);
                cmd.Parameters.AddWithValue("@ReminderID", bol.ReminderID);
                cmd.Parameters.AddWithValue("@EMNSendID", bol.EMNSendID);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMN_History tmp = new bol_EMN_History();
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.ToAddress = dr["ToEmail"] == null ? null : dr["ToEmail"].ToString();
                    tmp.CCAddress = dr["CcEmail"] == null ? null : dr["CcEmail"].ToString();
                    tmp.SendDate = dr["Date"] == null ? DateTime.Now : Convert.ToDateTime(dr["Date"].ToString());
                    tmp.ExcelNo = dr["ExcelNo"] == null ? 0 : int.Parse(dr["ExcelNo"].ToString());

                    if (dr["Date"].ToString() != "")
                    {
                        tmp.ReminderFailDate = dr["FormattedDate"].ToString();
                    }
                    templates.Add(tmp);
                }
            }
            return templates;


        }


        public IEnumerable<bol_EMNParam> GetEMNParamList(bol_EMNParam bol)
        {
            List<bol_EMNParam> paramlist = new List<bol_EMNParam>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_EMN_Param", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SubType", bol.Email_SubTypeID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMNParam tmp = new bol_EMNParam();
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.Email_SubTypeID = dr["Email_SubTypeID"] == null ? null : dr["Email_SubTypeID"].ToString();
                    tmp.ParamText = dr["ParamText"] == null ? null : dr["ParamText"].ToString();
                    tmp.ParamValue = dr["ParamValue"] == null ? null : dr["ParamValue"].ToString();

                    paramlist.Add(tmp);
                }
            }
            return paramlist;


        }

    }
}

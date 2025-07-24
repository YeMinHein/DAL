using BOL;
using BOL.EMN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EMN
{
    public class dal_EMN_Send
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_EMN_Send() { }

        public ResultMsg EMNInsert(bol_EMN_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@Records", bol.Records);
                    cmd.Parameters.AddWithValue("@EMNReminderType", bol.EMNReminderType);
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

        public bol_EMN_Progress GetEMNProgress(bol_EMN_Progress bol)
        {
            bol_EMN_Progress pro = new bol_EMN_Progress();
           
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_EMN_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@EMNSendID", bol.EMNSendID);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pro.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    pro.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    pro.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    pro.Message = dr["Content"] == null ? null : dr["Content"].ToString();
                    pro.Records = dr["Records"] == DBNull.Value ? 0 : int.Parse(dr["Records"].ToString());
                    pro.ProgressRecords = dr["ProgressRecords"] == DBNull.Value ? 0 : int.Parse(dr["ProgressRecords"].ToString());
                    pro.TemplateID = dr["TemplateID"] == DBNull.Value ? 0 : int.Parse(dr["TemplateID"].ToString());
                    pro.CompleteRecords = dr["CompleteRecords"] == DBNull.Value ? 0 : int.Parse(dr["CompleteRecords"].ToString());
                    pro.CreatedDate = dr["CreatedDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["CreatedDate"].ToString());
                    if (dr["CompletedDate"] != DBNull.Value)
                    {
                        pro.CompletedDate = DateTime.Parse(dr["CompletedDate"].ToString());
                    }
                    //pro.CreatedDate = dr["CreatedDate"] == DBNull.Value ? "" : dr["CreatedDate"].ToString();
                    //pro.CompletedDate = dr["CompletedDate"] == DBNull.Value ? "" : dr["CompletedDate"].ToString();
                    pro.FormattedCreatedDate = dr["FormattedCreatedDate"] == DBNull.Value ? "" : dr["FormattedCreatedDate"].ToString();
                    pro.FormattedCompletedDate = dr["FormattedCompletedDate"] == DBNull.Value ? "" : dr["FormattedCompletedDate"].ToString();
                }
            }
            
            return pro;
        }

        public ResultMsg GetLatestSendID(bol_EMN_Progress bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
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
        public ResultMsg EMN_SendUpdate(bol_EMN_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@EMNSendID", bol.ID);
                    cmd.Parameters.AddWithValue("@CompletedDate", DateTime.Now);
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


    }
}

using BOL;
using BOL.NOTI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NOTI
{
    public class dal_NOTI_Send
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_NOTI_Send() { }

        public ResultMsg Insert(bol_NOTI_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
                    cmd.Parameters.AddWithValue("@TopicType", bol.TopicType);
                    cmd.Parameters.AddWithValue("@Topic", bol.Topic);           //BillingArea, CustAccNo, General, PlanName, ServiceType, Status
                    cmd.Parameters.AddWithValue("@Category", bol.Category);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
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

        public IEnumerable<bol_NOTI_Param> GetNotiParamBySubType(bol_NOTI_Param bol)
        {
            List<bol_NOTI_Param> param_list = new List<bol_NOTI_Param>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SubType", bol.Noti_SubTypeID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_NOTI_Param param = new bol_NOTI_Param();
                    param.ParamText = dr["ParamText"] == null ? null : dr["ParamText"].ToString();
                    param.ParamValue = dr["ParamValue"] == null ? null : dr["ParamValue"].ToString();
                    param.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    param_list.Add(param);
                }
            }
            return param_list;


        }

        public ResultMsg InsertEBG_NotiSend(bol_NOTI_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
                    cmd.Parameters.AddWithValue("@TopicType", bol.TopicType);
                    cmd.Parameters.AddWithValue("@Topic", bol.Topic);
                    cmd.Parameters.AddWithValue("@Category", bol.Category);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@Records", bol.Records);
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

        public ResultMsg InsertEBG_NotiSendDevice(bol_NOTI_SendDevice bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@BodyDetail", bol.BodyDetail);
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

        public ResultMsg InsertEBG_NotiSendDeviceByDeviceList(bol_NOTI_SendDevice bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@BodyDetail", bol.BodyDetail);
                    cmd.Parameters.AddWithValue("@SentDate", bol.SentDate);
                    cmd.Parameters.AddWithValue("@InfoImageUrl", bol.InfoImageUrl);
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

        public async Task<ResultMsg> InsertEBG_NotiSendDeviceByDeviceListAsync(bol_NOTI_SendDevice bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@BodyDetail", bol.BodyDetail);
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

        public ResultMsg GetReplaceParam(bol_NOTI_ReplaceParam bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ParamType", bol.ParamType);
                    cmd.Parameters.AddWithValue("@Param", bol.Param);
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

        public ResultMsg GetLatestSendID(bol_NOTI_Progress bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
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

        public bol_NOTI_Progress GetNotiProgress(bol_NOTI_Progress bol)
        {
            bol_NOTI_Progress pro = new bol_NOTI_Progress();
           
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    pro.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    pro.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    pro.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    pro.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    pro.Records = dr["Records"] == DBNull.Value ? 0 : int.Parse(dr["Records"].ToString());
                    pro.ProgressRecords = dr["ProgressRecords"] == DBNull.Value ? 0 : int.Parse(dr["ProgressRecords"].ToString());
                    pro.CreatedDate = dr["CreatedDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["CreatedDate"].ToString());
                    pro.Template = dr["Template"] == null ? null : dr["Template"].ToString();
                    pro.CompleteRecords = dr["CompleteRecords"] == DBNull.Value ? 0 : int.Parse(dr["CompleteRecords"].ToString());
                    if (dr["CompletedDate"] != DBNull.Value) {
                        pro.CompletedDate = DateTime.Parse(dr["CompletedDate"].ToString());
                    }
                    //pro.CompletedDate = dr["CompletedDate"] == DBNull.Value ? null : DateTime.Parse(dr["CompletedDate"].ToString());
                    pro.FormattedCreatedDate = dr["FormattedCreatedDate"] == DBNull.Value ? "" : dr["FormattedCreatedDate"].ToString();
                    pro.FormattedCompletedDate = dr["FormattedCompletedDate"] == DBNull.Value ? "" : dr["FormattedCompletedDate"].ToString();
                }
            }
            
            return pro;
        }

        public ResultMsg Update_CompleteNotiSend(bol_NOTI_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.ID);
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


        public IEnumerable<bol_NOTI_Send_DeviceListByCustAccNo> GetDeviceListByCustAccNo(bol_NOTI_Send_DeviceListByCustAccNo bol)
        {
            List<bol_NOTI_Send_DeviceListByCustAccNo> dev_list = new List<bol_NOTI_Send_DeviceListByCustAccNo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_NOTI_Send_DeviceListByCustAccNo dev = new bol_NOTI_Send_DeviceListByCustAccNo();
                    dev.DeviceID = dr["DeviceID"] == null ? null : dr["DeviceID"].ToString();
                    dev_list.Add(dev);
                }
            }
            return dev_list;
        }

        public async Task<ResultMsg> Insert_NotiSendDeviceByCustAccNo(bol_NOTI_SendDevice bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    //cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);

                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    //cmd.Parameters.AddWithValue("@mm_order_id", bol.mm_order_id);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
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
        public async Task<ResultMsg> DeleteNotiByID(bol_NOTI_List bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_List", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);

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

        }

        public async Task<ResultMsg> UpdateNotiByID(bol_NOTI_List bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_NOTI_List", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);

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

        }
    }
}

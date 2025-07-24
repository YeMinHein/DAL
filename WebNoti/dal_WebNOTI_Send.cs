using BOL;
using BOL.General;
using BOL.GM;
using BOL.NOTI;
using BOL.WebNoti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WebNoti
{
    public class dal_WebNOTI_Send
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_WebNOTI_Send() { }

        //public ResultMsg Insert(bol_WebNOTI_Send bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@Type", bol.Type);
        //            cmd.Parameters.AddWithValue("@SubType", bol.SubType);
        //            cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
        //            cmd.Parameters.AddWithValue("@TopicType", bol.TopicType);
        //            cmd.Parameters.AddWithValue("@Topic", bol.Topic);           //BillingArea, CustAccNo, General, PlanName, ServiceType, Status
        //            cmd.Parameters.AddWithValue("@Category", bol.Category);
        //            cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
        //            cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}

        public IEnumerable<bol_WebNOTI_Param> GetWebNotiParamBySubType(bol_WebNOTI_Param bol)
        {
            List<bol_WebNOTI_Param> param_list = new List<bol_WebNOTI_Param>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SubType", bol.Noti_SubTypeID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_Param param = new bol_WebNOTI_Param();
                    param.ParamText = dr["ParamText"] == null ? null : dr["ParamText"].ToString();
                    param.ParamValue = dr["ParamValue"] == null ? null : dr["ParamValue"].ToString();
                    param.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    param_list.Add(param);
                }
            }
            return param_list;


        }

        //public ResultMsg InsertEBG_NotiSend(bol_WebNOTI_Send bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@Type", bol.Type);
        //            cmd.Parameters.AddWithValue("@SubType", bol.SubType);
        //            cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
        //            cmd.Parameters.AddWithValue("@TopicType", bol.TopicType);
        //            cmd.Parameters.AddWithValue("@Topic", bol.Topic);
        //            cmd.Parameters.AddWithValue("@Category", bol.Category);
        //            cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
        //            cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
        //            cmd.Parameters.AddWithValue("@Records", bol.Records);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}

        //public ResultMsg InsertEBG_NotiSendDevice(bol_WebNOTI_SendDevice bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 300; //seconds = 5mins
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
        //            cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
        //            cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
        //            cmd.Parameters.AddWithValue("@Title", bol.Title);
        //            cmd.Parameters.AddWithValue("@Content", bol.Content);
        //            cmd.Parameters.AddWithValue("@BodyDetail", bol.BodyDetail);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}


        //public ResultMsg GetReplaceParam(bol_WebNOTI_ReplaceParam bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@ParamType", bol.ParamType);
        //            cmd.Parameters.AddWithValue("@Param", bol.Param);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}

        //public ResultMsg GetLatestSendID(bol_WebNOTI_Progress bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };
        //}

        //public bol_WebNOTI_Progress GetNotiProgress(bol_WebNOTI_Progress bol)
        //{
        //    bol_WebNOTI_Progress pro = new bol_WebNOTI_Progress();

        //    using (SqlConnection con = new SqlConnection(conn_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
        //        cmd.Connection = con;
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            pro.Type = dr["Type"] == null ? null : dr["Type"].ToString();
        //            pro.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
        //            pro.Title = dr["Title"] == null ? null : dr["Title"].ToString();
        //            pro.Content = dr["Content"] == null ? null : dr["Content"].ToString();
        //            pro.Records = dr["Records"] == DBNull.Value ? 0 : int.Parse(dr["Records"].ToString());
        //            pro.ProgressRecords = dr["ProgressRecords"] == DBNull.Value ? 0 : int.Parse(dr["ProgressRecords"].ToString());
        //            pro.CreatedDate = dr["CreatedDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["CreatedDate"].ToString());
        //            pro.Template = dr["Template"] == null ? null : dr["Template"].ToString();
        //            pro.CompleteRecords = dr["CompleteRecords"] == DBNull.Value ? 0 : int.Parse(dr["CompleteRecords"].ToString());
        //            if (dr["CompletedDate"] != DBNull.Value) {
        //                pro.CompletedDate = DateTime.Parse(dr["CompletedDate"].ToString());
        //            }
        //            //pro.CompletedDate = dr["CompletedDate"] == DBNull.Value ? null : DateTime.Parse(dr["CompletedDate"].ToString());
        //            pro.FormattedCreatedDate = dr["FormattedCreatedDate"] == DBNull.Value ? "" : dr["FormattedCreatedDate"].ToString();
        //            pro.FormattedCompletedDate = dr["FormattedCompletedDate"] == DBNull.Value ? "" : dr["FormattedCompletedDate"].ToString();
        //        }
        //    }

        //    return pro;
        //}

        //public ResultMsg Update_CompleteNotiSend(bol_WebNOTI_Send bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@NotiSendID", bol.ID);
        //            cmd.Parameters.AddWithValue("@CompletedDate", DateTime.Now);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}


        //public IEnumerable<bol_WebNOTI_Send_DeviceListByCustAccNo> GetDeviceListByCustAccNo(bol_WebNOTI_Send_DeviceListByCustAccNo bol)
        //{
        //    List<bol_WebNOTI_Send_DeviceListByCustAccNo> dev_list = new List<bol_WebNOTI_Send_DeviceListByCustAccNo>();

        //    using (SqlConnection con = new SqlConnection(conn_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            bol_WebNOTI_Send_DeviceListByCustAccNo dev = new bol_WebNOTI_Send_DeviceListByCustAccNo();
        //            dev.DeviceID = dr["DeviceID"] == null ? null : dr["DeviceID"].ToString();
        //            dev_list.Add(dev);
        //        }
        //    }
        //    return dev_list;
        //}

        //public async Task<ResultMsg> Insert_NotiSendDeviceByCustAccNo(bol_WebNOTI_SendDevice bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 300; //seconds = 5mins
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
        //            cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
        //            //cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
        //            cmd.Parameters.AddWithValue("@Title", bol.Title);
        //            cmd.Parameters.AddWithValue("@Content", bol.Content);

        //            cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
        //            //cmd.Parameters.AddWithValue("@mm_order_id", bol.mm_order_id);
        //            cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };
        //}
        //public async Task<ResultMsg> DeleteNotiByID(bol_WebNOTI_List bol)
        //{
        //    int resp_code = 0;

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_NOTI_List", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 300; //seconds = 5mins
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@ID", bol.ID);

        //            cmd.Connection = con;
        //            await con.OpenAsync();
        //            resp_code = (int)await cmd.ExecuteScalarAsync();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code.ToString() };

        //}

        //public async Task<ResultMsg> UpdateNotiByID(bol_WebNOTI_List bol)
        //{
        //    int resp_code = 0;

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_NOTI_List", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 300; //seconds = 5mins
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@ID", bol.ID);

        //            cmd.Connection = con;
        //            await con.OpenAsync();
        //            resp_code = (int)await cmd.ExecuteScalarAsync();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code.ToString() };

        //}


        public async Task<ResultMsg> UpdateNotiByID(bol_WebNOTI_List bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.ToUserName);
                    cmd.Connection = con;
                    await con.OpenAsync();
                    await cmd.ExecuteScalarAsync();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };

        }
        public async Task<ResultMsg> WebNotiDelete(bol_WebNoti_Send bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", 13);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@FromUserName", bol.fromUserName);
                    cmd.Parameters.AddWithValue("@ToUserName", bol.lstToUserName);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.Template_ID);
                    cmd.Parameters.AddWithValue("@DetailsUrl", bol.DetailsUrl);
                    cmd.Parameters.AddWithValue("@Torole", bol.torole);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsFinanceUser", bol.IsFinanceUser);
                    cmd.Parameters.AddWithValue("@IsOnlyOneUser", bol.IsOnlyOneUser);
                    cmd.Parameters.AddWithValue("@IsRoleUser", bol.IsRoleUser);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Connection = con;
                    await con.OpenAsync();
                    await cmd.ExecuteScalarAsync();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };

        }

        public async Task<ResultMsg> WebNotiRead(bol_WebNoti_Send bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", 14);
                    cmd.Parameters.AddWithValue("@DetailsUrl", bol.DetailsUrl);
                   cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Connection = con;
                    await con.OpenAsync();
                    await cmd.ExecuteScalarAsync();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };

        }

        public async Task<List<bol_WebNOTI_List>> WebNotiList(bol_WebNOTI_List bol)
        {
            List<bol_WebNOTI_List> types = new List<bol_WebNOTI_List>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.ToUserName);
                await con.OpenAsync();
                 SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_List type = new bol_WebNOTI_List();
                    type.fromUserName = dr["FromUserName"] == DBNull.Value ? null : dr["FromUserName"].ToString();
                    type.ToUserName = dr["ToUserName"] == DBNull.Value ? null : dr["ToUserName"].ToString();
                    type.Title = dr["Title"] == DBNull.Value ? null : dr["Title"].ToString();
                    type.Content = dr["Content"] == DBNull.Value ? null : dr["Content"].ToString();
                    type.DetailsUrl = dr["DetailsUrl"] == DBNull.Value ? null : dr["DetailsUrl"].ToString();
                    type.FormattedCreatedDate = dr["FormattedCreatedDate"] == DBNull.Value ? null : dr["FormattedCreatedDate"].ToString();
                    types.Add(type);
                }
            }
            return types;
        }
        public async Task<List<bol_WebNOTI_List>> WebNotiListWithPagination(bol_WebNOTI_List bol)
        {
            List<bol_WebNOTI_List> types = new List<bol_WebNOTI_List>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.ToUserName);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                await con.OpenAsync();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_List type = new bol_WebNOTI_List();
                    type.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    type.fromUserName = dr["FromUserName"] == DBNull.Value ? null : dr["FromUserName"].ToString();
                    type.ToUserName = dr["ToUserName"] == DBNull.Value ? null : dr["ToUserName"].ToString();
                    type.Title = dr["Title"] == DBNull.Value ? null : dr["Title"].ToString();
                    type.Content = dr["Content"] == DBNull.Value ? null : dr["Content"].ToString();
                    type.DetailsUrl = dr["DetailsUrl"] == DBNull.Value ? null : dr["DetailsUrl"].ToString();
                    type.IsRead = dr["IsRead"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsRead"].ToString());
                    type.FormattedCreatedDate = dr["FormattedCreatedDate"] == DBNull.Value ? null : dr["FormattedCreatedDate"].ToString();
                    type.AllNotiCount = dr["AllNotiCount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["AllNotiCount"].ToString());
                    type.NotiHours = dr["NotiHours"] == DBNull.Value ? null : dr["NotiHours"].ToString();
                    types.Add(type);
                }
            }
            return types;
        }
        public async Task<ResultMsg> WebNotiCount(bol_WebNOTI_List bol)
        {
            string resp_code = "";
            string unread = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                  //  cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.fromUserName);
                   

                    cmd.Connection = con;
                   await con.OpenAsync();
                    //cmd.ExecuteNonQuery();
                    //resp_code = cmd.ExecuteScalar().ToString();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {

                        resp_code = dr["ReadCount"] == DBNull.Value ? "0" : dr["ReadCount"].ToString();
                        unread = dr["unreadCount"] == DBNull.Value ? "0" : dr["unreadCount"].ToString();
                        
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code+","+ unread, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code + "," + unread };

        }


        public async Task<List<bol_WebNOTI_User_Devices>> WebNotiDeviceTokenList(bol_WebNoti_Send bol)
        {
            List<bol_WebNOTI_User_Devices> types = new List<bol_WebNOTI_User_Devices>();
            bol.ActionParam = 7;
            using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 7);
                    cmd.Parameters.AddWithValue("@FromUserName", bol.fromUserName);
                    cmd.Parameters.AddWithValue("@ToUserName", bol.lstToUserName);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.Template_ID);

                    cmd.Parameters.AddWithValue("@DetailsUrl", bol.DetailsUrl);
                    cmd.Parameters.AddWithValue("@Torole", bol.torole);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsFinanceUser", bol.IsFinanceUser);
                    cmd.Parameters.AddWithValue("@IsOnlyOneUser", bol.IsOnlyOneUser);
                    cmd.Parameters.AddWithValue("@IsRoleUser", bol.IsRoleUser);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                    cmd.Connection = con;
                    await con.OpenAsync();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_WebNOTI_User_Devices type = new bol_WebNOTI_User_Devices();
                        type.Device_Token = dr["Device_Token"] == DBNull.Value ? null : dr["Device_Token"].ToString();

                        types.Add(type);
                    }
                }            
            return types;
        }


        public List<bol_WebNOTI_User_Devices> WebNotiSignalUserList(bol_WebNoti_Send bol)
        {
            List<bol_WebNOTI_User_Devices> types = new List<bol_WebNOTI_User_Devices>();
            bol.ActionParam = 10;
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 10);
                cmd.Parameters.AddWithValue("@FromUserName", bol.fromUserName);
                cmd.Parameters.AddWithValue("@ToUserName", bol.lstToUserName);
                cmd.Parameters.AddWithValue("@TemplateID", bol.Template_ID);
                cmd.Parameters.AddWithValue("@DetailsUrl", bol.DetailsUrl);
                cmd.Parameters.AddWithValue("@Torole", bol.torole);
                cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                cmd.Parameters.AddWithValue("@IsFinanceUser", bol.IsFinanceUser);
                cmd.Parameters.AddWithValue("@IsOnlyOneUser", bol.IsOnlyOneUser);
                cmd.Parameters.AddWithValue("@IsRoleUser", bol.IsRoleUser);
                cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                cmd.Connection = con;
                 con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_User_Devices type = new bol_WebNOTI_User_Devices();
                    type.StaffName = dr["StaffName"] == DBNull.Value ? null : dr["StaffName"].ToString();
                    type.UnReadCount = dr["UnReadCount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["UnReadCount"].ToString());
                    types.Add(type);
                }
            }
            return types;
        }

        #region SendNoti
        public async Task<ResultMsg> SendWebNoti(bol_WebNoti_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@FromUserName", bol.fromUserName);
                    cmd.Parameters.AddWithValue("@ToUserName", bol.lstToUserName);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.Template_ID);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@DetailsUrl", bol.DetailsUrl);
                    cmd.Parameters.AddWithValue("@Torole", bol.torole);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsFinanceUser", bol.IsFinanceUser);
                    cmd.Parameters.AddWithValue("@IsOnlyOneUser", bol.IsOnlyOneUser);
                    cmd.Parameters.AddWithValue("@IsRoleUser", bol.IsRoleUser);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                    cmd.Parameters.AddWithValue("@Records", bol.records);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Connection = con;
                     await   con.OpenAsync();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            try
            {
                if (bol.NotiSendID > 0 || bol.NotiSendID == -1)
                {
                    bol_WebNOTI_User_Devices bolToken = new bol_WebNOTI_User_Devices();
                    bolToken.UserName = bol.lstToUserName;

                    var notitokenList = await WebNotiDeviceTokenList(bol);


                    bol_WebNOTI_Template tembol = new bol_WebNOTI_Template();
                    tembol.ID = bol.Template_ID;
                    tembol.ActionParam = 10;
                    var template = await GetTemplateByID(tembol);

                    await SendWebFireBaseNoti(notitokenList, template,bol.FireBase_WebNotiServerKey);
                }
            }
            catch(Exception ex)
            {

            }

            return new ResultMsg() { Result = resp_code };
        }


        public async Task<ResultMsg> SendWebNotiWithoutTemplate(bol_WebNoti_Send bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@FromUserName", bol.fromUserName);
                    cmd.Parameters.AddWithValue("@ToUserName", bol.lstToUserName);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.Template_ID);

                    cmd.Parameters.AddWithValue("@DetailsUrl", bol.DetailsUrl);
                    cmd.Parameters.AddWithValue("@Torole", bol.torole);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsFinanceUser", bol.IsFinanceUser);
                    cmd.Parameters.AddWithValue("@IsOnlyOneUser", bol.IsOnlyOneUser);
                    cmd.Parameters.AddWithValue("@IsRoleUser", bol.IsRoleUser);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);

                    cmd.Connection = con;
                    await con.OpenAsync();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            try
            {
                bol_WebNOTI_User_Devices bolToken = new bol_WebNOTI_User_Devices();
                bolToken.UserName = bol.lstToUserName;

                var notitokenList = await WebNotiDeviceTokenList(bol);


                bol_WebNOTI_Template tembol = new bol_WebNOTI_Template();
                tembol.ID = bol.Template_ID;
                tembol.ActionParam = 10;
                //var template = await GetTemplateByID(tembol);
                tembol.Content = bol.Content;
                tembol.Title = bol.Title;
                await SendWebFireBaseNoti(notitokenList, tembol,bol.FireBase_WebNotiServerKey);
            }
            catch (Exception ex)
            {

            }

            return new ResultMsg() { Result = resp_code };
        }

        public async Task<bool> SendWebFireBaseNoti(List<bol_WebNOTI_User_Devices> bol , bol_WebNOTI_Template temps,string Serverkey)
        {
            try
            {
                if (bol != null)
                {
                    if (bol.Count > 0)
                    {
                           string[] devlist = bol.Select(p => p.Device_Token).ToArray();
                            await WebNoti_FirebaseService.SendPushNotification(devlist, temps.Title, temps.Content, null, Serverkey);
                        
                    }
                }
                
            }
            catch
            {

            }
            return true;
        }


        public async Task<bol_WebNOTI_Template> GetTemplateByID(bol_WebNOTI_Template bol)
        {
            bol_WebNOTI_Template tmp = new bol_WebNOTI_Template();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
               await con.OpenAsync();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    tmp.PromoUrl = dr["PromoUrl"] == null ? null : dr["PromoUrl"].ToString();
                    tmp.InfoImageUrl = dr["InfoImageUrl"] == null ? null : dr["InfoImageUrl"].ToString();
                    //tmp.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                }
            }
            return tmp;
        }
        #endregion

        #region Insert Web Noti Device
        public ResultMsg Insert_UserDevice(bol_WebNOTI_User_Devices bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_User_Devices", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Device_ID", bol.Device_ID);
                    cmd.Parameters.AddWithValue("@Device_Token", bol.Device_Token);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@BrowserName", bol.BrowserName);
                    cmd.Parameters.AddWithValue("@BrowserFullVersion", bol.BrowserFullVersion);
                    cmd.Parameters.AddWithValue("@OSName", bol.UserOSName);

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

        public IEnumerable<bol_Type> GetTypeList(bol_Type bol)
        {
            List<bol_Type> types = new List<bol_Type>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_User_Devices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Type type = new bol_Type();
                    type.Type = dr["Type"] == DBNull.Value ? null : dr["Type"].ToString();
                    types.Add(type);
                }
            }
            return types;
        }
        public IEnumerable<bol_SubType> GetSubTypeList(bol_SubType bol)
        {
            List<bol_SubType> subtypes = new List<bol_SubType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_User_Devices", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SubType subtype = new bol_SubType();
                    subtype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    subtype.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtype);
                }
            }
            return subtypes;
        }



        #endregion
    }
}

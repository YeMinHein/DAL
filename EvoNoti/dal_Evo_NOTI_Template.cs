using BOL;
using BOL.API;
using BOL.EvoNoti;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EvoNoti
{
   public class dal_Evo_NOTI_Template
    {
        ResultMsg result = new ResultMsg();
        private readonly IDbConnection _dbConnection;
        public dal_Evo_NOTI_Template() {
            _dbConnection = new SqlConnection(dal_ConfigManager.GTG);
        }

        public async Task<ResultMsg> GetNotiCount(bol_Evo_NOTI_Template bol)
        {
            string resp_code = "";
            try { 
                var parameters = new DynamicParameters();

                parameters.Add("ActionParam", bol.ActionParam);
                parameters.Add("SearchText", bol.SearchText);
                parameters.Add("Type", bol.Type);
                parameters.Add("SubType", bol.SubType);


                resp_code= await _dbConnection.QuerySingleAsync<string>("sp_Evo_NOTI_Template", parameters, commandType: CommandType.StoredProcedure);
        }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString()
    };
}

return new ResultMsg() { Result = resp_code };
        }

        public async Task<IEnumerable<bol_Evo_NOTI_TemplateV2>> GetListV2(bol_Evo_NOTI_TemplateV2 bol)
        {
            var parameters = new DynamicParameters();

            parameters.Add("ActionParam", bol.ActionParam);
            parameters.Add("SearchText", bol.SearchText);
            parameters.Add("Type", bol.Type);
            parameters.Add("SubType", bol.SubType);
            parameters.Add("PageSkipRows", bol.PageIndex);
            parameters.Add("PageTakeRows", 10);
            var result = await _dbConnection.QueryAsync<bol_Evo_NOTI_TemplateV2>(
               "sp_Evo_NOTI_Template",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }

        public async Task<bol_Evo_NOTI_TemplateV2> GetTemplateByType(bol_Evo_NOTI_TemplateV2 bol)
        {
            var parameters = new DynamicParameters();

            parameters.Add("ActionParam", bol.ActionParam);
            parameters.Add("SearchText", bol.SearchText);
            parameters.Add("Type", bol.Type);
            parameters.Add("SubType", bol.SubType);
            parameters.Add("PageSkipRows", bol.PageIndex);
            parameters.Add("PageTakeRows", 10);
            var result = await _dbConnection.QuerySingleOrDefaultAsync<bol_Evo_NOTI_TemplateV2>(
               "sp_Evo_NOTI_Template",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result;
        }

        public async Task<bol_Evo_NOTI_TemplateV2> GetByIDV2(bol_Evo_NOTI_TemplateV2 bol)
        {        
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", bol.ActionParam);
            parameters.Add("ID", bol.ID);
            return await _dbConnection.QueryFirstAsync<bol_Evo_NOTI_TemplateV2>(
               "sp_Evo_NOTI_Template",
               parameters,
               commandType: CommandType.StoredProcedure
           );
        }


        public async Task<bol_Evo_NOTI_TemplateV2> GetCategory(bol_Evo_NOTI_TemplateV2 bol)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", bol.ActionParam);
            parameters.Add("Type", bol.Type);
            parameters.Add("SubType", bol.SubType);
            return await _dbConnection.QueryFirstAsync<bol_Evo_NOTI_TemplateV2>(
               "sp_Evo_NOTI_Template",
               parameters,
               commandType: CommandType.StoredProcedure
           );

        }



        public async Task<ResultMsg> InsertV2(bol_Evo_NOTI_TemplateV2 bol)
        {
            string resp_code = "";
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("ActionParam", bol.ActionParam);
                 parameters.Add("AppID", bol.AppID);
                 parameters.Add("Name", bol.Name);
                 parameters.Add("Description", bol.Description);
                 parameters.Add("Title", bol.Title);
                 parameters.Add("Content", bol.Content);
                 parameters.Add("Type", bol.Type);
                 parameters.Add("SubType", bol.SubType);
                 parameters.Add("IsActive", bol.IsActive);
                 parameters.Add("IsDefault", bol.IsDefault);
                parameters.Add("CreatedDate", bol.CreatedDate);
                 parameters.Add("CreatedBy", bol.CreatedBy);
                 parameters.Add("PromoImageUrl", bol.PromoImageUrl);
                 parameters.Add("TxnImageUrl", bol.TxnImageUrl);
                 parameters.Add("InfoImageUrl", bol.InfoImageUrl);
                 parameters.Add("PromoUrl", bol.PromoUrl);
                 parameters.Add("BodyDetail", bol.BodyDetail);


                resp_code = await _dbConnection.QuerySingleAsync<string>("sp_Evo_NOTI_Template", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };
        }


        public async Task<ResultMsg> UpdateV2(bol_Evo_NOTI_TemplateV2 bol)
        {
            string resp_code = "";
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("ActionParam", bol.ActionParam);
                 parameters.Add("ID", bol.ID);
                 parameters.Add("AppID", bol.AppID);
                 parameters.Add("Name", bol.Name);
                 parameters.Add("Description", bol.Description);
                 parameters.Add("Title", bol.Title);
                 parameters.Add("Content", bol.Content);
                parameters.Add("IsDefault", bol.IsDefault);
                parameters.Add("Type", bol.Type);
                 parameters.Add("SubType", bol.SubType);
                 parameters.Add("IsActive", bol.IsActive);
                 parameters.Add("ModifiedDate", bol.ModifiedDate);
                 parameters.Add("ModifiedBy", bol.ModifiedBy);
                // parameters.Add("PromoImageUrl", bol.PromoImageUrl);
                // parameters.Add("TxnImageUrl", bol.TxnImageUrl);
                // parameters.Add("InfoImageUrl", bol.InfoImageUrl);
                 parameters.Add("PromoUrl", bol.PromoUrl);
                 parameters.Add("BodyDetail", bol.BodyDetail);


                resp_code = await _dbConnection.QuerySingleAsync<string>("sp_Evo_NOTI_Template", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };
        }

        public async Task<ResultMsg> UpdateNotiInfoImage(bol_Evo_NOTI_TemplateV2 bol)
        {
            string resp_code = "";
            try
            {
                var parameters = new DynamicParameters();

                parameters.Add("ActionParam", bol.ActionParam);
                parameters.Add("@InfoImageUrl", bol.InfoImageUrl);
                parameters.Add("@ID", bol.ID);

                resp_code = await _dbConnection.QuerySingleAsync<string>("sp_Evo_NOTI_Template", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                return new ResultMsg
                {
                    Result = resp_code,
                    Exception = ex.GetType().ToString(),
                    Message = ex.Message == null ? null : ex.Message.ToString()
                };
            }
            return new ResultMsg() { Result = resp_code };
        }


        #region Send Noti
        public async Task<IEnumerable<bol_Evo_TopicType>> GetTopicTypeList(bol_Evo_TopicType bol)
        {

            var parameters = new DynamicParameters();

            parameters.Add("ActionParam", bol.ActionParam);
            var result = await _dbConnection.QueryAsync<bol_Evo_TopicType>(
               "sp_Evo_NOTI_Topic",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }

        public async Task<IEnumerable<bol_Evo_Topic>> GetTopicList(bol_Evo_Topic bol)
        {
            var parameters = new DynamicParameters();

            parameters.Add("ActionParam", bol.ActionParam);
            parameters.Add("TopicType", bol.TopicType);
            parameters.Add("CityID", bol.CityID);
            var result = await _dbConnection.QueryAsync<bol_Evo_Topic>(
               "sp_Evo_NOTI_Topic",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }
        public async Task<IEnumerable<bol_Evo_Topic>> GetTopicList(bol_Evo_Topic bol,string cityName)
        {
            var parameters = new DynamicParameters();

            parameters.Add("ActionParam", bol.ActionParam);
            parameters.Add("TopicType", bol.TopicType);
            parameters.Add("CityID", cityName);
            var result = await _dbConnection.QueryAsync<bol_Evo_Topic>(
               "sp_Evo_NOTI_Topic",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }
        #endregion

    }
   
    #region Evo Noti
    public class dal_Evo_NOTI_Send
    {
        ResultMsg result = new ResultMsg();
        private readonly IDbConnection _dbConnection;
        public dal_Evo_NOTI_Send()
        {
            _dbConnection = new SqlConnection(dal_ConfigManager.GTG);
        }

        public async Task<IEnumerable<bol_Evo_NOTI_Param>> GetNotiParamBySubType(bol_Evo_NOTI_Param bol)
        {

            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("ActionParam", bol.ActionParam);
                parameters.Add("SubType", bol.Noti_SubTypeID);
                var result = await _dbConnection.QueryAsync<bol_Evo_NOTI_Param>(
                   "sp_Evo_NOTI_Send",
                   parameters,
                   commandType: CommandType.StoredProcedure
               );
                return result.ToList();
            }
            catch(Exception ex)
            {

            }
            return null;

        }



        public ResultMsg InsertEBG_NotiSend(bol_Evo_NOTI_Send bol)
        {
            string resp_code = "";
            try
            {
                string conn_str = dal_ConfigManager.GTG;
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
                    cmd.Parameters.AddWithValue("@TopicType", bol.TopicType);
                    cmd.Parameters.AddWithValue("@showInInbox", bol.showInInbox);
                    cmd.Parameters.AddWithValue("@Topic", bol.Topic);
                    cmd.Parameters.AddWithValue("@Category", bol.Category);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
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


        public ResultMsg Update_CompleteNotiSend(bol_Evo_NOTI_Send bol)
        {
            string resp_code = "";
            try
            {
                string conn_str = dal_ConfigManager.GTG;
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_NOTI_Send", con);
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


        

        public async Task<ResultMsg> Insert_Receive_NotiSendDeviceByCustomerCodeAsync(bol_Evo_NOTI_SendDevice bol)
        {
            string resp_code = "";
            try
            {
                string conn_str = dal_ConfigManager.GTG;
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@CustomerCode", bol.CustomerCode);
                    cmd.Parameters.AddWithValue("@ServiceNo", bol.ServiceNo);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                    cmd.Parameters.AddWithValue("@PaymentOperator", bol.PaymentOperator);
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


        public async Task<ResultMsg> InsertEBG_NotiSendDeviceByDeviceListAsync(bol_Evo_NOTI_SendDevice bol)
        {
            string resp_code = "";
            try
            {
                string conn_str = dal_ConfigManager.GTG;
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Evo_NOTI_Send", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@NotiSendID", bol.NotiSendID);
                    cmd.Parameters.AddWithValue("@CustomerCode", bol.CustomerCode);
                    cmd.Parameters.AddWithValue("@ServiceNo", bol.ServiceNo);
                    cmd.Parameters.AddWithValue("@TemplateID", bol.TemplateID);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
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

        #region noti list , read, delete
        public async Task<IEnumerable<Evo_Noti_List_Response_Model>> GetNotiList(string CustomerCode)
        {

            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("ActionParam", 21);
                parameters.Add("CustomerCode", CustomerCode);
                var result = await _dbConnection.QueryAsync<Evo_Noti_List_Response_Model>(
                   "sp_Evo_NOTI_Send",
                   parameters,
                   commandType: CommandType.StoredProcedure
               );
                return result.ToList();
            }
            catch (Exception ex)
            {

            }
            return null;

        }

        public async Task<string> UpdateNoti(int ID, string customer_code)
        {
            string resp_code = "";
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("ActionParam", 22);
                parameters.Add("ID", ID);
                parameters.Add("CustomerCode", customer_code);
                resp_code = await _dbConnection.QuerySingleAsync<string>("sp_Evo_NOTI_Send", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

            }
            return resp_code;
        }
        public async Task<string> DeleteNoti(int ID,string customer_code)
        {
            string resp_code = "";
            var parameters = new DynamicParameters();
            try
            {
                parameters.Add("ActionParam", 23);
                parameters.Add("ID", ID);
                parameters.Add("CustomerCode", customer_code);
                resp_code = await _dbConnection.QuerySingleAsync<string>("sp_Evo_NOTI_Send", parameters, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {

            }
            return resp_code;
        }


        public async Task<Evo_Noti_Detail_Response_Model> GetNotiDetail(int ID, string customer_code)
        {
            var parameters = new DynamicParameters();

            parameters.Add("ActionParam", 24);
            parameters.Add("ID", ID);
            parameters.Add("CustomerCode", customer_code);
            var result = await _dbConnection.QuerySingleOrDefaultAsync<Evo_Noti_Detail_Response_Model>(
               "sp_Evo_NOTI_Send",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result;
        }
        #endregion
    }
    #endregion
}

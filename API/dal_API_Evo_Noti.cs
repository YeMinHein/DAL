using BOL.API;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
  public  class dal_API_Evo_Noti
    {
        private readonly IDbConnection _dbConnection;
        public dal_API_Evo_Noti()
        {
            _dbConnection = new SqlConnection(dal_ConfigManager.GTG);
        }

        public async Task<int> RegisterDeviceToken(Evo_FirebaseTopicReqModel bo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 1);
            parameters.Add("CustomerCode", bo.CustomerCode);
            parameters.Add("Token", bo.Token);
            parameters.Add("AppVersion", bo.AppVersion);
            parameters.Add("Platform", bo.Platform);
            parameters.Add("Model", bo.Model);
            parameters.Add("DeviceVersion", bo.DeviceVersion);

            return await _dbConnection.QuerySingleAsync<int>("sp_Evo_APP_RegisteredDevice", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<string>> GetTopicList(Evo_FirebaseTopicReqModel bo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 1);
            parameters.Add("CustomerCode", bo.CustomerCode);
            var result = await _dbConnection.QueryAsync<string>(
               "sp_Evo_NOTI_Topic",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }

        public async Task<List<Evo_TokenList_ResponseModel>> GetTokenList(Evo_TokenList_ReqModel bo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 3);
            parameters.Add("CustomerCode", bo.CustomerCode);
            parameters.Add("Token", "Token");
            parameters.Add("DeviceVersion", "DeviceVersion");
            var result = await _dbConnection.QueryAsync<Evo_TokenList_ResponseModel>(
               "sp_Evo_APP_RegisteredDevice",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }

        public async Task<int> RemoveDeviceToken(Evo_FirebaseTopicReqModel bo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 4);
            parameters.Add("CustomerCode", bo.CustomerCode);
            parameters.Add("Token", bo.Token);
            parameters.Add("AppVersion", bo.AppVersion);
            parameters.Add("Platform", bo.Platform);
            parameters.Add("Model", bo.Model);
            parameters.Add("DeviceVersion", bo.DeviceVersion);

            return await _dbConnection.QuerySingleAsync<int>("sp_Evo_APP_RegisteredDevice", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<int> UpdateReferralPrimary(Evo_SearchCustomerPrimaryReqModel bo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 6);
            parameters.Add("CustomerCode", bo.custCode);
            parameters.Add("Token", "Token");
            parameters.Add("Serviceno", bo.serviceno);
            return await _dbConnection.QuerySingleAsync<int>("sp_Evo_APP_RegisteredDevice", parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Evo_SubscriberPrimary>> GetSubscriberPrimaryList(Evo_TokenList_ReqModel bo)
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 5);
            parameters.Add("CustomerCode", bo.CustomerCode);
            parameters.Add("Token", "Token");
            parameters.Add("DeviceVersion", "DeviceVersion");
            var result = await _dbConnection.QueryAsync<Evo_SubscriberPrimary>(
               "sp_Evo_APP_RegisteredDevice",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }

        public async Task<List<Evo_SubscriberPrimary>> GetEvoSubCreatedDateNULL()
        {
            var parameters = new DynamicParameters();
            parameters.Add("ActionParam", 7);
            parameters.Add("CustomerCode", "12345");
            parameters.Add("Token", "Token");
            parameters.Add("DeviceVersion", "DeviceVersion");
            var result = await _dbConnection.QueryAsync<Evo_SubscriberPrimary>(
               "sp_Evo_APP_RegisteredDevice",
               parameters,
               commandType: CommandType.StoredProcedure
           );
            return result.ToList();
        }



    }
}

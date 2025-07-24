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
 public class dal_API_Evo_Subscriber
    {
        private readonly IDbConnection _dbConnection;
        public dal_API_Evo_Subscriber()
        {
            _dbConnection = new SqlConnection(dal_ConfigManager.GTG);
        }


        public async Task<int> Evo_Subscriber_Insert_Update(List<bol_API_Evo_Subscriber> SubscriberList)
        {
            foreach (var sub in SubscriberList)
            {              
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ActionParam", sub.ActionParam);
                    parameters.Add("CustCode", sub.CustCode);
                    parameters.Add("OfferCode", sub.OfferCode);
                    parameters.Add("CustomerName", sub.CustomerName);
                    parameters.Add("SubsID", sub.SubsID);
                    parameters.Add("SubName", sub.SubName);
                    parameters.Add("AcctNbr", sub.AcctNbr);
                    parameters.Add("ServiceNo_AccNbr", sub.ServiceNo_AccNbr);
                    parameters.Add("ServiceType", sub.ServiceType);
                    parameters.Add("PaidFlag", sub.PaidFlag);
                    parameters.Add("City", sub.City);
                    parameters.Add("Township", sub.Township);
                    parameters.Add("Email", sub.Email);
                    parameters.Add("PhoneNo", sub.PhoneNo);
                    parameters.Add("Category", sub.Category);
                    parameters.Add("Brand", sub.Brand);
                    parameters.Add("SubAddress", sub.SubAddress);
                    parameters.Add("ProdState", sub.ProdState);
                    parameters.Add("BlockReason", sub.BlockReason);
                    parameters.Add("EvoCreatedDate", sub.EvoCreatedDate);

                    await _dbConnection.QuerySingleAsync<int>("sp_Evo_SubscriberList", parameters, commandType: CommandType.StoredProcedure);
                }
                catch
                {

                }
            }
            return 1;
        }
        public async Task<bol_API_Evo_Subscriber> Evo_Subscriber_Profile(bol_API_Evo_Subscriber sub)
        {
                try
                {
                    var parameters = new DynamicParameters();
                    parameters.Add("ActionParam", 3);
                    parameters.Add("CustCode", sub.CustCode);
                    parameters.Add("OfferCode", sub.OfferCode);
                    parameters.Add("CustomerName", sub.CustomerName);
                    parameters.Add("SubsID", sub.SubsID);
                    parameters.Add("SubName", sub.SubName);
                    parameters.Add("AcctNbr", sub.AcctNbr);
                    parameters.Add("ServiceNo_AccNbr", sub.ServiceNo_AccNbr);
                    parameters.Add("ServiceType", sub.ServiceType);
                    parameters.Add("PaidFlag", sub.PaidFlag);
                    parameters.Add("City", sub.City);
                    parameters.Add("Township", sub.Township);
                    parameters.Add("BlockReason", sub.BlockReason);
                return await _dbConnection.QuerySingleAsync<bol_API_Evo_Subscriber>("sp_Evo_SubscriberList", parameters, commandType: CommandType.StoredProcedure);
                }
                catch
                {

                }
            return null;
        }

        public async Task<List<bol_API_Evo_Subscriber>> Evo_SearchSubscriberList(string name)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ActionParam", 4);
                parameters.Add("search", name);
                var result = await _dbConnection.QueryAsync<bol_API_Evo_Subscriber>(
                    "sp_Evo_SubscriberList",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
            catch
            {

            }
            return null;
        }

        public async Task<List<bol_API_Evo_PaymentSetting>> Evo_SearchSubscriberPaymentSetting(string name)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ActionParam", 5);
                parameters.Add("search", name);
                var result = await _dbConnection.QueryAsync<bol_API_Evo_PaymentSetting>(
                    "sp_Evo_SubscriberList",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
            catch
            {

            }
            return null;
        }

        #region evo app connect api logs
        public async Task<int> Evo_APP_Application_Log_Insert(bol_API_Evo_Application_Log bol)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ActionParam", 1);
                parameters.Add("CustomerCode", bol.CustomerCode);
                parameters.Add("APICode", bol.APICode);
                parameters.Add("ResponseCode", bol.ResponseCode);
                parameters.Add("FileName", bol.FileName);
                parameters.Add("MethodName", bol.MethodName);
                parameters.Add("ErrorMessage", bol.ErrorMessage);
                var result = await _dbConnection.ExecuteAsync(
                    "sp_Evo_App_Application_Log",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return 1;
            }
            catch
            {

            }
            return 0;
        }
        public async Task<List<bol_API_Evo_Application_Log>> Evo_APP_Application_Log_Search(bol_API_Evo_Application_Log_Search bol)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ActionParam", 2);
                parameters.Add("StartDate", bol.StartDate);
                parameters.Add("EndDate", bol.EndDate);
                parameters.Add("CustomerCode", bol.CustomerCode);
                var result = await _dbConnection.QueryAsync<bol_API_Evo_Application_Log>(
                    "sp_Evo_App_Application_Log",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                return result.ToList();
            }
            catch
            {

            }
            return null;
        }
        #endregion

        public async Task<bol_API_Evo_Subscriber> Evo_SearchSubscriber(string name)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("ActionParam", 4);
                parameters.Add("search", name);
               return await _dbConnection.QuerySingleAsync<bol_API_Evo_Subscriber>(
                    "sp_Evo_SubscriberList",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );
            }
            catch
            {

            }
            return null;
        }

    }
}

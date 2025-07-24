using BOL;
using BOL.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public class dal_API_BSS
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public bol_API_BSS_GetServiceBalance GetCategoryByPlanFullName(bol_API_BSS_GetServiceBalance bol)
        {
            bol_API_BSS_GetServiceBalance bol_gsb = new bol_API_BSS_GetServiceBalance();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_GetServiceBalance", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@FullName", bol.FullName);  //Plan Full Name
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_gsb.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                }
            }
            return bol_gsb;
        }


        #region [GetAccountHistory]
        public async Task<ResultMsg> ActionAccountHistory(bol_API_BSS_SyncAccountHistory bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_AccountHistory", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@serviceInstanceNumber", bol.serviceInstanceNumber);
                    cmd.Parameters.AddWithValue("@planName", bol.planName);
                    cmd.Parameters.AddWithValue("@planStatus", bol.planStatus);
                    cmd.Parameters.AddWithValue("@dateTime", bol.dateTime);
                    cmd.Parameters.AddWithValue("@staffId", bol.staffId);
                    cmd.Parameters.AddWithValue("@staffName", bol.staffName);

                    cmd.Parameters.AddWithValue("@functionality", bol.functionality);
                    cmd.Parameters.AddWithValue("@remark", bol.remark);
                    cmd.Parameters.AddWithValue("@valueBefore", bol.valueBefore);
                    cmd.Parameters.AddWithValue("@valueAfter", bol.valueAfter);


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

        public bol_API_BSS_GetCreationDateByCustAccNo GetCreationDateByCustAccNo(bol_API_BSS_GetCreationDateByCustAccNo bol)
        {
            bol_API_BSS_GetCreationDateByCustAccNo gcd = new bol_API_BSS_GetCreationDateByCustAccNo();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_AccountHistory", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gcd.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    gcd.creationDate = dr["creationDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["creationDate"].ToString());
                }
            }
            return gcd;
        }
        #endregion

        #region BillListAction
        public async Task<ResultMsg> ActionBillList(bol_API_BSS_SyncBillList bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_BillList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                cmd.Parameters.AddWithValue("@billingAccountNumbrer", bol.billingAccountNumbrer);
                cmd.Parameters.AddWithValue("@AccountStatus", bol.AccountStatus);
                cmd.Parameters.AddWithValue("@CurrentPlan", bol.CurrentPlan);
                cmd.Parameters.AddWithValue("@Name", bol.Name);
                cmd.Parameters.AddWithValue("@billNumber", bol.billNumber);
                cmd.Parameters.AddWithValue("@documentType", bol.documentType);
                cmd.Parameters.AddWithValue("@amount", bol.amount);
                cmd.Parameters.AddWithValue("@unpaidAmount", bol.unpaidAmount);
                cmd.Parameters.AddWithValue("@billDate", bol.billDate);
                cmd.Parameters.AddWithValue("@dueDate", bol.dueDate);
                cmd.Parameters.AddWithValue("@billStatus", bol.billStatus);
                cmd.Parameters.AddWithValue("@disputedStatus", bol.disputedStatus);
                cmd.Parameters.AddWithValue("@billMonth", bol.billMonth);
                cmd.Parameters.AddWithValue("@billId", bol.billId);
                cmd.Parameters.AddWithValue("@currencyName", bol.currencyName);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public async Task<ResultMsg> ActionBillListV2(bol_API_BSS_SyncBillListV2 bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_BillList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                cmd.Parameters.AddWithValue("@billingAccountNumbrer", bol.billingAccountNumbrer);
                cmd.Parameters.AddWithValue("@AccountStatus", bol.AccountStatus);
                cmd.Parameters.AddWithValue("@CurrentPlan", bol.CurrentPlan);
                cmd.Parameters.AddWithValue("@Name", bol.Name);

                cmd.Parameters.AddWithValue("@udt_BillList", bol.udt_BillList);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region [Sync Staff]
        public async Task<ResultMsg> ActionSyncStaff(bol_API_BSS_SyncStaff bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@staffId", bol.staffId);
                cmd.Parameters.AddWithValue("@staffName", bol.staffName);
                cmd.Parameters.AddWithValue("@username", bol.username);
                cmd.Parameters.AddWithValue("@accountStatus", bol.accountStatus);
                cmd.Parameters.AddWithValue("@address", bol.address);
                cmd.Parameters.AddWithValue("@cityName", bol.cityName);
                cmd.Parameters.AddWithValue("@stateName", bol.stateName);
                cmd.Parameters.AddWithValue("@countryName", bol.countryName);
                cmd.Parameters.AddWithValue("@zip", bol.zip);
                cmd.Parameters.AddWithValue("@email", bol.email);
                cmd.Parameters.AddWithValue("@mobile", bol.mobile);
                cmd.Parameters.AddWithValue("@businessGrpName", bol.businessGrpName);
                cmd.Parameters.AddWithValue("@businessGrpHieName", bol.businessGrpHieName);
                cmd.Parameters.AddWithValue("@organizationName", bol.organizationName);
                cmd.Parameters.AddWithValue("@loggedInStaffId", bol.loggedInStaffId);
                cmd.Parameters.AddWithValue("@birthDate", bol.birthDate);
                cmd.Parameters.AddWithValue("@organizationId", bol.organizationId);
                cmd.Parameters.AddWithValue("@externalId", bol.externalId);
                cmd.Parameters.AddWithValue("@roleId", bol.roleId);
                cmd.Parameters.AddWithValue("@roleName", bol.roleName);
                cmd.Parameters.AddWithValue("@sId", bol.sId);
                cmd.Parameters.AddWithValue("@acluserDetails", bol.acluserDetails);
                cmd.Parameters.AddWithValue("@allowLogin", bol.allowLogin);
                cmd.Parameters.AddWithValue("@visibilityFlag", bol.visibilityFlag);
                cmd.Parameters.AddWithValue("@lowerUserName", bol.lowerUserName);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public async Task<ResultMsg> ActionSyncStaffBillingAreaName(bol_API_BSS_SyncStaff_BillingAreaName bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Staff", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@billingAreaNameId", bol.billingAreaNameId);
                cmd.Parameters.AddWithValue("@staffId", bol.staffId);
                cmd.Parameters.AddWithValue("@name", bol.name);
                cmd.Parameters.AddWithValue("@alias", bol.alias);
                cmd.Parameters.AddWithValue("@visibilityFlag", bol.visibilityFlag);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region [GetAccountStatement]
        public bol_API_BSS_GetCreationDateByCustAccNo GetCreationDate_AccountStatement(bol_API_BSS_GetCreationDateByCustAccNo bol)
        {
            bol_API_BSS_GetCreationDateByCustAccNo gcd = new bol_API_BSS_GetCreationDateByCustAccNo();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_AccountStatement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gcd.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    gcd.creationDate = dr["creationDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["creationDate"].ToString());
                }
            }
            return gcd;
        }
        public async Task<ResultMsg> ActionAccountStatement(bol_API_BSS_AccountStatement bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_AccountStatement", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@totalClosingBalance", bol.totalClosingBalance);
                    cmd.Parameters.AddWithValue("@depositPaid", bol.depositPaid);
                    cmd.Parameters.AddWithValue("@currencyName", bol.currencyName);

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

        public async Task<ResultMsg> ActionAccountStatementDetail(bol_API_BSS_AccountStatementDetail bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_AccountStatement", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@documentnumber", bol.documentnumber);
                    cmd.Parameters.AddWithValue("@postDate", bol.postDate);
                    cmd.Parameters.AddWithValue("@documentType", bol.documentType);
                    cmd.Parameters.AddWithValue("@type", bol.type);
                    cmd.Parameters.AddWithValue("@amount", bol.amount);
                    cmd.Parameters.AddWithValue("@currencyName", bol.currencyName);
                    cmd.Parameters.AddWithValue("@balance", bol.balance);

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


        public bol_API_BSS_GetOpeningBalanceByCustAccNo GetOpeningBalance_AccountStatement(bol_API_BSS_GetOpeningBalanceByCustAccNo bol)
        {
            bol_API_BSS_GetOpeningBalanceByCustAccNo gob = new bol_API_BSS_GetOpeningBalanceByCustAccNo();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_AccountStatement", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gob.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    gob.RowCounts = dr["RowCounts"] == DBNull.Value ? 0 : int.Parse(dr["RowCounts"].ToString());
                }
            }
            return gob;
        }
        #endregion

        #region GetCustomerCodes
        public bol_API_BSS_GetCustomerCodes GetCustomerCodes(bol_API_BSS_GetCustomerCodes bol)
        {
            bol_API_BSS_GetCustomerCodes gcc = new bol_API_BSS_GetCustomerCodes();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gcc.billingAccountNo = dr["billingAccountNo"] == null ? null : dr["billingAccountNo"].ToString();
                    gcc.serviceInstanceNo = dr["serviceInstanceNo"] == null ? null : dr["serviceInstanceNo"].ToString();
                    gcc.serviceAccountNo = dr["serviceAccountNo"] == null ? null : dr["serviceAccountNo"].ToString();
                    gcc.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();

                    gcc.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                }
            }
            return gcc;
        }

        public bol_API_BSS_GetCustomerCodes GetCustomerCodesBybillingAccountNo(bol_API_BSS_GetCustomerCodes bol)
        {
            bol_API_BSS_GetCustomerCodes gcc = new bol_API_BSS_GetCustomerCodes();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@billingAccountNo", bol.billingAccountNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gcc.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    gcc.serviceInstanceNo = dr["serviceInstanceNo"] == null ? null : dr["serviceInstanceNo"].ToString();
                    gcc.serviceAccountNo = dr["serviceAccountNo"] == null ? null : dr["serviceAccountNo"].ToString();
                }
            }
            return gcc;
        }
        #endregion

        #region Sync Installation Order
        public async Task<ResultMsg> ActionSyncInstallationOrder(bol_API_BSS_InstallationOrder bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_InstallationOrder", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@udt_InstallationOrder", bol.IntallationOrders);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region SyncAccountHistory(BSS)
        public bol_API_BSS_GetAccountHistoryDatetime GetAccountHistoryDatetime(bol_API_BSS_GetAccountHistoryDatetime bol)
        {
            bol_API_BSS_GetAccountHistoryDatetime bol_gah = new bol_API_BSS_GetAccountHistoryDatetime();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("[sp_BSS_Customer]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);  //Plan Full Name
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_gah.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    bol_gah.dateTime = dr["dateTime"] == DBNull.Value ? null : DateTime.Parse(dr["dateTime"].ToString());
                }
            }
            return bol_gah;
        }
        #endregion

        #region SyncGetServiceInstanceSummaryDetail
        public async Task<ResultMsg> GetServiceInstanceSummaryDetail(bol_API_BSS_GetServiceInstanceSummaryDetail bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_ServiceInstanceSummaryDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                cmd.Parameters.AddWithValue("@serviceInstanceNumber", bol.serviceInstanceNumber);
                cmd.Parameters.AddWithValue("@planName", bol.planName);
                cmd.Parameters.AddWithValue("@planId", bol.planId);
                cmd.Parameters.AddWithValue("@planStatus", bol.planStatus);
                cmd.Parameters.AddWithValue("@planType", bol.planType);
                //cmd.Parameters.AddWithValue("@expiryDate", bol.expiryDate);
                if (bol.expiryDate.ToString() == "1/1/9999 12:00:00 AM" || bol.expiryDate.ToString() == "1/1/0001 12:00:00 AM")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiryDate", bol.expiryDate);
                }

                cmd.Parameters.AddWithValue("@userName", bol.userName);
                cmd.Parameters.AddWithValue("@currencyId", bol.currencyId);
                cmd.Parameters.AddWithValue("@basicPackageHistoryId", bol.basicPackageHistoryId);
                cmd.Parameters.AddWithValue("@basicPackageServiceAlias", bol.basicPackageServiceAlias);
                //cmd.Parameters.AddWithValue("@activationDate", bol.activationDate);
                if (bol.activationDate.ToString() == "1/1/9999 12:00:00 AM" || bol.activationDate.ToString() == "1/1/0001 12:00:00 AM")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@activationDate", bol.activationDate);
                }
                if (bol.contractstartdate.ToString() == "1/1/9999 12:00:00 AM" || bol.contractstartdate.ToString() == "1/1/0001 12:00:00 AM")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiryDate", bol.contractstartdate);
                }
                if (bol.contractenddate.ToString() == "1/1/9999 12:00:00 AM" || bol.contractenddate.ToString() == "1/1/0001 12:00:00 AM")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiryDate", bol.contractenddate);
                }
                //cmd.Parameters.AddWithValue("@contractstartdate", bol.contractstartdate);
                //cmd.Parameters.AddWithValue("@contractenddate", bol.contractenddate);
                cmd.Parameters.AddWithValue("@noofyears", bol.noofyears);
                cmd.Parameters.AddWithValue("@billingStatus", bol.billingStatus);
                cmd.Parameters.AddWithValue("@promoName", bol.promoName);
                //cmd.Parameters.AddWithValue("@promoStartDate", bol.promoStartDate);
                if (bol.promoStartDate.ToString() == "1/1/9999 12:00:00 AM" || bol.promoStartDate.ToString() == "1/1/0001 12:00:00 AM")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@promoStartDate", bol.promoStartDate);
                }
                //cmd.Parameters.AddWithValue("@promoEndDate", bol.promoEndDate);
                if (bol.promoEndDate.ToString() == "1/1/9999 12:00:00 AM" || bol.promoEndDate.ToString() == "1/1/0001 12:00:00 AM")
                {

                }
                else
                {
                    cmd.Parameters.AddWithValue("@expiryDate", bol.promoEndDate);
                }
                cmd.Parameters.AddWithValue("@billiareaalias", bol.billiareaalias);
                cmd.Parameters.AddWithValue("@starterPackValidityActive", bol.starterPackValidityActive);
                cmd.Parameters.AddWithValue("@currencyAlias", bol.currencyAlias);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region SyncUpdatePersonalData
        public async Task<ResultMsg> UpdatePersonalData(bol_API_BSS_UpdatePersonalData bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_CustomerAccountDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNo", bol.customerAccountNo);
                cmd.Parameters.AddWithValue("@city", bol.city);
                cmd.Parameters.AddWithValue("@state", bol.state);
                cmd.Parameters.AddWithValue("@country", bol.country);

                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region Sync IO
        public async Task<ResultMsg> SyncIO(bol_API_BSS_SyncIO bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_IO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                cmd.Parameters.AddWithValue("@promotionname", bol.promotionname);
                if(bol.condosalesmasterName != null)
                {
                    cmd.Parameters.AddWithValue("@condosalesmasterName", bol.condosalesmasterName); 
                }                
                cmd.Parameters.AddWithValue("@orderStatus", bol.orderStatus);
                cmd.Parameters.AddWithValue("@ownedByGroup", bol.ownedByGroup);
                cmd.Parameters.AddWithValue("@password", bol.password);
                if (bol.condosalesmasterId != null)
                {
                    cmd.Parameters.AddWithValue("@condosalesmasterId", bol.condosalesmasterId);
                }
                cmd.Parameters.AddWithValue("@planname", bol.planname);
                if (bol.customerLastName != null)
                {
                    cmd.Parameters.AddWithValue("@customerLastName", bol.customerLastName);
                }
                if (bol.appointmentDateTime != null)
                {
                    cmd.Parameters.AddWithValue("@appointmentDateTime", bol.appointmentDateTime);
                }
                cmd.Parameters.AddWithValue("@installationEndDate", bol.installationEndDate);
                cmd.Parameters.AddWithValue("@installationAssignDate", bol.installationAssignDate);
                if (bol.customerAddress != null)
                {
                    cmd.Parameters.AddWithValue("@customerAddress", bol.customerAddress);
                }
                cmd.Parameters.AddWithValue("@address", bol.address);
                cmd.Parameters.AddWithValue("@customerAccNo", bol.customerAccNo);
                cmd.Parameters.AddWithValue("@PhoneNo", bol.PhoneNo);
                cmd.Parameters.AddWithValue("@custName", bol.custName);
                cmd.Parameters.AddWithValue("@customerRMN", bol.customerRMN);
                cmd.Parameters.AddWithValue("@customerFirstName", bol.customerFirstName);
                cmd.Parameters.AddWithValue("@installationId", bol.installationId);
                cmd.Parameters.AddWithValue("@RN", bol.RN);
                if (bol.ownedBy != null)
                {
                    cmd.Parameters.AddWithValue("@ownedBy", bol.ownedBy);
                }
                cmd.Parameters.AddWithValue("@assignToGroup", bol.assignToGroup);
                if (bol.assignTo != null)
                {
                    cmd.Parameters.AddWithValue("@assignTo", bol.assignTo);
                }
                cmd.Parameters.AddWithValue("@isUpdate", bol.isUpdate);
                cmd.Parameters.AddWithValue("@township", bol.township);
                cmd.Parameters.AddWithValue("@username", bol.username);

                if (bol.installationEndDate.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@formattedInstallationEndDate", bol.formattedInstallationEndDate);
                }
                if (bol.installationAssignDate.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@formattedInstallationAssignDate", bol.formattedInstallationAssignDate);
                }
                if (bol.appointmentDateTime.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@formattedAppointmentDateTime", bol.formattedAppointmentDateTime);
                }

                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public async Task<ResultMsg> SyncIOV2(bol_API_BSS_SyncIOV2 bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_IO", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@orderId", bol.orderId);
                cmd.Parameters.AddWithValue("@promotionname", bol.promotionname);
                if (bol.condosalesmasterName != null)
                {
                    cmd.Parameters.AddWithValue("@condosalesmasterName", bol.condosalesmasterName);
                }
                cmd.Parameters.AddWithValue("@orderStatus", bol.orderStatus);
                cmd.Parameters.AddWithValue("@ownedByGroup", bol.ownedByGroup);
                cmd.Parameters.AddWithValue("@password", bol.password);
                if (bol.condosalesmasterId != null)
                {
                    cmd.Parameters.AddWithValue("@condosalesmasterId", bol.condosalesmasterId);
                }
                cmd.Parameters.AddWithValue("@planname", bol.planname);
                if (bol.customerLastName != null)
                {
                    cmd.Parameters.AddWithValue("@customerLastName", bol.customerLastName);
                }
                if (bol.appointmentDateTime != null)
                {
                    cmd.Parameters.AddWithValue("@appointmentDateTime", bol.appointmentDateTime);
                }
                cmd.Parameters.AddWithValue("@installationEndDate", bol.installationEndDate);
                cmd.Parameters.AddWithValue("@installationAssignDate", bol.installationAssignDate);
                if (bol.customerAddress != null)
                {
                    cmd.Parameters.AddWithValue("@customerAddress", bol.customerAddress);
                }
                cmd.Parameters.AddWithValue("@address", bol.address);
                cmd.Parameters.AddWithValue("@customerAccNo", bol.customerAccNo);
                cmd.Parameters.AddWithValue("@PhoneNo", bol.PhoneNo);
                cmd.Parameters.AddWithValue("@custName", bol.custName);
                cmd.Parameters.AddWithValue("@customerRMN", bol.customerRMN);
                cmd.Parameters.AddWithValue("@customerFirstName", bol.customerFirstName);
                cmd.Parameters.AddWithValue("@installationId", bol.installationId);
                cmd.Parameters.AddWithValue("@RN", bol.RN);
                if (bol.ownedBy != null)
                {
                    cmd.Parameters.AddWithValue("@ownedBy", bol.ownedBy);
                }
                cmd.Parameters.AddWithValue("@assignToGroup", bol.assignToGroup);
                if (bol.assignTo != null)
                {
                    cmd.Parameters.AddWithValue("@assignTo", bol.assignTo);
                }
                cmd.Parameters.AddWithValue("@isUpdate", bol.isUpdate);
                cmd.Parameters.AddWithValue("@township", bol.township);
                cmd.Parameters.AddWithValue("@username", bol.username);

                if (bol.installationEndDate.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@formattedInstallationEndDate", bol.formattedInstallationEndDate);
                }
                if (bol.installationAssignDate.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@formattedInstallationAssignDate", bol.formattedInstallationAssignDate);
                }
                if (bol.appointmentDateTime.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@formattedAppointmentDateTime", bol.formattedAppointmentDateTime);
                }

                cmd.Parameters.AddWithValue("@cafId", bol.cafId);
                cmd.Parameters.AddWithValue("@cafRefOrderId", bol.cafRefOrderId);
                if (bol.orderEndDate.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@orderEndDate", bol.orderEndDate);
                }
                cmd.Parameters.AddWithValue("@multipleCustomerContactNo", bol.multipleCustomerContactNo);
                cmd.Parameters.AddWithValue("@planId", bol.planId);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public async Task<ResultMsg> SyncCondoSales(bol_API_BSS_SyncCondoSales bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_CondoSales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@VISIBILITYFLAG", bol.VISIBILITYFLAG);
                cmd.Parameters.AddWithValue("@CITY", bol.CITY);
                cmd.Parameters.AddWithValue("@COUNTRY", bol.COUNTRY);
                cmd.Parameters.AddWithValue("@CONDOMASTERID", bol.CONDOMASTERID);
                cmd.Parameters.AddWithValue("@STATE", bol.STATE);
                cmd.Parameters.AddWithValue("@RN", bol.RN);
                cmd.Parameters.AddWithValue("@NAME", bol.NAME);

                cmd.Parameters.AddWithValue("@detail_condoMasterId", bol.detail_condoMasterId);
                cmd.Parameters.AddWithValue("@detail_name", bol.detail_name);
                cmd.Parameters.AddWithValue("@flatHouseNum", bol.flatHouseNum);
                cmd.Parameters.AddWithValue("@buildingName", bol.buildingName);
                cmd.Parameters.AddWithValue("@streetRoad", bol.streetRoad);
                cmd.Parameters.AddWithValue("@detail_visibilityflag", bol.detail_visibilityflag);
                cmd.Parameters.AddWithValue("@pinCode", bol.pinCode);

                cmd.Parameters.AddWithValue("@city_id", bol.city_id);
                if (bol.city_name.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@city_name", bol.city_name);
                }
                if (bol.city_alias.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@city_alias", bol.city_alias);
                }
                if (bol.city_visibilityFlag.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@city_visibilityFlag", bol.city_visibilityFlag);
                }

                cmd.Parameters.AddWithValue("@state_id", bol.state_id);
                if (bol.state_name.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@state_name", bol.state_name);
                }
                if (bol.state_alias.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@state_alias", bol.state_alias);
                }
                if (bol.state_visibilityFlag.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@state_visibilityFlag", bol.state_visibilityFlag);
                }

                cmd.Parameters.AddWithValue("@country_id", bol.country_id);
                if (bol.country_name.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@country_name", bol.country_name);
                }
                if (bol.country_alias.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@country_alias", bol.country_alias);
                }
                if (bol.country_visibilityFlag.ToString() != "")
                {
                    cmd.Parameters.AddWithValue("@country_visibilityFlag", bol.country_visibilityFlag);
                }


                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region SyncPXChangServicePlan
        public async Task<ResultMsg> SyncPXChangeSericePlan(bol_API_SyncPXChangeServicePlanModel bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_PX_ChangeServicePlan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                //cmd.Parameters.AddWithValue("@serviceInstanceNumber", bol.serviceInstanceNumber);
                cmd.Parameters.AddWithValue("@effectiveDate", bol.effectiveDate);
                cmd.Parameters.AddWithValue("@currencyAlias", bol.currencyAlias);
                cmd.Parameters.AddWithValue("@packageName", bol.packageName);
                cmd.Parameters.AddWithValue("@remarks", bol.remarks);
                cmd.Parameters.AddWithValue("@PMRVO_paymentMode", bol.PMRVO_paymentMode);
                cmd.Parameters.AddWithValue("@PMRVO_CMR_paymentMode", bol.PMRVO_CMR_paymentMode);
                cmd.Parameters.AddWithValue("@PMRVO_manualReceiptNumber", bol.PMRVO_manualReceiptNumber);
                cmd.Parameters.AddWithValue("@PMRVO_description", bol.PMRVO_description);
                cmd.Parameters.AddWithValue("@PMRVO_paymentDate", bol.PMRVO_paymentDate);
                cmd.Parameters.AddWithValue("@PMRVO_totalTransactionAmount", bol.PMRVO_totalTransactionAmount);
                cmd.Parameters.AddWithValue("@PMRVO_otherBankName", bol.PMRVO_otherBankName);
                cmd.Parameters.AddWithValue("@PMRVO_otherBranchName", bol.PMRVO_otherBranchName);
                cmd.Parameters.AddWithValue("@partnerAccountNumber", bol.partnerAccountNumber);
                cmd.Parameters.AddWithValue("@organizationId", bol.organizationId);
                cmd.Parameters.AddWithValue("@packageId", bol.packageId);
                cmd.Parameters.AddWithValue("@modulename", bol.modulename);
                //cmd.Parameters.AddWithValue("@CRDRNRVO_billingAccountNumber", bol.CRDRNRVO_billingAccountNumber);
                cmd.Parameters.AddWithValue("@CRDRNRVO_subtotal", bol.CRDRNRVO_subtotal);
                cmd.Parameters.AddWithValue("@noofyears", bol.noofyears);
                cmd.Parameters.AddWithValue("@eventType", bol.eventType);
                //cmd.Parameters.AddWithValue("@CDRVO_chargeId", bol.CDRVO_chargeId);
                //cmd.Parameters.AddWithValue("@CDRVO_chargeName", bol.CDRVO_chargeName);
                //cmd.Parameters.AddWithValue("@CDRVO_canOverride", bol.CDRVO_canOverride);
                //cmd.Parameters.AddWithValue("@CDRVO_actualAmount", bol.CDRVO_actualAmount);
                //cmd.Parameters.AddWithValue("@CDRVO_overriddenBy", bol.CDRVO_overriddenBy);
                //cmd.Parameters.AddWithValue("@CDRVO_overriddenAmount", bol.CDRVO_overriddenAmount);
                //cmd.Parameters.AddWithValue("@CDRVO_isOverridden", bol.CDRVO_isOverridden);
                //cmd.Parameters.AddWithValue("@CDRVO_overrideLimitMin", bol.CDRVO_overrideLimitMin);
                //cmd.Parameters.AddWithValue("@CDRVO_overrideLimitMax", bol.CDRVO_overrideLimitMax);
                //cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }
        #endregion

        #region PX Get/Insert CAFPackageCharges, Get PackageName 
        public bol_API_BSS_CAF_PackageChargesModel GetBSSCAFPackageCharges(bol_API_BSS_CAF_PackageChargesModel bol)
        {
            bol_API_BSS_CAF_PackageChargesModel bol_pc = new bol_API_BSS_CAF_PackageChargesModel();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@packageId", bol.packageId);  //Plan Full Name
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_pc.chargeId = dr["chargeId"] == null ? null : dr["chargeId"].ToString();
                    bol_pc.chargeName = dr["chargeName"] == null ? null : dr["chargeName"].ToString();
                    bol_pc.canOverride = dr["canOverride"] == DBNull.Value ? false : bool.Parse(dr["canOverride"].ToString());
                    bol_pc.actualAmount = dr["actualAmount"] == DBNull.Value ? 0 : int.Parse(dr["actualAmount"].ToString());
                    //bol_pc.overriddenBy = dr["overriddenBy"] == null ? null : dr["overriddenBy"].ToString();
                    //bol_pc.overriddenAmount = dr["overriddenAmount"] == DBNull.Value ? 0 : int.Parse(dr["overriddenAmount"].ToString());
                    //bol_pc.isOverridden = dr["isOverridden"] == DBNull.Value ? false : bool.Parse(dr["isOverridden"].ToString());
                    //bol_pc.overrideLimitMin = dr["overrideLimitMin"] == DBNull.Value ? 0 : int.Parse(dr["overrideLimitMin"].ToString());
                    //bol_pc.overrideLimitMax = dr["overrideLimitMax"] == DBNull.Value ? 0 : int.Parse(dr["overrideLimitMax"].ToString());
                    if (dr["overriddenBy"] != DBNull.Value)
                    {
                        bol_pc.overriddenBy = dr["overriddenBy"].ToString();
                    }
                    if (dr["overriddenAmount"] != DBNull.Value)
                    {
                        bol_pc.overriddenAmount = int.Parse(dr["overriddenAmount"].ToString());
                    }
                    if (dr["isOverridden"] != DBNull.Value)
                    {
                        bol_pc.isOverridden = bool.Parse(dr["isOverridden"].ToString());
                    }
                    if (dr["overrideLimitMin"] != DBNull.Value) 
                    {
                        bol_pc.overrideLimitMin = int.Parse(dr["overrideLimitMin"].ToString());
                    }
                    if (dr["overrideLimitMax"] != DBNull.Value)
                    {
                        bol_pc.overrideLimitMax = int.Parse(dr["overrideLimitMax"].ToString());
                    }

                   
                }
            }
            return bol_pc;
        }

        public async Task<ResultMsg> InsertBSSCAFPackageCharges(bol_API_BSS_CAF_PackageChargesModel bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@packageId", bol.packageId);
                cmd.Parameters.AddWithValue("@chargeId", bol.chargeId);
                cmd.Parameters.AddWithValue("@chargeName", bol.chargeName);
                if (bol.canOverride != null)
                {
                    cmd.Parameters.AddWithValue("@canOverride", bol.canOverride);
                }
                cmd.Parameters.AddWithValue("@actualAmount", bol.actualAmount);
                if (bol.overriddenBy != null)
                {
                    cmd.Parameters.AddWithValue("@overriddenBy", bol.overriddenBy);
                }
                if (bol.overriddenAmount != null)
                {
                    cmd.Parameters.AddWithValue("@overriddenAmount", bol.overriddenAmount);
                }
                if (bol.isOverridden != null)
                {
                    cmd.Parameters.AddWithValue("@isOverridden", bol.isOverridden);
                }
                if (bol.overrideLimitMin != null)
                {
                    cmd.Parameters.AddWithValue("@overrideLimitMin", bol.overrideLimitMin);
                }
                if (bol.overrideLimitMax != null)
                {
                    cmd.Parameters.AddWithValue("@overrideLimitMax", bol.overrideLimitMax);
                }

                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public bol_API_SyncPXChangeServicePlanModel GetPXPackageNameByID(bol_API_SyncPXChangeServicePlanModel bol)
        {
            bol_API_SyncPXChangeServicePlanModel bol_gpn = new bol_API_SyncPXChangeServicePlanModel();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@packageId", bol.packageId);  
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_gpn.packageName = dr["packageName"] == null ? null : dr["packageName"].ToString();
                }
            }
            return bol_gpn;
        }
        #endregion
    }
}

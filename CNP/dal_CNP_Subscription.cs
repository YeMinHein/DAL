using BOL;
using BOL.CNP;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.CNP
{
    public class dal_CNP_Subscription
    {
        private string conn_str = dal_ConfigManager.GTG;
        private ResultMsg result = new ResultMsg();

        public dal_CNP_Subscription()
        {
        }

        public IEnumerable<bol_CNP_Subscription> GetComplaintList(bol_CNP_Subscription bol)
        {
            List<bol_CNP_Subscription> complaints = new List<bol_CNP_Subscription>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_CustomerComplaint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_CNP_Subscription complaint = new bol_CNP_Subscription();
                    complaint.ID = dr["ID"] == null ? 0 : int.Parse(dr["ID"].ToString());
                    complaint.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    var test = dr["SolvedDate"];
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        complaint.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };
                    if (dr["CreatedDate"].ToString() != "")
                    {
                        complaint.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    }
                    complaints.Add(complaint);
                }
            }
            return complaints;
        }

        public IEnumerable<bol_CNP_CustomerData> GetCNPCustomerData(bol_CNP_CustomerData bol)
        {
            List<bol_CNP_CustomerData> templates = new List<bol_CNP_CustomerData>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_ResetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccNo", bol.CustomerAccNo);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_CNP_CustomerData template = new bol_CNP_CustomerData();
                        template.CustomerAccNo = dr["CustomerAccNo"] == DBNull.Value ? null : dr["CustomerAccNo"].ToString();
                        template.CustomerName = dr["CustomerName"] == DBNull.Value ? null : dr["CustomerName"].ToString();
                        template.Plan = dr["ServicePlan"] == DBNull.Value ? null : dr["ServicePlan"].ToString();
                        template.MobileNo = dr["MobileNumber"] == DBNull.Value ? null : dr["MobileNumber"].ToString();
                        templates.Add(template);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return templates;
        }

        public ResultMsg CNP_ResponseLog(bol_CNP_ResponseLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_ResponseLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Module", bol.Module);
                    cmd.Parameters.AddWithValue("@Action", bol.Action);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@URL", bol.URL);
                    cmd.Parameters.AddWithValue("@Code", bol.Code);
                    cmd.Parameters.AddWithValue("@RequestBody", bol.RequestBody);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
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

        public ResultMsg CNP_ResetPassword(bol_CNP_ResetPassword bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_ResetPassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccNo", bol.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@Password", bol.Password);
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

        #region Subscribe

        public bol_CNP_CustomerResponseModel CNP_Customer(bol_CNP_CustomerRequestModel reqModel)
        {
            try
            {
                bol_CNP_CustomerResponseModel returnModel = new bol_CNP_CustomerResponseModel();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_Customers", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", reqModel.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccNo", reqModel.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@CustomerName", reqModel.CustomerName == null ? "" : reqModel.CustomerName);
                    cmd.Parameters.AddWithValue("@UserName", reqModel.CustomerAccNo == null ? "" : reqModel.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@Password", reqModel.Password == null ? "" : reqModel.Password);
                    cmd.Parameters.AddWithValue("@EmailAddress", reqModel.EmailAddress == null ? "" : reqModel.EmailAddress);
                    cmd.Parameters.AddWithValue("@Phone", reqModel.RegisteredMobileNo == null || reqModel.RegisteredMobileNo=="" ? reqModel.MobileNumber : reqModel.RegisteredMobileNo);
                    cmd.Parameters.AddWithValue("@CreatedDate", reqModel.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", reqModel.CreatedBy == null ? "" : reqModel.CreatedBy);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnModel.RespCode = dr["RespCode"] == DBNull.Value ? null : dr["RespCode"].ToString();
                        returnModel.RespDescription = dr["RespDescription"] == DBNull.Value ? null : dr["RespDescription"].ToString();
                        returnModel.CNP_id = dr["CNP_id"] == null ? 0 : Convert.ToInt32(dr["CNP_id"].ToString());
                    }
                    if (!dr.HasRows)
                    {
                        returnModel.RespCode = "005";
                        returnModel.RespDescription = "New CanalPlus Subscription";
                    }

                    con.Close();
                    return returnModel;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bol_CNP_ServiceInstanceDetailsRespModel CNP_Cust_ServiceInstanceDetails(bol_CNP_ServiceInstanceDetailsRespModel reqModel)
        {
            try
            {
                bol_CNP_ServiceInstanceDetailsRespModel returnModel = new bol_CNP_ServiceInstanceDetailsRespModel();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_ServiceInstanceDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", reqModel.ActionParam);
                    cmd.Parameters.AddWithValue("@serviceInstanceNo", reqModel.ServiceInstanceNo);
                    cmd.Parameters.AddWithValue("@serviceAccountNo", reqModel.ServiceAccountNo);
                    cmd.Parameters.AddWithValue("@customerAccountNo", reqModel.CustomerAccountNo == null ? "" : reqModel.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@name", reqModel.Name == null ? "" : reqModel.Name);
                    cmd.Parameters.AddWithValue("@type", reqModel.Type == null ? "" : reqModel.Type);
                    cmd.Parameters.AddWithValue("@status", reqModel.Status == null ? "" : reqModel.Status);
                    cmd.Parameters.AddWithValue("@price", reqModel.Price == null ? "" : reqModel.Price);
                    cmd.Parameters.AddWithValue("@safeCustody", reqModel.SafeCustody == null ? "" : reqModel.SafeCustody);
                    cmd.Parameters.AddWithValue("@userId", reqModel.UserID == null ? "" : reqModel.UserID);
                    cmd.Parameters.AddWithValue("@customerType", reqModel.CustomerType == null ? "" : reqModel.CustomerType);
                    cmd.Parameters.AddWithValue("@billingStatus", reqModel.BillingStatus == null ? "" : reqModel.BillingStatus);
                    cmd.Parameters.AddWithValue("@dunningExcluded", reqModel.DunningExcluded == null ? "" : reqModel.DunningExcluded);
                    cmd.Parameters.AddWithValue("@currencyId", reqModel.CurrencyID == null ? "" : reqModel.CurrencyID);
                    cmd.Parameters.AddWithValue("@leafNode", reqModel.LeafNode == null ? "" : reqModel.LeafNode);
                    cmd.Parameters.AddWithValue("@currencyName", reqModel.CurrencyName == null ? "" : reqModel.CurrencyName);
                    cmd.Parameters.AddWithValue("@currencyCode", reqModel.CurrencyCode == null ? "" : reqModel.CurrencyCode);
                    cmd.Parameters.AddWithValue("@password", reqModel.Password == null ? "" : reqModel.Password);
                    cmd.Parameters.AddWithValue("@promoName", reqModel.PromoName == null ? "" : reqModel.PromoName);
                    cmd.Parameters.AddWithValue("@promoStartDate", reqModel.PromoStartDate == null ? "" : reqModel.PromoStartDate);
                    cmd.Parameters.AddWithValue("@promoEndDate", reqModel.PromoEndDate == null ? "" : reqModel.PromoEndDate);
                    cmd.Parameters.AddWithValue("@expiryDate", reqModel.ExpiryDate == null ? "" : reqModel.ExpiryDate);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnModel.CustomerAccountNo = dr["CustomerAccountNo"] == DBNull.Value ? null : dr["CustomerAccountNo"].ToString();
                        returnModel.serviceInstanceNo = dr["serviceInstanceNo"] == DBNull.Value ? null : dr["serviceInstanceNo"].ToString();
                        returnModel.Status = dr["status"] == DBNull.Value ? null : dr["status"].ToString();
                        returnModel.Name = dr["name"] == DBNull.Value ? null : dr["name"].ToString();
                        returnModel.MainPlan = dr["MainPlan"] == DBNull.Value ? null : dr["MainPlan"].ToString();

                        try
                        {
                            returnModel.ServicePlanName = dr["ServicePlanName"] == DBNull.Value ? null : dr["ServicePlanName"].ToString();
                        }
                        catch
                        {

                        }
                    }
                    if (!dr.HasRows)
                    {
                        return null;
                    }
                    con.Close();
                    return returnModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bol_CNP_CustomerAccDetailRequestModel CNP_GetCustomerAccountDetail(bol_CNP_CustomerAccDetailRequestModel reqModel)
        {
            try
            {
                bol_CNP_CustomerAccDetailRequestModel returnModel = new bol_CNP_CustomerAccDetailRequestModel();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CustomerAccountDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", reqModel.ActionParam);
                    cmd.Parameters.AddWithValue("@customerAccountNo", reqModel.CustAccNo);
                    cmd.Parameters.AddWithValue("@name", reqModel.Name);
                    cmd.Parameters.AddWithValue("@creationDate", reqModel.CreationDate);
                    cmd.Parameters.AddWithValue("@status", reqModel.Status);
                    cmd.Parameters.AddWithValue("@emailAddress", reqModel.EmailAddress);
                    cmd.Parameters.AddWithValue("@registeredMobileNumber", reqModel.RegisteredMobileNo);
                    cmd.Parameters.AddWithValue("@billingArea", reqModel.BillingArea);
                    cmd.Parameters.AddWithValue("@customerCategory", reqModel.CustomerCategory);
                    cmd.Parameters.AddWithValue("@geoId", reqModel.GEOld);
                    cmd.Parameters.AddWithValue("@userName", reqModel.UserName);
                    cmd.Parameters.AddWithValue("@partnerAccountNumber", reqModel.PartnerAccNumber);
                    cmd.Parameters.AddWithValue("@organizationId", reqModel.OrganizationID);
                    cmd.Parameters.AddWithValue("@address", reqModel.Address);
                    cmd.Parameters.AddWithValue("@city", reqModel.City);
                    cmd.Parameters.AddWithValue("@state", reqModel.State);
                    cmd.Parameters.AddWithValue("@country", reqModel.Country);
                    cmd.Parameters.AddWithValue("@secretQuestion", reqModel.SecretQuestion);
                    cmd.Parameters.AddWithValue("@secretAnswer", reqModel.SecretAnswer);
                    cmd.Parameters.AddWithValue("@mobileNumber", reqModel.MobileNumber);
                    cmd.Parameters.AddWithValue("@multipleMobileNumber", reqModel.MultipleMobileNumber);
                    cmd.Parameters.AddWithValue("@customerAccountNumberId", reqModel.CustomerAccNumberID);
                    cmd.Parameters.AddWithValue("@billAddCompanyName", reqModel.BillAddCompanyName);
                    cmd.Parameters.AddWithValue("@regNo", reqModel.RegNo);
                    cmd.Parameters.AddWithValue("@businessType", reqModel.BusinessType);
                    cmd.Parameters.AddWithValue("@Ico", reqModel.ICO);
                    cmd.Parameters.AddWithValue("@leadId", reqModel.LeadID);
                    cmd.Parameters.AddWithValue("@cafNumber", reqModel.CAFNumber);
                    cmd.Parameters.AddWithValue("@cafFormNumber", reqModel.CAFFormNumber);
                    cmd.Parameters.AddWithValue("@firstName", reqModel.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", reqModel.LastName);
                    cmd.Parameters.AddWithValue("@nationality", reqModel.Nationality);
                    cmd.Parameters.AddWithValue("@multipleEmailId", reqModel.MultipleEmailID);
                    cmd.Parameters.AddWithValue("@connectionType", reqModel.ConnectionType);
                    cmd.Parameters.AddWithValue("@actualAmount", reqModel.ActualAmount);
                    cmd.Parameters.AddWithValue("@promoId", reqModel.PromoID);
                    cmd.Parameters.AddWithValue("@overridenAmount", reqModel.OverridenAmount);
                    cmd.Parameters.AddWithValue("@ioNumber", reqModel.IONumber);
                    con.Open();

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnModel.CustAccNo = dr["customerAccountNo"] == DBNull.Value ? null : dr["customerAccountNo"].ToString();
                        returnModel.Name = dr["name"] == DBNull.Value ? null : dr["name"].ToString();
                        returnModel.BillingArea = dr["billingArea"] == DBNull.Value ? null : dr["billingArea"].ToString();

                        try
                        {
                            returnModel.EmailAddress = dr["emailAddress"] == DBNull.Value ? null : dr["emailAddress"].ToString();
                            returnModel.RegisteredMobileNo = dr["registeredMobileNumber"] == DBNull.Value ? null : dr["registeredMobileNumber"].ToString();
                            returnModel.MobileNumber = dr["mobileNumber"] == DBNull.Value ? null : dr["mobileNumber"].ToString();
                            returnModel.CanalPlusPhoneNo = dr["CanalPlusPhoneNo"] == DBNull.Value ? null : dr["CanalPlusPhoneNo"].ToString();
                        }
                        catch(Exception ex)
                        {

                        }
                    }
                    if (!dr.HasRows)
                    {
                        return null;
                    }
                    con.Close();
                     return returnModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bol_CNP_PolicyModel CNP_Get_PolicyAndPromo(bol_CNP_PolicyModel reqModel)
        {
            try
            {
                bol_CNP_PolicyModel resModel = new bol_CNP_PolicyModel();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_Select_PolicyAndPromo", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@planName", reqModel.PlanName==null?"": reqModel.PlanName);
                    cmd.Parameters.AddWithValue("@customerType", reqModel.CustomerType==null ? "" : reqModel.CustomerType);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        resModel.PolicyDescription = dr["PolicyDescription"] == DBNull.Value ? null : dr["PolicyDescription"].ToString();
                        resModel.FreeDays = dr["FreeDays"] == DBNull.Value ? 0 : Convert.ToInt32(dr["FreeDays"].ToString());
                        resModel.CostPerMonth = dr["CostPerMonth"] == DBNull.Value ? 0 : Convert.ToInt32(dr["CostPerMonth"].ToString());
                        int daysToPay = reqModel.subscriptionDays - resModel.FreeDays;
                        int monthToPay = daysToPay / 30;
                        int totalCost = resModel.CostPerMonth * monthToPay;

                        resModel.TotalCost = totalCost;
                        resModel.PromoStartDate = dr["startDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["startDate"].ToString());

                        resModel.PromoEndDate = dr["endDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["endDate"].ToString());

                        resModel.PromoName = dr["PromoPeriodName"] == DBNull.Value ? null : dr["PromoPeriodName"].ToString();

                        resModel.PPid = dr["PPid"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PPid"].ToString());
                    }
                    con.Close();
                    return resModel;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public List<bol_CNP_ServicePlanModel> CNP_FTTH_PlanChagePageLoad()
        {
            List<bol_CNP_ServicePlanModel> csetup = new List<bol_CNP_ServicePlanModel>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM ServiceBasePlan WHERE IsActive=1 AND IsShown=1 AND  SortOrder <> 0 order by SortOrder desc", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_CNP_ServicePlanModel model = new bol_CNP_ServicePlanModel();

                        model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        model.Description = dr["PlanName"] == null ? "" : dr["PlanName"].ToString();
                        csetup.Add(model);
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }

            return csetup;
        }


        public bol_CNP_SubscritpionResponseModel CNP_Subscription(bol_CNP_SubscritpionRequestModel reqModel)
        {
            try
            {
                bol_CNP_SubscritpionResponseModel resModel = new bol_CNP_SubscritpionResponseModel();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_subscription", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", reqModel.ActionParam);
                    cmd.Parameters.AddWithValue("@CNP_id", reqModel.CNP_id);
                    cmd.Parameters.AddWithValue("@subid", reqModel.SubId);
                    cmd.Parameters.AddWithValue("@CustomerAccNo", reqModel.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@Email", reqModel.Email);
                    cmd.Parameters.AddWithValue("@Phone", reqModel.Phone);
                    cmd.Parameters.AddWithValue("@ServicePlan", reqModel.ServicePlan);
                    cmd.Parameters.AddWithValue("@BasePlan", reqModel.BasePlan);
                    cmd.Parameters.AddWithValue("@SubscribedStartDate", reqModel.SubscribedStartDate);
                    cmd.Parameters.AddWithValue("@SubscribedEndDate", reqModel.SubscribedEndDate);
                    cmd.Parameters.AddWithValue("@Type", reqModel.Type);
                    cmd.Parameters.AddWithValue("@Totaldays", reqModel.Totaldays);
                    cmd.Parameters.AddWithValue("@Price", reqModel.Price);
                    cmd.Parameters.AddWithValue("@IsOverride", reqModel.IsOverride);
                    cmd.Parameters.AddWithValue("@OverridePrice", reqModel.OverridePrice);
                    cmd.Parameters.AddWithValue("@IsPromo", reqModel.IsPromo);
                    cmd.Parameters.AddWithValue("@PromoID", reqModel.PromoID);
                    cmd.Parameters.AddWithValue("@Downloaded", reqModel.Downloaded);
                    cmd.Parameters.AddWithValue("@CreatedDate", reqModel.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", reqModel.CreatedBy);
                    cmd.Parameters.AddWithValue("@StartDate", reqModel.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", reqModel.EndDate);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        resModel.RespCode = dr["RespCode"] == DBNull.Value ? null : dr["RespCode"].ToString();
                        resModel.RespDescription = dr["RespCode"] == DBNull.Value ? null : dr["RespCode"].ToString();
                        resModel.SubId = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"].ToString());
                        resModel.CustomerAccNo = dr["CustomerAccNo"] == DBNull.Value ? null : dr["CustomerAccNo"].ToString();
                        resModel.SubscribedStartDate = dr["SubscribedStartDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["SubscribedStartDate"].ToString());
                        resModel.SubscribedEndDate = dr["SubscribedEndDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["SubscribedEndDate"].ToString());
                        resModel.Totaldays = dr["Totaldays"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Totaldays"].ToString());
                        resModel.IsPromo = dr["IsPromo"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsPromo"].ToString());
                        resModel.PromoID = dr["PromoID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PromoID"].ToString());
                        resModel.OverridePrice = dr["OverridePrice"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OverridePrice"].ToString());
                        resModel.CreatedDate = dr["CreatedDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["CreatedDate"].ToString());
                    }
                    con.Close();
                    return resModel;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<bol_CNP_SubscritpionResponseModel> CNP_RetrieveSubscription(string custAcc)
        {
            try
            {
                bol_CNP_SubscritpionRequestModel reqModel = new bol_CNP_SubscritpionRequestModel();
                reqModel.CustomerAccNo = custAcc;
                reqModel.ActionParam = "4";
                reqModel.CreatedDate = DateTime.Now;
                reqModel.StartDate = DateTime.Now;
                reqModel.EndDate = DateTime.Now;
                reqModel.SubscribedEndDate = DateTime.Now;
                reqModel.SubscribedStartDate = DateTime.Now;
                List<bol_CNP_SubscritpionResponseModel> lst_ = new List<bol_CNP_SubscritpionResponseModel>();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CNP_subscription", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", reqModel.ActionParam);
                    cmd.Parameters.AddWithValue("@CNP_id", reqModel.CNP_id);
                    cmd.Parameters.AddWithValue("@subid", reqModel.SubId);
                    cmd.Parameters.AddWithValue("@CustomerAccNo", reqModel.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@ServicePlan", reqModel.ServicePlan);
                    cmd.Parameters.AddWithValue("@BasePlan", reqModel.BasePlan);
                    cmd.Parameters.AddWithValue("@SubscribedStartDate", reqModel.SubscribedStartDate);
                    cmd.Parameters.AddWithValue("@SubscribedEndDate", reqModel.SubscribedEndDate);
                    cmd.Parameters.AddWithValue("@Type", reqModel.Type);
                    cmd.Parameters.AddWithValue("@Totaldays", reqModel.Totaldays);
                    cmd.Parameters.AddWithValue("@Price", reqModel.Price);
                    cmd.Parameters.AddWithValue("@IsOverride", reqModel.IsOverride);
                    cmd.Parameters.AddWithValue("@OverridePrice", reqModel.OverridePrice);
                    cmd.Parameters.AddWithValue("@IsPromo", reqModel.IsPromo);
                    cmd.Parameters.AddWithValue("@PromoID", reqModel.PromoID);
                    cmd.Parameters.AddWithValue("@Downloaded", reqModel.Downloaded);
                    cmd.Parameters.AddWithValue("@CreatedDate", reqModel.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", reqModel.CreatedBy);
                    cmd.Parameters.AddWithValue("@StartDate", reqModel.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", reqModel.EndDate);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_CNP_SubscritpionResponseModel resModel = new bol_CNP_SubscritpionResponseModel();
                        resModel.SubId = dr["Id"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id"].ToString());
                        resModel.CustomerAccNo = dr["CustomerAccNo"] == DBNull.Value ? null : dr["CustomerAccNo"].ToString();
                        resModel.SubscribedStartDate = dr["SubscribedStartDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["SubscribedStartDate"].ToString());
                        resModel.SubscribedEndDate = dr["SubscribedEndDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(dr["SubscribedEndDate"].ToString());
                        resModel.StrSubscribedStartDate = dr["SubscribedStartDate"] == DBNull.Value ? "" : Convert.ToDateTime(dr["SubscribedStartDate"].ToString()).ToString("dd/MM/yyyy hh:mm tt"); //Convert.ToDateTime(dr["SubscribedStartDate"].ToString()).ToString();
                        resModel.StrSubscribedEndDate = dr["SubscribedEndDate"] == DBNull.Value ? "" : Convert.ToDateTime(dr["SubscribedEndDate"].ToString()).ToString("dd/MM/yyyy hh:mm tt"); // Convert.ToDateTime(dr["SubscribedEndDate"].ToString()).ToString();
                        resModel.OverridePrice = dr["OverridePrice"] == DBNull.Value ? 0 : Convert.ToInt32(dr["OverridePrice"].ToString());
                        try
                        {
                            resModel.LastDate = dr["LastDate"] == DBNull.Value ? 0 : Convert.ToInt32(dr["LastDate"].ToString());
                        }
                        catch(Exception ex)
                        {

                        }
                        finally
                        {

                        }
                        lst_.Add(resModel);
                    }
                    con.Close();
                    return lst_;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion Subscribe
    }
}
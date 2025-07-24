using BOL;
using BOL.API;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public class dal_API_BSS_CustomerInfo
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();


        //public ResultMsg InsertCustomerInfo(bol_CustomerInfo bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_CustomerInfo", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccNo);
        //            cmd.Parameters.AddWithValue("@name", bol.Name);
        //            cmd.Parameters.AddWithValue("@title", bol.Title);
        //            cmd.Parameters.AddWithValue("@emailAddress", bol.EmailAddress);
        //            cmd.Parameters.AddWithValue("@registeredMobileNumber", bol.RegisteredMobileNumber);
        //            cmd.Parameters.AddWithValue("@billingArea", bol.BillingArea);
        //            cmd.Parameters.AddWithValue("@customerCategory", bol.CustomerCategory);
        //            cmd.Parameters.AddWithValue("@dateOfBirth", bol.DOB);
        //            cmd.Parameters.AddWithValue("@gender", bol.Gender);
        //            cmd.Parameters.AddWithValue("@billCycle", bol.BillCycle);
        //            cmd.Parameters.AddWithValue("@aadharNumber ", bol.NRC);

        //            cmd.Connection = con;
        //            con.Open();
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

        //public ResultMsg InsertCustomerAccountDetails(bol_CustomerAccDetail bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_CustomerAccountDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustAccNo);
        //            cmd.Parameters.AddWithValue("@name", bol.Name);
        //            cmd.Parameters.AddWithValue("@creationDate", bol.CreationDate);
        //            cmd.Parameters.AddWithValue("@status", bol.Status);
        //            cmd.Parameters.AddWithValue("@emailAddress", bol.EmailAddress);
        //            cmd.Parameters.AddWithValue("@registeredMobileNumber", bol.RegisteredMobileNo);
        //            cmd.Parameters.AddWithValue("@billingArea", bol.BillingArea);
        //            cmd.Parameters.AddWithValue("@customerCategory", bol.CustomerCategory);
        //            cmd.Parameters.AddWithValue("@geoId", bol.GEOld);
        //            cmd.Parameters.AddWithValue("@userName", bol.UserName);
        //            cmd.Parameters.AddWithValue("@partnerAccountNumber", bol.PartnerAccNumber);
        //            cmd.Parameters.AddWithValue("@organizationId", bol.OrganizationID);
        //            cmd.Parameters.AddWithValue("@address", bol.Address);
        //            cmd.Parameters.AddWithValue("@city", bol.City);
        //            cmd.Parameters.AddWithValue("@state", bol.State);
        //            cmd.Parameters.AddWithValue("@country", bol.Country);
        //            cmd.Parameters.AddWithValue("@secretQuestion", bol.SecretQuestion);
        //            cmd.Parameters.AddWithValue("@secretAnswer", bol.SecretAnswer);
        //            cmd.Parameters.AddWithValue("@mobileNumber", bol.MobileNumber);
        //            cmd.Parameters.AddWithValue("@multipleMobileNumber", bol.MultipleMobileNumber);
        //            cmd.Parameters.AddWithValue("@customerAccountNumberId", bol.CustomerAccNumberID);
        //            cmd.Parameters.AddWithValue("@billAddCompanyName", bol.BillAddCompanyName);
        //            cmd.Parameters.AddWithValue("@regNo", bol.RegNo);
        //            cmd.Parameters.AddWithValue("@businessType", bol.BusinessType);
        //            cmd.Parameters.AddWithValue("@Ico", bol.ICO);
        //            cmd.Parameters.AddWithValue("@leadId", bol.LeadID);
        //            cmd.Parameters.AddWithValue("@cafNumber", bol.CAFNumber);
        //            cmd.Parameters.AddWithValue("@cafFormNumber", bol.CAFFormNumber);
        //            cmd.Parameters.AddWithValue("@firstName", bol.FirstName);
        //            cmd.Parameters.AddWithValue("@lastName", bol.LastName);
        //            cmd.Parameters.AddWithValue("@nationality", bol.Nationality);
        //            cmd.Parameters.AddWithValue("@multipleEmailId", bol.MultipleEmailID);
        //            cmd.Parameters.AddWithValue("@connectionType", bol.ConnectionType);
        //            cmd.Parameters.AddWithValue("@actualAmount", bol.ActualAmount);
        //            cmd.Parameters.AddWithValue("@promoId", bol.PromoID);
        //            cmd.Parameters.AddWithValue("@overridenAmount", bol.OverridenAmount);
        //            cmd.Parameters.AddWithValue("@ioNumber", bol.IONumber);
        //            cmd.Connection = con;
        //            con.Open();
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

        //public ResultMsg InsertBillingAccountDetails(bol_BillingAccountDetails bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_BillingAccountDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@billingAccountNo", bol.BillingAccountNo);
        //            cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccountNo);
        //            cmd.Parameters.AddWithValue("@name", bol.Name);
        //            cmd.Parameters.AddWithValue("@creationDate", bol.CreationDate);
        //            cmd.Parameters.AddWithValue("@status", bol.Status);
        //            cmd.Parameters.AddWithValue("@billingCycle", bol.BillingCycle);
        //            cmd.Parameters.AddWithValue("@currency", bol.Currency);
        //            cmd.Parameters.AddWithValue("@billingOnHold", bol.BillingOnHold);
        //            cmd.Parameters.AddWithValue("@creditClass", bol.CreditClass);
        //            cmd.Parameters.AddWithValue("@billDeliveryMode", bol.BillDeliveryMode);
        //            cmd.Parameters.AddWithValue("@dunningStatus", bol.DunningStatus);
        //            cmd.Parameters.AddWithValue("@geoId", bol.GEOID);
        //            cmd.Parameters.AddWithValue("@taxType", bol.TaxType);
        //            cmd.Parameters.AddWithValue("@billingAreaId", bol.BillingAreaID);
        //            cmd.Connection = con;
        //            con.Open();
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

        //public ResultMsg InsertServiceAccountDetails(bol_ServiceAccountDetails bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_ServiceAccountDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@serviceAccountNo", bol.ServiceAccountNo);
        //            cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccNo);
        //            cmd.Parameters.AddWithValue("@name", bol.Name);
        //            cmd.Parameters.AddWithValue("@creationDate", bol.CreationDate);
        //            cmd.Parameters.AddWithValue("@geoId", bol.GEOID);
        //            cmd.Parameters.AddWithValue("@serviceType", bol.ServiceType);
        //            cmd.Connection = con;
        //            con.Open();
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

        //public ResultMsg InsertServiceInstanceDetails(bol_ServiceInstanceDetails bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_ServiceInstanceDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@serviceInstanceNo", bol.ServiceInstanceNo);
        //            cmd.Parameters.AddWithValue("@serviceAccountNo", bol.ServiceAccountNo);
        //            cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccountNo);
        //            cmd.Parameters.AddWithValue("@name", bol.Name);
        //            cmd.Parameters.AddWithValue("@type", bol.Type);
        //            cmd.Parameters.AddWithValue("@status", bol.Status);
        //            cmd.Parameters.AddWithValue("@price", bol.Price);
        //            cmd.Parameters.AddWithValue("@safeCustody", bol.SafeCustody);
        //            cmd.Parameters.AddWithValue("@userId", bol.UserID);
        //            cmd.Parameters.AddWithValue("@customerType", bol.CustomerType);
        //            cmd.Parameters.AddWithValue("@billingStatus", bol.BillingStatus);
        //            cmd.Parameters.AddWithValue("@dunningExcluded", bol.DunningExcluded);
        //            cmd.Parameters.AddWithValue("@currencyId", bol.CurrencyID);
        //            cmd.Parameters.AddWithValue("@leafNode", bol.LeafNode);
        //            cmd.Parameters.AddWithValue("@currencyName", bol.CurrencyName);
        //            cmd.Parameters.AddWithValue("@currencyCode", bol.CurrencyCode);
        //            cmd.Parameters.AddWithValue("@password", bol.Password);
        //            cmd.Parameters.AddWithValue("@promoName", bol.PromoName);
        //            cmd.Parameters.AddWithValue("@promoStartDate", bol.PromoStartDate);
        //            cmd.Parameters.AddWithValue("@promoEndDate", bol.PromoEndDate);
        //            cmd.Parameters.AddWithValue("@expiryDate", bol.ExpiryDate);
        //            cmd.Connection = con;
        //            con.Open();
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

        //public ResultMsg InsertPromotionDetails(bol_PromotionDetails bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_PromotionDetails", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@id", bol.ID);
        //            cmd.Parameters.AddWithValue("@promoId", bol.PromoID);
        //            cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccountNo);
        //            cmd.Parameters.AddWithValue("@name", bol.Name);
        //            cmd.Parameters.AddWithValue("@periodInMonth", bol.PeriodInMonth);
        //            cmd.Parameters.AddWithValue("@promoProductType", bol.PromoProductType);
        //            cmd.Parameters.AddWithValue("@unitType", bol.UnitType);
        //            cmd.Parameters.AddWithValue("@priceUnitType", bol.PriceUnitType);
        //            cmd.Parameters.AddWithValue("@price", bol.Price);
        //            cmd.Parameters.AddWithValue("@currencyType", bol.CurrencyType);
        //            cmd.Parameters.AddWithValue("@fromDate", bol.FromDate);
        //            cmd.Parameters.AddWithValue("@toDate", bol.ToDate);
        //            cmd.Connection = con;
        //            con.Open();
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


        #region Async
        public async Task<ResultMsg> InsertCustomerInfo(bol_CustomerInfo bol)
        {
            int resp_code = 0;

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_CustomerInfo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@name", bol.Name);
                    cmd.Parameters.AddWithValue("@title", bol.Title);
                    cmd.Parameters.AddWithValue("@emailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@registeredMobileNumber", bol.RegisteredMobileNumber);
                    cmd.Parameters.AddWithValue("@billingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@customerCategory", bol.CustomerCategory);
                    cmd.Parameters.AddWithValue("@dateOfBirth", bol.DOB);
                    cmd.Parameters.AddWithValue("@gender", bol.Gender);
                    cmd.Parameters.AddWithValue("@billCycle", bol.BillCycle);
                    cmd.Parameters.AddWithValue("@aadharNumber ", bol.NRC);

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

        public async Task<ResultMsg> InsertCustomerAccountDetails(bol_CustomerAccDetail bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_CustomerAccountDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@name", bol.Name);
                    cmd.Parameters.AddWithValue("@creationDate", bol.CreationDate);
                    cmd.Parameters.AddWithValue("@status", bol.Status);
                    cmd.Parameters.AddWithValue("@emailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@registeredMobileNumber", bol.RegisteredMobileNo);
                    cmd.Parameters.AddWithValue("@billingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@customerCategory", bol.CustomerCategory);
                    cmd.Parameters.AddWithValue("@geoId", bol.GEOld);
                    cmd.Parameters.AddWithValue("@userName", bol.UserName);
                    cmd.Parameters.AddWithValue("@partnerAccountNumber", bol.PartnerAccNumber);
                    cmd.Parameters.AddWithValue("@organizationId", bol.OrganizationID);
                    cmd.Parameters.AddWithValue("@address", bol.Address);
                    cmd.Parameters.AddWithValue("@city", bol.City);
                    cmd.Parameters.AddWithValue("@state", bol.State);
                    cmd.Parameters.AddWithValue("@country", bol.Country);
                    cmd.Parameters.AddWithValue("@secretQuestion", bol.SecretQuestion);
                    cmd.Parameters.AddWithValue("@secretAnswer", bol.SecretAnswer);
                    cmd.Parameters.AddWithValue("@mobileNumber", bol.MobileNumber);
                    cmd.Parameters.AddWithValue("@multipleMobileNumber", bol.MultipleMobileNumber);
                    cmd.Parameters.AddWithValue("@customerAccountNumberId", bol.CustomerAccNumberID);
                    cmd.Parameters.AddWithValue("@billAddCompanyName", bol.BillAddCompanyName);
                    cmd.Parameters.AddWithValue("@regNo", bol.RegNo);
                    cmd.Parameters.AddWithValue("@businessType", bol.BusinessType);
                    cmd.Parameters.AddWithValue("@Ico", bol.ICO);
                    cmd.Parameters.AddWithValue("@leadId", bol.LeadID);
                    cmd.Parameters.AddWithValue("@cafNumber", bol.CAFNumber);
                    cmd.Parameters.AddWithValue("@cafFormNumber", bol.CAFFormNumber);
                    cmd.Parameters.AddWithValue("@firstName", bol.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", bol.LastName);
                    cmd.Parameters.AddWithValue("@nationality", bol.Nationality);
                    cmd.Parameters.AddWithValue("@multipleEmailId", bol.MultipleEmailID);
                    cmd.Parameters.AddWithValue("@connectionType", bol.ConnectionType);
                    cmd.Parameters.AddWithValue("@actualAmount", bol.ActualAmount);
                    cmd.Parameters.AddWithValue("@promoId", bol.PromoID);
                    cmd.Parameters.AddWithValue("@overridenAmount", bol.OverridenAmount);
                    cmd.Parameters.AddWithValue("@ioNumber", bol.IONumber);
                    cmd.Parameters.AddWithValue("@flatHouseNum", bol.flatHouseNum);
                    cmd.Parameters.AddWithValue("@buildingSocietyName", bol.buildingSocietyName);
                    cmd.Parameters.AddWithValue("@landmark", bol.landmark);

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

        public async Task<ResultMsg> InsertBillingAccountDetails(bol_BillingAccountDetails bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_BillingAccountDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@billingAccountNo", bol.BillingAccountNo);
                    cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@name", bol.Name);
                    cmd.Parameters.AddWithValue("@creationDate", bol.CreationDate);
                    cmd.Parameters.AddWithValue("@status", bol.Status);
                    cmd.Parameters.AddWithValue("@billingCycle", bol.BillingCycle);
                    cmd.Parameters.AddWithValue("@currency", bol.Currency);
                    cmd.Parameters.AddWithValue("@billingOnHold", bol.BillingOnHold);
                    cmd.Parameters.AddWithValue("@creditClass", bol.CreditClass);
                    cmd.Parameters.AddWithValue("@billDeliveryMode", bol.BillDeliveryMode);
                    cmd.Parameters.AddWithValue("@dunningStatus", bol.DunningStatus);
                    cmd.Parameters.AddWithValue("@geoId", bol.GEOID);
                    cmd.Parameters.AddWithValue("@taxType", bol.TaxType);
                    cmd.Parameters.AddWithValue("@billingAreaId", bol.BillingAreaID);
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

        public async Task<ResultMsg> InsertServiceAccountDetails(bol_ServiceAccountDetails bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_ServiceAccountDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@serviceAccountNo", bol.ServiceAccountNo);
                    cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccNo);
                    cmd.Parameters.AddWithValue("@name", bol.Name);
                    cmd.Parameters.AddWithValue("@creationDate", bol.CreationDate);
                    cmd.Parameters.AddWithValue("@geoId", bol.GEOID);
                    cmd.Parameters.AddWithValue("@serviceType", bol.ServiceType);
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

        public async Task<ResultMsg> InsertServiceInstanceDetails(bol_ServiceInstanceDetails bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_ServiceInstanceDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@serviceInstanceNo", bol.ServiceInstanceNo);
                    cmd.Parameters.AddWithValue("@serviceAccountNo", bol.ServiceAccountNo);
                    cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@name", bol.Name);
                    cmd.Parameters.AddWithValue("@type", bol.Type);
                    cmd.Parameters.AddWithValue("@status", bol.Status);
                    cmd.Parameters.AddWithValue("@price", bol.Price);
                    cmd.Parameters.AddWithValue("@safeCustody", bol.SafeCustody);
                    cmd.Parameters.AddWithValue("@userId", bol.UserID);
                    cmd.Parameters.AddWithValue("@customerType", bol.CustomerType);
                    cmd.Parameters.AddWithValue("@billingStatus", bol.BillingStatus);
                    cmd.Parameters.AddWithValue("@dunningExcluded", bol.DunningExcluded);
                    cmd.Parameters.AddWithValue("@currencyId", bol.CurrencyID);
                    cmd.Parameters.AddWithValue("@leafNode", bol.LeafNode);
                    cmd.Parameters.AddWithValue("@currencyName", bol.CurrencyName);
                    cmd.Parameters.AddWithValue("@currencyCode", bol.CurrencyCode);
                    cmd.Parameters.AddWithValue("@password", bol.Password);
                    cmd.Parameters.AddWithValue("@promoName", bol.PromoName);
                    cmd.Parameters.AddWithValue("@promoStartDate", bol.PromoStartDate);
                    cmd.Parameters.AddWithValue("@promoEndDate", bol.PromoEndDate);
                    cmd.Parameters.AddWithValue("@expiryDate", bol.ExpiryDate);
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

        public async Task<ResultMsg> InsertPromotionDetails(bol_PromotionDetails bol)
        {
            int resp_code = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_PromotionDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@id", bol.ID);
                    cmd.Parameters.AddWithValue("@promoId", bol.PromoID);
                    cmd.Parameters.AddWithValue("@customerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@name", bol.Name);
                    cmd.Parameters.AddWithValue("@periodInMonth", bol.PeriodInMonth);
                    cmd.Parameters.AddWithValue("@promoProductType", bol.PromoProductType);
                    cmd.Parameters.AddWithValue("@unitType", bol.UnitType);
                    cmd.Parameters.AddWithValue("@priceUnitType", bol.PriceUnitType);
                    cmd.Parameters.AddWithValue("@price", bol.Price);
                    cmd.Parameters.AddWithValue("@currencyType", bol.CurrencyType);
                    cmd.Parameters.AddWithValue("@fromDate", bol.FromDate);
                    cmd.Parameters.AddWithValue("@toDate", bol.ToDate);
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

        public async Task<ResultMsg> InsertDepositDetails(List<bol_DepositDetails> bol)
        {
            int resp_code = 0;
            try
            {
                DataTable dt_c = new DataTable();
                if (bol.Count() > 0)
                {

                    dt_c = JsonConvert.DeserializeObject<DataTable>(JsonConvert.SerializeObject(bol).ToString());

                    using (SqlConnection con = new SqlConnection(conn_str))
                    {
                        SqlCommand cmd = new SqlCommand("sp_BSS_DepositDetails", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 300; //seconds = 5mins
                        cmd.Parameters.AddWithValue("@ActionParam", 1);
                        cmd.Parameters.AddWithValue("@udt_DepositDetails", dt_c);
                        cmd.Connection = con;
                        await con.OpenAsync();
                        resp_code = (int)await cmd.ExecuteScalarAsync();
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };

        }
        #endregion

        public IEnumerable<bol_GetServiceInstanceInfoResModel> dal_GetServiceInstanceInfo(bol_GetServiceInstanceInfo bol)
        {
            List<bol_GetServiceInstanceInfoResModel> gsis = new List<bol_GetServiceInstanceInfoResModel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNos", bol.CustAccNos);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_GetServiceInstanceInfoResModel gsi = new bol_GetServiceInstanceInfoResModel();
                    gsi.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    gsi.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    gsi.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                    
                    gsi.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    gsi.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    gsis.Add(gsi);
                }
            }
            return gsis;
        }


    }
}

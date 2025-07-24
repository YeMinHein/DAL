using BOL;
using BOL.General;
using BOL.WDM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WDM
{
    public class dal_WDM_BS_SAForm
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        SqlConnection con;
        public dal_WDM_BS_SAForm() { }

        public ResultMsg UpdateBusinessSAForm(bol_WDM_BS_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@CustomerName", bol.Name);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@Email", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@Address", bol.InstallationAddress);
                    cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                    cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                    cmd.Parameters.AddWithValue("@SolvedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@StaffRemark", "");
                    cmd.Parameters.AddWithValue("@IsSolved", false);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyRegistrationNo", bol.CompanyRegistrationNo);
                    cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg GetBusinessSAFormCount(bol_WDM_BS_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                    cmd.Parameters.AddWithValue("@PromoName", bol.PromoName);
                    cmd.Parameters.AddWithValue("@Product", bol.Product);
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@Reason", bol.Reason);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@IncludeCustAccNo", bol.IncludeCustAccNo);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
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

        public IEnumerable<bol_WDM_BS_SAForm> GetBusinessSAList(bol_WDM_BS_SAForm bol)
        {
            List<bol_WDM_BS_SAForm> saforms = new List<bol_WDM_BS_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                cmd.Parameters.AddWithValue("@PromoName", bol.PromoName);
                cmd.Parameters.AddWithValue("@Product", bol.Product);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                cmd.Parameters.AddWithValue("@Status", bol.Status);
                cmd.Parameters.AddWithValue("@Reason", bol.Reason);
                cmd.Parameters.AddWithValue("@Source", bol.Source);
                cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@IncludeCustAccNo", bol.IncludeCustAccNo);
                cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                cmd.CommandTimeout = 120;
                con.Open();
                try
                { 
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        bol_WDM_BS_SAForm saform = new bol_WDM_BS_SAForm();

                        saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                        saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                        saform.NRCPassport = dr["NRC/Passport"] == null ? null : dr["NRC/Passport"].ToString();
                        saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                        saform.VerifyMobileNo = dr["VerifyMobileNo"] == null ? null : dr["VerifyMobileNo"].ToString();
                        saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                        saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                        saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                        saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
                        saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                        saform.NoofBranch = dr["No_of_Branch"] == DBNull.Value ? 0 : int.Parse(dr["No_of_Branch"].ToString());
                        saform.CurrentInternetPlan = dr["CurrentInternetPlan"] == null ? null : dr["CurrentInternetPlan"].ToString();
                        saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                        saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                        saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                        saform.BuildingTypeID = dr["BuildingTypeID"] == DBNull.Value ? 0 : int.Parse(dr["BuildingTypeID"].ToString());
                        saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
                        saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
                        saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                        saform.Product = dr["Product"] == null ? null : dr["Product"].ToString();
                        saform.ProductPlan = dr["ProductPlan"] == null ? null : dr["ProductPlan"].ToString();
                        saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
                        saform.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                        saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                        saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                        saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
                        saform.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
                        saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
                        saform.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
                        if (dr["CreationDate"].ToString() != "")
                        {
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                        };
                        saform.City = dr["City"] == null ? null : dr["City"].ToString();
                        saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                        saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                        saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                        saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                        saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                        saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                        saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                        saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                        saform.LastGroupID = dr["LastGroupID"] == null ? 0 : Convert.ToInt32(dr["LastGroupID"].ToString());
                        saform.PreviousStatusID = dr["PreviousStatusID"] == null ? 0 : Convert.ToInt32(dr["PreviousStatusID"].ToString());
                        saform.InvoiceNo = dr["InvoiceNo"] == null ? null : dr["InvoiceNo"].ToString();
                        saform.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                        saform.IsAgree = dr["IsAgree"] == null ? false : Convert.ToBoolean(dr["IsAgree"].ToString());
                        if (dr["AgreementDate"].ToString() != "")
                            {
                                saform.FormattedAgreementDate = dr["FormattedAgreementDate"] == null ? null : dr["FormattedAgreementDate"].ToString();

                            };
                            saform.SendReceipt = dr["SendReceipt"] == DBNull.Value ? false : bool.Parse(dr["SendReceipt"].ToString());
                            if (dr["SendReceiptDate"].ToString() != "")
                            {
                                saform.FormattedSendReceiptDate = dr["FormattedSendReceiptDate"] == null ? null : dr["FormattedSendReceiptDate"].ToString();

                            }; saform.PaymentDocNo = dr["PaymentDocNo"] == null ? null : dr["PaymentDocNo"].ToString();

                            //saform.SendTermsAndConditions = dr["SendTermsAndConditions"] == null ? false : Convert.ToBoolean(dr["SendTermsAndConditions"].ToString());
                            //saform.SendReceipt = dr["SendReceipt"] == null ? false : Convert.ToBoolean(dr["SendReceipt"].ToString());
                            //saform.PaymentDocNo = dr["PaymentDocNo"] == null ? null : dr["PaymentDocNo"].ToString();

                            saforms.Add(saform);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message.ToString();
                        Console.WriteLine(s);
                    }
                }
                }
                catch(Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_BS_SAForm> GetBusinessSAData(bol_WDM_BS_SAForm bol)
        {
            List<bol_WDM_BS_SAForm> saforms = new List<bol_WDM_BS_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_BS_SAForm saform = new bol_WDM_BS_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    saform.VerifyMobileNo = dr["VerifyMobileNo"] == null ? null : dr["VerifyMobileNo"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    saform.CompanyRegistrationNo = dr["CompanyRegNo"] == null ? null : dr["CompanyRegNo"].ToString();
                    saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
                    saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                    saform.NoofBranch = dr["NoofBranch"] == DBNull.Value ? 0 : int.Parse(dr["NoofBranch"].ToString());
                    saform.CurrentInternetPlan = dr["CurrentInternetPlan"] == null ? null : dr["CurrentInternetPlan"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                    saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                    saform.BuildingTypeID = dr["BuildingTypeID"] == DBNull.Value ? 0 : int.Parse(dr["BuildingTypeID"].ToString());
                    saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                    saform.Product = dr["Product"] == null ? null : dr["Product"].ToString();
                    saform.ProductPlan = dr["ProductPlan"] == null ? null : dr["ProductPlan"].ToString();
                    saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
                    saform.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                    saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                    saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                    saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
                    saform.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
                    saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
                   // saform.SendReceipt = dr["SendReceipt"] == DBNull.Value ? false : bool.Parse(dr["SendReceipt"].ToString());
                    saform.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
                    if (dr["CreationDate"].ToString() != "")
                    {
                        saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    };
                    saform.City = dr["City"] == null ? null : dr["City"].ToString();
                    saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                    if (bol.ActionParam == 4)
                    {
                        saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                        saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                        saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                        saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        // saform.LastChangeStatus_Setting_ID = dr["LastChangeStatus_Setting_ID"] == null ? 0 : Convert.ToInt32(dr["LastChangeStatus_Setting_ID"].ToString());
                        saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                        saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                        saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                    }

                    saforms.Add(saform);
                }

            }
            return saforms;
        }

    
        
        #region BuildingType       
        public IEnumerable<bol_BuildingType> BuildingTypeList(bol_BuildingType bol)
        {
            List<bol_BuildingType> saforms = new List<bol_BuildingType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BuildingType saform = new bol_BuildingType();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());

                    saform.BuildingName = dr["BuildingName"] == null ? null : dr["BuildingName"].ToString();

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        #endregion

        public IQueryable<bol_FTTH_StatusModel> GetFTTH_StatusSetting()
        {
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            var FTTH_Change_Status_Settinglist = new List<bol_FTTH_StatusModel>();
            try
            {
                con.Open();

                var list = con.Query<bol_FTTH_StatusModel>("SELECT  * FROM dbo.FTTH_Status WHERE IsActive=1 ORDER BY SortOrder ASC").ToList().AsQueryable();
                return list;

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                con.Close();
            }
            return FTTH_Change_Status_Settinglist.AsQueryable();

        }

      #region SA_Sales_Satus
        public IQueryable<bol_SA_FTTH_StatusModel> GetFTTHSA_Status(bol_SA_FTTH_StatusModel bol)
        {
            List<bol_SA_FTTH_StatusModel> csetup = new List<bol_SA_FTTH_StatusModel>();
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);             
                ObjParm.Add("@LoggedBy",bol.LoggedBy );
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                con.Open();
                var list = con.Query<bol_SA_FTTH_StatusModel>("sp_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
                return list;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return csetup.AsQueryable();
        }
        public ResultMsg FTTHSA_StatusInsert(bol_SA_FTTH_StatusModel bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = bol.ID > 0 ? "Succefully updated!" : bol.ID == 0 ? "Succefully saved!" : "Succefully deleted" };
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }
        }
        #endregion

        #region[Business]
        public IEnumerable<bol_WDM_BusinessLogActivity> GetBusinessLogActivityData(bol_WDM_BusinessLogActivity bol)
        {
            List<bol_WDM_BusinessLogActivity> saforms = new List<bol_WDM_BusinessLogActivity>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_LogActivity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@BS_ID", bol.BS_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_BusinessLogActivity saform = new bol_WDM_BusinessLogActivity();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.BS_ID = dr["BS_ID"] == DBNull.Value ? 0 : int.Parse(dr["BS_ID"].ToString());
                    saform.Type = dr["Type"] == null ? "" : dr["Type"].ToString();
                    saform.Remark = dr["Remark"] == null ? "" : dr["Remark"].ToString();
                    saform.LoggedBy = dr["LoggedBy"] == null ? "" : dr["LoggedBy"].ToString();
                    saform.LoggedDate = dr["LoggedDate"] == null ? "" : dr["LoggedDate"].ToString();
                    saform.Datetime = dr["Datetime"] == null ? "" : dr["Datetime"].ToString();

                    if (dr["Datetime"].ToString() != "")
                    {
                        saform.FormattedDatetime = dr["FormattedDatetime"].ToString() == null ? DateTime.Now.ToString("dd/MM/yyyy") : dr["FormattedDatetime"].ToString();
                    };
                    saforms.Add(saform);
                }

            }
            return saforms;
        }
        public ResultMsg UpdateBusinessLogActivityForm(bol_WDM_BusinessLogActivity bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LogActivity", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@BS_ID", bol.BS_ID);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@Datetime", bol.Datetime);
                    cmd.Parameters.AddWithValue("@LoggedBy", bol.LoggedBy);
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
        public IEnumerable<bol_BS_Product> GetBusinessSolutionProductList(bol_BS_Product bol)
        {
            List<bol_BS_Product> csetups = new List<bol_BS_Product>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Product csetup = new bol_BS_Product();
                        csetup.Product = dr["Product"] == null ? null : dr["Product"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }
        public IEnumerable<bol_BS_Plan> GetBusinessSolutionPlanList(bol_BS_Plan bol)
        {
            List<bol_BS_Plan> csetups = new List<bol_BS_Plan>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Product", bol.Product);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Plan csetup = new bol_BS_Plan();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.Plan = dr["Plan"] == null ? null : dr["Plan"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }
        public IEnumerable<bol_BS_Status> GetBusinessStatusList(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Status csetup = new bol_BS_Status();
                        csetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }
        public IEnumerable<bol_BS_Reason> GetBusinessReasonList(bol_BS_Reason bol)
        {
            List<bol_BS_Reason> csetups = new List<bol_BS_Reason>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Reason csetup = new bol_BS_Reason();
                       // csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.Reason = dr["Reason"] == null ? null : dr["Reason"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }
        public IEnumerable<bol_BS_Owner> GetBusinessOwnerList(bol_BS_Owner bol)
        {
            List<bol_BS_Owner> csetups = new List<bol_BS_Owner>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Owner csetup = new bol_BS_Owner();
                        csetup.Value = dr["Value"] == null ? null : dr["Value"].ToString();
                        csetup.Owner = dr["userName"] == null ? null : dr["userName"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }

        public IEnumerable<bol_BS_Status> GetBusinessStatusListByPreviousGroupID(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@PreviousGroupID", bol.PreviousGroupID);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Status csetup = new bol_BS_Status();
                        csetup.ID = dr["GroupID"] == null ? 0 : Convert.ToInt32(dr["GroupID"].ToString());
                        csetup.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                        csetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }
        public IEnumerable<bol_BS_Reason> GetBusinessReasonListByGroupID(bol_BS_Reason bol)
        {
            List<bol_BS_Reason> csetups = new List<bol_BS_Reason>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                    cmd.Parameters.AddWithValue("@PreviousGroupID", bol.PreviousGroupID);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Reason csetup = new bol_BS_Reason();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.Reason = dr["Reason"] == null ? null : dr["Reason"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }

        public bol_BS_UserRolePermission GetByUserRolePermission(bol_BS_UserRolePermission bol)
        {
            bol_BS_UserRolePermission csetup = new bol_BS_UserRolePermission();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.IsDepartmentAdmin = dr["IsDepartmentAdmin"] == null ? false : Convert.ToBoolean(dr["IsDepartmentAdmin"].ToString());
                    csetup.IsSuperAdmin = dr["IsSuperAdmin"] == null ? false : Convert.ToBoolean(dr["IsSuperAdmin"].ToString());
                }
            }
            return csetup;
        }

        public IEnumerable<bol_BS_Status> GetBS_StatusID(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                    cmd.Parameters.AddWithValue("@PreviousGroupID", bol.PreviousGroupID);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Status csetup = new bol_BS_Status();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetups.Add(csetup);
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
            return csetups;
        }
        public IEnumerable<bol_BS_Status> GetBS_LastStatusID(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Status csetup = new bol_BS_Status();
                        csetup.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        csetup.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                        csetup.Plan = dr["PlanName"] == null ? "" : dr["PlanName"].ToString();
                        csetup.CustomerAccountNo = dr["CustomerAccountNo"] == null ? "" : dr["CustomerAccountNo"].ToString();
                        csetup.TotalCharges = dr["TotalCharges"] == null ? "" : dr["TotalCharges"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }

        public ResultMsg FTTH_BS_StatusInsert(bol_BS_StatusModel bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@BS_ID", bol.BS_ID == null ? 0 : bol.BS_ID);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_BS_ChangeStatus", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = bol.ID > 0 ? "Succefully updated!" : bol.ID == 0 ? "Succefully saved!" : "Succefully deleted" };
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }
        }


        public ResultMsg FTTH_BS_SendReceiptInsert(bol_BS_SendReceiptModel bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.BS_ID == null ? 0 : bol.BS_ID);
                ObjParm.Add("@PaymentDocNo", bol.PaymentDocumentNo == null ? "" : bol.PaymentDocumentNo);
                ObjParm.Add("@SendReceipt", bol.SendReceipt == null ? 0 : bol.SendReceipt);
                ObjParm.Add("@OrderCode", bol.OrderCode == null ? "" : bol.OrderCode);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_WDM_BS_LeadCollection", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = bol.BS_ID > 0 ? "Succefully updated!" : bol.BS_ID == 0 ? "Succefully saved!" : "Succefully deleted" };
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }
        }

        public ResultMsg BSInsert(bol_WDM_BS_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@VerifyMobileNo", bol.VerifyMobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyRegNo", bol.CompanyRegistrationNo);
                    cmd.Parameters.AddWithValue("@CompanySize", bol.CompanySize);
                    cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    cmd.Parameters.AddWithValue("@NoofBranch", bol.NoofBranch);
                    cmd.Parameters.AddWithValue("@CurrentInternetPlan", bol.CurrentInternetPlan);
                    cmd.Parameters.AddWithValue("@InstallationAddress", bol.InstallationAddress);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@BuildingTypeID", bol.BuildingTypeID);
                    cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@Product", bol.Product);
                    cmd.Parameters.AddWithValue("@ProductPlan", bol.ProductPlan);
                    cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                    cmd.Parameters.AddWithValue("@TotalAmount", bol.TotalAmount);
                    cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                    cmd.Parameters.AddWithValue("@OrderCode", bol.OrderCode);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@ContactPerson", bol.Name);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@ContactMobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@ContactEmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@ContactCreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@BranchAddress", bol.InstallationAddress);
                    cmd.Parameters.AddWithValue("@BranchMobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@BranchContactPerson", bol.Name);
                    cmd.Parameters.AddWithValue("@BranchServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
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

        public ResultMsg BSUpdate(bol_WDM_BS_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@VerifyMobileNo", bol.VerifyMobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyRegNo", bol.CompanyRegistrationNo);
                    cmd.Parameters.AddWithValue("@CompanySize", bol.CompanySize);
                    cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    cmd.Parameters.AddWithValue("@NoofBranch", bol.NoofBranch);
                    cmd.Parameters.AddWithValue("@CurrentInternetPlan", bol.CurrentInternetPlan);
                    cmd.Parameters.AddWithValue("@InstallationAddress", bol.InstallationAddress);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@BuildingTypeID", bol.BuildingTypeID);
                    cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@Product", bol.Product);
                    cmd.Parameters.AddWithValue("@ProductPlan", bol.ProductPlan);
                    cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                    cmd.Parameters.AddWithValue("@TotalAmount", bol.TotalAmount);
                    cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                    cmd.Parameters.AddWithValue("@OrderCode", bol.OrderCode);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@ContactPerson", bol.Name);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@ContactMobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@ContactEmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@ContactCreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@BranchAddress", bol.InstallationAddress);
                    cmd.Parameters.AddWithValue("@BranchMobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@BranchContactPerson", bol.Name);
                    cmd.Parameters.AddWithValue("@BranchServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
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
        public ResultMsg BSContactUpdate(bol_WDM_BSContact bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                     SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@ContactPerson", bol.ContactPerson);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@IsPrimary", bol.IsPrimary);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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
        public ResultMsg BSBranchUpdate(bol_WDM_BSBranch bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@ContactPerson", bol.ContactPerson);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@IsMain", bol.IsMain);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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

        public IEnumerable<bol_BS_Owner> GetBusinessTownshipByCityID(bol_BS_Owner bol)
        {
            List<bol_BS_Owner> csetups = new List<bol_BS_Owner>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Owner csetup = new bol_BS_Owner();
                        csetup.Owner = dr["userName"] == null ? null : dr["userName"].ToString();
                        csetups.Add(csetup);
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
            return csetups;
        }


        public IEnumerable<bol_WDM_BS_SAForm> GetBusinessSAByID(int ID)
        {
            List<bol_WDM_BS_SAForm> saforms = new List<bol_WDM_BS_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 10);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BS_SAForm saform = new bol_WDM_BS_SAForm();

                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                            saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                            saform.NRCPassport = dr["NRC/Passport"] == null ? null : dr["NRC/Passport"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.VerifyMobileNo = dr["VerifyMobileNo"] == null ? null : dr["VerifyMobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                            saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                            saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                            saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
                            saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                            saform.NoofBranch = dr["No_of_Branch"] == DBNull.Value ? 0 : int.Parse(dr["No_of_Branch"].ToString());
                            saform.CurrentInternetPlan = dr["CurrentInternetPlan"] == null ? null : dr["CurrentInternetPlan"].ToString();
                            saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                            saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                            saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                            saform.BuildingTypeID = dr["BuildingTypeID"] == DBNull.Value ? 0 : int.Parse(dr["BuildingTypeID"].ToString());
                            saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
                            saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
                            saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                            saform.Product = dr["Product"] == null ? null : dr["Product"].ToString();
                            saform.ProductPlan = dr["ProductPlan"] == null ? null : dr["ProductPlan"].ToString();
                            saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
                            saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                            saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
                            saform.SurchargePercentage = dr["TaxPercentage"] == null ? 0 : Convert.ToDecimal(dr["TaxPercentage"].ToString());
                            saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDecimal(dr["TaxAmount"].ToString());
                            saform.PlanAmountwithPromo = dr["Amount"] == null ? 0 : Convert.ToDecimal(dr["Amount"].ToString());
                            saform.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                            saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                            saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                            saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
                            saform.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
                            saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
                            //saform.SendReceipt = dr["SendReceipt"] == DBNull.Value ? false : bool.Parse(dr["SendReceipt"].ToString());
                            saform.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
                            if (dr["CreationDate"].ToString() != "")
                            {
                                saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                            };
                            saform.City = dr["City"] == null ? null : dr["City"].ToString();
                            saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                            saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                            saform.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                            saform.InvoiceNo = dr["InvoiceNo"] == null ? null : dr["InvoiceNo"].ToString();
                            saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                            saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                            saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                            saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                            saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                            saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                            saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                            saform.LastGroupID = dr["LastGroupID"] == null ? 0 : Convert.ToInt32(dr["LastGroupID"].ToString());
                            saform.PreviousStatusID = dr["PreviousStatusID"] == null ? 0 : Convert.ToInt32(dr["PreviousStatusID"].ToString());
                            saform.InvoiceNo = dr["InvoiceNo"] == null ? null : dr["InvoiceNo"].ToString();
                            saform.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                            saform.IsAgree = dr["IsAgree"] == null ? false : Convert.ToBoolean(dr["IsAgree"].ToString());
                            if (dr["AgreementDate"].ToString() != "")
                            {
                                saform.FormattedAgreementDate = dr["FormattedAgreementDate"] == null ? null : dr["FormattedAgreementDate"].ToString();

                            };
                            saform.PaymentDocNo = dr["PaymentDocNo"] == null ? null : dr["PaymentDocNo"].ToString();
                            saform.SendReceipt = dr["SendReceipt"] == null ? false : Convert.ToBoolean(dr["SendReceipt"].ToString());
                            if (dr["SendReceiptDate"].ToString() != "")
                            {
                                saform.FormattedSendReceiptDate = dr["FormattedSendReceiptDate"] == null ? null : dr["FormattedSendReceiptDate"].ToString();

                            };
                            //saform.SendTermsAndConditions = dr["SendTermsAndConditions"] == null ? false : Convert.ToBoolean(dr["SendTermsAndConditions"].ToString());
                            //saform.SendReceipt = dr["SendReceipt"] == null ? false : Convert.ToBoolean(dr["SendReceipt"].ToString());
                            //saform.PaymentDocNo = dr["PaymentDocNo"] == null ? null : dr["PaymentDocNo"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_BSContact> GetBusinessContactByID(int ID)
        {
            List<bol_WDM_BSContact> saforms = new List<bol_WDM_BSContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 15);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BSContact saform = new bol_WDM_BSContact();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.BS_ID = dr["BS_ID"] == DBNull.Value ? 0 : int.Parse(dr["BS_ID"].ToString());
                            saform.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                            saform.ContactPerson = dr["ContactPerson"] == null ? null : dr["ContactPerson"].ToString();
                            saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                            saform.IsPrimary = dr["IsPrimary"] == null ? false : Convert.ToBoolean(dr["IsPrimary"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_BSBranch> GetBusinessBranchByID(int ID)
        {
            List<bol_WDM_BSBranch> saforms = new List<bol_WDM_BSBranch>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 16);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BSBranch saform = new bol_WDM_BSBranch();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.BS_ID = dr["BS_ID"] == DBNull.Value ? 0 : int.Parse(dr["BS_ID"].ToString());
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.ContactPerson = dr["ContactPerson"] == null ? null : dr["ContactPerson"].ToString();
                            saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                            saform.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                            saform.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                            saform.IsMain = dr["IsMain"] == null ? false : Convert.ToBoolean(dr["IsMain"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_BSContact> GetBSContactList(int ID)
        {
            List<bol_WDM_BSContact> saforms = new List<bol_WDM_BSContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 11);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BSContact saform = new bol_WDM_BSContact();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.BS_ID = dr["BS_ID"] == DBNull.Value ? 0 : int.Parse(dr["BS_ID"].ToString());
                            saform.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                            saform.ContactPerson = dr["ContactPerson"] == null ? null : dr["ContactPerson"].ToString();
                            saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                            saform.IsPrimary = dr["IsPrimary"] == null ? false : Convert.ToBoolean(dr["IsPrimary"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_BusinessLogActivity> GetBSLogActivityList(int ID)
        {
            List<bol_WDM_BusinessLogActivity> saforms = new List<bol_WDM_BusinessLogActivity>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 12);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BusinessLogActivity saform = new bol_WDM_BusinessLogActivity();
                             saform.BS_ID = dr["BS_ID"] == DBNull.Value ? 0 : int.Parse(dr["BS_ID"].ToString());
                            saform.Icon = dr["Icon"] == null ? null : dr["Icon"].ToString();
                            saform.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                            saform.header = dr["header"] == null ? null : dr["header"].ToString();
                            saform.Remark = dr["Remark"].ToString();
                            saform.LoggedDate = dr["LoggedDate"] == null ? null : dr["LoggedDate"].ToString();
                            //saform.FormattedDatetime = dr["FormattedDatetime"] == null ? null : dr["FormattedDatetime"].ToString();
                            saform.FormattedLoggedDate = dr["FormattedLoggedDate"] == null ? null : dr["FormattedLoggedDate"].ToString();
                            saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                            saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                            saform.datedifference = dr["datedifference"] == null ? null : dr["datedifference"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_BSBranch> GetBSBranchList(int ID)
        {
            List<bol_WDM_BSBranch> saforms = new List<bol_WDM_BSBranch>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 13);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BSBranch saform = new bol_WDM_BSBranch();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.BS_ID = dr["BS_ID"] == DBNull.Value ? 0 : int.Parse(dr["BS_ID"].ToString());
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.ContactPerson = dr["ContactPerson"] == null ? null : dr["ContactPerson"].ToString();
                            saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                            saform.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                            saform.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                            saform.IsMain = dr["IsMain"] == null ? false : Convert.ToBoolean(dr["IsMain"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }

        #endregion

        public ResultMsg BSInvoiceNoUpdate(int ID)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 20);
                    cmd.Parameters.AddWithValue("@ID", ID);
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

        public IEnumerable<bol_WDM_BS_SAForm> GetBSTotalDuration(int ID)
        {
            List<bol_WDM_BS_SAForm> saforms = new List<bol_WDM_BS_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 22);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_WDM_BS_SAForm saform = new bol_WDM_BS_SAForm();
                            saform.Duration = dr["Duration"] == null ? null : dr["Duration"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public ResultMsg Delete_BSLeadCollection(bol_BS_Delete bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DeletedBy", bol.DeletedBy);
                    cmd.Parameters.AddWithValue("@DeletedRemark", bol.DeletedRemark);
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

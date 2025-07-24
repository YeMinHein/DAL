using BOL;
using BOL.General;
using BOL.PROMO;
using BOL.WDM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WDM
{
    public class dal_WDM_SAForm
    {
        //string conn_str = dal_ConfigManager.GTG;
        //ResultMsg result = new ResultMsg();

        //public dal_WDM_SAForm() {
        //}

        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_WDM_SAForm()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        //public IEnumerable<bol_WDM_SAForm> GetList(bol_WDM_SAForm bol)
        //{
        //    List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

        //    using (SqlConnection con = new SqlConnection(conn_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
        //        cmd.Parameters.AddWithValue("@City", bol.City);
        //        cmd.Parameters.AddWithValue("@BuildingType", bol.BuildingName);
        //        cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
        //        cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
        //        cmd.Parameters.AddWithValue("@EndDate", bol.EndDate); 
        //        cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
        //        cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
        //        cmd.Parameters.AddWithValue("@PageTakeRows", 10);
        //        if(bol.ActionParam==1)
        //        {
        //            cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
        //            cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
        //            cmd.Parameters.AddWithValue("@Status", bol.Status);
        //            cmd.Parameters.AddWithValue("@SuspendID", bol.SuspendID);
        //        }
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        while (dr.Read())
        //        {
        //            bol_WDM_SAForm saform = new bol_WDM_SAForm();
        //            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
        //            saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
        //            saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
        //            saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
        //            saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
        //            saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
        //            saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
        //            saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
        //            saform.IsCompany = dr["IsCompany"] == DBNull.Value ? false : bool.Parse(dr["IsCompany"].ToString());
        //            saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
        //            saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
        //            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
        //            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
        //            saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
        //            saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
        //            saform.ReferralCode = dr["ReferralCode"] == null ? null : dr["ReferralCode"].ToString();
        //            saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
        //            saform.isSentSMS = dr["isSentSMS"] == DBNull.Value ? false : bool.Parse(dr["isSentSMS"].ToString());
        //            saform.ServiceTypeID = dr["ServiceTypeID"] == DBNull.Value ? 0 : int.Parse(dr["ServiceTypeID"].ToString());
        //            saform.AddOnID = dr["AddOnID"] == DBNull.Value ? 0 : int.Parse(dr["AddOnID"].ToString());
        //            saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
        //            saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
        //            saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
        //            saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
        //            saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"]);
        //            saform.OrderCode = dr["OrderCode"] == null ? "" : Convert.ToString(dr["OrderCode"]);
        //            if (dr["IsSolved"].ToString() != "")
        //            {
        //                saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
        //            };
        //            if (dr["SolvedDate"].ToString() != "")
        //            {
        //                saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
        //            };
        //            if (dr["CreationDate"].ToString() != "")
        //            {
        //                saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
        //            };
        //            saform.SolvedBy = dr["SolvedBy"] == null ? null : dr["SolvedBy"].ToString();
        //            saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

        //            saform.City = dr["City"] == null ? null : dr["City"].ToString();
        //            saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
        //            saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();

        //            if (bol.ActionParam == 1)
        //            {
        //                saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
        //                saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
        //                saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
        //                saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
        //               // saform.LastChangeStatus_Setting_ID = dr["LastChangeStatus_Setting_ID"] == null ? 0 : Convert.ToInt32(dr["LastChangeStatus_Setting_ID"].ToString());
        //                saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
        //                saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
        //                saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
        //            }

        //            saforms.Add(saform);
        //        }
        //    }
        //    return saforms;
        //}

        public async Task<IQueryable<bol_WDM_SAForm>> GetList(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> csetups = new List<bol_WDM_SAForm>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                ObjParm.Add("@PageSkipRows", bol.PageIndex);
                ObjParm.Add("@PageTakeRows", 10);
                if (bol.ActionParam == 1)
                {
                    ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                    ObjParm.Add("@SolvedBy", bol.SolvedBy);
                    ObjParm.Add("@Status", bol.Status);
                    ObjParm.Add("@SuspendID", bol.SuspendID);
                }
                con.Open();

                //var result = await SqlMapper.QueryAsync<bol_WDM_SAForm>(                  //Backup V1 
                //                  con, "sp_WDM_SAForm",
                //  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<bol_WDM_SAForm>(
                                 con, "sp_WDM_SAForm",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }

       
        public IEnumerable<bol_WDM_SAForm> GetList_BK(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@BuildingType", bol.BuildingName);
                cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                if (bol.ActionParam == 1)
                {
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@SuspendID", bol.SuspendID);
                }
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                    saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                    saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                    saform.IsCompany = dr["IsCompany"] == DBNull.Value ? false : bool.Parse(dr["IsCompany"].ToString());
                    saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                    saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? null : dr["ReferralCode"].ToString();
                    saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
                    saform.isSentSMS = dr["isSentSMS"] == DBNull.Value ? false : bool.Parse(dr["isSentSMS"].ToString());
                    saform.ServiceTypeID = dr["ServiceTypeID"] == DBNull.Value ? 0 : int.Parse(dr["ServiceTypeID"].ToString());
                    saform.AddOnID = dr["AddOnID"] == DBNull.Value ? 0 : int.Parse(dr["AddOnID"].ToString());
                    saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
                    saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"]);
                    saform.OrderCode = dr["OrderCode"] == null ? "" : Convert.ToString(dr["OrderCode"]);
                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };
                    if (dr["CreationDate"].ToString() != "")
                    {
                        saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    };
                    saform.SolvedBy = dr["SolvedBy"] == null ? null : dr["SolvedBy"].ToString();
                    saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                    saform.City = dr["City"] == null ? null : dr["City"].ToString();
                    saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();

                    if (bol.ActionParam == 1)
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

        public IEnumerable<bol_WDM_ServicePlanPromo> bll_GetPromoByPlanID(int ActionParam,int ServiceBasePlan_ID,string ServiceCategory)
        {
            List<bol_WDM_ServicePlanPromo> saforms = new List<bol_WDM_ServicePlanPromo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_PROMO_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ServiceBasePlan_ID", ServiceBasePlan_ID);
                cmd.Parameters.AddWithValue("@ServiceCategory", ServiceCategory);
                cmd.Parameters.AddWithValue("@PROMOPLAN_ID", 0);
                cmd.CommandTimeout = 300;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_ServicePlanPromo saform = new bol_WDM_ServicePlanPromo();

                   
                    saform.PROMO_ID = dr["PROMO_ID"] == null ? 0 : Convert.ToInt32(dr["PROMO_ID"].ToString());
                    saform.PromoName_MM = dr["PromoName_MM"] == null ? "" : dr["PromoName_MM"].ToString();
                    saform.PromoName_Eng = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    try
                    {
                        saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"].ToString());
                        saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
                        saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToInt32(dr["SurchargePercentage"].ToString());
                        saform.PlanAmountwithPromo = dr["PlanAmount"] == null ? 0 : Convert.ToDouble(dr["PlanAmount"].ToString());
                        saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDouble(dr["TaxAmount"].ToString());
                    }
                    catch(Exception ex)
                    {
                        saform.TotalCharges = 0;
                    }
                    finally
                    {

                    }
                                       
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_ServicePlanPromo> bll_GetBSPromoByPlanID(int ActionParam, int ServiceBasePlan_ID, string ServiceCategory)
        {
            List<bol_WDM_ServicePlanPromo> saforms = new List<bol_WDM_ServicePlanPromo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_PROMO_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ServiceBasePlan_ID", ServiceBasePlan_ID);
                cmd.Parameters.AddWithValue("@ServiceCategory", ServiceCategory);
                cmd.Parameters.AddWithValue("@PROMOPLAN_ID", 0);
                cmd.CommandTimeout = 300;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_ServicePlanPromo saform = new bol_WDM_ServicePlanPromo();
                   try
                    {
                    saform.PromoName_Eng = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    }
                    catch (Exception ex)
                    {
                        saform.TotalCharges = 0;
                    }
                    finally
                    {

                    }

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        public async Task<IQueryable<bol_WDM_ServicePlanPromo>> bll_GetPromoByPlanIDAsync(int ActionParam, int ServiceBasePlan_ID, string ServiceCategory)
        {
            List<bol_WDM_ServicePlanPromo> saforms = new List<bol_WDM_ServicePlanPromo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_PROMO_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ServiceBasePlan_ID", ServiceBasePlan_ID);
                cmd.Parameters.AddWithValue("@ServiceCategory", ServiceCategory);
                cmd.Parameters.AddWithValue("@PROMOPLAN_ID", 0);

                con.Open();
                //  SqlDataReader dr = cmd.ExecuteReader();
                SqlDataReader dr = await cmd.ExecuteReaderAsync();

                int rowCount = 0;
                //while (await dr.ReadAsync())
                //{
                //    rowCount++;
                //}

                while (await dr.ReadAsync())
                {
                    rowCount++;
                    bol_WDM_ServicePlanPromo saform = new bol_WDM_ServicePlanPromo();


                    saform.PROMO_ID = dr["PROMO_ID"] == null ? 0 : Convert.ToInt32(dr["PROMO_ID"].ToString());
                    saform.PromoName_MM = dr["PromoName_MM"] == null ? "" : dr["PromoName_MM"].ToString();
                    saform.PromoName_Eng = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    try
                    {
                        saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"].ToString());
                        saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
                        saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToInt32(dr["SurchargePercentage"].ToString());
                        saform.PlanAmountwithPromo = dr["PlanAmount"] == null ? 0 : Convert.ToDouble(dr["PlanAmount"].ToString());
                        saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDouble(dr["TaxAmount"].ToString());
                    }
                    catch (Exception ex)
                    {
                        saform.TotalCharges = 0;
                    }
                    finally
                    {

                    }

                    saforms.Add(saform);
                }
            }
            return saforms.AsQueryable();
        }


        public IEnumerable<bol_WDM_ServicePlanPromo> bll_GetPXPromoByPlanID(int ActionParam, int ServiceBasePlan_ID, string ServiceCategory, bool IsDeposit)
        {
            List<bol_WDM_ServicePlanPromo> saforms = new List<bol_WDM_ServicePlanPromo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_PROMO_Detail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ServiceBasePlan_ID", ServiceBasePlan_ID);
                cmd.Parameters.AddWithValue("@ServiceCategory", ServiceCategory);
                cmd.Parameters.AddWithValue("@PROMOPLAN_ID", 0);
                cmd.Parameters.AddWithValue("@IsDeposit", IsDeposit);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_ServicePlanPromo saform = new bol_WDM_ServicePlanPromo();


                    saform.PROMO_ID = dr["PROMO_ID"] == null ? 0 : Convert.ToInt32(dr["PROMO_ID"].ToString());
                    saform.PromoName_MM = dr["PromoName_MM"] == null ? "" : dr["PromoName_MM"].ToString();
                    saform.PromoName_Eng = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    try
                    {
                        saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"].ToString());
                        saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
                        saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToInt32(dr["SurchargePercentage"].ToString());
                        saform.PlanAmountwithPromo = dr["PlanAmount"] == null ? 0 : Convert.ToDouble(dr["PlanAmount"].ToString());
                        saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDouble(dr["TaxAmount"].ToString());
                        
                        saform.DepositAmount = dr["DepositAmount"] == null ? 0 : Convert.ToDouble(dr["DepositAmount"].ToString());
                    }
                    catch (Exception ex)
                    {
                        saform.TotalCharges = 0;
                    }
                    finally
                    {

                    }

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        public IEnumerable<bol_WDM_ServicePlanPromo> bll_GetSAPlanByCity(int ActionParam, string cityName,string PaymentAlias)
        {
            List<bol_WDM_ServicePlanPromo> saforms = new List<bol_WDM_ServicePlanPromo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_ServiceApplicationForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", ActionParam);
                cmd.Parameters.AddWithValue("@PaymentAlias", PaymentAlias);
                cmd.Parameters.AddWithValue("@CompanyName", cityName);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_ServicePlanPromo saform = new bol_WDM_ServicePlanPromo();


                    saform.PROMO_ID = dr["PROMO_ID"] == null ? 0 : Convert.ToInt32(dr["PROMO_ID"].ToString());
                    saform.PromoName_MM = dr["PromoName_MM"] == null ? "" : dr["PromoName_MM"].ToString();
                    saform.PromoName_Eng = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    try
                    {
                        saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"].ToString());
                    }
                    catch (Exception ex)
                    {
                        saform.TotalCharges = 0;
                    }
                    finally
                    {

                    }

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        //bll_GetSAPromoByCity
        //bll_GetSAPlanByCity
        public IEnumerable<bol_ServiceBasePlan_Setup> bll_GetSAPromoByCity(int ActionParam, string cityName, string PaymentAlias)
        {
            List<bol_ServiceBasePlan_Setup> csetups = new List<bol_ServiceBasePlan_Setup>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_ServiceApplicationForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", ActionParam);
                cmd.Parameters.AddWithValue("@PaymentAlias", PaymentAlias);
                cmd.Parameters.AddWithValue("@CompanyName", cityName);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServiceBasePlan_Setup csetup = new bol_ServiceBasePlan_Setup();
                    csetup.id = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.service_type = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    csetup.plan_name = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csetup.plan_full_name = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    csetup.description = dr["Description"] == null ? null : dr["Description"].ToString();
                    //if (bol.ActionParam == 5)
                    //{
                    //    csetup.Bandwidth_Megabytes = dr["Bandwidth_Megabytes"] == null ? null : dr["Bandwidth_Megabytes"].ToString();
                    //    csetup.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                    //    csetup.Price = csetup.Price.Replace(".00", "");
                    //}
                    //else if (bol.ActionParam == 8)
                    //{
                    csetup.Bandwidth_Megabytes = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString();
                    csetup.Bandwidth_Megabytes = csetup.Bandwidth_Megabytes.Replace(".00", "");
                    csetup.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                    csetup.Price = csetup.Price.Replace(".00", "");
                    csetup.DownloadUnit = dr["DownloadUnit"] == null ? null : dr["DownloadUnit"].ToString();
                    //}

                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        public IEnumerable<bol_WDM_SAForm> GetSAData(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                if (bol.ActionParam == 1)
                {
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                }
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());

                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };

                    saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                    saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : Convert.ToInt32(dr["ServicePlanID"].ToString());
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.CityID = dr["CityID"] == null ? 0 : Convert.ToInt32(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == null ? 0 : Convert.ToInt32(dr["TownshipID"].ToString());
                    saform.PromoPlanID = dr["PromoPlanID"] == null ? 0 : Convert.ToInt32(dr["PromoPlanID"].ToString());
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.Latitude = dr["Latitude"] == null ? "" : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? "" : dr["Longitude"].ToString();
                    saform.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? "" : dr["ReferralCode"].ToString();
                    saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"]);
                    try
                    {
                        saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToInt32(dr["SurchargePercentage"].ToString());
                        saform.PlanAmount = dr["PlanAmount"] == null ? 0 : Convert.ToDouble(dr["PlanAmount"].ToString());
                        saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDouble(dr["TaxAmount"].ToString());
                    }
                    catch
                    {

                    }
                    if (bol.ActionParam == 1)
                    {
                        saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                        saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                        saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                    }
                    saform.BuildingTypeID = dr["BuildingTypeID"] == null || dr["BuildingTypeID"] == "" || dr["BuildingTypeID"] == " " || dr["BuildingTypeID"] == "NULL" ? 0 : Convert.ToInt32(dr["BuildingTypeID"]);
                    saform.BuildingName = dr["BuildingName"] == null ? "" : dr["BuildingName"].ToString();

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        public ResultMsg UpdateSAForm(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);                  
                    if(bol.ActionParam==5) //for update customer detail
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", bol.Name);                      
                        cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                        cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                        cmd.Parameters.AddWithValue("@Email", bol.EmailAddress);
                        cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                        cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                        cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                        cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                        cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                        cmd.Parameters.AddWithValue("@BuildingType", bol.BuildingTypeID);
                        cmd.Parameters.AddWithValue("@Address", bol.InstallationAddress);
                        cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                        cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@SolvedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@StaffRemark","");
                        cmd.Parameters.AddWithValue("@IsSolved", false);
                        cmd.Parameters.AddWithValue("@ReferralCode", bol.ReferralCode);                      
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SolvedDate", bol.SolvedDate);
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@StaffRemark", bol.StaffRemark);
                        cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);

                        cmd.Connection = con;
                        con.Open();
                        //cmd.ExecuteNonQuery();
                        resp_code = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

     
        public IEnumerable<bol_WDM_SAForm> GetFamilyData(bol_SA_FTTH_StatusModel bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 8);
                cmd.Parameters.AddWithValue("@ID", bol.SA_ID);
               
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? "" : dr["ReferralCode"].ToString();
                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    saform.TotalCharges = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"]);
                    saform.PaymentMethod = dr["PaymentMethod"] == null ? "" : dr["PaymentMethod"].ToString();
                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        public string CheckReferralCode(string ReferralCode)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_ServiceApplicationForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", 6);
                    cmd.Parameters.AddWithValue("@ReferralCode", ReferralCode);


                    con.Open();
                   //var result= cmd.ExecuteReader().ToString();
                    var ExecuteReader = cmd.ExecuteReader();
                    var result = "";
                    while (ExecuteReader.Read())
                    {
                        result = ExecuteReader.GetValue(0).ToString();
                    }
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }           
        }

        #region Payment
        public IEnumerable<bol_WDM_SAForm> GetSAPaymentStatus(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);               
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());                   
                    saform.PaymentOperator = dr["PaymentOperator"] == null ? "" : dr["PaymentOperator"].ToString();
                    saform.PaymentMethod = dr["PaymentMethod"] == null ? "": (dr["PaymentMethod"].ToString());
                    saform.Trade_Status = dr["Trade_Status"] == null ? "": (dr["Trade_Status"].ToString());                   
                    saform.PaymentDate = dr["PaymentDate"] == null ? DateTime.UtcNow : Convert.ToDateTime(dr["PaymentDate"]);
                    saform.total_amount = dr["total_amount"] == null ? "" : (dr["total_amount"].ToString());
                    saform.trans_currency = dr["trans_currency"] == null ? "" : (dr["trans_currency"].ToString());
                    saform.PromoName = dr["PromoName_Eng"] == null ? "" : (dr["PromoName_Eng"].ToString());
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        #endregion

        public IEnumerable<bol_WDM_SAForm> GetBusinessSAList(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BusinessSAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@IsSolved", bol.lstIsSolved);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                if (bol.ActionParam == 1)
                {
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@SuspendID", bol.SuspendID);
                }
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                    saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                    saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                    saform.IsCompany = dr["IsCompany"] == DBNull.Value ? false : bool.Parse(dr["IsCompany"].ToString());
                    saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                    saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? null : dr["ReferralCode"].ToString();
                    saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
                    saform.isSentSMS = dr["isSentSMS"] == DBNull.Value ? false : bool.Parse(dr["isSentSMS"].ToString());
                    saform.ServiceTypeID = dr["ServiceTypeID"] == DBNull.Value ? 0 : int.Parse(dr["ServiceTypeID"].ToString());
                    saform.AddOnID = dr["AddOnID"] == DBNull.Value ? 0 : int.Parse(dr["AddOnID"].ToString());
                    saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };
                    if (dr["CreationDate"].ToString() != "")
                    {
                        saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    };
                    saform.SolvedBy = dr["SolvedBy"] == null ? null : dr["SolvedBy"].ToString();
                    saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                    saform.City = dr["City"] == null ? null : dr["City"].ToString();
                    saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                    if (bol.ActionParam == 1)
                    {
                        saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                        saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                        saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                        saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        // saform.LastChangeStatus_Setting_ID = dr["LastChangeStatus_Setting_ID"] == null ? 0 : Convert.ToInt32(dr["LastChangeStatus_Setting_ID"].ToString());
                        saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                        saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                        saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                        saform.TotalCharges= dr["TotalCharges"] == null ? 0 :Convert.ToDouble(dr["TotalCharges"].ToString());
                    }

                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_SAForm> GetBusinessSAData(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_BusinessSAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                //SqlDataReader dr = cmd.ExecuteReader();
                //while (dr.Read())
                //{
                //    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                //    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());

                //    if (dr["IsSolved"].ToString() != "")
                //    {
                //        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                //    };
                //    if (dr["SolvedDate"].ToString() != "")
                //    {
                //        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                //    };

                //   saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                //    saforms.Add(saform);
                //}

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());

                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };

                    saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                    saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : Convert.ToInt32(dr["ServicePlanID"].ToString());
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.CityID = dr["CityID"] == null ? 0 : Convert.ToInt32(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == null ? 0 : Convert.ToInt32(dr["TownshipID"].ToString());
                    saform.PromoPlanID = dr["PromoPlanID"] == null ? 0 : Convert.ToInt32(dr["PromoPlanID"].ToString());
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.Latitude = dr["Latitude"] == null ? "" : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? "" : dr["Longitude"].ToString();
                    saform.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? "" : dr["ReferralCode"].ToString();
                    saform.CompanyName = dr["CompanyName"] == null ? "" : dr["CompanyName"].ToString();
                    saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? "" : dr["CompanyRegistrationNo"].ToString();
                    saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? "" : dr["TypeOfBusiness"].ToString();

                    try
                    {
                        saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"].ToString());
                        saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToInt32(dr["SurchargePercentage"].ToString());
                        saform.PlanAmount = dr["PlanAmount"] == null ? 0 : Convert.ToDouble(dr["PlanAmount"].ToString());
                        saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDouble(dr["TaxAmount"].ToString());
                    }
                    catch (Exception ex)
                    {
                        saform.TotalCharges = 0;
                    }

                    saforms.Add(saform);
                }

            }
            return saforms;
        }

        //public ResultMsg UpdateBusinessSAForm(bol_WDM_SAForm bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@ID", bol.ID);
        //            cmd.Parameters.AddWithValue("@SolvedDate", bol.SolvedDate);
        //            cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
        //            cmd.Parameters.AddWithValue("@StaffRemark", bol.StaffRemark);
        //            cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
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

        public ResultMsg UpdateBusinessSAForm(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BusinessSAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam",6);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    if (bol.ActionParam == 6) //for update customer detail
                    {
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
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@SolvedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@StaffRemark", "");
                        cmd.Parameters.AddWithValue("@IsSolved", false);
                        cmd.Parameters.AddWithValue("@ReferralCode", bol.ReferralCode);
                        cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                        cmd.Parameters.AddWithValue("@CompanyRegistrationNo", bol.CompanyRegistrationNo);
                        cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);

                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SolvedDate", bol.SolvedDate);
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@StaffRemark", bol.StaffRemark);
                        cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);

                        cmd.Connection = con;
                        con.Open();
                        //cmd.ExecuteNonQuery();
                        resp_code = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }
        public async Task<ResultMsg> GetSAFormCount(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                ObjParm.Add("@SolvedBy", bol.SolvedBy);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SuspendID", bol.SuspendID);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_WDM_SAForm",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }
        //public ResultMsg GetSAFormCount(bol_WDM_SAForm bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_WDM_SAForm", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
        //            cmd.Parameters.AddWithValue("@City", bol.City);
        //            cmd.Parameters.AddWithValue("@BuildingType", bol.BuildingName);
        //            cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
        //            cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
        //            cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
        //            cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
        //            cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
        //            cmd.Parameters.AddWithValue("@Status", bol.Status);
        //            cmd.Parameters.AddWithValue("@SuspendID", bol.SuspendID);
        //            cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
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
        public ResultMsg GetBusinessSAFormCount(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_BusinessSAForm", con);                   
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@SuspendID", bol.SuspendID);

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

        #region LTE
        public ResultMsg GetLTESAFormCount(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_LTESAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
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

        public IEnumerable<bol_WDM_SAForm> GetLTEList(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_LTESAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@City", bol.City);
               cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
               
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        bol_WDM_SAForm saform = new bol_WDM_SAForm();
                        saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                        saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                        saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                        saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                        saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                        saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                        saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                        saform.IsCompany = dr["IsCompany"] == DBNull.Value ? false : bool.Parse(dr["IsCompany"].ToString());
                        saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                        saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                        saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                        saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                        saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
                        saform.CreationDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                        if (dr["CreatedDate"].ToString() != "")
                        {
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                        };
                        saform.City = dr["City"] == null ? null : dr["City"].ToString();
                        saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                        saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                        saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
                        saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
                        saform.SolvedBy = dr["UpdatedBy"] == null ? null : dr["UpdatedBy"].ToString();
                        saforms.Add(saform);
                    }
                    catch(Exception ex)
                    {
                        ex.Message.ToString();
                    }
                }
            }
            return saforms;
        }

        public IEnumerable<bol_WDM_SAForm> GetLTESAData(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_LTESAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
               
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                     saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : Convert.ToInt32(dr["ServicePlanID"].ToString());
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.StateAndDivision = dr["StateAndDivision"] == null ? "" : dr["StateAndDivision"].ToString();
                    saform.CityID = dr["CityID"] == null ? 0 : Convert.ToInt32(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == null ? 0 : Convert.ToInt32(dr["TownshipID"].ToString());
                     saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.Latitude = dr["Latitude"] == null ? "" : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? "" : dr["Longitude"].ToString();
                    saform.CityName = dr["City"] == null ? "" : dr["City"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    
                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        public ResultMsg UpdateLTESAForm(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_LTESAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@CustomerName", bol.Name);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@Email", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@StateAndDivision", bol.StateAndDivision);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@Address", bol.InstallationAddress);
                    cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.SolvedBy);
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

        #endregion
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

        #region[SPS]
        public IQueryable<bol_FTTH_StatusModel> GetSPS_StatusSetting()
        {
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            var FTTH_Change_Status_Settinglist = new List<bol_FTTH_StatusModel>();
            try
            {
                con.Open();

                var list = con.Query<bol_FTTH_StatusModel>("SELECT  * FROM dbo.SPS_LeadCollection_Status WHERE IsActive=1 ORDER BY SortOrder ASC").ToList().AsQueryable();
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
        public IEnumerable<bol_FTTH_StatusModel> GetSPSStatusList(bol_FTTH_StatusModel bol)
        {
            List<bol_FTTH_StatusModel> csetups = new List<bol_FTTH_StatusModel>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_FTTH_StatusModel csetup = new bol_FTTH_StatusModel();
                        csetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                        csetup.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
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
        public IEnumerable<bol_BankPayment> GetBankForReceivedPayment(bol_BankPayment bol)
        {
            List<bol_BankPayment> bankpayments = new List<bol_BankPayment>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_General", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BankPayment bankpaymentdata = new bol_BankPayment();
                        bankpaymentdata.BankName = dr["BankName"] == DBNull.Value ? null : dr["BankName"].ToString();
                        bankpaymentdata.Value = dr["Value"] == DBNull.Value ? null : dr["Value"].ToString();
                        bankpayments.Add(bankpaymentdata);
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
            return bankpayments; ;
        }
        public async Task<ResultMsg> GetSPSSAFormCountV2(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@SearchByDate", bol.SearchByDate);
                ObjParm.Add("@SearchByServiceNoStatus", bol.SearchByServiceNoStatus);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@Township", bol.Township);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@Channel", bol.Channel);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                ObjParm.Add("@SolvedBy", bol.SolvedBy);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SuspendID", bol.SuspendID);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                ObjParm.Add("@FinanceUser", bol.FinanceUser);
                ObjParm.Add("@IsSPSEngineer", bol.IsSPSEngineer);
                ObjParm.Add("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@SearchGroupID", bol.SearchGroupID);
                ObjParm.Add("@SearchTeamID", bol.SearchTeamID);
                ObjParm.Add("@SearchOwner", bol.SearchOwner);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_SPS_WDM_SAForm",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }
        public async Task<ResultMsg> GetSPSSAFormLoginUserCount(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@SearchByDate", bol.SearchByDate);
                ObjParm.Add("@SearchByServiceNoStatus", bol.SearchByServiceNoStatus);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@Township", bol.Township);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@Channel", bol.Channel);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                ObjParm.Add("@SolvedBy", bol.SolvedBy);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SuspendID", bol.SuspendID);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                ObjParm.Add("@FinanceUser", bol.FinanceUser);
                ObjParm.Add("@IsSPSEngineer", bol.IsSPSEngineer);
                ObjParm.Add("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@SearchGroupID", bol.SearchGroupID);
                ObjParm.Add("@SearchTeamID", bol.SearchTeamID);
                ObjParm.Add("@SearchOwner", bol.SearchOwner);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_SPS_LoginUserCount",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }

        public async Task<IQueryable<bol_WDM_SAForm>> GetSPSListV2(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SAForm> csetups = new List<bol_WDM_SAForm>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@SearchByDate", bol.SearchByDate);
                ObjParm.Add("@SearchByServiceNoStatus", bol.SearchByServiceNoStatus);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@Township", bol.Township);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@Channel", bol.Channel);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                ObjParm.Add("@PageSkipRows", bol.PageIndex);
                ObjParm.Add("@PageTakeRows", 10);
                ObjParm.Add("@FinanceUser", bol.FinanceUser);
                ObjParm.Add("@IsSPSEngineer", bol.IsSPSEngineer);
                if (bol.ActionParam == 1)
                {
                    ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                    ObjParm.Add("@SolvedBy", bol.SolvedBy);
                    ObjParm.Add("@Status", bol.Status);
                    ObjParm.Add("@SuspendID", bol.SuspendID);
                }
                else if (bol.ActionParam == 15)
                {
                    ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                    ObjParm.Add("@SolvedBy", bol.SolvedBy);
                    ObjParm.Add("@Status", bol.Status);
                    ObjParm.Add("@SuspendID", bol.SuspendID);
                }
                ObjParm.Add("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@SearchGroupID", bol.SearchGroupID);
                ObjParm.Add("@SearchTeamID", bol.SearchTeamID);
                ObjParm.Add("@SearchOwner", bol.SearchOwner);
                con.Open();

                //var result = await SqlMapper.QueryAsync<bol_WDM_SAForm>(                  //Backup V1 
                //                  con, "sp_WDM_SAForm",
                //  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                var result = await SqlMapper.QueryAsync<bol_WDM_SAForm>(
                                 con, "sp_SPS_WDM_SAForm",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        public async Task<IQueryable<bol_WDM_SPSStatusList>> GetSPSStatusListV2(bol_WDM_SAForm bol)
        {
            List<bol_WDM_SPSStatusList> csetups = new List<bol_WDM_SPSStatusList>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@SearchByDate", bol.SearchByDate);
                ObjParm.Add("@SearchByServiceNoStatus", bol.SearchByServiceNoStatus);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@Township", bol.Township);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@Channel", bol.Channel);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                ObjParm.Add("@PageSkipRows", bol.PageIndex);
                ObjParm.Add("@PageTakeRows", 10);
                ObjParm.Add("@FinanceUser", bol.FinanceUser);
                ObjParm.Add("@IsSPSEngineer", bol.IsSPSEngineer);                
                ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                ObjParm.Add("@SolvedBy", bol.SolvedBy);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SuspendID", bol.SuspendID);               
                ObjParm.Add("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@UserName", bol.UserName);
                ObjParm.Add("@SearchGroupID", bol.SearchGroupID);
                ObjParm.Add("@SearchTeamID", bol.SearchTeamID);
                ObjParm.Add("@SearchOwner", bol.SearchOwner);
                con.Open();
                var result = await SqlMapper.QueryAsync<bol_WDM_SPSStatusList>(
                                 con, "sp_SPS_WDM_SAForm",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        public IEnumerable<bol_WDM_SAForm> GetSPSData(bol_SA_FTTH_StatusModel bol)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 8);
                cmd.Parameters.AddWithValue("@ID", bol.SA_ID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? "" : dr["ReferralCode"].ToString();
                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    saform.TotalCharges = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"]);
                    saform.PaymentMethod = dr["PaymentMethod"] == null ? "" : dr["PaymentMethod"].ToString();
                    saform.ReceiptNo = dr["ReceiptNo"] == null ? "" : dr["ReceiptNo"].ToString();
                    saform.ReceiptDate = dr["ReceiptDate"] == null ? "" : dr["ReceiptDate"].ToString();
                    saform.InvoiceNo = dr["InvoiceNo"] == null ? "" : dr["InvoiceNo"].ToString();
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public IQueryable<bol_SA_FTTH_StatusModel> GetFTTHSPS_Status(bol_SA_FTTH_StatusModel bol)
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
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                  con.Open();
                var list = con.Query<bol_SA_FTTH_StatusModel>("sp_SPS_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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

        public IQueryable<bol_SA_FTTH_StatusModelDuration> GetFTTHSPS_StatusDuration(bol_SA_FTTH_StatusModel bol)
        {
            List<bol_SA_FTTH_StatusModelDuration> csetup = new List<bol_SA_FTTH_StatusModelDuration>();
            ResultMsg message = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", 4);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                con.Open();
                var list = con.Query<bol_SA_FTTH_StatusModelDuration>("sp_SPS_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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

        public ResultMsg FTTHSPS_StatusInsert(bol_SA_FTTH_StatusModel bol)
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
                ObjParm.Add("@Date", bol.Date == null ? "" : bol.Date);
                ObjParm.Add("@OtherServiceName", bol.OtherServiceName == null ? "" : bol.OtherServiceName);
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_SPS_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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
        public IEnumerable<bol_BS_Status> GetSPSStatusListByPreviousGroupID(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
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

        public IEnumerable<bol_BS_Status> GetSPS_StatusID(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
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
        public IEnumerable<bol_BS_Status> GetSPS_LastStatusID(bol_BS_Status bol)
        {
            List<bol_BS_Status> csetups = new List<bol_BS_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_BS_Status csetup = new bol_BS_Status();
                        //csetup.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        csetup.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                        csetup.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                        csetup.LastStatusID = Convert.ToInt32(dr["LastStatusID"] == null ? "" : dr["LastStatusID"]);
                        csetup.LastLoggedDate = dr["LastLoggedDate"] == null ? "" : dr["LastLoggedDate"].ToString();
                        //csetup.Plan = dr["PlanName"] == null ? "" : dr["PlanName"].ToString();
                        //csetup.CustomerAccountNo = dr["CustomerAccountNo"] == null ? "" : dr["CustomerAccountNo"].ToString();
                        //csetup.TotalCharges = dr["TotalCharges"] == null ? "" : dr["TotalCharges"].ToString();
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
        public IEnumerable<bol_WDM_SAForm> GetSPSSAByID(int ID)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ActionParam", 3);
                cmd.Parameters.AddWithValue("@ID", ID);
                
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());

                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };

                    saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();
                    saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.CusAccNo = dr["CustomerAccountNo"] == null ? "" : dr["CustomerAccountNo"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : Convert.ToInt32(dr["ServicePlanID"].ToString());
                    saform.ServicePlanName = dr["ServicePlanName"] == null ? "" : dr["ServicePlanName"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.CityID = dr["CityID"] == null ? 0 : Convert.ToInt32(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == null ? 0 : Convert.ToInt32(dr["TownshipID"].ToString());
                    saform.PromoPlanID = dr["PromoPlanID"] == null ? 0 : Convert.ToInt32(dr["PromoPlanID"].ToString());
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.Latitude = dr["Latitude"] == null ? "" : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? "" : dr["Longitude"].ToString();
                    saform.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    saform.ReferralCode = dr["ReferralCode"] == null ? "" : dr["ReferralCode"].ToString();
                    saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    saform.TotalCharges = dr["TotalCharges"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TotalCharges"]);
                    saform.LastStatus = dr["LastStatus"] == null ? "" : dr["LastStatus"].ToString();
                    saform.ReceiptNo = dr["ReceiptNo"] == null ? "" : dr["ReceiptNo"].ToString();
                    saform.ReceiptDate = dr["ReceiptDate"] == null ? "" : dr["ReceiptDate"].ToString();
                    saform.InvoiceNo = dr["InvoiceNo"] == null ? "" : dr["InvoiceNo"].ToString();
                    saform.LeadCode = dr["LeadCode"] == null ? "" : dr["LeadCode"].ToString();
                    try
                    {
                        saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToInt32(dr["SurchargePercentage"].ToString());
                        saform.PlanAmount = dr["PlanAmount"] == null ? 0 : Convert.ToDouble(dr["PlanAmount"].ToString());
                        saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDouble(dr["TaxAmount"].ToString());
                        saform.DepositAmount = dr["DepositAmount"] == null ? 0 : Convert.ToDouble(dr["DepositAmount"].ToString());
                        saform.IsDeposit = dr["IsDeposit"] == null ? false : Convert.ToBoolean(dr["IsDeposit"].ToString());
                        
                    }
                    catch
                    {

                    }
                    
                    saform.BuildingTypeID = dr["BuildingTypeID"] == null || dr["BuildingTypeID"] == "" || dr["BuildingTypeID"] == " " || dr["BuildingTypeID"] == "NULL" ? 0 : Convert.ToInt32(dr["BuildingTypeID"]);
                    saform.BuildingName = dr["BuildingName"] == null ? "" : dr["BuildingName"].ToString();
                    saform.LeadSourceID = dr["LeadSourceID"] == null || dr["LeadSourceID"] == "" || dr["LeadSourceID"] == " " || dr["LeadSourceID"] == "NULL" ? 0 : Convert.ToInt32(dr["LeadSourceID"]);
                    saform.LeadSource = dr["Source"] == null ? "" : dr["Source"].ToString(); 
                    saform.ChannelID = dr["ChannelID"] == null || dr["ChannelID"] == "" || dr["ChannelID"] == " " || dr["ChannelID"] == "NULL" ? 0 : Convert.ToInt32(dr["ChannelID"]);
                    saform.Channel = dr["Channel"] == null ? "" : dr["Channel"].ToString();
                    saform.ChargingPattern = dr["ChargingPattern"] == null ? "" : dr["ChargingPattern"].ToString();
                    saform.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                    saform.ODSOwner = dr["ODSOwner"] == null ? null : dr["ODSOwner"].ToString();
                    saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                    saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                    saform.CustCode = dr["CustCode"] == null ? null : dr["CustCode"].ToString();
                    
                    string evoDate = dr["EvoCreatedDate"].ToString();
                    if(evoDate != "")
                    {
                        saform.EvoCreatedDate = dr["EvoCreatedDate"] == null ? null : ((DateTime)dr["EvoCreatedDate"]).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        saform.EvoCreatedDate = null;
                    }
                    //saform.EvoCreatedDate = evoDate == null ? null : dr["EvoCreatedDate"].ToString();                    
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_SAForm> GetSPSTotalAmountByID(int ID)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 26);
                cmd.Parameters.AddWithValue("@ID", ID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.TotalCharges = dr["TotalCharges"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TotalCharges"]);
                    
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_WDM_SAForm> GetSPSLastSAByID(int ID)
        {
            List<bol_WDM_SAForm> saforms = new List<bol_WDM_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ActionParam", 14);
                cmd.Parameters.AddWithValue("@ID", ID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_SAForm saform = new bol_WDM_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());                   
                    saform.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
                    saform.DOB = dr["DOB"] == null ? "" : dr["DOB"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? "" : dr["NRCPassport"].ToString();
                    saform.InstallationAddress = dr["InstallationAddress"] == null ? "" : dr["InstallationAddress"].ToString();
                    saform.CityID = dr["CityID"] == null ? 0 : Convert.ToInt32(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == null ? 0 : Convert.ToInt32(dr["TownshipID"].ToString());
                    saform.EmailAddress = dr["EmailAddress"] == null ? "" : dr["EmailAddress"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? "" : dr["MobileNo"].ToString();
                    saform.ServicePlanID = dr["ServicePlanID"] == null ? 0 : Convert.ToInt32(dr["ServicePlanID"].ToString());
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.CreationDate = dr["CreationDate"] == null ? "" : dr["CreationDate"].ToString();
                    saform.ServiceTypeID = dr["ServiceTypeID"] == null ? 0 : Convert.ToInt32(dr["ServiceTypeID"].ToString());
                    saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? "" : dr["FormattedCreatedDate"].ToString();
                    saform.City = dr["City"] == null ? "" : dr["City"].ToString();
                    saform.Township = dr["Township"] == null ? "" : dr["Township"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.Latitude = dr["Latitude"] == null ? "" : dr["Latitude"].ToString();
                    saform.Longitude = dr["Longitude"] == null ? "" : dr["Longitude"].ToString();
                    saform.LastStatus = dr["LastStatus"] == null ? "" : dr["LastStatus"].ToString();
                    saform.LastLoggedBy = dr["LastLoggedBy"] == null ? "" : dr["LastLoggedBy"].ToString();
                    saform.Owner = dr["Owner"] == null ? "" : dr["Owner"].ToString();
                    saform.LastLoggedDate = dr["LastLoggedDate"] == null ? "" : dr["LastLoggedDate"].ToString();
                    saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                    saform.LastGroupID = dr["LastGroupID"] == null ? 0 : Convert.ToInt32(dr["LastGroupID"].ToString());
                    saform.LastStatusName = dr["LastStatusName"] == null ? "" : dr["LastStatusName"].ToString();
                    saform.LastStatusParentName = dr["LastStatusParentName"] == null ? "" : dr["LastStatusParentName"].ToString();
                    saform.ColorCode = dr["ColorCode"] == null ? "" : dr["ColorCode"].ToString();
                    saform.BuildingTypeID = dr["BuildingTypeID"] == null ? 0 : Convert.ToInt32(dr["BuildingTypeID"].ToString());
                    saform.LeadSourceID = dr["LeadSourceID"] == null ? 0 : Convert.ToInt32(dr["LeadSourceID"].ToString());
                    saform.Source = dr["Source"] == null ? "" : dr["Source"].ToString();
                    saform.ChannelID = dr["ChannelID"] == null ? 0 : Convert.ToInt32(dr["ChannelID"].ToString());
                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    saform.PromoPlanID = dr["PromoPlanID"] == null ? 0 : Convert.ToInt32(dr["PromoPlanID"].ToString());
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.TotalCharges = dr["TotalCharges"] == null ? 0 : Convert.ToDouble(dr["TotalCharges"]);
                   
                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        //public IEnumerable<bol_WDM_SAForm> GetSPSSAByID(int ID)
        //{
        //    List<bol_WDM_BS_SAForm> saforms = new List<bol_WDM_BS_SAForm>();

        //    using (SqlConnection con = new SqlConnection(conn_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", 11);
        //        cmd.Parameters.AddWithValue("@ID", ID);
        //        con.Open();
        //        try
        //        {
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                try
        //                {
        //                    bol_WDM_SAForm saform = new bol_WDM_SAForm();

        //                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
        //                    saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
        //                    saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
        //                    saform.NRCPassport = dr["NRC/Passport"] == null ? null : dr["NRC/Passport"].ToString();
        //                    saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
        //                    saform.VerifyMobileNo = dr["VerifyMobileNo"] == null ? null : dr["VerifyMobileNo"].ToString();
        //                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
        //                    saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
        //                    saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
        //                    saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
        //                    saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
        //                    saform.NoofBranch = dr["No_of_Branch"] == DBNull.Value ? 0 : int.Parse(dr["No_of_Branch"].ToString());
        //                    saform.CurrentInternetPlan = dr["CurrentInternetPlan"] == null ? null : dr["CurrentInternetPlan"].ToString();
        //                    saform.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
        //                    saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
        //                    saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
        //                    saform.BuildingTypeID = dr["BuildingTypeID"] == DBNull.Value ? 0 : int.Parse(dr["BuildingTypeID"].ToString());
        //                    saform.ChannelID = dr["ChannelID"] == DBNull.Value ? 0 : int.Parse(dr["ChannelID"].ToString());
        //                    saform.Latitude = dr["Latitude"] == null ? null : dr["Latitude"].ToString();
        //                    saform.Longitude = dr["Longitude"] == null ? null : dr["Longitude"].ToString();
        //                    saform.ServicePlanID = dr["ServicePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ServicePlanID"].ToString());
        //                    saform.Product = dr["Product"] == null ? null : dr["Product"].ToString();
        //                    saform.ProductPlan = dr["ProductPlan"] == null ? null : dr["ProductPlan"].ToString();
        //                    saform.PromoPlanID = dr["PromoPlanID"] == DBNull.Value ? 0 : int.Parse(dr["PromoPlanID"].ToString());
        //                    saform.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
        //                    saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
        //                    saform.SurchargePercentage = dr["TaxPercentage"] == null ? 0 : Convert.ToDecimal(dr["TaxPercentage"].ToString());
        //                    saform.TaxAmount = dr["TaxAmount"] == null ? 0 : Convert.ToDecimal(dr["TaxAmount"].ToString());
        //                    saform.PlanAmountwithPromo = dr["Amount"] == null ? 0 : Convert.ToDecimal(dr["Amount"].ToString());
        //                    saform.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
        //                    saform.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
        //                    saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
        //                    saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
        //                    saform.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
        //                    saform.CreationDate = dr["CreationDate"] == null ? null : dr["CreationDate"].ToString();
        //                    //saform.SendReceipt = dr["SendReceipt"] == DBNull.Value ? false : bool.Parse(dr["SendReceipt"].ToString());
        //                    saform.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
        //                    if (dr["CreationDate"].ToString() != "")
        //                    {
        //                        saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
        //                    };
        //                    saform.City = dr["City"] == null ? null : dr["City"].ToString();
        //                    saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
        //                    saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
        //                    saform.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
        //                    saform.InvoiceNo = dr["InvoiceNo"] == null ? null : dr["InvoiceNo"].ToString();
        //                    saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
        //                    saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
        //                    saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
        //                    saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
        //                    saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
        //                    saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
        //                    saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
        //                    saform.LastGroupID = dr["LastGroupID"] == null ? 0 : Convert.ToInt32(dr["LastGroupID"].ToString());
        //                    saform.PreviousStatusID = dr["PreviousStatusID"] == null ? 0 : Convert.ToInt32(dr["PreviousStatusID"].ToString());
        //                    saform.InvoiceNo = dr["InvoiceNo"] == null ? null : dr["InvoiceNo"].ToString();
        //                    saform.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
        //                    saform.IsAgree = dr["IsAgree"] == null ? false : Convert.ToBoolean(dr["IsAgree"].ToString());
        //                    if (dr["AgreementDate"].ToString() != "")
        //                    {
        //                        saform.FormattedAgreementDate = dr["FormattedAgreementDate"] == null ? null : dr["FormattedAgreementDate"].ToString();

        //                    };
        //                    saform.PaymentDocNo = dr["PaymentDocNo"] == null ? null : dr["PaymentDocNo"].ToString();
        //                    saform.SendReceipt = dr["SendReceipt"] == null ? false : Convert.ToBoolean(dr["SendReceipt"].ToString());
        //                    if (dr["SendReceiptDate"].ToString() != "")
        //                    {
        //                        saform.FormattedSendReceiptDate = dr["FormattedSendReceiptDate"] == null ? null : dr["FormattedSendReceiptDate"].ToString();

        //                    };
        //                    //saform.SendTermsAndConditions = dr["SendTermsAndConditions"] == null ? false : Convert.ToBoolean(dr["SendTermsAndConditions"].ToString());
        //                    //saform.SendReceipt = dr["SendReceipt"] == null ? false : Convert.ToBoolean(dr["SendReceipt"].ToString());
        //                    //saform.PaymentDocNo = dr["PaymentDocNo"] == null ? null : dr["PaymentDocNo"].ToString();
        //                    saforms.Add(saform);
        //                }
        //                catch (Exception ex)
        //                {
        //                    string s = ex.Message.ToString();
        //                    Console.WriteLine(s);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            string s = ex.Message.ToString();
        //            Console.WriteLine(s);
        //        }
        //    }
        //    return saforms;
        //}
        public IEnumerable<bol_BS_Reason> GetSPSReasonListByGroupID(bol_BS_Reason bol)
        {
            List<bol_BS_Reason> csetups = new List<bol_BS_Reason>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
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
        public ResultMsg UpdateSPSForm(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    if (bol.ActionParam == 5 || bol.ActionParam == 23) //for update customer detail
                    {
                        cmd.Parameters.AddWithValue("@CustomerName", bol.Name);
                        cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                        cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                        cmd.Parameters.AddWithValue("@Email", bol.EmailAddress);
                        cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                        cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                        cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                        cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                        cmd.Parameters.AddWithValue("@PromoPlanID", bol.PromoPlanID);
                        cmd.Parameters.AddWithValue("@BuildingType", bol.BuildingTypeID);
                        cmd.Parameters.AddWithValue("@Channel", bol.ChannelID);
                        cmd.Parameters.AddWithValue("@Address", bol.InstallationAddress);
                        cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                        cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@SolvedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@StaffRemark", "");
                        cmd.Parameters.AddWithValue("@IsSolved", false);
                        cmd.Parameters.AddWithValue("@ReferralCode", bol.ReferralCode);
                        cmd.Parameters.AddWithValue("@ChargingPattern", bol.ChargingPattern);
                        cmd.Parameters.AddWithValue("@Category", bol.Category);
                        cmd.Parameters.AddWithValue("@IsDeposit", bol.IsDeposit);
                        cmd.Parameters.AddWithValue("@DepositAmount", bol.DepositAmount); 
                        cmd.Parameters.AddWithValue("@CusAccNo", bol.CusAccNo);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else if (bol.ActionParam == 24) //for update customer detail
                    {
                        cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                        cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@SolvedDate", DateTime.Now);
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@SolvedDate", bol.SolvedDate);
                        cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                        cmd.Parameters.AddWithValue("@StaffRemark", bol.StaffRemark);
                        cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);

                        cmd.Connection = con;
                        con.Open();
                        //cmd.ExecuteNonQuery();
                        resp_code = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }
        public ResultMsg UpdatePaymentSPSForm(bol_WDM_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
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

        public IEnumerable<bol_SPS_Reason> GetSPSReasonList(bol_SPS_Reason bol)
        {
            List<bol_SPS_Reason> csetups = new List<bol_SPS_Reason>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_SPS_Reason csetup = new bol_SPS_Reason();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.Reason = dr["StatusName"] == null ? null : dr["StatusName"].ToString();
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

        #endregion
        public IEnumerable<bol_WDM_GPS_UserList> GetODSUser(bol_WDM_ODSMap bol)
        {
            List<bol_WDM_GPS_UserList> cities = new List<bol_WDM_GPS_UserList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_ODS_GPS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_GPS_UserList userdata = new bol_WDM_GPS_UserList();
                    userdata.UserName = dr["username"] == DBNull.Value ? null : dr["username"].ToString();
                    cities.Add(userdata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_WDM_ODS_LatLongResModel> ODS_GPSList(bol_WDM_ODSMap bol)
        {
            List<bol_WDM_ODS_LatLongResModel> cities = new List<bol_WDM_ODS_LatLongResModel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_ODS_GPS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Name", bol.Name);
                cmd.Parameters.AddWithValue("@Date", bol.Date);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_ODS_LatLongResModel lstdata = new bol_WDM_ODS_LatLongResModel();
                    lstdata.lat = dr["Latitude"] == null ? 0 : Convert.ToDecimal(dr["Latitude"].ToString());
                    lstdata.lng = dr["Longitude"] == null ? 0 : Convert.ToDecimal(dr["Longitude"].ToString());
                    lstdata.label = dr["label"] == null ? 0 : Convert.ToInt32(dr["label"].ToString());
                    cities.Add(lstdata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_SPS_Owner> GetSPSOwnerList(bol_SPS_Owner bol)
        {
            List<bol_SPS_Owner> csetups = new List<bol_SPS_Owner>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_SPS_Owner csetup = new bol_SPS_Owner();
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
        public IEnumerable<bol_SPS_Owner> GetSPSStaffListByPermission(bol_SPS_Owner bol)
        {
            List<bol_SPS_Owner> csetups = new List<bol_SPS_Owner>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_SPS_Owner csetup = new bol_SPS_Owner();
                        csetup.Owner = dr["userName"] == null ? null : dr["userName"].ToString();
                        csetup.FullName = dr["fullName"] == null ? null : dr["fullName"].ToString();
                        csetup.GroupName = dr["GroupName"] == null ? null : dr["GroupName"].ToString();
                        csetup.TeamName = dr["TeamName"] == null ? null : dr["TeamName"].ToString();
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
        public IEnumerable<bol_WDM_GPS_Calculate> ODS_GPS_OnOffDuration(bol_WDM_ODSMap bol)
        {
            List<bol_WDM_GPS_Calculate> cities = new List<bol_WDM_GPS_Calculate>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_ODS_GPS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Name", bol.Name);
                cmd.Parameters.AddWithValue("@Date", bol.Date);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_GPS_Calculate lstdata = new bol_WDM_GPS_Calculate();
                    lstdata.userName = dr["userName"] == null ? "" : (dr["userName"].ToString());
                    lstdata.TotalDurationSeconds = dr["TotalDurationSeconds"] == null ? "" : (dr["TotalDurationSeconds"].ToString());
                    lstdata.OnOffTotalDuration = dr["OnOffTotalDuration"] == null ? "" : (dr["OnOffTotalDuration"].ToString());
                    cities.Add(lstdata);
                }
            }
            return cities;
        }
        public ResultMsg SPSInvoiceNoUpdate(int ID,string CreatedBy)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 17);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@SolvedBy", CreatedBy);
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
        public ResultMsg SPSReceiptNoUpdate(int ID)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 22);
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
        public List<BSModel> SPSInvoiceData(int ID)
        {
            try
            {
                List<BSModel> vm = new List<BSModel>();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 18);
                    cmd.Parameters.AddWithValue("@ID", ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        BSModel invoice = new BSModel();
                        invoice.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        invoice.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        invoice.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                        invoice.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                        invoice.InstallationAddress = dr["InstallationAddress"] == null ? null : dr["InstallationAddress"].ToString();
                        invoice.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                        invoice.BankPaymentName = dr["BankPaymentName"] == null ? null : dr["BankPaymentName"].ToString();
                        invoice.InvoiceNo = dr["InvoiceNo"] == null ? null : dr["InvoiceNo"].ToString();
                        invoice.InvoiceSendDate = dr["InvoiceSendDate"] == null ? null : dr["InvoiceSendDate"].ToString();
                        invoice.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                        invoice.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                        //invoice.IsAgree = dr["IsAgree"].ToString() == null || dr["IsAgree"].ToString() == "" ? false : Convert.ToBoolean(dr["IsAgree"].ToString());
                        invoice.PromotionDescription = dr["PromotionDescription"] == null ? null : dr["PromotionDescription"].ToString();
                        invoice.FreeMonth = dr["FreeMonth"] == null ? null : dr["FreeMonth"].ToString();
                        invoice.Total = dr["Total"] == null ? null : dr["Total"].ToString();
                        invoice.IsSurchargeOn = dr["IsSurchargeOn"] == null ? null : dr["IsSurchargeOn"].ToString();
                        invoice.SurchargePercentage = dr["SurchargePercentage"] == null ? null : dr["SurchargePercentage"].ToString();
                        invoice.TaxAmount = dr["TaxAmount"] == null ? null : dr["TaxAmount"].ToString();
                        invoice.TotalCharges = dr["TotalCharges"] == null ? null : dr["TotalCharges"].ToString();
                        invoice.City = dr["CityName"] == null ? null : dr["CityName"].ToString();
                        invoice.DepositAmount = dr["DepositAmount"] == null ? null : dr["DepositAmount"].ToString();
                        invoice.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                        invoice.ServiceName = dr["ServicePlanName"] == null ? null : dr["ServicePlanName"].ToString();
                        invoice.ReceiptNo = dr["ReceiptNo"] == null ? "" : dr["ReceiptNo"].ToString();
                        invoice.ReceiptDate = dr["ReceiptDate"] == null ? "" : dr["ReceiptDate"].ToString();
                        vm.Add(invoice);
                    }

                    con.Close();
                }
                return vm;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ResultMsg SPSPrintLog(bol_SPS_PrintLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 21);
                    cmd.Parameters.AddWithValue("@SA_ID", bol.SA_ID);
                    cmd.Parameters.AddWithValue("@DownloadBy", bol.DownloadBy);
                    cmd.Parameters.AddWithValue("@DownloadDate", bol.DownloadDate);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch(Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            return new ResultMsg() { Result = resp_code };
        }
        public ResultMsg SPSLogActivity(bol_SPS_ActivityLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_LogActivity", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SA_ID", bol.SA_ID);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@Datetime", bol.Datetime);
                    cmd.Parameters.AddWithValue("@LoggedBy", bol.LoggedBy);
                    cmd.Parameters.AddWithValue("@LoggedDate", bol.LoggedDate);
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
       public List<bol_SPS_LeadCode> GetSPS_LeadCodeByID(bol_SPS_LeadCode bo)
        {
            try
            {
                List<bol_SPS_LeadCode> vm = new List<bol_SPS_LeadCode>();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bo.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_SPS_LeadCode data = new bol_SPS_LeadCode();
                        data.LeadCode = dr["LeadCode"] == null ? null : dr["LeadCode"].ToString();
                        vm.Add(data);
                    }

                    con.Close();
                }
                return vm;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bol_SPS_CreatedDate> GetSPS_CreatedDateByLeadCode(bol_SPS_CreatedDate bo)
        {
            try
            {
                List<bol_SPS_CreatedDate> vm = new List<bol_SPS_CreatedDate>();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bo.ActionParam);
                    cmd.Parameters.AddWithValue("@LeadCode", bo.LeadCode);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_SPS_CreatedDate data = new bol_SPS_CreatedDate();
                        data.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                        vm.Add(data);
                    }

                    con.Close();
                }
                return vm;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bol_SPS_CollectedCashBaseAmount> GetSPS_CollectedCashedBaseAmount(bol_SPS_CollectedCashBaseAmount bo)
        {
            try
            {
                List<bol_SPS_CollectedCashBaseAmount> vm = new List<bol_SPS_CollectedCashBaseAmount>();
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 32);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_SPS_CollectedCashBaseAmount data = new bol_SPS_CollectedCashBaseAmount();
                        data.CollectedCashBaseAmount = dr["Amount"] == null ? 0 : Convert.ToInt32(dr["Amount"].ToString());
                        vm.Add(data);
                    }

                    con.Close();
                }
                return vm;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string CheckCustomerAccNo(string cusAccNo, int ID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_WDM_SAForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", 29);
                    cmd.Parameters.AddWithValue("@CusAccNo", cusAccNo);
                    cmd.Parameters.AddWithValue("@ID", ID);


                    con.Open();
                    //var result= cmd.ExecuteReader().ToString();
                    var ExecuteReader = cmd.ExecuteReader();
                    var result = "";
                    while (ExecuteReader.Read())
                    {
                        result = ExecuteReader.GetValue(0).ToString();
                    }
                    con.Close();
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

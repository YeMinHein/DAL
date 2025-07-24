using BOL;
using BOL.PROMO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PROMO
{
    public class dal_Promo_Setup
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_Promo_Setup()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        #region Promo Type

        #region Promo Type List 

        public IQueryable<bol_PROMO_Setup> PromoTypeList(bol_PROMO_Setup bol, int PROMO_TYPE = 0)
        {
            List<bol_PROMO_Setup> csetups = new List<bol_PROMO_Setup>();
            try
            {
                bol.createdDate = DateTime.Now;
                // bol.FromDate = DateTime.Now;
                //bol.ToDate = DateTime.Now;
                SqlCommand cmd = new SqlCommand("sp_PROMO_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                //DynamicParameters ObjParm = new DynamicParameters();
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@PromoName_MM", bol.PromoName_MM);
                cmd.Parameters.AddWithValue("@PromoName_Eng", bol.PromoName_Eng);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@PromoLabel", bol.PromoLabel);
                cmd.Parameters.AddWithValue("@PromoLabelColour", bol.PromoLabelColour);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.createdDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.createdBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort == null ? "" : bol.Sort);
                if (bol.ServiceBasePlanID != null)
                {
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", ConvertStringArrayToString(bol.ServiceBasePlanID));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", "0");
                }
                cmd.Parameters.AddWithValue("@CITY_ID", "0");
                cmd.Parameters.AddWithValue("@FOC_Month", bol.FOC_Month);
                cmd.Parameters.AddWithValue("@FOC_Day", bol.FOC_Day);
                cmd.Parameters.AddWithValue("@InstallMonth", bol.InstallMonth);
                cmd.Parameters.AddWithValue("@IsShown", false);
                cmd.Parameters.AddWithValue("@IsOTCCharge", bol.IsOTCCharge);
                cmd.Parameters.AddWithValue("@IsDepositCharge", bol.IsDepositCharge);
                cmd.Parameters.AddWithValue("@Remarks", bol.Remarks == null ? "" : bol.Remarks);
                cmd.Parameters.AddWithValue("@PromotionGroupID", bol.PromotionGroupID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PROMO_Setup csetup = new bol_PROMO_Setup();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.PromoName_MM = dr["PromoName_MM"] == null ? null : dr["PromoName_MM"].ToString();
                    csetup.PromoName_Eng = dr["PromoName_Eng"] == null ? null : dr["PromoName_Eng"].ToString();
                    csetup.Description_MM = dr["Description_MM"] == null ? null : dr["Description_MM"].ToString();
                    csetup.Description_Eng = dr["Description_Eng"] == null ? null : dr["Description_Eng"].ToString();
                    csetup.PromoLabel = dr["PromoLabel"] == null ? null : dr["PromoLabel"].ToString();
                    csetup.PromoLabelColour = dr["PromoLabelColour"] == null ? null : dr["PromoLabelColour"].ToString();
                    csetup.SortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                    csetup.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    csetup.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csetup.ServiceBasePlanID = dr["ServiceBasePlanID"] == null ? null : dr["ServiceBasePlanID"].ToString().Split(',');
                    csetup.City_ID = dr["City_ID"] == null ? null : dr["City_ID"].ToString().Split(',');
                    csetup.FromDate = dr["FromDate"] == null ? DateTime.Now : Convert.ToDateTime(dr["FromDate"].ToString());
                    csetup.ToDate = dr["ToDate"] == null ? DateTime.Now : Convert.ToDateTime(dr["ToDate"].ToString());
                    csetup.InstallMonth = dr["InstallMonth"] == null ? 0 : Convert.ToInt32(dr["InstallMonth"].ToString());
                    csetup.FOC_Month = dr["FOC_Month"] == null ? 0 : Convert.ToInt32(dr["FOC_Month"].ToString());
                    csetup.FOC_Day = dr["FOC_Day"] == null ? 0 : Convert.ToInt32(dr["FOC_Day"].ToString());
                    csetup.FOC_Note = dr["FOC_Note"] == null ? "" : dr["FOC_Note"].ToString();
                    csetup.IsOTCCharge = dr["IsOTCCharge"] == null ? false : Convert.ToBoolean(dr["IsOTCCharge"].ToString());
                    csetup.IsDepositCharge = dr["IsDepositCharge"] == null ? false : Convert.ToBoolean(dr["IsDepositCharge"].ToString());
                    csetup.Remarks = dr["Remarks"] == null ? "" : dr["Remarks"].ToString();
                    csetup.IsShown = dr["IsShown"] == null ? false : Convert.ToBoolean(dr["IsShown"].ToString());
                    csetup.PromotionGroupID = dr["PromotionGroupID"] == null ? 0 : Convert.ToInt32(dr["PromotionGroupID"].ToString());
                    csetup.PromotionGroup = dr["PromotionGroup"] == null ? "" : dr["PromotionGroup"].ToString();
                    csetups.Add(csetup);
                }
                //var list = con.Query<bol_PROMO_Setup>("sp_PROMO_Setup", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
                //return list;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
            finally
            {
                con.Close();
            }

            return csetups.AsQueryable();
        }
        #endregion
        #region Promo Type List 

        public int PromoTypeListCount(bol_PROMO_Setup bol, int PROMO_TYPE = 0)
        {

            try
            {
                bol.createdDate = DateTime.Now;
                //bol.FromDate = DateTime.Now;
                //bol.ToDate = DateTime.Now;
                SqlCommand cmd = new SqlCommand("sp_PROMO_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@PromoName_MM", bol.PromoName_MM);
                cmd.Parameters.AddWithValue("@PromoName_Eng", bol.PromoName_Eng);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@PromoLabel", bol.PromoLabel);
                cmd.Parameters.AddWithValue("@PromoLabelColour", bol.PromoLabelColour);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.createdDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.createdBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort == null ? "" : bol.Sort);
                if (bol.ServiceBasePlanID != null)
                {
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", ConvertStringArrayToString(bol.ServiceBasePlanID));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", "0");
                }
                cmd.Parameters.AddWithValue("@CITY_ID", "0");
                cmd.Parameters.AddWithValue("@FOC_Month", bol.FOC_Month);
                cmd.Parameters.AddWithValue("@FOC_Day", bol.FOC_Day);
                cmd.Parameters.AddWithValue("@InstallMonth", bol.InstallMonth);
                cmd.Parameters.AddWithValue("@IsShown", false);
                cmd.Parameters.AddWithValue("@IsOTCCharge", bol.IsOTCCharge);
                cmd.Parameters.AddWithValue("@IsDepositCharge", bol.IsDepositCharge);
                cmd.Parameters.AddWithValue("@Remarks", bol.Remarks == null ? "" : bol.Remarks);
                cmd.Parameters.AddWithValue("@PromotionGroupID", bol.PromotionGroupID);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return 0;

        }
        #endregion

        #region Prom Insert Update Delete
        public ResultMsg Promo_InsertUpdateDelete(bol_PROMO_Setup bol)
        {
            string resp_code = "";
            try
            {
                if (bol.ActionType == "DELETE")
                {
                    bol.createdDate = DateTime.Now;
                    bol.FromDate = DateTime.Now;
                    bol.ToDate = DateTime.Now;
                }

                SqlCommand cmd = new SqlCommand("sp_PROMO_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                //cmd.Parameters.AddWithValue("@PROMO_Type_ID ", bol.PROMO_Type_ID);
                cmd.Parameters.AddWithValue("@PromoName_MM", bol.PromoName_MM);
                cmd.Parameters.AddWithValue("@PromoName_Eng", bol.PromoName_Eng);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@PromoLabel", bol.PromoLabel);
                cmd.Parameters.AddWithValue("@PromoLabelColour", bol.PromoLabelColour);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.createdDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.createdBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@IsOTCCharge", bol.IsOTCCharge);
                cmd.Parameters.AddWithValue("@IsDepositCharge", bol.IsDepositCharge);
                cmd.Parameters.AddWithValue("@Remarks", bol.Remarks == null ? "" : bol.Remarks);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort == null ? "" : bol.Sort);
                if (bol.ServiceBasePlanID != null)
                {
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", ConvertStringArrayToString(bol.ServiceBasePlanID));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", "");
                }

                if (bol.City_ID != null)
                {
                    cmd.Parameters.AddWithValue("@CITY_ID", ConvertStringArrayToString(bol.City_ID));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@CITY_ID", "");
                }
                cmd.Parameters.AddWithValue("@PromotionGroupID", bol.PromotionGroupID);
                cmd.Parameters.AddWithValue("@FOC_Month", bol.FOC_Month);
                cmd.Parameters.AddWithValue("@FOC_Day", bol.FOC_Day);
                cmd.Parameters.AddWithValue("@FOC_Note", bol.FOC_Note == null ? "" : bol.FOC_Note);
                cmd.Parameters.AddWithValue("@InstallMonth", bol.InstallMonth);
                cmd.Parameters.AddWithValue("@IsShown", bol.IsShown);
                cmd.Connection = con;
                con.Open();
                //cmd.ExecuteNonQuery();
                if (bol.ActionType == "DELETE")
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    resp_code = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code, Message = resp_code == "3" ? "Succefully updated!" : resp_code == "2" ? "Succefully saved!" : "Succefully deleted" };

        }
        #endregion

        #endregion

        #region ServiceBase
        public IEnumerable<bol_ServiceBasePlan_Setup> ServiceBasePlanList(bol_PROMO_Setup bol)
        {
            List<bol_ServiceBasePlan_Setup> csetups = new List<bol_ServiceBasePlan_Setup>();
            try
            {
                bol.createdDate = DateTime.Now;
                bol.FromDate = DateTime.Now;
                bol.ToDate = DateTime.Now;
                SqlCommand cmd = new SqlCommand("sp_PROMO_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@PromoName_MM", bol.PromoName_MM);
                cmd.Parameters.AddWithValue("@PromoName_Eng", bol.PromoName_Eng);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@PromoLabel", bol.PromoLabel);
                cmd.Parameters.AddWithValue("@PromoLabelColour", bol.PromoLabelColour);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.createdDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.createdBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@ServiceBasePlanID", "");
                cmd.Parameters.AddWithValue("@FOC_Month", bol.FOC_Month);
                cmd.Parameters.AddWithValue("@FOC_Day", bol.FOC_Day);
                cmd.Parameters.AddWithValue("@InstallMonth", bol.InstallMonth);
                cmd.Parameters.AddWithValue("@IsShown", false);
                cmd.Parameters.AddWithValue("@IsOTCCharge", bol.IsOTCCharge);
                cmd.Parameters.AddWithValue("@IsDepositCharge", bol.IsDepositCharge);
                cmd.Parameters.AddWithValue("@Remarks", bol.Remarks == null ? "" : bol.Remarks);
                cmd.Parameters.AddWithValue("@CITY_ID", "");
                cmd.Parameters.AddWithValue("@PromotionGroupID", bol.PromotionGroupID);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort == null ? "" : bol.Sort);
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
                    if (bol.ActionParam == 5)
                    {
                        csetup.Bandwidth_Megabytes = dr["Bandwidth_Megabytes"] == null ? null : dr["Bandwidth_Megabytes"].ToString();
                        csetup.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                        csetup.Price = csetup.Price.Replace(".00", "");
                    }
                    else if (bol.ActionParam == 8)
                    {
                        csetup.Bandwidth_Megabytes = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString();
                        csetup.Bandwidth_Megabytes = csetup.Bandwidth_Megabytes.Replace(".00", "");
                        csetup.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                        csetup.Price = csetup.Price.Replace(".00", "");
                        csetup.DownloadUnit = dr["DownloadUnit"] == null ? null : dr["DownloadUnit"].ToString();

                        csetup.TotalCharges = dr["TotalCharges"] == null ? "0" : Convert.ToString(dr["TotalCharges"].ToString());
                        
                        csetup.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
                        csetup.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToDouble(dr["SurchargePercentage"].ToString());
                        csetup.TaxAmount = dr["TaxAmount"] == null ? "0" : Convert.ToString(dr["TaxAmount"].ToString());
                    }
                    //else if (bol.ActionParam == 10)
                    //{
                    //    csetup.Bandwidth_Megabytes = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString();
                    //    csetup.Bandwidth_Megabytes = csetup.Bandwidth_Megabytes.Replace(".00", "");
                    //    csetup.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                    //    csetup.Price = csetup.Price.Replace(".00", "");
                    //    csetup.DownloadUnit = dr["DownloadUnit"] == null ? null : dr["DownloadUnit"].ToString();
                    //}
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

            return csetups;
        }
        #endregion

        #region GetPromotionGroupList
        public IEnumerable<bol_PROMO_Group> GetPromotionGroupList(bol_PROMO_Setup bol)
        {
            List<bol_PROMO_Group> csetups = new List<bol_PROMO_Group>();
            try
            {
                bol.createdDate = DateTime.Now;
                bol.FromDate = DateTime.Now;
                bol.ToDate = DateTime.Now;
                SqlCommand cmd = new SqlCommand("sp_PROMO_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@PromoName_MM", bol.PromoName_MM);
                cmd.Parameters.AddWithValue("@PromoName_Eng", bol.PromoName_Eng);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@PromoLabel", bol.PromoLabel);
                cmd.Parameters.AddWithValue("@PromoLabelColour", bol.PromoLabelColour);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.createdDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.createdBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@ServiceBasePlanID", "");
                cmd.Parameters.AddWithValue("@FOC_Month", bol.FOC_Month);
                cmd.Parameters.AddWithValue("@FOC_Day", bol.FOC_Day);
                cmd.Parameters.AddWithValue("@InstallMonth", bol.InstallMonth);
                cmd.Parameters.AddWithValue("@IsShown", false);
                cmd.Parameters.AddWithValue("@IsOTCCharge", bol.IsOTCCharge);
                cmd.Parameters.AddWithValue("@IsDepositCharge", bol.IsDepositCharge);
                cmd.Parameters.AddWithValue("@Remarks", bol.Remarks == null ? "" : bol.Remarks);
                cmd.Parameters.AddWithValue("@CITY_ID", "");
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort == null ? "" : bol.Sort);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PROMO_Group csetup = new bol_PROMO_Group();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.PromotionGroup = dr["PromotionGroup"] == null ? null : dr["PromotionGroup"].ToString();
                    csetup.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    csetup.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    csetup.SortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
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

            return csetups;
        }
        #endregion

        public string ConvertStringArrayToString(string[] array)
        {
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append(',');
            }
            return builder.ToString().TrimEnd(',');
        }

        #region City List
        public IEnumerable<bol_PROMO_CITY> CityList()
        {
            List<bol_PROMO_CITY> csetups = new List<bol_PROMO_CITY>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from City where IsActive=1 ORDER BY OrderNo ASC ", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PROMO_CITY csetup = new bol_PROMO_CITY();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
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

            return csetups;
        }
        #endregion
    }
}

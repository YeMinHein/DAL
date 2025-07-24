using BOL;
using BOL.General;
using BOL.PROMO;
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
    public class dal_WDM_LimitCashCollection
    {
        //string conn_str = dal_ConfigManager.GTG;
        //ResultMsg result = new ResultMsg();

        //public dal_WDM_SAForm() {
        //}

        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_WDM_LimitCashCollection()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        public int dal_GetCashCollectorLimitCount(bol_WDM_CashCollectorRequestModel bol)
        {
            int count = 0;
            using(SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_LimitCashCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@cityID", bol.cityID);
                cmd.Parameters.AddWithValue("@cashcollector", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    count = dr["Counts"] == DBNull.Value ? 0 : int.Parse(dr["Counts"].ToString());
                }
            }
            return count;
        }
        public List<bol_WDM_CashCollectorLimitModel> dal_GetCashCollectorList(bol_WDM_CashCollectorRequestModel bol)
        {
            List<bol_WDM_CashCollectorLimitModel> ccList = new List<bol_WDM_CashCollectorLimitModel>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_LimitCashCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@cityID", bol.cityID);
                cmd.Parameters.AddWithValue("@cashcollector", bol.userName);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.pageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_CashCollectorLimitModel cc = new bol_WDM_CashCollectorLimitModel();
                    cc.RowNo = dr["RowNo"] == null ? 0 : int.Parse(dr["RowNo"].ToString());
                    cc.UserName = dr["userName"] == null ? "" : dr["userName"].ToString();
                    cc.FullName = dr["fullName"] == null ? "" : dr["fullName"].ToString();
                    cc.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    cc.TeamName = dr["TeamName"] == null ? "" : dr["TeamName"].ToString();
                    cc.TeamID = dr["TeamID"] == null ? "" : dr["TeamID"].ToString();
                    cc.CityID = dr["CityID"] == null ? "" : dr["CityID"].ToString();
                    cc.DailyCashAmount = dr["DailyCashAmount"] == null ? 0 : Decimal.Parse(dr["DailyCashAmount"].ToString());
                    cc.MaximumAmount = dr["MaximumAmount"] == null ? 0 : Decimal.Parse(dr["MaximumAmount"].ToString());
                    cc.MinimumAmount = dr["MinimumAmount"] == null ? 0 : Decimal.Parse(dr["MinimumAmount"].ToString());
                    ccList.Add(cc);
                }
            }
            return ccList;
        }
        public List<bol_WDM_CashCollectorLimitModel> dal_GetCashCollectorListSelect(bol_WDM_CashCollectorRequestModel bol)
        {
            List<bol_WDM_CashCollectorLimitModel> ccList = new List<bol_WDM_CashCollectorLimitModel>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_LimitCashCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@cityID", bol.cityID);
                cmd.Parameters.AddWithValue("@cashcollector", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_CashCollectorLimitModel cc = new bol_WDM_CashCollectorLimitModel();
                    cc.RowNo = dr["RowNo"] == null ? 0 : int.Parse(dr["RowNo"].ToString());
                    cc.UserName = dr["userName"] == null ? "" : dr["userName"].ToString();
                    cc.FullName = dr["fullName"] == null ? "" : dr["fullName"].ToString();
                    cc.CityName = dr["CityName"] == null ? "" : dr["CityName"].ToString();
                    cc.TeamName = dr["TeamName"] == null ? "" : dr["TeamName"].ToString();
                    cc.DailyCashAmount = dr["DailyCashAmount"] == null ? 0 : Decimal.Parse(dr["DailyCashAmount"].ToString());
                    cc.MaximumAmount = dr["MaximumAmount"] == null ? 0 : Decimal.Parse(dr["MaximumAmount"].ToString());
                    cc.MinimumAmount = dr["MinimumAmount"] == null ? 0 : Decimal.Parse(dr["MinimumAmount"].ToString());
                    ccList.Add(cc);
                }
            }
            return ccList;
        }
        public Decimal dal_GetBaseAmount()
        {
            decimal baseAmount = 0;
            using(SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_LimitCashCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 5);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    baseAmount = dr["Amount"] == null ? 0 : Decimal.Parse(dr["Amount"].ToString());
                }
            }
            return baseAmount;
        }
        public ResultMsg dal_InsertorUpdateLimitCashCollection(bol_WDM_CashCollectorLimitModel bol)
        {
            ResultMsg result = new ResultMsg();
            Decimal baseAmount = dal_GetBaseAmount();
            Decimal MaxAmount = bol.DailyCashAmount + baseAmount;
            Decimal MinAmount = bol.DailyCashAmount - baseAmount;
            if(bol.DailyCashAmount == 0)
            {
                MaxAmount = 0;
                MinAmount = 0;
            }
            using(SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_LimitCashCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@City", bol.CityID);
                cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                cmd.Parameters.AddWithValue("@DailyCashAmount", bol.DailyCashAmount);
                cmd.Parameters.AddWithValue("@MaximumAmount", MaxAmount);
                cmd.Parameters.AddWithValue("@MinimumAmount", MinAmount);
                cmd.Parameters.AddWithValue("@Create_Modify_UserName", bol.Create_Modify_UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Message = dr["RespDescription"].ToString();
                    result.Result = dr["RespCode"].ToString();
                }
            }
            return result;
        }
        public ResultMsg dal_UpdateMinMaxAmount(bol_WDM_CashCollectorLimitModel bol)
        {
            ResultMsg result = new ResultMsg();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_WDM_LimitCashCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@City", bol.CityID);
                cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                cmd.Parameters.AddWithValue("@DailyCashAmount", bol.DailyCashAmount);
                cmd.Parameters.AddWithValue("@MaximumAmount", bol.MaximumAmount);
                cmd.Parameters.AddWithValue("@MinimumAmount", bol.MinimumAmount);
                cmd.Parameters.AddWithValue("@Create_Modify_UserName", bol.Create_Modify_UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    result.Message = dr["RespDescription"].ToString();
                    result.Result = dr["RespCode"].ToString();
                }
            }
            return result;
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

       
    }
}

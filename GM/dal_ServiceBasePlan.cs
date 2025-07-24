using BOL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.GM;
using System.Data;
using Newtonsoft.Json.Schema;
using System.Web.Mvc;
using BOL.EMN;

namespace DAL.GM
{
    public class dal_ServiceBasePlan
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_ServiceBasePlan()
        {

        }        
        public IEnumerable<bol_ServiceBasePlan> GetFullNames(string PlanName)
        {
            List<bol_ServiceBasePlan> bolService = new List<bol_ServiceBasePlan>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GetFullNamesByPlanName", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iStrPlanName", PlanName);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServiceBasePlan bolServiceBasePlan = new bol_ServiceBasePlan();
                    bolServiceBasePlan.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    bolServiceBasePlan.BasePlan = dr["BasePlan"] == DBNull.Value ? 0 : Convert.ToInt32(dr["BasePlan"]);
                    bolService.Add(bolServiceBasePlan);
                }
            }
            return bolService;
        }      

        public ResultMsg InsertNewBasePlan(bol_ServiceBasePlan bol)
        {
            ResultMsg result = new ResultMsg();
            SqlConnection con = null;
            try
            {
                con = new SqlConnection(conn_str);
                SqlCommand cmd = new SqlCommand("sp_ServiceBasePlan_Add", con);
                var description = string.IsNullOrEmpty(bol.Description) ? "-" : bol.Description;
                var Features = string.IsNullOrEmpty(bol.Features) ? "-" : bol.Features;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@iStrServiceType", bol.ServiceType);
                cmd.Parameters.AddWithValue("@iStrPlanName", bol.PlanName);
                cmd.Parameters.AddWithValue("@iStrFullName", bol.FullName);
                cmd.Parameters.AddWithValue("@iStrCity", bol.City);                
                cmd.Parameters.AddWithValue("@iStrDescription", description);
                cmd.Parameters.AddWithValue("@iStrDownloadSpeed", bol.DownloadSpeed);
                cmd.Parameters.AddWithValue("@iStrUploadSpeed", bol.UploadSpeed);
                cmd.Parameters.AddWithValue("@iStrInstallationFees", bol.InstallationFees);
                cmd.Parameters.AddWithValue("@iStrBandwidthMegabytes", bol.Bandwidth_Megabytes);
                cmd.Parameters.AddWithValue("@iStrFeatures", Features);
                cmd.Parameters.AddWithValue("@iStrPrice", bol.Price);
                cmd.Parameters.AddWithValue("@iStrCategory", bol.Category);
                cmd.Parameters.AddWithValue("@iStrDepositAmount", bol.DepositAmount);
                cmd.Parameters.AddWithValue("@iStrPlanID", bol.planId);
                cmd.Parameters.AddWithValue("@iStrPlanType", bol.PlanType);
                cmd.Parameters.AddWithValue("@iStrValidity", bol.Validity);
                cmd.Parameters.AddWithValue("@iStrPromoDay", bol.PromoDay);
                cmd.Parameters.AddWithValue("@iStrChargingPattern", bol.ChargingPattern);
                cmd.Parameters.AddWithValue("@iStrPkgDisplayName", bol.PkgDisplayName);
                cmd.Parameters.AddWithValue("@SurchargePercentage", bol.SurchargePercentage);
                cmd.Parameters.AddWithValue("@IsDisplayinApp", bol.IsDisplayinApp);
                cmd.Parameters.AddWithValue("@IsDisplayin5BB", bol.IsDisplayin5BB);
                cmd.Parameters.AddWithValue("@IsDisplayinSpectrum", bol.IsDisplayinSpectrum);

                if (bol.IsParent)
                {
                    cmd.Parameters.AddWithValue("@IsParent", true);
                    cmd.Parameters.AddWithValue("@iStrBasePlanID", DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsParent", false);
                    cmd.Parameters.AddWithValue("@iStrBasePlanID", bol.BasePlan);
                }

                if (bol.IsSurcharge)
                {
                    cmd.Parameters.AddWithValue("@IsSurcharge", true);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IsSurcharge", false);
                }

                SqlParameter outputPlanId = new SqlParameter("@NewPlanID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(outputPlanId);

                con.Open();
                cmd.ExecuteNonQuery();

                int newPlanId = (int)outputPlanId.Value;

                if (newPlanId > 0)
                {
                    result.Result = "Complete";
                    result.Message = "Plan inserted successfully.";
                }
                else
                {
                    result.Result = "Error";
                    result.Message = "An error occurred while inserting the plan.";
                }
            }
            catch (Exception ex)
            {
                result.Result = "Error";
                result.Exception = ex.GetType().ToString();
                result.Message = ex.Message;
            }
            finally
            {
                if (con != null && con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return result;
        }

        public int GetPlanIdByPlanName(string planName)
        {
            int planId = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    string query = "SELECT ID FROM ServiceBasePlan WHERE LOWER(PlanName) = LOWER(@PlanName)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@PlanName", planName);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        planId = Convert.ToInt32(result);
                    }
                    else
                    {
                        planId = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                planId = 0;
            }
            return planId;
        }

    }
}

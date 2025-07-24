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
    public class dal_API_LTE
    {
        string conn_str = dal_ConfigManager.GTG;
        public bol_API_LTE_GetBillingAreaID LTERechargeGetBillingAreaID(bol_API_LTE_GetBillingAreaID bol)
        {
            bol_API_LTE_GetBillingAreaID gba = new bol_API_LTE_GetBillingAreaID();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo); 
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gba.Alias = dr["Alias"] == null ? null : dr["Alias"].ToString();
                }
            }
            return gba;
        }
        public bol_API_LTE_GetPlanInfo LTERechargeGetPlanInfo(bol_API_LTE_GetPlanInfo bol)
        {
            bol_API_LTE_GetPlanInfo gba = new bol_API_LTE_GetPlanInfo();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gba.planName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                }
            }
            return gba;
        }
        public IEnumerable<bol_API_LTE_GetRechargePlan_ResModel> GetRechargePlan(bol_API_LTE_GetRechargePlan bol)
        {
            List<bol_API_LTE_GetRechargePlan_ResModel> grps = new List<bol_API_LTE_GetRechargePlan_ResModel>();
            

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_LTE_GetRechargePlan_ResModel grp = new bol_API_LTE_GetRechargePlan_ResModel();

                    grp.planID = dr["planID"] == null ? null : dr["planID"].ToString();
                    grp.planName = dr["planName"] == null ? null : dr["planName"].ToString();
                    grp.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    grp.CalculatePrice = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());
                    if (dr["Price"] != DBNull.Value)
                    {
                        if (dr["Price"].ToString() != "")
                        {
                            //nd.Amount = double.Parse(dr["TransactionAmount"].ToString());
                            //nd.Amount.ToString("N", new System.Globalization.CultureInfo("en-US"));

                            double Price = double.Parse(dr["Price"].ToString());
                            grp.Price = Price.ToString("N0", new System.Globalization.CultureInfo("en-US")) + " MMK";
                        }
                    }

                    //grp.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                    grp.SortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                    grp.DownloadSpeed = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString();
                    //grp.UploadSpeed = dr["UploadSpeed"] == null ? null : dr["UploadSpeed"].ToString();
                    grp.Quota = dr["Quota"] == null ? 0 : Convert.ToInt32(dr["Quota"].ToString());
                    grp.Validity = dr["Validity"] == null ? 0 : Convert.ToInt32(dr["Validity"].ToString());
                    grp.Label = dr["Label"] == null ? null : dr["Label"].ToString();

                    grps.Add(grp);
                }
            }
            return grps;
        }

        public bol_API_LTE_GetPlanName LTEGetPlanName(bol_API_LTE_GetPlanName bol)
        {
            bol_API_LTE_GetPlanName gpn = new bol_API_LTE_GetPlanName();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@planId", bol.planId);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gpn.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                }
            }
            return gpn;
        }

    }
}

using BOL;
using BOL.WDM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WDM
{
    

    public class dal_WDM_LeadEntryForm
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        //public IEnumerable<bol_WDM_LEF_City> bll_GetCityList(bol_WDM_LEF_City bo)
        //{
        //    dal_General da = new dal_General();
        //    return da.GetTypeList(bo);
        //}

        public IEnumerable<bol_WDM_LEF_City> GetCityList(bol_WDM_LEF_City bol)
        {
            List<bol_WDM_LEF_City> cities = new List<bol_WDM_LEF_City>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_LEF_City city = new bol_WDM_LEF_City();
                    city.CityID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    city.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    cities.Add(city);
                }
            }
            return cities;
        }

        public IEnumerable<bol_WDM_LEF_Township> GetTownshipList(bol_WDM_LEF_Township bol)
        {
            List<bol_WDM_LEF_Township> townships = new List<bol_WDM_LEF_Township>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_LEF_Township township = new bol_WDM_LEF_Township();
                    township.TownshipID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    township.Township = dr["Township"] == DBNull.Value ? null : dr["Township"].ToString();
                    townships.Add(township);
                }
            }
            return townships;
        }
        public IEnumerable<bol_WDM_LEF_ChargingPattern> GetChargingPatternList(bol_WDM_LEF_ChargingPattern bol)
        {
            List<bol_WDM_LEF_ChargingPattern> cities = new List<bol_WDM_LEF_ChargingPattern>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_LEF_ChargingPattern city = new bol_WDM_LEF_ChargingPattern();
                    city.ChargingPattern = dr["ChargingPattern"] == DBNull.Value ? null : dr["ChargingPattern"].ToString();
                    cities.Add(city);
                }
            }
            return cities;
        }

        public IEnumerable<bol_WDM_LEF_Category> GetCategoryList(bol_WDM_LEF_Category bol)
        {
            List<bol_WDM_LEF_Category> townships = new List<bol_WDM_LEF_Category>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ChargingPattern", bol.ChargingPattern);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_LEF_Category township = new bol_WDM_LEF_Category();
                   township.Category = dr["Category"] == DBNull.Value ? null : dr["Category"].ToString();
                    townships.Add(township);
                }
            }
            return townships;
        }

        public IEnumerable<bol_WDM_LEF_Channel> GetChannelList(bol_WDM_LEF_Channel bol)
        {
            List<bol_WDM_LEF_Channel> channels = new List<bol_WDM_LEF_Channel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_LEF_Channel channel = new bol_WDM_LEF_Channel();
                    channel.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    channel.Channel = dr["Channel"] == DBNull.Value ? null : dr["Channel"].ToString();
                    channels.Add(channel);
                }
            }
            return channels;
        }
        public IEnumerable<bol_WDM_ServiceBasePlan> ServiceBasePlanList(bol_WDM_LEF_Plan bol)
        {
            List<bol_WDM_ServiceBasePlan> csetups = new List<bol_WDM_ServiceBasePlan>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_Plan", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@Category", bol.Category);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_WDM_ServiceBasePlan csetup = new bol_WDM_ServiceBasePlan();
                        csetup.id = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.service_type = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                        csetup.plan_name = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                        csetup.plan_full_name = dr["FullName"] == null ? null : dr["FullName"].ToString();
                        csetup.description = dr["Description"] == null ? null : dr["Description"].ToString();
                       
                            csetup.Bandwidth_Megabytes = dr["Bandwidth_Megabytes"] == null ? null : dr["Bandwidth_Megabytes"].ToString();
                            csetup.Price = dr["Price"] == null ? null : dr["Price"].ToString();
                            csetup.Price = csetup.Price.Replace(".00", "");
                       
                        csetups.Add(csetup);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //con.Close();
            }

            return csetups;
        }

    }


}

using BOL;
using BOL.POS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.POS
{
   public class dal_POS_Data
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        #region POS Data
        public IEnumerable<bol_POS_Data> POS_Summarize_DataList(bol_POS_Data bol)
        {
            List<bol_POS_Data> sparams = new List<bol_POS_Data>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {


                SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 9);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@CityName", bol.City);
                cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    
                        bol_POS_Data plans = new bol_POS_Data();

                        plans.ID = Convert.ToInt32(dr["ID"].ToString());
                        plans.Plan = Convert.ToString(dr["PlanName"]);
                        plans.City = dr["CityName"].ToString();
                        plans.FromDate = Convert.ToDateTime(dr["FromDate"]);
                        plans.ToDate = Convert.ToDateTime(dr["ToDate"]);
                        plans.SalesCount = Convert.ToInt32(dr["SalesCount"]);
                    plans.SortOrder = Convert.ToInt32(dr["SortOrder"].ToString());
                        sparams.Add(plans);
                }
            }
            return sparams;
        }
        public IEnumerable<bol_POS_WeeklyReport> GetPOSWeeklyReportList(bol_POS_Data bol)
        {
            List<bol_POS_WeeklyReport> sparams = new List<bol_POS_WeeklyReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {


                SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@CityName", bol.City);
                cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                cmd.Parameters.AddWithValue("@FTTHCategory", bol.FTTHCategory == null || bol.FTTHCategory == "" ? null : bol.FTTHCategory);
                cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_POS_WeeklyReport posreport = new bol_POS_WeeklyReport();
                    posreport.Week = dr["Week"] == null ? null : dr["Week"].ToString();
                    posreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    posreport.StartDate = dr["StartDate"] == null ? null : dr["StartDate"].ToString();
                    posreport.EndDate = dr["EndDate"] == null ? null : dr["EndDate"].ToString();
                    sparams.Add(posreport);
                }
            }
            return sparams;
        }

        public IEnumerable<bol_POS_MontlyReport> GetPOSMonthlyReportList(bol_POS_Data bol)
        {
            List<bol_POS_MontlyReport> posreports = new List<bol_POS_MontlyReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@CityName", bol.City);
                cmd.Parameters.AddWithValue("@FTTHCategory", bol.FTTHCategory == null || bol.FTTHCategory == "" ? null : bol.FTTHCategory);
                cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_POS_MontlyReport posreport = new bol_POS_MontlyReport();
                    posreport.MonthYearByNo = dr["MonthYearByNo"] == null ? null : dr["MonthYearByNo"].ToString();
                    posreport.MonthYearByText = dr["MonthYearByText"] == null ? null : dr["MonthYearByText"].ToString();
                    posreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    posreports.Add(posreport);
                }
            }
            return posreports;


        }


        public IEnumerable<bol_POS_SalesByCity> GetPOS_SalesByCity(bol_POS_Data bol)
        {
            List<bol_POS_SalesByCity> posreports = new List<bol_POS_SalesByCity>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@CityName", bol.City);
                cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_POS_SalesByCity posreport = new bol_POS_SalesByCity();
                    posreport.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    posreport.City = dr["City"] == null ? null : dr["City"].ToString();
                    posreport.SalesCount = dr["SalesCount"] == null ? 0 : int.Parse(dr["SalesCount"].ToString());
                    posreports.Add(posreport);
                }
            }
            return posreports;


        }

        public string GetPOS_LastrefrshDate(bol_POS_Data bol)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@FromDate",DateTime.Now );
                    cmd.Parameters.AddWithValue("@ToDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@CityName", bol.City);
                    cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                    cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                    cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);
                    con.Open();
                    //cmd.ExecuteNonQuery();
                   var result= cmd.ExecuteScalar().ToString();
                    con.Close();
                    return result;
                }
                
            }

            catch(Exception ex)

            {

            }

            return "";
        }

        #region POS Crawl Time
        public IEnumerable<bol_POS_CrawlTime> POSCrawlTimeList()
        {
            List<bol_POS_CrawlTime> csetups = new List<bol_POS_CrawlTime>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select ID,CrawlTime  from POSCrawlTimer where IsActive=1 ORDER BY CrawlTime ASC ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_POS_CrawlTime csetup = new bol_POS_CrawlTime();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.CrawlTime = dr["CrawlTime"] == null ? "" : dr["CrawlTime"].ToString();
                        csetups.Add(csetup);
                    }

                    con.Close();
                }
            }

            catch (Exception ex)

            {

            }
            finally
            {
                
            }

            return csetups;
        }
        #endregion

        public IEnumerable<bol_POS_last31Sales> GetPOS_Last31Sales(bol_POS_Data bol)
        {
            List<bol_POS_last31Sales> posreports = new List<bol_POS_last31Sales>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@CityName", bol.City);
                cmd.Parameters.AddWithValue("@FTTHCategory", bol.FTTHCategory==null || bol.FTTHCategory=="" ? null: bol.FTTHCategory);
                cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_POS_last31Sales posreport = new bol_POS_last31Sales();
                    posreport.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"]);
                    posreport.DayNames = dr["DayNames"] == null ? null : dr["DayNames"].ToString();
                    posreport.SalesCount = dr["SalesCount"] == null ? 0 : int.Parse(dr["SalesCount"].ToString());
                    posreports.Add(posreport);
                }
            }
            return posreports;
        }

        public IEnumerable<bol_POS_last12MonthSales> GetPOS_Last12MonthSales(bol_POS_Data bol)
        {
            List<bol_POS_last12MonthSales> posreports = new List<bol_POS_last12MonthSales>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GetPOSSalesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@CityName", bol.City);
                cmd.Parameters.AddWithValue("@IsAllTotal", bol.IsAllTotal);
                cmd.Parameters.AddWithValue("@IsOnlyCondoSales", bol.IsOnlyCondoSales);
                cmd.Parameters.AddWithValue("@IsOnlyBusinessPlan", bol.IsOnlyBusinessPlan);
                cmd.Parameters.AddWithValue("@FTTHCategory", bol.FTTHCategory == null || bol.FTTHCategory == "" ? null : bol.FTTHCategory);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_POS_last12MonthSales posreport = new bol_POS_last12MonthSales();
                    posreport.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"]);

                    posreport.DisplayName = dr["DisplayName"] == null ? null : dr["DisplayName"].ToString();
                    posreport.SalesPrice = dr["SalesPrice"] == null ? 0 : Double.Parse(dr["SalesPrice"].ToString());
                    posreports.Add(posreport);
                }
            }
            return posreports;
        }

        #endregion
    }
}

using BOL;
using BOL.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB
{
    public class dal_DB_Dashboard1
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_DB_Dashboard1() { }

        public IEnumerable<bol_DB_SAFormReport> GetSAFormReportList(bol_DB_SAFormReport bol)
        {
            List<bol_DB_SAFormReport> safreports = new List<bol_DB_SAFormReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_SAFormReport safreport = new bol_DB_SAFormReport();
                    safreport.MonthYearByNo = dr["MonthYearByNo"] == null ? null : dr["MonthYearByNo"].ToString();
                    safreport.MonthYearByText = dr["MonthYearByText"] == null ? null : dr["MonthYearByText"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }

        public IEnumerable<bol_DB_Dashboard1> GetSAFormCountList(bol_DB_Dashboard1 bol)
        {
            List<bol_DB_Dashboard1> safcounts = new List<bol_DB_Dashboard1>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_Dashboard1 safcount = new bol_DB_Dashboard1();
                    safcount.CurrentMonthSAFormCounts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safcounts.Add(safcount);
                }
            }
            return safcounts;


        }
                
        public IEnumerable<bol_DB_SAFormWeeklyReport> GetSAFormWeeklyReportList(bol_DB_SAFormWeeklyReport bol)
        {
            List<bol_DB_SAFormWeeklyReport> safreports = new List<bol_DB_SAFormWeeklyReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_SAFormWeeklyReport safreport = new bol_DB_SAFormWeeklyReport();
                    safreport.Week = dr["Week"] == null ? null : dr["Week"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreport.StartDate = dr["StartDate"] == null ? null : dr["StartDate"].ToString();
                    safreport.EndDate = dr["EndDate"] == null ? null : dr["EndDate"].ToString();
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }

        public IEnumerable<bol_DB_Dashboard1> GetSDFormCountList(bol_DB_Dashboard1 bol)
        {
            List<bol_DB_Dashboard1> safcounts = new List<bol_DB_Dashboard1>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_Dashboard1 safcount = new bol_DB_Dashboard1();
                    safcount.CurrentMonthSDFormCounts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safcounts.Add(safcount);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DB_Dashboard1> GetBusinessSAFormCountList(bol_DB_Dashboard1 bol)
        {
            List<bol_DB_Dashboard1> safcounts = new List<bol_DB_Dashboard1>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_Dashboard1 safcount = new bol_DB_Dashboard1();
                    safcount.CurrentMonthSAFormCounts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safcounts.Add(safcount);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DB_SAFormReport> GetBusinessSAFormMonthlyReportList(bol_DB_SAFormReport bol)
        {
            List<bol_DB_SAFormReport> safreports = new List<bol_DB_SAFormReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_SAFormReport safreport = new bol_DB_SAFormReport();
                    safreport.MonthYearByNo = dr["MonthYearByNo"] == null ? null : dr["MonthYearByNo"].ToString();
                    safreport.MonthYearByText = dr["MonthYearByText"] == null ? null : dr["MonthYearByText"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }
        public IEnumerable<bol_DB_SAFormWeeklyReport> GetBusinessSAFormWeeklyReportList(bol_DB_SAFormWeeklyReport bol)
        {
            List<bol_DB_SAFormWeeklyReport> safreports = new List<bol_DB_SAFormWeeklyReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DB_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DB_SAFormWeeklyReport safreport = new bol_DB_SAFormWeeklyReport();
                    safreport.Week = dr["Week"] == null ? null : dr["Week"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreport.StartDate = dr["StartDate"] == null ? null : dr["StartDate"].ToString();
                    safreport.EndDate = dr["EndDate"] == null ? null : dr["EndDate"].ToString();
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }

        #region[BS Dashboard]
        public IEnumerable<bol_BS_Dashboard> GetBSGroup1(bol_BS_Dashboard bol)
        {
            List<bol_BS_Dashboard> safcounts = new List<bol_BS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BS_Dashboard group1data = new bol_BS_Dashboard();
                    group1data.LeadsConversionRatio = dr["LeadsConversionRatio"] == null ? "" : dr["LeadsConversionRatio"].ToString();
                    safcounts.Add(group1data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_BS_Dashboard> GetBSGroup2(bol_BS_Dashboard bol)
        {
            List<bol_BS_Dashboard> safcounts = new List<bol_BS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BS_Dashboard group2data = new bol_BS_Dashboard();
                    group2data.Leads = dr["Leads"] == null ? 0 : Convert.ToInt32(dr["Leads"].ToString());
                    group2data.Qualified = dr["Qualified"] == null ? 0 : Convert.ToInt32(dr["Qualified"].ToString());
                    group2data.Negotiate = dr["Negotiate"] == null ? 0 : Convert.ToInt32(dr["Negotiate"].ToString());
                    group2data.SalesWon = dr["SalesWon"] == null ? 0 : Convert.ToInt32(dr["SalesWon"].ToString());
                    group2data.ClosedWon = dr["ClosedWon"] == null ? 0 : Convert.ToInt32(dr["ClosedWon"].ToString());
                    safcounts.Add(group2data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_BS_Dashboard> GetBSGroup3(bol_BS_Dashboard bol)
        {
            List<bol_BS_Dashboard> safcounts = new List<bol_BS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BS_Dashboard group3data = new bol_BS_Dashboard();
                    group3data.Qualified = dr["Qualified"] == null ? 0 : Convert.ToInt32(dr["Qualified"].ToString());
                    group3data.SalesWon = dr["SalesWon"] == null ? 0 : Convert.ToInt32(dr["SalesWon"].ToString());
                    group3data.ClosedWon = dr["ClosedWon"] == null ? 0 : Convert.ToInt32(dr["ClosedWon"].ToString());
                    safcounts.Add(group3data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_BS_Dashboard> GetBSGroup4(bol_BS_Dashboard bol)
        {
            List<bol_BS_Dashboard> safcounts = new List<bol_BS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@SortBy", bol.SortBy);
                cmd.Parameters.AddWithValue("@ROWID", bol.ROWID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BS_Dashboard group3data = new bol_BS_Dashboard();
                    group3data.RowNo = dr["RowNo"] == null ? 0 : Convert.ToInt32(dr["RowNo"].ToString());
                    group3data.ConversationRate = dr["ConversationRate"] == null ? "" : dr["ConversationRate"].ToString();
                    group3data.TotalCount = dr["TotalCount"] == null ? "" : dr["TotalCount"].ToString();
                    group3data.MonthlyAmount = dr["MonthlyAmount"] == null ? "" : dr["MonthlyAmount"].ToString();
                    group3data.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    group3data.ARPU = dr["ARPU"] == null ? "" : dr["ARPU"].ToString();
                    group3data.FullName = dr["FullName"] == null ? "" : dr["FullName"].ToString();
                    group3data.Role = dr["Role"] == null ? "" : dr["Role"].ToString();
                    group3data.subscribercount = dr["subscribercount"] == null ? "" : dr["subscribercount"].ToString();
                    group3data.saleswonsubscribercount = dr["saleswonsubscribercount"] == null ? "" : dr["saleswonsubscribercount"].ToString();
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }
        public IEnumerable<bol_BS_Dashboard> GetBSGroup4All(bol_BS_Dashboard bol)
        {
            List<bol_BS_Dashboard> safcounts = new List<bol_BS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@SortBy", bol.SortBy);
                cmd.Parameters.AddWithValue("@ROWID", bol.ROWID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BS_Dashboard group3data = new bol_BS_Dashboard();
                    group3data.RowNo = dr["RowNo"] == null ? 0 : Convert.ToInt32(dr["RowNo"].ToString());
                    group3data.ConversationRate = dr["ConversationRate"] == null ? "" : dr["ConversationRate"].ToString();
                    group3data.TotalCount = dr["TotalCount"] == null ? "" : dr["TotalCount"].ToString();
                    group3data.MonthlyAmount = dr["MonthlyAmount"] == null ? "" : dr["MonthlyAmount"].ToString();
                    group3data.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    group3data.ARPU = dr["ARPU"] == null ? "" : dr["ARPU"].ToString();
                    group3data.FullName = dr["FullName"] == null ? "" : dr["FullName"].ToString();
                    group3data.Role = dr["Role"] == null ? "" : dr["Role"].ToString();
                    group3data.subscribercount = dr["subscribercount"] == null ? "" : dr["subscribercount"].ToString();
                    group3data.saleswonsubscribercount = dr["saleswonsubscribercount"] == null ? "" : dr["saleswonsubscribercount"].ToString();
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }

        public IEnumerable<bol_BS_Dashboard> GetBSGroup5(bol_BS_Dashboard bol)
        {
            List<bol_BS_Dashboard> safcounts = new List<bol_BS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BS_Dashboard group3data = new bol_BS_Dashboard();
                    group3data.ApplicationForm = dr["ApplicationForm"] == null ? 0 : Convert.ToInt32(dr["ApplicationForm"].ToString());
                    group3data.AdminPortalForm = dr["AdminPortalForm"] == null ? 0 : Convert.ToInt32(dr["AdminPortalForm"].ToString());
                    group3data.InterestForm = dr["InterestForm"] == null ? 0 : Convert.ToInt32(dr["InterestForm"].ToString());
                    group3data.Ads_InterestForm = dr["Ads_InterestForm"] == null ? 0 : Convert.ToInt32(dr["Ads_InterestForm"].ToString());
                    group3data.AppointmentForm = dr["AppointmentForm"] == null ? 0 : Convert.ToInt32(dr["AppointmentForm"].ToString());
                    group3data.Import = dr["Import"] == null ? 0 : Convert.ToInt32(dr["Import"].ToString());
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }

        public IEnumerable<bol_BS_Detail> GetBSDBDetailsByOwner(int ActionParam,string Owner, string StartDate, string EndDate)
        {
            List<bol_BS_Detail> saforms = new List<bol_BS_Detail>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@Owner", Owner);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_BS_Detail saform = new bol_BS_Detail();

                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                            saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                            saform.PromoPlan = dr["PromoPlan"] == null ? null : dr["PromoPlan"].ToString();
                            saform.TotalAmount = dr["TotalAmount"] == null ? null : dr["TotalAmount"].ToString();
                            saform.MonthlyAmount = dr["MonthlyAmount"] == null ? null : dr["MonthlyAmount"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.Duration = dr["Duration"] == null ? null : dr["Duration"].ToString();
                            saform.MRCTotal = dr["MRCTotal"] == null ? null : dr["MRCTotal"].ToString();
                            
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
        #region[SC+ Dashboard]
        public IEnumerable<bol_SPS_Dashboard> GetSPSGroup1(bol_SPS_Dashboard bol)
        {
            List<bol_SPS_Dashboard> safcounts = new List<bol_SPS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Dashboard group1data = new bol_SPS_Dashboard();
                    group1data.LeadsConversionRatio = dr["LeadsConversionRatio"] == null ? "" : dr["LeadsConversionRatio"].ToString();
                    safcounts.Add(group1data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_SPS_Dashboard> GetSPSGroup2(bol_SPS_Dashboard bol)
        {
            List<bol_SPS_Dashboard> safcounts = new List<bol_SPS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Dashboard group2data = new bol_SPS_Dashboard();
                    group2data.Leads = dr["Leads"] == null ? 0 : Convert.ToInt32(dr["Leads"].ToString());
                    group2data.Qualified = dr["Qualified"] == null ? 0 : Convert.ToInt32(dr["Qualified"].ToString());
                    //group2data.Negotiate = dr["Negotiate"] == null ? 0 : Convert.ToInt32(dr["Negotiate"].ToString());
                    group2data.SalesWon = dr["SalesWon"] == null ? 0 : Convert.ToInt32(dr["SalesWon"].ToString());
                    group2data.ClosedWon = dr["ClosedWon"] == null ? 0 : Convert.ToInt32(dr["ClosedWon"].ToString());
                    safcounts.Add(group2data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_SPS_Dashboard> GetSPSGroup3(bol_SPS_Dashboard bol)
        {
            List<bol_SPS_Dashboard> safcounts = new List<bol_SPS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Dashboard group3data = new bol_SPS_Dashboard();
                    group3data.Qualified = dr["Qualified"] == null ? 0 : Convert.ToInt32(dr["Qualified"].ToString());
                    group3data.SalesWon = dr["SalesWon"] == null ? 0 : Convert.ToInt32(dr["SalesWon"].ToString());
                    group3data.ClosedWon = dr["ClosedWon"] == null ? 0 : Convert.ToInt32(dr["ClosedWon"].ToString());
                    safcounts.Add(group3data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_SPS_Dashboard> GetSPSGroup4(bol_SPS_Dashboard bol)
        {
            List<bol_SPS_Dashboard> safcounts = new List<bol_SPS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@SortBy", bol.SortBy);
                cmd.Parameters.AddWithValue("@ROWID", bol.ROWID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Dashboard group3data = new bol_SPS_Dashboard();
                    group3data.RowNo = dr["RowNo"] == null ? 0 : Convert.ToInt32(dr["RowNo"].ToString());
                    group3data.ConversationRate = dr["ConversationRate"] == null ? "" : dr["ConversationRate"].ToString();
                    group3data.TotalCount = dr["TotalCount"] == null ? "" : dr["TotalCount"].ToString();
                    group3data.MonthlyAmount = dr["MonthlyAmount"] == null ? "" : dr["MonthlyAmount"].ToString();
                    group3data.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    group3data.ARPU = dr["ARPU"] == null ? "" : dr["ARPU"].ToString();
                    group3data.FullName = dr["FullName"] == null ? "" : dr["FullName"].ToString();
                    group3data.Role = dr["Role"] == null ? "" : dr["Role"].ToString();
                    group3data.subscribercount = dr["subscribercount"] == null ? "" : dr["subscribercount"].ToString();
                    group3data.saleswonsubscribercount = dr["saleswonsubscribercount"] == null ? "" : dr["saleswonsubscribercount"].ToString();
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }
        public IEnumerable<bol_SPS_Dashboard> GetSPSGroup4All(bol_SPS_Dashboard bol)
        {
            List<bol_SPS_Dashboard> safcounts = new List<bol_SPS_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@SortBy", bol.SortBy);
                cmd.Parameters.AddWithValue("@ROWID", bol.ROWID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Dashboard group3data = new bol_SPS_Dashboard();
                    group3data.RowNo = dr["RowNo"] == null ? 0 : Convert.ToInt32(dr["RowNo"].ToString());
                    group3data.ConversationRate = dr["ConversationRate"] == null ? "" : dr["ConversationRate"].ToString();
                    group3data.TotalCount = dr["TotalCount"] == null ? "" : dr["TotalCount"].ToString();
                    group3data.MonthlyAmount = dr["MonthlyAmount"] == null ? "" : dr["MonthlyAmount"].ToString();
                    group3data.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    group3data.ARPU = dr["ARPU"] == null ? "" : dr["ARPU"].ToString();
                    group3data.FullName = dr["FullName"] == null ? "" : dr["FullName"].ToString();
                    group3data.Role = dr["Role"] == null ? "" : dr["Role"].ToString();
                    group3data.subscribercount = dr["subscribercount"] == null ? "" : dr["subscribercount"].ToString();
                    group3data.saleswonsubscribercount = dr["saleswonsubscribercount"] == null ? "" : dr["saleswonsubscribercount"].ToString();
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }

        public IEnumerable<bol_SPS_Channel> GetSPSGroup5(bol_SPS_Channel bol)
        {
            List<bol_SPS_Channel> safcounts = new List<bol_SPS_Channel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Channel group3data = new bol_SPS_Channel();
                    group3data._5BBBusiness = dr["5BB Business"] == DBNull.Value ? 0 : Convert.ToInt32(dr["5BB Business"].ToString());
                    group3data.GoogleMyBusiness = dr["Google My Business"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Google My Business"].ToString());
                    group3data.InPerson = dr["In Person"] == DBNull.Value ? 0 : Convert.ToInt32(dr["In Person"].ToString());
                    group3data.IncomingPhoneCall = dr["Incoming Phone Call"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Incoming Phone Call"].ToString());
                    group3data.Instagram = dr["Instagram"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Instagram"].ToString());
                    group3data.InterestForm = dr["Interest Form"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Interest Form"].ToString());
                    group3data.Mailchimp = dr["Mailchimp"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Mailchimp"].ToString());
                    group3data.OutdoorSales = dr["Outdoor Sales"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Outdoor Sales"].ToString());
                    group3data.PageComments = dr["Page Comments"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Page Comments"].ToString());
                    group3data.Telegram = dr["Telegram"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Telegram"].ToString());
                    group3data.TikTok = dr["TikTok"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TikTok"].ToString());
                    group3data.Viber = dr["Viber"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Viber"].ToString());
                    group3data.Walkin = dr["Walk-in"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Walk-in"].ToString());
                    group3data.WebsiteForms = dr["Website Forms"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Website Forms"].ToString());
                    safcounts.Add(group3data);
                }
            }
            return safcounts;


        }
        public IEnumerable<bol_SPS_Group6Dashboard> GetSPSGroup6(bol_SPS_Group6Dashboard bol)
        {
            List<bol_SPS_Group6Dashboard> safcounts = new List<bol_SPS_Group6Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Group6Dashboard group6data = new bol_SPS_Group6Dashboard();
                    group6data.New = dr["New"] == null ? "" : dr["New"].ToString();
                    group6data.FollowUp = dr["FollowUp"] == null ? "" : dr["FollowUp"].ToString();
                    group6data.Qualify = dr["Qualify"] == null ? "" : dr["Qualify"].ToString();
                    group6data.SalesWon = dr["SalesWon"] == null ? "" : dr["SalesWon"].ToString();
                    group6data.SalesClosed = dr["SalesClosed"] == null ? "" : dr["SalesClosed"].ToString();
                    group6data.Wait = dr["Wait"] == null ? "" : dr["Wait"].ToString();
                    group6data.Disqualify = dr["Disqualify"] == null ? "" : dr["Disqualify"].ToString();
                    group6data.SalesLost = dr["SalesLost"] == null ? "" : dr["SalesLost"].ToString();
                    safcounts.Add(group6data);
                }
            }
            return safcounts;


        }
        public IEnumerable<bol_SPS_Group6Dashboard> GetSPSGroup6ByCity(bol_SPS_Group6Dashboard bol)
        {
            List<bol_SPS_Group6Dashboard> safcounts = new List<bol_SPS_Group6Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_DashboardGroup6ByCity_V3", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Group6Dashboard group6data = new bol_SPS_Group6Dashboard();
                    group6data.City = dr["City"] == null ? "" : dr["City"].ToString();
                    group6data.New = dr["New"] == null ? "" : dr["New"].ToString();
                    group6data.FollowUp = dr["FollowUp"] == null ? "" : dr["FollowUp"].ToString();
                    group6data.Qualify = dr["Qualify"] == null ? "" : dr["Qualify"].ToString();
                    group6data.ReceivedPayment = dr["ReceivedPayment"] == null ? "" : dr["ReceivedPayment"].ToString();
                    group6data.SalesWon = dr["SalesWon"] == null ? "" : dr["SalesWon"].ToString();
                    group6data.SalesClosed = dr["SalesClosed"] == null ? "" : dr["SalesClosed"].ToString();
                    group6data.TotalSales = dr["TotalSales"] == null ? "" : dr["TotalSales"].ToString();
                    group6data.Wait = dr["Wait"] == null ? "" : dr["Wait"].ToString();
                    group6data.Disqualify = dr["Disqualify"] == null ? "" : dr["Disqualify"].ToString();
                    group6data.SalesLost = dr["SalesLost"] == null ? "" : dr["SalesLost"].ToString();
                    group6data.Total = dr["Total"] == null ? "" : dr["Total"].ToString();
                    safcounts.Add(group6data);
                }
            }
            return safcounts;


        }
        public IEnumerable<bol_SPS_Group6Dashboard> GetSPSGroup6ByGroupID(bol_SPS_Group6Dashboard bol)
        {
            List<bol_SPS_Group6Dashboard> safcounts = new List<bol_SPS_Group6Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_DashboardGroup6ByGroup_V2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.CommandTimeout = 500;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPS_Group6Dashboard group6data = new bol_SPS_Group6Dashboard();
                    group6data.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    //group6data.City = dr["City"] != DBNull.Value ? dr["City"].ToString() : string.Empty;
                    group6data.GroupAndTeams = dr["GroupAndTeams"] == null ? "" : dr["GroupAndTeams"].ToString();
                    group6data.New = dr["New"] == null ? "" : dr["New"].ToString();
                    group6data.FollowUp = dr["FollowUp"] == null ? "" : dr["FollowUp"].ToString();
                    group6data.Qualify = dr["Qualify"] == null ? "" : dr["Qualify"].ToString();
                    group6data.ReceivedPayment = dr["ReceivedPayment"] == null ? "" : dr["ReceivedPayment"].ToString();
                    group6data.SalesWon = dr["SalesWon"] == null ? "" : dr["SalesWon"].ToString();
                    group6data.SalesClosed = dr["SalesClosed"] == null ? "" : dr["SalesClosed"].ToString();
                    group6data.TotalSales = dr["TotalSales"] == null ? "" : dr["TotalSales"].ToString();
                    group6data.Wait = dr["Wait"] == null ? "" : dr["Wait"].ToString();
                    group6data.Disqualify = dr["Disqualify"] == null ? "" : dr["Disqualify"].ToString();
                    group6data.SalesLost = dr["SalesLost"] == null ? "" : dr["SalesLost"].ToString();
                    group6data.Total = dr["Total"] == null ? "" : dr["Total"].ToString();
                    safcounts.Add(group6data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_SPS_Detail> GetSPSDBDetailsByOwner(int ActionParam, string Owner, string City, int GroupID, string UserName, string StartDate, string EndDate)
        { 
            List<bol_SPS_Detail> saforms = new List<bol_SPS_Detail>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@City", City);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                cmd.Parameters.AddWithValue("@Owner", Owner);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_SPS_Detail saform = new bol_SPS_Detail();

                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                            saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                            saform.PromoPlan = dr["PromoPlan"] == null ? null : dr["PromoPlan"].ToString();
                            saform.TotalAmount = dr["TotalAmount"] == null ? null : dr["TotalAmount"].ToString();
                            saform.MonthlyAmount = dr["MonthlyAmount"] == null ? null : dr["MonthlyAmount"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.Duration = dr["Duration"] == null ? null : dr["Duration"].ToString();
                            saform.MRCTotal = dr["MRCTotal"] == null ? null : dr["MRCTotal"].ToString();

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
    }
}

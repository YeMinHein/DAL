using BOL;
using BOL.DPSI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DPSI
{
    public class dal_DPSI_Dashboard1
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_DPSI_Dashboard1() { }

        public IEnumerable<bol_DPSI_SAFormReport> GetSAFormReportList(bol_DPSI_SAFormReport bol)
        {
            List<bol_DPSI_SAFormReport> safreports = new List<bol_DPSI_SAFormReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_SAFormReport safreport = new bol_DPSI_SAFormReport();
                    safreport.MonthYearByNo = dr["MonthYearByNo"] == null ? null : dr["MonthYearByNo"].ToString();
                    safreport.MonthYearByText = dr["MonthYearByText"] == null ? null : dr["MonthYearByText"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }

        public IEnumerable<bol_DPSI_Dashboard1> GetSAFormCountList(bol_DPSI_Dashboard1 bol)
        {
            List<bol_DPSI_Dashboard1> safcounts = new List<bol_DPSI_Dashboard1>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard1 safcount = new bol_DPSI_Dashboard1();
                    safcount.CurrentMonthSAFormCounts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safcounts.Add(safcount);
                }
            }
            return safcounts;


        }
                
        public IEnumerable<bol_DPSI_SAFormWeeklyReport> GetSAFormWeeklyReportList(bol_DPSI_SAFormWeeklyReport bol)
        {
            List<bol_DPSI_SAFormWeeklyReport> safreports = new List<bol_DPSI_SAFormWeeklyReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_SAFormWeeklyReport safreport = new bol_DPSI_SAFormWeeklyReport();
                    safreport.Week = dr["Week"] == null ? null : dr["Week"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreport.StartDate = dr["StartDate"] == null ? null : dr["StartDate"].ToString();
                    safreport.EndDate = dr["EndDate"] == null ? null : dr["EndDate"].ToString();
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }

        public IEnumerable<bol_DPSI_Dashboard1> GetSDFormCountList(bol_DPSI_Dashboard1 bol)
        {
            List<bol_DPSI_Dashboard1> safcounts = new List<bol_DPSI_Dashboard1>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard1 safcount = new bol_DPSI_Dashboard1();
                    safcount.CurrentMonthSDFormCounts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safcounts.Add(safcount);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DPSI_Dashboard1> GetBusinessSAFormCountList(bol_DPSI_Dashboard1 bol)
        {
            List<bol_DPSI_Dashboard1> safcounts = new List<bol_DPSI_Dashboard1>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard1 safcount = new bol_DPSI_Dashboard1();
                    safcount.CurrentMonthSAFormCounts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safcounts.Add(safcount);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DPSI_SAFormReport> GetBusinessSAFormMonthlyReportList(bol_DPSI_SAFormReport bol)
        {
            List<bol_DPSI_SAFormReport> safreports = new List<bol_DPSI_SAFormReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_SAFormReport safreport = new bol_DPSI_SAFormReport();
                    safreport.MonthYearByNo = dr["MonthYearByNo"] == null ? null : dr["MonthYearByNo"].ToString();
                    safreport.MonthYearByText = dr["MonthYearByText"] == null ? null : dr["MonthYearByText"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }
        public IEnumerable<bol_DPSI_SAFormWeeklyReport> GetBusinessSAFormWeeklyReportList(bol_DPSI_SAFormWeeklyReport bol)
        {
            List<bol_DPSI_SAFormWeeklyReport> safreports = new List<bol_DPSI_SAFormWeeklyReport>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard1", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_SAFormWeeklyReport safreport = new bol_DPSI_SAFormWeeklyReport();
                    safreport.Week = dr["Week"] == null ? null : dr["Week"].ToString();
                    safreport.Counts = dr["Counts"] == null ? 0 : int.Parse(dr["Counts"].ToString());
                    safreport.StartDate = dr["StartDate"] == null ? null : dr["StartDate"].ToString();
                    safreport.EndDate = dr["EndDate"] == null ? null : dr["EndDate"].ToString();
                    safreports.Add(safreport);
                }
            }
            return safreports;


        }

        #region[DPSI Dashboard]
        public IEnumerable<bol_DPSI_Dashboard> GetDPSIGroup1(bol_DPSI_Dashboard bol)
        {
            List<bol_DPSI_Dashboard> safcounts = new List<bol_DPSI_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard group1data = new bol_DPSI_Dashboard();
                    group1data.LeadsConversionRatio = dr["LeadsConversionRatio"] == null ? "" : dr["LeadsConversionRatio"].ToString();
                    safcounts.Add(group1data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DPSI_Dashboard> GetDPSIGroup2(bol_DPSI_Dashboard bol)
        {
            List<bol_DPSI_Dashboard> safcounts = new List<bol_DPSI_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard group2data = new bol_DPSI_Dashboard();
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

        public IEnumerable<bol_DPSI_Dashboard> GetDPSIGroup3(bol_DPSI_Dashboard bol)
        {
            List<bol_DPSI_Dashboard> safcounts = new List<bol_DPSI_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard group3data = new bol_DPSI_Dashboard();
                    group3data.Qualified = dr["Qualified"] == null ? 0 : Convert.ToInt32(dr["Qualified"].ToString());
                    group3data.Negotiate = dr["Negotiate"] == null ? 0 : Convert.ToInt32(dr["Negotiate"].ToString());
                    group3data.SalesWon = dr["SalesWon"] == null ? 0 : Convert.ToInt32(dr["SalesWon"].ToString());
                    group3data.ClosedWon = dr["ClosedWon"] == null ? 0 : Convert.ToInt32(dr["ClosedWon"].ToString());
                    safcounts.Add(group3data);
                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DPSI_Dashboard> GetDPSIGroup4(bol_DPSI_Dashboard bol)
        {
            List<bol_DPSI_Dashboard> safcounts = new List<bol_DPSI_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@SortBy", bol.SortBy);
                //cmd.Parameters.AddWithValue("@ROWID", bol.ROWID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard group3data = new bol_DPSI_Dashboard();
                    group3data.RowNo = dr["RowNo"] == null ? 0 : Convert.ToInt32(dr["RowNo"].ToString());
                    group3data.ConversationRate = dr["ConversationRate"] == null ? "" : dr["ConversationRate"].ToString();
                    group3data.TotalCount = dr["TotalCount"] == null ? "" : dr["TotalCount"].ToString();
                    group3data.MonthlyAmount = dr["MonthlyAmount"] == null ? "" : dr["MonthlyAmount"].ToString();
                    group3data.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    group3data.ARPU = dr["ARPU"] == null ? "" : dr["ARPU"].ToString();
                    group3data.UserName = dr["UserName"] == null ? "" : dr["UserName"].ToString();
                    group3data.FullName = dr["FullName"] == null ? "" : dr["FullName"].ToString();
                    group3data.Role = dr["Role"] == null ? "" : dr["Role"].ToString();
                    group3data.subscribercount = dr["Subscribercount"] == null ? "" : dr["Subscribercount"].ToString();
                    group3data.saleswonsubscribercount = dr["saleswonSubscribercount"] == null ? "" : dr["saleswonSubscribercount"].ToString();
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }
        public IEnumerable<bol_DPSI_Dashboard> GetDPSIGroup4All(bol_DPSI_Dashboard bol)
        {
            List<bol_DPSI_Dashboard> safcounts = new List<bol_DPSI_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@SortBy", bol.SortBy);
                //cmd.Parameters.AddWithValue("@ROWID", bol.ROWID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard group3data = new bol_DPSI_Dashboard();
                    group3data.RowNo = dr["RowNo"] == null ? 0 : Convert.ToInt32(dr["RowNo"].ToString());
                    group3data.ConversationRate = dr["ConversationRate"] == null ? "" : dr["ConversationRate"].ToString();
                    group3data.TotalCount = dr["TotalCount"] == null ? "" : dr["TotalCount"].ToString();
                    group3data.MonthlyAmount = dr["MonthlyAmount"] == null ? "" : dr["MonthlyAmount"].ToString();
                    group3data.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    group3data.ARPU = dr["ARPU"] == null ? "" : dr["ARPU"].ToString();
                    group3data.UserName = dr["UserName"] == null ? "" : dr["UserName"].ToString();
                    group3data.FullName = dr["FullName"] == null ? "" : dr["FullName"].ToString();
                    group3data.Role = dr["Role"] == null ? "" : dr["Role"].ToString();
                    group3data.subscribercount = dr["Subscribercount"] == null ? "" : dr["Subscribercount"].ToString();
                    group3data.saleswonsubscribercount = dr["saleswonSubscribercount"] == null ? "" : dr["saleswonSubscribercount"].ToString();
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DPSI_Dashboard> GetDPSIGroup5(bol_DPSI_Dashboard bol)
        {
            List<bol_DPSI_Dashboard> safcounts = new List<bol_DPSI_Dashboard>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Dashboard group3data = new bol_DPSI_Dashboard();
                    group3data.Outbound = dr["Outbound"] == null ? 0 : Convert.ToInt32(dr["Outbound"].ToString());
                    group3data.IncomingPhoneCall = dr["IncomingPhoneCall"] == null ? 0 : Convert.ToInt32(dr["IncomingPhoneCall"].ToString());
                    group3data.Messenger = dr["Messenger"] == null ? 0 : Convert.ToInt32(dr["Messenger"].ToString());
                    group3data.PageComments = dr["PageComments"] == null ? 0 : Convert.ToInt32(dr["PageComments"].ToString());
                    group3data.WebsiteForms = dr["WebsiteForms"] == null ? 0 : Convert.ToInt32(dr["WebsiteForms"].ToString());
                    group3data.Instagram = dr["Instagram"] == null ? 0 : Convert.ToInt32(dr["Instagram"].ToString());
                    group3data.LinkedIn = dr["LinkedIn"] == null ? 0 : Convert.ToInt32(dr["LinkedIn"].ToString());
                    group3data.Telegram = dr["Telegram"] == null ? 0 : Convert.ToInt32(dr["Telegram"].ToString());
                    group3data.Mailchimp = dr["Mailchimp"] == null ? 0 : Convert.ToInt32(dr["Mailchimp"].ToString());
                    group3data._5BBBusiness = dr["5BBBusiness"] == null ? 0 : Convert.ToInt32(dr["5BBBusiness"].ToString());
                    group3data.Globalnet = dr["Globalnet"] == null ? 0 : Convert.ToInt32(dr["Globalnet"].ToString());
                    group3data.Referral = dr["Referral"] == null ? 0 : Convert.ToInt32(dr["Referral"].ToString());
                    //group3data.OutboundCall = dr["OutboundCall"] == null ? 0 : Convert.ToInt32(dr["OutboundCall"].ToString());
                    //group3data.Ads_InterestForm = dr["Ads_InterestForm"] == null ? 0 : Convert.ToInt32(dr["Ads_InterestForm"].ToString());
                    //group3data.Import = dr["Import"] == null ? 0 : Convert.ToInt32(dr["Import"].ToString());
                    safcounts.Add(group3data);


                }
            }
            return safcounts;


        }

        public IEnumerable<bol_DPSI_Detail> GetDPSIDBDetailsByOwner(int ActionParam,string Owner, string StartDate, string EndDate)
        {
            List<bol_DPSI_Detail> saforms = new List<bol_DPSI_Detail>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Dashboard", con);
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
                            bol_DPSI_Detail saform = new bol_DPSI_Detail();

                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                            saform.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                           // saform.PromoPlan = dr["PromoPlan"] == null ? null : dr["PromoPlan"].ToString();
                            saform.TotalAmount = dr["TotalAmount"] == null ? null : dr["TotalAmount"].ToString();
                            //saform.MonthlyAmount = dr["MonthlyAmount"] == null ? null : dr["MonthlyAmount"].ToString();
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

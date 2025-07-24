using BOL;
using BOL.Resources;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Resources
{
   public class dal_Resources_SuccessStories
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_Resources_SuccessStories()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        public IQueryable<bol_Resources_Industry> GetResourcesIndustry()
        {
            List<bol_Resources_Industry> csetup = new List<bol_Resources_Industry>();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_Resources_GetSuccessStoriesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 0);
                cmd.Parameters.AddWithValue("@RequestName", "Industry");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Industry model = new bol_Resources_Industry();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.IndustryName = dr["IndustryName"] == null ? null : dr["IndustryName"].ToString();
                    model.BriefDescription = dr["BriefDescription"] == null ? null : dr["BriefDescription"].ToString();
                    csetup.Add(model);
                }


                return csetup.ToList().AsQueryable();

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

        public IQueryable<bol_Resources_Region> GetResourcesRegion()
        {
            List<bol_Resources_Region> csetup = new List<bol_Resources_Region>();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_Resources_GetSuccessStoriesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 0);
                cmd.Parameters.AddWithValue("@RequestName", "Region");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Region model = new bol_Resources_Region();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.RegionName = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.Add(model);
                }


                return csetup.ToList().AsQueryable();

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

        public IQueryable<bol_Resources_CompanySize> GetResourcesCompanySize()
        {
            List<bol_Resources_CompanySize> csetup = new List<bol_Resources_CompanySize>();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_Resources_GetSuccessStoriesData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 0);
                cmd.Parameters.AddWithValue("@RequestName", "Organization");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_CompanySize model = new bol_Resources_CompanySize();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.CompanySize = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.Add(model);
                }
                return csetup.ToList().AsQueryable();

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

        public IQueryable<bol_Resources_SuccessStories> GetSuccessStoryResoures(bol_Resources_SuccessStories bol)
        {
            List<bol_Resources_SuccessStories> csetup = new List<bol_Resources_SuccessStories>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Resources_SuccessStories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@IndustryName", bol.IndustryName == null ? "" : bol.IndustryName);
                cmd.Parameters.AddWithValue("@CompanyName", bol.companyName == null ? "" : bol.companyName);
                cmd.Parameters.AddWithValue("@Logo", bol.Logo == null ? "" : bol.Logo);
                cmd.Parameters.AddWithValue("@Title", bol.Title == null ? "" : bol.Title);
                cmd.Parameters.AddWithValue("@Region", bol.Regions == null ? "" : bol.Regions);
                cmd.Parameters.AddWithValue("@BriefDescription", bol.BriefDescription == null ? "" : bol.BriefDescription);
                cmd.Parameters.AddWithValue("@Description", bol.Description == null ? "" : bol.Description);
                cmd.Parameters.AddWithValue("@CustomerSatisfiedDate", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@CompanySize", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@CompanyWebsiteName", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate == null ? "" : bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate == null ? "" : bol.ToDate);
                cmd.Parameters.AddWithValue("@CompanyProduct", bol.CompanyProducts == null ? "" : bol.CompanyProducts);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_SuccessStories model = new bol_Resources_SuccessStories();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.companyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    model.IndustryName = dr["IndustryName"] == null ? null : dr["IndustryName"].ToString();
                    model.Regions = dr["Regions"] == null ? null : dr["Regions"].ToString();
                    model.CustomerSatisfiedDate = dr["CustomerSatisfiedDate"] == null ? null : dr["CustomerSatisfiedDate"].ToString();
                    model.Oraganizationsize = dr["Oraganizationsize"] == null ? null : dr["Oraganizationsize"].ToString();
                    model.Websites = dr["Websites"] == null ? null : dr["Websites"].ToString();
                    model.CompanyProducts = dr["CompanyProducts"] == null ? null : dr["CompanyProducts"].ToString();
                    model.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    model.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                  
                    csetup.Add(model);
                }


                return csetup.ToList().AsQueryable();

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


        public bol_Resources_SuccessStories GetSuccessStoryResouresByID(bol_Resources_SuccessStories bol)
        {
            bol_Resources_SuccessStories csetup = new bol_Resources_SuccessStories();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Resources_SuccessStories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@IndustryName", bol.IndustryName == null ? "" : bol.IndustryName);
                cmd.Parameters.AddWithValue("@CompanyName", bol.companyName == null ? "" : bol.companyName);
                cmd.Parameters.AddWithValue("@Logo", bol.Logo == null ? "" : bol.Logo);
                cmd.Parameters.AddWithValue("@Title", bol.Title == null ? "" : bol.Title);
                cmd.Parameters.AddWithValue("@Region", bol.Regions == null ? "" : bol.Regions);
                cmd.Parameters.AddWithValue("@BriefDescription", bol.BriefDescription == null ? "" : bol.BriefDescription);
                cmd.Parameters.AddWithValue("@Description", bol.Description == null ? "" : bol.Description);
                cmd.Parameters.AddWithValue("@CustomerSatisfiedDate", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@CompanySize", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@CompanyWebsiteName", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@CompanyProduct", bol.CompanyProducts == null ? "" : bol.CompanyProducts);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_SuccessStories model = new bol_Resources_SuccessStories();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.companyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    model.IndustryName = dr["IndustryName"] == null ? null : dr["IndustryName"].ToString();
                    model.Regions = dr["Regions"] == null ? null : dr["Regions"].ToString();
                    model.CustomerSatisfiedDate = dr["CustomerSatisfiedDate"] == null ? null : dr["CustomerSatisfiedDate"].ToString();
                    model.Oraganizationsize = dr["Oraganizationsize"] == null ? null : dr["Oraganizationsize"].ToString();
                    model.Websites = dr["Websites"] == null ? null : dr["Websites"].ToString();
                    model.CompanyProducts = dr["CompanyProducts"] == null ? null : dr["CompanyProducts"].ToString();
                    model.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    model.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    model.Logo = dr["Logo"] == null ? null : dr["Logo"].ToString();
                    model.BannerPhoto = dr["BannerPhoto"] == null ? null : dr["BannerPhoto"].ToString();
                    model.BriefDescription = dr["BriefDescription"] == null ? null : dr["BriefDescription"].ToString();
                    model.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup =model;
                }


                return csetup;

            }

            catch (Exception ex)

            {

            }
            finally
            {
                con.Close();
            }
            return csetup;
        }

        public bol_Resources_SuccessStories GetSuccessStoryLogoResouresByID(bol_Resources_SuccessStories bol)
        {
            bol_Resources_SuccessStories csetup = new bol_Resources_SuccessStories();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Resources_SuccessStories", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@IndustryName", bol.IndustryName == null ? "" : bol.IndustryName);
                cmd.Parameters.AddWithValue("@CompanyName", bol.companyName == null ? "" : bol.companyName);
                cmd.Parameters.AddWithValue("@Logo", bol.Logo == null ? "" : bol.Logo);
                cmd.Parameters.AddWithValue("@Title", bol.Title == null ? "" : bol.Title);
                cmd.Parameters.AddWithValue("@Region", bol.Regions == null ? "" : bol.Regions);
                cmd.Parameters.AddWithValue("@BriefDescription", bol.BriefDescription == null ? "" : bol.BriefDescription);
                cmd.Parameters.AddWithValue("@Description", bol.Description == null ? "" : bol.Description);
                cmd.Parameters.AddWithValue("@CustomerSatisfiedDate", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@CompanySize", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@CompanyWebsiteName", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@CompanyProduct", bol.CompanyProducts == null ? "" : bol.CompanyProducts);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_SuccessStories model = new bol_Resources_SuccessStories();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.companyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    model.IndustryName = dr["IndustryName"] == null ? null : dr["IndustryName"].ToString();
                    model.Regions = dr["Regions"] == null ? null : dr["Regions"].ToString();
                    model.CustomerSatisfiedDate = dr["CustomerSatisfiedDate"] == null ? null : dr["CustomerSatisfiedDate"].ToString();
                    model.Oraganizationsize = dr["Oraganizationsize"] == null ? null : dr["Oraganizationsize"].ToString();
                    model.Websites = dr["Websites"] == null ? null : dr["Websites"].ToString();
                    model.CompanyProducts = dr["CompanyProducts"] == null ? null : dr["CompanyProducts"].ToString();
                    model.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    model.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    model.Logo = dr["Logo"] == null ? null : dr["Logo"].ToString();
                    model.BannerPhoto = dr["BannerPhoto"] == null ? null : dr["BannerPhoto"].ToString();
                    csetup = model;
                }


                return csetup;

            }

            catch (Exception ex)

            {

            }
            finally
            {
                con.Close();
            }
            return csetup;
        }
        public ResultMsg GetSuccessStoryResouresCount(bol_Resources_SuccessStories bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Resources_SuccessStories", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                    cmd.Parameters.AddWithValue("@IndustryName", bol.IndustryName == null ? "" : bol.IndustryName);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.companyName == null ? "" : bol.companyName);
                    cmd.Parameters.AddWithValue("@Logo", bol.Logo == null ? "" : bol.Logo);
                    cmd.Parameters.AddWithValue("@Title", bol.Title == null ? "" : bol.Title);
                    cmd.Parameters.AddWithValue("@Region", bol.Regions == null ? "" : bol.Regions);
                    cmd.Parameters.AddWithValue("@BriefDescription", bol.BriefDescription == null ? "" : bol.BriefDescription);
                    cmd.Parameters.AddWithValue("@Description", bol.Description == null ? "" : bol.Description);
                    cmd.Parameters.AddWithValue("@CustomerSatisfiedDate", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                    cmd.Parameters.AddWithValue("@CompanySize", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                    cmd.Parameters.AddWithValue("@CompanyWebsiteName", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);         
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@FromDate", bol.FromDate == null ? "" : bol.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", bol.ToDate == null ? "" : bol.ToDate);
                    cmd.Parameters.AddWithValue("@CompanyProduct", bol.CompanyProducts == null ? "" : bol.CompanyProducts);
                    cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                    cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);

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

        public ResultMsg SuccessStoryResouresInsertUpdate(bol_Resources_SuccessStories bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@IndustryName", bol.IndustryName == null ? "" : bol.IndustryName);
                ObjParm.Add("@CompanyName", bol.companyName == null ? "" : bol.companyName);
                ObjParm.Add("@Logo", bol.Logo == null ? "" : bol.Logo);
                ObjParm.Add("@BannerPhoto", bol.BannerPhoto == null ? "" : bol.BannerPhoto);
                ObjParm.Add("@Title", bol.Title == null ? "" : bol.Title);
                ObjParm.Add("@Region", bol.Regions == null ? "" : bol.Regions);
                ObjParm.Add("@BriefDescription", bol.BriefDescription == null ? "" : bol.BriefDescription);
                ObjParm.Add("@Description", bol.Description == null ? "" : bol.Description);
                ObjParm.Add("@CustomerSatisfiedDate", bol.CustomerSatisfiedDate == null ? "" : bol.CustomerSatisfiedDate);
                ObjParm.Add("@CompanySize", bol.Oraganizationsize == null ? "" : bol.Oraganizationsize);
                ObjParm.Add("@CompanyWebsiteName", bol.Websites == null ? "" : bol.Websites);
                ObjParm.Add("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@CompanyProduct", bol.CompanyProducts == null ? "" : bol.CompanyProducts);

                con.Open();
#pragma warning disable CS0219 // The variable 'Result' is assigned but its value is never used
                string Result = "OK";
#pragma warning restore CS0219 // The variable 'Result' is assigned but its value is never used
                var ResultMsg = con.ExecuteScalar("sp_Resources_SuccessStories", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = ResultMsg, Message = bol.ID > 0 ? "Succefully updated!" : bol.ID == 0 ? "Succefully saved!" : "Succefully deleted" };
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
        public ResultMsg SuccessStoryResouresDelete(bol_Resources_SuccessStories bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_SuccessStories", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = "Succefully deleted!" };
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


        #region Speech 
        public ResultMsg SuccessStorySpeechDelete(bol_Resources_Speech bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ActionTypes", bol.ActionTypes == null ? "" : bol.ActionTypes);
                ObjParm.Add("@CheckIDs", bol.CheckIDs == null ? "" : bol.CheckIDs);
                ObjParm.Add("@Customer_ID", bol.Customer_ID == null ? 0 : bol.Customer_ID);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_SuccessStories_Speech", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = "Succefully deleted!" };
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

        public ResultMsg SuccessStorySpeechTextInsertUpdate(bol_Resources_Speech bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ActionTypes", bol.ActionTypes == null ? "" : bol.ActionTypes);
                ObjParm.Add("@CheckIDs", bol.CheckIDs == null ? "" : bol.CheckIDs);
                ObjParm.Add("@Customer_ID", bol.Customer_ID == null ? 0 : bol.Customer_ID);
                ObjParm.Add("@Name", bol.Name == null ? "" : bol.Name);
                ObjParm.Add("@GenerateName", bol.GenerateName == null ? "" : bol.GenerateName);
                ObjParm.Add("@SpeechText", bol.SpeechText == null ? "" : bol.SpeechText);
                ObjParm.Add("@Position", bol.Position == null ? "" : bol.Position);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@DepartmentName", bol.DepartmentName == null ? "" : bol.DepartmentName);
                ObjParm.Add("@ID", 0);
                con.Open();
#pragma warning disable CS0219 // The variable 'Result' is assigned but its value is never used
                string Result = "OK";
#pragma warning restore CS0219 // The variable 'Result' is assigned but its value is never used
                var ResultMsg = con.ExecuteScalar("sp_Resources_SuccessStories_Speech", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = ResultMsg, Message = bol.ID > 0 ? "Succefully updated!" : bol.ID == 0 ? "Succefully saved!" : "Succefully deleted" };
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

        public IQueryable<bol_Resources_Speech> GetResources_Speech(bol_Resources_Speech bol)
        {
            List<bol_Resources_Speech> csetup = new List<bol_Resources_Speech>();
            try
            {

                SqlCommand cmd = new SqlCommand("sp_Resources_SuccessStories_Speech", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Customer_ID", bol.Customer_ID);
                cmd.Parameters.AddWithValue("@ActionTypes", " ");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Speech model = new bol_Resources_Speech();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());

                    model.SpeechText = dr["SpeechText"] == null ? null : dr["SpeechText"].ToString();
                    model.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    model.Position = dr["Position"] == null ? null : dr["Position"].ToString();
                    model.ActionTypes = dr["ActionTypes"] == null ? null : dr["ActionTypes"].ToString();
                    model.GenerateName = dr["GenerateName"] == null ? null : dr["GenerateName"].ToString();
                    model.DepartmentName = dr["DepartmentName"] == null ? null : dr["DepartmentName"].ToString();
                    csetup.Add(model);
                }
                return csetup.ToList().AsQueryable();

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
        #endregion

    }
}

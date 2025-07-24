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
   public class dal_Resources_HowTo
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_Resources_HowTo()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }
        public IQueryable<bol_Resources_HowTo> GetHowToResoures(bol_Resources_HowTo bol)
        {
            List<bol_Resources_HowTo> csetup = new List<bol_Resources_HowTo>();
            try
            {
                
              
                SqlCommand cmd = new SqlCommand("sp_Resources_HowTo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                cmd.Parameters.AddWithValue("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@Title_Eng", bol.Title_Eng);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@Title_MM", bol.Title_MM);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                cmd.Parameters.AddWithValue("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                cmd.Parameters.AddWithValue("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_HowTo model = new bol_Resources_HowTo();
                   model.ID= dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.CategoryID= dr["CategoryID"] == null ? 0 : Convert.ToInt32(dr["CategoryID"].ToString()); 
                    model.Title_Eng = dr["Title_Eng"] == null ? null : dr["Title_Eng"].ToString();
                    model.Title_MM = dr["Title_MM"] == null ? null : dr["Title_MM"].ToString();
                    model.SortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                    model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    model.CreatedBy= dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                    model.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    model.CategoryName_Eng= dr["CategoryName_Eng"] == null ? null : dr["CategoryName_Eng"].ToString();
                    model.CategoryName_MM = dr["CategoryName_MM"] == null ? null : dr["CategoryName_MM"].ToString();
                    model.RelatedPost_Image = dr["RelatedPost_Image"] == null ? null : dr["RelatedPost_Image"].ToString();
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
        public IQueryable<bol_Resources_HowTo> GetHowToResouresByID(bol_Resources_HowTo bol)
        {
            List<bol_Resources_HowTo> csetup = new List<bol_Resources_HowTo>();
            try
            {


                SqlCommand cmd = new SqlCommand("sp_Resources_HowTo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                cmd.Parameters.AddWithValue("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@Title_Eng", bol.Title_Eng);
                cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                cmd.Parameters.AddWithValue("@Title_MM", bol.Title_MM);
                cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                cmd.Parameters.AddWithValue("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                cmd.Parameters.AddWithValue("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_HowTo model = new bol_Resources_HowTo();
                    if (bol.ID == 0 && bol.CategoryID != 0)
                    {
                        model.ID = 0;
                        model.CategoryID = bol.CategoryID;
                        model.CategoryName_Eng = dr["CategoryName_Eng"] == null ? null : dr["CategoryName_Eng"].ToString();
                    }
                    else
                    {
                        model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        model.CategoryID = dr["CategoryID"] == null ? 0 : Convert.ToInt32(dr["CategoryID"].ToString());
                        model.Title_Eng = dr["Title_Eng"] == null ? null : dr["Title_Eng"].ToString();
                        model.Title_MM = dr["Title_MM"] == null ? null : dr["Title_MM"].ToString();
                        model.SortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                        model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                        model.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                        model.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                        model.CategoryName_Eng = dr["CategoryName_Eng"] == null ? null : dr["CategoryName_Eng"].ToString();
                        model.CategoryName_MM = dr["CategoryName_MM"] == null ? null : dr["CategoryName_MM"].ToString();
                        model.Description_Eng = dr["Description_Eng"] == null ? null : dr["Description_Eng"].ToString();
                        model.Description_MM = dr["Description_MM"] == null ? null : dr["Description_MM"].ToString();
                        model.RelatedPost_Image = dr["RelatedPost_Image"] == null ? null : dr["RelatedPost_Image"].ToString();
                    }
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
        public IQueryable<bol_Resources_HowTo> GetHowToCategoryResoures(bol_Resources_HowTo bol)
        {
            List<bol_Resources_HowTo> csetup = new List<bol_Resources_HowTo>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@Title_Eng", bol.Title_Eng);
                ObjParm.Add("@Description_Eng", bol.Description_Eng);
                ObjParm.Add("@Title_MM", bol.Title_MM);
                ObjParm.Add("@Description_MM", bol.Description_MM);
                ObjParm.Add("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                ObjParm.Add("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                ObjParm.Add("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                ObjParm.Add("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                var list = con.Query<bol_Resources_HowTo>("sp_Resources_HowTo", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();

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
        public ResultMsg GetHowToResouresCount(bol_Resources_HowTo bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Resources_HowTo", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                    cmd.Parameters.AddWithValue("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                    cmd.Parameters.AddWithValue("@Description_MM", bol.Description_MM);
                    cmd.Parameters.AddWithValue("@Title_MM", bol.Title_MM);
                    cmd.Parameters.AddWithValue("@Title_Eng", bol.Title_Eng);
                    cmd.Parameters.AddWithValue("@Description_Eng", bol.Description_Eng);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                    cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                    cmd.Parameters.AddWithValue("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                    cmd.Parameters.AddWithValue("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image);
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

        public ResultMsg HowToResouresInsertUpdate(bol_Resources_HowTo bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@Title_Eng", bol.Title_Eng);
                ObjParm.Add("@Description_Eng", bol.Description_Eng);
                ObjParm.Add("@Title_MM", bol.Title_MM);
                ObjParm.Add("@Description_MM", bol.Description_MM);
                ObjParm.Add("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                ObjParm.Add("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                ObjParm.Add("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                ObjParm.Add("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image.Replace("<p>","").Replace("</p>", "").Replace("<br/>", "").Replace("<br>", ""));
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_HowTo", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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

        #region Image Upload
        public IQueryable<bol_Resources_HowToImage> GetHowToResouresImagesList(bol_Resources_HowToImage bol)
        {
            List<bol_Resources_HowToImage> csetup = new List<bol_Resources_HowToImage>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Resources_HowTo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 13);
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@HowToID", bol.HowToID);
                cmd.Parameters.AddWithValue("@CategoryID",0);
                cmd.Parameters.AddWithValue("@SearchText", "");
                cmd.Parameters.AddWithValue("@Title_Eng", "");
                cmd.Parameters.AddWithValue("@Description_Eng", "");
                cmd.Parameters.AddWithValue("@Title_MM", "");
                cmd.Parameters.AddWithValue("@Description_MM", "");
                cmd.Parameters.AddWithValue("@IsActive", false);
                cmd.Parameters.AddWithValue("@SortOrder", 1);
                cmd.Parameters.AddWithValue("@CreatedBy","");
                cmd.Parameters.AddWithValue("@CategoryName_Eng", "");
                cmd.Parameters.AddWithValue("@CategoryName_MM", "");
                cmd.Parameters.AddWithValue("@RelatedPost_Image", "");
                cmd.Parameters.AddWithValue("@PageSkipRows", 0);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_HowToImage model = new bol_Resources_HowToImage();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.HowToID = dr["HowToID"] == null ? 0 : Convert.ToInt32(dr["HowToID"].ToString());
                    model.GroupID = dr["GroupID"] == null ? 0 : Convert.ToInt32(dr["GroupID"].ToString());
                    model.ImagesUrl = dr["ImagesUrl"] == null ? null : dr["ImagesUrl"].ToString();                  
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

        public ResultMsg HowToResouresImageInsert(bol_Resources_HowToImage bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", 15);
                ObjParm.Add("@ID", 0);
                ObjParm.Add("@HowToID", bol.HowToID);
                ObjParm.Add("@CategoryID", 0);
                ObjParm.Add("@SearchText", "");
                ObjParm.Add("@Title_Eng", "");
                ObjParm.Add("@Description_Eng", "");
                ObjParm.Add("@Title_MM", "");
                ObjParm.Add("@Description_MM", "");
                ObjParm.Add("@IsActive", true);
                ObjParm.Add("@SortOrder", 1);
                ObjParm.Add("@CreatedBy", bol.CreatedBy);
                ObjParm.Add("@CategoryName_Eng", "");
                ObjParm.Add("@CategoryName_MM", "");
                ObjParm.Add("@RelatedPost_Image", bol.ImagesUrl);
                ObjParm.Add("@PageSkipRows", 0);
                ObjParm.Add("@PageTakeRows", 10);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_HowTo", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = "Succefully deleted" };
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
        public ResultMsg HowToResouresImageDelete(bol_Resources_HowToImage bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", 14);
                ObjParm.Add("@ID", bol.ID);
                ObjParm.Add("@HowToID", bol.HowToID);
                ObjParm.Add("@CategoryID", 0);
                ObjParm.Add("@SearchText", "");
                ObjParm.Add("@Title_Eng", "");
                ObjParm.Add("@Description_Eng", "");
                ObjParm.Add("@Title_MM", "");
                ObjParm.Add("@Description_MM", "");
                ObjParm.Add("@IsActive", true);
                ObjParm.Add("@SortOrder", 1);
                ObjParm.Add("@CreatedBy", "");
                ObjParm.Add("@CategoryName_Eng", "");
                ObjParm.Add("@CategoryName_MM","");
                ObjParm.Add("@RelatedPost_Image", "");
                ObjParm.Add("@PageSkipRows", 0);
                ObjParm.Add("@PageTakeRows", 10);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_HowTo", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message =  "Succefully deleted" };
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
    }
}

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
    public class dal_Resources_Blog
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_Resources_Blog()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }
        public IQueryable<bol_Resources_Blog> GetBlogResoures(bol_Resources_Blog bol)
        {
            List<bol_Resources_Blog> csetup = new List<bol_Resources_Blog>();
            try
            {


                SqlCommand cmd = new SqlCommand("sp_Resources_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);

                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@Title", bol.Title);
                cmd.Parameters.AddWithValue("@Description", bol.Description);
                cmd.Parameters.AddWithValue("@PublishStatus", bol.PublishStatus);
                cmd.Parameters.AddWithValue("@TopicIDs", bol.TopicIDs);
                cmd.Parameters.AddWithValue("@AuthorIDs", bol.AuthorIDs);
                cmd.Parameters.AddWithValue("@FromDate", bol.FromDate == null ? "" : bol.FromDate);
                cmd.Parameters.AddWithValue("@ToDate", bol.ToDate == null ? "" : bol.ToDate);

                cmd.Parameters.AddWithValue("@IsFeatured", bol.IsFeatured == null ? false : bol.IsFeatured);

                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image);

                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);


                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Blog model = new bol_Resources_Blog();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    model.IsPublish = dr["IsPublish"] == null ? false : Convert.ToBoolean(dr["IsPublish"].ToString());
                    model.IsFeatured = dr["IsFeatured"] == null ? false : Convert.ToBoolean(dr["IsFeatured"].ToString());
                    model.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                    model.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    model.FormattedPublishDate = dr["FormattedPublishDate"] == null ? null : dr["FormattedPublishDate"].ToString();
                    model.RelatedPost_Image = dr["RelatedPost_Image"] == null ? null : dr["RelatedPost_Image"].ToString();
                    model.TopicIDs = dr["TopicIDs"] == null ? null : dr["TopicIDs"].ToString();
                    model.TopicNames = dr["TopicNames"] == null ? null : dr["TopicNames"].ToString();
                    model.AuthorIDs = dr["AuthorIDs"] == null ? null : dr["AuthorIDs"].ToString();
                    model.AuthorNames = dr["AuthorNames"] == null ? null : dr["AuthorNames"].ToString();
                    model.Blog_ID = dr["Blog_ID"] == null ? null : dr["Blog_ID"].ToString();
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

        public ResultMsg GetBlogResouresCount(bol_Resources_Blog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Resources_Blog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                    cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);

                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                    cmd.Parameters.AddWithValue("@FromDate", bol.FromDate == null ? "" : bol.FromDate);
                    cmd.Parameters.AddWithValue("@ToDate", bol.ToDate == null ? "" : bol.ToDate);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@PublishStatus", bol.PublishStatus);
                    cmd.Parameters.AddWithValue("@TopicIDs", bol.TopicIDs);
                    cmd.Parameters.AddWithValue("@AuthorIDs", bol.AuthorIDs);

                    cmd.Parameters.AddWithValue("@IsFeatured", bol.IsFeatured == null ? false : bol.IsFeatured);

                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
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
        public IQueryable<bol_Resources_Blog> GetBlogResouresByID(bol_Resources_Blog bol)
        {
            List<bol_Resources_Blog> csetup = new List<bol_Resources_Blog>();
            try
            {


                SqlCommand cmd = new SqlCommand("sp_Resources_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

                cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);

                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@Title", bol.Title);
                cmd.Parameters.AddWithValue("@Description", bol.Description);
                cmd.Parameters.AddWithValue("@TopicIDs", bol.TopicIDs);
                cmd.Parameters.AddWithValue("@AuthorIDs", bol.AuthorIDs);

                cmd.Parameters.AddWithValue("@IsFeatured", bol.IsFeatured == null ? false : bol.IsFeatured);

                cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                cmd.Parameters.AddWithValue("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image);

                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);


                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Blog model = new bol_Resources_Blog();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    model.Description = dr["Descriptions"] == null ? null : dr["Descriptions"].ToString();
                    model.BriefDescription = dr["BriefDescription"] == null ? null : dr["BriefDescription"].ToString();
                    model.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    model.IsPublish = dr["IsPublish"] == null ? false : Convert.ToBoolean(dr["IsPublish"].ToString());
                    model.TopicIDs = dr["TopicIDs"] == null ? null : dr["TopicIDs"].ToString();
                    model.TopicNames = dr["TopicNames"] == null ? null : dr["TopicNames"].ToString();
                    model.AuthorIDs = dr["AuthorIDs"] == null ? null : dr["AuthorIDs"].ToString();
                    model.AuthorNames = dr["AuthorNames"] == null ? null : dr["AuthorNames"].ToString();
                    model.IsFeatured = dr["IsFeatured"] == null ? false : Convert.ToBoolean(dr["IsFeatured"].ToString());
                    model.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                    model.Blog_ID = dr["Blog_ID"] == null ? null : dr["Blog_ID"].ToString();
                    model.FormattedPublishDate = dr["FormattedPublishDate"] == null ? null : dr["FormattedPublishDate"].ToString();
                    

                    if (dr["PublishDate"]!=null && dr["PublishDate"] != DBNull.Value)
                    {
                        model.PublishDate = Convert.ToDateTime(dr["PublishDate"]);
                    }
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
       
        public ResultMsg BlogResouresInsertUpdate(bol_Resources_Blog bol)
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
                ObjParm.Add("@Title", bol.Title);
                ObjParm.Add("@Description", bol.Description);
                ObjParm.Add("@BriefDescription", bol.BriefDescription);
                ObjParm.Add("@PublishDate", bol.IsPublish == true?bol.FormattedCreatedDate : "");
                ObjParm.Add("@PostStatus", bol.PostStatus);
                ObjParm.Add("@TopicIDs", bol.TopicIDs);
                ObjParm.Add("@ImageListID",bol.ImageListID);
                ObjParm.Add("@AuthorIDs", bol.AuthorIDs);
                ObjParm.Add("@Blog_ID", bol.Blog_ID);

                ObjParm.Add("@IsFeatured", bol.IsFeatured == null ? false : bol.IsFeatured);


                ObjParm.Add("@IsActive", bol.IsFeatured == null ? false : bol.IsActive);


                ObjParm.Add("@IsPublish", bol.IsPublish == null ? false : bol.IsPublish);

                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image.Replace("<p>", "").Replace("</p>", "").Replace("<br/>", "").Replace("<br>", ""));

                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);


                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);

                con.Open();
#pragma warning disable CS0219 // The variable 'Result' is assigned but its value is never used
                string Result = "OK";
#pragma warning restore CS0219 // The variable 'Result' is assigned but its value is never used
                var ResultMsg = con.ExecuteScalar("sp_Resources_Blog", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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
        public ResultMsg BlogResouresDelete(bol_Resources_Blog bol)
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
                ObjParm.Add("@Title", bol.Title);
                ObjParm.Add("@Description", bol.Description);
                ObjParm.Add("@PublishDate", DateTime.Now);
                ObjParm.Add("@TopicIDs", bol.TopicIDs);

                ObjParm.Add("@IsFeatured", bol.IsFeatured == null ? false : bol.IsFeatured);


                ObjParm.Add("@IsActive", bol.IsFeatured == null ? false : bol.IsActive);


                ObjParm.Add("@IsPublish", bol.IsFeatured == null ? false : bol.IsPublish);

                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@RelatedPost_Image", bol.RelatedPost_Image == null ? "" : bol.RelatedPost_Image.Replace("<p>", "").Replace("</p>", "").Replace("<br/>", "").Replace("<br>", ""));

                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);


                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);

                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_Blog", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message =  "Succefully deleted!"};
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

        public IQueryable<bol_Resources_Author> GetResourcesBlogAuthor(int ActionParam)
        {
            List<bol_Resources_Author> csetup = new List<bol_Resources_Author>();
            try
            {


                SqlCommand cmd = new SqlCommand("sp_Resources_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@SearchText", "");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Author model = new bol_Resources_Author();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.AuthorName = dr["AuthorName"] == null ? null : dr["AuthorName"].ToString();
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

        public IQueryable<bol_Resources_Topic> GetResourcesBlogTopic(int ActionParam)
        {
            List<bol_Resources_Topic> csetup = new List<bol_Resources_Topic>();
            try
            {


                SqlCommand cmd = new SqlCommand("sp_Resources_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@SearchText", "");
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_Topic model = new bol_Resources_Topic();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.Name = dr["TopicName"] == null ? null : dr["TopicName"].ToString();
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


        #region Image Upload
        public IQueryable<bol_Resources_BlogImage> GetBlogResouresImagesList(bol_Resources_BlogImage bol)
        {
            List<bol_Resources_BlogImage> csetup = new List<bol_Resources_BlogImage>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_Resources_Blog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 6);
                cmd.Parameters.AddWithValue("@ID", 0);
                cmd.Parameters.AddWithValue("@BlogID", bol.BlogID);
                cmd.Parameters.AddWithValue("@PageSkipRows", 0);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Resources_BlogImage model = new bol_Resources_BlogImage();
                    model.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    model.BlogID = dr["BlogID"] == null ? 0 : Convert.ToInt32(dr["BlogID"].ToString());
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

        public ResultMsg BlogResouresImageInsert(bol_Resources_BlogImage bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", 8);
                ObjParm.Add("@ID", 0);
                ObjParm.Add("@BlogID", bol.BlogID);
                ObjParm.Add("@CreatedBy", bol.CreatedBy);
                ObjParm.Add("@RelatedPost_Image", bol.ImagesUrl);
                ObjParm.Add("@PageSkipRows", 0);
                ObjParm.Add("@PageTakeRows", 10);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_Blog", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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
        public ResultMsg BlogResouresImageDelete(bol_Resources_BlogImage bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", 7);
                ObjParm.Add("@ID", bol.ID);
                ObjParm.Add("@BlogID", bol.BlogID);
                ObjParm.Add("@CreatedBy", "");
                ObjParm.Add("@RelatedPost_Image","");
                ObjParm.Add("@PageSkipRows", 0);
                ObjParm.Add("@PageTakeRows", 10);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_Resources_Blog", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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
        #endregion
    }
}

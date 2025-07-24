using BOL;
using BOL.NOTI;
using BOL.WebNoti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WebNoti
{
    public class dal_WebNOTI_Template
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_WebNOTI_Template() { }

        public IEnumerable<bol_WebNOTI_Template> GetList(bol_WebNOTI_Template bol)
        {
            List<bol_WebNOTI_Template> templates = new List<bol_WebNOTI_Template>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                //cmd.Parameters.AddWithValue("@Content", bol.Content);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_Template tmp = new bol_WebNOTI_Template();
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    templates.Add(tmp);
                }
            }
            return templates;
        }

        public IEnumerable<bol_WebNOTI_TemplateV2> GetListV2(bol_WebNOTI_TemplateV2 bol)
        {
            List<bol_WebNOTI_TemplateV2> templates = new List<bol_WebNOTI_TemplateV2>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                //cmd.Parameters.AddWithValue("@Content", bol.Content);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WebNOTI_TemplateV2 tmp = new bol_WebNOTI_TemplateV2();
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    tmp.PromoImageUrl = dr["PromoImageUrl"] == null ? null : dr["PromoImageUrl"].ToString();
                    tmp.TxnImageUrl = dr["TxnImageUrl"] == null ? null : dr["TxnImageUrl"].ToString();
                    tmp.InfoImageUrl = dr["InfoImageUrl"] == null ? null : dr["InfoImageUrl"].ToString();
                    tmp.IDType = dr["IDType"] == null ? null : dr["IDType"].ToString();
                    tmp.PromoUrl = dr["PromoUrl"] == null ? null : dr["PromoUrl"].ToString();
                    templates.Add(tmp);
                }
            }
            return templates;
        }

        public bol_WebNOTI_Template GetByID(bol_WebNOTI_Template bol)
        {
            bol_WebNOTI_Template tmp = new bol_WebNOTI_Template();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    tmp.PromoUrl = dr["PromoUrl"] == null ? null : dr["PromoUrl"].ToString();
                    tmp.InfoImageUrl = dr["InfoImageUrl"] == null ? null : dr["InfoImageUrl"].ToString();
                    tmp.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                }
            }
            return tmp;
        }

        public ResultMsg Insert(bol_WebNOTI_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
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


        public ResultMsg Update(bol_WebNOTI_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@ModifiedDate", bol.ModifiedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", bol.ModifiedBy);
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

        public ResultMsg GetWebNotiCount(bol_WebNOTI_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Connection = con;
                    con.Open();
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

        public ResultMsg InsertV2(bol_WebNOTI_TemplateV2 bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@PromoImageUrl", bol.PromoImageUrl);
                    cmd.Parameters.AddWithValue("@TxnImageUrl", bol.TxnImageUrl);
                    cmd.Parameters.AddWithValue("@InfoImageUrl", bol.InfoImageUrl);
                    cmd.Parameters.AddWithValue("@PromoUrl", bol.PromoUrl);
                    cmd.Parameters.AddWithValue("@BodyDetail", bol.BodyDetail);
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

        public ResultMsg UpdateV2(bol_WebNOTI_TemplateV2 bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@ModifiedDate", bol.ModifiedDate);
                    cmd.Parameters.AddWithValue("@ModifiedBy", bol.ModifiedBy);
                    //cmd.Parameters.AddWithValue("@PromoImageUrl", bol.PromoImageUrl);
                    //cmd.Parameters.AddWithValue("@TxnImageUrl", bol.TxnImageUrl);
                    //cmd.Parameters.AddWithValue("@InfoImageUrl", bol.InfoImageUrl);
                    cmd.Parameters.AddWithValue("@PromoUrl", bol.PromoUrl);
                    cmd.Parameters.AddWithValue("@BodyDetail", bol.BodyDetail);
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

        public bol_WebNOTI_TemplateV2 GetByIDV2(bol_WebNOTI_TemplateV2 bol)
        {
            bol_WebNOTI_TemplateV2 tmp = new bol_WebNOTI_TemplateV2();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    //tmp.PromoImageUrl = dr["PromoImageUrl"] == null ? null : dr["PromoImageUrl"].ToString();
                    //tmp.TxnImageUrl = dr["TxnImageUrl"] == null ? null : dr["TxnImageUrl"].ToString();
                    tmp.InfoImageUrl = dr["InfoImageUrl"] == null ? null : dr["InfoImageUrl"].ToString();
                    tmp.PromoUrl = dr["PromoUrl"] == null ? null : dr["PromoUrl"].ToString();
                    tmp.BodyDetail = dr["BodyDetail"] == null ? null : dr["BodyDetail"].ToString();
                }
            }
            return tmp;
        }

        public bol_WebNOTI_TemplateV2 GetCategory(bol_WebNOTI_TemplateV2 bol)
        {
            bol_WebNOTI_TemplateV2 tmp = new bol_WebNOTI_TemplateV2();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                }
            }
            return tmp;
        }

        public ResultMsg UpdateNotiInfoImage(bol_WebNOTI_TemplateV2 bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@InfoImageUrl", bol.InfoImageUrl);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Connection = con;
                    con.Open();
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

        public bol_WebNOTI_Template GetTemplateByName(bol_WebNOTI_Template bol)
        {
            bol_WebNOTI_Template tmp = new bol_WebNOTI_Template();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 13);
                cmd.Parameters.AddWithValue("@Name", bol.Name);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                   
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                   
                }
            }
            return tmp;
        }

        public bol_WebNOTI_Template GetWebNotiTemplateBySubType(bol_WebNOTI_Template bol)
        {
            bol_WebNOTI_Template tmp = new bol_WebNOTI_Template();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Web_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 14);
                cmd.Parameters.AddWithValue("@SearchText", bol.Name);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());

                }
            }
            return tmp;
        }

        public bol_WebNOTI_Owner GetNotiOwner(bol_WebNOTI_Owner bol)
        {
            bol_WebNOTI_Owner tmp = new bol_WebNOTI_Owner();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BS_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 12);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                }
            }
            return tmp;
        }

    }
}

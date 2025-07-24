using BOL;
using BOL.EMN;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EMN
{
    public class dal_EMN_Template
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_EMN_Template() { }

        public IEnumerable<bol_EMN_Template> GetList(bol_EMN_Template bol)
        {
            List<bol_EMN_Template> templates = new List<bol_EMN_Template>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_EMN_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@SearchType", bol.Type);
                cmd.Parameters.AddWithValue("@SearchSubType", bol.SubType);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);

                //cmd.Parameters.AddWithValue("@Content", bol.Content);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMN_Template tmp = new bol_EMN_Template();
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.TypeID = dr["TypeID"] == DBNull.Value ? 0 : int.Parse(dr["TypeID"].ToString());
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    tmp.ReminderType = dr["ReminderType"] == null ? null : dr["ReminderType"].ToString();
                    templates.Add(tmp);
                }
            }
            return templates;


        }

        public bol_EMN_Template GetByID(bol_EMN_Template bol)
        {
            bol_EMN_Template tmp = new bol_EMN_Template();
            
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_EMN_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    tmp.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    tmp.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.TypeID = dr["TypeID"] == DBNull.Value ? 0 : int.Parse(dr["TypeID"].ToString());
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    tmp.FromEmailAddress = dr["FromEmailAddress"] == null ? null : dr["FromEmailAddress"].ToString();
                    tmp.FromEmailPassword = dr["Password"] == null ? null : dr["Password"].ToString();
                    tmp.ReminderType = dr["ReminderType"] == null ? null : dr["ReminderType"].ToString();
                }
            }
        
            return tmp;
        }

        public ResultMsg Insert(bol_EMN_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Type", bol.SubType);
                    //cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@ReminderType", bol.ReminderType);
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


        public ResultMsg Update(bol_EMN_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@Content", bol.Content);
                    cmd.Parameters.AddWithValue("@Type", bol.SubType);
                    //cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@ReminderType", bol.ReminderType);
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

        public ResultMsg GetEMNCount(bol_EMN_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@SearchType", bol.Type);
                    cmd.Parameters.AddWithValue("@SearchSubType", bol.SubType);
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

        public IEnumerable<bol_EMN_Template> EMN_TemplateData(string TemplateName)
        {
            List<bol_EMN_Template> data = new List<bol_EMN_Template>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_EMN_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 8);
                cmd.Parameters.AddWithValue("@SearchText", TemplateName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMN_Template emndata = new bol_EMN_Template();
                    //emndata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    emndata.Name = dr["TemplateName"] == null ? null : dr["TemplateName"].ToString();
                    emndata.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    emndata.Title = dr["EmailSubject"] == null ? null : dr["EmailSubject"].ToString();
                    emndata.Content = dr["EmailBody"] == null ? null : dr["EmailBody"].ToString();
                    emndata.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    emndata.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    emndata.ReminderType = dr["ReminderType"] == null ? null : dr["ReminderType"].ToString();
                  //  emndata.TypeID = dr["TypeID"] == DBNull.Value ? 0 : int.Parse(dr["TypeID"].ToString());
                    emndata.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    emndata.FromEmailAddress = dr["FromEmailAddress"] == null ? null : dr["FromEmailAddress"].ToString();
                    emndata.FromEmailPassword = dr["Password"] == null ? null : dr["Password"].ToString();
                    data.Add(emndata);
                }
            }

            return data;
        }
        #region[EMN Temp Attached File]
    
        public ResultMsg InsertEMNTempAttachedFile(bol_EMN_Temp_Attached bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Temp_Attached", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@AttachedFile", bol.AttachedFile);
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

        public IEnumerable<bol_EMN_Temp_Attached> GetEMNTempAttachedFile(bol_EMN_Temp_Attached bol)
        {
            List<bol_EMN_Temp_Attached> templates = new List<bol_EMN_Temp_Attached>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_EMN_Temp_Attached", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMN_Temp_Attached tmp = new bol_EMN_Temp_Attached();
                    tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    tmp.AttachedFile = dr["AttachedFile"] == null ? null : dr["AttachedFile"].ToString();
                    tmp.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                    tmp.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                    templates.Add(tmp);
                }
            }
            return templates;


        }

        public ResultMsg DeleteEMNTempAttachedFile(bol_EMN_Temp_Attached bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EMN_Temp_Attached", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
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

        #endregion
    }
}

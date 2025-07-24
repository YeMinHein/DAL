using BOL;
using BOL.SMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SMS
{
    public class dal_SMS_Template
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_SMS_Template() { }

        public IEnumerable<bol_SMS_Template> GetList(bol_SMS_Template bol)
        {
            List<bol_SMS_Template> templates = new List<bol_SMS_Template>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SMS_Template", con);
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
                        bol_SMS_Template tmp = new bol_SMS_Template();
                        tmp.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                        tmp.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        tmp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                        tmp.Message = dr["Message"] == null ? null : dr["Message"].ToString();
                        tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                        tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                        tmp.TypeID = dr["TypeID"] == DBNull.Value ? 0 : int.Parse(dr["TypeID"].ToString());
                        tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                        templates.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            return templates;


        }

        public bol_SMS_Template GetByID(bol_SMS_Template bol)
        {
            bol_SMS_Template tmp = new bol_SMS_Template();
            
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SMS_Template", con);
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
                    tmp.Message = dr["Message"] == null ? null : dr["Message"].ToString();
                    tmp.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    tmp.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    tmp.TypeID = dr["TypeID"] == DBNull.Value ? 0 : int.Parse(dr["TypeID"].ToString());
                    tmp.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    //tmp.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                   
                }
            }
        
            return tmp;
        }

        public ResultMsg Insert(bol_SMS_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SMS_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Message", bol.Message);
                    cmd.Parameters.AddWithValue("@Type", bol.SubType);
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


        public ResultMsg Update(bol_SMS_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SMS_Template", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@Message", bol.Message);
                    cmd.Parameters.AddWithValue("@Type", bol.SubType);
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

        public ResultMsg GetSMSCount(bol_SMS_Template bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SMS_Template", con);
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

        public IEnumerable<bol_SMS_Template> SMS_TemplateData(string TemplateName)
        {
            List<bol_SMS_Template> data = new List<bol_SMS_Template>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SMS_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 8);
                cmd.Parameters.AddWithValue("@SearchText", TemplateName);
                cmd.Connection = con;
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMS_Template smsdata = new bol_SMS_Template();
                    smsdata.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    smsdata.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    smsdata.Message = dr["Message"] == null ? null : dr["Message"].ToString();
                    smsdata.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    smsdata.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    smsdata.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    data.Add(smsdata);
                }
            }

            return data;
        }

    }
}

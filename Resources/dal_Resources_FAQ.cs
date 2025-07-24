using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using BOL.Resources;
using Dapper;

namespace DAL.Resources
{
   public class dal_Resources_FAQ
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_Resources_FAQ()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }
        public IQueryable<bol_Resources_FAQ> GetFAQResoures(bol_Resources_FAQ bol)
        {
            List<bol_Resources_FAQ> csetup = new List<bol_Resources_FAQ>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@Question_MM", bol.Question_MM);
                ObjParm.Add("@Question_Eng", bol.Question_Eng);
                ObjParm.Add("@Answer_Eng", bol.Answer_Eng);
                ObjParm.Add("@Answer_MM", bol.Answer_MM);
                ObjParm.Add("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                ObjParm.Add("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                ObjParm.Add("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                ObjParm.Add("@Tags", bol.Tags == null ? "" : bol.Tags);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                var list = con.Query<bol_Resources_FAQ>("sp_FAQ", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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
        public ResultMsg GetFAQResouresCount(bol_Resources_FAQ bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_FAQ", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID == null ? 0 : bol.ID);
                    cmd.Parameters.AddWithValue("@CategoryID", bol.CategoryID == null ? 0 : bol.CategoryID);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                    cmd.Parameters.AddWithValue("@Question_MM", bol.Question_MM);
                    cmd.Parameters.AddWithValue("@Question_Eng", bol.Question_Eng);
                    cmd.Parameters.AddWithValue("@Answer_Eng", bol.Answer_Eng);
                    cmd.Parameters.AddWithValue("@Answer_MM", bol.Answer_MM);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                    cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                    cmd.Parameters.AddWithValue("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                    cmd.Parameters.AddWithValue("@Tags", bol.Tags == null ? "" : bol.Tags);
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

        public ResultMsg FAQResouresInsertUpdate(bol_Resources_FAQ bol)
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
                ObjParm.Add("@Question_MM", bol.Question_MM);
                ObjParm.Add("@Question_Eng", bol.Question_Eng);
                ObjParm.Add("@Answer_Eng", bol.Answer_Eng);
                ObjParm.Add("@Answer_MM", bol.Answer_MM);
                ObjParm.Add("@IsActive", bol.IsActive == null ? false : bol.IsActive);
                ObjParm.Add("@SortOrder", bol.SortOrder == null ? 0 : bol.SortOrder);
                ObjParm.Add("@IsTopQuestion", bol.IsTopQuestion == null ? false : bol.IsTopQuestion);
                ObjParm.Add("@TopQSortOrder", bol.TopQSortOrder == null ? 0 : bol.TopQSortOrder);
                ObjParm.Add("@CreatedBy", bol.CreatedBy == null ? "" : bol.CreatedBy);
                ObjParm.Add("@CategoryName_Eng", bol.CategoryName_Eng == null ? "" : bol.CategoryName_Eng);
                ObjParm.Add("@CategoryName_MM", bol.CategoryName_MM == null ? "" : bol.CategoryName_MM);
                ObjParm.Add("@Tags", bol.Tags == null ? "" : bol.Tags);
                ObjParm.Add("@PageSkipRows", bol.PageSkipsRows == null ? 0 : bol.PageSkipsRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_FAQ", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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
    }
}

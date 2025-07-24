using BOL;
using BOL.WDM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WDM
{
   public class dal_WDM_Interest
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_WDM_Interest()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        #region Interest
        public IQueryable<bol_WDM_Interest> GetInterestList(bol_WDM_Interest bol)
        {
            List<bol_WDM_Interest> csetup = new List<bol_WDM_Interest>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@actionParam", bol.actionParam);
                ObjParm.Add("@StartDate", bol.StartDate == null ? DateTime.Now : bol.StartDate);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@EndDate", bol.EndDate == null ? DateTime.Now : bol.EndDate);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Category", bol.Category);
                ObjParm.Add("@ServiceBasePlanID", bol.ServiceBasePlanID);
                ObjParm.Add("@CityId", bol.CityId);
                con.Open();
                var list = con.Query<bol_WDM_Interest>("sp_SalesContact", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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

        public ResultMsg GetInsterestCount(bol_WDM_Interest bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SalesContact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", bol.actionParam);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate == null ? DateTime.Now : bol.StartDate);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);                   
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate == null ? DateTime.Now : bol.EndDate);
                    cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                    cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                    cmd.Parameters.AddWithValue("@Category", bol.Category);
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", bol.ServiceBasePlanID);
                    cmd.Parameters.AddWithValue("@CityId", bol.CityId);
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

        #region LTE Interest
        public IQueryable<bol_WDM_Interest> GetLTEInterestList(bol_WDM_Interest bol)
        {
            List<bol_WDM_Interest> csetup = new List<bol_WDM_Interest>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@actionParam", 3);
                ObjParm.Add("@StartDate", bol.StartDate == null ? DateTime.Now : bol.StartDate);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@EndDate", bol.EndDate == null ? DateTime.Now : bol.EndDate);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@Category", bol.Category);
                ObjParm.Add("@ServiceBasePlanID", bol.ServiceBasePlanID);
                ObjParm.Add("@CityId", bol.CityId);
                con.Open();
                var list = con.Query<bol_WDM_Interest>("sp_LTE_Interest", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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

        public ResultMsg GetLTEInsterestCount(bol_WDM_Interest bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_LTE_Interest", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@actionParam", 4);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate == null ? DateTime.Now : bol.StartDate);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate == null ? DateTime.Now : bol.EndDate);
                    cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                    cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                    cmd.Parameters.AddWithValue("@Category", bol.Category);
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", bol.ServiceBasePlanID);
                    cmd.Parameters.AddWithValue("@CityId", bol.CityId);
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

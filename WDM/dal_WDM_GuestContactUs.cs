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
   public class dal_WDM_GuestContactUs
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_WDM_GuestContactUs()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        #region ContactUs
        public IQueryable<bol_WDM_GuestContactUs> GetContactUsList(bol_WDM_GuestContactUs bol)
        {
            List<bol_WDM_GuestContactUs> csetup = new List<bol_WDM_GuestContactUs>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@actionParam", bol.ActionParam);
                ObjParm.Add("@Name", bol.Name == null ? "" : bol.Name);
                ObjParm.Add("@startDate", bol.FromDate == null ? "" : bol.FromDate);
                ObjParm.Add("@endDate", bol.ToDate == null ? "" : bol.ToDate);
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@AssignedStatus", bol.AssignedStatus);
                ObjParm.Add("@AssignedGroup", bol.AssignedGroup);
                con.Open();
                var list = con.Query<bol_WDM_GuestContactUs>("sp_GuestContact", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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

        public int GetContactUsListCount(bol_WDM_GuestContactUs bol)
        {

            try
            {

                SqlCommand cmd = new SqlCommand("sp_GuestContact", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Name", bol.Name == null ? "" : bol.Name);
                cmd.Parameters.AddWithValue("@startDate", bol.FromDate);
                cmd.Parameters.AddWithValue("@endDate", bol.ToDate);
                cmd.Parameters.AddWithValue("@AssignedStatus", bol.AssignedStatus);
                cmd.Parameters.AddWithValue("@AssignedGroup", bol.AssignedGroup);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return 0;
        }
        #endregion

        #region GetCountactUsStatus
        public IQueryable<bol_WDM_GuestContactUs_Status> GetContactUsStatusList(bol_WDM_GuestContactUs_Status bol)
        {
            List<bol_WDM_GuestContactUs_Status> csetup = new List<bol_WDM_GuestContactUs_Status>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@actionParam", bol.ActionParam);
                ObjParm.Add("@GuestContact_ID", bol.GuestContact_ID == null ? 0 : bol.GuestContact_ID);
                ObjParm.Add("@Status", bol.Status == null ? "" : bol.Status);
                ObjParm.Add("@AssignedGroup", bol.AssignedGroup == null ? "" : bol.AssignedGroup);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@LoggedBy", bol.LoggedBy == null ? "" : bol.LoggedBy);
                ObjParm.Add("@LoggedDate", bol.LoggedDate==null ? DateTime.Now:bol.LoggedDate);
                con.Open();
                var list = con.Query<bol_WDM_GuestContactUs_Status>("sp_GuestContactStatus", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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
        public ResultMsg ContactUsStatusInsert(bol_WDM_GuestContactUs_Status bol)
        {
            string resp_code = "";
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@actionParam", bol.ActionParam);
                ObjParm.Add("@GuestContact_ID", bol.GuestContact_ID == null ? 0 : bol.GuestContact_ID);
                ObjParm.Add("@Status", bol.Status == null ? "" : bol.Status);
                ObjParm.Add("@AssignedGroup", bol.AssignedGroup == null ? "" : bol.AssignedGroup);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@LoggedBy", bol.LoggedBy == null ? "" : bol.LoggedBy);
                ObjParm.Add("@LoggedDate", bol.LoggedDate);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_GuestContactStatus", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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
        #endregion
    }
}

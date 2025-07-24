using BOL;
using BOL.General;
using BOL.MobileView;
using BOL.PROMO;
using BOL.WDM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MobileView
{
    public class dal_MobileView
    {
        //string conn_str = dal_ConfigManager.GTG;
        //ResultMsg result = new ResultMsg();

        //public dal_WDM_SAForm() {
        //}

        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_MobileView()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        #region[SPS]
    
        public async Task<IQueryable<bol_MobileViewListResModel>> GetMobileViewList(bol_MobileViewListResModel bol)
        {
            List<bol_MobileViewListResModel> csetups = new List<bol_MobileViewListResModel>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@City", bol.City);
                ObjParm.Add("@BuildingType", bol.BuildingName);
                ObjParm.Add("@Channel", bol.Channel);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@PromoPlanID", bol.PromoPlanID);
                ObjParm.Add("@PageSkipRows", bol.PageIndex);
                ObjParm.Add("@PageTakeRows", 10);
                ObjParm.Add("@FinanceUser", bol.FinanceUser);
                ObjParm.Add("@IsSPSEngineer", bol.IsSPSEngineer);
                ObjParm.Add("@IsOnlyMe", bol.IsOnlyMe);
                ObjParm.Add("@SolvedBy", bol.SolvedBy);
                ObjParm.Add("@Status", bol.Status);
                ObjParm.Add("@SuspendID", bol.SuspendID);
                ObjParm.Add("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@UserName", bol.UserName);
                con.Open();
                var result = await SqlMapper.QueryAsync<bol_MobileViewListResModel>(
                                 con, "sp_SPS_WDM_SAForm",
                 ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                return result.AsQueryable();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return csetups.AsQueryable();
        }

        public string dal_GetRolebyUserName(string UserName)
        {
            string role = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_General", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 52);
                    cmd.Parameters.AddWithValue("@UserName", UserName);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                       role = dr["Name"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {


            }
            return role;
        }

        #endregion

    }
}

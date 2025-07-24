using BOL;
using BOL.LSM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LSM
{
    public class dal_LSM
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public IEnumerable<bol_LSM_GetLTERegionList> dal_LSM_GetLTERegionList(bol_LSM_GetLTERegionList bol)
        {
            List<bol_LSM_GetLTERegionList> lrls = new List<bol_LSM_GetLTERegionList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_LSM_GetLTERegionList lrl = new bol_LSM_GetLTERegionList();
                    lrl.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    lrl.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    lrls.Add(lrl);
                }
            }
            return lrls;

        }
        public IEnumerable<bol_LSM_GetLTEPlanList> dal_LSM_GetLTEPlanList(bol_LSM_GetLTEPlanList bol)
        {
            List<bol_LSM_GetLTEPlanList> lpls = new List<bol_LSM_GetLTEPlanList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_LSM_GetLTEPlanList lpl = new bol_LSM_GetLTEPlanList();
                    lpl.planId = dr["planId"] == null ? null : dr["planId"].ToString();
                    lpl.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    lpl.LabelColor = dr["LabelColor"] == null ? null : dr["LabelColor"].ToString();
                    lpls.Add(lpl);
                }
            }
            return lpls;


        }
        public bol_LSM_GetLTEPlanList dal_LSM_GetLTERechargePlanList(bol_LSM_GetLTEPlanList bol)
        {
            List<bol_LSM_GetLTEPlanList> lpls = new List<bol_LSM_GetLTEPlanList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_LSM_GetLTEPlanList lpl = new bol_LSM_GetLTEPlanList();
                    lpl.RechargeId = dr["RechargeId"] == null ? null : dr["RechargeId"].ToString();
                    lpl.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    lpl.LabelColor = dr["LabelColor"] == null ? null : dr["LabelColor"].ToString();
                    lpls.Add(lpl);
                }
                bol.lstLTERechargePlan = lpls;
            }
            return bol;


        }
        

        public IEnumerable<bol_LSM_GetSaveRegionPlanList> dal_LSM_GetSaveRegionRechargePlanList(bol_LSM_GetSaveRegionPlanList bol)
        {
            List<bol_LSM_GetSaveRegionPlanList> srpls = new List<bol_LSM_GetSaveRegionPlanList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_LSM_GetSaveRegionPlanList srpl = new bol_LSM_GetSaveRegionPlanList();
                    srpl.RegionID = dr["RegionID"] == null ? 0 : Convert.ToInt32(dr["RegionID"].ToString());
                    srpl.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    srpl.RechargeId = dr["RechargeId"] == null ? null : dr["RechargeId"].ToString();
                    srpl.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    srpl.LabelColor = dr["LabelColor"] == null ? null : dr["LabelColor"].ToString();
                    srpls.Add(srpl);
                }
            }
            return srpls;


        }

        public ResultMsg Save_LTERechargePlanSetting(bol_LSM_SaveRechargePlanSetting bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@RegionID", bol.RegionID == null ? 0 : bol.RegionID);
                ObjParm.Add("@ServiceBasePlanID", bol.ServiceBasePlanID == null ? 0 : bol.ServiceBasePlanID);
                ObjParm.Add("@Label", bol.Label == null ? "" : bol.Label);
                ObjParm.Add("@CreatedBy", bol.@CreatedBy);
                ObjParm.Add("@CreatedDate", bol.CreatedDate == null ? "" : bol.CreatedDate);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_LTE_Recharge", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = "Succefully saved!" };
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
        public IEnumerable<bol_LSM_GetLTELabel> GetLTERechargeLabel(bol_LSM_GetLTELabel bol)
        {
            List<bol_LSM_GetLTELabel> csetups = new List<bol_LSM_GetLTELabel>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                    cmd.Parameters.AddWithValue("@ServiceBasePlanID", bol.ServiceBasePlanID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_LSM_GetLTELabel csetup = new bol_LSM_GetLTELabel();
                        csetup.Label = dr["Label"] == null ? "" : dr["Label"].ToString();
                        csetups.Add(csetup);
                    }
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
            }
            return csetups;
        }

        public ResultMsg GetLTERechargePlanSettingCount(bol_LSM_GetSaveRegionPlanList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
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
        public IEnumerable<bol_LSM_GetSaveRegionPlanList> GetLTERechargePlanSettingList(bol_LSM_GetSaveRegionPlanList bol)
        {
            List<bol_LSM_GetSaveRegionPlanList> saforms = new List<bol_LSM_GetSaveRegionPlanList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_LSM_GetSaveRegionPlanList saform = new bol_LSM_GetSaveRegionPlanList();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    saform.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    saform.Label = dr["Label"] == null ? null : dr["Label"].ToString();                    
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public ResultMsg DeleteLTERechargePlan(bol_LSM_GetSaveRegionPlanList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_LTE_Recharge", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
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

    }
}

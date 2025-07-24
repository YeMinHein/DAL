using BOL;
using BOL.SVM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SVM
{
    public class dal_SVM_PlanChangeForm
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_SVM_PlanChangeForm() { }

        public ResultMsg GetPlanChangeFormCount(bol_SVM_PlanChangeForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SVM_PlanChange", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@source", bol.source);
                    cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                    cmd.Parameters.AddWithValue("@IsSolved", bol.lstIsSolved);
                    cmd.Parameters.AddWithValue("@EffectiveDate", bol.effectiveDate);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
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
        public IEnumerable<bol_SVM_PlanChangeForm> GetPlanChangeList(bol_SVM_PlanChangeForm bol)
        {
            List<bol_SVM_PlanChangeForm> saforms = new List<bol_SVM_PlanChangeForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SVM_PlanChange", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@source", bol.source);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                cmd.Parameters.AddWithValue("@IsSolved", bol.lstIsSolved);
                cmd.Parameters.AddWithValue("@EffectiveDate", bol.effectiveDate);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SVM_PlanChangeForm saform = new bol_SVM_PlanChangeForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    saform.CurrentUsingPlanID = dr["CurrentUsingPlanID"] == DBNull.Value ? 0 : int.Parse(dr["CurrentUsingPlanID"].ToString());
                    saform.CurrentUsingServicePlan = dr["CurrentUsingPlan"] == null ? null : dr["CurrentUsingPlan"].ToString();
                    saform.ToChangePlanID = dr["ToChangePlanID"] == DBNull.Value ? 0 : int.Parse(dr["ToChangePlanID"].ToString());
                    saform.ToChangeServicePlan = dr["ToChangePlan"] == null ? null : dr["ToChangePlan"].ToString();
                    saform.CustPhoneNo = dr["CustPhoneNo"] == null ? null : dr["CustPhoneNo"].ToString();
                    saform.Date = dr["Date"] == null ? null : dr["Date"].ToString();
                    saform.source = dr["source"] == null ? null : dr["source"].ToString();
                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };
                    if (dr["CreatedDate"].ToString() != "")
                    {
                        saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    };
                    saform.SolvedBy = dr["SolvedBy"] == null ? null : dr["SolvedBy"].ToString();
                    saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                   
                    saforms.Add(saform);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_SVM_PlanChangeForm> GetPlanChangeData(bol_SVM_PlanChangeForm bol)
        {
            List<bol_SVM_PlanChangeForm> saforms = new List<bol_SVM_PlanChangeForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SVM_PlanChange", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SVM_PlanChangeForm saform = new bol_SVM_PlanChangeForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                   
                    if (dr["IsSolved"].ToString() != "")
                    {
                        saform.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "")
                    {
                        saform.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };
                  
                   saform.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        public ResultMsg UpdatePlanChangeForm(bol_SVM_PlanChangeForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SVM_PlanChange", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@SolvedDate", bol.SolvedDate);
                    cmd.Parameters.AddWithValue("@SolvedBy", bol.SolvedBy);
                    cmd.Parameters.AddWithValue("@StaffRemark", bol.StaffRemark);
                    cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
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

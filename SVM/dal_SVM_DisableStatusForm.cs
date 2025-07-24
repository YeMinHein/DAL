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
    public class dal_SVM_DisableStatusForm
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_SVM_DisableStatusForm() { }

        public ResultMsg GetDisableStatusFormCount(bol_SVM_DisableStatusForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SVM_DisableStatus", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                    cmd.Parameters.AddWithValue("@IsTemporary", bol.lstIsTemporary);
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
        public IEnumerable<bol_SVM_DisableStatusForm> GetDisableStatusList(bol_SVM_DisableStatusForm bol)
        {
            List<bol_SVM_DisableStatusForm> saforms = new List<bol_SVM_DisableStatusForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SVM_DisableStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                cmd.Parameters.AddWithValue("@IsTemporary", bol.lstIsTemporary);
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
                    bol_SVM_DisableStatusForm saform = new bol_SVM_DisableStatusForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.CustomerAccNo = dr["CustomerAccNo"] == null ? null : dr["CustomerAccNo"].ToString();
                    saform.CustomerName = dr["CustomerName"] == null ? null : dr["CustomerName"].ToString();
                    saform.CurrentPlanID = dr["CurrentPlanID"] == DBNull.Value ? 0 : int.Parse(dr["CurrentPlanID"].ToString());
                    saform.CurrentPlan = dr["CurrentPlan"] == null ? null : dr["CurrentPlan"].ToString();
                    saform.CustCode = dr["CustCode"] == null ? null : dr["CustCode"].ToString();
                    //saform.IsTemporary = dr["IsTemporary"] == DBNull.Value ? 0 : int.Parse(dr["IsTemporary"].ToString());
                    saform.CustomerContactPhNo = dr["CustomerContactPhNo"] == null ? null : dr["CustomerContactPhNo"].ToString();
                    saform.Date = dr["Date"] == null ? null : dr["Date"].ToString();
                    if (dr["IsTemporary"].ToString() != "")
                    {
                        saform.IsTemporary = bool.Parse(dr["IsTemporary"].ToString());
                    };
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
        public IEnumerable<bol_SVM_DisableStatusForm> GetDisableStatusData(bol_SVM_DisableStatusForm bol)
        {
            List<bol_SVM_DisableStatusForm> saforms = new List<bol_SVM_DisableStatusForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SVM_DisableStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SVM_DisableStatusForm saform = new bol_SVM_DisableStatusForm();
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

        public ResultMsg UpdateDisableStatusForm(bol_SVM_DisableStatusForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SVM_DisableStatus", con);
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

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
    public class dal_WDM_AdvancePayment
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_WDM_AdvancePayment() { }

        public IEnumerable<bol_WDM_AdvancePayment> GetAdvancePaymentList(bol_WDM_AdvancePayment bol)
        {
            List<bol_WDM_AdvancePayment> AdvancePayments = new List<bol_WDM_AdvancePayment>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300; //seconds = 5mins
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@PromoPlan", bol.PromoPlan);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@lstStatus", bol.Status);
                cmd.Parameters.AddWithValue("@IsFinished", bol.IsFinished);
                cmd.Parameters.AddWithValue("@Source", bol.Source);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate",bol.EndDate);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_AdvancePayment AdvancePayment = new bol_WDM_AdvancePayment();
                    AdvancePayment.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    AdvancePayment.CustomerAccountNo = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                    AdvancePayment.CustomerName = dr["CustomerName"] == null ? null : dr["CustomerName"].ToString();
                    AdvancePayment.PhoneNo = dr["PhoneNo"] == null ? null : dr["PhoneNo"].ToString();
                    AdvancePayment.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                    AdvancePayment.ServicePlan = dr["ServicePlan"] == null ? null : dr["ServicePlan"].ToString();
                    AdvancePayment.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();
                    AdvancePayment.InstallMonth = dr["InstallMonth"] == DBNull.Value ? 0 : int.Parse(dr["InstallMonth"].ToString());
                    AdvancePayment.FOCMonth = dr["FOC_Month"] == DBNull.Value ? 0 : int.Parse(dr["FOC_Month"].ToString());
                    AdvancePayment.FOCDay = dr["FOC_Day"] == null ? 0 : Convert.ToInt32(dr["FOC_Day"].ToString());
                    AdvancePayment.TotalAmount = dr["TotalAmount"] == null ? null : dr["TotalAmount"].ToString();
                    AdvancePayment.PromoPlan = dr["PromoName_Eng"] == null ? null : dr["PromoName_Eng"].ToString();

                    if (dr["CreatedDate"].ToString() != "")
                    {
                        AdvancePayment.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    }
                    AdvancePayment.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
                    AdvancePayment.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                    AdvancePayment.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                    AdvancePayment.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                    AdvancePayment.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                    AdvancePayment.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                    AdvancePayment.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                    AdvancePayment.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                    if (dr["IsFinished"].ToString() != "")
                    {
                        AdvancePayment.IsFinished = bool.Parse(dr["IsFinished"].ToString());
                    };
                    if (dr["FinishedDate"].ToString() != "")
                    {
                        AdvancePayment.FormattedFinishedDate = dr["FormattedFinishedDate"].ToString();
                    };
                    AdvancePayment.FinishedBy = dr["FinishedBy"] == null ? "" : dr["FinishedBy"].ToString();
                    AdvancePayment.PaymentBy = dr["PaymentBy"] == null ? "" : dr["PaymentBy"].ToString();
                    if (dr["PaymentDate"].ToString() != "")
                    {
                        AdvancePayment.PaymentDate = dr["PaymentDate"].ToString();
                    }
                    AdvancePayment.FinishedRemark = dr["FinishedRemark"] == null ? null : dr["FinishedRemark"].ToString();
                    if (dr["SendReceipt"].ToString() != "")
                    {
                        AdvancePayment.SendReceipt = bool.Parse(dr["SendReceipt"].ToString());
                    };
                    AdvancePayments.Add(AdvancePayment);
                }
            }
            return AdvancePayments;
        }

        public ResultMsg GetAdvancePaymentCount(bol_WDM_AdvancePayment bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 300; //seconds = 5mins
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@PromoPlan", bol.PromoPlan);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@lstStatus", bol.Status);
                    cmd.Parameters.AddWithValue("@IsFinished", bol.IsFinished);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
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

        #region[AdvancePayment]
        public IEnumerable<bol_WDM_AdvancePayment> GetAdvancePaymentData(bol_WDM_AdvancePayment bol)
        {
            List<bol_WDM_AdvancePayment> saforms = new List<bol_WDM_AdvancePayment>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_AdvancePayment saform = new bol_WDM_AdvancePayment();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.CustomerAccountNo = dr["CustomerAccountNo"] == null ? "" : dr["CustomerAccountNo"].ToString();
                    saform.CustomerName = dr["CustomerName"] == null ? "" : dr["CustomerName"].ToString();
                    saform.PhoneNo = dr["PhoneNo"] == null ? "" : dr["PhoneNo"].ToString();
                    saform.Email = dr["Email"] == null ? "" : dr["Email"].ToString();
                    saform.CurrentPlan = dr["CurrentPlan"] == null ? "" : dr["CurrentPlan"].ToString();
                    saform.AdvancePaymentForMonths = dr["AdvancePaymentForMonths"] == null ? "" : dr["AdvancePaymentForMonths"].ToString();
                    saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? "" : dr["FormattedCreatedDate"].ToString();
                    saform.ServicePlan = dr["ServicePlan"] == null ? "" : dr["ServicePlan"].ToString();
                    saform.PromoName = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    saform.BankForPayment = dr["BankForPayment"] == null ? "" : dr["BankForPayment"].ToString();
                    saform.OrderCode = dr["OrderCode"] == null ? "" : dr["OrderCode"].ToString();
                    saform.FOCMonth = dr["FOC_Month"] == null ? 0 : Convert.ToInt32(dr["FOC_Month"].ToString());
                    saform.FOCDay = dr["FOC_Day"] == null ? 0 : Convert.ToInt32(dr["FOC_Day"].ToString());
                    saform.InstallMonth = dr["InstallMonth"] == null ? 0 : Convert.ToInt32(dr["InstallMonth"].ToString());
                    saform.Price = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());
                    saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? "" : dr["IsSurchargeOn"].ToString();
                    saform.TaxPercentage = dr["TaxPercentage"] == null ? "" : dr["TaxPercentage"].ToString();
                    saform.TaxAmount = dr["TaxAmount"] == null ? "" : dr["TaxAmount"].ToString();
                    saform.Amount = dr["Amount"] == null ? "" : dr["Amount"].ToString();
                    saform.TotalAmount = dr["TotalAmount"] == null ? "" : dr["TotalAmount"].ToString();
                    if (dr["IsFinished"].ToString() != "")
                    {
                        saform.IsFinished = bool.Parse(dr["IsFinished"].ToString());
                    };
                    if (dr["FinishedDate"].ToString() != "")
                    {
                        saform.FormattedFinishedDate = dr["FormattedFinishedDate"].ToString();
                    };
                    saform.FinishedBy = dr["FinishedBy"] == null ? "" : dr["FinishedBy"].ToString();
                    saform.PaymentBy = dr["PaymentBy"] == null ? "" : dr["PaymentBy"].ToString();
                    saform.PaymentDate = dr["PaymentDate"] == null ? "" : dr["PaymentDate"].ToString();
                    saform.FinishedRemark = dr["FinishedRemark"] == null ? null : dr["FinishedRemark"].ToString();
                    saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                    saforms.Add(saform);
                }

            }
            return saforms;
        }
        public IEnumerable<bol_ServiceBasePlanSurchargeModel> GetServiceBasePlanSurcharge(bol_ServiceBasePlanSurchargeModel bol)
        {
            List<bol_ServiceBasePlanSurchargeModel> saforms = new List<bol_ServiceBasePlanSurchargeModel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CurrentPlan", bol.CurrentPlan);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServiceBasePlanSurchargeModel saform = new bol_ServiceBasePlanSurchargeModel();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.IsSurchargeOn = dr["IsSurchargeOn"] == null ? false : Convert.ToBoolean(dr["IsSurchargeOn"].ToString());
                    saform.SurchargePercentage = dr["SurchargePercentage"] == null ? 0 : Convert.ToDecimal(dr["SurchargePercentage"].ToString());
                    saforms.Add(saform);
                }

            }
            return saforms;
        }
        public ResultMsg UpdateAdvancePaymentForm(bol_WDM_AdvancePayment bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@AdvancePaymentForMonths", bol.AdvancePaymentForMonths);
                    cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                    cmd.Parameters.AddWithValue("@TotalAmount", bol.TotalAmount);
                    cmd.Parameters.AddWithValue("@CustomerName", bol.CustomerName);
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

        public ResultMsg UpdateAdvancePaymentFinishedForm(bol_WDM_AdvancePayment bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@IsFinished", bol.IsFinished);
                    cmd.Parameters.AddWithValue("@FinishedDate", bol.FinishedDate);
                    cmd.Parameters.AddWithValue("@FinishedBy", bol.FinishedBy);
                    cmd.Parameters.AddWithValue("@FinishedRemark", bol.FinishedRemark);
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

        public ResultMsg UpdateAdvancePaymentReceivedForm(bol_AdvancePaymentStatusModel bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.SA_ID);
                    cmd.Parameters.AddWithValue("@SendReceipt", bol.SendReceipt);
                    cmd.Parameters.AddWithValue("@PaymentDocumentNo", bol.PaymentDocumentNo); //same as creditdocumentno
                    cmd.Parameters.AddWithValue("@FinishedRemark", bol.FinishedRemark);
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

        public ResultMsg UpdatePaymentDocumentNo(bol_AdvancePaymentStatusModel bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@OrderCode", bol.OrderCode);
                    cmd.Parameters.AddWithValue("@PaymentDocumentNo", bol.PaymentDocumentNo); //same as creditdocumentno
                    cmd.Parameters.AddWithValue("@FinishedRemark", bol.FinishedRemark);
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

        public IEnumerable<bol_WDM_AdvancePayment> GetAdvPaymentPromoPlanDetail(bol_WDM_AdvancePayment bol)
        {
            List<bol_WDM_AdvancePayment> saforms = new List<bol_WDM_AdvancePayment>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 9);
                cmd.Parameters.AddWithValue("@CurrentPlan", bol.CurrentPlan);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_AdvancePayment saform = new bol_WDM_AdvancePayment();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.PromoName = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                    saform.FOCMonth = dr["FOC_Month"] == null ? 0 : Convert.ToInt32(dr["FOC_Month"].ToString());
                    saform.FOCDay = dr["FOC_Day"] == null ? 0 : Convert.ToInt32(dr["FOC_Day"].ToString());
                    saform.InstallMonth = dr["InstallMonth"] == null ? 0 : Convert.ToInt32(dr["InstallMonth"].ToString());
                    saforms.Add(saform);
                }

            }
            return saforms;
        }

        public IEnumerable<bol_WDM_AdvancePayment> GetAdvPayPromoByPlanID(int ActionParam, int ServiceBasePlan_ID)
        {
            List<bol_WDM_AdvancePayment> saforms = new List<bol_WDM_AdvancePayment>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@CurrentPlan", ServiceBasePlan_ID);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_AdvancePayment saform = new bol_WDM_AdvancePayment();

                    try
                    {
                        saform.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    
                        saform.PromoName = dr["PromoName_Eng"] == null ? "" : dr["PromoName_Eng"].ToString();
                   
                    }
                    catch (Exception ex)
                    {
                       
                    }
                    finally
                    {

                    }

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        #endregion

        #region AdvancePaymentStatus
        public IQueryable<bol_AdvancePaymentStatusModel> GetAdvancePaymentStatus(bol_AdvancePaymentStatusModel bol)
        {
            List<bol_AdvancePaymentStatusModel> csetup = new List<bol_AdvancePaymentStatusModel>();
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                ObjParm.Add("@PaymentAlias", "Advance");
                con.Open();
                var list = con.Query<bol_AdvancePaymentStatusModel>("sp_AdvancePaymentStatus", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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
        public ResultMsg AdvancePaymentStatusInsert(bol_AdvancePaymentStatusModel bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);
                ObjParm.Add("@LoggedBy", bol.LoggedBy);
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                ObjParm.Add("@PaymentAlias", "Advance");
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_AdvancePaymentStatus", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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

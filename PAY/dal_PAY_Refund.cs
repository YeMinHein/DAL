using BOL;
using BOL.PAY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PAY
{
  public  class dal_PAY_Refund
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_PAY_Refund()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        #region Payment Refund

        public IQueryable<bol_PAY_Refund> RefundList(bol_PAY_Refund bol)
        {
            List<bol_PAY_Refund> csetups = new List<bol_PAY_Refund>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Refund", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@OrderCode", bol.OrderCode);
                cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (bol.PaymentType == "Bill" || bol.PaymentType == "Advance" || bol.PaymentType=="Recharge")
                {
                    while (dr.Read())
                    {
                        bol_PAY_Refund csetup = new bol_PAY_Refund();
                        csetup.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                        csetup.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
                        csetup.PaymentMethod = dr["PaymentMethod"] == null ? null : dr["PaymentMethod"].ToString();
                        csetup.PaymentOperator = dr["PaymentOperator"] == null ? null : dr["PaymentOperator"].ToString();
                        csetup.PaymentStatus = dr["PaymentStatus"] == null ? null : dr["PaymentStatus"].ToString();
                        // csetup.CreatedDate = dr["CreatedDate"] == null ? null : Convert.ToDateTime(dr["CreatedDate"]);
                        csetup.transaction_id = dr["transaction_id"] == null ? null : dr["transaction_id"].ToString();
                        csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        csetup.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                        csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                        csetup.IsSyncBSS = Convert.ToBoolean(dr["IsSyncBSS"]);
                        csetup.NRC = dr["NRC"] == null ? null : dr["NRC"].ToString();
                        csetup.customerAccountNo = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
                        csetup.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                        csetup.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                        csetup.PaymentDateStr = dr["PaymentDateStr"] == null ? "" : Convert.ToString(dr["PaymentDateStr"]);
                        csetup.CreatedDateStr = dr["CreatedDateStr"] == null ? "" : Convert.ToString(dr["CreatedDateStr"]);
                        csetup.UpdatePaymentStatus = dr["UpdatePaymentStatus"] == null ? "" : Convert.ToString(dr["UpdatePaymentStatus"]);
                        csetup.LastStatusName = dr["LastStatusName"] == null ? "" : Convert.ToString(dr["LastStatusName"]);
                        csetup.LastStatus = dr["LastStatus"] == null ? "" : Convert.ToString(dr["LastStatus"]);
                        // csetup.CreatedDate= dr["CreatedDate"] == null || dr["CreatedDate"] == "" || dr["CreatedDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["CreatedDate"]);
                        //csetup.PaymentDate= dr["PaymentDate"] == null || dr["PaymentDate"] == "" || dr["PaymentDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["PaymentDate"]);
                        if (dr["CreatedDate"] != DBNull.Value)
                        {
                            csetup.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                        }
                        if (dr["PaymentDate"] != DBNull.Value)
                        {
                            csetup.PaymentDate = DateTime.Parse(dr["PaymentDate"].ToString());
                        }                        
                        csetups.Add(csetup);
                    }
                }
                else
                {
                    while (dr.Read())
                    {
                        bol_PAY_Refund csetup = new bol_PAY_Refund();
                        csetup.SA_ID = dr["SA_ID"] == null ? 0 : Convert.ToInt32(dr["SA_ID"].ToString());
                        csetup.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                        csetup.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
                        csetup.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
                        csetup.PaymentMethod = dr["PaymentMethod"] == null ? null : dr["PaymentMethod"].ToString();
                        csetup.PaymentOperator = dr["PaymentOperator"] == null ? null : dr["PaymentOperator"].ToString();
                        csetup.PaymentStatus = dr["PaymentStatus"] == null ? null : dr["PaymentStatus"].ToString();
                        // csetup.CreatedDate = dr["CreatedDate"] == null ? null : Convert.ToDateTime(dr["CreatedDate"]);
                        csetup.transaction_id = dr["transaction_id"] == null ? null : dr["transaction_id"].ToString();
                        csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        csetup.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                        csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                        csetup.NRC = dr["NRC"] == null ? null : dr["NRC"].ToString();
                        csetup.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                        csetup.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                        csetup.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                        csetup.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                        csetup.PaymentDateStr = dr["PaymentDateStr"] == null ? "" : Convert.ToString(dr["PaymentDateStr"]);
                        csetup.CreatedDateStr = dr["CreatedDateStr"] == null ? "" : Convert.ToString(dr["CreatedDateStr"]);
                        csetup.UpdatePaymentStatus = dr["UpdatePaymentStatus"] == null ? "" : Convert.ToString(dr["UpdatePaymentStatus"]);
                        csetup.LastStatusName = dr["LastStatusName"] == null ? "" : Convert.ToString(dr["LastStatusName"]);
                        csetup.LastStatus = dr["LastStatus"] == null ? "" : Convert.ToString(dr["LastStatus"]);
                        // csetup.CreatedDate= dr["CreatedDate"] == null || dr["CreatedDate"] == "" || dr["CreatedDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["CreatedDate"]);
                        //csetup.PaymentDate= dr["PaymentDate"] == null || dr["PaymentDate"] == "" || dr["PaymentDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["PaymentDate"]);
                        if (dr["CreatedDate"] != DBNull.Value)
                        {
                            csetup.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                        }
                        if (dr["PaymentDate"] != DBNull.Value)
                        {
                            csetup.PaymentDate = DateTime.Parse(dr["PaymentDate"].ToString());
                        }
                        csetups.Add(csetup);
                    }
                }
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
        public bol_PAY_Refund RefundCustomerByOrderCode(bol_PAY_Refund bol)
        {
            bol_PAY_Refund csetup = new bol_PAY_Refund();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Refund", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 3);
                cmd.Parameters.AddWithValue("@OrderCode", bol.OrderCode);
                cmd.Parameters.AddWithValue("@PaymentType", bol.PaymentType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {                                    
                    csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                    csetup.NRC = dr["NRC"] == null ? null : dr["NRC"].ToString();
                    csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                    csetup.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                    csetup.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csetup.PromoName = dr["PromoName"] == null ? null : dr["PromoName"].ToString();
                    
                    csetup.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                    csetup.OrderCancelledBy = dr["OrderCancelledBy"] == null ? null : dr["OrderCancelledBy"].ToString();
                    if (dr["OrderCancelledDate"] != DBNull.Value && dr["OrderCancelledDate"] !="")
                    {
                        csetup.OrderCancelledDate = DateTime.Parse(dr["OrderCancelledDate"].ToString());
                        
                    }
                    if(bol.PaymentType=="Bill" || bol.PaymentType=="Advance")
                    {
                        csetup.billingArea = dr["billingArea"] == null ? null : dr["billingArea"].ToString();
                        csetup.customerAccountNo = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
                       // csetup.IsSyncBSS = Convert.ToBoolean(dr["IsSyncBSS"]);
                    }

                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return csetup;
        }
        #endregion
        #region CheckPaymentStatus
        public string CheckPaymentStatus(List<bol_PAY_Refund> bol,string UserName)
        {            
            DataTable dt = new DataTable();
            //Add columns  
            dt.Columns.Add(new DataColumn("ordercode", typeof(string)));
            dt.Columns.Add(new DataColumn("merch_order_id", typeof(string)));
            dt.Columns.Add(new DataColumn("payment_method", typeof(string)));
            dt.Columns.Add(new DataColumn("PaymentDate", typeof(DateTime)));
            dt.Columns.Add(new DataColumn("mm_order_id", typeof(string)));
            dt.Columns.Add(new DataColumn("payment_status", typeof(string)));
            dt.Columns.Add(new DataColumn("order_status", typeof(string)));
            dt.Columns.Add(new DataColumn("createdby", typeof(string)));
            dt.Columns.Add(new DataColumn("createddate", typeof(DateTime)));

            foreach (var list in bol)
            {
                //Add rows  
                dt.Rows.Add(list.OrderCode, list.merch_order_id, list.PaymentMethod, list.PaymentDate, 
                    list.PaymentStatus, list.transaction_id, list.UpdatePaymentStatus,UserName,DateTime.UtcNow
                    );
            }

            //sqlcon as SqlConnection  
            //SqlCommand sqlcom = new SqlCommand("usp_InsertProducts", sqlcon);
            SqlCommand cmd = new SqlCommand("sp_PAY_CheckPayment_Log", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAY_CheckPayment", dt);
            //sqlcom.Parameters.Add(prmReturn);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "";
        }
        #endregion

        #region UpdateRefund
        public ResultMsg UpdateRefund(bol_PAY_Refund bol)
        {
            string resp_code = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Refund", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 2);
                cmd.Parameters.AddWithValue("@Is_Refund", bol.Is_Refund);
                cmd.Parameters.AddWithValue("@Refund_Remark", bol.Refund_Remark);
                cmd.Parameters.AddWithValue("@Refund_Date", bol.Refund_Date);
                cmd.Parameters.AddWithValue("@Refund_By", bol.Refund_By);
                cmd.Parameters.AddWithValue("@merch_order_id", bol.merch_order_id);
                con.Open();
               resp_code = cmd.ExecuteScalar().ToString();               
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }
           
             return new ResultMsg() { Result = resp_code, Message = resp_code == "4" ? "Succefully updated!" : resp_code == "3" ? "Succefully saved!" : "Succefully deleted" };
            
        }
        #endregion

        #region Payment Refund

        public IQueryable<bol_PAY_Refund> CheckPayment(int SA_ID)
        {
            List<bol_PAY_Refund> csetups = new List<bol_PAY_Refund>();
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Refund", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 2);
                cmd.Parameters.AddWithValue("@SA_ID", SA_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PAY_Refund csetup = new bol_PAY_Refund();
                    csetup.SA_ID = dr["SA_ID"] == null ? 0 : Convert.ToInt32(dr["SA_ID"].ToString());
                    csetup.PaymentAlias = dr["PaymentAlias"] == null ? null : dr["PaymentAlias"].ToString();
                    csetup.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
                    csetup.OrderCode = dr["OrderCode"] == null ? null : dr["OrderCode"].ToString();
                    csetup.PaymentMethod = dr["PaymentMethod"] == null ? null : dr["PaymentMethod"].ToString();
                    csetup.PaymentOperator = dr["PaymentOperator"] == null ? null : dr["PaymentOperator"].ToString();
                    csetup.PaymentStatus = dr["PaymentStatus"] == null ? null : dr["PaymentStatus"].ToString();
                   // csetup.CreatedDate = dr["CreatedDate"] == null ? null : Convert.ToDateTime(dr["CreatedDate"]);
                    csetup.transaction_id = dr["transaction_id"] == null ? null : dr["transaction_id"].ToString();
                    csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                    csetup.NRC = dr["NRC"] == null ? null : dr["NRC"].ToString();
                    csetup.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                    csetup.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    csetup.TotalAmount = dr["TotalAmount"] == null ? 0 : Convert.ToDouble(dr["TotalAmount"].ToString());
                    csetup.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csetup.PaymentDateStr = dr["PaymentDateStr"] == null ? "" : Convert.ToString(dr["PaymentDateStr"]);
                    csetup.CreatedDateStr = dr["CreatedDateStr"] == null ? "" : Convert.ToString(dr["CreatedDateStr"]);
                    csetup.UpdatePaymentStatus = dr["UpdatePaymentStatus"] == null ? "" : Convert.ToString(dr["UpdatePaymentStatus"]);
                    csetup.LastStatusName = dr["LastStatusName"] == null ? "" : Convert.ToString(dr["LastStatusName"]);
                    if (dr["CreatedDate"] != DBNull.Value)
                    {
                        csetup.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                    }
                    if (dr["PaymentDate"] != DBNull.Value)
                    {
                        csetup.PaymentDate = DateTime.Parse(dr["PaymentDate"].ToString());
                    }
                   // csetup.CreatedDate = dr["CreatedDate"] == null || dr["CreatedDate"] == "" || dr["CreatedDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["CreatedDate"]);
                    //csetup.PaymentDate = dr["PaymentDate"] == null || dr["PaymentDate"] == "" || dr["PaymentDate"] == DBNull.Value ? null : Convert.ToDateTime(dr["PaymentDate"]);
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

            return csetups.AsQueryable();
        }
        #endregion

        
        public string UpdateKBZPaymentStatus(string merch_order_id,string UserName)
        {
            string resp_code = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_ServiceApplicationForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@actionParam", 8);
                cmd.Parameters.AddWithValue("@merch_order_id", merch_order_id);
                cmd.Parameters.AddWithValue("@Name", UserName);
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                return resp_code;
            }
            finally
            {
                con.Close();
            }
            return resp_code;
        }

  }
}

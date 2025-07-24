using BOL;
using BOL.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public class dal_API_Customer
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public ResultMsg GetCSBillListCount(bol_API_CSBillList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
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

        public IEnumerable<bol_API_CSBillList> GetCSBillList(bol_API_CSBillList bol)
        {
            List<bol_API_CSBillList> bls = new List<bol_API_CSBillList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_CSBillList bl = new bol_API_CSBillList();
                    bl.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    bl.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    bl.billingAccountNumber = dr["billingAccountNumber"] == null ? null : dr["billingAccountNumber"].ToString();
                    bl.AccountStatus = dr["AccountStatus"] == null ? null : dr["AccountStatus"].ToString();
                    bl.CurrentPlan = dr["CurrentPlan"] == null ? null : dr["CurrentPlan"].ToString();
                    bl.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    bl.billNumber = dr["billNumber"] == null ? null : dr["billNumber"].ToString();
                    bl.documentType = dr["documentType"] == null ? null : dr["documentType"].ToString();
                    bl.amount = dr["amount"] == DBNull.Value ? 0 : double.Parse(dr["amount"].ToString());
                    bl.unpaidAmount = dr["unpaidAmount"] == DBNull.Value ? 0 : double.Parse(dr["unpaidAmount"].ToString());
                    if (dr["FormattedbillDate"] != DBNull.Value)
                    {
                        bl.billDate = dr["FormattedbillDate"].ToString();
                    }
                    if (dr["FormatteddueDate"] != DBNull.Value)
                    {
                        bl.dueDate = dr["FormatteddueDate"].ToString();
                    }
                    bl.billStatus = dr["billStatus"] == null ? null : dr["billStatus"].ToString();
                    bl.disputedStatus = dr["disputedStatus"] == null ? null : dr["disputedStatus"].ToString();
                    bl.billMonth = dr["billMonth"] == null ? null : dr["billMonth"].ToString();
                    bl.billId = dr["billId"] == null ? null : dr["billId"].ToString();
                    bl.currencyName = dr["currencyName"] == null ? null : dr["currencyName"].ToString();
                    bls.Add(bl);
                }
            }
            return bls;
        }


        public ResultMsg GetCSAccountHistoryCount(bol_API_CSAccountHistory bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
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

        public IEnumerable<bol_API_CSAccountHistory> GetCSAccountHistory(bol_API_CSAccountHistory bol)
        {
            List<bol_API_CSAccountHistory> ahs = new List<bol_API_CSAccountHistory>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_CSAccountHistory ah = new bol_API_CSAccountHistory();
                    ah.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    ah.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    ah.serviceInstanceNumber = dr["serviceInstanceNumber"] == null ? null : dr["serviceInstanceNumber"].ToString();
                    ah.planName = dr["planName"] == null ? null : dr["planName"].ToString();
                    ah.planStatus = dr["planStatus"] == null ? null : dr["planStatus"].ToString();
                    if (dr["FormatteddateTime"] != DBNull.Value)
                    {
                        ah.dateTime = dr["FormatteddateTime"].ToString();
                    }
                    ah.staffId = dr["staffId"] == null ? null : dr["staffId"].ToString();
                    ah.staffName = dr["staffName"] == null ? null : dr["staffName"].ToString();
                    ah.functionality = dr["functionality"] == null ? null : dr["functionality"].ToString();
                    ah.remark = dr["remark"] == null ? null : dr["remark"].ToString();
                    ah.valueBefore = dr["valueBefore"] == null ? null : dr["valueBefore"].ToString();
                    ah.valueAfter = dr["valueAfter"] == null ? null : dr["valueAfter"].ToString();
                    ahs.Add(ah);
                }
            }
            return ahs;
        }

        public bol_API_CSInfo GetCSInfo(bol_API_CSInfo bol)
        {
            bol_API_CSInfo rsetup = new bol_API_CSInfo();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rsetup.customerAccountNumber = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
                    rsetup.Name = dr["name"] == null ? null : dr["name"].ToString();
                    rsetup.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    rsetup.status = dr["status"] == null ? null : dr["status"].ToString();
                    rsetup.expiryDate = dr["expiryDate"] == null ? null : dr["expiryDate"].ToString();

                    rsetup.leadId = dr["leadId"] == null ? null : dr["leadId"].ToString();
                    rsetup.cafNumber = dr["cafNumber"] == null ? null : dr["cafNumber"].ToString();
                    rsetup.ioNumber = dr["ioNumber"] == null ? null : dr["ioNumber"].ToString();
                    rsetup.title = dr["title"] == null ? null : dr["title"].ToString();
                    rsetup.dateOfBirth = dr["dateOfBirth"] == null ? null : dr["dateOfBirth"].ToString();
                    rsetup.gender = dr["gender"] == null ? null : dr["gender"].ToString();
                    rsetup.creationDate = dr["creationDate"] == null ? null : dr["creationDate"].ToString();
                    rsetup.emailAddress = dr["emailAddress"] == null ? null : dr["emailAddress"].ToString();
                    rsetup.registeredMobileNumber = dr["registeredMobileNumber"] == null ? null : dr["registeredMobileNumber"].ToString();
                    rsetup.billingArea = dr["billingArea"] == null ? null : dr["billingArea"].ToString();
                    rsetup.customerCategory = dr["customerCategory"] == null ? null : dr["customerCategory"].ToString();
                    rsetup.businessType = dr["businessType"] == null ? null : dr["businessType"].ToString();
                    rsetup.condoSalesMasterName = dr["condoSalesMasterName"] == null ? null : dr["condoSalesMasterName"].ToString();
                    rsetup.NRCNo = dr["NRCNo"] == null ? null : dr["NRCNo"].ToString();

                    rsetup.PlanType = dr["PlanType"] == null ? null : dr["PlanType"].ToString();
                    rsetup.price = dr["price"] == null ? null : dr["price"].ToString();
                    rsetup.userId = dr["userId"] == null ? null : dr["userId"].ToString();
                }
            }
            return rsetup;
        }


        public IEnumerable<bol_API_CSInfo> GetSearchCSInfo(bol_API_CSInfo bol)
        {
            List<bol_API_CSInfo> csis = new List<bol_API_CSInfo>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_Customer", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_CSInfo csi = new bol_API_CSInfo();

                    csi.customerAccountNumber = dr["customerAccountNo"] == null ? null : dr["customerAccountNo"].ToString();
                    csi.Name = dr["name"] == null ? null : dr["name"].ToString();
                    csi.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csi.status = dr["status"] == null ? null : dr["status"].ToString();
                    csis.Add(csi);
                }
            }
            return csis;
        }

        public IEnumerable<bol_API_SearchCustomerList> GetSearchCustomerList(bol_API_SearchCustomerList bol)
        {
            List<bol_API_SearchCustomerList> bls = new List<bol_API_SearchCustomerList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_SearchCustomerList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@SearchTextServiceInstanceNo", bol.SearchTextServiceInstanceNo);
                cmd.Parameters.AddWithValue("@SearchTextName", bol.CUSTNAME);
                cmd.Parameters.AddWithValue("@SearchTextMobileNo", bol.PHONENO);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_SearchCustomerList bl = new bol_API_SearchCustomerList();
                    bl.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    bl.CUSTNAME = dr["CUSTNAME"] == null ? null : dr["CUSTNAME"].ToString();
                    bl.PHONENO = dr["PHONENO"] == null ? null : dr["PHONENO"].ToString();
                    bl.CUST_ACC = dr["CUST_ACC"] == null ? null : dr["CUST_ACC"].ToString();
                    bl.CUSTCATEGORY = dr["CUSTCATEGORY"] == null ? null : dr["CUSTCATEGORY"].ToString();
                    bl.SERVICETYPE = dr["SERVICETYPE"] == null ? null : dr["SERVICETYPE"].ToString();
                    bl.ACCOUNTSTATUS = dr["ACCOUNTSTATUS"] == null ? null : dr["ACCOUNTSTATUS"].ToString();

                    bls.Add(bl);
                }
            }
            return bls;
        }

        public ResultMsg GetSearchCustomerListCount(bol_API_SearchCustomerList bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_BSS_SearchCustomerList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@SearchTextServiceInstanceNo", bol.SearchTextServiceInstanceNo);
                    cmd.Parameters.AddWithValue("@SearchTextName", bol.CUSTNAME);
                    cmd.Parameters.AddWithValue("@SearchTextMobileNo", bol.PHONENO);
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

        public IEnumerable<bol_API_PrepaidHistory> GetPrepaidHistory(bol_API_PrepaidHistory bol)
        {
            List<bol_API_PrepaidHistory> phs = new List<bol_API_PrepaidHistory>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_PrepaidHistory ph = new bol_API_PrepaidHistory();
                    ph.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    ph.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
                    ph.effectiveDate = dr["effectiveDate"] == null ? null : dr["effectiveDate"].ToString();
                    ph.packageName = dr["packageName"] == null ? null : dr["packageName"].ToString();
                    ph.PMRVO_paymentDate = dr["PMRVO_paymentDate"] == null ? null : dr["PMRVO_paymentDate"].ToString();
                    ph.PMRVO_totalTransactionAmount = dr["PMRVO_totalTransactionAmount"] == DBNull.Value ? 0 : int.Parse(dr["PMRVO_totalTransactionAmount"].ToString());
                    ph.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    ph.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                    ph.merch_order_id = dr["merch_order_id"] == null ? null : dr["merch_order_id"].ToString();
                    ph.ReceivableChannelAlias = dr["ReceivableChannelAlias"] == null ? null : dr["ReceivableChannelAlias"].ToString();
                    ph.InternetRefNo = dr["InternetRefNo"] == null ? null : dr["InternetRefNo"].ToString();
                    ph.CRNo = dr["CRNo"] == null ? null : dr["CRNo"].ToString();
                    ph.Status = dr["Status"] == null ? null : dr["Status"].ToString();

                    ph.PaymentSource = dr["PaymentSource"] == null ? null : dr["PaymentSource"].ToString();
                    ph.PaymentOperator = dr["PaymentOperator"] == null ? null : dr["PaymentOperator"].ToString();

                    ph.CancelledDate = dr["CancelledDate"] == null ? null : dr["CancelledDate"].ToString();
                    ph.CancelledBy = dr["CancelledBy"] == null ? null : dr["CancelledBy"].ToString();
                    ph.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                    phs.Add(ph);
                }
            }
            return phs;
        }

        public ResultMsg GetPrepaidHistoryCount(bol_API_PrepaidHistory bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
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

        public IEnumerable<bol_DepositDetails> GetCSInfo_DepositDetails(bol_API_CSInfo bol)
        {
            List<bol_DepositDetails> ddls = new List<bol_DepositDetails>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_BSS_DepositDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@customerAccountNo", bol.customerAccountNumber);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DepositDetails ddl = new bol_DepositDetails();

                    ddl.accountNumber = dr["accountNumber"] == null ? null : dr["accountNumber"].ToString();
                    ddl.amountDue = dr["amountDue"] == DBNull.Value ? 0 : decimal.Parse(dr["amountDue"].ToString());
                    ddl.depositAmount = dr["depositAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["depositAmount"].ToString());
                    ddl.depositName = dr["depositName"] == null ? null : dr["depositName"].ToString();
                    ddl.depositType = dr["depositType"] == null ? null : dr["depositType"].ToString();
                    ddl.status = dr["status"] == null ? null : dr["status"].ToString();
                    ddl.amtTransferredRefund = dr["amtTransferredRefund"] == DBNull.Value ? 0 : decimal.Parse(dr["amtTransferredRefund"].ToString());
                    ddl.maturityDays = dr["maturityDays"] == DBNull.Value ? 0 : int.Parse(dr["maturityDays"].ToString());
                    ddl.maturityMonths = dr["maturityMonths"] == DBNull.Value ? 0 : int.Parse(dr["maturityMonths"].ToString());
                    ddl.depositDetailId = dr["depositDetailId"] == null ? null : dr["depositDetailId"].ToString();
      
                    ddls.Add(ddl);
                }
            }
            return ddls;
        }

        public ResultMsg UpdateFixCRNo(bol_API_PrepaidHistory bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
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
    }
}

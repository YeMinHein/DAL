using BOL;
using BOL.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.API
{
    public class dal_API_MobileApp
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        #region[GetPlan]
        public IEnumerable<bol_API_GetPlan> GetPlan(bol_API_ReqGetPlan bol)
        {
            List<bol_API_GetPlan> csetups = new List<bol_API_GetPlan>();
            int ActionParam = 3;

            string ServiceType = bol.service_type == null ? "" : bol.service_type;
            string PlanFullName = bol.plan_full_name == null ? "" : bol.plan_full_name;


            if (ServiceType != "" && PlanFullName == "")
            {
                ActionParam = 3;
            }
            else if (ServiceType == "" && PlanFullName != "")
            {
                ActionParam = 4;
            }
            else if (ServiceType != "" && ServiceType != "")
            {
                ActionParam = 5;
            }

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAppGetPlan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ServiceType", bol.service_type);
                cmd.Parameters.AddWithValue("@FullName", bol.plan_full_name);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_GetPlan csetup = new bol_API_GetPlan();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.service_type = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    csetup.plan_short_name = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csetup.plan_full_name = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    csetup.description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup.isActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    csetup.isShown = dr["IsShown"] == null ? false : Convert.ToBoolean(dr["IsShown"].ToString());
                    csetup.download_speed = dr["DownloadSpeed"] == null ? 0 : Convert.ToDecimal(dr["DownloadSpeed"].ToString());
                    csetup.upload_speed = dr["UploadSpeed"] == null ? 0 : Convert.ToDecimal(dr["UploadSpeed"].ToString());
                    csetup.sortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                    csetup.features = dr["Features"] == null ? null : dr["Features"].ToString();
                    csetup.ImageUrl = dr["ImageUrl"] == null ? null : dr["ImageUrl"].ToString();
                    csetup.price = dr["Price"] == null ? 0 : Convert.ToDecimal(dr["Price"].ToString());
                    csetup.InstallationFees = dr["InstallationFees"] == null ? 0 : Convert.ToDecimal(dr["InstallationFees"].ToString());
                    csetup.DepositAmount = dr["DepositAmount"] == null ? 0 : Convert.ToDecimal(dr["DepositAmount"].ToString());
                    csetup.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                    csetup.UploadUnit = dr["UploadUnit"] == null ? null : dr["UploadUnit"].ToString();
                    csetup.DownloadUnit = dr["DownloadUnit"] == null ? null : dr["DownloadUnit"].ToString();

                    if (dr["Validity"] != DBNull.Value)
                    {
                        csetup.Validity = Convert.ToInt32(dr["Validity"].ToString());
                    }
                    else
                    {
                        csetup.Validity = 0;
                    }
                    csetup.ChargingPattern = dr["ChargingPattern"] == null ? null : dr["ChargingPattern"].ToString();
                    csetup.PkgDisplayName = dr["PkgDisplayName"] == null ? null : dr["PkgDisplayName"].ToString();
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        public bol_API_GetPlan GetCurrentPlan(bol_API_ReqGetPlan bol)
        {
            bol_API_GetPlan csetup = new bol_API_GetPlan();

            int ActionParam = 6;

            string ServiceType = bol.service_type == null ? "" : bol.service_type;
            string PlanFullName = bol.plan_full_name == null ? "" : bol.plan_full_name;


            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAppGetPlan", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ServiceType", bol.service_type);
                cmd.Parameters.AddWithValue("@FullName", bol.plan_full_name);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.service_type = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    csetup.plan_short_name = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    csetup.plan_full_name = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    csetup.description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup.isActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    csetup.isShown = dr["IsShown"] == null ? false : Convert.ToBoolean(dr["IsShown"].ToString());
                    csetup.download_speed = dr["DownloadSpeed"] == null ? 0 : Convert.ToDecimal(dr["DownloadSpeed"].ToString());
                    csetup.upload_speed = dr["UploadSpeed"] == null ? 0 : Convert.ToDecimal(dr["UploadSpeed"].ToString());
                    csetup.sortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                    csetup.features = dr["Features"] == null ? null : dr["Features"].ToString();
                    csetup.ImageUrl = dr["ImageUrl"] == null ? null : dr["ImageUrl"].ToString();
                    csetup.price = dr["Price"] == null ? 0 : Convert.ToDecimal(dr["Price"].ToString());
                    csetup.InstallationFees = dr["InstallationFees"] == null ? 0 : Convert.ToDecimal(dr["InstallationFees"].ToString());
                    csetup.DepositAmount = dr["DepositAmount"] == null ? 0 : Convert.ToDecimal(dr["DepositAmount"].ToString());
                    csetup.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                    csetup.UploadUnit = dr["UploadUnit"] == null ? null : dr["UploadUnit"].ToString();
                    csetup.DownloadUnit = dr["DownloadUnit"] == null ? null : dr["DownloadUnit"].ToString();
                    //csetup.Validity = dr["Validity"] == null ? 0 : Convert.ToInt32(dr["Validity"].ToString());
                    //csetup.ChargingPattern = dr["ChargingPattern"] == null ? null : dr["ChargingPattern"].ToString();
                    if (dr["Validity"] != DBNull.Value)
                    {
                        csetup.Validity = Convert.ToInt32(dr["Validity"].ToString());
                    }
                    else
                    {
                        csetup.Validity = 0;
                    }
                    csetup.ChargingPattern = dr["ChargingPattern"] == null ? null : dr["ChargingPattern"].ToString();
                    csetup.PkgDisplayName = dr["PkgDisplayName"] == null ? null : dr["PkgDisplayName"].ToString();
                }
            }
            return csetup;
        }
        #endregion

        #region[SaveActivityLog]
        public async Task<ResultMsg> SaveActivityLog(bol_API_SaveActivityLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MobileAppActivityLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@ActivityDate", bol.ActivityDate);
                    cmd.Parameters.AddWithValue("@ActivityType", bol.ActivityType);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
                if(resp_code == "600")
                {
                    CustomerComplaintInsert(bol);
                }
                
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };
        }
        public void CustomerComplaintInsert(bol_API_SaveActivityLog actModel)
        {
            try
            {
                string resp_code = "";
                if (actModel.ActivityType == "Ticket")
                {
                    bol_API_CustomerComplaintModel CComplaintModel = new bol_API_CustomerComplaintModel();
                    CComplaintModel.ActivityDate = actModel.ActivityDate;
                    CComplaintModel.ActivityType = actModel.ActivityType;
                    CComplaintModel.CustomerAccountNo = actModel.CustomerAccountNo.Replace(" ", "");
                    CComplaintModel.Description = actModel.Description;
                    CComplaintModel.Source = "5BB APP";
                    CComplaintModel.ComplaintDesc = CComplaintModel.Description.Contains("Device Issues") ? "ONU Power Outage" :
                        CComplaintModel.Description.Contains("Connection Issues") ? "Connection Problem" :
                        CComplaintModel.Description.Contains("LOS Red") ? "LOS Red" : "Other Issues";
                    CComplaintModel.ServiceType = actModel.CustomerAccountNo.ToLower().Contains("lte") ? "LTE" : "FTTH";
                    //dataLayer.MobileAPP_CustomerComplaintInsert(CComplaintModel);

                    try
                    {
                        using (SqlConnection con = new SqlConnection(conn_str))
                        {
                            SqlCommand cmd = new SqlCommand("sp_MobileAPP_CustomerComplaintInsert", con);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@CustomerAccountNo", CComplaintModel.CustomerAccountNo);
                            cmd.Parameters.AddWithValue("@Description", CComplaintModel.Description);
                            cmd.Parameters.AddWithValue("@ActivityDate", CComplaintModel.ActivityDate);
                            cmd.Parameters.AddWithValue("@Source", CComplaintModel.Source);
                            cmd.Parameters.AddWithValue("@ServiceType", CComplaintModel.ServiceType);
                            cmd.Parameters.AddWithValue("@ActivityType", CComplaintModel.ActivityType);
                            cmd.Parameters.AddWithValue("@ComplaintDesc", CComplaintModel.ComplaintDesc);

                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            //resp_code = cmd.ExecuteScalar().ToString();
                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else if (actModel.ActivityType == "Relocation")
                {
                    bol_API_CustomerRelocationPlanchangeModel CRelocationModel = new bol_API_CustomerRelocationPlanchangeModel();
                    CRelocationModel.ActivityType = actModel.ActivityType;
                    CRelocationModel.CustomerAccountNo = actModel.CustomerAccountNo.Replace(" ", "");
                    CRelocationModel.Source = "5BB APP";
                    CRelocationModel.ServiceType = actModel.CustomerAccountNo.ToLower().Contains("lte") ? "LTE" : "FTTH";
                    actModel.Description = actModel.Description.Replace("You requested to relocate your current address - “ ", "");
                    string[] AddressArr = actModel.Description.Split(new string[] { "to new address  " }, StringSplitOptions.None);
                    CRelocationModel.From = AddressArr[0]; //old
                    var ToAddress = AddressArr[1];
                    AddressArr = ToAddress.Split(new string[] { "on" }, StringSplitOptions.None);
                    CRelocationModel.To = AddressArr[0]; //new
                    CustomerPlanChangeRelocationInsert(CRelocationModel);
                }
                else if (actModel.ActivityType == "Plan Change")
                {
                    bol_API_CustomerRelocationPlanchangeModel CPlanChangeModel = new bol_API_CustomerRelocationPlanchangeModel();
                    CPlanChangeModel.ActivityType = actModel.ActivityType;
                    CPlanChangeModel.CustomerAccountNo = actModel.CustomerAccountNo.Replace(" ", "");
                    CPlanChangeModel.Source = "5BB APP";
                    CPlanChangeModel.ServiceType = actModel.CustomerAccountNo.ToLower().Contains("lte") ? "LTE" : "FTTH";

                    actModel.Description = actModel.Description.Replace("You requested to change your current plan  ", "").Replace("  to new plan  ", "-");
                    string[] planChangeArr = actModel.Description.Split(new string[] { "-" }, StringSplitOptions.None);
                    CPlanChangeModel.From = planChangeArr[0].Replace(" ", "");
                    CPlanChangeModel.To = planChangeArr[2].Replace(" ", "");
                    planChangeArr = planChangeArr[3].Split(new string[] { "on " }, StringSplitOptions.None);
                    CPlanChangeModel.EffectiveDate = planChangeArr[1].Replace(".", "");
                    CPlanChangeModel.EffectiveDate = CPlanChangeModel.EffectiveDate.ToString();
                    //if (CPlanChangeModel.EffectiveDate.Contains("/"))
                    //{
                    //   DateTime dd = Convert.ToDateTime(CPlanChangeModel.EffectiveDate.ToString());                      
                    //    CPlanChangeModel.EffectiveDate = dd.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    //}
                    //                CPlanChangeModel.EffectiveDate = Convert.ToDateTime(CPlanChangeModel.EffectiveDate).ToString(
                    //"dd/MM/yyyy",
                    //CultureInfo.InvariantCulture);
                    CustomerPlanChangeRelocationInsert(CPlanChangeModel);
                }
                else if (actModel.ActivityType == "Reactivate")
                {
                    bol_API_CustomerRelocationPlanchangeModel CReactivateModel = new bol_API_CustomerRelocationPlanchangeModel();
                    CReactivateModel.ActivityType = actModel.ActivityType;
                    CReactivateModel.CustomerAccountNo = actModel.CustomerAccountNo.Replace(" ", "");
                    CReactivateModel.Source = "5BB APP";
                    CReactivateModel.ServiceType = actModel.CustomerAccountNo.ToLower().Contains("lte") ? "LTE" : "FTTH";
                    string[] reactivateArr = actModel.Description.Split(new string[] { "on " }, StringSplitOptions.None);
                    CReactivateModel.EffectiveDate = reactivateArr[1].Replace(".", "");
                    CReactivateModel.EffectiveDate = CReactivateModel.EffectiveDate.ToString();// Convert.ToDateTime(CReactivateModel.EffectiveDate).ToString("dd/MM/yyyy",CultureInfo.InvariantCulture);
                    //if (CReactivateModel.EffectiveDate.Contains("/"))
                    //{
                    //   DateTime dd = Convert.ToDateTime(CReactivateModel.EffectiveDate.ToString());
                    //    CReactivateModel.EffectiveDate = dd.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
                    //}
                    CustomerPlanChangeRelocationInsert(CReactivateModel);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void CustomerPlanChangeRelocationInsert(bol_API_CustomerRelocationPlanchangeModel reqModel)
        {
            try
            {
                string resp_code = "";
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MobileAPP_FTTHRelocationPlanChange", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", reqModel.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@From", reqModel.From);
                    cmd.Parameters.AddWithValue("@To", reqModel.To);
                    cmd.Parameters.AddWithValue("@Source", reqModel.Source);
                    cmd.Parameters.AddWithValue("@ServiceType", reqModel.ServiceType);
                    cmd.Parameters.AddWithValue("@ActivityType", reqModel.ActivityType);
                    cmd.Parameters.AddWithValue("@EffectiveDate ", reqModel.EffectiveDate);

                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            catch (Exception ex)
            {
                string msg = ex.Message.ToString();
                Console.WriteLine(msg);
                Console.Write(msg);
                ex.Message.ToString();
            }

        }


        #endregion

        #region[GetActivityLog]
        public IEnumerable<bol_API_GetActivityLog> GetActivityLog(bol_API_GetActivityLog bol)
        {
            List<bol_API_GetActivityLog> csetups = new List<bol_API_GetActivityLog>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAppActivityLog", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 3);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customer_account_no);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_GetActivityLog csetup = new bol_API_GetActivityLog();
                    csetup.id = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.customer_account_no = dr["CustomerAccountNo"] == null ? null : dr["CustomerAccountNo"].ToString();
                    csetup.description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup.activity_type = dr["ActivityType"] == null ? null : dr["ActivityType"].ToString();
                    csetup.activity_date = dr["ActivityDate"] == null ? DateTime.Now : Convert.ToDateTime(dr["ActivityDate"].ToString());

                    csetups.Add(csetup);
                }
            }
            return csetups;
        }
        #endregion

        #region[SendEmail]
        public async Task<ResultMsg> SendEmail(bol_API_SendEmail bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_EmailLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@FromEmail", bol.FromEmail);
                    cmd.Parameters.AddWithValue("@ToEmail", bol.ToEmail);
                    cmd.Parameters.AddWithValue("@Subject", bol.Subject);
                    cmd.Parameters.AddWithValue("@Body", bol.Body);
                    cmd.Parameters.AddWithValue("@ActivityType", bol.ActivityType);
                    cmd.Parameters.AddWithValue("@SendDate", DateTime.Now);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };
        }

        #endregion

        #region[Topic]

        public async Task<ResultMsg> RegisterDevice(bol_API_RegisterDevice bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_APP_RegisteredDevice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };
        }

        public async Task<ResultMsg> RegisterDeviceV2(bol_API_RegisterDeviceV2 bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_APP_RegisteredDevice", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                    cmd.Parameters.AddWithValue("@AppVersion", bol.AppVersion);
                    cmd.Parameters.AddWithValue("@Platform", bol.Platform);
                    cmd.Connection = con;
                    con.Open();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };
        }
        public IEnumerable<bol_API_TopicRes> GetTopic(bol_API_TopicReq bol)
        {
            List<bol_API_TopicRes> csetups = new List<bol_API_TopicRes>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        bol_API_TopicRes topicModel = new bol_API_TopicRes();
                        if (!DBNull.Value.Equals(dr.GetValue(i)))
                        {
                            topicModel.Topic = dr.GetValue(i).ToString().Replace(" ", string.Empty);
                            csetups.Add(topicModel);
                        }

                    }

                }
            }
            return csetups;
        }


        public IEnumerable<bol_API_TopicRes> GetTopicFCM(bol_API_TopicReq bol)
        {
            List<bol_API_TopicRes> csetups = new List<bol_API_TopicRes>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 4);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    for (int i = 0; i < dr.FieldCount; i++)
                    {
                        bol_API_TopicRes topicModel = new bol_API_TopicRes();
                        if (!DBNull.Value.Equals(dr.GetValue(i)))
                        {
                            var test = csetups.Where(x => x.Topic == dr.GetValue(i).ToString()).Count();
                            if (test == 0)
                            {
                                topicModel.Topic = dr.GetValue(i).ToString().Replace(" ", string.Empty);
                                csetups.Add(topicModel);
                            }
                        }

                    }

                }
            }
            return csetups;
        }
        #endregion

        #region[NotiList]
        public IEnumerable<bol_API_NotiList> GetNotiList(bol_API_TopicReq bol)
        {
            List<bol_API_NotiList> csetups = new List<bol_API_NotiList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_NotiList csetup = new bol_API_NotiList();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    csetup.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    csetup.SentDate = dr["SentDate"] == null ? DateTime.Now : Convert.ToDateTime(dr["SentDate"].ToString());
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        public IEnumerable<bol_API_NotiListV2> GetNotiListV2(bol_NotiListReqModelV2 bol)
        {
            List<bol_API_NotiListV2> nl = new List<bol_API_NotiListV2>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_NotiListV2 n = new bol_API_NotiListV2();
                    bol_API_NotiDetailV2 nd = new bol_API_NotiDetailV2();
                    n.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    n.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    n.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    n.SentDate = dr["SentDate"] == null ? DateTime.Now : Convert.ToDateTime(dr["SentDate"].ToString());
                    n.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                    n.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    n.InfoImageUrl = dr["InfoImageUrl"] == null ? null : dr["InfoImageUrl"].ToString();

                    if (n.Category == "Information")
                    {
                        string InfoUrl = "Noti/Detail";
                        n.PromoUrl = bol.OriginLocationRFF + InfoUrl + "?custaccno=" + bol.CustAccNo + "&id=" + n.ID;
                    }
                    else if (n.Category == "Transaction")
                    {
                        string TxnUrl = "Noti/Detail";
                        n.PromoUrl = bol.OriginLocationRFF + TxnUrl + "?custaccno=" + bol.CustAccNo + "&id=" + n.ID;
                    }
                    else if (n.Category == "Promotion")
                    {
                        n.PromoUrl = dr["PromoUrl"] == null ? null : dr["PromoUrl"].ToString();
                    }

                    if (dr["IsRead"] != DBNull.Value)
                    {
                        n.IsRead = bool.Parse(dr["IsRead"].ToString());
                    }
                    if (dr["merch_order_id"] != DBNull.Value)
                    {
                        nd.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                        nd.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                        if (dr["DocumentAlias"] != DBNull.Value)
                        {
                            if (dr["DocumentAlias"].ToString() == "DEBIT_PAYMENT")
                            {
                                if (dr["merch_order_id"].ToString().StartsWith("DR"))
                                {
                                    nd.Type = "Debit note";
                                }
                                else
                                {
                                    nd.Type = "Regular Invoice";
                                }
                            }
                            if (dr["DocumentAlias"].ToString() == "ADVANCE_PAYMENT")
                            {
                                nd.Type = "Advance Payment";
                            }
                            if (dr["DocumentAlias"].ToString() == "RECHARGE_PAYMENT")
                            {
                                nd.Type = "Recharge Payment";
                            }
                            if (dr["DocumentAlias"].ToString() == "PREPAID_PAYMENT")
                            {
                                nd.Type = "Prepaid Payment";
                            }

                        }
                        nd.BillMonth = dr["BillMonth"] == null ? null : dr["BillMonth"].ToString();
                        if (dr["TransactionAmount"] != DBNull.Value)
                        {
                            if (dr["TransactionAmount"].ToString() != "")
                            {
                                //nd.Amount = double.Parse(dr["TransactionAmount"].ToString());
                                //nd.Amount.ToString("N", new System.Globalization.CultureInfo("en-US"));

                                double Amount = double.Parse(dr["TransactionAmount"].ToString());
                                nd.Amount = Amount.ToString("N", new System.Globalization.CultureInfo("en-US"));
                            }
                        }
                        nd.BillInvoiceNo = dr["BillInvoiceNo"] == null ? null : dr["BillInvoiceNo"].ToString();
                        nd.PaymentMethod = dr["PaymentOperator"] == null ? null : dr["PaymentOperator"].ToString();
                        nd.TransactionDate = dr["TransactionDate"] == null ? null : dr["TransactionDate"].ToString();
                        nd.CurrencyAlias = dr["CurrencyAlias"] == null ? null : dr["CurrencyAlias"].ToString();

                        n.Detail = nd;
                    }
                    else
                    {
                        n.Detail = new object { };
                    }
                    nl.Add(n);
                }
            }
            return nl;
        }

        #endregion

        #region[AppImageList]
        public IEnumerable<bol_API_ImageList> GetImageList(bol_API_ImageList bol)
        {
            List<bol_API_ImageList> csetups = new List<bol_API_ImageList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 7);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_ImageList csetup = new bol_API_ImageList();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.BillingArea = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
                    csetup.ImageType = dr["ImageType"] == null ? null : dr["ImageType"].ToString();
                    csetup.ImageUrl = dr["ImageUrl"] == null ? null : dr["ImageUrl"].ToString();
                    csetup.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup.LearnMoreUrl = dr["LearnMoreUrl"] == null ? null : dr["LearnMoreUrl"].ToString();
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        #endregion

        #region[RegionList]
        public IEnumerable<bol_API_RegionList> GetRegionList(bol_API_RegionList bol)
        {
            List<bol_API_RegionList> csetups = new List<bol_API_RegionList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_RegionDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 6);
                cmd.Parameters.AddWithValue("@Region", bol.Region);
                cmd.Parameters.AddWithValue("@ActionType", bol.ActionType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_RegionList csetup = new bol_API_RegionList();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.RegionID = dr["RegionID"] == null ? 0 : Convert.ToInt32(dr["RegionID"].ToString());
                    csetup.ActionTypeID = dr["ActionTypeID"] == null ? 0 : Convert.ToInt32(dr["ActionTypeID"].ToString());
                    csetup.Region = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
                    csetup.ActionType = dr["ActionType"] == null ? null : dr["ActionType"].ToString();
                    csetup.PrimaryPhoneNo = dr["PrimaryPhoneNo"] == null ? null : dr["PrimaryPhoneNo"].ToString();
                    csetup.SecondaryPhoneNos = dr["SecondaryPhoneNos"] == null ? null : dr["SecondaryPhoneNos"].ToString();
                    csetup.PrimaryEmail = dr["PrimaryEmail"] == null ? null : dr["PrimaryEmail"].ToString();
                    csetup.CCEmails = dr["CCEmails"] == null ? null : dr["CCEmails"].ToString();
                    csetup.BCCEmails = dr["BCCEmails"] == null ? null : dr["BCCEmails"].ToString();
                    csetup.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                    csetup.LatAndLong = dr["LatAndLong"] == null ? null : dr["LatAndLong"].ToString();
                    csetup.Facebook = dr["Facebook"] == null ? null : dr["Facebook"].ToString();
                    csetup.Youtube = dr["Youtube"] == null ? null : dr["Youtube"].ToString();
                    csetup.ShowRoomName = dr["ShowRoomName"] == null ? null : dr["ShowRoomName"].ToString();
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }


        #endregion


        #region[Referrals]
        public class ReferralParams
        {
            public string ParamType { get; set; }
            public string ParamValue { get; set; }
        }

        List<ReferralParams> ref_params = new List<ReferralParams>() {
            new ReferralParams(){ ParamType = "CusAccNo", ParamValue="{##custAccNo##}"},
            new ReferralParams(){ ParamType = "Name", ParamValue="{##name##}"},
            new ReferralParams(){  ParamType = "ReferralCode", ParamValue="{##referralCode##}"}
        };


        public async Task<ResultMsg> InsertReferral(bol_API_GetReferral bol)
        {
            int resp_code = 0;
            bol_API_GetReferralResModel gr = new bol_API_GetReferralResModel();


            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_Referrals", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ActionField", bol.ActionField);
                    cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                    cmd.Parameters.AddWithValue("@MobileNumber", bol.MobileNumber);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resp_code = int.Parse(dr["RespCode"].ToString());
                        gr.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                        gr.MobileNumber = dr["MobileNumber"] == null ? null : dr["MobileNumber"].ToString();
                        gr.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        gr.ReferralCode = dr["ReferralCode"] == null ? null : dr["ReferralCode"].ToString();
                        gr.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                        string body = dr["Content"] == null ? null : dr["Content"].ToString();
                        string strContent = dr["Content"] == null ? null : dr["Content"].ToString();
                        //gr.Content = dr["Content"] == null ? null : dr["Content"].ToString();

                        foreach (var p in ref_params.ToList())
                        {
                            var regex = new System.Text.RegularExpressions.Regex(p.ParamValue);
                            if (regex.IsMatch(body))
                            {
                                string ParamType = "";

                                string strReplaced = "";
                                if (p.ParamValue == "{##referralCode##}")
                                {
                                    strReplaced = strContent.Replace(p.ParamValue, gr.ReferralCode);
                                }
                                else if (p.ParamValue == "{##custAccNo##}")
                                {
                                    strReplaced = strContent.Replace(p.ParamValue, gr.CustAccNo);
                                }
                                else if (p.ParamValue == "{##name##}")
                                {
                                    strReplaced = strContent.Replace(p.ParamValue, gr.Name);
                                }
                                strContent = strReplaced;
                            }

                        }

                        gr.Content = strContent;
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString(), Data = gr };
            }

            return new ResultMsg() { Result = resp_code.ToString(), Data = gr };

        }

        public bol_API_GetReferralResModel GetReferralByCustAccNo(bol_API_GetReferral bol)
        {
            bol_API_GetReferralResModel gr = new bol_API_GetReferralResModel();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_Referrals", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    gr.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    gr.MobileNumber = dr["MobileNumber"] == null ? null : dr["MobileNumber"].ToString();
                    gr.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    gr.ReferralCode = dr["ReferralCode"] == null ? null : dr["ReferralCode"].ToString();
                    gr.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    gr.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                }
            }
            return gr;
        }
        #endregion

        #region Level 2 Form 
        public bol_API_CheckVerification GetCheckVerification(bol_API_CheckVerification bol)
        {
            bol_API_CheckVerification cv = new bol_API_CheckVerification();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CustomerAccountLevel2", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cv.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    cv.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    cv.UpdateMobileNo = dr["UpdateMobileNo"] == null ? null : dr["UpdateMobileNo"].ToString();
                    cv.Step = dr["Step"] == null ? 0 : Convert.ToInt32(dr["Step"].ToString());
                    cv.VerifiedDate = dr["VerifiedDate"] == null ? null : dr["VerifiedDate"].ToString();
                    cv.UpdateNRC = dr["UpdateNRC"] == null ? null : dr["UpdateNRC"].ToString();
                    cv.UpdateNRCCode = dr["UpdateNRCCode"] == null ? null : dr["UpdateNRCCode"].ToString();
                    cv.UpdateNRCTownship = dr["UpdateNRCTownship"] == null ? null : dr["UpdateNRCTownship"].ToString();
                    cv.UpdateNRCA = dr["UpdateNRCA"] == null ? null : dr["UpdateNRCA"].ToString();
                    cv.UpdateNRCNo = dr["UpdateNRCNo"] == null ? null : dr["UpdateNRCNo"].ToString();

                    cv.SendVCodeStep1Count = dr["SendVCodeStep1Count"] == null ? 0 : Convert.ToInt32(dr["SendVCodeStep1Count"].ToString());
                    cv.SendVCodeStep3Count = dr["SendVCodeStep3Count"] == null ? 0 : Convert.ToInt32(dr["SendVCodeStep3Count"].ToString());
                    cv.Nationality = dr["nationality"] == null ? null : dr["nationality"].ToString();
                    cv.PassportNo = dr["PassportNo"] == null ? null : dr["PassportNo"].ToString();
                    cv.VerifyBy = dr["VerifyBy"] == null ? null : dr["VerifyBy"].ToString();
                    cv.SMSStep = dr["SMSStep"] == null ? 0 : Convert.ToInt32(dr["SMSStep"].ToString());
                    cv.Step1SMSStatus = dr["Step1SMSStatus"] == null ? null : dr["Step1SMSStatus"].ToString();
                    cv.Step3SMSStatus = dr["Step3SMSStatus"] == null ? null : dr["Step3SMSStatus"].ToString();
                }
            }
            return cv;
        }
        #endregion

        #region Get Plan By CustAccNo
        public bol_API_GetPlanByCustAccNo GetPlanByCustAccNo(bol_API_GetPlanByCustAccNo bol)
        {
            bol_API_GetPlanByCustAccNo gp = new bol_API_GetPlanByCustAccNo();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_GetDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gp.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    gp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    gp.Price = dr["Price"] == DBNull.Value ? 0 : double.Parse(dr["Price"].ToString());
                }
            }
            return gp;
        }
        #endregion

        #region[GetPlanPriceList]
        public IEnumerable<bol_API_PlanPriceList> GetPlanPriceList(bol_API_PlanPriceListByCustAccNo bol)
        {
            List<bol_API_PlanPriceList> ppl = new List<bol_API_PlanPriceList>();
            int ActionParam = 30;

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_PlanPriceList pp = new bol_API_PlanPriceList();
                    pp.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    pp.PromoName_Eng = dr["PromoName_Eng"] == null ? null : dr["PromoName_Eng"].ToString();
                    pp.PromoName_MM = dr["PromoName_MM"] == null ? null : dr["PromoName_MM"].ToString();
                    pp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    pp.Price = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());

                    if (dr["Amount"] != DBNull.Value)
                    {
                        int Amount = int.Parse(dr["Amount"].ToString());
                        pp.Amount = String.Format("{0:n0}", Amount) + " MMK";
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    if (dr["Amount"] != DBNull.Value)
                    {
                        pp.CalculateAmount = Convert.ToInt32(dr["Amount"].ToString());
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    pp.Note = dr["Note"] == null ? null : dr["Note"].ToString();




                    if (dr["SurchargePercentage"] != DBNull.Value)
                    {
                        pp.TaxPercentage = Convert.ToInt32(dr["SurchargePercentage"].ToString());
                    }
                    else
                    {
                        pp.TaxPercentage = 0;
                    }

                    pp.CalculateTaxAmount = dr["TaxAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TaxAmount"].ToString());
                    if (dr["TaxAmount"] != DBNull.Value)
                    {
                        int TaxAmount = int.Parse(dr["TaxAmount"].ToString());
                        pp.TaxAmount = String.Format("{0:n0}", TaxAmount) + " MMK";
                    }
                    else
                    {
                        pp.TaxAmount = "0";
                    }

                    pp.CalculateTotalAmount = dr["TotalAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TotalAmount"].ToString());
                    if (dr["TotalAmount"] != DBNull.Value)
                    {
                        int TotalAmount = int.Parse(dr["TotalAmount"].ToString());
                        pp.TotalAmount = String.Format("{0:n0}", TotalAmount) + " MMK";
                    }
                    else
                    {
                        pp.TotalAmount = "0";
                    }

                    ppl.Add(pp);
                }
            }
            return ppl;
        }
        public bol_API_CurrentPlan GetCurrentPlan(bol_API_PlanPriceListByCustAccNo bol)
        {
            bol_API_CurrentPlan bol_cp = new bol_API_CurrentPlan();
            int ActionParam = 31;

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_cp.AdvancePaymentFormID = dr["AdvancePaymentFormID"] == null ? 0 : Convert.ToInt32(dr["AdvancePaymentFormID"].ToString());
                    bol_cp.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    bol_cp.PromoName_Eng = dr["PromoName_Eng"] == null ? null : dr["PromoName_Eng"].ToString();
                    bol_cp.PromoName_MM = dr["PromoName_MM"] == null ? null : dr["PromoName_MM"].ToString();
                    bol_cp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    if (dr["Price"] != DBNull.Value)
                    {
                        int Price = int.Parse(dr["Price"].ToString());
                        bol_cp.Price = Price;
                    }
                    else
                    {
                        bol_cp.Price = 0;
                    }
                    var test = dr["Amount"];
                    if (dr["Amount"] != DBNull.Value)
                    {
                        int Amount = Convert.ToInt32(dr["Amount"]);
                        bol_cp.Amount = String.Format("{0:n0}", Amount) + " MMK";
                    }
                    else
                    {
                        bol_cp.Amount = "0";
                    }
                    bol_cp.BankForPayment = dr["BankForPayment"] == null ? null : dr["BankForPayment"].ToString();


                    if (dr["SurchargePercentage"] != DBNull.Value)
                    {
                        bol_cp.TaxPercentage = Convert.ToInt32(dr["SurchargePercentage"].ToString());
                    }
                    else
                    {
                        bol_cp.TaxPercentage = 0;
                    }

                    //bol_cp.CalculateTaxAmount = dr["TaxAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TaxAmount"].ToString());
                    if (dr["TaxAmount"] != DBNull.Value)
                    {
                        int TaxAmount = int.Parse(dr["TaxAmount"].ToString());
                        bol_cp.TaxAmount = String.Format("{0:n0}", TaxAmount) + " MMK";
                    }
                    else
                    {
                        bol_cp.TaxAmount = "0";
                    }

                    //bol_cp.CalculateTotalAmount = dr["TotalAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TotalAmount"].ToString());
                    if (dr["TotalAmount"] != DBNull.Value)
                    {
                        int TotalAmount = int.Parse(dr["TotalAmount"].ToString());
                        bol_cp.TotalAmount = String.Format("{0:n0}", TotalAmount) + " MMK";
                    }
                    else
                    {
                        bol_cp.TotalAmount = "0";
                    }
                }
            }
            return bol_cp;
        }

        public IEnumerable<bol_API_PXPlanPriceList> GetPXPlanPriceList(bol_API_PlanPriceListByCustAccNo bol)
        {
            List<bol_API_PXPlanPriceList> ppl = new List<bol_API_PXPlanPriceList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_PXPlanPriceList pp = new bol_API_PXPlanPriceList();
                    //pp.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    pp.PackageID = dr["PackageID"] == null ? null : dr["PackageID"].ToString();
                    pp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    pp.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    pp.PkgDisplayName = dr["PkgDisplayName"] == null ? null : dr["PkgDisplayName"].ToString();
                    pp.Price = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());

                    if (dr["Amount"] != DBNull.Value)
                    {
                        int Amount = int.Parse(dr["Amount"].ToString());
                        pp.Amount = String.Format("{0:n0}", Amount) + " MMK";
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    if (dr["Amount"] != DBNull.Value)
                    {
                        pp.CalculateAmount = Convert.ToInt32(dr["Amount"].ToString());
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    //pp.Note = dr["Note"] == null ? null : dr["Note"].ToString();



                    if (dr["SurchargePercentage"] != DBNull.Value)
                    {
                        pp.TaxPercentage = Convert.ToInt32(dr["SurchargePercentage"].ToString());
                    }
                    else
                    {
                        pp.TaxPercentage = 0;
                    }

                    pp.CalculateTaxAmount = dr["TaxAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TaxAmount"].ToString());
                    if (dr["TaxAmount"] != DBNull.Value)
                    {
                        int TaxAmount = int.Parse(dr["TaxAmount"].ToString());
                        pp.TaxAmount = String.Format("{0:n0}", TaxAmount) + " MMK";
                    }
                    else
                    {
                        pp.TaxAmount = "0";
                    }

                    pp.CalculateTotalAmount = dr["TotalAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TotalAmount"].ToString());
                    if (dr["TotalAmount"] != DBNull.Value)
                    {
                        int TotalAmount = int.Parse(dr["TotalAmount"].ToString());
                        pp.TotalAmount = String.Format("{0:n0}", TotalAmount) + " MMK";
                    }
                    else
                    {
                        pp.TotalAmount = "0";
                    }

                    pp.DownloadSpeed = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString() + " " + dr["DownloadUnit"].ToString();
                    pp.UploadSpeed = dr["UploadSpeed"] == null ? null : dr["UploadSpeed"].ToString() + " " + dr["UploadUnit"].ToString();
                    //pp.Validity = dr["Validity"] == null ? null : dr["Validity"].ToString();
                    if (dr["Validity"] != DBNull.Value)
                    {
                        pp.Validity = Convert.ToInt32(dr["Validity"].ToString());
                        //pp.Validity = dr["Validity"].ToString() + " Days";
                    }
                    else
                    {
                        pp.Validity = 0;
                    }
                    if (dr["PromoDay"] != DBNull.Value)
                    {
                        pp.PromoDay = Convert.ToInt32(dr["PromoDay"].ToString());
                        //pp.PromoDay = dr["PromoDay"].ToString() + " Days";
                    }
                    else
                    {
                        pp.PromoDay = 0;
                    }

                    pp.ValidityLabel = pp.Validity.ToString() + " Days" + (pp.PromoDay == 0 ? "" : " + Promo " + pp.PromoDay.ToString() + " Days");

                    if (dr["SortOrder"] != DBNull.Value)
                    {
                        pp.SortOrder = Convert.ToInt32(dr["SortOrder"].ToString());
                    }
                    else
                    {
                        pp.SortOrder = 0;
                    }

                    ppl.Add(pp);
                }
            }
            return ppl;
        }

        public bol_API_CurrentPXPlanPriceList GetCurrentPXPlan(bol_API_PlanPriceListByCustAccNo bol)
        {
            bol_API_CurrentPXPlanPriceList pp = new bol_API_CurrentPXPlanPriceList();
            int ActionParam = 2;

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //pp.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    pp.PackageID = dr["PackageID"] == null ? null : dr["PackageID"].ToString();
                    pp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    pp.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    pp.PkgDisplayName = dr["PkgDisplayName"] == null ? null : dr["PkgDisplayName"].ToString();
                    pp.Price = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());

                    if (dr["Amount"] != DBNull.Value)
                    {
                        int Amount = int.Parse(dr["Amount"].ToString());
                        pp.Amount = String.Format("{0:n0}", Amount) + " MMK";
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    if (dr["Amount"] != DBNull.Value)
                    {
                        pp.CalculateAmount = Convert.ToInt32(dr["Amount"].ToString());
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    //pp.Note = dr["Note"] == null ? null : dr["Note"].ToString();



                    if (dr["SurchargePercentage"] != DBNull.Value)
                    {
                        pp.TaxPercentage = Convert.ToInt32(dr["SurchargePercentage"].ToString());
                    }
                    else
                    {
                        pp.TaxPercentage = 0;
                    }

                    pp.CalculateTaxAmount = dr["TaxAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TaxAmount"].ToString());
                    if (dr["TaxAmount"] != DBNull.Value)
                    {
                        int TaxAmount = int.Parse(dr["TaxAmount"].ToString());
                        pp.TaxAmount = String.Format("{0:n0}", TaxAmount) + " MMK";
                    }
                    else
                    {
                        pp.TaxAmount = "0";
                    }

                    pp.CalculateTotalAmount = dr["TotalAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TotalAmount"].ToString());
                    if (dr["TotalAmount"] != DBNull.Value)
                    {
                        int TotalAmount = int.Parse(dr["TotalAmount"].ToString());
                        pp.TotalAmount = String.Format("{0:n0}", TotalAmount) + " MMK";
                    }
                    else
                    {
                        pp.TotalAmount = "0";
                    }

                    pp.DownloadSpeed = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString() + " " + dr["DownloadUnit"].ToString();
                    pp.UploadSpeed = dr["UploadSpeed"] == null ? null : dr["UploadSpeed"].ToString() + " " + dr["UploadUnit"].ToString();
                    //pp.Validity = dr["Validity"] == null ? null : dr["Validity"].ToString();
                    if (dr["Validity"] != DBNull.Value)
                    {
                        pp.Validity = Convert.ToInt32(dr["Validity"].ToString());
                        //pp.Validity = dr["Validity"].ToString() + " Days";
                    }
                    else
                    {
                        pp.Validity = 0;
                    }
                    if (dr["PromoDay"] != DBNull.Value)
                    {
                        pp.PromoDay = Convert.ToInt32(dr["PromoDay"].ToString());
                        //pp.PromoDay = dr["PromoDay"].ToString() + " Days";
                    }
                    else
                    {
                        pp.PromoDay = 0;
                    }

                    pp.ValidityLabel = pp.Validity.ToString() + " Days" + (pp.PromoDay == 0 ? "" : " + Promo " + pp.PromoDay.ToString() + " Days");

                    if (dr["SortOrder"] != DBNull.Value)
                    {
                        pp.SortOrder = Convert.ToInt32(dr["SortOrder"].ToString());
                    }
                    else
                    {
                        pp.SortOrder = 0;
                    }

                    pp.ExpiryDate = dr["ExpiryDate"] == DBNull.Value ? "": dr["ExpiryDate"].ToString();
                    pp.NextPlanStartDate = dr["NextPlanStartDate"] == DBNull.Value ? "" : dr["NextPlanStartDate"].ToString();

                    pp.StartDate = dr["StartDate"] == DBNull.Value ? "" : dr["StartDate"].ToString();
                    pp.EndDate = dr["EndDate"] == DBNull.Value ? "" : dr["EndDate"].ToString();

                    pp.ExpireIn = dr["ExpireIn"] == DBNull.Value ? "0 Days" : dr["ExpireIn"].ToString() + " Days";

                    #region Expirein
                    try
                    {
                        var localDateTimeOffset_FromDate = DateTime.Parse(pp.StartDate.Substring(6, 4) + "/" + pp.StartDate.Substring(3, 2) + "/" + pp.StartDate.Substring(0, 2) + " " + pp.StartDate.Substring(10, 9));
                        var localDateTimeOffset_ToDate = DateTime.Parse(pp.EndDate.Substring(6, 4) + "/" + pp.EndDate.Substring(3, 2) + "/" + pp.EndDate.Substring(0, 2) + " " + pp.EndDate.Substring(10, 9)); 

                        var localDateTimeOffset_FromDate_short = DateTime.Parse(pp.StartDate.Substring(6, 4) + "/" + pp.StartDate.Substring(3, 2) + "/" + pp.StartDate.Substring(0, 2)).ToLongDateString();
                        var localDateTimeOffset_ToDate_short = DateTime.Parse(pp.EndDate.Substring(6, 4) + "/" + pp.EndDate.Substring(3, 2) + "/" + pp.EndDate.Substring(0, 2)).ToLongDateString();

                        double days = (DateTime.Parse(localDateTimeOffset_ToDate_short) - DateTime.Parse(DateTime.Now.ToShortDateString())).TotalDays;
                        //double hours = (localDateTimeOffset_ToDate - DateTime.Now).TotalHours;
                        //double minutes = (localDateTimeOffset_ToDate - DateTime.Now).TotalMinutes;
                        
                        DateTime myanmarStandardTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "Myanmar Standard Time");
                        //string mmtime = myanmarStandardTime.ToString("yyyy/MM/dd HH:mm:ss");

                        double hours = (localDateTimeOffset_ToDate - myanmarStandardTime).TotalHours;
                        double minutes = (localDateTimeOffset_ToDate - myanmarStandardTime).TotalMinutes;

                        DateTime dt1 = DateTime.Parse(localDateTimeOffset_FromDate.ToString("yyyy/MM/dd HH:mm:ss"));
                        DateTime dt2 = DateTime.Parse(localDateTimeOffset_ToDate.ToString("yyyy/MM/dd HH:mm:ss"));

                        if (minutes < 0)
                        {
                            pp.ExpireIn = "Expired";
                        }
                        else if (minutes <= 60)
                        {
                            pp.ExpireIn = "1 Hour";
                        }
                        else if (minutes < 1440)
                        {
                            var split_hours = hours.ToString().Split('.');
                            int hrs = 0;
                            var tst = split_hours[1].ToString();
                            char c = tst[0];
                            int startwith_hrs = int.Parse(c.ToString());
                            if (startwith_hrs >= 5)
                            {
                                hrs = int.Parse(split_hours[0].ToString()) + 1;
                            }
                            else
                            {
                                hrs = int.Parse(split_hours[0].ToString());
                            }

                            if (hrs > 1)
                            {
                                pp.ExpireIn = hrs.ToString() + " Hours";
                            }
                            else
                            {
                                pp.ExpireIn = "1 Hour";
                            }

                        }
                        else
                        {
                            pp.ExpireIn = days.ToString() + " Days";
                        }
                    }
                    catch (Exception ex)
                    {
                        pp.ExpireIn = "0 Days";
                    }
                    #endregion
                }
            }
            return pp;
        }

        public bol_API_NextPXPlanPriceList GetNextPXPlan(bol_API_PlanPriceListByCustAccNo bol)
        {
            bol_API_NextPXPlanPriceList pp = new bol_API_NextPXPlanPriceList();
            int ActionParam = 4;

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    //pp.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    pp.PackageID = dr["PackageID"] == null ? null : dr["PackageID"].ToString();
                    pp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    pp.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                    pp.PkgDisplayName = dr["PkgDisplayName"] == null ? null : dr["PkgDisplayName"].ToString();
                    pp.Price = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());

                    if (dr["Amount"] != DBNull.Value)
                    {
                        int Amount = int.Parse(dr["Amount"].ToString());
                        pp.Amount = String.Format("{0:n0}", Amount) + " MMK";
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    if (dr["Amount"] != DBNull.Value)
                    {
                        pp.CalculateAmount = Convert.ToInt32(dr["Amount"].ToString());
                    }
                    else
                    {
                        pp.Amount = "0";
                    }

                    //pp.Note = dr["Note"] == null ? null : dr["Note"].ToString();



                    if (dr["SurchargePercentage"] != DBNull.Value)
                    {
                        pp.TaxPercentage = Convert.ToInt32(dr["SurchargePercentage"].ToString());
                    }
                    else
                    {
                        pp.TaxPercentage = 0;
                    }

                    pp.CalculateTaxAmount = dr["TaxAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TaxAmount"].ToString());
                    if (dr["TaxAmount"] != DBNull.Value)
                    {
                        int TaxAmount = int.Parse(dr["TaxAmount"].ToString());
                        pp.TaxAmount = String.Format("{0:n0}", TaxAmount) + " MMK";
                    }
                    else
                    {
                        pp.TaxAmount = "0";
                    }

                    pp.CalculateTotalAmount = dr["TotalAmount"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TotalAmount"].ToString());
                    if (dr["TotalAmount"] != DBNull.Value)
                    {
                        int TotalAmount = int.Parse(dr["TotalAmount"].ToString());
                        pp.TotalAmount = String.Format("{0:n0}", TotalAmount) + " MMK";
                    }
                    else
                    {
                        pp.TotalAmount = "0";
                    }

                    pp.DownloadSpeed = dr["DownloadSpeed"] == null ? null : dr["DownloadSpeed"].ToString() + " " + dr["DownloadUnit"].ToString();
                    pp.UploadSpeed = dr["UploadSpeed"] == null ? null : dr["UploadSpeed"].ToString() + " " + dr["UploadUnit"].ToString();
                    //pp.Validity = dr["Validity"] == null ? null : dr["Validity"].ToString();
                    if (dr["Validity"] != DBNull.Value)
                    {
                        pp.Validity = Convert.ToInt32(dr["Validity"].ToString());
                        //pp.Validity = dr["Validity"].ToString() + " Days";
                    }
                    else
                    {
                        pp.Validity = 0;
                    }
                    if (dr["PromoDay"] != DBNull.Value)
                    {
                        pp.PromoDay = Convert.ToInt32(dr["PromoDay"].ToString());
                        //pp.PromoDay = dr["PromoDay"].ToString() + " Days";
                    }
                    else
                    {
                        pp.PromoDay = 0;
                    }

                    pp.ValidityLabel = pp.Validity.ToString() + " Days" + (pp.PromoDay == 0 ? "" : " + Promo " + pp.PromoDay.ToString() + " Days");

                    if (dr["SortOrder"] != DBNull.Value)
                    {
                        pp.SortOrder = Convert.ToInt32(dr["SortOrder"].ToString());
                    }
                    else
                    {
                        pp.SortOrder = 0;
                    }

                    //pp.ExpiryDate = dr["ExpiryDate"] == DBNull.Value ? "" : dr["ExpiryDate"].ToString();
                    //pp.NextPlanStartDate = dr["NextPlanStartDate"] == DBNull.Value ? "" : dr["NextPlanStartDate"].ToString();

                    pp.StartDate = dr["StartDate"] == DBNull.Value ? "" : dr["StartDate"].ToString();
                    pp.EndDate = dr["EndDate"] == DBNull.Value ? "" : dr["EndDate"].ToString();
                }
            }
            return pp;
        }
       
        #endregion

        #region AdvancePaymentPlanAction
        public async Task<ResultMsg> AdvancePaymentPlanAction(bol_API_AdvancePaymentPlanAction bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@AdvancePaymentForMonths", bol.AdvancePaymentForMonths);
                cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                cmd.Parameters.AddWithValue("@BankForPayment", bol.BankForPayment);
                cmd.Parameters.AddWithValue("@OrderCode", bol.OrderCode);
                cmd.Parameters.AddWithValue("@Source", bol.Source);
                cmd.Parameters.AddWithValue("@ActionType", bol.ActionType);
                cmd.Connection = con;
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

            return new ResultMsg() { Result = resp_code, Message = resp_code == "1" ? "Save Successful!" : resp_code == "2" ? "Update Successful!" : resp_code == "3" ? "Cancel Successful!" : resp_code == "01" ? "Save Fail!" : resp_code == "02" ? "Update Fail!" : resp_code == "03" ? "Cancel Fail!" : resp_code == "14" ? "Already Received Payment! Not allowed to cancel." : "" };

        }
        #endregion

        #region [AccountVerification]
        public async Task<ResultMsg> InsertAccountVerification(bol_API_AccountVerification bol)
        {
            string resp_code = "";
            DataTable dt = new DataTable();
            dynamic data = dt;
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_AccountVerification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@VerifyType", bol.VerifyType);
                cmd.Parameters.AddWithValue("@VerifyAccount", bol.VerifyAccount);
                cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                cmd.Parameters.AddWithValue("@ExpireMinutes", bol.ExpireMinutes);
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();



                resp_code = dt.Rows.Count == 0 ? "0" : dt.Rows[0]["RespCode"].ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString(), Data = dt };
        }

        public async Task<ResultMsg> CheckAccountVerification(bol_API_AccountVerification bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_AccountVerification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@VerifyType", bol.VerifyType);
                cmd.Parameters.AddWithValue("@VerifyAccount", bol.VerifyAccount);
                //cmd.Parameters.AddWithValue("@VerifySecondaryAccount", bol.VerifySecondaryAccount);
                cmd.Parameters.AddWithValue("@VerificationCode", bol.VerificationCode);
                cmd.Parameters.AddWithValue("@ExpireMinutes", bol.ExpireMinutes);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public async Task<ResultMsg> UpdateAccountVerificationSyncBSS(bol_API_AccountVerification bol)
        {
            string resp_code = "";
            SqlConnection con = new SqlConnection(conn_str);

            try
            {
                SqlCommand cmd = new SqlCommand("sp_AccountVerification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@VerifyType", bol.VerifyType);
                cmd.Parameters.AddWithValue("@VerifyAccount", bol.VerifyAccount);
                //cmd.Parameters.AddWithValue("@VerifySecondaryAccount", bol.VerifySecondaryAccount);
                cmd.Parameters.AddWithValue("@VerificationCode", bol.VerificationCode);
                //cmd.Parameters.AddWithValue("@ExpireMinutes", bol.ExpireMinutes);
                cmd.Connection = con;
                con.Open();
                resp_code = cmd.ExecuteScalar().ToString();
                con.Close();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code.ToString() };
        }

        public IEnumerable<bol_API_EmailList_Result> GetEmailList(bol_API_EmailList bol)
        {
            List<bol_API_EmailList_Result> ppl = new List<bol_API_EmailList_Result>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_AccountVerification", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@CustAccNo", bol.CustAccNo);
                cmd.Parameters.AddWithValue("@VerifyType", bol.VerifyType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_EmailList_Result pp = new bol_API_EmailList_Result();
                    pp.Email = dr["Email"] == null ? null : dr["Email"].ToString();
                    pp.VerifiedDate = dr["VerifiedDate"] == null ? null : dr["VerifiedDate"].ToString();

                    if (dr["IsPrimary"] != DBNull.Value)
                    {
                        if (bool.Parse(dr["IsPrimary"].ToString()) == true)
                        {
                            pp.IsPrimary = true;
                        }
                        else
                        {
                            pp.IsPrimary = false;
                        }
                    }
                    else
                    {
                        pp.IsPrimary = false;
                    }

                    ppl.Add(pp);
                }
            }
            return ppl;
        }
        #endregion

        //#region [GetAccountHistory]
        //public async Task<ResultMsg> ActionAccountHistory(bol_API_BSS_SyncAccountHistory bol)
        //{
        //    int resp_code = 0;

        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_BSS_AccountHistory", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandTimeout = 300; //seconds = 5mins
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);

        //            cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
        //            cmd.Parameters.AddWithValue("@serviceInstanceNumber", bol.serviceInstanceNumber);
        //            cmd.Parameters.AddWithValue("@planName", bol.planName);
        //            cmd.Parameters.AddWithValue("@planStatus", bol.planStatus);
        //            cmd.Parameters.AddWithValue("@dateTime", bol.dateTime);
        //            cmd.Parameters.AddWithValue("@staffId", bol.staffId);
        //            cmd.Parameters.AddWithValue("@staffName", bol.staffName);

        //            cmd.Parameters.AddWithValue("@functionality", bol.functionality);
        //            cmd.Parameters.AddWithValue("@remark", bol.remark);
        //            cmd.Parameters.AddWithValue("@valueBefore", bol.valueBefore);
        //            cmd.Parameters.AddWithValue("@valueAfter", bol.valueAfter);


        //            cmd.Connection = con;
        //            await con.OpenAsync();
        //            resp_code = (int)await cmd.ExecuteScalarAsync();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code.ToString(), Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code.ToString() };

        //}

        //public bol_API_BSS_GetCreationDateByCustAccNo GetCreationDateByCustAccNo(bol_API_BSS_GetCreationDateByCustAccNo bol)
        //{
        //    bol_API_BSS_GetCreationDateByCustAccNo gcd = new bol_API_BSS_GetCreationDateByCustAccNo();

        //    using (SqlConnection con = new SqlConnection(conn_str))
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_BSS_AccountHistory", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
        //        con.Open();
        //        SqlDataReader dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            gcd.customerAccountNumber = dr["customerAccountNumber"] == null ? null : dr["customerAccountNumber"].ToString();
        //            gcd.creationDate = dr["creationDate"] == DBNull.Value ? DateTime.Now : DateTime.Parse(dr["creationDate"].ToString());
        //        }
        //    }
        //    return gcd;
        //}
        //#endregion

        //#region BillListAction
        //public async Task<ResultMsg> BillListAction(bol_API_BSS_SyncBillList bol)
        //{
        //    string resp_code = "";
        //    SqlConnection con = new SqlConnection(conn_str);

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand("sp_AdvancePaymentForm", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //        cmd.Parameters.AddWithValue("@customerAccountNumber", bol.customerAccountNumber);
        //        cmd.Parameters.AddWithValue("@billingAccountNumbrer", bol.billingAccountNumbrer);
        //        cmd.Parameters.AddWithValue("@AccountStatus", bol.AccountStatus);
        //        cmd.Parameters.AddWithValue("@CurrentPlan", bol.CurrentPlan);
        //        cmd.Parameters.AddWithValue("@Name", bol.Name);
        //        cmd.Parameters.AddWithValue("@billNumber", bol.billNumber);
        //        cmd.Parameters.AddWithValue("@documentType", bol.documentType);
        //        cmd.Parameters.AddWithValue("@amount", bol.amount);
        //        cmd.Parameters.AddWithValue("@unpaidAmount", bol.unpaidAmount);
        //        cmd.Parameters.AddWithValue("@billDate", bol.billDate);
        //        cmd.Parameters.AddWithValue("@dueDate", bol.dueDate);
        //        cmd.Parameters.AddWithValue("@billStatus", bol.billStatus);
        //        cmd.Parameters.AddWithValue("@disputedStatus", bol.disputedStatus);
        //        cmd.Parameters.AddWithValue("@billMonth", bol.billMonth);
        //        cmd.Parameters.AddWithValue("@billId", bol.billId);
        //        cmd.Parameters.AddWithValue("@currencyName", bol.currencyName);
        //        cmd.Connection = con;
        //        con.Open();
        //        resp_code = cmd.ExecuteScalar().ToString();
        //        con.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code.ToString() };
        //}
        //#endregion

        #region[Get Noti Template By SubType]
        public IEnumerable<bol_API_SDFNOTI> GetNotiTemplateBySubType(string subtype)
        {
            List<bol_API_SDFNOTI> csetups = new List<bol_API_SDFNOTI>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Template", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 13);
                cmd.Parameters.AddWithValue("@SubType", subtype);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_SDFNOTI csetup = new bol_API_SDFNOTI();
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    csetup.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                    csetup.Content = dr["Content"] == null ? null : dr["Content"].ToString();
                    csetup.BodyDetail = dr["BodyDetail"] == null ? null : dr["BodyDetail"].ToString();
                    csetup.Type = dr["Type"] == null ? null : dr["Type"].ToString();
                    csetup.SubType = dr["SubType"] == null ? null : dr["SubType"].ToString();
                    csetup.InfoImageUrl = dr["InfoImageUrl"] == null ? null : dr["InfoImageUrl"].ToString();
                    csetup.IsActive = dr["IsActive"] == null ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                    csetups.Add(csetup);
                }
            }
            return csetups;
        }

        #endregion

        public ResultMsg InsertAppExceptionLog(bol_API_AppExceptionLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_API_AppExceptionLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@OS", bol.OS);
                    cmd.Parameters.AddWithValue("@VersionNo", bol.VersionNo);
                    cmd.Parameters.AddWithValue("@AppVersion", bol.AppVersion);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@URL", bol.URL);
                    cmd.Parameters.AddWithValue("@ExceptionType", bol.ExceptionType);
                    cmd.Parameters.AddWithValue("@ExceptionMessage", bol.ExceptionMessage);
                    cmd.Parameters.AddWithValue("@RequestData", bol.RequestData);
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

        #region Ourdoor Sales
        //public ResultMsg Login(bol_API_Login_History_Log bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_API_UserAuthentication", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@ProjectCode", bol.ProjectCode);
        //            cmd.Parameters.AddWithValue("@username", bol.UserName);
        //            cmd.Parameters.AddWithValue("@password", bol.Password);
        //            cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
        //            cmd.Connection = con;
        //            con.Open();
        //            //cmd.ExecuteNonQuery();
        //            resp_code = cmd.ExecuteScalar().ToString();
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
        //    }

        //    return new ResultMsg() { Result = resp_code };

        //}

        public bol_API_Login Login(bol_API_Login_History_Log bol)
        {
            bol_API_Login li = new bol_API_Login();
            ResultMsg rm = new ResultMsg();
            bol_API_LoginUser liu = new bol_API_LoginUser();
            List<bol_API_DataVersion> dv = new List<bol_API_DataVersion>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("sp_API_UserAuthentication", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ProjectCode", bol.ProjectCode);
                cmd.Parameters.AddWithValue("@username", bol.UserName);
                cmd.Parameters.AddWithValue("@password", bol.Password);
                cmd.Parameters.AddWithValue("@DeviceID", bol.DeviceID);
                //cmd.Connection = con;
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        rm.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                        rm.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                        rm.Data = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());

                        li.result = rm;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["userName"].ToString() != "")
                        {
                            liu.UserName = ds.Tables[1].Rows[0]["userName"].ToString();
                            liu.FullName = ds.Tables[1].Rows[0]["fullName"].ToString();
                            liu.Role = ds.Tables[1].Rows[0]["role"].ToString();
                        }

                        li.user = liu;
                    }
                    else
                    {
                        li.user = liu;
                    }

                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        //var json_dv = JsonConvert.SerializeObject(ds.Tables[2]);
                        //List<bol_API_DataVersion> list_dv = JsonConvert.DeserializeObject<List<bol_API_DataVersion>>(json_dv);

                        List<bol_API_DataVersion> list_dv = new List<bol_API_DataVersion>();
                        list_dv = (from DataRow dr in ds.Tables[2].Rows
                                   select new bol_API_DataVersion()
                                   {
                                       ProjectCode = dr["ProjectCode"].ToString(),
                                       Item = dr["Item"].ToString(),
                                       Version = dr["Version"].ToString(),
                                       UpdatedDate = Convert.ToDateTime(dr["UpdatedDate"])

                                   }
                                    ).ToList();


                        //dv.ProjectCode = ds.Tables[2].Rows[0]["ProjectCode"].ToString();
                        //dv.Item = ds.Tables[2].Rows[0]["Item"].ToString();
                        //dv.Version = ds.Tables[2].Rows[0]["Version"].ToString();
                        //dv.UpdatedDate = ds.Tables[2].Rows[0]["UpdatedDate"].ToString();

                        li.dataVersion = list_dv;
                    }
                    else
                    {
                        li.dataVersion = dv;
                    }
                }
            }
            return li;
        }
        #endregion

        #region[City, Township, Plan, Switch]
        public IEnumerable<bol_API_City_Response> GetCity(bol_API_City bol)
        {
            List<bol_API_City_Response> cities = new List<bol_API_City_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_City_Response city = new bol_API_City_Response();
                    city.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    city.CityName = dr["CityName"] == null ? null : dr["CityName"].ToString();
                    city.CityName_MM = dr["CityName_MM"] == null ? null : dr["CityName_MM"].ToString();
                    city.OrderNo = dr["OrderNo"] == null ? 0 : Convert.ToInt32(dr["OrderNo"].ToString());

                    cities.Add(city);
                }
            }
            return cities;
        }
        public IEnumerable<bol_API_City_Response> GetCityByPermission(bol_API_City_Req bol)
        {
            List<bol_API_City_Response> regions = new List<bol_API_City_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 24);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_City_Response region = new bol_API_City_Response();
                    region.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    region.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    region.CityName_MM = dr["CityName_MM"] == null ? null : dr["CityName_MM"].ToString();
                    region.OrderNo = dr["OrderNo"] == null ? 0 : Convert.ToInt32(dr["OrderNo"].ToString());
                    regions.Add(region);
                }
            }
            return regions;
        }

        public IEnumerable<bol_API_Township_Response> GetTownship(bol_API_Township bol)
        {
            List<bol_API_Township_Response> townships = new List<bol_API_Township_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 2);
                if (bol.City_ID != 0)
                {
                    cmd.Parameters.AddWithValue("@City_ID", bol.City_ID);
                }

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_Township_Response township = new bol_API_Township_Response();
                    township.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    township.City_ID = dr["City_ID"] == null ? 0 : Convert.ToInt32(dr["City_ID"].ToString());
                    township.Township = dr["Township"] == null ? null : dr["Township"].ToString();

                    townships.Add(township);
                }
            }
            return townships;
        }

        public IEnumerable<bol_API_ServiceBasePlan_Response> GetSBPlan(bol_API_ServiceBasePlan bol)
        {
            List<bol_API_ServiceBasePlan_Response> sbp_s = new List<bol_API_ServiceBasePlan_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 3);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_ServiceBasePlan_Response sbp = new bol_API_ServiceBasePlan_Response();
                    sbp.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    sbp.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    sbp.PlanName = dr["PlanName"] == null ? null : dr["PlanName"].ToString();
                    sbp.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    sbp.DownloadSpeed = dr["DownloadSpeed"] == null ? 0 : Convert.ToInt32(dr["DownloadSpeed"].ToString());
                    sbp.UploadSpeed = dr["UploadSpeed"] == null ? 0 : Convert.ToInt32(dr["UploadSpeed"].ToString());
                    sbp.DownloadUnit = dr["DownloadUnit"] == null ? null : dr["DownloadUnit"].ToString();
                    sbp.UploadUnit = dr["UploadUnit"] == null ? null : dr["UploadUnit"].ToString();
                    sbp.Features = dr["Features"] == null ? null : dr["Features"].ToString();
                    sbp.Price = dr["Price"] == null ? 0 : Convert.ToInt32(dr["Price"].ToString());
                    sbp.Category = dr["Category"] == null ? null : dr["Category"].ToString();
                    sbp.planId = dr["planId"] == null ? null : dr["planId"].ToString();
                    sbp.PlanType = dr["PlanType"] == null ? null : dr["PlanType"].ToString();
                    sbp.Quota = dr["Quota"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Quota"].ToString());
                    sbp.Validity = dr["Validity"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Validity"].ToString());

                    sbp_s.Add(sbp);
                }
            }
            return sbp_s;
        }

        public bol_API_Login InsertOnOff(bol_API_OnOff bol)
        {
            bol_API_Login li = new bol_API_Login();
            ResultMsg rm = new ResultMsg();

            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    DataSet ds = new DataSet();

                    SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    //cmd.Connection = con;
                    //con.Open();
                    ////cmd.ExecuteNonQuery();
                    //resp_code = cmd.ExecuteScalar().ToString();
                    //con.Close();


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            rm.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                            rm.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                            rm.Data = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());

                            li.result = rm;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return li;
            }

            return li;
        }

        public ResultMsg InsertGPS(bol_API_GPS bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                    cmd.Parameters.AddWithValue("@BatteryPercentage", bol.BatteryPercentage);
                    cmd.Parameters.AddWithValue("@ActionID", bol.ActionID);
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

        public ResultMsg InsertLeadForm(bol_API_LeadForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.userName);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Phone", bol.Phone);
                    cmd.Parameters.AddWithValue("@Email", bol.Email);
                    cmd.Parameters.AddWithValue("@Plan", bol.Plan);
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@Township", bol.Township);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
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

        #region PAY_PaymentMethod
        public IEnumerable<bol_API_PAY_PaymentMethod_Response> GetPaymentMethod(bol_API_PAY_PaymentMethod bol)
        {
            List<bol_API_PAY_PaymentMethod_Response> pm_s = new List<bol_API_PAY_PaymentMethod_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_MobileAPP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 4);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_PAY_PaymentMethod_Response pm = new bol_API_PAY_PaymentMethod_Response();

                    pm.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    pm.BankName = dr["BankName"] == null ? null : dr["BankName"].ToString();
                    pm.Code = dr["Value"] == null ? null : dr["Value"].ToString();
                    pm.Status = dr["Status"] == null ? null : dr["Status"].ToString();
                    pm.SortOrder = dr["SortOrder"] == null ? 0 : Convert.ToInt32(dr["SortOrder"].ToString());
                    pm.ImageUrl = dr["ImageUrl"] == null ? null : dr["ImageUrl"].ToString();
                    pm.IsMobileActive = dr["IsMobileActive"] == null ? false : bool.Parse(dr["IsMobileActive"].ToString());

                    pm_s.Add(pm);
                }
            }
            return pm_s;
        }
        #endregion

        #region Lead Collection
        public ResultMsg InsertLeadEntryForm(bol_API_LeadEntryForm bol)
        {
            string resp_code = "";
            bol_API_Res_LeadEntryForm model = new bol_API_Res_LeadEntryForm();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SPS_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@ServicePlanID", bol.ServicePlanID);
                    cmd.Parameters.AddWithValue("@LeadSourceID", bol.LeadSourceID);
                    cmd.Parameters.AddWithValue("@ChannelID", bol.ChannelID);
                    cmd.Parameters.AddWithValue("@Latitude", bol.Latitude);
                    cmd.Parameters.AddWithValue("@Longitude", bol.Longitude);
                    cmd.Parameters.AddWithValue("@LoggedBy", bol.LoggedBy);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@BatteryPercentage", bol.BatteryPercentage);
                    //if (bol.LoggedBy != null) { }
                    //else if (bol.LoggedBy != "") { }
                    //else
                    //{
                    //cmd.Parameters.AddWithValue("@LoggedBy", bol.LoggedBy);
                    //}
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    // resp_code = cmd.ExecuteScalar().ToString();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        model.RespCode = dr["RespCode"] == null ? null : dr["RespCode"].ToString();
                        model.SAID = dr["SAID"] == null ? 0 : Convert.ToInt32(dr["SAID"].ToString());
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = model.RespCode,Data=model.SAID };
        }
        #endregion

        #region[Get SPS Leads Count]
        public IEnumerable<bol_API_SPSLeadsCount_Response> GetSPSLeadsCount(bol_API_SPSLeadsCount bol)
        {
            List<bol_API_SPSLeadsCount_Response> list = new List<bol_API_SPSLeadsCount_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_MobileAppAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_SPSLeadsCount_Response data = new bol_API_SPSLeadsCount_Response();
                    data.Leads = dr["Leads"] == null ? 0 : Convert.ToInt32(dr["Leads"].ToString());
                    data.SalesWon = dr["SalesWon"] == null ? 0 : Convert.ToInt32(dr["SalesWon"].ToString());
                    data.TodayLeads = dr["TodayLeads"] == null ? 0 : Convert.ToInt32(dr["TodayLeads"].ToString());
                    data.TodaySalesWon = dr["TodaySalesWon"] == null ? 0 : Convert.ToInt32(dr["TodaySalesWon"].ToString());
                    list.Add(data);
                }
            }
            return list;
        }

        #endregion

        #region Change Password
        public ResultMsg ChangePassword(bol_API_ChangePassword bol)
        {
            string resp_code = "";
            bol_API_Res_ChangePassword model = new bol_API_Res_ChangePassword();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_MobileAPP_ChangePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@userName", bol.UserName);
                    cmd.Parameters.AddWithValue("@oldpassword", bol.OldPassword);
                    cmd.Parameters.AddWithValue("@newpassword", bol.NewPassword);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    // resp_code = cmd.ExecuteScalar().ToString();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        model.RespCode = dr["RespCode"] == null ? null : dr["RespCode"].ToString();
                        model.Message = dr["Message"] == null ? null : dr["Message"].ToString();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = model.RespCode, Data = model.Message };
        }
        #endregion

        #region Update PX Status
        public async Task<ResultMsg> UpdatePXStatus(bol_API_SyncPXChangeServicePlanModel bol)
        {
            string resp_code = "";
            bol_API_SyncPXChangeServicePlanModel model = new bol_API_SyncPXChangeServicePlanModel();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_PAY_Prepaid", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 13);
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.customerAccountNumber);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    // resp_code = cmd.ExecuteScalar().ToString();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        model.RespCode = dr["RespCode"] == null ? null : dr["RespCode"].ToString();
                    }

                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = model.RespCode };
        }
        #endregion

        #region[Get SPS Cash Collector Dashboard]
        public IEnumerable<bol_API_SPSCashCollectorDashboard_Response> GetSPSCashCollectorDashboard(bol_API_SPSLeadsCount bol)
        {
            List<bol_API_SPSCashCollectorDashboard_Response> list = new List<bol_API_SPSCashCollectorDashboard_Response>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SPS_MobileAppAPI", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_SPSCashCollectorDashboard_Response data = new bol_API_SPSCashCollectorDashboard_Response();
                    data.OneMonthCustomerCount = dr["OneMonthCustomerCount"] == null ? 0 : Convert.ToInt32(dr["OneMonthCustomerCount"].ToString());
                    data.OneMonthCollectedCashAmount = dr["OneMonthCollectedCashAmount"] == null ? 0 : Convert.ToDecimal(dr["OneMonthCollectedCashAmount"].ToString());
                    data.TodayCustomerCount = dr["TodayCustomerCount"] == null ? 0 : Convert.ToInt32(dr["TodayCustomerCount"].ToString());
                    data.TodayCollectedCashAmount = dr["TodayCollectedCashAmount"] == null ? 0 : Convert.ToDecimal(dr["TodayCollectedCashAmount"].ToString());
                    data.MinimumAmount = dr["MinimumAmount"] == null ? 0 : Convert.ToDecimal(dr["MinimumAmount"].ToString());
                    list.Add(data);
                }
            }
            return list;
        }

        #endregion
    }
}

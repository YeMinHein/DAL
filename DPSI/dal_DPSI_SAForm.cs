using BOL;
using BOL.General;
using BOL.DPSI;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL.WDM;

namespace DAL.DPSI
{
    public class dal_DPSI_SAForm
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        SqlConnection con;
        public dal_DPSI_SAForm() { }

        public ResultMsg UpdateDPSISAForm(bol_DPSI_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@Name", bol.Name);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@Department", bol.Department);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyRegistrationNo", bol.CompanyRegistrationNo);
                    cmd.Parameters.AddWithValue("@CompanySize", bol.CompanySize);
                    cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@Channel", bol.Channel);
                    cmd.Parameters.AddWithValue("@PainPoint", bol.PainPoint);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg GetDPSISAFormCount(bol_DPSI_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                  
                    cmd.Parameters.AddWithValue("@City", bol.City);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@Product", bol.Product);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@Reason", bol.Reason);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@Channel", bol.Channel);
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
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

        public IEnumerable<bol_DPSI_SAForm> GetDPSISAList(bol_DPSI_SAForm bol)
        {
            List<bol_DPSI_SAForm> saforms = new List<bol_DPSI_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@City", bol.City);
                cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                cmd.Parameters.AddWithValue("@Product", bol.Product);
                cmd.Parameters.AddWithValue("@Status", bol.Status);
                cmd.Parameters.AddWithValue("@Reason", bol.Reason);
                cmd.Parameters.AddWithValue("@Source", bol.Source);
                cmd.Parameters.AddWithValue("@Channel", bol.Channel);
                cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);               
                cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);               
                con.Open();
                try
                { 
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    try
                    {
                        bol_DPSI_SAForm saform = new bol_DPSI_SAForm();

                        saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                        saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                        saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                        saform.Department = dr["Department"] == null ? null : dr["Department"].ToString();
                        saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                        saform.NRCPassport = dr["NRC/Passport"] == null ? null : dr["NRC/Passport"].ToString();
                        saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                        saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                        saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                        saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                        saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
                        saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                         saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                        saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                        saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                       saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                        saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
                        saform.Channel = dr["Channel"] == null ? null : dr["Channel"].ToString();
                            //saform.PainPoint = dr["PainPoint"] == null ? null : dr["PainPoint"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                        if (dr["CreatedDate"].ToString() != "")
                        {
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                        };
                        saform.City = dr["City"] == null ? null : dr["City"].ToString();
                        saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                        saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                        saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                        saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                        saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                        saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                        saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                        saform.LastGroupID = dr["LastGroupID"] == null ? 0 : Convert.ToInt32(dr["LastGroupID"].ToString());
                        saform.ProductCode = dr["ProductCode"] == null ? null : dr["ProductCode"].ToString();
                            
                            //saform.ProjectName = dr["ProjectName"] == null ? null : dr["ProjectName"].ToString();
                            //saform.NoOfLicense = dr["NoOfLicense"] == null ? 0 : int.Parse(dr["NoOfLicense"].ToString());
                            //saform.EdgeAppliance = dr["EdgeAppliance"] == null ? null : dr["EdgeAppliance"].ToString();
                            //saform.PreviousStatusID = dr["PreviousStatusID"] == null ? 0 : Convert.ToInt32(dr["PreviousStatusID"].ToString());

                            saforms.Add(saform);
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message.ToString();
                        Console.WriteLine(s);
                    }
                }
                }
                catch(Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSI_SAForm> GetDPSISAData(bol_DPSI_SAForm bol)
        {
            List<bol_DPSI_SAForm> saforms = new List<bol_DPSI_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_SAForm saform = new bol_DPSI_SAForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                    saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                    saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                    saform.CompanyRegistrationNo = dr["CompanyRegNo"] == null ? null : dr["CompanyRegNo"].ToString();
                    saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
                    saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                    saform.CurrentInternetPlan = dr["CurrentInternetPlan"] == null ? null : dr["CurrentInternetPlan"].ToString();
                    saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                    saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                    saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                   saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                    saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
                    saform.Channel = dr["Channel"] == null ? null : dr["Channel"].ToString();
                    saform.PainPoint = dr["PainPoint"] == null ? null : dr["PainPoint"].ToString();
                    saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                   // saform.SendReceipt = dr["SendReceipt"] == DBNull.Value ? false : bool.Parse(dr["SendReceipt"].ToString());
                   
                    if (dr["CreatedDate"].ToString() != "")
                    {
                        saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    };
                    saform.City = dr["City"] == null ? null : dr["City"].ToString();
                    saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                   
                    if (bol.ActionParam == 4)
                    {
                        saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                        saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                        saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                        saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        // saform.LastChangeStatus_Setting_ID = dr["LastChangeStatus_Setting_ID"] == null ? 0 : Convert.ToInt32(dr["LastChangeStatus_Setting_ID"].ToString());
                        saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                        saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                        saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                    }

                    saforms.Add(saform);
                }

            }
            return saforms;
        }

    
        
        #region BuildingType       
        public IEnumerable<bol_BuildingType> BuildingTypeList(bol_BuildingType bol)
        {
            List<bol_BuildingType> saforms = new List<bol_BuildingType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BuildingType saform = new bol_BuildingType();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());

                    saform.BuildingName = dr["BuildingName"] == null ? null : dr["BuildingName"].ToString();

                    saforms.Add(saform);
                }
            }
            return saforms;
        }

        #endregion

        public IQueryable<bol_FTTH_StatusModel> GetFTTH_StatusSetting()
        {
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            var FTTH_Change_Status_Settinglist = new List<bol_FTTH_StatusModel>();
            try
            {
                con.Open();

                var list = con.Query<bol_FTTH_StatusModel>("SELECT  * FROM dbo.FTTH_Status WHERE IsActive=1 ORDER BY SortOrder ASC").ToList().AsQueryable();
                return list;

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                con.Close();
            }
            return FTTH_Change_Status_Settinglist.AsQueryable();

        }

      #region SA_Sales_Satus
        public IQueryable<bol_SA_FTTH_StatusModel> GetFTTHSA_Status(bol_SA_FTTH_StatusModel bol)
        {
            List<bol_SA_FTTH_StatusModel> csetup = new List<bol_SA_FTTH_StatusModel>();
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID == null ? 0 : bol.ID);
                ObjParm.Add("@Remark", bol.Remark == null ? "" : bol.Remark);
                ObjParm.Add("@Status_ID", bol.Status_ID == null ? 0 : bol.Status_ID);             
                ObjParm.Add("@LoggedBy",bol.LoggedBy );
                ObjParm.Add("@SA_ID", bol.SA_ID == null ? 0 : bol.SA_ID);
                con.Open();
                var list = con.Query<bol_SA_FTTH_StatusModel>("sp_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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
        public ResultMsg FTTHSA_StatusInsert(bol_SA_FTTH_StatusModel bol)
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
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_SA_FTTH_Status", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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

        #region[DPSI]
        public IEnumerable<bol_DPSI_LogActivity> GetDPSILogActivityData(bol_DPSI_LogActivity bol)
        {
            List<bol_DPSI_LogActivity> saforms = new List<bol_DPSI_LogActivity>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LogActivity", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_LogActivity saform = new bol_DPSI_LogActivity();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                    saform.Type = dr["Type"] == null ? "" : dr["Type"].ToString();
                    saform.Remark = dr["Remark"] == null ? "" : dr["Remark"].ToString();
                    saform.LoggedBy = dr["LoggedBy"] == null ? "" : dr["LoggedBy"].ToString();
                    saform.LoggedDate = dr["LoggedDate"] == null ? "" : dr["LoggedDate"].ToString();
                    saform.Datetime = dr["Datetime"] == null ? "" : dr["Datetime"].ToString();

                    if (dr["Datetime"].ToString() != "")
                    {
                        saform.FormattedDatetime = dr["FormattedDatetime"].ToString() == null ? DateTime.Now.ToString("dd/MM/yyyy") : dr["FormattedDatetime"].ToString();
                    };
                    saforms.Add(saform);
                }

            }
            return saforms;
        }
        public ResultMsg UpdateDPSILogActivityForm(bol_DPSI_LogActivity bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LogActivity", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    cmd.Parameters.AddWithValue("@Type", bol.Type);
                    cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                    cmd.Parameters.AddWithValue("@Remark", bol.Remark);
                    cmd.Parameters.AddWithValue("@Datetime", bol.Datetime);
                    cmd.Parameters.AddWithValue("@LoggedBy", bol.LoggedBy);
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
        public IEnumerable<bol_DPSI_Product> GetDPSIProductList(bol_DPSI_Product bol)
        {
            List<bol_DPSI_Product> csetups = new List<bol_DPSI_Product>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Product csetup = new bol_DPSI_Product();
                        csetup.Product = dr["Product"] == null ? null : dr["Product"].ToString();
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

        public IEnumerable<bol_DPSI_Status> GetDPSIStatusList(bol_DPSI_Status bol)
        {
            List<bol_DPSI_Status> csetups = new List<bol_DPSI_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Status csetup = new bol_DPSI_Status();
                        csetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
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
        public IEnumerable<bol_DPSI_Reason> GetDPSIReasonList(bol_DPSI_Reason bol)
        {
            List<bol_DPSI_Reason> csetups = new List<bol_DPSI_Reason>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Status", bol.Status);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Reason csetup = new bol_DPSI_Reason();
                       // csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.Reason = dr["Reason"] == null ? null : dr["Reason"].ToString();
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
        public IEnumerable<bol_DPSI_Owner> GetDPSIOwnerList(bol_DPSI_Owner bol)
        {
            List<bol_DPSI_Owner> csetups = new List<bol_DPSI_Owner>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Owner csetup = new bol_DPSI_Owner();
                        csetup.Value = dr["Value"] == null ? null : dr["Value"].ToString();
                        csetup.Owner = dr["userName"] == null ? null : dr["userName"].ToString();
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

        public IEnumerable<bol_DPSI_Status> GetDPSIStatusListByPreviousGroupID(bol_DPSI_Status bol)
        {
            List<bol_DPSI_Status> csetups = new List<bol_DPSI_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@PreviousGroupID", bol.PreviousGroupID);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Status csetup = new bol_DPSI_Status();
                        csetup.ID = dr["GroupID"] == null ? 0 : Convert.ToInt32(dr["GroupID"].ToString());
                        csetup.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                        csetup.Status = dr["Status"] == null ? null : dr["Status"].ToString();
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
        public IEnumerable<bol_DPSI_Reason> GetDPSIReasonListByGroupID(bol_DPSI_Reason bol)
        {
            List<bol_DPSI_Reason> csetups = new List<bol_DPSI_Reason>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                    cmd.Parameters.AddWithValue("@PreviousGroupID", bol.PreviousGroupID);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Reason csetup = new bol_DPSI_Reason();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.Reason = dr["Reason"] == null ? null : dr["Reason"].ToString();
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

        public bol_DPSI_UserRolePermission GetByUserRolePermission(bol_DPSI_UserRolePermission bol)
        {
            bol_DPSI_UserRolePermission csetup = new bol_DPSI_UserRolePermission();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    csetup.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    csetup.IsDepartmentAdmin = dr["IsDepartmentAdmin"] == null ? false : Convert.ToBoolean(dr["IsDepartmentAdmin"].ToString());
                    csetup.IsSuperAdmin = dr["IsSuperAdmin"] == null ? false : Convert.ToBoolean(dr["IsSuperAdmin"].ToString());
                }
            }
            return csetup;
        }

        public IEnumerable<bol_DPSI_Status> GetDPSI_StatusID(bol_DPSI_Status bol)
        {
            List<bol_DPSI_Status> csetups = new List<bol_DPSI_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                    cmd.Parameters.AddWithValue("@PreviousGroupID", bol.PreviousGroupID);
                    cmd.Parameters.AddWithValue("@FinanceUser", bol.FinanceUser);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Status csetup = new bol_DPSI_Status();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
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
        public IEnumerable<bol_DPSI_Status> GetDPSI_LastStatusID(bol_DPSI_Status bol)
        {
            List<bol_DPSI_Status> csetups = new List<bol_DPSI_Status>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Status csetup = new bol_DPSI_Status();
                        csetup.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                        csetup.Name = dr["Name"] == null ? "" : dr["Name"].ToString();
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

        public ResultMsg FTTH_DPSI_StatusInsert(bol_DPSI_StatusModel bol)
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
                ObjParm.Add("@DPSI_ID", bol.DPSI_ID == null ? 0 : bol.DPSI_ID);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_DPSI_ChangeStatus", ObjParm, commandType: CommandType.StoredProcedure).ToString();
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


        public ResultMsg FTTH_DPSI_SendReceiptInsert(bol_DPSI_SendReceiptModel bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.DPSI_ID == null ? 0 : bol.DPSI_ID);
                ObjParm.Add("@PaymentDocNo", bol.PaymentDocumentNo == null ? "" : bol.PaymentDocumentNo);
                ObjParm.Add("@SendReceipt", bol.SendReceipt == null ? 0 : bol.SendReceipt);
                ObjParm.Add("@OrderCode", bol.OrderCode == null ? "" : bol.OrderCode);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_DPSI_LeadCollection", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                return new ResultMsg() { Result = Result, Message = bol.DPSI_ID > 0 ? "Succefully updated!" : bol.DPSI_ID == 0 ? "Succefully saved!" : "Succefully deleted" };
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

        public bol_DPSI_ResponseModel DPSIInsert(bol_DPSI_SAForm bol)
        {
            bol_DPSI_ResponseModel returnModel = new bol_DPSI_ResponseModel();
            string resp_code = "";
            //try
            //{
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                  //  cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@ContactPersonName", bol.Name);
                    cmd.Parameters.AddWithValue("@ContactID", bol.ContactID);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@Department", bol.Department);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyID", bol.CompanyID);
                    cmd.Parameters.AddWithValue("@CompanyRegistrationNo", bol.CompanyRegistrationNo);
                    cmd.Parameters.AddWithValue("@CompanySize", bol.CompanySize);
                    cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@Channel", bol.Channel);
                    cmd.Parameters.AddWithValue("@PainPoint", bol.PainPoint);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.Owner);
                    cmd.Connection = con;
                    con.Open();
                    //resp_code = cmd.ExecuteScalar().ToString();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        returnModel.RespCode = dr["RespCode"] == DBNull.Value ? null : dr["RespCode"].ToString();
                        returnModel.RespDescription = dr["RespDescription"] == DBNull.Value ? null : dr["RespDescription"].ToString();
                        returnModel.DPSI_ID = dr["DPSI_ID"] == null ? 0 : Convert.ToInt32(dr["DPSI_ID"].ToString());
                    }
                    con.Close();
                    return returnModel;
                }
            //}
            //catch (Exception ex)
            //{
            //    return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            //}

            //return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg DPSIUpdate(bol_DPSI_SAForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@ContactPersonName", bol.Name);
                    cmd.Parameters.AddWithValue("@ContactID", bol.ContactID);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@Department", bol.Department);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    cmd.Parameters.AddWithValue("@CompanyID", bol.CompanyID);
                    cmd.Parameters.AddWithValue("@CompanyRegistrationNo", bol.CompanyRegistrationNo);
                    cmd.Parameters.AddWithValue("@CompanySize", bol.CompanySize);
                    cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    cmd.Parameters.AddWithValue("@Source", bol.Source);
                    cmd.Parameters.AddWithValue("@Channel", bol.Channel);
                    cmd.Parameters.AddWithValue("@PainPoint", bol.PainPoint);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);

                    //cmd.Parameters.AddWithValue("@CompanyID", bol.CompanyID);
                    //cmd.Parameters.AddWithValue("@ContactID", bol.ContactID);
                    //cmd.Parameters.AddWithValue("@ContactPersonName", bol.Name);
                    //cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    //cmd.Parameters.AddWithValue("@Department", bol.Department);
                    //cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    //cmd.Parameters.AddWithValue("@DOB", bol.DOB);
                    //cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    //cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    //cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                    //cmd.Parameters.AddWithValue("@TownshipID", bol.TownshipID);
                    //cmd.Parameters.AddWithValue("@Address", bol.Address);
                    //cmd.Parameters.AddWithValue("@CompanyName", bol.CompanyName);
                    //cmd.Parameters.AddWithValue("@CompanyRegistrationNo", bol.CompanyRegistrationNo);
                    //cmd.Parameters.AddWithValue("@CompanySize", bol.CompanySize);
                    //cmd.Parameters.AddWithValue("@TypeOfBusiness", bol.TypeOfBusiness);
                    // cmd.Parameters.AddWithValue("@PainPoint", bol.PainPoint);
                    //cmd.Parameters.AddWithValue("@Title", bol.Title);
                    //cmd.Parameters.AddWithValue("@ContactPersonName", bol.Name);
                    // cmd.Parameters.AddWithValue("@ContactMobileNo", bol.MobileNo);
                    //cmd.Parameters.AddWithValue("@ContactEmailAddress", bol.EmailAddress);
                    //cmd.Parameters.AddWithValue("@ContactCreatedBy", bol.CreatedBy);
                    //cmd.Parameters.AddWithValue("@BranchAddress", bol.Address);
                    //cmd.Parameters.AddWithValue("@BranchMobileNo", bol.MobileNo);
                    //cmd.Parameters.AddWithValue("@BranchContactPersonName", bol.Name);
                    //cmd.Parameters.AddWithValue("@Source", bol.Source);
                    //cmd.Parameters.AddWithValue("@Channel", bol.Channel);
                    //cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    //cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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
        public ResultMsg DPSIContactUpdate(bol_DPSIContact bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                     SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@CompanyID", bol.CompanyID);
                    cmd.Parameters.AddWithValue("@Title", bol.Title);
                    cmd.Parameters.AddWithValue("@ContactPersonName", bol.ContactPersonName);
                    cmd.Parameters.AddWithValue("@Designation", bol.Designation);
                    cmd.Parameters.AddWithValue("@Department", bol.Department);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@EmailAddress", bol.EmailAddress);
                    cmd.Parameters.AddWithValue("@NRCPassport", bol.NRCPassport);
                    cmd.Parameters.AddWithValue("@Note", bol.Note);
                    cmd.Parameters.AddWithValue("@IsPrimary", bol.IsPrimary);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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
        public ResultMsg DPSIBranchUpdate(bol_DPSIBranch bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@ContactPersonName", bol.ContactPersonName);
                    
                    cmd.Parameters.AddWithValue("@CustomerAccountNo", bol.CustomerAccountNo);
                    cmd.Parameters.AddWithValue("@MobileNo", bol.MobileNo);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@IsMain", bol.IsMain);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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

        public IEnumerable<bol_DPSI_Owner> GetDPSITownshipByCityID(bol_DPSI_Owner bol)
        {
            List<bol_DPSI_Owner> csetups = new List<bol_DPSI_Owner>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_Owner csetup = new bol_DPSI_Owner();
                        csetup.Owner = dr["userName"] == null ? null : dr["userName"].ToString();
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


        public IEnumerable<bol_DPSI_SAForm> GetDPSISAByID(int ID)
        {
            List<bol_DPSI_SAForm> saforms = new List<bol_DPSI_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 10);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSI_SAForm saform = new bol_DPSI_SAForm();

                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.LeadCode = dr["LeadCode"] == null ? null : dr["LeadCode"].ToString();
                            saform.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                            saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                            saform.Department = dr["Department"] == null ? null : dr["Department"].ToString();
                            saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                            saform.NRCPassport = dr["NRC/Passport"] == null ? null : dr["NRC/Passport"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                            saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                            saform.CompanyRegistrationNo = dr["CompanyRegistrationNo"] == null ? null : dr["CompanyRegistrationNo"].ToString();
                            saform.CompanySize = dr["CompanySize"] == null ? null : dr["CompanySize"].ToString();
                            saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saform.CityID = dr["CityID"] == DBNull.Value ? 0 : int.Parse(dr["CityID"].ToString());
                            saform.TownshipID = dr["TownshipID"] == DBNull.Value ? 0 : int.Parse(dr["TownshipID"].ToString());
                             saform.Owner = dr["Owner"] == null ? null : dr["Owner"].ToString();
                            saform.Source = dr["Source"] == null ? null : dr["Source"].ToString();
                            saform.Channel = dr["Channel"] == null ? null : dr["Channel"].ToString();
                            saform.PainPoint = dr["PainPoint"] == null ? null : dr["PainPoint"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            //saform.SendReceipt = dr["SendReceipt"] == DBNull.Value ? false : bool.Parse(dr["SendReceipt"].ToString());
                           
                            if (dr["CreatedDate"].ToString() != "")
                            {
                                saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                            };
                            saform.City = dr["City"] == null ? null : dr["City"].ToString();
                            saform.Township = dr["Township"] == null ? null : dr["Township"].ToString();
                           
                            saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                            saform.LastLoggedBy = dr["LastLoggedBy"] == null ? null : dr["LastLoggedBy"].ToString();
                            saform.LastLoggedDate = dr["LastLoggedDate"] == null ? null : dr["LastLoggedDate"].ToString();
                            saform.LastStatusID = dr["LastStatusID"] == null ? 0 : Convert.ToInt32(dr["LastStatusID"].ToString());
                            saform.LastStatusName = dr["LastStatusName"] == null ? null : dr["LastStatusName"].ToString();
                            saform.LastStatusParentName = dr["LastStatusParentName"] == null ? null : dr["LastStatusParentName"].ToString();
                            saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                            saform.LastGroupID = dr["LastGroupID"] == null ? 0 : Convert.ToInt32(dr["LastGroupID"].ToString());
                            saform.PreviousStatusID = dr["PreviousStatusID"] == null ? 0 : Convert.ToInt32(dr["PreviousStatusID"].ToString());
                            saform.CompanyID = dr["CompanyID"] == null ? 0 : Convert.ToInt32(dr["CompanyID"].ToString());
                            saform.ContactID = dr["ContactID"] == null ? null : dr["ContactID"].ToString();
                            saform.PrimaryContact = dr["PrimaryContact"] == DBNull.Value ? 0 : Convert.ToInt32(dr["PrimaryContact"].ToString());
                           
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_CheckDPSIContact> CheckDPSIContact(int ID, string contactname)
        {
            List<bol_CheckDPSIContact> saforms = new List<bol_CheckDPSIContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 40);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@ContactPersonName", contactname);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_CheckDPSIContact saform = new bol_CheckDPSIContact();
                            saform.Count = dr["Count"] == DBNull.Value ? 0 : int.Parse(dr["Count"].ToString());
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }

        public IEnumerable<bol_DPSIContact> GetDPSIContactByID(int ID,int DPSI_ID)
        {
            List<bol_DPSIContact> saforms = new List<bol_DPSIContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 15);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@DPSI_ID", DPSI_ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIContact saform = new bol_DPSIContact();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.CompanyID = dr["CompanyID"] == DBNull.Value ? 0 : int.Parse(dr["CompanyID"].ToString());
                            saform.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                            saform.ContactPersonName = dr["ContactPersonName"] == null ? null : dr["ContactPersonName"].ToString();
                            saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                           saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                            saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                            saform.Department = dr["Department"] == null ? null : dr["Department"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                             saform.Note = dr["Note"] == null ? null : dr["Note"].ToString();
                            //saform.IsPrimary = dr["IsPrimary"] == null ? false : Convert.ToBoolean(dr["IsPrimary"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                            saform.RegistrationNo = dr["RegistrationNo"] == null ? null : dr["RegistrationNo"].ToString();
                            saform.Size = dr["Size"] == null ? null : dr["Size"].ToString();
                            saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                            saform.CityID = dr["CityID"] == null ? null : dr["CityID"].ToString();
                            saform.TownshipID = dr["TownshipID"] == null ? null : dr["TownshipID"].ToString();
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saform.IsPrimary = dr["IsPrimary"] == null ? false : bool.Parse(dr["IsPrimary"].ToString());

                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_CheckDPSIContact> CheckDPSICompany(int ID, string companyname)
        {
            List<bol_CheckDPSIContact> saforms = new List<bol_CheckDPSIContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 41);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@CompanyName", companyname);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_CheckDPSIContact saform = new bol_CheckDPSIContact();
                            saform.Count = dr["Count"] == DBNull.Value ? 0 : int.Parse(dr["Count"].ToString());
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSICompany> GetDPSICompanyByID(int ID)
        {
            List<bol_DPSICompany> saforms = new List<bol_DPSICompany>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 39);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSICompany saform = new bol_DPSICompany();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());                            
                            saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                            saform.RegistrationNo = dr["RegistrationNo"] == null ? null : dr["RegistrationNo"].ToString();
                            saform.Size = dr["Size"] == null ? null : dr["Size"].ToString();
                            saform.TypeOfBusiness = dr["TypeOfBusiness"] == null ? null : dr["TypeOfBusiness"].ToString();
                            saform.CityID = dr["CityID"] == null ? null : dr["CityID"].ToString();
                            saform.TownshipID = dr["TownshipID"] == null ? null : dr["TownshipID"].ToString();
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSIBranch> GetDPSIBranchByID(int ID)
        {
            List<bol_DPSIBranch> saforms = new List<bol_DPSIBranch>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 16);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIBranch saform = new bol_DPSIBranch();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            //saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.CompanyID = dr["CompanyID"] == DBNull.Value ? 0 : int.Parse(dr["CompanyID"].ToString());
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.ContactPersonName = dr["ContactPersonName"] == null ? null : dr["ContactPersonName"].ToString();
                            saform.IsMain = dr["IsMain"] == null ? false : Convert.ToBoolean(dr["IsMain"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSIDocument> GetDPSIDocumentByID(int ID, int ActionParam)
        {
            List<bol_DPSIDocument> saforms = new List<bol_DPSIDocument>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", ActionParam);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIDocument saform = new bol_DPSIDocument();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.DocTypeID = dr["DocTypeID"] == null ? null : dr["DocTypeID"].ToString();
                            saform.DocTypeName = dr["DocTypeName"] == null ? null : dr["DocTypeName"].ToString();
                            saform.DocNo = dr["DocNo"] == null ? null : dr["DocNo"].ToString();
                            saform.DocName = dr["DocName"] == null ? null : dr["DocName"].ToString();
                            saform.FilePath = dr["FilePath"] == null ? null : dr["FilePath"].ToString();
                            saform.UploadedRemark = dr["UploadedRemark"] == null ? null : dr["UploadedRemark"].ToString();
                            saform.UploadedBy = dr["UploadedBy"] == null ? null : dr["UploadedBy"].ToString();
                            saform.UploadedDate = dr["UploadedDate"] == null ? null : dr["UploadedDate"].ToString();
                            saform.DocDate = dr["DocDate"] == null ? null : dr["DocDate"].ToString();
                            saform.ExpiredDate = dr["ExpiredDate"] == null ? null : dr["ExpiredDate"].ToString();
                            saform.IsDeleted = dr["IsDeleted"] == null ? false : Convert.ToBoolean(dr["IsDeleted"].ToString());
                            saform.DeletedBy = dr["DeletedBy"] == null ? null : dr["DeletedBy"].ToString();
                            saform.DeletedDate = dr["DeletedDate"] == null ? null : dr["DeletedDate"].ToString();
                            saform.Deleted_Remark = dr["Deleted_Remark"] == null ? null : dr["Deleted_Remark"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public int IsHaveDPSIDocument(bol_IsHaveDPSIDocument model)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", model.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", model.ID);
                    cmd.Parameters.AddWithValue("@DocType", model.DocType);
                    cmd.Connection = con;
                    con.Open();
                    i = Int32.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return i;
        }
        public int IsHaveDPSIProduct(bol_IsHaveDPSIProduct model)
        {
            int i = 0;
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", model.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", model.DPSI_ID);
                    cmd.Connection = con;
                    con.Open();
                    i = Int32.Parse(cmd.ExecuteScalar().ToString());
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return i;
        }

        public IEnumerable<bol_DPSIProduct> GetDPSIProductList(int ID)
        {
            List<bol_DPSIProduct> saforms = new List<bol_DPSIProduct>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Product_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 2);
                cmd.Parameters.AddWithValue("@DPSI_ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIProduct saform = new bol_DPSIProduct();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.ServiceName = dr["ServiceName"] == null ? null : dr["ServiceName"].ToString();
                            saform.ServicePlansID = dr["ServicePlansID"] == DBNull.Value ? null : dr["ServicePlansID"].ToString();
                            saform.ServicePlanFullName = dr["ServicePlanFullName"] == DBNull.Value ? null : dr["ServicePlanFullName"].ToString();
                            
                            saform.ExchangeRate = dr["ExchangeRate"] == null ? 0 : decimal.Parse(dr["ExchangeRate"].ToString());

                            saform.IsOTC = dr["IsOTC"] == DBNull.Value ? false : bool.Parse(dr["IsOTC"].ToString());
                            saform.OTCTaxApply = dr["OTCTaxApply"] == DBNull.Value ? false : bool.Parse(dr["OTCTaxApply"].ToString());
                            saform.OTCTaxMode = dr["OTCTaxMode"] == DBNull.Value ? null : dr["OTCTaxMode"].ToString();
                            saform.OTCAmount = dr["OTCAmount"] == DBNull.Value ? null : dr["OTCAmount"].ToString();
                            saform.OTCTaxAmount = dr["OTCTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["OTCTaxAmount"].ToString());
                            saform.OTCCurrencyConverted = dr["OTCCurrencyConverted"] == DBNull.Value ? null : dr["OTCCurrencyConverted"].ToString();
                            saform.OTCTotalAmount = dr["OTCTotalAmount"] == DBNull.Value ? null : dr["OTCTotalAmount"].ToString();

                            saform.IsMRC = dr["IsMRC"] == DBNull.Value ? false : bool.Parse(dr["IsMRC"].ToString());
                            saform.MRCTaxApply = dr["MRCTaxApply"] == DBNull.Value ? false : bool.Parse(dr["MRCTaxApply"].ToString());
                            saform.MRCTaxMode = dr["MRCTaxMode"] == DBNull.Value ? null : dr["MRCTaxMode"].ToString();
                            saform.MRCAmount = dr["MRCAmount"] == DBNull.Value ? null : dr["MRCAmount"].ToString();
                            saform.MRCTaxAmount = dr["MRCTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["MRCTaxAmount"].ToString());
                            saform.MRCCurrencyConverted = dr["MRCCurrencyConverted"] == DBNull.Value ? null : dr["MRCCurrencyConverted"].ToString();
                            saform.MRCTotalAmount = dr["MRCTotalAmount"] == DBNull.Value ? null : dr["MRCTotalAmount"].ToString();
                           
                            saform.IsAnnualPrice = dr["AnnualPriceTaxApply"] == DBNull.Value ? false : bool.Parse(dr["IsAnnualPrice"].ToString());
                            saform.AnnualPriceTaxApply = dr["AnnualPriceTaxApply"] == DBNull.Value ? false : bool.Parse(dr["AnnualPriceTaxApply"].ToString());
                            saform.AnnualPriceTaxMode = dr["AnnualPriceTaxMode"] == DBNull.Value ? null : dr["AnnualPriceTaxMode"].ToString();
                            saform.AnnualPriceAmount = dr["AnnualPriceAmount"] == DBNull.Value ? null : dr["AnnualPriceAmount"].ToString();
                            saform.AnnualPriceTaxAmount = dr["AnnualPriceTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["AnnualPriceTaxAmount"].ToString());
                            saform.AnnualPriceCurrencyConverted = dr["AnnualPriceCurrencyConverted"] == DBNull.Value ? null : dr["AnnualPriceCurrencyConverted"].ToString();
                            saform.AnnualPriceTotalAmount = dr["AnnualPriceTotalAmount"] == DBNull.Value ? null : dr["AnnualPriceTotalAmount"].ToString();

                            saform.IsManagedServiceAmt = dr["IsManagedServiceAmt"] == DBNull.Value ? false : bool.Parse(dr["IsManagedServiceAmt"].ToString());
                            saform.ManagedServiceAmtTaxApply = dr["ManagedServiceAmtTaxApply"] == DBNull.Value ? false : bool.Parse(dr["ManagedServiceAmtTaxApply"].ToString());
                            saform.ManagedServiceAmtTaxMode = dr["ManagedServiceAmtTaxMode"] == DBNull.Value ? null : dr["ManagedServiceAmtTaxMode"].ToString();
                            saform.ManagedServiceAmtAmount = dr["ManagedServiceAmtAmount"] == DBNull.Value ? null : dr["ManagedServiceAmtAmount"].ToString();
                            saform.ManagedServiceAmtTaxAmount = dr["ManagedServiceAmtTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["ManagedServiceAmtTaxAmount"].ToString());
                            saform.ManagedServiceAmtCurrencyConverted = dr["ManagedServiceAmtCurrencyConverted"] == DBNull.Value ? null : dr["ManagedServiceAmtCurrencyConverted"].ToString();
                            saform.ManagedServiceAmtTotalAmount = dr["ManagedServiceAmtTotalAmount"] == DBNull.Value ? null : dr["ManagedServiceAmtTotalAmount"].ToString();

                            saform.Currency = dr["Currency"] == null ? null : dr["Currency"].ToString();
                            saform.CPU = dr["CPU"] == null ? null : dr["CPU"].ToString();
                            saform.Memory = dr["Memory"] == null ? null : dr["Memory"].ToString();
                            saform.HardDisk = dr["HardDisk"] == null ? null : dr["HardDisk"].ToString();
                            saform.Bandwidth = dr["Bandwidth"] == null ? null : dr["Bandwidth"].ToString();
                            saform.NoOfPublicIP = dr["NoOfPublicIP"] == null ? 0 : int.Parse(dr["NoOfPublicIP"].ToString());
                            saform.ServiceStartDate = dr["ServiceStartDate"] == null ? null : dr["ServiceStartDate"].ToString();
                            saform.ServiceEndDate = dr["ServiceEndDate"] == null ? null : dr["ServiceEndDate"].ToString();
                            saform.TechnicalAssignedPerson = dr["TechnicalAssignedPerson"] == null ? null : dr["TechnicalAssignedPerson"].ToString();
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saform.FormattedServiceStartDate = dr["FormattedServiceStartDate"] == null ? null : dr["FormattedServiceStartDate"].ToString();
                            saform.FormattedServiceEndDate = dr["FormattedServiceEndDate"] == null ? null : dr["FormattedServiceEndDate"].ToString();

                            saform.OTCTaxAmountWithMode = dr["OTCTaxAmountWithMode"] == DBNull.Value ? null : dr["OTCTaxAmountWithMode"].ToString();
                            saform.MRCTaxAmountWithMode = dr["MRCTaxAmountWithMode"] == DBNull.Value ? null : dr["MRCTaxAmountWithMode"].ToString();
                            saform.AnnualPriceTaxAmountWithMode = dr["AnnualPriceTaxAmountWithMode"] == DBNull.Value ? null : dr["AnnualPriceTaxAmountWithMode"].ToString();
                            saform.ManagedServiceAmtTaxAmountWithMode = dr["ManagedServiceAmtTaxAmountWithMode"] == DBNull.Value ? null : dr["ManagedServiceAmtTaxAmountWithMode"].ToString();

                            saform.OTCTotal = dr["OTCTotal"] == DBNull.Value ? null : dr["OTCTotal"].ToString();
                            saform.MRCTotal = dr["MRCTotal"] == DBNull.Value ? null : dr["MRCTotal"].ToString();
                            saform.AnnualPriceTotal = dr["AnnualPriceTotal"] == DBNull.Value ? null : dr["AnnualPriceTotal"].ToString();
                            saform.ManagedServiceAmtTotal = dr["ManagedServiceAmtTotal"] == DBNull.Value ? null : dr["ManagedServiceAmtTotal"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }

        public IEnumerable<bol_DPSIContact> GetDPSIContactList(int ID)
        {
            List<bol_DPSIContact> saforms = new List<bol_DPSIContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 11);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIContact saform = new bol_DPSIContact();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.CompanyID = dr["CompanyID"] == DBNull.Value ? 0 : int.Parse(dr["CompanyID"].ToString());
                            saform.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                            saform.ContactPersonName = dr["ContactPersonName"] == null ? null : dr["ContactPersonName"].ToString();
                            saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                            saform.Department = dr["Department"] == null ? null : dr["Department"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                            saform.NRCPassport = dr["NRCPassport"] == null ? null : dr["NRCPassport"].ToString();
                            saform.Note = dr["Note"] == null ? null : dr["Note"].ToString();
                            saform.IsPrimary = dr["IsPrimary"] == null ? false : Convert.ToBoolean(dr["IsPrimary"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSI_LogActivity> GetDPSILogActivityList(int ID)
        {
            List<bol_DPSI_LogActivity> saforms = new List<bol_DPSI_LogActivity>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 12);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSI_LogActivity saform = new bol_DPSI_LogActivity();
                             saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.Icon = dr["Icon"] == null ? null : dr["Icon"].ToString();
                            saform.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
                            saform.header = dr["header"] == null ? null : dr["header"].ToString();
                            saform.Remark = dr["Remark"].ToString();
                            saform.LoggedDate = dr["LoggedDate"] == null ? null : dr["LoggedDate"].ToString();
                            //saform.FormattedDatetime = dr["FormattedDatetime"] == null ? null : dr["FormattedDatetime"].ToString();
                            saform.FormattedLoggedDate = dr["FormattedLoggedDate"] == null ? null : dr["FormattedLoggedDate"].ToString();
                            saform.LastStatus = dr["LastStatus"] == null ? null : dr["LastStatus"].ToString();
                            saform.ColorCode = dr["ColorCode"] == null ? null : dr["ColorCode"].ToString();
                            saform.datedifference = dr["datedifference"] == null ? null : dr["datedifference"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }        
        public IEnumerable<bol_DPSIBranch> GetDPSIBranchList(int ID)
        {
            List<bol_DPSIBranch> saforms = new List<bol_DPSIBranch>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 13);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIBranch saform = new bol_DPSIBranch();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            //saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.CompanyID = dr["CompanyID"] == DBNull.Value ? 0 : int.Parse(dr["CompanyID"].ToString());
                            saform.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.ContactPersonName = dr["ContactPersonName"] == null ? null : dr["ContactPersonName"].ToString();
                             saform.IsMain = dr["IsMain"] == null ? false : Convert.ToBoolean(dr["IsMain"].ToString());
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSIDocument> GetDPSIDocumentList(int ID)
        {
            List<bol_DPSIDocument> saforms = new List<bol_DPSIDocument>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 6);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIDocument saform = new bol_DPSIDocument();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.DocTypeID = dr["DocTypeID"] == null ? null : dr["DocTypeID"].ToString();
                            saform.DocTypeName = dr["DocTypeName"] == null ? null : dr["DocTypeName"].ToString();
                            saform.DocNo = dr["DocNo"] == null ? null : dr["DocNo"].ToString();
                            saform.DocName = dr["DocName"] == null ? null : dr["DocName"].ToString();
                            saform.FilePath = dr["FilePath"] == null ? null : dr["FilePath"].ToString();
                            saform.UploadedRemark = dr["UploadedRemark"] == null ? null : dr["UploadedRemark"].ToString();
                            saform.UploadedBy = dr["UploadedBy"] == null ? null : dr["UploadedBy"].ToString();
                            saform.UploadedDate = dr["UploadedDate"] == null ? null : dr["UploadedDate"].ToString();
                            saform.DocDate = dr["DocDate"] == null ? null : dr["DocDate"].ToString();
                            saform.ExpiredDate = dr["ExpiredDate"] == null ? null : dr["ExpiredDate"].ToString();
                            saform.IsDeleted = dr["IsDeleted"] == null ? false : Convert.ToBoolean(dr["IsDeleted"].ToString());
                            saform.DeletedBy = dr["DeletedBy"] == null ? null : dr["DeletedBy"].ToString();
                            saform.DeletedDate = dr["DeletedDate"] == null ? null : dr["DeletedDate"].ToString();
                            saform.Deleted_Remark = dr["Deleted_Remark"] == null ? null : dr["Deleted_Remark"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }

        #endregion

        public ResultMsg DPSIInvoiceNoUpdate(int ID)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 20);
                    cmd.Parameters.AddWithValue("@ID", ID);
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

        public IEnumerable<bol_DPSI_SAForm> GetDPSITotalDuration(int ID)
        {
            List<bol_DPSI_SAForm> saforms = new List<bol_DPSI_SAForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 22);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSI_SAForm saform = new bol_DPSI_SAForm();
                            saform.Duration = dr["Duration"] == null ? null : dr["Duration"].ToString();
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public ResultMsg Delete_DPSILeadCollection(bol_DPSI_Delete bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DeletedBy", bol.DeletedBy);
                    cmd.Parameters.AddWithValue("@DeletedRemark", bol.DeletedRemark);
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
        public IEnumerable<bol_DPSI_DocType> GetDPSIDocTypeList(bol_DPSI_DocType bol)
        {
            List<bol_DPSI_DocType> csetups = new List<bol_DPSI_DocType>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RoleID", bol.RoleID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_DocType csetup = new bol_DPSI_DocType();
                        csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                        csetup.DocName = dr["DocName"] == null ? null : dr["DocName"].ToString();
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

        public IEnumerable<bol_DPSI_DocType> GetDPSIDocTypebyDocID(bol_DPSI_DocType bol)
        {
            List<bol_DPSI_DocType> csetups = new List<bol_DPSI_DocType>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_DocType csetup = new bol_DPSI_DocType();
                        csetup.DocName = dr["DocName"] == null ? null : dr["DocName"].ToString();
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
        public ResultMsg DocumentInsert(bol_DPSIDocument bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    cmd.Parameters.AddWithValue("@DocDate", bol.DocDate);
                    cmd.Parameters.AddWithValue("@DocTypeID", bol.DocTypeID);
                    cmd.Parameters.AddWithValue("@DocNo", bol.DocNo);
                    cmd.Parameters.AddWithValue("@DocName", bol.DocName);
                    cmd.Parameters.AddWithValue("@FilePath", bol.FilePath);
                    cmd.Parameters.AddWithValue("@FileName", bol.FileName);
                    cmd.Parameters.AddWithValue("@UploadedRemark", bol.UploadedRemark);
                    cmd.Parameters.AddWithValue("@UploadedBy", bol.UploadedBy);
                    cmd.Parameters.AddWithValue("@strcat", bol.strcat);
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
        public ResultMsg DocumentUpdate(bol_DPSIDocument bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    cmd.Parameters.AddWithValue("@DocDate", bol.DocDate);
                    cmd.Parameters.AddWithValue("@DocTypeID", bol.DocTypeID);
                    cmd.Parameters.AddWithValue("@DocNo", bol.DocNo);
                    cmd.Parameters.AddWithValue("@DocName", bol.DocName);
                    cmd.Parameters.AddWithValue("@FilePath", bol.FilePath);
                    cmd.Parameters.AddWithValue("@FileName", bol.FileName);
                    cmd.Parameters.AddWithValue("@UploadedRemark", bol.UploadedRemark);
                    cmd.Parameters.AddWithValue("@UploadedBy", bol.UploadedBy);
                    cmd.Parameters.AddWithValue("@strcat", bol.strcat);
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
        public ResultMsg DocumentDelete(bol_DPSIDocument bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DeletedBy", bol.DeletedBy);
                    cmd.Parameters.AddWithValue("@Deleted_Remark", bol.Deleted_Remark);
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
        public IEnumerable<bol_DPSI_TechnicialAssignedPerson> GetDPSITechnicialAssignedPersonList(bol_DPSI_TechnicialAssignedPerson bol)
        {
            List<bol_DPSI_TechnicialAssignedPerson> csetups = new List<bol_DPSI_TechnicialAssignedPerson>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_TechnicialAssignedPerson csetup = new bol_DPSI_TechnicialAssignedPerson();
                        csetup.Value = dr["Value"] == null ? null : dr["Value"].ToString();
                        csetup.Owner = dr["userName"] == null ? null : dr["userName"].ToString();
                        csetup.FullName = dr["FullName"] == null ? null : dr["FullName"].ToString();
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
        public ResultMsg DPSIProductSalesInsert(bol_DPSI_Product_Setup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Product_Sales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    cmd.Parameters.AddWithValue("@ServiceName", bol.ServiceName);
                    cmd.Parameters.AddWithValue("@ServicePlansID", bol.ServicePlansID);
                    cmd.Parameters.AddWithValue("@Currency", bol.Currency);
                    cmd.Parameters.AddWithValue("@ExchangeRate", bol.ExchangeRate);
                    cmd.Parameters.AddWithValue("@IsOTC", bol.IsOTC);
                    cmd.Parameters.AddWithValue("@OTCTaxApply", bol.OTCTaxApply);
                    cmd.Parameters.AddWithValue("@OTCTaxMode", bol.OTCTaxMode);
                    cmd.Parameters.AddWithValue("@OTCAmount", bol.OTCAmount);
                    cmd.Parameters.AddWithValue("@OTCTaxAmount", bol.OTCTaxAmount);
                    cmd.Parameters.AddWithValue("@OTCCurrencyConverted", bol.OTCCurrencyConverted);
                    cmd.Parameters.AddWithValue("@OTCTotalAmount", bol.OTCTotalAmount);
                    cmd.Parameters.AddWithValue("@IsMRC", bol.IsMRC);
                    cmd.Parameters.AddWithValue("@MRCTaxApply", bol.MRCTaxApply);
                    cmd.Parameters.AddWithValue("@MRCTaxMode", bol.MRCTaxMode);
                    cmd.Parameters.AddWithValue("@MRCAmount", bol.MRCAmount);
                    cmd.Parameters.AddWithValue("@MRCTaxAmount", bol.MRCTaxAmount);
                    cmd.Parameters.AddWithValue("@MRCCurrencyConverted", bol.MRCCurrencyConverted);
                    cmd.Parameters.AddWithValue("@MRCTotalAmount", bol.MRCTotalAmount);
                    cmd.Parameters.AddWithValue("@IsAnnualPrice", bol.IsAnnualPrice);
                    cmd.Parameters.AddWithValue("@AnnualPriceTaxApply", bol.AnnualPriceTaxApply);
                    cmd.Parameters.AddWithValue("@AnnualPriceTaxMode", bol.AnnualPriceTaxMode);
                    cmd.Parameters.AddWithValue("@AnnualPriceAmount", bol.AnnualPriceAmount);
                    cmd.Parameters.AddWithValue("@AnnualPriceTaxAmount", bol.AnnualPriceTaxAmount);
                    cmd.Parameters.AddWithValue("@AnnualPriceCurrencyConverted", bol.AnnualPriceCurrencyConverted);
                    cmd.Parameters.AddWithValue("@AnnualPriceTotalAmount", bol.AnnualPriceTotalAmount);
                    cmd.Parameters.AddWithValue("@IsManagedServiceAmt", bol.IsManagedServiceAmt);
                    cmd.Parameters.AddWithValue("@ManagedServiceAmtTaxApply", bol.ManagedServiceAmtTaxApply);
                    cmd.Parameters.AddWithValue("@ManagedServiceAmtTaxMode", bol.ManagedServiceAmtTaxMode);
                    cmd.Parameters.AddWithValue("@ManagedServiceAmtAmount", bol.ManagedServiceAmtAmount);
                    cmd.Parameters.AddWithValue("@ManagedServiceAmtTaxAmount", bol.ManagedServiceAmtTaxAmount);
                    cmd.Parameters.AddWithValue("@ManagedServiceAmtCurrencyConverted", bol.ManagedServiceAmtCurrencyConverted);
                    cmd.Parameters.AddWithValue("@ManagedServiceAmtTotalAmount", bol.ManagedServiceAmtTotalAmount);
                    cmd.Parameters.AddWithValue("@CPU", bol.CPU);
                    cmd.Parameters.AddWithValue("@Memory", bol.Memory);
                    cmd.Parameters.AddWithValue("@HardDisk", bol.HardDisk);
                    cmd.Parameters.AddWithValue("@Bandwidth", bol.Bandwidth);
                    cmd.Parameters.AddWithValue("@NoOfPublicIP", bol.NoOfPublicIP);
                    cmd.Parameters.AddWithValue("@ServiceStartDate", bol.ServiceStartDate);
                    cmd.Parameters.AddWithValue("@ServiceEndDate", bol.ServiceEndDate);
                    cmd.Parameters.AddWithValue("@TechnicalAssignedPerson", bol.TechnicalAssignedPerson);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@ProjectName" ,bol.ProjectName);
                    cmd.Parameters.AddWithValue("@NoOfLicense", bol.NoOfLicense);
                    cmd.Parameters.AddWithValue("@EdgeAppliance", bol.EdgeAppliance);
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

        public IEnumerable<bol_DPSIProduct> DPSI_ProductDataByID(int ID)
        {
            List<bol_DPSIProduct> saforms = new List<bol_DPSIProduct>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Product_Sales", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIProduct saform = new bol_DPSIProduct();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.DPSI_ID = dr["DPSI_ID"] == DBNull.Value ? 0 : int.Parse(dr["DPSI_ID"].ToString());
                            saform.ServiceName = dr["ServiceName"] == null ? null : dr["ServiceName"].ToString();
                            saform.ServicePlansID = dr["ServicePlansID"] == DBNull.Value ? null : dr["ServicePlansID"].ToString();

                            saform.ExchangeRate = dr["ExchangeRate"] == null ? 0 : decimal.Parse(dr["ExchangeRate"].ToString());
                            saform.IsOTC = dr["IsOTC"] == DBNull.Value ? false : bool.Parse(dr["IsOTC"].ToString());
                            saform.OTCTaxApply = dr["OTCTaxApply"] == DBNull.Value ? false : bool.Parse(dr["OTCTaxApply"].ToString());
                            saform.OTCTaxMode = dr["OTCTaxMode"] == DBNull.Value ? null : dr["OTCTaxMode"].ToString();
                            saform.OTCAmount = dr["OTCAmount"] == DBNull.Value ? null : dr["OTCAmount"].ToString();
                            saform.OTCTaxAmount = dr["OTCTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["OTCTaxAmount"].ToString());
                            saform.OTCCurrencyConverted = dr["OTCCurrencyConverted"] == DBNull.Value ? null : dr["OTCCurrencyConverted"].ToString();
                            saform.OTCTotalAmount = dr["OTCTotalAmount"] == DBNull.Value ? null : dr["OTCTotalAmount"].ToString();
                            saform.IsMRC = dr["IsMRC"] == DBNull.Value ? false : bool.Parse(dr["IsMRC"].ToString());
                            saform.MRCTaxApply = dr["MRCTaxApply"] == DBNull.Value ? false : bool.Parse(dr["MRCTaxApply"].ToString());
                            saform.MRCTaxMode = dr["MRCTaxMode"] == DBNull.Value ? null : dr["MRCTaxMode"].ToString();
                            saform.MRCAmount = dr["MRCAmount"] == DBNull.Value ? null : dr["MRCAmount"].ToString();
                            saform.MRCTaxAmount = dr["MRCTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["MRCTaxAmount"].ToString());
                            saform.MRCCurrencyConverted = dr["MRCCurrencyConverted"] == DBNull.Value ? null : dr["MRCCurrencyConverted"].ToString();
                            saform.MRCTotalAmount = dr["MRCTotalAmount"] == DBNull.Value ? null : dr["MRCTotalAmount"].ToString();
                            saform.IsAnnualPrice = dr["IsAnnualPrice"] == DBNull.Value ? false : bool.Parse(dr["IsAnnualPrice"].ToString());
                            saform.AnnualPriceTaxApply = dr["AnnualPriceTaxApply"] == DBNull.Value ? false : bool.Parse(dr["AnnualPriceTaxApply"].ToString());
                            saform.AnnualPriceTaxMode = dr["AnnualPriceTaxMode"] == DBNull.Value ? null : dr["AnnualPriceTaxMode"].ToString();
                            saform.AnnualPriceAmount = dr["AnnualPriceAmount"] == DBNull.Value ? null : dr["AnnualPriceAmount"].ToString();
                            saform.AnnualPriceTaxAmount = dr["AnnualPriceTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["AnnualPriceTaxAmount"].ToString());
                            saform.AnnualPriceCurrencyConverted = dr["AnnualPriceCurrencyConverted"] == DBNull.Value ? null : dr["AnnualPriceCurrencyConverted"].ToString();
                            saform.AnnualPriceTotalAmount = dr["AnnualPriceTotalAmount"] == DBNull.Value ? null : dr["AnnualPriceTotalAmount"].ToString();

                            saform.IsManagedServiceAmt = dr["IsManagedServiceAmt"] == DBNull.Value ? false : bool.Parse(dr["IsManagedServiceAmt"].ToString());
                            saform.ManagedServiceAmtTaxApply = dr["ManagedServiceAmtTaxApply"] == DBNull.Value ? false : bool.Parse(dr["ManagedServiceAmtTaxApply"].ToString());
                            saform.ManagedServiceAmtTaxMode = dr["ManagedServiceAmtTaxMode"] == DBNull.Value ? null : dr["ManagedServiceAmtTaxMode"].ToString();
                            saform.ManagedServiceAmtAmount = dr["ManagedServiceAmtAmount"] == DBNull.Value ? null : dr["ManagedServiceAmtAmount"].ToString();
                            saform.ManagedServiceAmtTaxAmount = dr["ManagedServiceAmtTaxAmount"] == DBNull.Value ? 0 : decimal.Parse(dr["ManagedServiceAmtTaxAmount"].ToString());
                            saform.ManagedServiceAmtCurrencyConverted = dr["ManagedServiceAmtCurrencyConverted"] == DBNull.Value ? null : dr["ManagedServiceAmtCurrencyConverted"].ToString();
                            saform.ManagedServiceAmtTotalAmount = dr["ManagedServiceAmtTotalAmount"] == DBNull.Value ? null : dr["ManagedServiceAmtTotalAmount"].ToString();

                            saform.Currency = dr["Currency"] == null ? null : dr["Currency"].ToString();
                            saform.CPU = dr["CPU"] == null ? null : dr["CPU"].ToString();
                            saform.Memory = dr["Memory"] == null ? null : dr["Memory"].ToString();
                            saform.HardDisk = dr["HardDisk"] == null ? null : dr["HardDisk"].ToString();
                            saform.Bandwidth = dr["Bandwidth"] == null ? null : dr["Bandwidth"].ToString();
                            saform.NoOfPublicIP = dr["NoOfPublicIP"] == null ? 0 : int.Parse(dr["NoOfPublicIP"].ToString());
                            saform.ServiceStartDate = dr["ServiceStartDate"] == null ? null : dr["ServiceStartDate"].ToString();
                            saform.ServiceEndDate = dr["ServiceEndDate"] == null ? null : dr["ServiceEndDate"].ToString();
                            saform.TechnicalAssignedPerson = dr["TechnicalAssignedPerson"] == null ? null : dr["TechnicalAssignedPerson"].ToString();
                            saform.CreatedBy = dr["CreatedBy"] == null ? null : dr["CreatedBy"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            saform.FormattedCreatedDate = dr["FormattedCreatedDate"] == null ? null : dr["FormattedCreatedDate"].ToString();
                            saform.ProjectName = dr["ProjectName"] == null ? null : dr["ProjectName"].ToString();
                            saform.NoOfLicense = dr["NoOfLicense"] == null ? 0 : int.Parse(dr["NoOfLicense"].ToString());
                            saform.EdgeAppliance = dr["EdgeAppliance"] == null ? null : dr["EdgeAppliance"].ToString();

                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public IEnumerable<bol_DPSIContact> DPSI_ContactIsPrimary(int ID,int DPSI_ID)
        {
            List<bol_DPSIContact> saforms = new List<bol_DPSIContact>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 26);
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@DPSI_ID", DPSI_ID);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSIContact saform = new bol_DPSIContact();
                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.IsPrimary = dr["IsPrimary"] == DBNull.Value ? false : bool.Parse(dr["IsPrimary"].ToString());
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        //public ResultMsg Delete_DPSIProduct(bol_DPSI_Delete bol)
        //{
        //    string resp_code = "";
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_DPSI_Product_Sales", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@ID", bol.ID);
        //            cmd.Parameters.AddWithValue("@DeletedBy", bol.DeletedBy);
        //            cmd.Parameters.AddWithValue("@DeletedRemark", bol.DeletedRemark);
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
        public ResultMsg Delete_DPSIDocument(bol_DPSI_Delete bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Documents", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DeletedBy", bol.DeletedBy);
                    cmd.Parameters.AddWithValue("@Deleted_Remark", bol.DeletedRemark);
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
        public IEnumerable<bol_DPSI_CheckSODate> GetDPSICheckSODate(bol_DPSI_CheckSODate bol)
        {
            List<bol_DPSI_CheckSODate> csetups = new List<bol_DPSI_CheckSODate>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_CheckSODate csetup = new bol_DPSI_CheckSODate();
                        csetup.Result = dr["Result"] == null ? null : dr["Result"].ToString();
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
        public IEnumerable<bol_DPSI_CheckProductAmount> GetDPSICheckProductAmount(bol_DPSI_CheckProductAmount bol)
        {
            List<bol_DPSI_CheckProductAmount> csetups = new List<bol_DPSI_CheckProductAmount>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@DPSI_ID", bol.DPSI_ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_CheckProductAmount csetup = new bol_DPSI_CheckProductAmount();
                        csetup.Result = dr["Result"] == null ? null : dr["Result"].ToString();
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
        public IEnumerable<bol_DPSI_ContactName> GetDPSIContactID(string ContactName)
        {
            List<bol_DPSI_ContactName> csetups = new List<bol_DPSI_ContactName>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 37);
                    cmd.Parameters.AddWithValue("@ContactPersonName", ContactName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_ContactName csetup = new bol_DPSI_ContactName();
                        csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
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
        public IEnumerable<bol_DPSI_CompanyName> GetDPSICompanyID(string CompanyName)
        {
            List<bol_DPSI_CompanyName> csetups = new List<bol_DPSI_CompanyName>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_LeadCollection", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 38);
                    cmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_DPSI_CompanyName csetup = new bol_DPSI_CompanyName();
                        csetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
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
        #region[DPSI Contact]
        public ResultMsg GetDPSIContactFormCount(bol_DPSI_ContactForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Contact", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                    cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
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

        public IEnumerable<bol_DPSI_ContactForm> GetDPSIContactList(bol_DPSI_ContactForm bol)
        {
            List<bol_DPSI_ContactForm> saforms = new List<bol_DPSI_ContactForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_Contact", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@Owner", bol.Owner);
                cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                cmd.Parameters.AddWithValue("@IsSuperAdmin", bol.IsSuperAdmin);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                try
                {
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        try
                        {
                            bol_DPSI_ContactForm saform = new bol_DPSI_ContactForm();

                            saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                            saform.Title = dr["Title"] == null ? null : dr["Title"].ToString();
                            saform.ContactPersonName = dr["ContactPersonName"] == null ? null : dr["ContactPersonName"].ToString();
                            saform.DOB = dr["DOB"] == null ? null : dr["DOB"].ToString();
                            saform.NRCPassport = dr["NRC/Passport"] == null ? null : dr["NRC/Passport"].ToString();
                            saform.Designation = dr["Designation"] == null ? null : dr["Designation"].ToString();
                            saform.Department = dr["Department"] == null ? null : dr["Department"].ToString();                           
                            saform.MobileNo = dr["MobileNo"] == null ? null : dr["MobileNo"].ToString();
                            saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                            saform.CompanyName = dr["CompanyName"] == null ? null : dr["CompanyName"].ToString();
                            saform.Note = dr["Note"] == null ? null : dr["Note"].ToString();
                            saform.CreatedDate = dr["CreatedDate"] == null ? null : dr["CreatedDate"].ToString();
                            if (dr["CreatedDate"].ToString() != "")
                            {
                                saform.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                            };
                            
                            saforms.Add(saform);
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message.ToString();
                            Console.WriteLine(s);
                        }
                    }
                }
                catch (Exception ex)
                {
                    string s = ex.Message.ToString();
                    Console.WriteLine(s);
                }
            }
            return saforms;
        }
        public ResultMsg DPSIProductDelete(bol_DPSI_Delete bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DPSI_Product_Sales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@DeletedBy", bol.DeletedBy);
                    cmd.Parameters.AddWithValue("@Deleted_Remark", bol.DeletedRemark);
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

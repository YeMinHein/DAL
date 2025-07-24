using BOL;
using BOL.API;
using BOL.CF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CF
{
    public class dal_CF_CollectForm_List
    {
        private string conn_str;
        private ResultMsg result;

        public dal_CF_CollectForm_List()
        {
            conn_str = dal_ConfigManager.GTG;
            result = new ResultMsg();
        }

        public List<bol_CF_CollectForm_List> GetAllSalesLeadList(bol_CF_CollectForm_List_Model bol)
        {
            List<bol_CF_CollectForm_List> staffs = new List<bol_CF_CollectForm_List>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_List", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                cmd.Parameters.AddWithValue("@City_ID", bol.City_ID);
                cmd.Parameters.AddWithValue("@Township_ID", bol.Township_ID);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@IsSuperAdminRole ", bol.IsSuperAdminRole);
                cmd.Parameters.AddWithValue("@Collect_from", bol.Collect_from);
                cmd.Parameters.AddWithValue("@Leads_source", bol.Leads_source);
                cmd.Parameters.AddWithValue("@Leads_status", bol.Leads_status);
                cmd.Parameters.AddWithValue("@From_Date", bol.From_Date);
                cmd.Parameters.AddWithValue("@To_Date", bol.To_Date);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@TownshipInspection", bol.TownshipInspection);
                cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                cmd.Parameters.AddWithValue("@LeadStatusID", bol.LeadStatusID);
                cmd.Parameters.AddWithValue("@ReasonID", bol.ReasonID);
                cmd.Parameters.AddWithValue("@StatusID", bol.StatusID);
                cmd.Parameters.AddWithValue("@IsNoOwner", bol.IsNoOwner);
                cmd.Parameters.AddWithValue("@SearchUsername", bol.SearchUsername);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();


                while (dr.Read())
                {
                    bol_CF_CollectForm_List st = new bol_CF_CollectForm_List();
                    st.ID = Convert.ToInt32(dr["ID"].ToString());
                    st.name = dr["name"].ToString();
                    st.phone = dr["phone"].ToString();
                    st.email = dr["email"].ToString();
                    st.city = dr["city"].ToString();
                    try
                    {
                        st.City_ID = Convert.ToInt32(dr["City_ID"].ToString());
                    }
                    catch
                    {

                    }
                    st.township = dr["township"].ToString();
                    st.customer_township = dr["customer_township"].ToString();
                    st.address = dr["address"].ToString();
                    st.house_hold_type = dr["house_hold_type"].ToString();
                    st.collect_from = dr["collect_from"].ToString();
                    st.messenger_user_id = dr["messenger_user_id"].ToString();
                    st.CreatedDate = Convert.ToDateTime(dr["CreatedDate"].ToString());
                    st.UpdatedBy = dr["UpdatedBy"].ToString();
                    st.FormattedCreated = dr["FormattedCreatedDate"].ToString();
                    st.FormattedUpdatedDate= dr["FormattedUpdatedDate"].ToString();
                    st.CFOthers = dr["CFOthers"].ToString();
                    st.CFInterested = dr["CFInterested"].ToString();
                    //st.lead_status_id = Convert.ToInt32(dr["lead_status_id"].ToString());
                    try
                    {
                        st.lead_status_id = dr["lead_status_id"] == null ? 0 : Convert.ToInt32(dr["lead_status_id"].ToString());
                    }
                    catch(Exception ex)
                    {
                        st.lead_status_id = 0;
                    }
                    try
                    {
                        st.status_id = dr["status_id"] == null ? 0 : Convert.ToInt32(dr["status_id"].ToString());
                    }
                    catch (Exception ex)
                    {
                        st.status_id = 0;
                    }
                    try
                    {
                        st.reason_id = dr["reason_id"] == null ? 0 : Convert.ToInt32(dr["reason_id"].ToString());
                        }
                            catch (Exception ex)
                        {
                            st.reason_id = 0;
                        }
                    try
                    {
                        st.other_operator_used_id = dr["other_operator_used_id"] == null ? 0 : Convert.ToInt32(dr["other_operator_used_id"].ToString());
                    }
                    catch(Exception ex)
                    {
                        st.other_operator_used_id = 0;
                    }
                    try
                    {
                        st.ColorCode = dr["ColorCode"].ToString();
                    }
                    catch(Exception ex)
                    {
                        st.ColorCode = "";
                    }
                    st.assign_staff_name = dr["assign_staff_name"].ToString(); 
                    st.remark = dr["remark"].ToString();
                    st.ownerName = dr["ownerName"].ToString();
                    st.leadstatusName = dr["leadstatusName"].ToString();
                    st.statusName = dr["statusName"].ToString();
                    st.reasonName = dr["reasonName"].ToString();
                    st.otherOperatorName = dr["otherOperatorName"].ToString();

                    staffs.Add(st);
                }
            }
            //if(staffs.Count<=0)
            //{
            //    return null;
            //}
            return staffs;
        }

        public ResultMsg GetSalesLeadCount(bol_CF_CollectForm_List_Model bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_List", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@City_ID", bol.City_ID);
                    cmd.Parameters.AddWithValue("@Township_ID", bol.Township_ID);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@Collect_from", bol.Collect_from);
                    cmd.Parameters.AddWithValue("@Leads_source", bol.Leads_source);
                    cmd.Parameters.AddWithValue("@Leads_status", bol.Leads_status);
                    cmd.Parameters.AddWithValue("@IsSuperAdminRole ", bol.IsSuperAdminRole);
                    cmd.Parameters.AddWithValue("@From_Date", bol.From_Date);
                    cmd.Parameters.AddWithValue("@To_Date", bol.To_Date);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@TownshipInspection", bol.TownshipInspection);
                    cmd.Parameters.AddWithValue("@IsOnlyMe", bol.IsOnlyMe);
                    cmd.Parameters.AddWithValue("@LeadStatusID", bol.LeadStatusID);
                    cmd.Parameters.AddWithValue("@ReasonID", bol.ReasonID);
                    cmd.Parameters.AddWithValue("@StatusID", bol.StatusID);
                    cmd.Parameters.AddWithValue("@IsNoOwner", bol.IsNoOwner);
                    cmd.Parameters.AddWithValue("@SearchUsername", bol.SearchUsername);
                    cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows);
                    cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg
                {
                    Result = resp_code,
                    Exception = ex.GetType().ToString(),
                    Message = ex.Message == null ? null : ex.Message.ToString()
                };

            }
            return new ResultMsg() { Result = resp_code };
        }



        public ResultMsg UpdateSalesLead(bol_API_CF_CollectForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 2);
                    cmd.Parameters.AddWithValue("@city", bol.city);
                    cmd.Parameters.AddWithValue("@township", bol.township);
                    cmd.Parameters.AddWithValue("@name", bol.name);
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
                return new ResultMsg
                {
                    Result = resp_code,
                    Exception = ex.GetType().ToString(),
                    Message = ex.Message == null ? null : ex.Message.ToString()
                };

            }
            return new ResultMsg() { Result = resp_code };
        }

        public ResultMsg UpdateSalesLeadCityTownship(bol_API_CF_CollectForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 3);
                    cmd.Parameters.AddWithValue("@city", bol.city);
                    cmd.Parameters.AddWithValue("@township", bol.township);
                    cmd.Parameters.AddWithValue("@name", bol.name);
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
                return new ResultMsg
                {
                    Result = resp_code,
                    Exception = ex.GetType().ToString(),
                    Message = ex.Message == null ? null : ex.Message.ToString()
                };

            }
            return new ResultMsg() { Result = resp_code };
        }

        #region CF Status
        public List<bol_CF_CollectForm_Status> GetAllCFStatusList(bol_CF_CollectForm_Status bol)
        {
            List<bol_CF_CollectForm_Status> staffs = new List<bol_CF_CollectForm_Status>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_CF_Status", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                cmd.Parameters.AddWithValue("@Status", bol.Status);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    bol_CF_CollectForm_Status st = new bol_CF_CollectForm_Status();
                    st.ID = Convert.ToInt32(dr["ID"].ToString());
                    st.Name = dr["Name"].ToString();
                    st.ColorCode = dr["ColorCode"].ToString();
                    st.GroupID = Convert.ToInt32(dr["GroupID"].ToString());
                    st.ParentGroupID =Convert.ToInt32(dr["ParentGroupID"].ToString());
                    st.Status = dr["Status"].ToString();
                    staffs.Add(st);
                }
            }
            //if(staffs.Count<=0)
            //{
            //    return null;
            //}
            return staffs;
        }
        #endregion


        public ResultMsg UpdateCFForm(bol_CF_CollectForm_Update bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_CF_CollectForm_StatusUpdate", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@lead_status_id", bol.lead_status_id);
                    cmd.Parameters.AddWithValue("@status_id", bol.status_id);
                    cmd.Parameters.AddWithValue("@reason_id", bol.reason_id);
                    cmd.Parameters.AddWithValue("@other_operator_used_id", bol.other_operator_used_id);
                    cmd.Parameters.AddWithValue("@assign_staff_name", bol.assign_staff_name);
                    cmd.Parameters.AddWithValue("@remark", bol.remark);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Connection = con;
                    con.Open();
                    //cmd.ExecuteNonQuery();
                    resp_code = cmd.ExecuteScalar().ToString();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg
                {
                    Result = resp_code,
                    Exception = ex.GetType().ToString(),
                    Message = ex.Message == null ? null : ex.Message.ToString()
                };

            }
            return new ResultMsg() { Result = resp_code };
        }

    }
}

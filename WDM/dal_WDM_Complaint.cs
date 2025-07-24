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
    public class dal_WDM_Complaint
    {
        //string conn_str = dal_ConfigManager.GTG;
        //ResultMsg result = new ResultMsg();

        //public dal_WDM_Complaint() { }

        string conn_str = "";
        ResultMsg result;
        SqlConnection con;
        public dal_WDM_Complaint()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }

        public async Task<IQueryable<bol_WDM_Complaint>> GetComplaintList(bol_WDM_Complaint bol)
        {
            List<bol_WDM_Complaint> csetups = new List<bol_WDM_Complaint>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@ServiceType", bol.ServiceType);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@StaffID", bol.StaffID);
                ObjParm.Add("@PageSkipRows", bol.PageIndex);
                ObjParm.Add("@PageTakeRows", 10);
                ObjParm.Add("@Source", bol.Source == null || bol.Source == "" ? "All" : bol.Source);
                con.Open();

                var result = await SqlMapper.QueryAsync<bol_WDM_Complaint>(
                                  con, "sp_WDM_CustomerComplaint",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);

                //var status = await con.ExecuteScalarAsync<int>("sp_PAY_History",
                // ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
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

        public IEnumerable<bol_WDM_Complaint> GetComplaintList_BK(bol_WDM_Complaint bol)
        {
            List<bol_WDM_Complaint> complaints = new List<bol_WDM_Complaint>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_WDM_CustomerComplaint", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate",bol.EndDate);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                cmd.Parameters.AddWithValue("@Source", bol.Source==null|| bol.Source=="" ? "All":bol.Source);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_Complaint complaint = new bol_WDM_Complaint();
                    complaint.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    complaint.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    complaint.CustAccNo = dr["CustAccNo"] == null ? null : dr["CustAccNo"].ToString();
                    complaint.Name = dr["Name"] == null ? null : dr["Name"].ToString();
                    complaint.PhoneNo = dr["PhoneNo"] == null ? null : dr["PhoneNo"].ToString();
                    complaint.OtherPhoneNo = dr["OtherPhoneNo"] == null ? null : dr["OtherPhoneNo"].ToString();
                    complaint.ComplaintID = dr["ComplaintID"] == null ? null : dr["ComplaintID"].ToString();
                    complaint.Remark = dr["Remark"] == null ? null : dr["Remark"].ToString();
                    complaint.ServiceType = dr["ServiceType"] == null ? null : dr["ServiceType"].ToString();
                    if (dr["IsSolved"].ToString() != "")
                    {
                        complaint.IsSolved = bool.Parse(dr["IsSolved"].ToString());
                    };
                    if (dr["SolvedDate"].ToString() != "") {
                        complaint.FormattedSolvedDate = dr["FormattedSolvedDate"].ToString();
                    };
                    complaint.SolvedBy = dr["SolvedBy"] == null ? null : dr["SolvedBy"].ToString();
                    complaint.StaffRemark = dr["StaffRemark"] == null ? null : dr["StaffRemark"].ToString();
                    if (dr["CreatedDate"].ToString() != "")
                    {
                        complaint.FormattedCreatedDate = dr["FormattedCreatedDate"].ToString();
                    }
                    complaint.Desc_eng = dr["Desc_eng"] == null ? null : dr["Desc_eng"].ToString();
                    complaint.Desc_mm = dr["Desc_mm"] == null ? null : dr["Desc_mm"].ToString();
                    complaint.Source = bol.ActionParam == 5 ? dr["Source"] == null ? "" : dr["Source"].ToString():"";
                    complaints.Add(complaint);
                }
            }
            return complaints;
        }

        public ResultMsg UpdateSolvedComplaint(bol_WDM_Complaint bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_CustomerComplaint", con);
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
        public async Task<ResultMsg> GetComplaintCount(bol_WDM_Complaint bol)
        {
            string resp_code = "";
            ResultMsg n = new ResultMsg();
            SqlConnection con = new SqlConnection(conn_str);
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@SearchText", bol.SearchText);
                ObjParm.Add("@ServiceType", bol.ServiceType);
                ObjParm.Add("@BillingArea", bol.BillingArea);
                ObjParm.Add("@IsSolved", bol.IsSolved);
                ObjParm.Add("@StartDate", bol.StartDate);
                ObjParm.Add("@EndDate", bol.EndDate);
                ObjParm.Add("@StaffID", bol.StaffID);
                ObjParm.Add("@Source", bol.Source == null || bol.Source == "" ? "All" : bol.Source);
                con.Open();
                string Result = "OK";
                var status = await con.ExecuteScalarAsync<int>("sp_WDM_CustomerComplaint",
                  ObjParm, commandTimeout: 360, commandType: CommandType.StoredProcedure);
                resp_code = status.ToString();
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg() { Result = resp_code };
        }

        public ResultMsg GetComplaintCount_BK(bol_WDM_Complaint bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_WDM_CustomerComplaint", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@IsSolved", bol.IsSolved);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                    cmd.Parameters.AddWithValue("@Source", bol.Source == null || bol.Source == "" ? "All" : bol.Source);
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

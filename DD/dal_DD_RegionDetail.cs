using BOL;
using BOL.DD;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DD
{
    public class dal_DD_RegionDetail
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_DD_RegionDetail() { }

        public IEnumerable<bol_DD_RegionDetail> GetList(bol_DD_RegionDetail bol)
        {
            List<bol_DD_RegionDetail> rdetails = new List<bol_DD_RegionDetail>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_RegionDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                //cmd.Parameters.AddWithValue("@ServiceType", bol.ServiceType);
                //cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DD_RegionDetail rdetail = new bol_DD_RegionDetail();
                    rdetail.ID = dr["ID"] == null ? 0 : int.Parse(dr["ID"].ToString());
                    rdetail.RegionID = dr["RegionID"] == null ? 0 : int.Parse(dr["RegionID"].ToString());
                    rdetail.ActionTypeID = dr["ActionTypeID"] == null ? 0 : int.Parse(dr["ActionTypeID"].ToString());
                    rdetail.PrimaryPhoneNo = dr["PrimaryPhoneNo"] == null ? null : dr["PrimaryPhoneNo"].ToString();
                    rdetail.SecondaryPhoneNos = dr["SecondaryPhoneNos"] == null ? null : dr["SecondaryPhoneNos"].ToString();
                    rdetail.PrimaryEmail = dr["PrimaryEmail"] == null ? null : dr["PrimaryEmail"].ToString();
                    rdetail.CCEmails = dr["CCEmails"] == null ? null : dr["CCEmails"].ToString();
                    rdetail.BCCEmails = dr["BCCEmails"] == null ? null : dr["BCCEmails"].ToString();
                    rdetail.Address= dr["Address"] == null ? null : dr["Address"].ToString();
                    rdetail.LatAndLong = dr["LatAndLong"] == null ? null : dr["LatAndLong"].ToString();
                    rdetail.Facebook = dr["Facebook"] == null ? null : dr["Facebook"].ToString();
                    rdetail.Youtube = dr["Youtube"] == null ? null : dr["Youtube"].ToString();
                    rdetail.IsActive = dr["IsActive"] == null ? false : bool.Parse(dr["IsActive"].ToString());
                    rdetails.Add(rdetail);
                }
            }
            return rdetails;
        }
        public IEnumerable<bol_DD_RegionDetail> GetByRegionID(bol_DD_RegionDetail bol)
        {
            List<bol_DD_RegionDetail> rdetails = new List<bol_DD_RegionDetail>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_RegionDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DD_RegionDetail rdetail = new bol_DD_RegionDetail();
                    rdetail.ID = dr["ID"] == null ? 0 : int.Parse(dr["ID"].ToString());
                    rdetail.RegionID = dr["RegionID"] == null ? 0 : int.Parse(dr["RegionID"].ToString());
                    rdetail.ActionTypeID = dr["ActionTypeID"] == null ? 0 : int.Parse(dr["ActionTypeID"].ToString());
                    rdetail.PrimaryPhoneNo = dr["PrimaryPhoneNo"] == null ? null : dr["PrimaryPhoneNo"].ToString();
                    rdetail.SecondaryPhoneNos = dr["SecondaryPhoneNos"] == null ? null : dr["SecondaryPhoneNos"].ToString();
                    rdetail.PrimaryEmail = dr["PrimaryEmail"] == null ? null : dr["PrimaryEmail"].ToString();
                    rdetail.CCEmails = dr["CCEmails"] == null ? null : dr["CCEmails"].ToString();
                    rdetail.BCCEmails = dr["BCCEmails"] == null ? null : dr["BCCEmails"].ToString();
                    rdetail.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                    rdetail.LatAndLong = dr["LatAndLong"] == null ? null : dr["LatAndLong"].ToString();
                    rdetail.Facebook = dr["Facebook"] == null ? null : dr["Facebook"].ToString();
                    rdetail.Youtube = dr["Youtube"] == null ? null : dr["Youtube"].ToString();
                    rdetail.IsActive = dr["IsActive"] == null ? false : bool.Parse(dr["IsActive"].ToString());
                    rdetail.RegionName = dr["RegionName"] == null ? null : dr["RegionName"].ToString();
                    rdetail.ActionTypeName = dr["ActionTypeName"] == null ? null : dr["ActionTypeName"].ToString();
                    rdetails.Add(rdetail);
                }
            }
            return rdetails;
        }

        public bol_DD_RegionDetail GetByID(bol_DD_RegionDetail bol)
        {
            bol_DD_RegionDetail rdetail = new bol_DD_RegionDetail();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_RegionDetail", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    rdetail.ID = dr["ID"] == null ? 0 : int.Parse(dr["ID"].ToString());
                    rdetail.RegionID = dr["RegionID"] == null ? 0 : int.Parse(dr["RegionID"].ToString());
                    rdetail.ActionTypeID = dr["ActionTypeID"] == null ? 0 : int.Parse(dr["ActionTypeID"].ToString());
                    rdetail.PrimaryPhoneNo = dr["PrimaryPhoneNo"] == null ? null : dr["PrimaryPhoneNo"].ToString();
                    rdetail.SecondaryPhoneNos = dr["SecondaryPhoneNos"] == null ? null : dr["SecondaryPhoneNos"].ToString();
                    rdetail.PrimaryEmail = dr["PrimaryEmail"] == null ? null : dr["PrimaryEmail"].ToString();
                    rdetail.CCEmails = dr["CCEmails"] == null ? null : dr["CCEmails"].ToString();
                    rdetail.BCCEmails = dr["BCCEmails"] == null ? null : dr["BCCEmails"].ToString();
                    rdetail.Address = dr["Address"] == null ? null : dr["Address"].ToString();
                    rdetail.LatAndLong = dr["LatAndLong"] == null ? null : dr["LatAndLong"].ToString();
                    rdetail.Facebook = dr["Facebook"] == null ? null : dr["Facebook"].ToString();
                    rdetail.Youtube = dr["Youtube"] == null ? null : dr["Youtube"].ToString();
                    rdetail.IsActive = dr["IsActive"] == null ? false : bool.Parse(dr["IsActive"].ToString());
                }
            }
            return rdetail;
        }

        public ResultMsg Insert(bol_DD_RegionDetail bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_RegionDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                    cmd.Parameters.AddWithValue("@ActionTypeID", bol.ActionTypeID);
                    cmd.Parameters.AddWithValue("@PrimaryPhoneNo", bol.PrimaryPhoneNo);
                    cmd.Parameters.AddWithValue("@SecondaryPhoneNos", bol.SecondaryPhoneNos);
                    cmd.Parameters.AddWithValue("@PrimaryEmail", bol.PrimaryEmail);
                    cmd.Parameters.AddWithValue("@CCEmails", bol.CCEmails);
                    cmd.Parameters.AddWithValue("@BCCEmails", bol.BCCEmails);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@LatAndLong", bol.LatAndLong);
                    cmd.Parameters.AddWithValue("@Facebook", bol.Facebook);
                    cmd.Parameters.AddWithValue("@Youtube", bol.Youtube);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
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

        public ResultMsg Update(bol_DD_RegionDetail bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_RegionDetail", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
                    cmd.Parameters.AddWithValue("@RegionID", bol.RegionID);
                    cmd.Parameters.AddWithValue("@ActionTypeID", bol.ActionTypeID);
                    cmd.Parameters.AddWithValue("@PrimaryPhoneNo", bol.PrimaryPhoneNo);
                    cmd.Parameters.AddWithValue("@SecondaryPhoneNos", bol.SecondaryPhoneNos);
                    cmd.Parameters.AddWithValue("@PrimaryEmail", bol.PrimaryEmail);
                    cmd.Parameters.AddWithValue("@CCEmails", bol.CCEmails);
                    cmd.Parameters.AddWithValue("@BCCEmails", bol.BCCEmails);
                    cmd.Parameters.AddWithValue("@Address", bol.Address);
                    cmd.Parameters.AddWithValue("@LatAndLong", bol.LatAndLong);
                    cmd.Parameters.AddWithValue("@Facebook", bol.Facebook);
                    cmd.Parameters.AddWithValue("@Youtube", bol.Youtube);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@UpdatedDate", bol.UpdatedDate);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
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

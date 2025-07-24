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
    public class dal_SVM_ChangeAddressForm
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_SVM_ChangeAddressForm() { }

        public ResultMsg GetChangeAddressFormCount(bol_SVM_ChangeAddressForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SVM_ChangeAddress", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                    cmd.Parameters.AddWithValue("@IsSolved", bol.lstIsSolved);
                    cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                    cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                    cmd.Parameters.AddWithValue("@Source", bol.source);
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
        public IEnumerable<bol_SVM_ChangeAddressForm> GetChangeAddressList(bol_SVM_ChangeAddressForm bol)
        {
            List<bol_SVM_ChangeAddressForm> saforms = new List<bol_SVM_ChangeAddressForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SVM_ChangeAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                cmd.Parameters.AddWithValue("@IsSolved", bol.lstIsSolved);
                cmd.Parameters.AddWithValue("@StartDate", bol.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", bol.EndDate);
                cmd.Parameters.AddWithValue("@Source", bol.source);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SVM_ChangeAddressForm saform = new bol_SVM_ChangeAddressForm();
                    saform.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    saform.EmailAddress = dr["EmailAddress"] == null ? null : dr["EmailAddress"].ToString();
                    saform.CustomerID = dr["CustomerID"] == null ? null : dr["CustomerID"].ToString();
                    saform.CustomerName = dr["CustomerName"] == null ? null : dr["CustomerName"].ToString();
                   saform.ContactPhoneNo = dr["ContactPhoneNo"] == null ? null : dr["ContactPhoneNo"].ToString();
                    saform.CurrentAddress = dr["CurrentAddress"] == null ? null : dr["CurrentAddress"].ToString();
                    saform.ChangeAddress = dr["ChangeAddress"] == null ? null : dr["ChangeAddress"].ToString();
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
        public IEnumerable<bol_SVM_ChangeAddressForm> GetChangeAddressData(bol_SVM_ChangeAddressForm bol)
        {
            List<bol_SVM_ChangeAddressForm> saforms = new List<bol_SVM_ChangeAddressForm>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_SVM_ChangeAddress", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SVM_ChangeAddressForm saform = new bol_SVM_ChangeAddressForm();
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

        public ResultMsg UpdateChangeAddressForm(bol_SVM_ChangeAddressForm bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_SVM_ChangeAddress", con);
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

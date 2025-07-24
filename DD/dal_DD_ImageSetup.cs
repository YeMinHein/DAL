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
    public class dal_DD_ImageSetup
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_DD_ImageSetup() { }

        public IEnumerable<bol_DD_ImageSetup> GetList(bol_DD_ImageSetup bol)
        {
            List<bol_DD_ImageSetup> imgsetups = new List<bol_DD_ImageSetup>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                cmd.Parameters.AddWithValue("@ImageType", bol.ImageType);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageIndex);
                cmd.Parameters.AddWithValue("@PageTakeRows", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DD_ImageSetup imgsetup = new bol_DD_ImageSetup();
                    imgsetup.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    imgsetup.ImageType = dr["ImageType"] == null ? null : dr["ImageType"].ToString();
                    imgsetup.ImageUrl = dr["ImageUrl"] == null ? null : dr["ImageUrl"].ToString();
                    imgsetup.BillingArea = dr["BillingArea"] == null ? null : dr["BillingArea"].ToString();
                    imgsetup.Description = dr["Description"] == null ? null : dr["Description"].ToString();
                    imgsetup.LearnMoreUrl = dr["LearnMoreUrl"] == null ? null : dr["LearnMoreUrl"].ToString();
                    imgsetup.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    imgsetups.Add(imgsetup);
                }
            }
            return imgsetups;


        }

        public ResultMsg Insert(bol_DD_ImageSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ImageType", bol.ImageType);
                    cmd.Parameters.AddWithValue("@ImageUrl", bol.ImageUrl);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@LearnMoreUrl", bol.LearnMoreUrl);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@ImageFileName", bol.ImageFileName);
                    cmd.Parameters.AddWithValue("@CreatedDate", bol.CreatedDate);
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
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }

        public ResultMsg UpdateImage(bol_DD_ImageSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@ImageUrl", bol.ImageUrl);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
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


        public ResultMsg UpdateInfo(bol_DD_ImageSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@Description", bol.Description);
                    cmd.Parameters.AddWithValue("@LearnMoreUrl", bol.LearnMoreUrl);
                    cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                    cmd.Parameters.AddWithValue("@ID", bol.ID);
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

        public ResultMsg Delete(bol_DD_ImageSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
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
                return new ResultMsg { Result = resp_code, Exception = ex.GetType().ToString(), Message = ex.Message == null ? null : ex.Message.ToString() };
            }

            return new ResultMsg() { Result = resp_code };

        }
        public ResultMsg GetCount(bol_DD_ImageSetup bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_DD_ImageSetup", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@BillingArea", bol.BillingArea);
                    cmd.Parameters.AddWithValue("@ImageType", bol.ImageType);
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

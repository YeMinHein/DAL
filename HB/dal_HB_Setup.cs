using BOL;
using BOL.HB;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.HB
{
  public  class dal_HB_Setup
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;

        #region Constructor
        public dal_HB_Setup()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }
        #endregion


        #region HB List
        public IQueryable<bol_HB_Setup> HBList(bol_HB_Setup bol)
        {
            List<bol_HB_Setup> csetups = new List<bol_HB_Setup>();
            try
            {
               
                bol.ModifiedDate = DateTime.Now;
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID);
                ObjParm.Add("@WebBannerPhoto1", bol.WebBannerPhoto1);
                ObjParm.Add("@MobileBannerPhoto1", bol.MobileBannerPhoto1);
                ObjParm.Add("@LearnMoreURL1", bol.LearnMoreURL1);
                ObjParm.Add("@WebBannerPhoto2", bol.WebBannerPhoto2);
                ObjParm.Add("@MobileBannerPhoto2", bol.MobileBannerPhoto2);
                ObjParm.Add("@LearnMoreURL2", bol.LearnMoreURL2);
                ObjParm.Add("@WebBannerPhoto3", bol.WebBannerPhoto3);
                ObjParm.Add("@MobileBannerPhoto3", bol.MobileBannerPhoto3);
                ObjParm.Add("@LearnMoreURL3", bol.LearnMoreURL3);
                ObjParm.Add("@WebBannerPhoto4", bol.WebBannerPhoto4);
                ObjParm.Add("@MobileBannerPhoto4", bol.MobileBannerPhoto4);
                ObjParm.Add("@LearnMoreURL4", bol.LearnMoreURL4);
                ObjParm.Add("@WebBannerPhoto5", bol.WebBannerPhoto5);
                ObjParm.Add("@MobileBannerPhoto5", bol.MobileBannerPhoto5);
                ObjParm.Add("@LearnMoreURL5", bol.LearnMoreURL5);
                ObjParm.Add("@ModifiedDate ", bol.ModifiedDate, DbType.Date);
                ObjParm.Add("@ModifiedBy", bol.ModifiedBy);
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                 con.Open();
                var list = con.Query<bol_HB_Setup>("sp_HB_Setup", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
                return list;
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

        #region HB List Count
        public int HBListCount(bol_HB_Setup bol)
        {
           
            try
            {

                bol.ModifiedDate = DateTime.Now;
                SqlCommand cmd = new SqlCommand("sp_HB_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@WebBannerPhoto1", bol.WebBannerPhoto1);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto1", bol.MobileBannerPhoto1);
                cmd.Parameters.AddWithValue("@LearnMoreURL1", bol.LearnMoreURL1);
                cmd.Parameters.AddWithValue("@WebBannerPhoto2", bol.WebBannerPhoto2);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto2", bol.MobileBannerPhoto2);
                cmd.Parameters.AddWithValue("@LearnMoreURL2", bol.LearnMoreURL2);
                cmd.Parameters.AddWithValue("@WebBannerPhoto3", bol.WebBannerPhoto3);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto3", bol.MobileBannerPhoto3);
                cmd.Parameters.AddWithValue("@LearnMoreURL3", bol.LearnMoreURL3);
                cmd.Parameters.AddWithValue("@WebBannerPhoto4", bol.WebBannerPhoto4);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto4", bol.MobileBannerPhoto4);
                cmd.Parameters.AddWithValue("@LearnMoreURL4", bol.LearnMoreURL4);
                cmd.Parameters.AddWithValue("@WebBannerPhoto5", bol.WebBannerPhoto5);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto5", bol.MobileBannerPhoto5);
                cmd.Parameters.AddWithValue("@LearnMoreURL5", bol.LearnMoreURL5);
                cmd.Parameters.AddWithValue("@ModifiedDate ", bol.ModifiedDate);
                cmd.Parameters.AddWithValue("@ModifiedBy", bol.ModifiedBy);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);                
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                con.Open();
                return Convert.ToInt32(cmd.ExecuteScalar().ToString());

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }

            return 0;
        }
        #endregion


        #region HB Insert Update Delete
        public ResultMsg InsertUpdateDelete(bol_HB_Setup bol)
        {
            string resp_code = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_HB_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@WebBannerPhoto1", bol.WebBannerPhoto1);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto1", bol.MobileBannerPhoto1);
                cmd.Parameters.AddWithValue("@LearnMoreURL1", bol.LearnMoreURL1);
                cmd.Parameters.AddWithValue("@WebBannerPhoto2", bol.WebBannerPhoto2);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto2", bol.MobileBannerPhoto2);
                cmd.Parameters.AddWithValue("@LearnMoreURL2", bol.LearnMoreURL2);
                cmd.Parameters.AddWithValue("@WebBannerPhoto3", bol.WebBannerPhoto3);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto3", bol.MobileBannerPhoto3);
                cmd.Parameters.AddWithValue("@LearnMoreURL3", bol.LearnMoreURL3);
                cmd.Parameters.AddWithValue("@WebBannerPhoto4", bol.WebBannerPhoto4);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto4", bol.MobileBannerPhoto4);
                cmd.Parameters.AddWithValue("@LearnMoreURL4", bol.LearnMoreURL4);
                cmd.Parameters.AddWithValue("@WebBannerPhoto5", bol.WebBannerPhoto5);
                cmd.Parameters.AddWithValue("@MobileBannerPhoto5", bol.MobileBannerPhoto5);
                cmd.Parameters.AddWithValue("@LearnMoreURL5", bol.LearnMoreURL5);
                cmd.Parameters.AddWithValue("@ModifiedDate ", bol.ModifiedDate);
                cmd.Parameters.AddWithValue("@ModifiedBy", bol.ModifiedBy);
                con.Open();

                //cmd.ExecuteNonQuery();
                if (bol.ActionParam == 5)
                {
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    resp_code = cmd.ExecuteScalar().ToString();
                }
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }
             if(bol.ID==0)
            {
              var HBID=  Convert.ToInt32(resp_code) - 3;
                resp_code = "3";
                return new ResultMsg() { Result = Convert.ToString(HBID), Message = resp_code == "4" ? "Succefully Modified!" : resp_code == "3" ? "Succefully saved!" : "Succefully deleted" };
            }
            else
            {
                return new ResultMsg() { Result = resp_code, Message = resp_code == "4" ? "Succefully Modified!" : resp_code == "3" ? "Succefully saved!" : "Succefully deleted" };
            }
               
          
           

        }
        #endregion


        #region HBByID
        public bol_HB_Setup GetHBByID(int ID)
        {
            bol_HB_Setup csetup = new bol_HB_Setup();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Top(1) * from HomeBanner where ID=" + ID, con);
                SqlDataReader dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {
                    
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.WebBannerPhoto1 = dr["WebBannerPhoto1"] == null ? "" : dr["WebBannerPhoto1"].ToString();
                    csetup.MobileBannerPhoto1 = dr["MobileBannerPhoto1"] == null ? "" : dr["MobileBannerPhoto1"].ToString();
                    csetup.LearnMoreURL1 = dr["LearnMoreURL1"] == null ? "" : dr["LearnMoreURL1"].ToString();
                    csetup.WebBannerPhoto2 = dr["WebBannerPhoto2"] == null ? "" : dr["WebBannerPhoto2"].ToString();
                    csetup.MobileBannerPhoto2 = dr["MobileBannerPhoto2"] == null ? "" : dr["MobileBannerPhoto2"].ToString();
                    csetup.LearnMoreURL2 = dr["LearnMoreURL2"] == null ? "" : dr["LearnMoreURL2"].ToString();
                    csetup.WebBannerPhoto3 = dr["WebBannerPhoto3"] == null ? "" : dr["WebBannerPhoto3"].ToString();
                    csetup.MobileBannerPhoto3 = dr["MobileBannerPhoto3"] == null ? "" : dr["MobileBannerPhoto3"].ToString();
                    csetup.LearnMoreURL3 = dr["LearnMoreURL3"] == null ? "" : dr["LearnMoreURL3"].ToString();
                    csetup.WebBannerPhoto4 = dr["WebBannerPhoto4"] == null ? "" : dr["WebBannerPhoto4"].ToString();
                    csetup.MobileBannerPhoto4 = dr["MobileBannerPhoto4"] == null ? "" : dr["MobileBannerPhoto4"].ToString();
                    csetup.LearnMoreURL4 = dr["LearnMoreURL4"] == null ? "" : dr["LearnMoreURL4"].ToString();
                    csetup.WebBannerPhoto5 = dr["WebBannerPhoto5"] == null ? "" : dr["WebBannerPhoto5"].ToString();
                    csetup.MobileBannerPhoto5 = dr["MobileBannerPhoto5"] == null ? "" : dr["MobileBannerPhoto5"].ToString();
                    csetup.LearnMoreURL5 = dr["LearnMoreURL5"] == null ? "" : dr["LearnMoreURL5"].ToString();

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

    }
}

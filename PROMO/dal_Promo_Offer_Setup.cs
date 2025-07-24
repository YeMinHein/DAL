using BOL;
using BOL.PROMO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PROMO
{
  public  class dal_Promo_Offer_Setup
    {
        string conn_str = "";
        ResultMsg result;
        SqlConnection con;

        #region Constructor
        public dal_Promo_Offer_Setup()
        {
            conn_str = dal_ConfigManager.GTG;
            con = new SqlConnection(conn_str);
            result = new ResultMsg();
        }
        #endregion


        #region Promo Offer List
        public IQueryable<bol_PROMO_Offer_Setup> PromoOfferList(bol_PROMO_Offer_Setup bol)
        {
            List<bol_PROMO_Offer_Setup> csetups = new List<bol_PROMO_Offer_Setup>();
            try
            {
               
                bol.CreatedDate = DateTime.Now;
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID);
                ObjParm.Add("@Promo_Plan_ID", bol.Promo_Plan_ID);
                ObjParm.Add("@PromotionGroupID", bol.PromotionGroupID);
                ObjParm.Add("@PromotionTitle", bol.PromotionTitle);
                ObjParm.Add("@Brief_Description", bol.Brief_Description);
                ObjParm.Add("@DESCRIPTION", bol.Description);
                ObjParm.Add("@Photo", bol.Photo);
                ObjParm.Add("@SortOrder", bol.SortOrder);
                ObjParm.Add("@createdDate ", bol.CreatedDate, DbType.Date);
                ObjParm.Add("@createdBy", bol.CreatedBy);
                ObjParm.Add("@IsActive", bol.IsActive);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@Banner_Photo", bol.Banner_Photo);
                ObjParm.Add("@IsShown", bol.IsShown);
                ObjParm.Add("@IsPublish", bol.IsPublish);
                ObjParm.Add("@IsButtonShown", bol.IsButtonShown);
                ObjParm.Add("@ButtonLabel", bol.ButtonLabel);
                ObjParm.Add("@RedirectURL", bol.RedirectURL);
                ObjParm.Add("@IsDelete", bol.IsDelete, DbType.Boolean);
                ObjParm.Add("@IsOverride", bol.IsOverride, DbType.Boolean);
                ObjParm.Add("@PublishDate ", DateTime.Now, DbType.Date);
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                ObjParm.Add("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                ObjParm.Add("@Sort ", bol.Sort == null ? "" : bol.Sort);
                con.Open();
                var list = con.Query<bol_PROMO_Offer_Setup>("sp_PROMO_Offer_Setup", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
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

        #region Promo Offer List Count
        public int PromoOfferListCount(bol_PROMO_Offer_Setup bol)
        {
           
            try
            {

                bol.CreatedDate = DateTime.Now;
                SqlCommand cmd = new SqlCommand("sp_PROMO_Offer_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@Promo_Plan_ID", bol.Promo_Plan_ID);
                cmd.Parameters.AddWithValue("@PromotionGroupID", bol.PromotionGroupID);
                cmd.Parameters.AddWithValue("@PromotionTitle", bol.PromotionTitle);
                cmd.Parameters.AddWithValue("@Brief_Description", bol.Brief_Description);
                cmd.Parameters.AddWithValue("@DESCRIPTION", bol.Description);
                cmd.Parameters.AddWithValue("@Photo", bol.Photo);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.CreatedDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.CreatedBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@Banner_Photo", bol.Banner_Photo);
                cmd.Parameters.AddWithValue("@IsShown", bol.IsShown);
                cmd.Parameters.AddWithValue("@IsPublish", bol.IsPublish);
                cmd.Parameters.AddWithValue("@IsButtonShown", bol.IsButtonShown);
                cmd.Parameters.AddWithValue("@ButtonLabel", bol.ButtonLabel);
                cmd.Parameters.AddWithValue("@RedirectURL", bol.RedirectURL);
                cmd.Parameters.AddWithValue("@IsDelete", bol.IsDelete);
                cmd.Parameters.AddWithValue("@IsOverride", bol.IsOverride);
                cmd.Parameters.AddWithValue("@PublishDate ", DateTime.Now);
                cmd.Parameters.AddWithValue("@PageSkipRows", bol.PageSkipRows == null ? 0 : bol.PageSkipRows);
                cmd.Parameters.AddWithValue("@PageTakeRows", bol.PageTakeRows == null ? 0 : bol.PageTakeRows);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName==null? "": bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort==null ? "":bol.Sort);
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


        #region Promo Offer Insert Update Delete
        public ResultMsg InsertUpdateDelete(bol_PROMO_Offer_Setup bol)
        {
            string resp_code = "";
            try
            {
                SqlCommand cmd = new SqlCommand("sp_PROMO_Offer_Setup", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                cmd.Parameters.AddWithValue("@Promo_Plan_ID", bol.Promo_Plan_ID);
                cmd.Parameters.AddWithValue("@PromotionGroupID", bol.PromotionGroupID);
                cmd.Parameters.AddWithValue("@PromotionTitle", bol.PromotionTitle);
                cmd.Parameters.AddWithValue("@Brief_Description", bol.Brief_Description);
                cmd.Parameters.AddWithValue("@DESCRIPTION", bol.Description);
                cmd.Parameters.AddWithValue("@Photo", bol.Photo);
                cmd.Parameters.AddWithValue("@SortOrder", bol.SortOrder);
                cmd.Parameters.AddWithValue("@createdDate ", bol.CreatedDate);
                cmd.Parameters.AddWithValue("@createdBy", bol.CreatedBy);
                cmd.Parameters.AddWithValue("@IsActive", bol.IsActive);
                cmd.Parameters.AddWithValue("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                cmd.Parameters.AddWithValue("@Banner_Photo", bol.Banner_Photo);
                cmd.Parameters.AddWithValue("@IsShown", bol.IsShown);
                cmd.Parameters.AddWithValue("@IsPublish", bol.IsPublish);
                cmd.Parameters.AddWithValue("@IsButtonShown", bol.IsButtonShown);
                cmd.Parameters.AddWithValue("@ButtonLabel", bol.ButtonLabel);
                cmd.Parameters.AddWithValue("@RedirectURL", bol.RedirectURL);
                cmd.Parameters.AddWithValue("@IsDelete", bol.IsDelete);
                cmd.Parameters.AddWithValue("@IsOverride", bol.IsOverride);
                cmd.Parameters.AddWithValue("@PublishDate ", DateTime.Now);
                cmd.Parameters.AddWithValue("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                cmd.Parameters.AddWithValue("@Sort ", bol.Sort == null ? "" : bol.Sort);
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
              var promoOfferID=  Convert.ToInt32(resp_code) - 3;
                resp_code = "3";
                return new ResultMsg() { Result = Convert.ToString(promoOfferID), Message = resp_code == "4" ? "Succefully updated!" : resp_code == "3" ? "Succefully saved!" : "Succefully deleted" };
            }
            else
            {
                return new ResultMsg() { Result = resp_code, Message = resp_code == "4" ? "Succefully updated!" : resp_code == "3" ? "Succefully saved!" : "Succefully deleted" };
            }
               
          
           

        }
        #endregion


        #region PromoOfferByID
        public bol_PROMO_Offer_Setup GetPromoOfferByID(int ID)
        {
            bol_PROMO_Offer_Setup csetup = new bol_PROMO_Offer_Setup();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select Top(1) * from PROMO_Offer where ID=" + ID, con);
                SqlDataReader dr = cmd.ExecuteReader();
               
                while (dr.Read())
                {
                    
                    csetup.ID = dr["ID"] == null ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    csetup.Photo = dr["Photo"] == null ? "" : dr["Photo"].ToString();
                    csetup.Banner_Photo = dr["Banner_Photo"] == null ? "" : dr["Banner_Photo"].ToString();
                   
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

        #region CheckPromotionAlreadyTaken
        public bool CheckPromotionPlanExist(int Promo_Plan_ID,int ID)
        {          
            try
            {
                con.Open();
                SqlCommand cmd;
                if (ID == 0)
                {
                    cmd = new SqlCommand("select Top(1) * from PROMO_Offer where  IsActive=1 AND IsShown=1 AND   Promo_Plan_ID<>0 AND Promo_Plan_ID=" + Promo_Plan_ID, con);
                }
                else
                {
                    cmd = new SqlCommand("select Top(1) * from PROMO_Offer where  IsActive=1 AND IsShown=1 AND  Promo_Plan_ID=" + Promo_Plan_ID + " AND ID<>"+ID, con);
                }
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return false;
        }
        #endregion

        #region PromoOfferPublish
        public ResultMsg PromoOfferPublish(bol_PROMO_Offer_Setup da)
        {
            try
            {
                con.Open();
                SqlCommand cmd;
                cmd = new SqlCommand("update PROMO_Offer SET IsPublish=" + Convert.ToString(da.IsPublish==true?1:0) + " , PublishDate='" +da.PublishDate.ToString("yyyy/MM/dd") + "' WHERE ID=" + da.ID, con);
                //if (da.IsPublish == true)
                //{
                   
                //}
                //else
                //{
                //    //cmd = new SqlCommand("update PROMO_Offer SET IsPublish=" + da.IsPublish + " , PublishDate=" + null + " WHERE ID=" + da.ID, con);
                //}

                cmd.ExecuteNonQuery();
                return new ResultMsg() { Result = "success", Message = da.IsPublish==true?  "Succefully published!" : "Succefully unpublish!" };
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return new ResultMsg { Result = "", Exception = "", Message = "" };

        }
        #endregion

        

    }
}

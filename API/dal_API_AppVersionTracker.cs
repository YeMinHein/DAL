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
    public class dal_API_AppVersionTracker
    {
        string conn_str = dal_ConfigManager.GTG;
        public ResultMsg Insert(bol_API_AppVersionTracker bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_API_AppVersionTracker", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                    cmd.Parameters.AddWithValue("@AppVersion", bol.AppVersion);
                    cmd.Parameters.AddWithValue("@IsForceToUpdate", bol.IsForceToUpdate);
                    cmd.Parameters.AddWithValue("@PublishDate", bol.PublishDate);
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


        public bol_API_AppVersionTracker GetByAppID(bol_API_AppVersionTracker bol)
        {
            bol_API_AppVersionTracker avt = new bol_API_AppVersionTracker();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_API_AppVersionTracker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    avt.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    avt.AppVersion = dr["AppVersion"] == null ? null : dr["AppVersion"].ToString();
                    avt.IsForceToUpdate = dr["IsForceToUpdate"] == null ? false : bool.Parse(dr["IsForceToUpdate"].ToString());
                    //avt.PublishDate = dr["PublishDate"] == DBNull.Value ? "" : dr["PublishDate"].ToString();
                    //avt.CreatedDate = dr["CreatedDate"] == DBNull.Value ? "" : dr["CreatedDate"].ToString();

                    if (dr["PublishDate"] != DBNull.Value)
                    {
                        avt.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                    }
                    if (dr["CreatedDate"] != DBNull.Value)
                    {
                        avt.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                    }
                }
            }
            return avt;
        }

        public bol_API_AppVersionTracker GetByAppIDV2(bol_API_AppVersionTracker bol)
        {
            bol_API_AppVersionTracker avt = new bol_API_AppVersionTracker();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_API_AppVersionTracker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                cmd.Parameters.AddWithValue("@AppVersion", bol.AppVersion);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    avt.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    avt.AppVersion = dr["AppVersion"] == null ? null : dr["AppVersion"].ToString();
                    avt.IsForceToUpdate = dr["IsForceToUpdate"] == null ? false : bool.Parse(dr["IsForceToUpdate"].ToString());
                    //avt.PublishDate = dr["PublishDate"] == DBNull.Value ? "" : dr["PublishDate"].ToString();
                    //avt.CreatedDate = dr["CreatedDate"] == DBNull.Value ? "" : dr["CreatedDate"].ToString();

                    if (dr["PublishDate"] != DBNull.Value)
                    {
                        avt.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                    }
                    if (dr["CreatedDate"] != DBNull.Value)
                    {
                        avt.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                    }
                }
            }
            return avt;
        }

        public IEnumerable<bol_API_AppVersionTrackerDetail> GetListByAppID(bol_API_AppVersionTracker bol)
        {
            List<bol_API_AppVersionTrackerDetail> detail_list = new List<bol_API_AppVersionTrackerDetail>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_API_AppVersionTracker", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@AppID", bol.AppID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_AppVersionTrackerDetail detail = new bol_API_AppVersionTrackerDetail();
                    detail.AppID = dr["AppID"] == null ? null : dr["AppID"].ToString();
                    detail.AppVersion = dr["AppVersion"] == null ? null : dr["AppVersion"].ToString();
                    detail.IsForceToUpdate = dr["IsForceToUpdate"] == null ? false : bool.Parse(dr["IsForceToUpdate"].ToString());
                    if (dr["PublishDate"] != DBNull.Value)
                    {
                        detail.PublishDate = DateTime.Parse(dr["PublishDate"].ToString());
                    }
                    //if (dr["CreatedDate"] != DBNull.Value)
                    //{
                    //    detail.CreatedDate = DateTime.Parse(dr["CreatedDate"].ToString());
                    //}
                    detail_list.Add(detail);
                }
            }
            return detail_list;


        }
    }
}

using BOL;
using BOL.LLK;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LLK
{
    public class dal_LLK_LaLaKyiList
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public dal_LLK_LaLaKyiList() { }

        public IEnumerable<bol_API_LaLaKyiList> GetLaLaKyiList()
        {
            List<bol_API_LaLaKyiList> param_list = new List<bol_API_LaLaKyiList>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_LLK_MovieImageList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 1);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_API_LaLaKyiList llklist = new bol_API_LaLaKyiList();
                    llklist.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    llklist.MovieType = dr["MovieType"] == null ? null : dr["MovieType"].ToString();
                    llklist.MovieName = dr["MovieName"] == null ? null : dr["MovieName"].ToString();
                    llklist.ImageUrl = dr["ImageUrl"] == null ? null : dr["ImageUrl"].ToString();
                    llklist.MovieUrl = dr["MovieUrl"] == null ? null : dr["MovieUrl"].ToString();
                    //llklist.IsActive = dr["IsActive"] == DBNull.Value ? false : bool.Parse(dr["IsActive"].ToString());
                    param_list.Add(llklist);
                }
            }
            return param_list;


        }
    }
}

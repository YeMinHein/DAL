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
    public class dal_API_Merchant
    {
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();

        public bol_API_GetMerchantInfoList GetMerchantInfo(bol_API_GetMerchantInfo_History_Log bol)
        {
            bol_API_GetMerchantInfoList bol_merinfo = new bol_API_GetMerchantInfoList();
            List<bol_API_GetMerchantInfo> infoList = new List<bol_API_GetMerchantInfo>();
            //bol_API_GetMerchantInfo merInfo = new bol_API_GetMerchantInfo();
            bol_API_GetMerchantInfo merInfo;
            ResultMsg rm = new ResultMsg();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("sp_GetMerchantInfo", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@MerchantCode", bol.MerchantCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for(int i = 0; i<ds.Tables[0].Rows.Count; i++)
                        {
                            merInfo = new bol_API_GetMerchantInfo();
                            merInfo.MerchantCode = ds.Tables[0].Rows[i]["MerchantCode"].ToString();
                            merInfo.MerchantName = ds.Tables[0].Rows[i]["MerchantName"].ToString();
                            merInfo.ContactPerson = ds.Tables[0].Rows[i]["ContactPerson"].ToString();
                            merInfo.BranchName = ds.Tables[0].Rows[i]["BranchName"].ToString();
                            merInfo.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                            merInfo.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                            infoList.Add(merInfo);
                        }
                        bol_merinfo.merchantList = infoList;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["Message"].ToString() != "")
                        {
                            rm.Result = ds.Tables[1].Rows[0]["Result"].ToString();
                            rm.Message = ds.Tables[1].Rows[0]["Message"].ToString();
                            rm.Data = int.Parse(ds.Tables[1].Rows[0]["ID"].ToString());

                            bol_merinfo.result = rm;
                        }
                    }
                }
            }
            return bol_merinfo;
        }

        public bol_API_MerchantLogin GetMerchantLogin(bol_API_MerchantLogin_History_Log bol)
        {
            bol_API_MerchantLogin bol_mer = new bol_API_MerchantLogin();
            bol_API_MerchantLoginUser mer = new bol_API_MerchantLoginUser();
            ResultMsg rm = new ResultMsg();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("sp_GetMerchantLogin", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@Password", bol.Password);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        mer.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                        mer.MerchantCode = ds.Tables[0].Rows[0]["MerchantCode"].ToString();
                        mer.MerchantName = ds.Tables[0].Rows[0]["MerchantName"].ToString();
                        mer.BranchName = ds.Tables[0].Rows[0]["BranchName"].ToString();
                        mer.ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                        mer.Mobile = ds.Tables[0].Rows[0]["Mobile"].ToString();
                        mer.Address = ds.Tables[0].Rows[0]["Address"].ToString();

                        bol_mer.merchant = mer;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["Message"].ToString() != "")
                        {
                            rm.Result = ds.Tables[1].Rows[0]["Result"].ToString();
                            rm.Message = ds.Tables[1].Rows[0]["Message"].ToString();
                            rm.Data = int.Parse(ds.Tables[1].Rows[0]["ID"].ToString());

                            bol_mer.result = rm;
                        }
                    }
                }
            }
            return bol_mer;
        }

        public bol_API_MerchantForgotPassword GetMerchantData(bol_API_MerchantForgotPassword_History_Log bol)
        {
            bol_API_MerchantForgotPassword bol_merData = new bol_API_MerchantForgotPassword();
            bol_API_GetMerchantData merInfo = new bol_API_GetMerchantData();
            ResultMsg rm = new ResultMsg();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("sp_GetMerchantData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            merInfo.MerchantCode = ds.Tables[0].Rows[i]["MerchantCode"].ToString();
                            merInfo.BranchName = ds.Tables[0].Rows[i]["BranchName"].ToString();
                            merInfo.UserName = ds.Tables[0].Rows[i]["UserName"].ToString();
                            merInfo.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                        }
                        bol_merData.merchantData = merInfo;
                    }

                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        if (ds.Tables[1].Rows[0]["Message"].ToString() != "")
                        {
                            rm.Result = ds.Tables[1].Rows[0]["Result"].ToString();
                            rm.Message = ds.Tables[1].Rows[0]["Message"].ToString();
                            rm.Data = int.Parse(ds.Tables[1].Rows[0]["ID"].ToString());

                            bol_merData.result = rm;
                        }
                    }
                }
            }
            return bol_merData;
        }

        public bol_API_MerchantChangePassword ChangePasword(bol_API_MerchantChangePassword_History_Log bol)
        {
            bol_API_MerchantChangePassword bol_merData = new bol_API_MerchantChangePassword();
            ResultMsg rm = new ResultMsg();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand("sp_MerchantChangePassword", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                cmd.Parameters.AddWithValue("@Password", bol.Password);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        if (ds.Tables[0].Rows[0]["Message"].ToString() != "")
                        {
                            rm.Result = ds.Tables[0].Rows[0]["Result"].ToString();
                            rm.Message = ds.Tables[0].Rows[0]["Message"].ToString();
                            rm.Data = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());

                            bol_merData.result = rm;
                        }
                    }
                }
            }
            return bol_merData;
        }
    }
}

using BOL;
using BOL.URM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.URM
{
    public class dal_URM_Role_Setup
    {
        string conn_str;
        ResultMsg result;
        SqlConnection con;

        #region Constructor
        public dal_URM_Role_Setup()
        {
            conn_str = dal_ConfigManager.GTG;
            ResultMsg result = new ResultMsg();
            con = new SqlConnection(conn_str);
        }
        #endregion

        public IQueryable<bol_URM_Role_Setup> GetURMROLEList(bol_URM_Role_Setup bol)
        {
            List<bol_URM_Role_Setup> csetup = new List<bol_URM_Role_Setup>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID);
                ObjParm.Add("@RoleName", bol.RoleName == null ? "" : bol.RoleName);
                ObjParm.Add("@Description", bol.Description == null ? "" : bol.Description);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@IsActive", bol.IsActive);
                ObjParm.Add("@CreatedBy", "");
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows);
                ObjParm.Add("@FieldName", bol.FieldName == null ? "" : bol.FieldName);
                ObjParm.Add("@Sort", bol.Sort == null ? "" : bol.Sort);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                ObjParm.Add("@ValidateActive", bol.ValidateActive == null ? "" : bol.ValidateActive);
                con.Open();
                if (bol.ActionParam == 5 || bol.ActionParam == 6)
                {
                    var list = con.Query<bol_URM_Role_Setup>("sp_URM_Role", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
                    return list;
                }
                else if(bol.ActionParam == 4)
                {           
                    var list = con.Execute("sp_URM_Role", ObjParm, commandType: CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return csetup.AsQueryable();
        }

        public ResultMsg URM_Role_InsertUpdateDelete(bol_URM_Role_Setup bol)
        {
            string resp_code = "";
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@ID", bol.ID);
                ObjParm.Add("@RoleName", bol.RoleName);
                ObjParm.Add("@Description", bol.Description);
                ObjParm.Add("@IsSuperAdmin", bol.IsSuperAdmin);
                ObjParm.Add("@IsDepartmentAdmin", bol.IsDepartmentAdmin);
                ObjParm.Add("@IsActive", bol.IsActive);
                ObjParm.Add("@CreatedBy", bol.CreatedBy);
                ObjParm.Add("@PageSkipRows", bol.PageSkipRows);
                ObjParm.Add("@PageTakeRows", bol.PageTakeRows);
                ObjParm.Add("@FieldName", bol.FieldName);
                ObjParm.Add("@Sort", bol.Sort);
                ObjParm.Add("@SearchText", bol.SearchText == null ? "" : bol.SearchText);
                if (bol.ActionParam == 1)
                {
                    ObjParm.Add("@RetVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                }
                //ObjParm.Add("@returnValue", dbType: DbType.String, direction: ParameterDirection.ReturnValue);
                con.Open();
                string Result = "OK";
                var ResultMsg = con.Execute("sp_URM_Role", ObjParm, commandType: CommandType.StoredProcedure).ToString();
                if (bol.ActionParam == 1)
                {
                    Result = Convert.ToString(ObjParm.Get<int>("@RetVal"));
                }
                return new ResultMsg() { Result = Result, Message = bol.ID > 0 ? "Succefully updated!" : bol.ID == 0 ? "Succefully saved!" : "Succefully deleted" };
            }
            catch (Exception ex)
            {
                return new ResultMsg { Result = resp_code, Exception = "", Message = ex.Message == null ? null : ex.Message.ToString() };
            }
            finally
            {
                con.Close();
            }

            return new ResultMsg { Result = resp_code, Exception = "", Message = "" };

        }
    }
}

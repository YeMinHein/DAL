using BOL;
using BOL.URM;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace DAL.URM
{
  public  class dal_URM_RoleMenu
    {
        string conn_str;
        ResultMsg result;
        SqlConnection con;

        #region Constructor
        public dal_URM_RoleMenu()
        {
            conn_str = dal_ConfigManager.GTG;
            ResultMsg result = new ResultMsg();
            con = new SqlConnection(conn_str);
        }
        #endregion

        public IQueryable<bol_URM_Role_Menu> GetURM_ROLEMENUList(bol_URM_Role_Menu bol)
        {
            List<bol_URM_Role_Menu> csetup = new List<bol_URM_Role_Menu>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@RoleID", bol.RoleID);
                ObjParm.Add("@ControllerName", bol.ControllerName==null?"": bol.ControllerName);
                ObjParm.Add("@ActionName", bol.ActionName == null ? "" : bol.ActionName);
                ObjParm.Add("@MenuList", bol.MenuList == null ? "" : bol.MenuList);
                ObjParm.Add("@UpdatedBy", bol.UpdatedBy == null ? "" : bol.UpdatedBy);
                con.Open();           
                var list = con.Query<bol_URM_Role_Menu>("sp_URM_Role_Menu", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
                return list;

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

        public IQueryable<bol_URM_Role_Menu> GetURM_Multiple_ROLE_MENUList(bol_URM_Role_Menu bol)
        {
            List<bol_URM_Role_Menu> csetup = new List<bol_URM_Role_Menu>();
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@RoleID", bol.RoleID);
                ObjParm.Add("@ControllerName", bol.ControllerName == null ? "" : bol.ControllerName);
                ObjParm.Add("@ActionName", bol.ActionName == null ? "" : bol.ActionName);
                ObjParm.Add("@MenuList", bol.MenuList == null ? "" : bol.MenuList);
                ObjParm.Add("@UpdatedBy", bol.UpdatedBy == null ? "" : bol.UpdatedBy);
                ObjParm.Add("@userName", bol.userName == null ? "" : bol.userName);
                con.Open();
                var list = con.Query<bol_URM_Role_Menu>("sp_URM_Role_Menu", ObjParm, commandType: CommandType.StoredProcedure).AsQueryable();
                return list;

            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
            return csetup.AsQueryable();
        }


        public ResultMsg Update_ROLEMEN(bol_URM_Role_Menu bol)
        {
            
            try
            {
                DynamicParameters ObjParm = new DynamicParameters();
                ObjParm.Add("@ActionParam", bol.ActionParam);
                ObjParm.Add("@RoleID", bol.RoleID);
                ObjParm.Add("@ControllerName", bol.ControllerName == null ? "" : bol.ControllerName);
                ObjParm.Add("@ActionName", bol.ActionName == null ? "" : bol.ActionName);
                ObjParm.Add("@MenuList ", bol.MenuList == null ? "" : bol.MenuList);
                ObjParm.Add("@UpdatedBy", bol.UpdatedBy == null ? "" : bol.UpdatedBy);
                con.Open();
                var list = con.Execute("sp_URM_Role_Menu", ObjParm, commandType: CommandType.StoredProcedure);
                return new ResultMsg() { Result = "OK", Message =  "Succefully updated!" };

            }
            catch (Exception ex)
            {
                return new ResultMsg() { Result = "OK", Message = ex.ToString() };
            }
            finally
            {
                con.Close();
            }
        }
    }
}

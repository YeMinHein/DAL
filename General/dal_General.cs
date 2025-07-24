using BOL;
using BOL.DPSI;
using BOL.General;
using BOL.NOTI;
using BOL.WDM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.General
{
    public class dal_General
    { 
        string conn_str = dal_ConfigManager.GTG;
        ResultMsg result = new ResultMsg();
        public dal_General() { }
        public IEnumerable<bol_Type> GetTypeList(bol_Type bol)
        {
            List<bol_Type> types = new List<bol_Type>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Type type = new bol_Type();
                    type.Type = dr["Type"] == DBNull.Value ? null : dr["Type"].ToString();
                    types.Add(type);
                }
            }
            return types;
        }
        public IEnumerable<bol_SubType> GetSubTypeList(bol_SubType bol)
        {
            List<bol_SubType> subtypes = new List<bol_SubType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SubType subtype = new bol_SubType();
                    subtype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    subtype.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtype);
                }
            }
            return subtypes;
        }
        public IEnumerable<bol_Template> GetTemplateList(bol_Template bol)
        {
            List<bol_Template> templates = new List<bol_Template>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Template template = new bol_Template();
                    template.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    template.Name = dr["Name"] == DBNull.Value ? null : dr["Name"].ToString();
                    templates.Add(template);
                }
            }
            return templates;
        }
        public IEnumerable<bol_TopicType> GetTopicTypeList(bol_TopicType bol)
        {
            List<bol_TopicType> topictypes = new List<bol_TopicType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_TopicType topictype = new bol_TopicType();
                    topictype.TopicType = dr["TopicType"] == DBNull.Value ? null : dr["TopicType"].ToString();
                    topictypes.Add(topictype);
                }
            }
            return topictypes;
        }
        public IEnumerable<bol_Topic> GetTopicList(bol_Topic bol)
        {
            List<bol_Topic> topics = new List<bol_Topic>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_NOTI_Topic", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@TopicType", bol.TopicType);
                cmd.Parameters.AddWithValue("@CityID", bol.CityID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Topic topic = new bol_Topic();
                    topic.Topic = dr["Topic"] == DBNull.Value ? null : dr["Topic"].ToString();
                    topics.Add(topic);
                }
            }
            return topics;
        }
        public IEnumerable<bol_BillingArea> GetBillingAreaList(bol_BillingArea bol)
        {
            List<bol_BillingArea> billingareas = new List<bol_BillingArea>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BillingArea billingarea= new bol_BillingArea();
                    billingarea.BillingArea = dr["BillingArea"] == DBNull.Value ? null : dr["BillingArea"].ToString();
                    billingareas.Add(billingarea);
                }
            }
            return billingareas;
        }
        public IEnumerable<bol_Department> GetDepartmentList(bol_Department bol)
        {
            List<bol_Department> departments = new List<bol_Department>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 43);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Department dep = new bol_Department();
                    dep.DepartmentName = dr["DepartmentName"] == DBNull.Value ? null : dr["DepartmentName"].ToString();
                    departments.Add(dep);
                }
            }
            return departments;
        }
        public IEnumerable<bol_BillingArea> GetBillingAreaListByStaffID(bol_BillingArea bol)
        {
            List<bol_BillingArea> billingareas = new List<bol_BillingArea>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BillingArea billingarea = new bol_BillingArea();
                    billingarea.BillingArea = dr["BillingArea"] == DBNull.Value ? null : dr["BillingArea"].ToString();
                    billingareas.Add(billingarea);
                }
            }
            return billingareas;
        }

        public IEnumerable<bol_BillingArea> GetBillingAreaPXListByStaffID(bol_BillingArea bol)
        {
            List<bol_BillingArea> billingareas = new List<bol_BillingArea>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BillingArea billingarea = new bol_BillingArea();
                    billingarea.BillingArea = dr["BillingArea"] == DBNull.Value ? null : dr["BillingArea"].ToString();
                    billingareas.Add(billingarea);
                }
            }
            return billingareas;
        }

        public IEnumerable<bol_BillingArea> GetBillingAreaFTTHListByStaffID(bol_BillingArea bol)
        {
            List<bol_BillingArea> billingareas = new List<bol_BillingArea>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StaffID", bol.StaffID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BillingArea billingarea = new bol_BillingArea();
                    billingarea.BillingArea = dr["BillingArea"] == DBNull.Value ? null : dr["BillingArea"].ToString();
                    billingareas.Add(billingarea);
                }
            }
            return billingareas;
        }

        public IEnumerable<bol_ServiceType> GetServiceTypeList(bol_ServiceType bol)
        {
            List<bol_ServiceType> servicetypes = new List<bol_ServiceType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServiceType servicetype = new bol_ServiceType();
                    servicetype.ServiceType = dr["ServiceType"] == DBNull.Value ? null : dr["ServiceType"].ToString();
                    servicetypes.Add(servicetype);
                }
            }
            return servicetypes;
        }

        public IEnumerable<bol_PromoPlan> GetPromoPlanTypeList(bol_PromoPlan bol)
        {
            List<bol_PromoPlan> servicetypes = new List<bol_PromoPlan>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PromoPlan promoplans = new bol_PromoPlan();
                    promoplans.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    promoplans.PromoPlan = dr["PromoName_Eng"] == DBNull.Value ? null : dr["PromoName_Eng"].ToString();
                    servicetypes.Add(promoplans);
                }
            }
            return servicetypes;
        }

        public IEnumerable<bol_ActionType> GetActionTypeList(bol_ActionType bol)
        {
            List<bol_ActionType> actiontypes = new List<bol_ActionType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ActionType actiontype = new bol_ActionType();
                    actiontype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    actiontype.ActionTypeName = dr["ActionTypeName"] == DBNull.Value ? null : dr["ActionTypeName"].ToString();
                    actiontypes.Add(actiontype);
                }
            }
            return actiontypes;
        }
        public IEnumerable<bol_Role> GetRoleList(bol_Role bol)
        {
            List<bol_Role> Roles = new List<bol_Role>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@StaffID", bol.username);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Role role = new bol_Role();
                    role.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    role.Role = dr["Role"] == DBNull.Value ? null : dr["Role"].ToString();
                    Roles.Add(role);
                }
            }
            return Roles;
        }       
        public IEnumerable<bol_EMNType> GetEMNTypeList(bol_EMNType bol)
        {
            List<bol_EMNType> types = new List<bol_EMNType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMNType type = new bol_EMNType();
                    type.Type = dr["Type"] == DBNull.Value ? null : dr["Type"].ToString();
                    types.Add(type);
                }
            }
            return types;
        }
        public IEnumerable<bol_EMNSubType> GetEMNSubTypeNameList(bol_EMNSubType bol)
        {
            List<bol_EMNSubType> subtypes = new List<bol_EMNSubType>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMNSubType subtype = new bol_EMNSubType();
                    subtype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    subtype.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtype);
                }
            }
            return subtypes;
        }
        public IEnumerable<bol_EMNSubType> GetEMNSubTypeList(bol_EMNSubType bol)
        {
            List<bol_EMNSubType> subtypes = new List<bol_EMNSubType>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMNSubType subtype = new bol_EMNSubType();
                    subtype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    subtype.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtype);
                }
            }
            return subtypes;
        }
        public IEnumerable<bol_EMNTemplate> GetEMNTemplateList(bol_EMNTemplate bol)
        {
            List<bol_EMNTemplate> templates = new List<bol_EMNTemplate>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                //cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMNTemplate template = new bol_EMNTemplate();
                    template.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    template.Name = dr["Name"] == DBNull.Value ? null : dr["Name"].ToString();
                    templates.Add(template);
                }
            }
            return templates;
        }
        public IEnumerable<bol_EMNParam> GetEMNParamTableBySubTypes(bol_EMNParam bol)
        {
            List<bol_EMNParam> templates = new List<bol_EMNParam>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", int.Parse(bol.Email_SubTypeID));
                //cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_EMNParam template = new bol_EMNParam();
                    template.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    template.Email_SubTypeID = dr["Email_SubTypeID"] == DBNull.Value ? null : dr["Email_SubTypeID"].ToString();
                    template.ParamText = dr["ParamText"] == DBNull.Value ? null : dr["ParamText"].ToString();
                    template.ParamValue = dr["ParamValue"] == DBNull.Value ? null : dr["ParamValue"].ToString();
                    templates.Add(template);
                }
            }
            return templates;
        }
        public IEnumerable<bol_Channel> SearchChannelList(bol_Channel bol)
        {
            List<bol_Channel> cities = new List<bol_Channel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 9);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Channel citydata = new bol_Channel();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.Channel = dr["Channel"] == DBNull.Value ? null : dr["Channel"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }

        public IEnumerable<bol_City> GetCityList(bol_City bol)
        {
            List<bol_City> cities = new List<bol_City>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_City citydata = new bol_City();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_City> GetDPSICityList(bol_City bol)
        {
            List<bol_City> cities = new List<bol_City>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_City citydata = new bol_City();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }

        public IEnumerable<bol_WDM_CashCollectorModel> getCashCollectorList(bol_WDM_CashCollectorModel bol)
        {
            List<bol_WDM_CashCollectorModel> cashCollectorList = new List<bol_WDM_CashCollectorModel>();
            using(SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_WDM_CashCollectorModel cashcollector = new bol_WDM_CashCollectorModel();
                    cashcollector.userName = dr["userName"] == DBNull.Value ? null : dr["userName"].ToString();
                    cashcollector.fullName = dr["fullName"] == DBNull.Value ? null : dr["fullName"].ToString();
                    cashCollectorList.Add(cashcollector);
                }
            }
            return cashCollectorList;
        }
        public IEnumerable<bol_MovieType> GetMovieTypesList(bol_MovieType bol)
        {
            List<bol_MovieType> cities = new List<bol_MovieType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_MovieType movietypedata = new bol_MovieType();
                    movietypedata.MovieType = dr["MovieType"] == DBNull.Value ? null : dr["MovieType"].ToString();
                    cities.Add(movietypedata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_BuildingType> bll_GetBuildingType(bol_BuildingType bol)
        {
            List<bol_BuildingType> cities = new List<bol_BuildingType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BuildingType buildingtypedata = new bol_BuildingType();
                    buildingtypedata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    buildingtypedata.BuildingName = dr["BuildingName"] == DBNull.Value ? null : dr["BuildingName"].ToString();
                    cities.Add(buildingtypedata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_LTE> GetLTEPlanList(bol_LTE bol)
        {
            List<bol_LTE> result = new List<bol_LTE>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_LTE ltedata = new bol_LTE();
                    ltedata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    ltedata.Name = dr["PlanName"] == DBNull.Value ? null : dr["PlanName"].ToString();
                    result.Add(ltedata);
                }
            }
            return result;
        }

        public IEnumerable<bol_City> GetLTECityList(bol_City bol)
        {
            List<bol_City> cities = new List<bol_City>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_City citydata = new bol_City();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }

        #region[SMS]
        public IEnumerable<bol_SMSType> GetSMSTypeList(bol_SMSType bol)
        {
            List<bol_SMSType> types = new List<bol_SMSType>();
            try
            { 
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMSType type = new bol_SMSType();
                    type.Type = dr["Type"] == DBNull.Value ? null : dr["Type"].ToString();
                    types.Add(type);
                }
            }
        }
            catch(Exception e)
            {
                e.Message.ToString();
            }
            return types;
        }
        public IEnumerable<bol_SMSSubType> GetSMSSubTypeNameList(bol_SMSSubType bol)
        {
            List<bol_SMSSubType> subtypes = new List<bol_SMSSubType>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMSSubType subtype = new bol_SMSSubType();
                    subtype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    subtype.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtype);
                }
            }
            return subtypes;
        }
        public IEnumerable<bol_SMSSubType> GetSMSSubTypeList(bol_SMSSubType bol)
        {
            List<bol_SMSSubType> subtypes = new List<bol_SMSSubType>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMSSubType subtype = new bol_SMSSubType();
                    subtype.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    subtype.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtype);
                }
            }
            return subtypes;
        }
        public IEnumerable<bol_SMSTemplate> GetSMSTemplateList(bol_SMSTemplate bol)
        {
            List<bol_SMSTemplate> templates = new List<bol_SMSTemplate>();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Type", bol.Type);
                //cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMSTemplate template = new bol_SMSTemplate();
                    template.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    template.Name = dr["Name"] == DBNull.Value ? null : dr["Name"].ToString();
                    templates.Add(template);
                }
            }
            return templates;
        }
        public IEnumerable<bol_SMSParam> GetSMSParamTableBySubTypes(bol_SMSParam bol)
        {
            List<bol_SMSParam> templates = new List<bol_SMSParam>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", int.Parse(bol.SMS_SubTypeID));
                //cmd.Parameters.AddWithValue("@SubType", bol.SubType);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMSParam template = new bol_SMSParam();
                    template.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    template.SMS_SubTypeID = dr["SMS_SubTypeID"] == DBNull.Value ? null : dr["SMS_SubTypeID"].ToString();
                    template.ParamText = dr["ParamText"] == DBNull.Value ? null : dr["ParamText"].ToString();
                    template.ParamValue = dr["ParamValue"] == DBNull.Value ? null : dr["ParamValue"].ToString();
                    templates.Add(template);
                }
            }
            return templates;
        }

        #endregion

        #region[Export Excel Log]
        public ResultMsg ExportExcelLogInsert(bol_ExportExcelLog bol)
        {
            string resp_code = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_ExcelExportLog", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 1);
                    cmd.Parameters.AddWithValue("@Form", bol.Form);
                    cmd.Parameters.AddWithValue("@SearchFromDate", bol.SearchFromDate);
                    cmd.Parameters.AddWithValue("@SearchToDate", bol.SearchToDate);
                    cmd.Parameters.AddWithValue("@Filter", bol.Filter);
                    cmd.Parameters.AddWithValue("@SearchBy", bol.SearchBy);
                    cmd.Parameters.AddWithValue("@SearchDate", DateTime.Now);

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
        #endregion
        public IEnumerable<bol_City> GetCityByID(bol_City bol)
        {
            List<bol_City> cities = new List<bol_City>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_City citydata = new bol_City();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_Township> GetTownshipByID(bol_Township bol)
        {
            List<bol_Township> cities = new List<bol_Township>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Township citydata = new bol_Township();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.Township = dr["Township"] == DBNull.Value ? null : dr["Township"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_ServicePlan> GetFTTHServicePlanByID(bol_ServicePlan bol)
        {
            List<bol_ServicePlan> cities = new List<bol_ServicePlan>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServicePlan citydata = new bol_ServicePlan();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.ServicePlan = dr["ServicePlan"] == DBNull.Value ? null : dr["ServicePlan"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_BuildingType> GetResidentialTypeByID(bol_BuildingType bol)
        {
            List<bol_BuildingType> cities = new List<bol_BuildingType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BuildingType citydata = new bol_BuildingType();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.BuildingName = dr["BuildingName"] == DBNull.Value ? null : dr["BuildingName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_FTTHStatusName> GetFTTHStatusNameByID(bol_FTTHStatusName bol)
        {
            List<bol_FTTHStatusName> cities = new List<bol_FTTHStatusName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_FTTHStatusName citydata = new bol_FTTHStatusName();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.StatusName = dr["StatusName"] == DBNull.Value ? null : dr["StatusName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_ServicePlan> GetLTEServicePlanByID(bol_ServicePlan bol)
        {
            List<bol_ServicePlan> cities = new List<bol_ServicePlan>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServicePlan citydata = new bol_ServicePlan();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.ServicePlan = dr["PlanName"] == DBNull.Value ? null : dr["PlanName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_SMSSubType> GetDataForSMSSubType(int ID)
        {
            List<bol_SMSSubType> subtypes = new List<bol_SMSSubType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 35);
                cmd.Parameters.AddWithValue("@ID",ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SMSSubType subtypedata = new bol_SMSSubType();
                    subtypedata.SubType = dr["SubType"] == DBNull.Value ? null : dr["SubType"].ToString();
                    subtypes.Add(subtypedata);
                }
            }
            return subtypes;
        }

        public IEnumerable<bol_ServicePlan> GetBusinessServicePlanList(bol_ServicePlan bol)
        {
            List<bol_ServicePlan> plans = new List<bol_ServicePlan>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_ServicePlan plandata = new bol_ServicePlan();
                    plandata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    plandata.ServicePlan = dr["PlanName"] == DBNull.Value ? null : dr["PlanName"].ToString();
                    plans.Add(plandata);
                }
            }
            return plans;
        }


        public IEnumerable<bol_BankPayment> GetBankPaymentList(bol_BankPayment bol)
        {
            List<bol_BankPayment> bankpayments = new List<bol_BankPayment>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BankPayment bankpaymentdata = new bol_BankPayment();
                    bankpaymentdata.BankName = dr["BankName"] == DBNull.Value ? null : dr["BankName"].ToString();
                    bankpaymentdata.Value = dr["Value"] == DBNull.Value ? null : dr["Value"].ToString();
                    bankpayments.Add(bankpaymentdata);
                }
            }
            return bankpayments;
        }
        
        public IEnumerable<bol_BusinessType> TypeOfBusinessList(bol_BusinessType bol)
        {
            List<bol_BusinessType> businesstypes = new List<bol_BusinessType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BusinessType businesstypedata = new bol_BusinessType();
                   // businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.Name = dr["Name"] == DBNull.Value ? null : dr["Name"].ToString();
                    businesstypedata.Value = dr["Value"] == DBNull.Value ? null : dr["Value"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public IEnumerable<bol_Channel> ChannelList(bol_Channel bol)
        {
            List<bol_Channel> businesstypes = new List<bol_Channel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Source", bol.Source);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Channel businesstypedata = new bol_Channel();
                    businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.Channel = dr["Channel"] == DBNull.Value ? null : dr["Channel"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public IEnumerable<bol_Township> TownshipByCityID(bol_Township bol)
        {
            List<bol_Township> townshiptypes = new List<bol_Township>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.CityID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Township townshipdata = new bol_Township();
                    townshipdata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    townshipdata.Township = dr["Township"] == DBNull.Value ? null : dr["Township"].ToString();
                    townshiptypes.Add(townshipdata);
                }
            }
            return townshiptypes;
        }
        public IEnumerable<bol_BSStatus> GetBSStatusByID(bol_BSStatus bol)
        {
            List<bol_BSStatus> bsstatus = new List<bol_BSStatus>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BSStatus bsstatusdata = new bol_BSStatus();
                    bsstatusdata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    bsstatusdata.Status = dr["Status"] == DBNull.Value ? null : dr["Status"].ToString();
                    bsstatusdata.Reason = dr["Reason"] == DBNull.Value ? null : dr["Reason"].ToString();
                    bsstatus.Add(bsstatusdata);
                }
            }
            return bsstatus;
        }
        public IEnumerable<bol_PromoPlan> GetBusinessPromoPlan(bol_PromoPlan bol)
        {
            List<bol_PromoPlan> servicetypes = new List<bol_PromoPlan>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_PromoPlan promoplans = new bol_PromoPlan();
                    promoplans.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    promoplans.PromoPlan = dr["PromoName_Eng"] == DBNull.Value ? null : dr["PromoName_Eng"].ToString();
                    servicetypes.Add(promoplans);
                }
            }
            return servicetypes;
        }
        public IEnumerable<bol_DPSI_Status> GetDPSIStatusByID(bol_DPSI_Status bol)
        {
            List<bol_DPSI_Status> bsstatus = new List<bol_DPSI_Status>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_Status bsstatusdata = new bol_DPSI_Status();
                    bsstatusdata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    bsstatusdata.Status = dr["Status"] == DBNull.Value ? null : dr["Status"].ToString();
                    bsstatusdata.Reason = dr["Reason"] == DBNull.Value ? null : dr["Reason"].ToString();
                    bsstatus.Add(bsstatusdata);
                }
            }
            return bsstatus;
        }
        #region[DPSI List]
        public IEnumerable<bol_DPSI_ServiceName> GetDPSIServiceNameList(bol_DPSI_ServiceName bol)
        {
            List<bol_DPSI_ServiceName> cities = new List<bol_DPSI_ServiceName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_ServiceName citydata = new bol_DPSI_ServiceName();
                    citydata.ServiceName = dr["ServiceName"] == DBNull.Value ? null : dr["ServiceName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_DPSI_ServicePlan> GetDPSIServicePlanList(bol_DPSI_ServicePlan bol)
        {
            List<bol_DPSI_ServicePlan> cities = new List<bol_DPSI_ServicePlan>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ServiceName", bol.ServiceName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_ServicePlan citydata = new bol_DPSI_ServicePlan();
                    citydata.ServicePlansID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.ServicePlan = dr["ServicePlan"] == DBNull.Value ? null : dr["ServicePlan"].ToString();
                    citydata.ServicePlanFullName = dr["ServicePlanFullName"] == DBNull.Value ? null : dr["ServicePlanFullName"].ToString();
                    citydata.IsAlone = dr["IsAlone"] == DBNull.Value ? false :  bool.Parse(dr["IsAlone"].ToString());
                    cities.Add(citydata);
                }
            }
            return cities;
        }

        #endregion

        public IEnumerable<bol_DPSI_ContactName> DPSIContactNameList(bol_DPSI_ContactName bol)
        {
            List<bol_DPSI_ContactName> businesstypes = new List<bol_DPSI_ContactName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_ContactName businesstypedata = new bol_DPSI_ContactName();
                    businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.ContactName = dr["ContactPersonName"] == DBNull.Value ? null : dr["ContactPersonName"].ToString();
                    businesstypedata.CompanyName = dr["CompanyName"] == DBNull.Value ? null : dr["CompanyName"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public IEnumerable<bol_DPSI_ContactName> DPSIContactNameListByByDPSIID(bol_DPSI_ContactName bol)
        {
            List<bol_DPSI_ContactName> businesstypes = new List<bol_DPSI_ContactName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_ContactName businesstypedata = new bol_DPSI_ContactName();
                    businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.ContactName = dr["ContactPersonName"] == DBNull.Value ? null : dr["ContactPersonName"].ToString();
                    businesstypedata.CompanyName = dr["CompanyName"] == DBNull.Value ? null : dr["CompanyName"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public IEnumerable<bol_DPSI_CompanyName> DPSICompanyNameList(bol_DPSI_CompanyName bol)
        {
            List<bol_DPSI_CompanyName> businesstypes = new List<bol_DPSI_CompanyName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_DPSI_CompanyName businesstypedata = new bol_DPSI_CompanyName();
                    businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.CompanyName = dr["CompanyName"] == DBNull.Value ? null : dr["CompanyName"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public IEnumerable<bol_BusinessType> DPSITypeOfBusinessList(bol_BusinessType bol)
        {
            List<bol_BusinessType> businesstypes = new List<bol_BusinessType>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_DPSI_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_BusinessType businesstypedata = new bol_BusinessType();
                    // businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.Name = dr["Name"] == DBNull.Value ? null : dr["Name"].ToString();
                    businesstypedata.Value = dr["Value"] == DBNull.Value ? null : dr["Value"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public bol_SPS_Staff GetSPSRoleID(bol_SPS_Role bol)
        {
            bol_SPS_Staff staff = new bol_SPS_Staff();
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.username);
                cmd.Parameters.AddWithValue("@Password", bol.password);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    staff.RoleId = dr["RoleID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["RoleID"].ToString());
                    staff.FullName = dr["fullName"] == null ? "" : dr["fullName"].ToString();
                    staff.MobileNo = dr["mobileNo"] == null ? "" : dr["mobileNo"].ToString();
                    staff.Role = dr["Role"] == null ? "" : (dr["Role"].ToString());
                }
            }
            return staff;
        }
        public bol_SPS_CashCollectorData SPSCashCollectorData(bol_SPS_Role bol)
        {
            bol_SPS_CashCollectorData staff = new bol_SPS_CashCollectorData();
            using (SqlConnection con = new SqlConnection(conn_str))
            {

                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 30);
                cmd.Parameters.AddWithValue("@UserName", bol.username);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    staff.MaximumAmount = dr["MaximumAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["MaximumAmount"].ToString());
                    staff.TodayCollectedCashAmount = dr["TodayCollectedCashAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(dr["TodayCollectedCashAmount"].ToString());
                }
            }
            return staff;
        }
        public IEnumerable<bol_showroom> GetShowroomList()
        {
            List<bol_showroom> showrooms = new List<bol_showroom>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 50);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_showroom showroom = new bol_showroom();
                    showroom.showroomName = dr["showroomname"] == DBNull.Value ? null : dr["showroomname"].ToString();
                    showrooms.Add(showroom);
                }
            }
            return showrooms;
        }
        public bol_TeamLeader GetIsTeamLeader(bol_TeamLeader bol)
        {
            using(SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 7);
                cmd.Parameters.AddWithValue("@UserName", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol.IsTeamLeader = dr["IsTeamLeader"] == DBNull.Value ? false : (Boolean)dr["IsTeamLeader"];
                }
            }
            return bol;
        }
        public bol_GroupLeader GetIsGroupLeader(bol_GroupLeader bol)
        {
            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 6);
                cmd.Parameters.AddWithValue("@UserName", bol.userName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol.IsGroupLeader = dr["IsGroupLeader"] == DBNull.Value ? false : (Boolean)dr["IsGroupLeader"];
                }
            }
            return bol;
        }
        public IEnumerable<bol_SPSRegionName> GetSPSRegionList()
        {
            List<bol_SPSRegionName> regions = new List<bol_SPSRegionName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 14);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSRegionName region = new bol_SPSRegionName();
                    region.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    region.Region = dr["Region"] == DBNull.Value ? null : dr["Region"].ToString();
                    regions.Add(region);
                }
            }
            return regions;
        }

        public IEnumerable<bol_SPSGroupName> GetSPSGroupNameList()
        {
            List<bol_SPSGroupName> groups = new List<bol_SPSGroupName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 9);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSGroupName group = new bol_SPSGroupName();
                    group.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    group.GroupName = dr["GroupName"] == DBNull.Value ? null : dr["GroupName"].ToString();
                    groups.Add(group);
                }
            }
            return groups;
        }
        public IEnumerable<bol_SPSGroupName> GetSPSGroupNameListByUserName(string UserName)
        {
            List<bol_SPSGroupName> groups = new List<bol_SPSGroupName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 17);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSGroupName group = new bol_SPSGroupName();
                    group.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    group.GroupName = dr["GroupName"] == DBNull.Value ? null : dr["GroupName"].ToString();
                    groups.Add(group);
                }
            }
            return groups;
        }
        public IEnumerable<bol_SPSGroupName> GetSPSGroupNameListForSPSInsight(string UserName)
        {
            List<bol_SPSGroupName> groups = new List<bol_SPSGroupName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 25);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSGroupName group = new bol_SPSGroupName();
                    group.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    group.GroupName = dr["GroupName"] == DBNull.Value ? null : dr["GroupName"].ToString();
                    groups.Add(group);
                }
            }
            return groups;
        }
        public IEnumerable<bol_SPSTeamName> GetSPSTeamNameListForSPSInsight(string UserName)
        {
            List<bol_SPSTeamName> teams = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 28);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName team = new bol_SPSTeamName();
                    team.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    team.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(team);
                }
            }
            return teams;
        }

        public IEnumerable<bol_SPSTeamName> GetSPSTeamNameList()
        {
            List<bol_SPSTeamName> teams = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 10);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName team = new bol_SPSTeamName();
                    team.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    team.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(team);
                }
            }
            return teams;
        }
        public IEnumerable<bol_SPSTeamName> GetSPSTeamNameListByUserName(string UserName)
        {
            List<bol_SPSTeamName> teams = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 23);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName team = new bol_SPSTeamName();
                    team.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    team.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(team);
                }
            }
            return teams;
        }
        public IEnumerable<bol_SPSTeamName> GetSPSUserNameList()
        {
            List<bol_SPSTeamName> teams = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 3);
                cmd.Parameters.AddWithValue("@UserName", 3);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName team = new bol_SPSTeamName();
                    team.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    team.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(team);
                }
            }
            return teams;
        }
        public IEnumerable<bol_SPSGroupName> GetGroupByID(bol_SPSGroupName bol)
        {
            List<bol_SPSGroupName> cities = new List<bol_SPSGroupName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSGroupName citydata = new bol_SPSGroupName();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.GroupName = dr["GroupName"] == DBNull.Value ? null : dr["GroupName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_SPSTeamName> GetTeamByID(bol_SPSTeamName bol)
        {
            List<bol_SPSTeamName> cities = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.ID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName citydata = new bol_SPSTeamName();
                    citydata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    citydata.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    cities.Add(citydata);
                }
            }
            return cities;
        }
        public IEnumerable<bol_SPSTeamName> GetTeamNameByGroupID(bol_SPSTeamName bol)
        {
            List<bol_SPSTeamName> teams = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.GroupID);
                cmd.Parameters.AddWithValue("@UserName", bol.LoginUser);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName team = new bol_SPSTeamName();
                    team.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    team.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(team);
                }
            }
            return teams;
        }
        public IEnumerable<bol_SPSGroupName> GetGroupNameByRegion(bol_SPSGroupName bol)
        {
            List<bol_SPSGroupName> groups = new List<bol_SPSGroupName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@Region", bol.Region);
                cmd.Parameters.AddWithValue("@UserName", bol.LoginUser);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSGroupName group = new bol_SPSGroupName();
                    group.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    group.GroupName = dr["GroupName"] == DBNull.Value ? null : dr["GroupName"].ToString();
                    groups.Add(group);
                }
            }
            return groups;
        }

        public IEnumerable<bol_SPSTeamName> GetTeamNameByRegion(bol_SPSTeamName bol)
        {
            List<bol_SPSTeamName> teams = new List<bol_SPSTeamName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@ID", bol.GroupID);
                cmd.Parameters.AddWithValue("@Region", bol.Region);
                cmd.Parameters.AddWithValue("@UserName", bol.LoginUser);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTeamName team = new bol_SPSTeamName();
                    team.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    team.TeamName = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(team);
                }
            }
            return teams;
        }
        public IEnumerable<bol_SPSUserName> GetSPSUserNameByPermission(string UserName)
        {
            List<bol_SPSUserName> users = new List<bol_SPSUserName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 19);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSUserName user = new bol_SPSUserName();
                    user.UserName = dr["userName"] == DBNull.Value ? null : dr["userName"].ToString();
                    user.FullName = dr["fullName"] == DBNull.Value ? null : dr["fullName"].ToString();
                    users.Add(user);
                }
            }
            return users;
        }
        public IEnumerable<bol_SPSUserName> GetSPSUserNameByCity(bol_SPSUserName bol)
        {
            List<bol_SPSUserName> users = new List<bol_SPSUserName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                cmd.Parameters.AddWithValue("@UserName", bol.LoginUser);
                cmd.Parameters.AddWithValue("@Region", bol.Region);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSUserName user = new bol_SPSUserName();
                    user.UserName = dr["userName"] == DBNull.Value ? null : dr["userName"].ToString();
                    user.FullName = dr["fullName"] == DBNull.Value ? null : dr["fullName"].ToString();
                    users.Add(user);
                }
            }
            return users;
        }
        public IEnumerable<bol_SPSUserName> GetSPSUserNameByGroupID(string GroupID,string UserName)
        {
            List<bol_SPSUserName> users = new List<bol_SPSUserName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 20);
                cmd.Parameters.AddWithValue("@GroupID", GroupID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSUserName user = new bol_SPSUserName();
                    user.UserName = dr["userName"] == DBNull.Value ? null : dr["userName"].ToString();
                    user.FullName = dr["fullName"] == DBNull.Value ? null : dr["fullName"].ToString();
                    users.Add(user);
                }
            }
            return users;
        }
        public IEnumerable<bol_SPSUserName> GetSPSUserNameByTeamID(string TeamID,string UserName)
        {
            List<bol_SPSUserName> users = new List<bol_SPSUserName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 21);
                cmd.Parameters.AddWithValue("@TeamID", TeamID);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSUserName user = new bol_SPSUserName();
                    user.UserName = dr["userName"] == DBNull.Value ? null : dr["userName"].ToString();
                    user.FullName = dr["fullName"] == DBNull.Value ? null : dr["fullName"].ToString();
                    users.Add(user);
                }
            }
            return users;
        }

        #region[Cash Collector Data]
        public IEnumerable<bol_SPSCashCollector> GetSPSCashCollectorByPermission(bol_SPSCashCollector bol)
        {
            List<bol_SPSCashCollector> users = new List<bol_SPSCashCollector>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 31);
                cmd.Parameters.AddWithValue("@UserName", bol.LoginUser);
                cmd.Parameters.AddWithValue("@Region", bol.Region);
                cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSCashCollector user = new bol_SPSCashCollector();
                    user.CashCollector = dr["CashCollector"] == DBNull.Value ? null : dr["CashCollector"].ToString();
                    user.CashCollectorFullName = dr["CashCollectorFullName"] == DBNull.Value ? null : dr["CashCollectorFullName"].ToString();
                    users.Add(user);
                }
            }
            return users;
        }
      
        #endregion
        public IEnumerable<bol_Channel> SPSChannelList(bol_Channel bol)
        {
            List<bol_Channel> businesstypes = new List<bol_Channel>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Channel businesstypedata = new bol_Channel();
                    businesstypedata.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    businesstypedata.Channel = dr["Channel"] == DBNull.Value ? null : dr["Channel"].ToString();
                    businesstypes.Add(businesstypedata);
                }
            }
            return businesstypes;
        }
        public IEnumerable<bol_SPSRegionName> GetSPSRegionListByPermission(string UserName)
        {
            List<bol_SPSRegionName> regions = new List<bol_SPSRegionName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 24);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSRegionName region = new bol_SPSRegionName();
                    region.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    region.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    regions.Add(region);
                }
            }
            return regions;
        }
        public IEnumerable<bol_SPSTownshipName> GetSPSTownshipListByPermission(string UserName)
        {
            List<bol_SPSTownshipName> regions = new List<bol_SPSTownshipName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 27);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSTownshipName region = new bol_SPSTownshipName();
                    region.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    region.Township = dr["Township"] == DBNull.Value ? null : dr["Township"].ToString();
                    regions.Add(region);
                }
            }
            return regions;
        }
        public IEnumerable<bol_SPSRegionName> GetSPSRegionListByPermissionForSPSInsight(string UserName)
        {
            List<bol_SPSRegionName> regions = new List<bol_SPSRegionName>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_sps_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 26);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_SPSRegionName region = new bol_SPSRegionName();
                    region.ID = dr["ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["ID"].ToString());
                    region.CityName = dr["CityName"] == DBNull.Value ? null : dr["CityName"].ToString();
                    regions.Add(region);
                }
            }
            return regions;
        }
        public IEnumerable<bol_userdevicetoken> GetUserDeviceTokenList(string UserName)
        {
            List<bol_userdevicetoken> devtoklist = new List<bol_userdevicetoken>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", 57);
                cmd.Parameters.AddWithValue("@UserName", UserName);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_userdevicetoken devtoken = new bol_userdevicetoken();
                    devtoken.DeviceToken = dr["DeviceToken"] == DBNull.Value ? null : dr["DeviceToken"].ToString();
                    devtoklist.Add(devtoken);
                }
            }
            return devtoklist;
        }

        public IEnumerable<bol_Location> GetLocationList(bol_Location bol)
        {
            List<bol_Location> locations = new List<bol_Location>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Location locationData = new bol_Location();
                    locationData.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    locationData.LocationName = dr["LocationName"] == DBNull.Value ? null : dr["LocationName"].ToString();
                    locations.Add(locationData);
                }
            }
            return locations;
        }

        public IEnumerable<bol_Team> GetTeamList(bol_Team bol)
        {
            List<bol_Team> teams = new List<bol_Team>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Team teamdata = new bol_Team();
                    teamdata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    teamdata.TeamName  = dr["TeamName"] == DBNull.Value ? null : dr["TeamName"].ToString();
                    teams.Add(teamdata);
                }
            }
            return teams;
        }

        public IEnumerable<bol_Position> GetPositionList(bol_Position bol)
        {
            List<bol_Position> positions = new List<bol_Position>();

            using (SqlConnection con = new SqlConnection(conn_str))
            {
                SqlCommand cmd = new SqlCommand("sp_General", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bol_Position positiondata = new bol_Position();
                    positiondata.ID = dr["ID"] == DBNull.Value ? 0 : int.Parse(dr["ID"].ToString());
                    positiondata.PositionName = dr["PositionName"] == DBNull.Value ? null : dr["PositionName"].ToString();
                    positions.Add(positiondata);
                }
            }
            return positions;
        }

    }
}
using BOL;
using BOL.API;
using BOL.GT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.GT
{
    public class dal_GT_Team
    {
        private string conn_str;
        private ResultMsg result;

        public dal_GT_Team()
        {
            conn_str = dal_ConfigManager.GTG;
            result = new ResultMsg();
        }
        public List<bol_Team_Detail> dal_TeamList(bol_Team_List_Req team)
        {
            List<bol_Team_Detail> TeamList = new List<bol_Team_Detail>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", team.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchTeamName", team.searchTeamName);
                    cmd.Parameters.AddWithValue("@SearchCity", team.searchCity);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_Team_Detail t = new bol_Team_Detail();
                        t.ID = Convert.ToInt32(dr["ID"].ToString()); 
                        t.TeamName = dr["TeamName"].ToString();
                        t.TeamLeader = dr["TeamLeader"].ToString();
                        t.CashCollector = dr["CashCollector"].ToString();
                        if(t.CashCollector != null)
                        {
                            var CashCollectorString = dr["CashCollector"].ToString();
                            t.CashCollectorArray = CashCollectorString.Split(',');
                        }
                        
                        t.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                        t.City = dr["City"].ToString();
                        t.CityID = Convert.ToInt32(dr["CityID"].ToString());
                        bol_Team_Member_Req teamMember = new bol_Team_Member_Req();
                        teamMember.ActionParam = 2;
                        teamMember.TeamID = t.ID;
                        t.TeamMembers = dal_TeamMember(teamMember);
                        TeamList.Add(t);
                    }
                        con.Close();
                }
            }
            catch (Exception ex)
            {
               

            }
            return TeamList;
        }
        
        public List<bol_Team_Member> dal_TeamMember(bol_Team_Member_Req bol)
        {
            List<bol_Team_Member> team = new List<bol_Team_Member>();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_Team_Member t = new bol_Team_Member();
                        t.ID = Convert.ToInt32(dr["ID"].ToString());
                        t.UserName = dr["userName"].ToString();
                        t.Name = dr["StaffName"].ToString();
                        team.Add(t);
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {

            }
            return team;
        }
        public ResultMsg dal_UpdateTeamName(bol_UpdateTeamNameReq req)
        {
            ResultMsg msg = new ResultMsg();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", req.ActionParam);
                    cmd.Parameters.AddWithValue("@TeamID", req.TeamID);
                    cmd.Parameters.AddWithValue("@TeamName", req.TeamName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        msg.Result = dr["Result"].ToString();
                    }
                    con.Close();
                }
            }catch(Exception ex)
            {

            }
            return msg;
        }
        public List<bol_GetTeamMemberList> dal_GetTeamMemberList(bol_GetTeamMemberList bol)
        {
            List<bol_GetTeamMemberList> teamMember = new List<bol_GetTeamMemberList>();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetTeamMemberList team = new bol_GetTeamMemberList();
                        team.UserName = dr["userName"].ToString();
                        team.FullName = dr["fullName"].ToString();
                        teamMember.Add(team);
                    }
                    con.Close();
                }
            }catch(Exception ex)
            {

            }
            return teamMember;
        }
        public List<bol_GetTeamMemberList> dal_GetTeamLeaderList()
        {
            List<bol_GetTeamMemberList> teamMember = new List<bol_GetTeamMemberList>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 18);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetTeamMemberList team = new bol_GetTeamMemberList();
                        team.UserName = dr["userName"].ToString();
                        team.FullName = dr["fullName"].ToString();
                        teamMember.Add(team);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return teamMember;
        }

        public List<bol_GetTeamMemberList> dal_GetCashColectorList(bol_GetTeamMemberList bol)
        {
            List<bol_GetTeamMemberList> teamMember = new List<bol_GetTeamMemberList>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetTeamMemberList team = new bol_GetTeamMemberList();
                        team.UserName = dr["userName"].ToString();
                        team.FullName = dr["fullName"].ToString();
                        teamMember.Add(team);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return teamMember;
        }
        public List<bol_GetTeamMemberList> dal_GetCashColectorListExcept(bol_GetTeamMemberList bol)
        {
            List<bol_GetTeamMemberList> teamMember = new List<bol_GetTeamMemberList>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@CashCollector", bol.CashCollector);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetTeamMemberList team = new bol_GetTeamMemberList();
                        team.UserName = dr["userName"].ToString();
                        team.FullName = dr["fullName"].ToString();
                        teamMember.Add(team);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return teamMember;
        }
        //public ResultMsg dal_AddNewTeam(bol_AddNewTeamReq bol)
        //{
        //    ResultMsg result = new ResultMsg();
        //    try
        //    {
        //        using(SqlConnection con = new SqlConnection(conn_str))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
        //            cmd.Parameters.AddWithValue("@TeamName", bol.TeamName);
        //            cmd.Parameters.AddWithValue("@TeamMember", bol.TeamMembers);
        //            cmd.Parameters.AddWithValue("@City", bol.City);
        //            cmd.Parameters.AddWithValue("@CashCollector", bol.CashCollector);
        //            cmd.Parameters.AddWithValue("@IsActive", bol.Active);
        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                result.Result = dr["Result"].ToString();
        //            }
        //            con.Close();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return result;
        //}
        public bol_Team_Detail dal_GetTeamDetailWithID(bol_Team_Detail bol)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 6);
                    cmd.Parameters.AddWithValue("@TeamID", bol.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol.ID = Convert.ToInt32(dr["ID"].ToString());
                        bol.TeamName = dr["TeamName"].ToString();
                        bol.TeamLeader = dr["TeamLeader"].ToString();
                        bol.TeamLeaderFullName = dr["TeamLeaderFullName"].ToString();
                        bol.CashCollector = dr["CashCollector"].ToString();
                        List<bol_GroupLeader> cclist = new List<bol_GroupLeader>();
                        if (bol.CashCollector != null)
                        {
                            var CashCollectorString = dr["CashCollector"].ToString();
                            bol.CashCollectorArray = CashCollectorString.Split(',');
                        }
                        for(var i = 0; i<bol.CashCollectorArray.Length; i++)
                        {
                            bol_GroupLeader cc = dal_GetGroupLeader(bol.CashCollectorArray[i]);
                            cclist.Add(cc);
                            
                        }
                        bol.CashCollectorList = cclist;
                        bol.IsActive = Convert.ToBoolean(dr["IsActive"].ToString());
                        bol.City = dr["City"].ToString();
                        bol.CityID = Convert.ToInt32(dr["CityID"].ToString());
                        bol_Team_Member_Req teamMember = new bol_Team_Member_Req();
                        teamMember.ActionParam = 2;
                        teamMember.TeamID = bol.ID;
                        bol.TeamMembers = dal_TeamMember(teamMember);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return bol;
        }
        public List<bol_Group_Detail> dal_GroupList(bol_Group_List_Req group)
        {
            List<bol_Group_Detail> GroupList = new List<bol_Group_Detail>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", group.ActionParam);
                    cmd.Parameters.AddWithValue("@SearchGroupName", group.searchGroupName);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_Group_Detail g = new bol_Group_Detail();
                        g.ID = Convert.ToInt32(dr["ID"].ToString());
                        g.GroupName = dr["GroupName"].ToString();
                        var s = dr["GroupLeader"].ToString();
                        string[] GroupLeaderArray = s.Split(',');
                        
                        List<bol_GroupLeader> groupLeader = new List<bol_GroupLeader>();
                        g.GroupLeader = GroupLeaderArray;
                        for (var i = 0; i < GroupLeaderArray.Length; i++)
                        {
                            bol_GroupLeader gl = dal_GetGroupLeader(GroupLeaderArray[i]);
                            groupLeader.Add(gl);
                        }
                        g.GroupLeader1 = groupLeader;
                        g.Active = Convert.ToBoolean(dr["IsActive"].ToString());
                        bol_TeamReq t = new bol_TeamReq();
                        t.ActionParam = 8;
                        t.GroupID = g.ID;
                        g.Teams = dal_GetTeamForGroup(t);
                        GroupList.Add(g);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {


            }
            return GroupList;
        }
        public List<bol_UpdateTeamNameReq> dal_GetTeamForGroup(bol_TeamReq bol)
        {
            List<bol_UpdateTeamNameReq> team = new List<bol_UpdateTeamNameReq>();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_UpdateTeamNameReq T = new bol_UpdateTeamNameReq();
                        T.TeamID = Convert.ToInt32(dr["ID"].ToString());
                        T.TeamName = dr["TeamName"].ToString();
                        team.Add(T);
                    }
                    con.Close();
                }
            }catch(Exception e)
            {

            }
            return team;
        }
        public List<bol_GroupLeaderList> dal_GetGroupLeaderList()
        {
            List < bol_GroupLeaderList >groupLeader = new List<bol_GroupLeaderList>();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 9);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GroupLeaderList g = new bol_GroupLeaderList();
                        g.UserName = dr["userName"].ToString();
                        g.FullName = dr["fullName"].ToString();
                        groupLeader.Add(g);
                    }
                    con.Close();

                }

            }catch(Exception e)
            {

            }
            return groupLeader;
        }
        public List<bol_UpdateTeamNameReq> dal_GetGroupMemberList()
        {
            List<bol_UpdateTeamNameReq> GroupMember = new List<bol_UpdateTeamNameReq>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 10);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_UpdateTeamNameReq g = new bol_UpdateTeamNameReq();
                        g.TeamID = Convert.ToInt32(dr["ID"].ToString());
                        g.TeamName = dr["TeamName"].ToString();
                        GroupMember.Add(g);
                    }
                    con.Close();

                }

            }
            catch (Exception e)
            {

            }
            return GroupMember;
        }
        public ResultMsg dal_AddNewGroup(bol_AddGroupReq bol)
        {
            ResultMsg msg = new ResultMsg();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", bol.ActionParam);
                    cmd.Parameters.AddWithValue("@GroupName", bol.GroupName);
                    cmd.Parameters.AddWithValue("@GroupLeader", bol.GroupLeader);
                    cmd.Parameters.AddWithValue("@GroupMember", bol.GroupMember);
                    cmd.Parameters.AddWithValue("@IsActive", bol.Active);
                    cmd.Parameters.AddWithValue("@CreatedBy", bol.CreatedBy);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        msg.Message = dr["RespDescription"].ToString();
                    }
                   
                }
            }
            catch(Exception ex)
            {

            }
            return msg;
        }
        public bol_Group_Detail dal_GetGroupWithID(bol_Group_Detail bol)
        {
            List<bol_GroupLeader> group = new List<bol_GroupLeader>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 12);
                    cmd.Parameters.AddWithValue("@GroupID", bol.ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol.GroupName = dr["GroupName"].ToString();
                        var s = dr["GroupLeader"].ToString();
                        string[] GroupLeaderArray = s.Split(',');
                        bol.GroupLeader = GroupLeaderArray;
                        for (var i = 0; i<GroupLeaderArray.Length; i++)
                        {
                            bol_GroupLeader gl = dal_GetGroupLeader(GroupLeaderArray[i]);
                            group.Add(gl);
                        }
                        bol.GroupLeader1 = group;
                        bol_TeamReq t = new bol_TeamReq();
                        t.ActionParam = 8;
                        t.GroupID = bol.ID;
                        bol.Teams = dal_GetTeamForGroup(t);
                        bol.Active =Convert.ToBoolean(dr["IsActive"].ToString());
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return bol;
        }
        public bol_GroupLeader dal_GetGroupLeader(string userName)
        {
            bol_GroupLeader bol = new bol_GroupLeader();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 13);
                    cmd.Parameters.AddWithValue("@userName", userName);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol.UserName =userName;
                       
                        bol.FullName = dr["fullName"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return bol;
        }
        public List<bol_Team_Member> dal_GetSPSMemberList()
        {
            List <bol_Team_Member> M= new List<bol_Team_Member>();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 14);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_Team_Member tm = new bol_Team_Member();
                        tm.UserName = dr["UserName"].ToString();
                        tm.Name = dr["FullName"].ToString();
                        M.Add(tm);
                    }
                    con.Close();
                }
            }
            catch(Exception ex)
            {

            }
            return M;
        }
        public List<bol_Member> dal_GetMemberList(bol_member_req req)
        {
            List<bol_Member> bol = new List<bol_Member>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 15);
                    cmd.Parameters.AddWithValue("@SearchMember", req.searchMember);
                    cmd.Parameters.AddWithValue("@SearchGroupName", req.searchGroup);
                    cmd.Parameters.AddWithValue("@SearchTeamName", req.searchTeam);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    
                    while (dr.Read())
                    {
                        bol_Member m = new bol_Member();
                        m.GroupID = dr["GroupID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["GroupID"]);
                        m.TeamID = dr["TeamID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["TeamID"]);
                        m.GroupName = dr["GroupName"] == DBNull.Value ? "": dr["GroupName"].ToString();
                        m.TeamName = dr["TeamName"] == DBNull.Value ? "" : dr["TeamName"].ToString();
                        m.TeamLeader = dr["TeamLeader"] == DBNull.Value ? "" : dr["TeamLeader"].ToString();
                        m.GroupLeader = dr["GroupLeader"] == DBNull.Value ? "" : dr["GroupLeader"].ToString();
                        m.FullName = dr["FullName"].ToString();
                        m.UserName = dr["UserName"].ToString();
                        m.IsActive = dr["IsActive"] == DBNull.Value ? false : Convert.ToBoolean(dr["IsActive"].ToString());
                        if(m.TeamName == "" && m.GroupName != "")
                        {
                            m.IsGroupLeader = true;
                        }
                        else
                        {
                            m.IsGroupLeader = false;
                        }
                        if(m.TeamLeader == m.UserName)
                        {
                            m.IsTeamLeader = true;
                        }
                        else
                        {
                            m.IsTeamLeader = false;
                        }
                        m.CanGroupLeader = dr["CanGroupLeader"] == DBNull.Value ? false : Convert.ToBoolean(dr["CanGroupLeader"]);
                        m.CanTeamLeader = dr["CanTeamLeader"] == DBNull.Value ? false : Convert.ToBoolean(dr["CanTeamLeader"]);
                        bol.Add(m);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return bol;
        }
        public List<bol_UpdateTeamNameReq> dal_GetTeamNameForExist(int ID)
        {
            List<bol_UpdateTeamNameReq> bol = new List<bol_UpdateTeamNameReq>();
            try
            {
                using(SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 16);
                    cmd.Parameters.AddWithValue("@TeamID", ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_UpdateTeamNameReq t = new bol_UpdateTeamNameReq();
                        t.TeamID = Convert.ToInt32(dr["ID"].ToString());
                        t.TeamName = dr["TeamName"].ToString();
                        bol.Add(t);
                    }
                    con.Close();
                }
            }catch(Exception ex)
            {

            }
            return bol;
        }
        public List<bol_Group_Detail> dal_GetGroupNameForExist(int ID)
        {
            List<bol_Group_Detail> bol = new List<bol_Group_Detail>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 17);
                    cmd.Parameters.AddWithValue("@GroupID", ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_Group_Detail g = new bol_Group_Detail();
                        g.ID = Convert.ToInt32(dr["ID"].ToString());
                        g.GroupName = dr["GroupName"].ToString();
                        bol.Add(g);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return bol;
        }
        public string dal_GetTeamLeaderWithID(int ID)
        {
            string TeamLeader = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 19);
                    cmd.Parameters.AddWithValue("@TeamID", ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        TeamLeader = dr["TeamLeader"] == DBNull.Value ? "" : dr["TeamLeader"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return TeamLeader;
        }
        public string dal_GetGroupLeaderWithID(int ID)
        {
            string GroupLeader = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 20);
                    cmd.Parameters.AddWithValue("@GroupID", ID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        GroupLeader = dr["GroupLeader"] == DBNull.Value ? "" : dr["GroupLeader"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return GroupLeader;
        }
        public string dal_UpdateTeamMember(bol_Member bol)
        {
            string result = "";
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 21);
                    cmd.Parameters.AddWithValue("@GroupID", bol.GroupID);
                    cmd.Parameters.AddWithValue("@TeamID", bol.TeamID);
                    cmd.Parameters.AddWithValue("@isGroupLeader", bol.IsGroupLeader);
                    cmd.Parameters.AddWithValue("@GroupLeader", bol.GroupLeader);
                    cmd.Parameters.AddWithValue("@TeamLeader", bol.TeamLeader);
                    cmd.Parameters.AddWithValue("@UpdatedBy", bol.UpdatedBy);
                    cmd.Parameters.AddWithValue("@UserName", bol.UserName);
                    cmd.Parameters.AddWithValue("@PreviousTeamID", bol.PreviousTeamID);
                    cmd.Parameters.AddWithValue("@PreviousTeamLeader", bol.PreviousTeamLeader);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        result = dr["ResDescription"] == DBNull.Value ? "" : dr["ResDescription"].ToString();
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public List<bol_GetTeamMemberList> dal_GetRemainGroupLeaderWithID(string GroupLeader)
        {
            List<bol_GetTeamMemberList> bol = new List<bol_GetTeamMemberList>();
            try
            {
                using (SqlConnection con = new SqlConnection(conn_str))
                {
                    SqlCommand cmd = new SqlCommand("sp_GroupsTeams", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ActionParam", 22);
                    cmd.Parameters.AddWithValue("@GroupLeader", GroupLeader);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bol_GetTeamMemberList b = new bol_GetTeamMemberList();

                        b.FullName  = dr["FullName"] == DBNull.Value ? "" : dr["FullName"].ToString();
                        b.UserName = dr["UserName"] == DBNull.Value ? "" : dr["UserName"].ToString();
                        bol.Add(b);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return bol;
        }

    }
}

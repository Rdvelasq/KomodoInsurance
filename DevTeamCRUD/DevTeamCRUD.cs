using DeveloperNameSpace;
using DeveloperRepo;
using DevTeamNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamRepo
{
    public class DevTeamCRUD
    {
        private DeveloperCRUD developer = new DeveloperCRUD();
        private List<DevTeam> _devTeams = new List<DevTeam>();
        private DevTeam devteam = new DevTeam();
        private List<Developer> _developers = new List<Developer>();
       

        //Create
        public void CreateDevTeam(DevTeam devTeam)
        {
            _devTeams.Add(devTeam);
        }

        //Read
        public List<DevTeam> GetDevTeam()
        {
            return _devTeams;
        }

        //Update 
        public bool UpdateDevTeam(int oldTeamID, DevTeam newDevTeam)
        {
            DevTeam oldDevTeam = GetDevTeam(oldTeamID);
            if (oldDevTeam != null)
            {
                oldDevTeam.TeamName = newDevTeam.TeamName;
                oldDevTeam.TeamID = newDevTeam.TeamID;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteTeam(int id)
        {
            DevTeam devteam = GetDevTeam(id);
            int initalCount = _devTeams.Count();
            _devTeams.Remove(devteam);
            if (initalCount >  _devTeams.Count())
            {
         
                return true;
            }
            else
            {
                return false;
            }

        }
        public void AddTeamMember(Developer devObject, int id)
        {
            DevTeam getTeam = GetDevTeam(id);
            getTeam.Developers.Add(devObject);
           
            

        }
        public List <Developer> ViewTeamMembers(int id)
        {
            DevTeam devTeam = GetDevTeam(id);
            return devTeam.Developers;

        }
        public bool DeleteTeamMember(int teamID, Developer devObj)
        {

            DevTeam devteam = GetDevTeam(teamID);
            foreach(Developer devloper in devteam.Developers)
            {
                if(devloper == devObj)
                {
                    devteam.Developers.Remove(devloper);
                    return true;
                }
                
            }
            return false;
        } 
        //Helper
        public DevTeam GetDevTeam(int id)
        {
            foreach(DevTeam devteam in _devTeams)
            {
                if(id == devteam.TeamID)
                {
                    return devteam;
                }
                       
            }
            return null;
        }
        //Helper View Members 
        public Developer GetTeamMembers(DevTeam devteam)
        {
            foreach (Developer developer in devteam.Developers)
            {
                return developer;
            }
            return null;
        }

    }
}

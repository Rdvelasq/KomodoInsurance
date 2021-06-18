using DeveloperNameSpace;
using DeveloperRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamNameSpace
{
    public class DevTeam
    {
        public int TeamID { get; set; }
        public string TeamName { get; set; }
        public List<Developer> Developers { get; set; } = new List<Developer>();
        public DevTeam() { }
        public DevTeam(int teamID, string teamName) // Developer developer )
        {
            TeamID = teamID;
            TeamName = teamName;
            //Developer = developer;
        }
        public DevTeam(int teamID, string teamName,List <Developer> developers)
        {
            TeamID = teamID;
            TeamName = teamName;
            Developers = developers;
        }

        
    }
}

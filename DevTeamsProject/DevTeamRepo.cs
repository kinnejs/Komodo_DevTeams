using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DevTeamRepo
    {
        private readonly List<DevTeam> _devTeams = new List<DevTeam>();



        //Pull in both developer and devteam
        public void AddDevToDevTeam(Developer developer, DevTeam devteam)
        {
            devteam.ListofDevelopers.Add(developer);
        }

        //DevTeam Create
        public void AddTeamToList(DevTeam content)
        {
            _devTeams.Add(content);
        }
        //DevTeam Read
        public List<DevTeam> GetDevTeamList()
        {
            return _devTeams;
        }
        //DevTeam Update
        //Developer Update
        public bool UpdateExistingTeams(string originalTeam, DevTeam newTeam)
        {
            //Find Content
            DevTeam oldTeam = GetTeamByTeamName(originalTeam);

            //Update Content
            if (oldTeam != null)
            {
                
                oldTeam.License = newTeam.License;
                oldTeam.TeamName = newTeam.TeamName;

                return true;
            }
            else
            {
                return false;
            }
        }

      


        //DevTeam Delete
        public bool RemoveTeamFromList(string teamname)
        {
            DevTeam content = GetTeamByTeamName(teamname);

            if (content == null)
            {
                return false;
            }

            int initialCount = _devTeams.Count;
            _devTeams.Remove(content);

            if (initialCount > _devTeams.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

       

        //DevTeam Helper (Get Team by ID)
        public DevTeam GetTeamByTeamName(string teamName)
        {
            
            
            foreach (DevTeam content in _devTeams)

                if (content.TeamName.ToLower() == teamName.ToLower())
                {
                    return content;
                }
                else
                {
                    return null;
                }
            return null;
        }
    }

}


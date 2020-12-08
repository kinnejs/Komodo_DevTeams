using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public enum TeamNam
    {
        Alpha = 1,
        Beta,
        Gamma
    }

    public class DevTeam
    {
        //try instead of having separate name and Id for developer in two different places, keep it in the developer class only. And create a property that calls a List<Developer> as the reference type instead. 
        public List<Developer> ListofDevelopers{ get; set; }
        public string TeamName { get; set; }
        public bool License { get; set; }
        public DevTeam() { }
        public DevTeam(bool license, string teamName)
        {
            License = license;
            TeamName = teamName;
        }
    }
}

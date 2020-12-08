using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public enum TeamName {
    Alpha = 1,
    Beta,
    Gamma
    }
    //Plain Old C# Object POCO
    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool License { get; set; }
        public TeamName NameOfTeam { get; set; }

        public Developer() { }
        public Developer (string name, int id, bool license, TeamName teamname)
        {
            Name = name;
            ID = id;
            License = license;
            NameOfTeam = teamname;
        }

    }
}

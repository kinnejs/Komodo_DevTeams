using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTeamsProject
{
    public class DeveloperRepo
    {
        private readonly List<Developer> _developerDirectory = new List<Developer>();

        //Developer Create
        public void AddDeveloperToList(Developer content)
        {
            _developerDirectory.Add(content);
        }
        //Developer Read
        public List<Developer> GetDeveloperList()
        {
            return _developerDirectory;
        }
        //Developer Update
        public bool UpdateExistingDeveloper(int originalID, Developer newID)
        {
            //Find Content
            Developer oldID = GetDeveloperByID(originalID);

            //Update Content
            if(oldID != null)
            {
                oldID.Name = newID.Name;
                oldID.ID = newID.ID;
                oldID.License = newID.License;
                oldID.NameOfTeam = newID.NameOfTeam;

                return true;
            }
            else
            {
                return false;
            }
        }

        internal void Remove(Developer content)
        {
            throw new NotImplementedException();
        }

        //Developer Delete
        public bool RemoveContentFromList(int id)
        {
            Developer content = GetDeveloperByID(id);

            if(content == null)
            {
                return false;
            }

            int initialCount = _developerDirectory.Count;
            _developerDirectory.Remove(content);

            if(initialCount > _developerDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Developer Helper (Get Developer by ID)

        public Developer GetDeveloperByID(int id)
        {
            foreach (Developer content in _developerDirectory)
            {
                if(content.ID == id)
                {
                    return content;
                }
            }
            return null;
        }

       
    }
}

using DeveloperNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperRepo
{
    public class DeveloperCRUD
    {
        private List<Developer> _developers = new List<Developer>();

        //Create 
        public void AddDeveloper(Developer developer)
        {
            _developers.Add(developer);
        }

        //Read

        public List<Developer> GetDevelopers()
        {
            return _developers;
        }

        //Update
        public bool UpdateDeveloper(int oldId, Developer newDeveloper)
        {
            Developer oldDeveloper = GetDeveloperByID(oldId);
            if (oldDeveloper != null) 
            {
                oldDeveloper.Name = newDeveloper.Name ;
                oldDeveloper.ID = newDeveloper.ID  ;
                oldDeveloper.HasPluralSight = newDeveloper.HasPluralSight;
                return true;
            }
            else
            {
                return false;
            }
        }

        //Delete
        public bool DeleteDeveloper(int id)
        {
            Developer developer = GetDeveloperByID(id);
            if (developer == null)
            {
                return false;
            }

            int initalCount = _developers.Count();
            _developers.Remove(developer);

            if (initalCount > _developers.Count())
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        //Helper
        public Developer GetDeveloperByID(int id)
        {
            foreach(Developer developer in _developers)
            {
                if( developer.ID == id)
                {
                    return developer;
                }
                
            }
            return null;
        }

       
    }
}

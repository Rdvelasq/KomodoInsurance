using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeveloperNameSpace
{
    public class Developer
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public bool HasPluralSight { get; set; } 

        public Developer() { }
        public Developer(string name, int id, bool hasPluralSight)
        {
            Name = name;
            ID = id;
            HasPluralSight = hasPluralSight;
        }
    }
}

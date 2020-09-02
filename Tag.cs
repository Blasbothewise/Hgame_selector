using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hgame_selector
{
    class Tag
    {
        string Name;
        int ID;

        public Tag(String Name, int ID)
        {
            this.Name = Name;
            this.ID = ID;
        }

        public string name { get => Name; set => Name = value; }
        public int id { get => ID; set => ID = value; }
    }
}

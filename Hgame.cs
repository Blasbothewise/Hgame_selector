using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hgame_selector
{
    public class Hgame
    {
        private int ID;
        private string Name, JP_Name, Dev, ExePath, IconName;
        List<string> Genres;

        public Hgame(int ID, string Name, string jp_Name, string Dev, string ExePath, string IconName, List<string> Genres)
        {
            this.ID = ID;
            this.Name = Name;
            this.jp_Name = jp_Name;
            this.Dev = Dev;
            this.ExePath = ExePath;
            this.IconName = IconName;
            this.Genres = Genres;
        }

        public int id { get => ID; set => ID = value; }
        public string name { get => Name; set => Name = value; }
        public string jp_Name { get => JP_Name; set => JP_Name = value; }
        public string dev { get => Dev; set => Dev = value; }
        public string exePath { get => ExePath; set => ExePath = value; }
        public string iconName { get => IconName; set => IconName = value; }
        public List<string> genres { get => Genres; set => Genres = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hgame_selector
{
    public class Config
    {
        private String user, pass, vndb_tag_archive;
        private Boolean useCreds;

        public Config() //Default constuctor
        { 
        
        }

        public Config(String user, String pass)
        {
            this.user = user;
            this.pass = pass;
        }

        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public bool UseCreds { get => useCreds; set => useCreds = value; }
        public string VNDB_tag_archive { get => vndb_tag_archive; set => vndb_tag_archive = value; }
    }
}

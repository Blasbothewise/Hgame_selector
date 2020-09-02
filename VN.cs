using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hgame_selector
{
    public class VN
    {
        private string Original, Title, Image;

        private List<List<float>> Tags;

        public VN(string Original, string Title, string Image, List<List<float>> Tags)
        {
            this.Original = Original;
            this.Title = Title;
            this.Image = Image;
            this.Tags = Tags;
        }

        public string original { get => Original; set => Original = value; }
        public string title { get => Title; set => Title = value; }
        public string image { get => Image; set => Image = value; }
        public List<List<float>> tags { get => Tags; set => Tags = value; }
    }
}

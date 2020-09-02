using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hgame_selector
{
    class Tags
    {
        private List<Tag> tag_col;

        public Tags(List<Tag> tag_col)
        {
            this.Tag_col = tag_col;
        }

        internal List<Tag> Tag_col { get => tag_col; set => tag_col = value; }

        private bool tag_exists(int id)
        {
            for (int i = 0; i < Tag_col.Count; i++)
            {
                if (Tag_col[i].id == id)
                {
                    return true;
                }
            }

            return false;
        }

        private Tag get_tag(int id)
        {
            for (int i = 0; i < Tag_col.Count; i++)
            {
                if (Tag_col[i].id == id)
                {
                    return Tag_col[i];
                }
            }

            return null;
        }
    }
}

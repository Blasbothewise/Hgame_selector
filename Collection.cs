using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hgame_selector
{
    public class Collection
    {
        private int total = 0, last_index; //last index
        private List<Hgame> hgames, page = new List<Hgame>(), Itempool = new List<Hgame>();

        public Collection(int total, List<Hgame> hgames)
        {
            this.Total = total;
            this.Hgames = hgames;
            this.last_index = (int) hgames.Count() / 15;

            Console.WriteLine("LAST INDEX: " + last_index);
            Console.WriteLine("Hgames: " + hgames.Count);

            genPool("", "All");

            genPage(0);
        }

        

        public int Total { get => total; set => total = value; }
        public List<Hgame> Hgames { get => hgames; set => hgames = value; }

        public List<Hgame> GetPage()
        {
            return page;
        }

        public int get_Last_Index()
        {
            return last_index;
        }

        public void genPage(int Pageindex)
        {
            int actualIndex = Pageindex * 15;

            page.Clear();

            int plusTen = actualIndex + 15;

            if (plusTen > Itempool.Count)
            {
                plusTen = Itempool.Count;
            }

            for (int i = actualIndex; i < plusTen; i++)
            {
                page.Add(Itempool[i]);
            }
        }

        public void genPool(string srchTerm, string srchType)
        {
            Itempool.Clear();

            for (int i = 0; i < Hgames.Count; i++)
            {
                if (srchType.Equals("Tag"))
                {
                    for (int i2 = 0; i2 < Hgames[i].genres.Count; i2++)
                    {
                        if (Hgames[i].genres[i2].Equals(srchTerm))
                        {
                            Itempool.Add(Hgames[i]);
                        }
                    }
                }
                else if (srchType.Equals("Name"))
                {
                    if (Hgames[i].name.Contains(srchTerm))
                    {
                        Itempool.Add(Hgames[i]);
                    }
                }
                else if (srchType.Equals("Developer"))
                {
                    if (Hgames[i].dev.Equals(srchTerm, StringComparison.CurrentCultureIgnoreCase))
                    {
                        Itempool.Add(Hgames[i]);
                    }
                }
                else if (srchType.Equals("All"))
                {
                    Itempool.Add(Hgames[i]);
                }
                else
                {
                    //Should never get here so do nothing.
                }
            }

            last_index = (int)Itempool.Count() / 15;
        }

        public void sortPool(string srtType)
        {
            if (srtType.Equals("Addition order / ID"))
            {
                Itempool = Itempool.OrderBy(x => x.id).ToList();
            }
            else if (srtType.Equals("Developer"))
            {
                Itempool = Itempool.OrderBy(x => x.dev).ToList();
            }
            else if (srtType.Equals("Name asc"))
            {
                Itempool = Itempool.OrderBy(x => x.name).ToList();
            }
            else if (srtType.Equals("Name desc"))
            {
                Itempool = Itempool.OrderByDescending(x => x.name).ToList();
            }
            else
            {
                Itempool = Itempool.OrderBy(x => x.id).ToList();
            }
        }

        public void AddHgame(Hgame input)
        {
            Hgames.Add(input);
            last_index = (int)hgames.Count() / 15;
        }

        public Hgame GetHgame(int ID)
        {
            for (int i = 0; i < Hgames.Count; i++)
            {
                if (Hgames[i].id == ID)
                {
                    return Hgames[i];
                }
            }

            return null;
        }

        public void SetHgame(Hgame input)
        {
            for (int i = 0; i < Hgames.Count; i++)
            {
                if (Hgames[i].id == input.id)
                {
                    Hgames[i] = input;
                }
            }
        }

        public void RemoveHgame(Hgame input)
        {
            Hgames.Remove(input);
        }

        public string PrintHgames()
        {
            string str = "";
            for(int i = 0; i < Hgames.Count; i++)
            {
                str += "ID: " + Hgames[i].id + ", Name: " + Hgames[i].name + ", ExePath: " + Hgames[i].exePath + ", IconName: " + Hgames[i].iconName + ", Dev: " + Hgames[i].dev + ", Genres" + Hgames[i].genres + "\n";
            }

            return str;
        }

        public int getNextID()
        {
            return Hgames.Count + 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Play
    {
        public string Name { get; set; } //название
        public string Theater { get; set; } //театр
        public string Genre { get; set; } //жанр
        public string Actors { get; set; } //актеры
        public string Produser { get; set; } //режиссер
        public string Desc { get; set; } //описание
        public int Time { get; set; } //сколько часов идет
        public string picture { get; set; } //картинка 
        public List<session> sess { get; set; } //сеансы


        public int Pri
        {
            get
            {
                int min = Int32.MaxValue;
                for (int i = 0; i < sess.Count; i++)
                {
                    for (int j = 0; j < sess[i].tic.Count; j++)
                    {
                        if (min > sess[i].tic[j].price) min = sess[i].tic[j].price;
                    }
                }
                return min;
            }
        }

        public Play(string name2, string theater2, string genre2, string actors2, string produser2, string desc2, int time2, string picture2, List<session> sess2)
        {
            Name = name2;
            Theater = theater2;
            Genre = genre2;
            Actors = actors2;
            Produser = produser2;
            Desc = desc2;
            Time = time2;
            picture = picture2;
            sess = sess2;
        }
        public Play() { }


    }
}

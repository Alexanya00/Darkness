using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class session //сеансы
    {

        public string date { get; set; } //дата

        public string time { get; set; } //время

        public List<places> tic { get; set; } //билеты



        public int Pr // минимальная цена сеанса
        {
            
            get
            {
                int min= Int32.MaxValue;
                for (int i = 0; i < tic.Count; i++)
                {
                    if (min> tic[i].price) min = tic[i].price;

                }
                return min;
            }
        }

        public int plasess // количество ВСЕХ мест
        {

            get
            {
                int k=0;
                for (int i = 0; i < tic.Count; i++) k = k + tic[i].quantity;
                return k;
            }
        }


        public session(string date2, string time2, List<places> tic2)
        {
            date = date2;
            time = time2;
            tic = tic2;
        }
        public session() { }

    }
}

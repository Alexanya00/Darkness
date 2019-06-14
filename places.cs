using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class places //места и цены
    {
        public string name { get; set; }//название (ложа, партер и тд)
        public int quantity { get; set; } //количество мест данной категории
        public int price { get; set; }//цена

        public places(int quantity2, int price2, string name2)
        {
            quantity = quantity2;
            price = price2;
            name = name2;
        }
        public places() { }

    }
}

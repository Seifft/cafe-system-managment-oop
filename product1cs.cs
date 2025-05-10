using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe_system_managment
{
    public class product1
    {

        string name;
        decimal price;
        public product1(string Name, decimal Price)
        {
            name = Name;
            price = Price;
        }
        public override string ToString()
        {
            return name;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cafe_system_managment
{

    public class dgvproduct
    {
        // استخدام الأسماء الجديدة التي طلبتها
        public string product { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }

        public dgvproduct(string product, decimal price, int quantity, decimal total)
        {
            this.product = product;
            this.price = price;
            this.quantity = quantity;
            this.total = total;
        }
    }
}

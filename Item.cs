using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Item
    {
        public Item(string name, int quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public Item(string name, int price, int quantity)
        {
            this.Name = name;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Name { get; private set; }

        public int? Price { get; private set; }

        public int Quantity { get; private set; }
    }
}

using System.Collections.Generic;

namespace PromotionEngine
{
    public class Cart
    {
        private List<Item> cartItems;
        public Cart()
        {
            this.cartItems = new List<Item>();
        }

        public void AddItem(string name, int quantity)
        { 
            this.cartItems.Add(new Item(name, quantity));
        }

        public IEnumerable<Item> GetItems()
        {
            return this.cartItems;
        }
    }
}

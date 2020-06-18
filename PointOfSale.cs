using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PointOfSale
    {
        private Cart cart;
        private BackOffice store;
        public PointOfSale(BackOffice store)
        {
            this.cart = new Cart();
            this.store = store;
        }

        public void AddItemToCart(string name, int quantity)
        {
            this.cart.AddItem(name, quantity);
        }

        public int GetCartValue()
        {
            var cartItems = this.cart.GetItems().ToList();
            var offers = this.store.GetOffers();
            var value = this.GetSingleOffer(cartItems, offers);
            value = value + this.GetClubbedOffer(cartItems, offers);
            value = value + this.GetValueCartItems(cartItems);
            return value;
        }

        private int GetSingleOffer(List<Item> cartItems, IEnumerable<Promotion> offers)
        {
            int cartValue = 0;
            var items = cartItems.ToArray();
            foreach (var item in items)
            {
                var offer = offers.FirstOrDefault(f => f.OfferItems.Contains(item.Name) && !f.IsClubedOffer);
                if (offer != null && offer.Quantity <= item.Quantity)
                {
                    var totalOfferAvailed = item.Quantity / offer.Quantity;
                    var leftItem = item.Quantity - totalOfferAvailed * offer.Quantity;
                    cartValue = cartValue + totalOfferAvailed * offer.Price + leftItem * this.store.GetItemPrice(item.Name);

                    cartItems.Remove(item);
                }
            }

            return cartValue;
        }

        private int GetClubbedOffer(List<Item> cartItems, IEnumerable<Promotion> offers)
        {
            int cartValue = 0;
            var items = cartItems.ToArray();
            foreach (var item in items)
            {
                var offer = offers.FirstOrDefault(f => f.OfferItems.Contains(item.Name) && f.IsClubedOffer);
                if (offer != null)
                {
                    var clubbedItem = cartItems.FirstOrDefault(f => f.Name != item.Name && offer.OfferItems.Contains(f.Name));
                    if (clubbedItem != null)
                    {
                        cartValue = cartValue + offer.Price;

                        cartItems.Remove(item);
                        cartItems.Remove(clubbedItem);
                    }
                }
            }

            return cartValue;
        }

        private int GetValueCartItems(List<Item> cartItems)
        {
            int cartValue = 0;
            foreach (var item in cartItems)
            {
                cartValue = cartValue + item.Quantity * this.store.GetItemPrice(item.Name);
            }

            return cartValue;
        }
    }
}

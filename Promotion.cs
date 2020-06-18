using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class Promotion
    {
        public Promotion(IEnumerable<string> offerItems, int quantity, int price)
        {
            this.OfferItems = new List<string>();
            this.OfferItems.AddRange(offerItems);
            this.Quantity = quantity;
            this.Price = price;
        }

        public List<string> OfferItems { get; private set; }

        public int Quantity { get; private set; }

        public int Price { get; private set; }

        public bool IsClubedOffer
        {
            get
            {
                return this.OfferItems.Count > 1;
            }
        }
    }
}

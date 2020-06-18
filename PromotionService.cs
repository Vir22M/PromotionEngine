using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class PromotionService
    {
        private List<Promotion> offers;
        public PromotionService()
        {
            this.offers = new List<Promotion>();
        }

        public IEnumerable<Promotion> GetOffers()
        {
            return this.offers;
        }

        public void AddOffer(IEnumerable<string> offerItems, int price, int quantity)
        {
            var offer = new Promotion(offerItems, quantity, price);
            this.offers.Add(offer);
        }
    }
}

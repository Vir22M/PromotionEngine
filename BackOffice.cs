using System.Collections.Generic;
using System.Linq;

namespace PromotionEngine
{
    public class BackOffice
    {
        private List<Item> Items;
        private readonly PromotionService promotionService;
        public BackOffice()
        {
            this.Items = new List<Item>();
            this.promotionService = new PromotionService();
        }

        public void CreatePromotion(IEnumerable<string> itmeNames, int price, int quanity)
        {
            this.promotionService.AddOffer(itmeNames, price, quanity);
        }

        public void CreateItem(string name, int price, int quanity)
        {
            this.Items.Add(new Item(name, price, quanity));
        }

        public IEnumerable<Promotion> GetOffers()
        {
            return this.promotionService.GetOffers();
        }

        public int GetItemPrice(string name)
        {
            return this.Items.Single(s => s.Name == name).Price.Value;
        }
    }
}

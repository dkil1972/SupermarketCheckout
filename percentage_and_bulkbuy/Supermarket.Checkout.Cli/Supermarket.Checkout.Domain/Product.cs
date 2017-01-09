using System.Collections.Generic;
using System.Linq;

namespace Supermarket.Checkout.Domain
{
    public class Product
    {
        public Product(char sku, decimal unitPrice, List<IOffer> offers)
        {
            Sku = sku;
            UnitPrice = unitPrice;
            Offers = offers;
        }

        public char Sku { get; }
        private decimal UnitPrice { get; }
        public List<IOffer> Offers { get; }

        public decimal CalculatePriceWithDiscount(Dictionary<char, int> itemCounts)
        {
            var itemsInBasket = itemCounts[Sku];
            var offerToApply = Offers.FirstOrDefault(offer => offer.CanBeAppliedTo(itemsInBasket));
            return offerToApply?.CalculateTotalDiscountedPrice(itemsInBasket) ?? UnitPrice;
        }
    }
}
using System.Linq;

namespace Supermarket.Checkout.Domain
{
    public class Checkout
    {
        private IRepository PricingRepository { get; }

        public Checkout(IRepository pricingRepository)
        {
            PricingRepository = pricingRepository;
        }

        public decimal CalculatePriceFor(string shoppingBasketContent)
        {
            var products = PricingRepository.AllMatching(shoppingBasketContent);

            var itemCounts = shoppingBasketContent.ToCharArray()
                .GroupBy(item => item)
                .ToDictionary(item => item.Key, item => item.Count());

            return shoppingBasketContent.ToCharArray().Sum(
                item => products[item].CalculatePriceWithDiscount(itemCounts));
        }
    }
}
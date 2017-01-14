using System;
using Library;
using Xunit;
using System.Collections.Generic;

namespace Tests
{
    public class LibraryTests
    {
        [Fact]
        public void should_calculate_discounted_price_of_a_single_item_when_offer_can_be_applied() 
        {
            var data = new List<Product>
            {
                new Product('A', 50m, new PercentageOffer(0.9m))
            };

            var pricingRepository = new InMemoryRepository(data);
            var checkout = new Checkout(pricingRepository);
            var discountedPrice = checkout.CalculatePriceFor("A");
            Assert.Equal(45m, discountedPrice);
        }
    }

    public class InMemoryRepository : IRepository
    {
        private IEnumerable<Product> _dataToReturn;

        public InMemoryRepository(IEnumerable<Product> dataToReturn)
        {
            _dataToReturn = dataToReturn;
        }

        public IEnumerable<Product> GetAll(string itemsInBasket)
        {
            return _dataToReturn;
        }

    }
}

using System.Collections.Generic;
using Supermarket.Checkout.Domain;

namespace Supermarket.Checkout.Tests
{
    public class FakeRepository : IRepository
    {
        public Dictionary<char, Product> ProductsToReturn { get; }

        public FakeRepository(Dictionary<char, Product> productsToReturn)
        {
            ProductsToReturn = productsToReturn;
        }

        public IDictionary<char, Product> AllMatching(string shoppingBasketContent)
        {
            return ProductsToReturn;
        }
    }
}
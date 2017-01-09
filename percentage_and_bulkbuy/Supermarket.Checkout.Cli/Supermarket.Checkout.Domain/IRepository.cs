using System.Collections.Generic;

namespace Supermarket.Checkout.Domain
{
    public interface IRepository
    {
        IDictionary<char, Product> AllMatching(string shoppingBasketContent);
    }
}
using System;
using static Newtonsoft.Json.JsonConvert;
using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Checkout
    {
        private IRepository _pricingRepository; 

        public Checkout(IRepository repository)
        {
            _pricingRepository = repository;
        }
        public decimal CalculatePriceFor(string items)
        {
            var products = _pricingRepository.GetAll(items);

            return items.ToCharArray().Sum(
                    item => products.First(product => product.Sku == item)
                        .CalculatePriceWithDiscount(item));
        }
    }

    public interface IRepository
    {
        IEnumerable<Product> GetAll(string itemsInBasket);
    }

    public class Product
    {
        public char Sku {get; private set; }
        public decimal BasePrice {get; private set; }
        public PercentageOffer Offer {get; private set; }

        public Product(char sku, decimal basePrice, PercentageOffer offer)
        {
            Sku = sku;
            BasePrice = basePrice;
            Offer = offer;
        }

        public decimal CalculatePriceWithDiscount(char sku)
        {
            return -1;
        }
    }

    public class PercentageOffer
    {
        private decimal _multiplier;

        public PercentageOffer(decimal multiplier)
        {
            _multiplier = multiplier;
        }
    }
}

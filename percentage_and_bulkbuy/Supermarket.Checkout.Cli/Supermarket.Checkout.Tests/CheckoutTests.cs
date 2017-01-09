using System.Collections.Generic;
using NUnit.Framework;
using Supermarket.Checkout.Domain;

namespace Supermarket.Checkout.Tests
{

    public class CheckoutTests 
    {
        [TestCase("", 0)]
        [TestCase("A", 45)]
        [TestCase("AA", 90)]
        public void should_apply_percentage_discount_to_unit_price(
            string shoppingBasketContents, decimal expectedPrice)
        {
            var productA = new Product('A', 50m, new List<IOffer>
            {
                new PercentageOffer(50m, 0.9m),
            });
            var products = new Dictionary<char, Product>
            {
                {
                    productA.Sku, productA
                }
            };

            decimal totalPrice = new Domain.Checkout(
                new FakeRepository(products)).CalculatePriceFor(shoppingBasketContents);

            Assert.That(totalPrice, Is.EqualTo(expectedPrice));
        }

        [Test]
        public void should_apply_bulk_buy_discount_when_percentage_and_multi_buy_can_be_applied_to_product()
        {
            var productsToReturn = new Dictionary<char, Product>
            {
                {
                    'A', new Product('A', 50m, new List<IOffer>
                    {
                        new BulkBuyOffer(3, 130),
                        new PercentageOffer(50m, 0.8m)
                    })
                }
            };
            decimal totalPrice = new Domain.Checkout(
                new FakeRepository(productsToReturn)).CalculatePriceFor("AAA");

            Assert.That(totalPrice, Is.EqualTo(130m));
        }

        [Test]
        public void should_calculate_price_for_different_products_when_the_basket_contains_different_items()
        {
            var productsToReturn = new Dictionary<char, Product>
            {
                {
                    'A', new Product('A', 50m, 
                        new List<IOffer> { new BulkBuyOffer(3, 130), })
                },
                {
                    'B', new Product('B', 40m, 
                        new List<IOffer> { new BulkBuyOffer(2, 80), })
                }
            };
            decimal totalPrice = new Domain.Checkout(
                new FakeRepository(productsToReturn)).CalculatePriceFor("AB");

            Assert.That(totalPrice, Is.EqualTo(90m));
        }
    }
}

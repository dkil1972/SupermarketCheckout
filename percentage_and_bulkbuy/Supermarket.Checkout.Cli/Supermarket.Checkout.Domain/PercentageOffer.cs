namespace Supermarket.Checkout.Domain
{
    public class PercentageOffer : IOffer
    {
        public decimal UnitPrice { get; }
        public decimal Multiplyer { get; }

        public PercentageOffer(decimal unitPrice, decimal multiplyer)
        {
            UnitPrice = unitPrice;
            Multiplyer = multiplyer;
        }

        public decimal CalculateTotalDiscountedPrice(int numberItemsInBasket)
        {
            return UnitPrice * Multiplyer;
        }

        public bool CanBeAppliedTo(int itemsInBasket)
        {
            return true;
        }
    }
}
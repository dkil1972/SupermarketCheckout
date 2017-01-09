namespace Supermarket.Checkout.Domain
{
    public class BulkBuyOffer : IOffer
    {
        public int Threshold { get; }
        public decimal DiscountedPrice { get; }
        private int NumberOfTimesDiscountApplied { get; set; }

        public BulkBuyOffer(int threshold, decimal discountedPrice)
        {
            //threshold should never be zero, if it is throw an exception
            Threshold = threshold;
            DiscountedPrice = discountedPrice;
        }

        public decimal CalculateTotalDiscountedPrice(int numberItemsInBasket)
        {
            var numberOfTimesToApplyDiscount = numberItemsInBasket / Threshold;

            if (NumberOfTimesDiscountApplied >= numberOfTimesToApplyDiscount)
                return 0;

            NumberOfTimesDiscountApplied++;
            return numberItemsInBasket >= Threshold ? DiscountedPrice : 0;
        }

        public bool CanBeAppliedTo(int itemsInBasket)
        {
            return itemsInBasket >= Threshold;
        }
    }
}
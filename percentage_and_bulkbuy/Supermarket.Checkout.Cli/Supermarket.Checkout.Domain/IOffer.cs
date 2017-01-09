namespace Supermarket.Checkout.Domain
{
    public interface IOffer
    {
        decimal CalculateTotalDiscountedPrice(int numberItemsInBasket);
        bool CanBeAppliedTo(int itemsInBasket);
    }
}
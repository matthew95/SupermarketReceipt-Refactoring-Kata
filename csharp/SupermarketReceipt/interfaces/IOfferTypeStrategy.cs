namespace SupermarketReceipt.interfaces;

public interface IOfferTypeStrategy
{
    public Discount CalculateDiscount(double quantity, double unitPrice);
}
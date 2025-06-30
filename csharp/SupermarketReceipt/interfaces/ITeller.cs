namespace SupermarketReceipt.interfaces;

public interface ITeller
{
    public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument);
    public IReceipt ChecksOutArticlesFrom(ICart theCart);
}
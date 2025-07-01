namespace SupermarketReceipt.interfaces;

public interface ITeller
{
    public void AddSpecialOffer(IOfferTypeStrategy offerTypeStrategy, Product product);
    public IReceipt ChecksOutArticlesFrom(ICart theCart);
}
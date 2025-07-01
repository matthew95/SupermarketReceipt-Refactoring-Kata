using SupermarketReceipt.interfaces;

namespace SupermarketReceipt
{
    public enum SpecialOfferType
    {
        ThreeForTwo,
        TenPercentDiscount,
        TwoForAmount,
        FiveForAmount
    }

    public class Offer
    {
        private readonly IOfferTypeStrategy _offerTypeStrategy;
        private Product _product;

        // okay so this offer class just became a wrapper for offerTypestrategies and corresponding products.
        // Could probably make that one dictionary<Product, Offer> just dictionary<Product, IOfferTypeStrat> or something.
        public Offer(IOfferTypeStrategy offerTypeStrategy, Product product)
        {
            _offerTypeStrategy = offerTypeStrategy;
            _product = product;
        }

        public IOfferTypeStrategy GetOfferTypeStratey()
        {
            return _offerTypeStrategy;
        }
        
        
        
    }
}
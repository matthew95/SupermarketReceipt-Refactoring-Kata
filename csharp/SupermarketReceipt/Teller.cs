using System.Collections.Generic;
using SupermarketReceipt.interfaces;
using SupermarketReceipt.models;

namespace SupermarketReceipt
{
    public class Teller: ITeller
    {
        private readonly ISupermarketCatalog _catalog;
        private readonly OfferCatalog _offers = new();
        private readonly ReceiptGenerator _receiptGenerator = new ReceiptGenerator();

        public Teller(ISupermarketCatalog catalog /*, OfferCatalog offers*/)
        {
            _catalog = catalog;
            // _offers = offers;
        }

        public void AddSpecialOffer(SpecialOfferType offerType, Product product, double argument)
        {
            _offers[product] = new Offer(offerType, product, argument);
        }

        public IReceipt ChecksOutArticlesFrom(ICart theCart)
        {
            IReceipt receipt = new Receipt();
            var productQuantities = theCart.GetItems();
            foreach (var pq in productQuantities)
            {
                var p = pq.Product;
                var quantity = pq.Quantity;
                var unitPrice = _catalog.GetUnitPrice(p);
                var price = quantity * unitPrice;
                receipt.AddProduct(p, quantity, unitPrice, price);
            }

            
            // theCart.HandleOffers(receipt, _offers, _catalog);
            
            // I don't like the implicit modification of receipt but clearer for now than
            // when also returning it in Generate()
            this._receiptGenerator.Generate(receipt, theCart, _offers, _catalog);
            
            return receipt;
        }
    }
}
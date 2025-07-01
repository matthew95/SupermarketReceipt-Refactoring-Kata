using System.Globalization;
using System.Linq;
using SupermarketReceipt.implementations;
using SupermarketReceipt.interfaces;
using SupermarketReceipt.models;

namespace SupermarketReceipt;

public class ReceiptGenerator
{
    private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");
    
     public void Generate(IReceipt receipt, ICart cart, OfferCatalog offers, ISupermarketCatalog catalog)
        {
            foreach (var product in offers.Keys)
            {
                var quantityOptional = cart.GetItemQuantity(product);
                if (!offers.ContainsKey(product) || !quantityOptional.HasValue)
                {
                    continue;
                }
                
                var quantity = quantityOptional.Value;
                var quantityAsInt = (int)quantity;
                
                var offer = offers[product];
                var unitPrice = catalog.GetUnitPrice(product);
                Discount discount = null;
                var x = 1;
                if (offer.OfferType == SpecialOfferType.ThreeForTwo)
                {
                    x = 3;
                }
                else if (offer.OfferType == SpecialOfferType.TwoForAmount)
                {
                    x = 2;
                    if (quantityAsInt >= 2)
                    {
                        var total = offer.Argument * (quantityAsInt / x) + quantityAsInt % 2 * unitPrice;
                        var discountN = unitPrice * quantity - total;
                        discount = new Discount(product, "2 for " + PrintPrice(offer.Argument), -discountN);
                    }
                }

                if (offer.OfferType == SpecialOfferType.FiveForAmount) x = 5;
                var numberOfXs = quantityAsInt / x;
                if (offer.OfferType == SpecialOfferType.ThreeForTwo && quantityAsInt > 2)
                {
                    discount = (new OfferTypeZForXFactory()).Create(product, 3, 2).CalculateDiscount(quantity, unitPrice);
                }

                if (offer.OfferType == SpecialOfferType.TenPercentDiscount) discount = new Discount(product, offer.Argument + "% off", -quantity * unitPrice * offer.Argument / 100.0);
                if (offer.OfferType == SpecialOfferType.FiveForAmount && quantityAsInt >= 5)
                {
                    var discountTotal = unitPrice * quantity - (offer.Argument * numberOfXs + quantityAsInt % 5 * unitPrice);
                    discount = new Discount(product, x + " for " + PrintPrice(offer.Argument), -discountTotal);
                }

                if (discount != null)
                    receipt.AddDiscount(discount);
            }
            
        }
        
        private string PrintPrice(double price)
        {
            return price.ToString("N2", Culture);
        }
}
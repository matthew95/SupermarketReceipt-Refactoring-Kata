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
                    //TODO okay the offers.ContainsKey() is redundant because I iterate over the offers.Keys but will fix later
                    continue;
                }
                
                var quantity = quantityOptional.Value;
                var quantityAsInt = (int)quantity;
                
                var offer = offers[product];
                var unitPrice = catalog.GetUnitPrice(product);
                Discount discount = null;
                if (offer.OfferType == SpecialOfferType.TwoForAmount)
                {
                    discount = OfferTypeZForAmountFactory.Create(product, 2, offer.Argument).CalculateDiscount(quantity, unitPrice);
                }

                if (offer.OfferType == SpecialOfferType.ThreeForTwo)
                {
                    discount = OfferTypeZForXFactory.Create(product, 3, 2).CalculateDiscount(quantity, unitPrice);
                }

                if (offer.OfferType == SpecialOfferType.TenPercentDiscount)
                {
                    discount = OfferTypeZPercentDiscount.Create(product, offer.Argument).CalculateDiscount(quantity, unitPrice);
                }
                if (offer.OfferType == SpecialOfferType.FiveForAmount)
                {
                    discount = OfferTypeZForAmountFactory.Create(product, 5, offer.Argument).CalculateDiscount(quantity, unitPrice);
                }

                if (discount != null)
                    receipt.AddDiscount(discount);
            }
            
        }
}
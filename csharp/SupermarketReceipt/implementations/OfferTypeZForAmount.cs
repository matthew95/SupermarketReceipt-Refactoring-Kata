using System;
using SupermarketReceipt.interfaces;

namespace SupermarketReceipt.implementations;

public static class OfferTypeZForAmountFactory
{
    public static IOfferTypeStrategy Create(Product product, int z, double forAmount)
    {
        Discount f(double quantity, double unitPrice)
        {
            // TODO This feels really convoluted but can't think of the better way right now. fix later.
            
            var quantityAsInt = (int)quantity;
            var numberOfYs = quantityAsInt / z;
            
            var discountTotal = unitPrice * quantity - (forAmount * numberOfYs + quantityAsInt % z * unitPrice);
            return new Discount(product, $"{z} for {PricePrinter.Print(forAmount)}", -discountTotal);
        }

        return new OfferTypeStrategy(f);
    }
}
using System;
using SupermarketReceipt.interfaces;

namespace SupermarketReceipt.implementations;

public static class OfferTypeZForXFactory
{
    public static IOfferTypeStrategy Create(Product product, int z, int forY)
    {
        Discount f(double quantity, double unitPrice)
        {
            // TODO This feels really convoluted but can't think of the better way right now.
            // fix later.
            
            var quantityAsInt = (int)quantity;
            var numberOfYs = quantityAsInt / z;
            var discountAmount = quantity * unitPrice - (numberOfYs * forY * unitPrice + quantityAsInt % z * unitPrice);
            return new Discount(product, $"{z} for {forY}", -discountAmount);
        }

        return new OfferTypeStrategy(f);
    }
}
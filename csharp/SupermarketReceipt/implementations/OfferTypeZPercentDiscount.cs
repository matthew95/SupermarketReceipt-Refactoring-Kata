using System;
using SupermarketReceipt.interfaces;

namespace SupermarketReceipt.implementations;

public static class OfferTypeZPercentDiscount
{
    public static IOfferTypeStrategy Create(Product product, double z)
    {
        Discount f(double quantity, double unitPrice)
        {
            // TODO This feels really convoluted but can't think of the better way right now.
            // fix later.
            
            return new Discount(product, $"{z}% off", -quantity * unitPrice * z / 100.0);
        }

        return new OfferTypeStrategy(f);
    }
}
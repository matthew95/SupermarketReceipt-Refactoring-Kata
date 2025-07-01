using System;
using SupermarketReceipt.interfaces;

namespace SupermarketReceipt.implementations;

public static class OfferTypeZForAmountFactory
{
    public static IOfferTypeStrategy Create(Product product, int z, double forAmount)
    {
        Discount f(double quantity, double unitPrice)
        {
            // Okay without this if-statement we got discounts of -0. we can't
            // check for zero (floatValue == 0) at the end of this function (because of floating point representation) and I don't want to look into
            // what threshold I should use to work around this. It's easier to just check this condition: (like the original code did similarly) 
            if (quantity < z)
            {
                return null;
            }
            
            // TODO This feels really convoluted but can't think of the better way right now. fix later.
            
            var quantityAsInt = (int)quantity;
            var numberOfYs = quantityAsInt / z;
            
            var discountTotal = unitPrice * quantity - (forAmount * numberOfYs + quantityAsInt % z * unitPrice);
            return new Discount(product, $"{z} for {PricePrinter.Print(forAmount)}", -discountTotal);
        }

        return new OfferTypeStrategy(f);
    }
}
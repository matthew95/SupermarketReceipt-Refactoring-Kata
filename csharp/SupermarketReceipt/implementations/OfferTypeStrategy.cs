using System;
using SupermarketReceipt.interfaces;

namespace SupermarketReceipt.implementations;

public class OfferTypeStrategy: IOfferTypeStrategy
{
    private readonly Func<double, double, Discount> _f;

    public OfferTypeStrategy(Func<double, double, Discount> discountFunc)
    {
        this._f =  discountFunc;
    }
    
    public Discount CalculateDiscount(double quantity, double unitPrice)
    {
        return this._f(quantity, unitPrice);
    }
}
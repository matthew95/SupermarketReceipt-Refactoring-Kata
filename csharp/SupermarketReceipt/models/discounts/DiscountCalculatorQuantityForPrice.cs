using System.Collections.Generic;

namespace SupermarketReceipt;

public class DiscountCalculatorQuantityForPrice
{
    private readonly ISupermarketCatalog _catalog;
    private readonly Product _product;
    private readonly int _quantity;
    private readonly double _price;

    public DiscountCalculatorQuantityForPrice(Product product, ISupermarketCatalog catalog, Dictionary<Product, Offer> offers, int quantity, double price)
    {
        // base(product, $"{amount} for {price}", );
        this._catalog = catalog;
        this._product = product;
        this._quantity = quantity;
        this._price = price;
    }
    
    // public Discount calculateDiscount()
    // {
    //     
    //     // var discountTotal = unitPrice * quantity - (offer.Argument * numberOfXs + quantity % 5 * unitPrice);
    //     // discount = new Discount(p, x + " for " + PrintPrice(offer.Argument), -discountTotal);
    //     // // return new Discount(_product, _quantity, _price);
    // }
    
    
}
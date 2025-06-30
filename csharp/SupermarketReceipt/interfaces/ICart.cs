using System.Collections.Generic;
using SupermarketReceipt.models;

namespace SupermarketReceipt.interfaces;

public interface ICart
{
    public List<ProductQuantity> GetItems();
    public void AddItem(Product product);
    public void AddItemQuantity(Product product, double quantity);
    public double? GetItemQuantity(Product product);
    // public void HandleOffers(IReceipt receipt, OfferCatalog offers, ISupermarketCatalog catalog);

}
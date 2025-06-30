using System.Collections.Generic;

namespace SupermarketReceipt.interfaces;

public interface ICart
{
    public List<ProductQuantity> GetItems();
    public void AddItem(Product product);
    public void AddItemQuantity(Product product, double quantity);
    public void HandleOffers(IReceipt receipt, Dictionary<Product, Offer> offers, ISupermarketCatalog catalog);
    
}
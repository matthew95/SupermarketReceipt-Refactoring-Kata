using System.Collections.Generic;

namespace SupermarketReceipt.interfaces;

public interface IReceipt
{
    public void AddProduct(Product p, double quantity, double price, double totalPrice);
    public List<ReceiptItem> GetItems();
    public void AddDiscount(Discount discount);
    public List<Discount> GetDiscounts();
    public double GetTotalPrice();
}
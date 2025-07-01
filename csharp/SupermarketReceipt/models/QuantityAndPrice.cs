namespace SupermarketReceipt.models;

public class QuantityAndPrice
{
    public double Quantity { get; set; }
    public double UnitPrice { get; set; }
    
    //will go later
    public Offer Offer { get; set; }
}
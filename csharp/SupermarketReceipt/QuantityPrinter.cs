using System.Globalization;

namespace SupermarketReceipt;

public class QuantityPrinter
{
    private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");
    
    public static string Print(ReceiptItem item)
    {
        return ProductUnit.Each == item.Product.Unit
            ? ((int) item.Quantity).ToString()
            : item.Quantity.ToString("N3", Culture);
    }
}
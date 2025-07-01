using System.Globalization;

namespace SupermarketReceipt;

public class PricePrinter
{
    private static readonly CultureInfo Culture = CultureInfo.CreateSpecificCulture("en-GB");
    
    public static string Print(double price)
    {
        return price.ToString("N2", Culture);
    }
}
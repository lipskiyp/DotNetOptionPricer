using OptionPricer.Instruments.Options;

namespace OptionPricer.Utils.Extensions;

public static class EuropeanSwaptionDisplay
{
    public static void Display(this EuropeanSwaption swaption, double F)
    {
        Console.WriteLine($"Price: {swaption.Pricer.Price(F)}");
    }
}

using OptionPricer.Options.EuropeanSwaptions;

namespace OptionPricer.Extensions.EuropeanSwaptions;

public static class EuropeanSwaptionDisplay
{
    public static void Display(this EuropeanSwaption swaption, double F)
    {
        Console.WriteLine($"Price: {swaption.Price(F)}");
    }
}

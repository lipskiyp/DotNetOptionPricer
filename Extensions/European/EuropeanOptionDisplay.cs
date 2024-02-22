using OptionPricer.Options.European;

namespace OptionPricer.Extensions.European;

public static class EuropeanOptionDisplay
{
    public static void Display(this EuropeanOption option, double S)
    {
        Console.WriteLine($"Price: {option.Price(S)}");
        Console.WriteLine($"Delta: {option.Delta(S)}");
        Console.WriteLine($"Gamma: {option.Gamma(S)}");
        Console.WriteLine($"Vega: {option.Vega(S)}");
    }
}

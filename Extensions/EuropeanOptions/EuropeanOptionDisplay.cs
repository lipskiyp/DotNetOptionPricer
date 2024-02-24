using OptionPricer.Options.EuropeanOptions;

namespace OptionPricer.Extensions.EuropeanOptions;

public static class EuropeanOptionDisplay
{
    public static void Display(this EuropeanOption option, double S)
    {
        // Price
        Console.WriteLine($"Price: {option.Price(S)}");

        // First Order Greeks
        Console.WriteLine($"Delta: {option.Delta(S)}");
        Console.WriteLine($"Vega: {option.Vega(S)}");
        Console.WriteLine($"Rho: {option.Rho(S)}");

        // Second Order Greeks
        Console.WriteLine($"Gamma: {option.Gamma(S)}");
        Console.WriteLine($"Volga: {option.Volga(S)}");
        Console.WriteLine($"Vanna: {option.Vanna(S)}");
    }
}

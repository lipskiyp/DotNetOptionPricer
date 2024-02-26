using OptionPricer.Options.EuropeanOptions;

namespace OptionPricer.Extensions.EuropeanOptions;

public static class EuropeanOptionDisplay
{
    public static void Display(this EuropeanOption option, double S)
    {
        // Price
        Console.WriteLine($"Price: {option.Price(S)}");

        // First Order Greeks
        Console.WriteLine($"Delta: {option.Greeks.Delta(S)}");
        Console.WriteLine($"Vega: {option.Greeks.Vega(S)}");
        Console.WriteLine($"Rho: {option.Greeks.Rho(S)}");

        // Second Order Greeks
        Console.WriteLine($"Gamma: {option.Greeks.Gamma(S)}");
        Console.WriteLine($"Volga: {option.Greeks.Volga(S)}");
        Console.WriteLine($"Vanna: {option.Greeks.Vanna(S)}");
    }
}

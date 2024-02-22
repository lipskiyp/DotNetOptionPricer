namespace OptionPricer.Options.Interfaces;

public interface IEuropeanOption
{
    // Price
    public abstract double Price(double S);

    // Delta
    public abstract double Delta(double S);

    // Gamma
    public abstract double Gamma(double S);

    // Vega
    public abstract double Vega(double S);
}

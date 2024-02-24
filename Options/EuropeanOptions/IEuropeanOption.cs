namespace OptionPricer.Options.EuropeanOptions;

public interface IEuropeanOption
{
    // Price
    public abstract double Price(double S);
}

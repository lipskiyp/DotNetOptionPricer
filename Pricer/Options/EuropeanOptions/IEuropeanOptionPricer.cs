namespace OptionPricer.Pricer.Options;

public interface IEuropeanOptionPricer
{
    // Price
    public abstract double Price(double S);
}

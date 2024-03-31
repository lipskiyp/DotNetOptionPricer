namespace OptionPricer.Pricers.Options;

public interface IEuropeanOptionPricer
{
    // Price
    public abstract double Price(double S);
}

namespace OptionPricer.Pricer.Options;

public interface IEuropeanSwaptionPricer
{
    // Price
    public abstract double Price(double F);
}

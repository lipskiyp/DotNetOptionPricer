namespace OptionPricer.Pricers.Options;

public interface IEuropeanSwaptionPricer
{
    // Price
    public abstract double Price(double F);
}

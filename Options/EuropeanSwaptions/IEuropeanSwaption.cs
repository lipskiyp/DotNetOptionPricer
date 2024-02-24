namespace OptionPricer.Options.EuropeanSwaptions;

public interface IEuropeanSwaption
{
    // Price
    public abstract double Price(double F);
}

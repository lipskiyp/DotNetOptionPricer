namespace OptionPricer.Pricers.Bonds;

public interface IBondPricer
{
    // Dirty Price on date given constant interest rate r
    public double DirtyPrice(DateTime date, double r);

    // Clean Price on date given constant interest rate r
    public double CleanPrice(DateTime date, double r);
}
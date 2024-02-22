namespace OptionPricer.Options.European;

public class EuropeanPutOption : EuropeanOption
{
    // Default constructor
    public EuropeanPutOption() : base()
    {
    }

    // Constructor
    public EuropeanPutOption(double K, double vol, double r, double d, double T) : base(K, vol, r, d, T)
    {
    }

    public double Price(double S)
    {
        return _K * Math.Exp(-_r * _T) * N(-D2(S)) - S * N(-D1(S));
    }

}
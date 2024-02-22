namespace OptionPricer.Options.European;

public class EuropeanCallOption : EuropeanOption
{
    // Default constructor
    public EuropeanCallOption() : base()
    {
    }

    // Constructor
    public EuropeanCallOption(double K, double vol, double r, double d, double T) : base(K, vol, r, d, T)
    {
    }

    // Price
    public override double Price(double S)
    {
        return S * Math.Exp((_d - _r) * _T) * N(D1(S)) - _K * Math.Exp(-_r * _T) * N(D2(S));
    }

    // Delta
    public override double Delta(double S)
    {
        return Math.Exp(_d - _r) * N(D1(S));
    }
}

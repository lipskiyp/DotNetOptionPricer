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
    public double Price(double S)
    {
        return S * Math.Exp((_d - _r) * _T) * N(D1(S)) - _K * Math.Exp(-_r * _T) * N(D2(S));
    }

    // Delta
    public double Delta(double S)
    {
        return Math.Exp(_d - _r) * N(D1(S));
    }

    // Gamma
    public double Gamma(double S)
    {
        return P(D1(S)) * Math.Exp(_d - _r) * _T / (S * _vol * Math.Sqrt(_T));
    }

    // Vega
    public double Vega(double S)
    {
        return S * Math.Sqrt(_T) * Math.Exp((_d - _r) * _T) * P(D1(S));
    }
}
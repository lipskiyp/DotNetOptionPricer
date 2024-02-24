using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanOptions;

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
        return S * Math.Exp((_d - _r) * _T) * NormalDist.N(D1(S)) - _K * Math.Exp(-_r * _T) * NormalDist.N(D2(S));
    }

    // Rho
    public override double Rho(double S)
    {
        return _K * Math.Exp(-_r * _T) * NormalDist.N(D2(S)) * _T;
    }
}

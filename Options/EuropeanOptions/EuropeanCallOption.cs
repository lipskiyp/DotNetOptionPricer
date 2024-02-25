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
        return S * Math.Exp((d - r) * T) * NormalDist.N(D1(S)) - K * Math.Exp(-r * T) * NormalDist.N(D2(S));
    }

    // Rho
    public override double Rho(double S)
    {
        return K * Math.Exp(-r * T) * NormalDist.N(D2(S)) * T;
    }
}

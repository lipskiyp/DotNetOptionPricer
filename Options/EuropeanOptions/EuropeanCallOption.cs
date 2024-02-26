using OptionPricer.Greeks.EuropeanOptionGreeks;
using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanOptions;

public class EuropeanCallOption : EuropeanOption
{
    EuropeanCallOptionGreeks greeks;

    // Greeks
    public override EuropeanCallOptionGreeks Greeks
    {
        get { return greeks; }
    }

    // Default constructor
    public EuropeanCallOption() : this(100, 0.1, 0.05, 0.02, 1)
    {
    }

    // Constructor
    public EuropeanCallOption(double K, double vol, double r, double d, double T) : base(K, vol, r, d, T)
    {
        greeks = new(this);
    }

    // Price
    public override double Price(double S)
    {
        return S * Math.Exp((d - r) * T) * NormalDist.N(D1(S)) - K * Math.Exp(-r * T) * NormalDist.N(D2(S));
    }
}

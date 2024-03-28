using OptionPricer.Greeks.EuropeanOptionGreeks;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Options.EuropeanOptions;

public class EuropeanPutOption : EuropeanOption
{
    EuropeanPutOptionGreeks greeks;

    // Greeks
    public override EuropeanPutOptionGreeks Greeks
    {
        get { return greeks; }
    }

    // Default constructor
    public EuropeanPutOption() : this(100, 0.1, 0.05, 0.02, 1)
    {
    }

    // Constructor
    public EuropeanPutOption(double K, double vol, double r, double d, double T) : base(K, vol, r, d, T)
    {
        greeks = new(this);
    }

    // Price
    public override double Price(double S)
    {
        return K * Math.Exp(-r * T) * NormalDist.N(-D2(S)) - S * NormalDist.N(-D1(S));
    }
}

using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanOptions;

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

    // Price
    public override double Price(double S)
    {
        return K * Math.Exp(-r * T) * NormalDist.N(-D2(S)) - S * NormalDist.N(-D1(S));
    }

    // Delta
    public override double Delta(double S)
    {
        return base.Delta(S) - 1;  // extend base class implementation 
    }

    // Rho
    public override double Rho(double S)
    {
        return K * Math.Exp(-r * T) * NormalDist.N(-D2(S)) * T;
    }
}

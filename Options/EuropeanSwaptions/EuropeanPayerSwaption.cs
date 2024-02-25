using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanSwaptions;

public class EuropeanPayerSwaption : EuropeanSwaption
{
    // Default Constructor 
    public EuropeanPayerSwaption() : base()
    {
    }

    // Constructor 
    public EuropeanPayerSwaption(double K, double vol, double r, double T, double t, int m) : base(K, vol, r, T, t, m)
    {
    }

    public override double Price(double F)
    {
        return alpha(F) * Math.Exp(-r * T) * (F * NormalDist.N(D1(F)) - K * NormalDist.N(D2(F)));
    }
}
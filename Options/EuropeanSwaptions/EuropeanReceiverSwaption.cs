using OptionPricer.Utils.Distributions;

namespace OptionPricer.Options.EuropeanSwaptions;

public class EuropeanReceiverSwaption : EuropeanSwaption
{
    // Default Constructor
    public EuropeanReceiverSwaption() : this(0.1, 0.1, 0.1, 2, 1, 4)
    {
    }

    // Constructor
    protected EuropeanReceiverSwaption(double K, double vol, double r, double T, double t, int m) : base(K, vol, r, T, t, m)
    {
    }

    public override double Price(double F)
    {
        return alpha(F) * Math.Exp(-r * T) * (K * NormalDist.N(-D2(F)) - F * NormalDist.N(D1(F)));
    }
}
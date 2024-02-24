using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanSwaptions;

public class EuropeanReceiverSwaption : EuropeanSwaption
{
    // Default Constructor 
    public EuropeanReceiverSwaption() : base()
    {
    }

    // Constructor 
    protected EuropeanReceiverSwaption(double K, double vol, double r, double T, double t, int m) : base(K, vol, r, T, t, m)
    {
    }

    public override double Price(double F)
    {
        return alpha(F) * Math.Exp(-_r * _T) * (_K * NormalDist.N(-D2(F)) - F * NormalDist.N(D1(F)));
    }
}
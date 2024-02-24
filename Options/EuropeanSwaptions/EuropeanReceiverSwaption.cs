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
        return 2.0;
    }
}
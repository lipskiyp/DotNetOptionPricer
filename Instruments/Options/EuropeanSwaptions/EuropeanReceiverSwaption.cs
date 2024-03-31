using OptionPricer.Pricer.Options;

namespace OptionPricer.Instruments.Options;

public class EuropeanReceiverSwaption : EuropeanSwaption
{
    public EuropeanReceiverSwaptionPricer pricer;

    // Pricer
    public override EuropeanReceiverSwaptionPricer Pricer { 
        get {
            return pricer;
        }
    }

    // Default Constructor
    public EuropeanReceiverSwaption() : this(0.1, 0.1, 0.1, 2, 1, 4)
    {
    }

    // Constructor
    public EuropeanReceiverSwaption(double K, double vol, double r, double T, double t, int m) : base (K, vol, r, T, t, m)
    {
        pricer = new(this);
    }
}
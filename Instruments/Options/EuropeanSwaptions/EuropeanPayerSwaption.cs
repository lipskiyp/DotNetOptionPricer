using OptionPricer.Pricers.Options;

namespace OptionPricer.Instruments.Options;

public class EuropeanPayerSwaption : EuropeanSwaption
{
    public EuropeanPayerSwaptionPricer pricer;

    // Pricer
    public override EuropeanPayerSwaptionPricer Pricer { 
        get {
            return pricer;
        }
    }

    // Default Constructor
    public EuropeanPayerSwaption() : this(0.1, 0.1, 0.1, 2, 1, 4)
    {
    }

    // Constructor
    public EuropeanPayerSwaption(double K, double vol, double r, double T, double t, int m) : base (K, vol, r, T, t, m)
    {
        pricer = new(this);
    }
}
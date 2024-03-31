using OptionPricer.Greeks.Options;
using OptionPricer.Pricers.Options;

namespace OptionPricer.Instruments.Options;

public class EuropeanCallOption : EuropeanOption
{
    EuropeanCallOptionGreeks greeks;
    EuropeanCallOptionPricer pricer;

    // Greeks
    public override EuropeanCallOptionGreeks Greeks { 
        get {
            return greeks;
        }
    }

    // Pricer
    public override EuropeanCallOptionPricer Pricer { 
        get {
            return pricer;
        }
    }

    // Default Constructor
    public EuropeanCallOption() : this(100, 0.1, 0.05, 0.02, 1)
    {
    }

    // Constructor
    public EuropeanCallOption(double K, double vol, double r, double d, double T) : base(K, vol, r, d, T)
    {
        greeks = new(this);
        pricer = new(this);
    }
}
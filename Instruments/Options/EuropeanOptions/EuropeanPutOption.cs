using OptionPricer.Greeks.Options;
using OptionPricer.Pricers.Options;

namespace OptionPricer.Instruments.Options;

public class EuropeanPutOption : EuropeanOption
{
    EuropeanPutOptionGreeks greeks;
    EuropeanPutOptionPricer pricer;

    // Greeks
    public override EuropeanPutOptionGreeks Greeks { 
        get {
            return greeks;
        }
    }

    // Pricer
    public override EuropeanPutOptionPricer Pricer { 
        get {
            return pricer;
        }
    }

    // Default Constructor
    public EuropeanPutOption() : this(100, 0.1, 0.05, 0.02, 1)
    {
    }

    // Constructor
    public EuropeanPutOption(double K, double vol, double r, double d, double T) : base(K, vol, r, d, T)
    {
        greeks = new(this);
        pricer = new(this);
    }
}
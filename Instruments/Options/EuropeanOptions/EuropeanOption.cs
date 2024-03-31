using OptionPricer.Greeks.Options;
using OptionPricer.Pricer.Options;

namespace OptionPricer.Instruments.Options;

public abstract class EuropeanOption
{
    public double K;  // Strike price
    public double vol;  // Volatility
    public double r;  // Interest rate
    public double d;  // Cost of carry
    public double T;  // Expiry date

    // Greeks
    public abstract EuropeanOptionGreeks Greeks { get; }

    // Pricer
    public abstract EuropeanOptionPricer Pricer { get; }

    // Constructor
    protected EuropeanOption(double K, double vol, double r, double d, double T)
    {
        this.K = K; this.vol = vol; this.r = r; this.d = d; this.T = T;
    }
}
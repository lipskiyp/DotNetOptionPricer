using OptionPricer.Pricers.Options;

namespace OptionPricer.Instruments.Options;

public abstract class EuropeanSwaption 
{
    public double K;  // Strike swap rate
    public double vol;  // Forward swap rate volatility
    public double r;  // Interest rate
    public double T;  // Swaption expiry date
    public double t;  // Swap tenor
    public int m;  // Compoundings per year

    // Pricer
    public abstract EuropeanSwaptionPricer Pricer { get; }

    // Constructor
    protected EuropeanSwaption(double K, double vol, double r, double T, double t, int m)
    {
        this.K = K; this.vol = vol; this.r = r; this.T = T; this.t = t; this.m = m;
    }
}
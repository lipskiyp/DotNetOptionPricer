using OptionPricer.Greeks.EuropeanOptionGreeks;

namespace OptionPricer.Options.EuropeanOptions;

abstract public class EuropeanOption : IEuropeanOption
{
    public double K;  // Strike price
    public double vol;  // Volatility
    public double r;  // Interest rate
    public double d;  // Cost of carry
    public double T;  // Expiry date

    // Greeks
    public abstract EuropeanOptionGreeks Greeks { get; }

    // Constructor
    protected EuropeanOption(double K, double vol, double r, double d, double T)
    {
        this.K = K; this.vol = vol; this.r = r; this.d = d; this.T = T;
    }

    // Price
    public abstract double Price(double S);

    public double D1(double S)
    {
        var tmp = Math.Log(S / K) + (d + vol * vol / 2) / T;
        return tmp / (vol * Math.Sqrt(T));
    }

    public double D2(double S)
    {
        return D1(S) - vol * Math.Sqrt(T);
    }
}

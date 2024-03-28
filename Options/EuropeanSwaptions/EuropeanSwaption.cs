using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanSwaptions;

public abstract class EuropeanSwaption : IEuropeanSwaption
{
    public double K;  // Strike swap rate
    public double vol;  // Forward swap rate volatility
    public double r;  // Interest rate
    public double T;  // Swaption expiry date
    public double t;  // Swap tenor
    public int m;  // Compoundings per year

    // Constructor
    protected EuropeanSwaption(double K, double vol, double r, double T, double t, int m)
    {
        this.K = K; this.vol = vol; this.r = r; this.T = T; this.t = t; this.m = m;
    }

    // Price
    public abstract double Price(double F);

    protected double D1(double F)
    {
        var tmp = Math.Log(F / K) + vol * vol * T / 2;
        return tmp / (vol * Math.Sqrt(T));
    }

    protected double D2(double F)
    {
        return D1(F) - vol * Math.Sqrt(T);
    }

    protected double alpha(double F)
    {
        var tmp = 1 / Math.Pow(1 + (F / m), t * m);
        return (1 - tmp) / F;
    }
}
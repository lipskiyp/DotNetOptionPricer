using OptionPricer.Options.Greeks;
using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanOptions;

abstract public class EuropeanOption : IEuropeanOption, IGreeksFirstOrder, IGreeksSecondOrder
{
    public double K;  // Strike price
    public double vol;  // Volatility
    public double r;  // Interest rate
    public double d;  // Cost of carry
    public double T;  // Expiry date

    // Default Constructor
    protected EuropeanOption() : this(100, 0.1, 0.05, 0.02, 1)
    {
    }

    // Constructor
    protected EuropeanOption(double K, double vol, double r, double d, double T)
    {
        this.K = K; this.vol = vol; this.r = r; this.d = d; this.T = T;
    }

    protected double D1(double S)
    {
        var tmp = Math.Log(S / K) + (d + vol * vol / 2) / T;
        return tmp / (vol * Math.Sqrt(T));
    }

    protected double D2(double S)
    {
        return D1(S) - vol * Math.Sqrt(T);
    }

    // Price
    public abstract double Price(double S);

    // Delta
    public virtual double Delta(double S)
    {
        return Math.Exp(d - r) * NormalDist.N(D1(S));
    }

    // Rho
    public abstract double Rho(double S);

    // Vega
    public virtual double Vega(double S)
    {
        return S * Math.Sqrt(T) * Math.Exp((d - r) * T) * NormalDist.P(D1(S));
    }

    // Gamma
    public virtual double Gamma(double S)
    {
        return NormalDist.P(D1(S)) * Math.Exp(d - r) * T / (S * vol * Math.Sqrt(T));
    }

    // Volga
    public virtual double Volga(double S)
    {
        return S * Math.Sqrt(T) * Math.Exp((d - r) * T) * NormalDist.P(D1(S)) * D1(S) * D2(S) / vol;
    }

    // Vanna
    public virtual double Vanna(double S)
    {
        return NormalDist.P(D1(S)) * Math.Exp((d - r) * T) * D2(S) / vol;
    }
}

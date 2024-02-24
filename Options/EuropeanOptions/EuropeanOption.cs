using OptionPricer.Options.Interfaces;
using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanOptions;

abstract public class EuropeanOption : IEuropeanOption, IGreeksFirstOrder, IGreeksSecondOrder
{
    protected double _K;  // Strike price
    protected double _vol;  // Volatility
    protected double _r;  // Interest rate
    protected double _d;  // Cost of carry
    protected double _T;  // Expiry date

    // Default Constructor
    protected EuropeanOption()
    {
        _K = 100; _vol = 0.1; _r = 0.05; _d = 0.02; _T = 1;
    }

    // Constructor
    protected EuropeanOption(double K, double vol, double r, double d, double T)
    {
        _K = K; _vol = vol; _r = r; _d = d; _T = T;
    }

    protected double D1(double S)
    {
        var tmp = Math.Log(S / _K) + (_d + _vol * _vol / 2) / _T;
        return tmp / (_vol * Math.Sqrt(_T));
    }

    protected double D2(double S)
    {
        return D1(S) - _vol * Math.Sqrt(_T);
    }

    // Price
    public abstract double Price(double S);

    // Delta
    public virtual double Delta(double S)
    {
        return Math.Exp(_d - _r) * NormalDist.N(D1(S));
    }

    // Rho
    public abstract double Rho(double S);

    // Vega
    public virtual double Vega(double S)
    {
        return S * Math.Sqrt(_T) * Math.Exp((_d - _r) * _T) * NormalDist.P(D1(S));
    }

    // Gamma
    public virtual double Gamma(double S)
    {
        return NormalDist.P(D1(S)) * Math.Exp(_d - _r) * _T / (S * _vol * Math.Sqrt(_T));
    }

    // Volga
    public virtual double Volga(double S)
    {
        return S * Math.Sqrt(_T) * Math.Exp((_d - _r) * _T) * NormalDist.P(D1(S)) * D1(S) * D2(S) / _vol;
    }

    // Vanna
    public virtual double Vanna(double S)
    {
        return NormalDist.P(D1(S)) * Math.Exp((_d - _r) * _T) * D2(S) / _vol;
    }
}

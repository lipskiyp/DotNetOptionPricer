using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanSwaptions;

public abstract class EuropeanSwaption : IEuropeanSwaption
{
    protected double _K;  // Strike swap rate
    protected double _vol;  // Forward swap rate volatility
    protected double _r;  // Interest rate
    protected double _T;  // Swaption expiry date
    protected double _t;  // Swap tenor
    protected int _m;  // Compoundings per year

    // Default Constructor 
    protected EuropeanSwaption()
    {
        _K = 0.1; _vol = 0.1; _r = 0.1; _T = 2; _t = 1; _m = 4;
    }

    // Constructor 
    protected EuropeanSwaption(double K, double vol, double r, double T, double t, int m)
    {
        _K = K; _vol = vol; _r = r; _T = T; _t = t; _m = m;
    }

    // Price
    public abstract double Price(double F);

    protected double D1(double F)
    {
        var tmp = Math.Log(F / _K) + _vol * _vol * _T / 2;
        return tmp / (_vol * Math.Sqrt(_T));
    }

    protected double D2(double F)
    {
        return D1(F) - _vol * Math.Sqrt(_T);
    }

    protected double alpha(double F)
    {
        var tmp = 1 / Math.Pow(1 + (F / _m), _t * _m);
        return (1 - tmp) / F;
    }
}
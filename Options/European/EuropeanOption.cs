namespace OptionPricer.Options.European;

abstract public class EuropeanOption
{
    protected double _K;  // Strike price
    protected double _vol;  // Volatility
    protected double _r;  // Interest rate
    protected double _d;  // Cost of carry
    protected double _T;  // Expiry date

    protected MathNet.Numerics.Distributions.Normal distribution;

    // Default Constructor
    protected EuropeanOption()
    {
        distribution = new MathNet.Numerics.Distributions.Normal();
        _K = 100;
        _vol = 0.1;
        _r = 0.05;
        _d = 0.02;
        _T = 1;
    }

    // Constructor
    protected EuropeanOption(double K, double vol, double r, double d, double T)  // : this()
    {
        distribution = new MathNet.Numerics.Distributions.Normal();
        _K = K;
        _vol = vol;
        _r = r;
        _d = d;
        _T = T;
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

    // Gaussian probability density
    protected double n(double x)
    {
        return distribution.Density(x);
    }

    // Cumulative Gaussian distribution
    protected double N(double x)
    {
        return distribution.CumulativeDistribution(x);
    }
}

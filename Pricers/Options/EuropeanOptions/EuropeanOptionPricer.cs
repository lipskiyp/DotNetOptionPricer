using OptionPricer.Instruments.Options;

namespace OptionPricer.Pricers.Options;

abstract public class EuropeanOptionPricer : IEuropeanOptionPricer
{
    public EuropeanOption option;

    // Constructor
    protected EuropeanOptionPricer(EuropeanOption option)
    {
        this.option = option;
    }

    // Price
    public abstract double Price(double S);

    public double D1(double S)
    {
        var tmp = Math.Log(S / option.K) + (option.d + option.vol * option.vol / 2) / option.T;
        return tmp / (option.vol * Math.Sqrt(option.T));
    }

    public double D2(double S)
    {
        return D1(S) - option.vol * Math.Sqrt(option.T);
    }
}

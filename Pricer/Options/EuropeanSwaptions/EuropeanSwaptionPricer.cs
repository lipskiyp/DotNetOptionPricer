using OptionPricer.Instruments.Options;

namespace OptionPricer.Pricer.Options;

public abstract class EuropeanSwaptionPricer : IEuropeanSwaptionPricer
{
    public EuropeanSwaption swaption;

    // Constructor
    protected EuropeanSwaptionPricer(EuropeanSwaption swaption)
    {
        this.swaption = swaption;
    }

    // Price
    public abstract double Price(double F);

    protected double D1(double F)
    {
        var tmp = Math.Log(F / swaption.K) + swaption.vol * swaption.vol * swaption.T / 2;
        return tmp / (swaption.vol * Math.Sqrt(swaption.T));
    }

    protected double D2(double F)
    {
        return D1(F) - swaption.vol * Math.Sqrt(swaption.T);
    }

    protected double alpha(double F)
    {
        var tmp = 1 / Math.Pow(1 + (F / swaption.m), swaption.t * swaption.m);
        return (1 - tmp) / F;
    }
}
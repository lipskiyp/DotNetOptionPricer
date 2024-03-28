using OptionPricer.Options.EuropeanOptions;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Greeks.EuropeanOptionGreeks;

public abstract class EuropeanOptionGreeks : IEuropeanOptionGreeks
{
    public EuropeanOption option;

    public EuropeanOptionGreeks(EuropeanOption option)
    {
        this.option = option;
    }

    // Delta
    public virtual double Delta(double S)
    {
        return Math.Exp(option.d - option.r) * NormalDist.N(option.D1(S));
    }

    // Rho
    public virtual double Rho(double S)
    {
        return option.K * Math.Exp(-option.r * option.T) * NormalDist.N(option.D2(S)) * option.T;
    }

    // Vega
    public double Vega(double S)
    {
        return S * Math.Sqrt(option.T) * Math.Exp((option.d - option.r) * option.T) * NormalDist.P(option.D1(S));
    }

    // Gamma
    public virtual double Gamma(double S)
    {
        return NormalDist.P(option.D1(S)) * Math.Exp(option.d - option.r) * option.T / (S * option.vol * Math.Sqrt(option.T));
    }

    // Volga
    public virtual double Volga(double S)
    {
        return S * Math.Sqrt(option.T) * Math.Exp((option.d - option.r) * option.T) * NormalDist.P(option.D1(S)) * option.D1(S) * option.D2(S) / option.vol;
    }

    // Vanna
    public virtual double Vanna(double S)
    {
        return NormalDist.P(option.D1(S)) * Math.Exp((option.d - option.r) * option.T) * option.D2(S) / option.vol;
    }
}
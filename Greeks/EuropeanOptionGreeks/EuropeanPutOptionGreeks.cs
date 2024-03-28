using OptionPricer.Options.EuropeanOptions;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Greeks.EuropeanOptionGreeks;

public class EuropeanPutOptionGreeks : EuropeanOptionGreeks
{
    public EuropeanPutOptionGreeks(EuropeanPutOption option) : base(option)
    {
    }

    // Delta
    public override double Delta(double S)
    {
        return Math.Exp(option.d - option.r) * NormalDist.N(option.D1(S)) - 1;
    }

    // Rho
    public override double Rho(double S)
    {
        return option.K * Math.Exp(-option.r * option.T) * NormalDist.N(-option.D2(S)) * option.T;
    }
}

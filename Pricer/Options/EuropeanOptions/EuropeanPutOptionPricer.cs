using OptionPricer.Instruments.Options;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Pricer.Options;

public class EuropeanPutOptionPricer : EuropeanOptionPricer
{
    // Constructor
    public EuropeanPutOptionPricer(EuropeanPutOption option) : base(option)
    {
    }

    // Price
    public override double Price(double S)
    {
        return option.K * Math.Exp(-option.r * option.T) * NormalDist.N(-D2(S)) - S * NormalDist.N(-D1(S));
    }
}

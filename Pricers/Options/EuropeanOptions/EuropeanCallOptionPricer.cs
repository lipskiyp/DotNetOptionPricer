using OptionPricer.Instruments.Options;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Pricers.Options;

public class EuropeanCallOptionPricer : EuropeanOptionPricer
{
    // Constructor
    public EuropeanCallOptionPricer(EuropeanCallOption option) : base(option)
    {
    }

    // Price
    public override double Price(double S)
    {
        return S * Math.Exp((option.d - option.r) * option.T) * NormalDist.N(D1(S)) - option.K * Math.Exp(-option.r * option.T) * NormalDist.N(D2(S));
    }
}

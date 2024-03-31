using OptionPricer.Instruments.Options;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Pricers.Options;

public class EuropeanPayerSwaptionPricer : EuropeanSwaptionPricer
{
    // Constructor
    public EuropeanPayerSwaptionPricer(EuropeanPayerSwaption swaption) : base(swaption)
    {
    }

    public override double Price(double F)
    {
        return alpha(F) * Math.Exp(-swaption.r * swaption.T) * (F * NormalDist.N(D1(F)) - swaption.K * NormalDist.N(D2(F)));
    }
}
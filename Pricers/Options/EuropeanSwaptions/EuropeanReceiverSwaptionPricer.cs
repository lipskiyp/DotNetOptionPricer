using OptionPricer.Instruments.Options;
using OptionPricer.Utils.Distributions;

namespace OptionPricer.Pricers.Options;

public class EuropeanReceiverSwaptionPricer : EuropeanSwaptionPricer
{
    // Constructor
    public EuropeanReceiverSwaptionPricer(EuropeanReceiverSwaption swaption) : base(swaption)
    {
    }

    public override double Price(double F)
    {
        return alpha(F) * Math.Exp(-swaption.r * swaption.T) * (swaption.K * NormalDist.N(-D2(F)) - F * NormalDist.N(D1(F)));
    }
}
using OptionPricer.Bonds.VasicekBond;

namespace OptionPricer.Options.VasicekBondOptions;

public class VasicekBondCallOption : VasicekBondOption
{
    public VasicekBondCallOption() : base()
    {
    }

    public VasicekBondCallOption(double t, double s, double T, double K) : base(t, s, T, K)
    {
    }

    // Option Price
    public override double Price(VasicekBond model)
    {
        throw new NotImplementedException();
    }
}

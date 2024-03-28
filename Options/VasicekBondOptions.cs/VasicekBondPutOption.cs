using OptionPricer.Bonds.VasicekBond;

namespace OptionPricer.Options.VasicekBondOptions;

public class VasicekBondPutOption : VasicekBondOption
{
    public VasicekBondPutOption() : base()
    {
    }

    public VasicekBondPutOption(double t, double s, double T, double K) : base(t, s, T, K)
    {
    }

    // Option Price
    public override double Price(VasicekBond model)
    {
        return 0;
    }
}

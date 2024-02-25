using OptionPricer.Bonds.PureDiscountBonds;

namespace OptionPricer.Options.PureDiscountBondOptions;

public class PureDiscountBondPutOption : PureDiscountBondOption
{
    public PureDiscountBondPutOption() : base()
    {
    }

    public PureDiscountBondPutOption(double t, double s, double T, double K) : base(t, s, T, K)
    {
    }

    // Option Price
    public override double Price(VasicekModel model)
    {
        return 0;
    }
}

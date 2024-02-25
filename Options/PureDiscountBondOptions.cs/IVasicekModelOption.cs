using OptionPricer.Bonds.PureDiscountBonds;

namespace OptionPricer.Options.PureDiscountBondOptions;

public interface IVasicekModelOption
{
    // Option Price
    public abstract double Price(VasicekModel model);
}

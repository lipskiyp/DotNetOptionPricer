using OptionPricer.Pricers.Bonds;

namespace OptionPricer.Instruments.Bonds;

public interface IPureDiscountBond
{
    public abstract PureDiscountBondPricer Pricer { get; }
}
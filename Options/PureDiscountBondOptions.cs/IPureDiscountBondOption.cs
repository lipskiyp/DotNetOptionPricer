using OptionPricer.Bonds.PureDiscountBonds;

namespace OptionPricer.Options.PureDiscountBondOptions;

public interface IPureDiscountBondOption
{
    // Vasicek model option Price
    public abstract double Price(VasicekModel model);
}

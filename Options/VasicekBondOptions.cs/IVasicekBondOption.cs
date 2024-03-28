using OptionPricer.Bonds.VasicekBond;

namespace OptionPricer.Options.VasicekBondOptions;

public interface IVasicekBondOption
{
    // Vasicek model option Price
    public abstract double Price(VasicekBond model);
}

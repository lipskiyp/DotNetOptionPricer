using OptionPricer.Pricers.Bonds;

namespace OptionPricer.Instruments.Bonds;

public interface IVasicekBond
{
    public abstract VasicekBondPricer Pricer { get; }
}
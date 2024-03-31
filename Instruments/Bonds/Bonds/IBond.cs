using OptionPricer.Pricers.Bonds;
using OptionPricer.Utils.Dates;

namespace OptionPricer.Instruments.Bonds;

public interface IBond
{
    public abstract BondPricer Pricer { get; } 
}
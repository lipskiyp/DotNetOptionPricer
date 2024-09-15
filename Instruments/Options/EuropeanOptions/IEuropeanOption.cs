using OptionPricer.Greeks.Options;
using OptionPricer.Pricers.Options;

namespace OptionPricer.Instruments.Options;

public interface IEuropeanOption
{
    // Greeks
    public abstract EuropeanOptionGreeks Greeks { get; }

    // Pricer
    public abstract EuropeanOptionPricer Pricer { get; }
}

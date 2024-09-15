using OptionPricer.Pricers.Options;

namespace OptionPricer.Instruments.Options;

public interface IEuropeanSwaption
{
    public abstract EuropeanSwaptionPricer Pricer { get; }
}

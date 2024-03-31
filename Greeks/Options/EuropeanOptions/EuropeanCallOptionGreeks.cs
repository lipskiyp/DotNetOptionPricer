using OptionPricer.Instruments.Options;

namespace OptionPricer.Greeks.Options;

public class EuropeanCallOptionGreeks : EuropeanOptionGreeks
{
    public EuropeanCallOptionGreeks(EuropeanCallOption option) : base(option)
    {
    }
}

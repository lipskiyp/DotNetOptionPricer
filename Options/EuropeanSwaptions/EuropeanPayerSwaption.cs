using OptionPricer.Utils;

namespace OptionPricer.Options.EuropeanSwaptions;

public class EuropeanPayerSwaption : EuropeanSwaption
{
    // Default Constructor 
    public EuropeanPayerSwaption() : base()
    {
    }

    // Constructor 
    protected EuropeanPayerSwaption(double K, double vol, double r, double T, double t, int m) : base(K, vol, r, T, t, m)
    {
    }

    public override double Price(double F)
    {
        return 2.0;
    }
}
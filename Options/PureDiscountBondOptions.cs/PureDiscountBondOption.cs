using OptionPricer.Bonds.PureDiscountBonds;

namespace OptionPricer.Options.PureDiscountBondOptions;

public abstract class PureDiscountBondOption : IVasicekModelOption
{
    public double t;  // Time
    public double s;  // PDB maturity date
    public double T;  // Option expiry date
    public double K;  // Option strike price 

    // Default Constructor 
    protected PureDiscountBondOption() : this(0.5, 2, 1, 0.8)
    {
    }

    // Constructor
    protected PureDiscountBondOption(double t, double s, double T, double K) : base()
    {
        this.t = t; this.s = s; this.T = T; this.K = K;
    }

    // Option Price
    public abstract double Price(VasicekModel model);
}

using OptionPricer.Bonds.VasicekBond;

namespace OptionPricer.Options.VasicekBondOptions;

public abstract class VasicekBondOption : IVasicekBondOption
{
    public double t;  // Time
    public double s;  // PDB maturity date
    public double T;  // Option expiry date
    public double K;  // Option strike price

    // Default Constructor
    protected VasicekBondOption() : this(0.5, 2, 1, 0.8)
    {
    }

    // Constructor
    protected VasicekBondOption(double t, double s, double T, double K) : base()
    {
        this.t = t; this.s = s; this.T = T; this.K = K;
    }

    // Option Price
    public abstract double Price(VasicekBond model);
}

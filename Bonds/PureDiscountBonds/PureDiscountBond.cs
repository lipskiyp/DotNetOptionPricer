using OptionPricer.Options.PureDiscountBondOptions;

namespace OptionPricer.Bonds.PureDiscountBonds;

public abstract class PureDiscountBond
{
    public double k;  // Speed of adjustment
    public double u;  // Long-term rate
    public double vol;  // Short rate volatility 
    public double r;  // Short rate

    // Default Constructor
    protected PureDiscountBond() : this(0.25, 0.1, 0.1, 0.1)
    {
    }

    // Constructor
    protected PureDiscountBond(double k, double u, double vol, double r)
    {
        this.k = k; this.u = u; this.vol = vol; this.r = r;
    }

    // PDB price at time t for PDB with maturity at time s (t<=s)
    public abstract double P(double t, double s);

    // Spot rate at time t for PDB with maturity at time s (t<=s)
    public abstract double RSpot(double t, double s);

    // Spot rate volatility 
    public abstract double RVol(double t, double s);
}

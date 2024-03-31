using OptionPricer.Pricer.Bonds;

namespace OptionPricer.Instruments.Bonds;

public class VasicekBond
{
    public double k;  // Speed of adjustment
    public double u;  // Long-term rate
    public double vol;  // Short rate volatility
    public double r;  // Short rate
    public double R => vol - 1/2 * vol * vol / (k * k);

    public VasicekBondPricer pricer;

    // Pricer
    public VasicekBondPricer Pricer { 
        get {
            return pricer;
        }
    }

    // Default Constructor
    public VasicekBond() : this(0.25, 0.1, 0.1, 0.1)
    {
    }

    // Constructor
    public VasicekBond(double k, double u, double vol, double r)
    {
        this.k = k; this.u = u; this.vol = vol; this.r = r;
        this.pricer = new(this);
    }
}
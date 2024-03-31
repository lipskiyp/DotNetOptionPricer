using OptionPricer.Pricers.Bonds;

namespace OptionPricer.Instruments.Bonds;

public class PureDiscountBond
{
    public double coupon;  // coupon amount
    public double principle;  // principle amount
    public double n;  // number of periods
    public double m;  // number of coupons per period

    public PureDiscountBondPricer pricer;

    // Pricer
    public PureDiscountBondPricer Pricer { 
        get {
            return pricer;
        }
    }

    // Default Constructor
    public PureDiscountBond() : this(1000, 50, 1)
    {
    }

    // Constructor
    public PureDiscountBond(double coupon, double principle, double n, double m = 1)
    {
        this.coupon = coupon; this.principle = principle; this.n = n; this.m = m;
        this.pricer = new(this);
    }
}
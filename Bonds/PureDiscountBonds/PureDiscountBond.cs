using OptionPricer.Utils.Discounting;

namespace OptionPricer.Bonds.PureDiscountBonds;

public class PureDiscountBond : IPureDiscountBond
{
    public double coupon;  // coupon amount
    public double principle;  // principle amount
    public double n;  // number of periods
    public double m;  // number of coupons per period

    // Default Constructor
    protected PureDiscountBond() : this(1000, 50, 1)
    {
    }

    // Constructor
    protected PureDiscountBond(double coupon, double principle, double n, double m = 1)
    {
        this.coupon = coupon; this.principle = principle; this.n = n; this.m = m;
    }

    // Bond present value given some discount rate r
    public double P(double r)
    {
        double principlePV = InterestRateCalculator.PresentValue(principle, r, n, 1);
        double couponsPV = InterestRateCalculator.PresentValueAnnuity(coupon, r, n, m);
        return principlePV + couponsPV;
    }
}

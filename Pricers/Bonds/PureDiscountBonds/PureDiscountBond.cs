using OptionPricer.Instruments.Bonds;
using OptionPricer.Utils.Discounting;

namespace OptionPricer.Pricers.Bonds;

public class PureDiscountBondPricer : IPureDiscountBondPricer
{
    public PureDiscountBond bond;

    // Constructor
    public PureDiscountBondPricer(PureDiscountBond bond)
    {
        this.bond = bond;
    }

    // Bond present value given some discount rate r
    public double P(double r)
    {
        double principlePV = InterestRateCalculator.PresentValue(bond.principle, r, bond.n, 1);
        double couponsPV = InterestRateCalculator.PresentValueAnnuity(bond.coupon, r, bond.n, bond.m);
        return principlePV + couponsPV;
    }
}

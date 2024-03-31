using OptionPricer.Instruments.Bonds;
using OptionPricer.Utils.Discounting;

namespace OptionPricer.Pricers.Bonds;

public class BondPricer : IBondPricer
{
    public Bond bond;

    public BondPricer(Bond bond)
    {
        this.bond = bond;
    }

    public double DirtyPrice(DateTime date, double r)
    {
        throw new NotImplementedException();
    }
    
    public double CleanPrice(DateTime date, double r)
    {
        double principlePV = InterestRateCalculator.PresentValue(
            bond.principle, r, bond.yearFraction(date, bond.endDate)
        );

        double couponsPV = 0;
        foreach (DateTime[] period in bond.scheduler.GenerateShortSchedule())
        {
            if (period[1] > date)
            {
                double dyf = bond.yearFraction(date, period[1]);
                couponsPV += InterestRateCalculator.PresentValue(
                    bond.coupon * bond.principle, r, dyf
                );
            }
        }

        return couponsPV + principlePV;
    }
}
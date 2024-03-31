using OptionPricer.Pricers.Bonds;
using OptionPricer.Utils.Dates;

namespace OptionPricer.Instruments.Bonds;

public class Bond : IBond
{
    public DateTime startDate;
    public DateTime endDate;
    public double coupon;  // coupon as a fraction of principle 
    public double principle;
    public YearFraction yearFraction;

    public BondPricer pricer;
    public DateScheduler scheduler;

    public BondPricer Pricer {
        get { return pricer; }
    }

    public DateScheduler Scheduler {
        get { return scheduler; }
    }

    public Bond(DateTime startDate, DateTime endDate, double coupon, double principle, int businessDateOffset = -1,
       YearFraction? yearFraction = null, ScheduleFrequency couponFrequency = ScheduleFrequency.Quarterly)
    {
        this.startDate = startDate; this.endDate = endDate; this.coupon = coupon; this.principle = principle;
        this.yearFraction = yearFraction != null ? yearFraction : DateYearFraction.YearFractionActAct;  // default value 
        pricer = new(this);
        scheduler = new(startDate, endDate, couponFrequency, 
            matchEndDate: true, businessDateOffset: businessDateOffset);
    }
}
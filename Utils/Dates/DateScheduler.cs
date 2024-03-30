namespace OptionPricer.Utils.Dates;

public enum ScheduleFrequency 
{
    Weekly, Biweekly, Monthly, Quarterly, Semiannual, Annual
}

public class DateScheduler
{
    public ScheduleFrequency scheduleFrequency;
    public int fixingDateOffset;  
    public int paymentDateOffset;

    public DateScheduler(ScheduleFrequency scheduleFrequency, int fixingDateOffset = 0, int paymentDateOffset = 0)
    {
        this.scheduleFrequency = scheduleFrequency; this.fixingDateOffset = fixingDateOffset; this.paymentDateOffset = paymentDateOffset;
    }

    private bool IsBusinessDay(DateTime date)
    {
        return date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Saturday;
    }

    private DateTime NextDate(DateTime date)
    {
        switch (scheduleFrequency)
        {
            case ScheduleFrequency.Weekly:
                return date.AddDays(7);

            case ScheduleFrequency.Biweekly:
                return date.AddDays(14);

            case ScheduleFrequency.Monthly:
                return date.AddMonths(1);

            case ScheduleFrequency.Quarterly:
                return date.AddMonths(3);

            case ScheduleFrequency.Semiannual:
                return date.AddMonths(6);

            case ScheduleFrequency.Annual:
                return date.AddYears(1);

            default:
                throw new NotImplementedException();
        }
    }

}
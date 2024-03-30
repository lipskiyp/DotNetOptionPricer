namespace OptionPricer.Utils.Dates;

public enum ScheduleFrequency 
{
    Weekly, Biweekly, Monthly, Quarterly, Semiannual, Annual
}

public class DateScheduler
{
    public DateTime startDate; 
    public DateTime endDate;
    public ScheduleFrequency scheduleFrequency;
    public int fixingDateOffset;  
    public int paymentDateOffset;

    public DateScheduler(DateTime startDate, DateTime endDate, ScheduleFrequency scheduleFrequency, int fixingDateOffset = 0, int paymentDateOffset = 0)
    {
        this.startDate = startDate; this.endDate = endDate;
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

    private int CountPeriods()
    {
        switch (scheduleFrequency)
        {
            case ScheduleFrequency.Weekly:
                return (endDate - startDate).Days / 7 + 1;

            case ScheduleFrequency.Biweekly:
                return (endDate - startDate).Days / 14 + 1;

            case ScheduleFrequency.Monthly:
                return (endDate.Year - startDate.Year) * 12 + (endDate.Month - startDate.Month) + 1;

            case ScheduleFrequency.Quarterly:
                return (endDate.Year - startDate.Year) * 4 + (endDate.Month - startDate.Month) / 4 + 1;

            case ScheduleFrequency.Semiannual:
                return (endDate.Year - startDate.Year) * 2 + (endDate.Month - startDate.Month) / 2 + 1;

            case ScheduleFrequency.Annual:
                return endDate.Year - startDate.Year + 1;

            default:
                throw new NotImplementedException();
        } 
    }

    public DateTime[][] GenerateSchedule()
    {
        int nperiods = CountPeriods();
        DateTime[][] schedule = new DateTime[nperiods][];

        DateTime currentDate = startDate;
        DateTime nextDate = NextDate(currentDate);
        for (int period = 0; period < nperiods; period++)
        {
            schedule[period] = [
                currentDate.AddDays(fixingDateOffset),  // fixing date 
                currentDate,  // period start date
                nextDate,  // period end date
                nextDate.AddDays(paymentDateOffset)  // payment date
            ];
            currentDate = nextDate;
            nextDate = NextDate(currentDate);
        }
        return schedule;
    }
    

}
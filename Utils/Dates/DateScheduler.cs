namespace OptionPricer.Utils.Dates;

public enum ScheduleFrequency 
{
    Weekly, Biweekly, Monthly, Quarterly, Semiannual, Annual
}

public class DateScheduler
{
    public DateTime startDate;  // Schedule Start Date 
    public DateTime endDate;  // Schedule End Date 
    public ScheduleFrequency scheduleFrequency;  // Schedule frequency 
    public bool matchEndDate; // Use endDate as period End Date for last period irrespective of scheduleFrequency. 

    public int fixingDateOffset;  // Fixing Date offset relative to period Start Date 
    public int paymentDateOffset;  // Payment Date offset relative to period End Date 
    public int businessDateOffset;  // Date offset if it is not a business date 

    // Constructor 
    public DateScheduler(DateTime startDate, DateTime endDate, ScheduleFrequency scheduleFrequency, bool matchEndDate = true,
        int fixingDateOffset = 0, int paymentDateOffset = 0, int businessDateOffset = 0)
    {
        this.startDate = startDate; this.endDate = endDate; this.scheduleFrequency = scheduleFrequency; this.matchEndDate = matchEndDate;
        this.fixingDateOffset = fixingDateOffset; this.paymentDateOffset = paymentDateOffset; this.businessDateOffset = businessDateOffset;
    }

    // Returns true if date is business date 
    private bool IsBusinessDay(DateTime date)
    {
        return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Saturday;
    }

    private DateTime NextDate(DateTime date)
    {
        return ScrollDate(date, 1);
    }

    private DateTime PreviousDate(DateTime date)
    {
        return ScrollDate(date, -1);
    }

    // Scroll through dates 
    private DateTime ScrollDate(DateTime date, int direction)
    {
        switch (scheduleFrequency)
        {
            case ScheduleFrequency.Weekly:
                return date.AddDays(7 * direction);

            case ScheduleFrequency.Biweekly:
                return date.AddDays(14 * direction);

            case ScheduleFrequency.Monthly:
                return date.AddMonths(1 * direction);

            case ScheduleFrequency.Quarterly:
                return date.AddMonths(3 * direction);

            case ScheduleFrequency.Semiannual:
                return date.AddMonths(6 * direction);

            case ScheduleFrequency.Annual:
                return date.AddYears(1 * direction);

            default:
                throw new NotImplementedException();
        }
    }

    // Count number of scheduled periods
    private int CountPeriods()
    {
        switch (scheduleFrequency)
        {
            case ScheduleFrequency.Weekly:
                return (endDate - startDate).Days / 7;

            case ScheduleFrequency.Biweekly:
                return (endDate - startDate).Days / 14;

            case ScheduleFrequency.Monthly:
                return (endDate.Year - startDate.Year) * 12 + (endDate.Month - startDate.Month);

            case ScheduleFrequency.Quarterly:
                return (endDate.Year - startDate.Year) * 4 + (endDate.Month - startDate.Month) / 4;

            case ScheduleFrequency.Semiannual:
                return (endDate.Year - startDate.Year) * 2 + (endDate.Month - startDate.Month) / 2;

            case ScheduleFrequency.Annual:
                return endDate.Year - startDate.Year;

            default:
                throw new NotImplementedException();
        } 
    }

    // Offsets date by businessDateOffset before it is business date if businessDateOffset != 0
    private DateTime BusinessDateOffset(DateTime date)
    {
        if (businessDateOffset == 0)
            return date;

        while(!IsBusinessDay(date))
            date = date.AddDays(businessDateOffset);

        return date;
    }

    // Update last period if matchEndDate==true
    private DateTime[][] MatchLastDate(DateTime[][] schedule)
    {
        if (matchEndDate)
        {
            DateTime currentDate = PreviousDate(endDate);
            DateTime fixingDate = currentDate.AddDays(fixingDateOffset);
            DateTime paymentDate = endDate.AddDays(paymentDateOffset);

            schedule[^1] = [
                BusinessDateOffset(fixingDate),
                BusinessDateOffset(currentDate),
                BusinessDateOffset(endDate),
                BusinessDateOffset(paymentDate),
            ];
        }
        return schedule;
    }

    // Generates DateTime Schedule matrix with Fixing Date, Start Date, End Date, Payment Date
    public DateTime[][] GenerateSchedule()
    {
        int nperiods = CountPeriods();
        DateTime[][] schedule = new DateTime[nperiods][];

        DateTime currentDate = startDate;
        DateTime nextDate = NextDate(currentDate);

        for (int period = 0; period < nperiods; period++)
        {
            DateTime fixingDate = currentDate.AddDays(fixingDateOffset);
            DateTime paymentDate = nextDate.AddDays(paymentDateOffset);

            schedule[period] = [
                BusinessDateOffset(fixingDate), 
                BusinessDateOffset(currentDate), 
                BusinessDateOffset(nextDate), 
                BusinessDateOffset(paymentDate)
            ];

            currentDate = nextDate;
            nextDate = NextDate(currentDate);
        }

        return MatchLastDate(schedule);
    }

    // Prints DateTime Schedule matrix
    public void DisplaySchedule()
    {
        foreach (DateTime[] day in GenerateSchedule())
        {
            foreach(DateTime date in day)
            {
                Console.Write("{0}  ", date.ToString("yyyy/MM/dd"));
            }
            Console.WriteLine();
        }
    }
}
namespace OptionPricer.Utils.Dates;

public class Date
{
    DateTime date;

    public Date()
    {
        date = DateTime.Now;
    }

    public Date(int year, int month, int day)
    {
        date = new(year, month, day);
    }

    public Date(DateTime date)
    {
        this.date = date;
    }

    public Date(Date date)
    {
        this.date = date.date;
    }

    // Actual number of days between date - nedDate and actual number days in a year
    public double YearFractionActAct(DateTime endDate)
    {
        double act = DateTime.IsLeapYear(date.Year) ? 366 : 365;
        return (endDate - date).Days / act;
    }

    public double YearFractionActAct(Date endDate)
    {
        return YearFractionActAct(endDate.date);
    }

    // Actual number of days between date - nedDate and 360 days in a year
    public double YearFractionAct360(DateTime endDate)
    {
        return (endDate - date).Days / (double) 360;
    }

    public double YearFractionAct360(Date endDate)
    {
        return YearFractionAct360(endDate.date);
    }

    // Actual number of days between date - nedDate and 365 days in a year
    public double YearFractionAct365(DateTime endDate)
    {
        return (endDate - date).Days / (double) 365;
    }

    public double YearFractionAct365(Date endDate)
    {
        return YearFractionAct365(endDate.date);
    }

    // 30 day month days between date - nedDate and 360 days in a year
    public double YearFraction30_360(DateTime endDate)
    {
        int yearDelta = endDate.Year - date.Year;
        int monthDelta = endDate.Month - date.Month;
        int dayDelta = endDate.Day - date.Day;
        return  (yearDelta * 360 + monthDelta * 30 + dayDelta) / (double) 360;
    }

    public double YearFraction30_360(Date endDate)
    {
        return YearFraction30_360(endDate.date);
    }

    // 30 day month days between date - nedDate and 365 days in a year
    public double YearFraction30E_360(DateTime endDate)
    {   
        int yearDelta = endDate.Year - date.Year;
        int monthDelta = endDate.Month - date.Month;
        int dayDelta = endDate.Day == 31 ? 30: endDate.Day - date.Day == 31 ? 30 : date.Day;  
        return  (yearDelta * 360 + monthDelta * 30 + dayDelta) / (double) 360;
    }

    public double YearFraction30E_360(Date endDate)
    {
        return YearFraction30E_360(endDate.date);
    }
}
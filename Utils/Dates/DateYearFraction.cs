namespace OptionPricer.Utils.Dates;

public delegate double YearFraction(DateTime startDate, DateTime endDate);

public static class DateYearFraction
{
    public static double YearFractionActAct(DateTime startDate, DateTime endDate)
    {
        double act = DateTime.IsLeapYear(startDate.Year) ? 366 : 365;
        return DateDelta.DayDeltaAct(startDate, endDate) / act;
    }

    public static double YearFractionAct360(DateTime startDate, DateTime endDate)
    {
        return DateDelta.DayDeltaAct(startDate, endDate) / (double) 360;
    }

    public static double YearFractionAct365(DateTime startDate, DateTime endDate)
    {
        return DateDelta.DayDeltaAct(startDate, endDate) / (double) 365;
    }

    public static double YearFraction30360(DateTime startDate, DateTime endDate)
    {
        return DateDelta.DayDelta30(startDate, endDate) / (double) 360;
    }

    public static double YearFraction30E360(DateTime startDate, DateTime endDate)
    {   
        return DateDelta.DayDelta30E(startDate, endDate) / (double) 360;
    }
}
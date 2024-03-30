namespace OptionPricer.Utils.Dates;

public static class DateDelta
{
    public static int DayDeltaAct(DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).Days;
    }

    public static int DayDelta30(DateTime startDate, DateTime endDate)
    {
        int yearDelta = endDate.Year - startDate.Year;
        int monthDelta = endDate.Month - startDate.Month;
        int dayDelta = endDate.Day - startDate.Day;
        return  yearDelta * 360 + monthDelta * 30 + dayDelta;
    }

    public static int DayDelta30E(DateTime startDate, DateTime endDate)
    {
        int yearDelta = endDate.Year - startDate.Year;
        int monthDelta = endDate.Month - startDate.Month;
        int dayDelta = endDate.Day == 31 ? 30: endDate.Day - startDate.Day == 31 ? 30 : startDate.Day;  
        return  yearDelta * 360 + monthDelta * 30 + dayDelta;
    }
}
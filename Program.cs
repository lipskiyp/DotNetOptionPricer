using OptionPricer.Utils.Extensions;
using OptionPricer.Options.EuropeanOptions;
using OptionPricer.Options.EuropeanSwaptions;
using OptionPricer.Utils.Dates;

// European Options
EuropeanCallOption callOption = new(100, 0.1, 0.1, 0, 2);
EuropeanPutOption putOption = new();

callOption.Display(100);
Console.WriteLine();
putOption.Display(100);
Console.WriteLine();

// European Swaptions
EuropeanPayerSwaption payerSwaption = new(0.075, 0.2, 0.06, 2, 4, 2);
payerSwaption.Display(0.07);


DateScheduler scheduler = new(new DateTime(2020, 1, 1), new DateTime(2021, 1, 1), ScheduleFrequency.Monthly, -2, -2);
foreach (DateTime[] day in scheduler.GenerateSchedule())
{
    Console.WriteLine($"{day[0]}, {day[1]}, {day[2]}, {day[3]}");
}
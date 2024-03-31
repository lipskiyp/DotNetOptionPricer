using OptionPricer.Utils.Extensions;
using OptionPricer.Instruments.Options;
using OptionPricer.Instruments.Bonds;
using System.Linq.Expressions;

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


Bond bond = new(new DateTime(2020, 12, 31), new DateTime(2022, 12, 31), 0.025, 1000);
bond.scheduler.DisplaySchedule();
Console.WriteLine("Bond Dirty Price: {0}", bond.pricer.CleanPrice(new DateTime(2020, 12, 31), 0.1));



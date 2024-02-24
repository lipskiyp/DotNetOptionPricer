using OptionPricer.Extensions.European;
using OptionPricer.Options.EuropeanOptions;

EuropeanCallOption callOption = new(100, 0.1, 0.1, 0, 2);
EuropeanPutOption putOption = new();

callOption.Display(100);
Console.WriteLine();
putOption.Display(100);

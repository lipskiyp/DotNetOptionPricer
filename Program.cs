using OptionPricer.Options.European;

EuropeanCallOption callOption = new();
Console.WriteLine(callOption.Price(100));

EuropeanPutOption putOption = new();
Console.WriteLine(putOption.Price(100));

﻿using OptionPricer.Utils.Extensions;
using OptionPricer.Options.EuropeanOptions;
using OptionPricer.Options.EuropeanSwaptions;

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

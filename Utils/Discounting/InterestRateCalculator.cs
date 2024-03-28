namespace OptionPricer.Utils.Discounting;

public static class InterestRateCalculator
{
    // Future value of S given n number of periods with interest paid m times per period
    public static double FutureValue(double S, double r, double n, double m = 1)
    {
        return S * Math.Pow(1 + r / m, n * m);
    }

    // Future value of S starting with period n
    public static double FutureValue(double[] S, double r, double n = 0, double m = 1)
    {
        double FV = 0;
        foreach (double s in S)
        {
            FV += FutureValue(s, r, n, m);
            n++;
        }
        return FV;
    }

    // Ordinary Annuity Future Value given n number of periods with interest paid m times per period
    public static double FutureValueAnnuity(double S, double r, double n, double m = 1)
    {
        return S * (Math.Pow(1 + r / m, n * m) - 1) / r;
    }

    // Present value of S given n number of periods with interest paid m times per period
    public static double PresentValue(double S, double r, double n, double m = 1)
    {
        return S / Math.Pow(1 + r / m, n * m);
    }

    // Present value of Ps starting with period n
    public static double PresentValue(double[] S, double r, double n = 0, double m = 1)
    {
        double PV = 0;
        foreach (double s in S)
        {
            PV += PresentValue(s, r, n, m);
            n++;
        }
        return PV;
    }

    // Ordinary Annuity Present Value given n number of periods with interest paid m times per period
    public static double PresentValueAnnuity(double S, double r, double n, double m = 1)
    {
        return S * (1 - 1 / Math.Pow(1 + r / m, n * m)) / r;
    }
}
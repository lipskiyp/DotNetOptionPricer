namespace OptionPricer.Utils;

public static class NormalDist
{
    static MathNet.Numerics.Distributions.Normal normalDist;

    static NormalDist()
    {
        normalDist = new();
    }

    // Gaussian probability density
    public static double P(double x)
    {
        return normalDist.Density(x);
    }

    // Cumulative Gaussian distribution
    public static double N(double x)
    {
        return normalDist.CumulativeDistribution(x);
    }
}

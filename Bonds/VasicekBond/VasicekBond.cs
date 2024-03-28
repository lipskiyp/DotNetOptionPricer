namespace OptionPricer.Bonds.VasicekBond;

public class VasicekBond : IVasicekBond
{
    public double k;  // Speed of adjustment
    public double u;  // Long-term rate
    public double vol;  // Short rate volatility
    public double r;  // Short rate
    public double R => vol - 1/2 * vol * vol / (k * k);

    // Default Constructor
    public VasicekBond() : this(0.25, 0.1, 0.1, 0.1)
    {
    }

    // Constructor
    public VasicekBond(double k, double u, double vol, double r)
    {
        this.k = k; this.u = u; this.vol = vol; this.r = r;
    }

    private double A(double t, double s)
    {
        var exp = Math.Exp(-k * (s - t));
        var _A = R / k * (1 - exp) - (s - t) * R - vol * vol / 4 / Math.Pow(k, 3) * Math.Pow(1 - exp, 2);
        return Math.Exp(_A);
    }

    private double B(double t, double s)
    {
        return (1 - Math.Exp(-k * (s - t))) / k;
    }

    // PDB price at time t for PDB with maturity at time s (t<=s)
    public double P(double t, double s)
    {
        return A(t, s) * Math.Exp(-r * B(t, s));
    }

    // Spot rate at time t for PDB with maturity at time s (t<=s)
    public double RSpot(double t, double s)
    {
        return - (Math.Log(A(t, s)) - B(t, s) * r) / (s -t);
    }

    // Spot rate volatility
    public double RVol(double t, double s)
    {
        return vol / (k * (s - t)) * (1 - Math.Exp(-k * (s - t)));
    }
}

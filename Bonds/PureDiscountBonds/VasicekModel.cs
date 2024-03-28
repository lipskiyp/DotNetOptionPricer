namespace OptionPricer.Bonds.PureDiscountBonds;

public class VasicekModel : PureDiscountBond
{
    public double R => vol - 1/2 * vol * vol / (k * k);

    // Default Constructor
    public VasicekModel() : base()
    {
    }

    // Constructor
    public VasicekModel(double k, double u, double vol, double r) : base(k, u, vol, r)
    {
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
    public override double P(double t, double s)
    {
        return A(t, s) * Math.Exp(-r * B(t, s));
    }

    // Spot rate at time t for PDB with maturity at time s (t<=s)
    public override double RSpot(double t, double s)
    {
        return - (Math.Log(A(t, s)) - B(t, s) * r) / (s -t);
    }

    // Spot rate volatility
    public override double RVol(double t, double s)
    {
        return vol / (k * (s - t)) * (1 - Math.Exp(-k * (s - t)));
    }
}

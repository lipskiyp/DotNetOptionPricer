using OptionPricer.Instruments.Bonds;

namespace OptionPricer.Pricer.Bonds;

public class VasicekBondPricer : IVasicekBondPricer
{
    public VasicekBond bond;

    // Constructor
    public VasicekBondPricer(VasicekBond bond)
    {
        this.bond = bond;
    }

    private double A(double t, double s)
    {
        var exp = Math.Exp(-bond.k * (s - t));
        var _A = bond.R / bond.k * (1 - exp) - (s - t) * bond.R - bond.vol * bond.vol / 4 / Math.Pow(bond.k, 3) * Math.Pow(1 - exp, 2);
        return Math.Exp(_A);
    }

    private double B(double t, double s)
    {
        return (1 - Math.Exp(-bond.k * (s - t))) / bond.k;
    }

    // PDB price at time t for PDB with maturity at time s (t<=s)
    public double P(double t, double s)
    {
        return A(t, s) * Math.Exp(-bond.r * B(t, s));
    }

    // Spot rate at time t for PDB with maturity at time s (t<=s)
    public double RSpot(double t, double s)
    {
        return - (Math.Log(A(t, s)) - B(t, s) * bond.r) / (s -t);
    }

    // Spot rate volatility
    public double RVol(double t, double s)
    {
        return bond.vol / (bond.k * (s - t)) * (1 - Math.Exp(-bond.k * (s - t)));
    }
}

namespace OptionPricer.Pricer.Bonds;

public interface IVasicekBondPricer
{
    // PDB price at time t for PDB with maturity at time s (t<=s)
    public double P(double t, double s);

    // Spot rate at time t for PDB with maturity at time s (t<=s)
    public double RSpot(double t, double s);

    // Spot rate volatility
    public double RVol(double t, double s);
}

namespace OptionPricer.Options.Greeks;

public interface IGreeksFirstOrder
{
    // Delta
    public abstract double Delta(double S);

    // Vega
    public abstract double Vega(double S);

    // Rho
    public abstract double Rho(double S);
}

public interface IGreeksSecondOrder
{
    // Gamma
    public abstract double Gamma(double S);

    // Volga
    public abstract double Volga(double S);

    // Vanna
    public abstract double Vanna(double S);
}

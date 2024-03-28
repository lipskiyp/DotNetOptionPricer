namespace OptionPricer.Utils.Discounting;

public class InterestRate
{
    public double r;  // Interest rate

    // Default Constructor
    public InterestRate() : this(0.1)
    {
    }

    // Constructor
    public InterestRate(double r)
    {
        this.r = r;
    }
}
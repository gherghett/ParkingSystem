
public interface IPricingStrategy
{
    decimal CalculatePrice(Ticket ticket);
}

public class PricedPerStartedHour : IPricingStrategy
{
    private decimal _pricePerHour;
    public PricedPerStartedHour(decimal pricePerHour)
    {
        this._pricePerHour = pricePerHour;
    }
    public decimal CalculatePrice(Ticket ticket)
    {
        DateTime end = ticket.EndTime ?? DateTime.Now;
        TimeSpan parkedTime = end - ticket.StartTime;
        return _pricePerHour * (decimal)Math.Floor(parkedTime.TotalHours);
    }
}
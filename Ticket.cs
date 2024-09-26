public class Ticket
{
    public int LotId { get; private set; }
    public int CarId { get; private set; }
    public DateTime StartTime { get; private set; }
    public DateTime? EndTime { get; private set; }
    public decimal Price { get; private set; }

    private readonly IPricingStrategy _pricingStrategy;

    public Ticket(int lotId, int carId, IPricingStrategy pricingStrategy)
    {
        LotId = lotId;
        CarId = carId;
        StartTime = DateTime.Now;
        EndTime = null;
        _pricingStrategy = pricingStrategy;
    }

    public void SimulateHours(int h) => StartTime = StartTime.AddHours(-h);

    public void Close()
    {
        EndTime = DateTime.Now;
        Price = _pricingStrategy.CalculatePrice(this);
    }
}

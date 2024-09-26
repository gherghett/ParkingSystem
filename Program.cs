namespace ParkingSystem;

class Program
{
    static void Main(string[] args)
    {
        var ticket = new Ticket(lotId: 10, carId:20, new PricedPerStartedHour(pricePerHour: 20));
        ticket.SimulateHours(4);
        ticket.Close();
        Console.WriteLine(ticket.Price);
    }
}

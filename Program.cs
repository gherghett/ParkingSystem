namespace ParkingSystem;

class Program
{
    static void Main(string[] args)
    {
        IPricingStrategy todaysPrice = new PricedPerStartedHour(pricePerHour: 20);
        var ticket = new Ticket(lotId: 10, carId:20, todaysPrice);
        ticket.SimulateHours(4);
        ticket.Close();
        Console.WriteLine(ticket.Price);

        List<Ticket> tickets = [];
        
        for(int i = 0; i < 100; i++)
        {
            // 4 tickets för varje lot mellan 0-24
            var tkt = new Ticket(lotId: i/4, carId: i, todaysPrice); 

            // vi "spolar fram" 0 timmar för de 25 första, 1 timme 
            // för 25-49, 2 till 50-74, 3 till 75-99 
            tkt.SimulateHours(i/25);

            tkt.Close(); //parkering avslutas, och priset kalkyleras
            tickets.Add(tkt);
        }

        var prices = tickets.GroupBy(tkt => tkt.LotId)
                .Select(group => 
                    (
                        LotId: group.Key, 
                        TotalPrice: group.Sum(tkt => tkt.Price)
                    ))
                .OrderByDescending(p => p);

        prices.ToList()
            .ForEach(
                price => Console.WriteLine($"Lot: {price.LotId} earned:{price.TotalPrice}"));
    }
}

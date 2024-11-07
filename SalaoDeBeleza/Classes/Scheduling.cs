namespace SalaoDeBeleza.Classes
{
    public class Scheduling
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Professional Professional { get; set; }
        public DateTime Time { get; set; }

        public Scheduling() { }

        public Scheduling(Customer customer, Service service, Professional professional, DateTime time)
        {
            this.Customer = customer;
            this.Service = service;
            this.Professional = professional;
            this.Time = time;
        }
    }
}

namespace SalaoDeBeleza.Classes
{
    public class Service
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Professional Professional { get; set; }
        public decimal Price { get; set; }

        public Service() { }

        public Service(Customer customer, Professional professional, decimal price)
        {
            Customer = customer;
            Professional = professional;
            Price = price;
        }
    }
}

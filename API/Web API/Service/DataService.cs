using Web_API.Models;

namespace Web_API.Service
{
    public class DataService
    {
        private List<Customer> Customers { get; }
        public int Id { get; set; }

        public DataService()
        {
            Id = 1;

            Customers = new List<Customer>
            {
                new(Id++, "Mikkel",    "mikkel@privat.dk",    CustomerType.Privat),
                new(Id++, "Kenny",     "kenny@privat.dk",     CustomerType.Privat),
                new(Id++, "Louise",    "louise@privat.dk",    CustomerType.Privat),
                new(Id++, "Alexander", "alex@erhverv.dk",     CustomerType.Erhverv),
                new(Id++, "Kristian",  "kristian@erhverv.dk", CustomerType.Erhverv)
            };
        }

        // --------------------------------------------------
        public Customer[]? GetCustomers()
        {
            return Customers
                .ToArray();
        }

        public Customer? GetCustomerById(int id)
        {
            return Customers
                .Find(c => c.Id == id);
        }

        public Customer CreateCustomer(string name, string email, CustomerType type)
        {
            var customer = new Customer(Id++, name, email, type);

            Customers.Add(customer);

            return customer;
        }

        public Customer DeleteCustomer(int id)
        {
            var customer = Customers
                .Find(c => c.Id == id)!;

            Customers.Remove(customer);

            return customer;
        }

        public string[] GetEmailsByType(CustomerType type)
        {
            string[] emails = Customers
                .Where(c => c.Type == type)
                .Select(c => c.Email)
                .ToArray();

            return emails;
        }

    }
}

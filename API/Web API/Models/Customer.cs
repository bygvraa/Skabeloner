namespace Web_API.Models
{
    public class Customer
    {
        public Customer(int Id, string Name, string Email, CustomerType Type)
        {
            this.Id = Id;
            this.Name = Name;
            this.Email = Email;
            this.Type = Type;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public CustomerType Type { get; set; }
    }

    public enum CustomerType
    {
        Privat,
        Erhverv
    };

}

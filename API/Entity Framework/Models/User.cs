namespace Entity_Framework.Models
{
    public class User
    {
        // Properties
        public long Id { get; set; }
        public string Name { get; set; }
        public List<TodoTask>? Tasks { get; set; }

        // Konstruktører
        public User(string Name)
        {
            this.Name = Name;
        }
    }

}

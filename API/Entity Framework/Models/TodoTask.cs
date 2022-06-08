namespace Entity_Framework.Models
{
    public class TodoTask
    {
        // Properties
        public long Id { get; set; }
        public string Text { get; set; }
        public bool Done { get; set; }
        public User? User { get; set; }

        // Konstruktører
        public TodoTask(string Text, bool Done, User User)
        {
            this.Text = Text;
            this.Done = Done;
            this.User = User;
        }

        public TodoTask(string Text, bool Done)
        {
            this.Text = Text;
            this.Done = Done;
        }
    }
}

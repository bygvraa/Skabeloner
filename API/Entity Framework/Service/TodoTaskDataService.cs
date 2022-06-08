using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Entity_Framework.Data;
using Entity_Framework.Models;

namespace Entity_Framework.Service
{
    public class TodoTaskDataService
    {
        private TodoTaskDbContext db { get; }
        public TodoTaskDataService(TodoTaskDbContext db)
        {
            this.db = db;
        }

        // ---------------------------------------------------------------

        public List<TodoTask> GetTasks()
        {
            return db.Tasks
                .Include(task => task.User)
                .ToList();
        }

        public TodoTask GetTaskById(int id)
        {
            return db.Tasks
                .Where(task => task.Id == id)
                .Include(task => task.User)
                .First();
        }

        public string CreateTask(string text, bool done, int userId)
        {
            User user = db.Users
                .Where(user => user.Id == userId)
                .First();

            TodoTask task = new(text, done, user);

            db.Tasks.Add(task);
            db.SaveChanges();

            return JsonSerializer.Serialize(
                new { msg = "New task created", newTask = task }
            );
        }

        public DbSet<User> GetUsers()
        {
            return db.Users;
        }

        public string CreateUser(string name)
        {
            User user = new(name);

            db.Users.Add(user);
            db.SaveChanges();

            return JsonSerializer.Serialize(
                new { msg = "New user created", newUser = user });
        }

        // ---------------------------------------------------------------

        /// <summary>
        /// Seeder noget nyt data i databasen hvis det er nødvendigt.
        /// </summary>
        public void SeedData()
        {
            User user = db.Users.FirstOrDefault()!;
            if (user is null)
            {
                user = new User("Lasse");

                db.Users.Add(user);
                db.Users.Add(new User("Simon"));
                db.Users.Add(new User("Søren"));
            }

            TodoTask task = db.Tasks.FirstOrDefault()!;
            if (task is null)
            {
                db.Tasks.Add(new TodoTask("Opgave1", false, user));
                db.Tasks.Add(new TodoTask("Opgave2", true, user));
                db.Tasks.Add(new TodoTask("Opgave3", false, user));
            }

            db.SaveChanges();
        }
    }
}

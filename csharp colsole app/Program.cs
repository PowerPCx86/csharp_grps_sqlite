using Microsoft.EntityFrameworkCore;

namespace app
{
    public class Program
    {
        private static void Main(string[] args)
        {
            using (var context = new Db_context())
            {
                context.Database.EnsureCreated();
                var person = new Person { name = "cat" };
                context.People.Add(person);
                context.SaveChanges();

                var people = context.People.ToList();
                foreach(var dude in people)
                {
                    Console.WriteLine($"ID: {dude.id}, NAME: {dude.name}");
                }

            }
        }
    }

    public class Db_context : DbContext
    {
        public DbSet<Person> People { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=people.db");
        }

    }

    public class Person
    {
        public int id { set; get; }
        public string? name { set; get; }
    }
}

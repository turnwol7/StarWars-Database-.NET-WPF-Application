using System;
using System.Linq;
using System.IO;
using Npgsql;
using StarWarsDatabaseApp;
using starwars;

namespace StarWarsDatabaseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Establish database connection
            string connectionString = "Host=localhost;Username=postgres;Password=postgres;Database=starwars";
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Execute SQL script to set up the database schema
                ExecuteSqlFromFile(connection, "database.sql");
                Console.WriteLine("Database setup completed.");

                // Retrieve data from the database using Entity Framework Core
                StarwarsContext context = new StarwarsContext();

                IQueryable<Person> people = context.People;
                Console.WriteLine("0X0X0X0X0X PEOPLE IN STARWARS 0X0X0X0X0");
                foreach (Person person in people)
                {
                    Console.WriteLine(person.Name);
                }

                IQueryable<Planet> planets = context.Planets.Where(p => p.Population > 1000000);
                Console.WriteLine("\n0X0X0X0X0X PLANETS POPULATION 0X0X0X0X0");
                foreach (Planet planet in planets)
                {
                    Console.WriteLine($"Planet: {planet.Name}, Population: {planet.Population}");
                }

                IQueryable<Person> tallPeople = context.People.Where(p => p.Height > 200);
                Console.WriteLine("\n0X0X0X0X0X HEIGHTS IN CM 0X0X0X0X0");
                foreach (Person person in tallPeople)
                {
                    Console.WriteLine($"Name: {person.Name}, Height: {person.Height}");
                }

                // Close database connection
                connection.Close();
            }
            Console.ReadLine();
        }

        private static void ExecuteSqlFromFile(NpgsqlConnection connection, string filePath)
        {
            string sql = File.ReadAllText(filePath);
            using NpgsqlCommand cmd = new NpgsqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }
    }
}
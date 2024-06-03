using AGSR.DataLayer;
using AGSR.DataLayer.Entities;
using AGSR.DataLayer.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace AGSR_Console
{
    public class Program
    {
        private static string connectionString;
        private static string[] FirstNames = { "Пётр", "Иван", "Александр", "Алексей", "Антон", "Дмитрий", "Анатолий", "Евгений", "Виктор", "Роман" };
        private static string[] LastNames = { "Пётров", "Иванов", "Хвостов", "Пушкин", "Толстой", "Лермонтов", "Тургенев", "Тютчев", "Достоевский", "Гоголь" };
        private static string[] Surnames = { "Пётрович", "Иванович", "Александрович", "Алексеевич", "Антонович", "Дмитриевич", "Анатольевич", "Евгеньевич", "Викторович", "Романович" };


        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;

            var rand = new Random();

            using (ApplicationDbContext db = new ApplicationDbContext(options))
            {
                for (int i = 0; i < 100; i++)
                {
                    var patient = new Patient()
                    {
                        Id = Guid.NewGuid(),
                        Family = LastNames[rand.Next(0, 9)],
                        FirstName = FirstNames[rand.Next(0, 9)],
                        Surname = Surnames[rand.Next(0, 9)],
                        Use = "official",
                        Active = true,
                        BirthDate = new DateTime(rand.Next(1950, 2024), rand.Next(1, 12), rand.Next(28)),
                        Gender = Gender.Male
                    };
                    db.Set<Patient>().Add(patient);
                }

                db.SaveChanges();

                var patients = db.Patient.ToList();
                foreach (Patient patient in patients)
                    Console.WriteLine($"{patient.Id} {patient.Family} {patient.FirstName} {patient.Surname} - {patient.BirthDate}");
            }
        }
    }
}
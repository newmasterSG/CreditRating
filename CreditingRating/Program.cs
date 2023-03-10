using CreditingRating.Context;
using CreditingRating.Model;
using Microsoft.EntityFrameworkCore;
using CreditingRating.CalculationScore;
using System.Globalization;

namespace CreditingRating
{
    public class Program
    {
        static void Main(string[] args)
        {
            FicoGrade ficoGrade = new FicoGrade();
            //Writing name.
            string name = Console.ReadLine();

            //Writing surname.
            string surname = Console.ReadLine();

            double salary = Convert.ToDouble(Console.ReadLine());

            int age = Convert.ToInt32(Console.ReadLine());

            string male = Console.ReadLine();

            var cultureInfo = new CultureInfo("de-DE");

            string dateString = "12 Juni 2008";

            var dateTime = DateTime.Parse(dateString, cultureInfo);
            //Connection to database
            using (var dbContext1 = new BankingContext())
            {
                var existingClient = dbContext1.Clients.Include(c => c.Credits).FirstOrDefault(c => c.Person.Name == name && c.Person.Surname == surname);

                //Checking if user has in datavase if not adding
                if (existingClient != null && existingClient.Credits != null && existingClient.Credits.Any())
                {
                    var clientRating = ficoGrade.CalculateFicoScore(existingClient.Credits.ToList());
                    Console.WriteLine($"Клиент уже есть в базе данных. Рейтинг клиента: {clientRating}");
                }
                else
                {
                    var client = new Client
                    {
                        Salary = salary,
                        Person = new Person
                        {
                            Age = age,
                            Birthday = dateTime.ToString(),
                            Name = name,
                            Surname = surname,
                            Gender = male
                        },
                        Credits = new List<Credit>
                        {
                        new Credit(){ AvailableCredit = 10000, MoneySpent = 0, LatePayment = 0, OpenedDate = new DateTime(1999, 1, 1), Name = "SomeCreidit"},
                        new Credit(){ AvailableCredit = 10000, MoneySpent = 0, LatePayment = 0, OpenedDate = new DateTime(2000, 1, 1), Name = "SomeCreidit"},
                        new Credit(){ AvailableCredit = 10000, MoneySpent = 0, LatePayment = 0, OpenedDate = new DateTime(2004, 1, 1), Name = "Mortage"}
                        }
                    };
                    var bank = new Bank { };
                    var bankClient = new BankClient { Bank = bank, Client = client, Rating = ficoGrade.CalculateFicoScore(client.Credits.ToList()) };
                    dbContext1.BankClients.Add(bankClient);
                    dbContext1.SaveChanges();
                    Console.WriteLine($"Новый клиент успешно добавлен. Рейтинг клиента: {bankClient.Rating}");
                }
            }

            using (var context = new BankingContext())
            {
                var clients = context.Clients
                    .SelectMany(c => c.ClientBanks, (c, p) => new { ClientId = c.Id, Salary = c.Salary, Rating = p.Rating })
                    .ToList();

                foreach (var client in clients)
                {
                    Console.WriteLine($"Id: {client.ClientId}, Salary: {client.Salary}, Rating: {client.Rating}");
                }
            }

            int id = Convert.ToInt32(Console.ReadLine());
            using (var context = new BankingContext())
            {
                var bank = context.Clients.FirstOrDefault(b => b.Id == id); // Получить объект Bank с Id = id
                if (bank != null)
                {
                    bool deleteMoreClients = true;
                    while (deleteMoreClients)
                    {
                        Console.WriteLine($"Удалить всех клиентов банка {bank.Id}? (Y/N)");
                        string answer = Console.ReadLine();
                        if (answer.ToLower() == "y")
                        {
                            var bankClients = context.BankClients.Where(bc => bc.ClientId == bank.Id); // Получить всех BankClient, связанных с Bank
                            context.BankClients.RemoveRange(bankClients); // Удалить всех BankClient
                            context.Clients.Remove(bank); // Удалить сам объект Bank
                            context.SaveChanges(); // Сохранить изменения
                            Console.WriteLine("Клиенты банка удалены");
                            deleteMoreClients = false;
                        }
                        else if (answer.ToLower() == "n")
                        {
                            Console.WriteLine("Операция отменена");
                            deleteMoreClients = false;
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод, попробуйте еще раз");
                        }
                    }
                }
            }

            //using (var context = new BankingContext())
            //{
            //    var bank = context.Clients.FirstOrDefault(b => b.Id == 7004); // Получить объект Bank с Id=1
            //    if (bank != null)
            //    {
            //        var bankClients = context.BankClients.Where(bc => bc.ClientId == bank.Id); // Получить все BankClient, связанные с Bank
            //        context.BankClients.RemoveRange(bankClients); // Удалить все BankClient
            //        context.Clients.Remove(bank); // Удалить сам объект Bank
            //        context.SaveChanges(); // Сохранить изменения
            //    }
            //}

            //using (var context = new BankingContext())
            //{
            //    var clients = context.Clients.Select(x => x.Id).ToList();

            //    foreach (var client in clients)
            //    {
            //        // Console.WriteLine($"Id: {client.ClientId}, Salary: {client.Salary}, Rating: {client.Rating}");
            //        Console.WriteLine($"Id : {client}");
            //    }
            //}
        }
    }
}
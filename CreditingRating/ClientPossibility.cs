using CreditingRating.CalculationScore;
using CreditingRating.Context;
using CreditingRating.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditingRating
{
    public class ClientPossibility
    {
        public void CheckingRating(string name, string surname)
        {
            FicoGrade ficoGrade = new FicoGrade();
            //Connection to database
            using (var dbContext1 = new BankingContext())
            {
                var existingClient = dbContext1.Clients.Include(c => c.Credits).FirstOrDefault(c => c.Person.Name == name && c.Person.Surname == surname);

                //Checking if user has in datavase if not adding
                if (existingClient != null && existingClient.Credits != null && existingClient.Credits.Any())
                {
                    var clientRating = ficoGrade.CalculateFicoScore(existingClient.Credits.ToList());
                    Console.WriteLine($"The client is already in the database. Customer rating: {clientRating}");
                }
                else
                {
                    Console.Write("Write your salary = ");
                    double salary = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Write your age = ");
                    int age = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    Console.Write("Write your gender = ");
                    string gender = Console.ReadLine();
                    Console.WriteLine();

                    var cultureInfo = new CultureInfo("de-DE");

                    Console.WriteLine("Write your birthday date like this format 12 Juni 2008 also you can write 12 07 2008");

                    Console.Write("Write you birhday date = ");
                    string dateString = Console.ReadLine();
                    Console.WriteLine();

                    var dateTime = DateOnly.Parse(dateString, cultureInfo);

                    Console.Write("How many credits do you have ? ");
                    int numbersOfCredits = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    List<Credit> credits = new List<Credit>();

                    for (int i = 1; i <= numbersOfCredits; i++)
                    {
                        Console.Write("Enter how much credit is available to you on the card = ");
                        int AvailableCredit = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        Console.Write("How much did you spend on credit = ");
                        double MoneySpent = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine();

                        Console.Write("Enter how many late payments were = ");
                        int LatePay = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        Console.Write("Please enter the type of loan = ");
                        string NameCredit = Console.ReadLine();
                        Console.WriteLine();

                        Console.Write("Write when you open this credit like this format 12 Juni 2008 also you can write 12 07 2008 = ");
                        string datString = Console.ReadLine();
                        Console.WriteLine();
                        try
                        {
                            var datTime = DateTime.Parse(dateString, cultureInfo);
                            credits.Add(new Credit() { AvailableCredit = AvailableCredit, MoneySpent = MoneySpent, LatePayment = LatePay, OpenedDate = datTime, Name = NameCredit });
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        if(numbersOfCredits > 1)
                        {
                            Console.WriteLine($"Do the same with {i++} credit");
                        }
                    }

                    var client = new Client
                    {
                        Salary = salary,
                        Person = new Person
                        {
                            Age = age,
                            Birthday = dateTime.ToString(),
                            Name = name,
                            Surname = surname,
                            Gender = gender
                        },
                        Credits = credits
                    };
                    var bank = new Bank { };
                    var bankClient = new BankClient { Bank = bank, Client = client, Rating = ficoGrade.CalculateFicoScore(client.Credits.ToList()) };
                    dbContext1.BankClients.Add(bankClient);
                    dbContext1.SaveChanges();
                    Console.WriteLine($"New client added successfully. Customer Rating: {bankClient.Rating}");
                }
            }
        }

        public void CheckingAllUsers()
        {
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
        }

        public void DeleteUserFromDataBase(int id)
        {
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
        }

    }
}

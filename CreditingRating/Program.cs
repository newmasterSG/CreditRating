using CreditingRating.Context;
using CreditingRating.Model;
using Microsoft.EntityFrameworkCore;
using CreditingRating.CalculationScore;
namespace CreditingRating
{
    public class Program
    {
        static void Main(string[] args)
        {
            FicoGrade ficoGrade = new FicoGrade();
            using (var dbContext1 = new BankingContext())
            {
                var client = new Client
                {
                    Salary = 600000,
                    CreditHistory = new CreditHistory
                    {
                        CreditHistoryLength = 5,
                        CreditUtilization = 10,
                        PaymentHistory = new List<double> { 1,1,1,1 },
                        recentInquiries = 0
                    },
                    Person = new Person
                    {
                        Age = 20,
                        Birthday = new DateOnly(2004, 09, 03).ToString(),
                        Name = "Daniel",
                        Surname = "Plotnik",
                        Gender = "male"
                    },
                };
                var bank = new Bank { };
                var bankClient = new BankClient { Bank = bank, Client = client, Rating = ficoGrade.CalculateScore(client) };
                dbContext1.BankClients.Add(bankClient);
                dbContext1.SaveChanges();
            }

            using (var context = new BankingContext())
            {
                var clients = context.Clients
                    .SelectMany(c => c.ClientBanks, (c, p) => new { ClientId = c.Id, Salary = c.Salary, Rating = p.Rating })
                    .ToList();

                //var clients = context.Clients.Select(x => x.Id).ToList();

                foreach (var client in clients)
                {
                     Console.WriteLine($"Id: {client.ClientId}, Salary: {client.Salary}, Rating: {client.Rating}");
                    //Console.WriteLine($"Id : {client}");
                }
            }

            //using (var context = new BankingContext())
            //{
            //    var bank = context.Clients.FirstOrDefault(b => b.Id == 1002); // Получить объект Bank с Id=1
            //    if (bank != null)
            //    {
            //        var bankClients = context.BankClients.Where(bc => bc.ClientId == bank.Id); // Получить все BankClient, связанные с Bank
            //        context.BankClients.RemoveRange(bankClients); // Удалить все BankClient
            //        context.Clients.Remove(bank); // Удалить сам объект Bank
            //        context.SaveChanges(); // Сохранить изменения
            //    }
            //}

            using (var context = new BankingContext())
            {
                var clients = context.Clients.Select(x => x.Id).ToList();

                foreach (var client in clients)
                {
                    // Console.WriteLine($"Id: {client.ClientId}, Salary: {client.Salary}, Rating: {client.Rating}");
                    Console.WriteLine($"Id : {client}");
                }
            }
        }
    }
}
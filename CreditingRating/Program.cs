using CreditingRating.Context;
using CreditingRating.Model;
using Microsoft.EntityFrameworkCore;
using CreditingRating.CalculationScore;
using System.Globalization;
using System.Numerics;

namespace CreditingRating
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! This program was created for calculation creaditing rating using FICO score");

            Console.Write("Write your name = ");
            string name = Console.ReadLine();
            name = name.Trim();
            Console.WriteLine();

            Console.Write("Write your surname = ");
            string surname = Console.ReadLine();
            surname = surname.Trim();
            Console.WriteLine();

            ClientPossibility clientPossibility = new ClientPossibility();

            clientPossibility.CheckingRating(name, surname);
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;

namespace KiwiBankomaten
{
    class DataBase
    {
        // Dictionary for saving users. With 6 test users created
        public static Dictionary<int, Customer> CustomerDict =
            new Dictionary<int, Customer>()
        {
                {1, new Customer(1, "Tobias", "NotionLover65",false) },
                {2, new Customer(2, "Anas", "Core3.1",false) },
                {3, new Customer(3, "Reidar", "Password123",false) },
                {4, new Customer(4, "Michael", "abc",false) },
                {5, new Customer(5, "Andre", "123",false) },
                {6, new Customer(6, "Ludvig", "drowssaP",false) }
        };

        // List of Admins
        public static List<Admin> AdminList = new List<Admin>()
        {
            {new Admin("Petter", "Rettep") },
            {new Admin("Max", "Xam") },
            {new Admin("Jonathan", "Nahtajon") },
            {new Admin("Daniel", "Leinad") },
            {new Admin("Charlie", "Eilrahc") }
        };

        // Dictionary with currencies and exchange rates
        public static Dictionary<string, decimal> ExchangeRates =
            new Dictionary<string, decimal>()
        {
                {"SEK", 1m },
                {"USD", 10.42m },
                {"EUR", 10.85m },
                {"DKK", 1.46m },
                {"NOK", 1.05m },
                {"GBP", 12.59m },
                {"CHF", 11.04m },
                {"AUD", 6.98m },
                {"CNY", 1.45m }
            };

        // Prints out currrency list with current exchange rates
        public static void PrintCurrencies()
        {
            foreach (string currency in DataBase.ExchangeRates.Keys)
            {
                Console.WriteLine($"{currency}");
            }
        }

        // Dictionary with account types and interest
        public static List<Tuple<string, decimal>> BankAccountTypes =
            new List<Tuple<string, decimal>>
            {
                Tuple.Create("Lönekonto", 0m),
                Tuple.Create("Korttidssparkonto", 1.2m ),
                Tuple.Create("Långtidssparkonto", 1.7m ),
                Tuple.Create("Barnsparkonto", 2.3m)
            };

        // Prints out account types with interest values
        public static void PrintAccountTypes()
        {
            for (int i = 1; i <= BankAccountTypes.Count; i++)
            {
                Console.WriteLine($"{i}. {BankAccountTypes[i - 1].Item1}, " +
                    $"ränta: {BankAccountTypes[i - 1].Item2}");
            }
        }
    }
}

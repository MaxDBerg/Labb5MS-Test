﻿using System;
using System.Collections.Generic;

namespace KiwiBankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LogIn();
        }

        public static void LogIn()
        {

            Console.WriteLine("Welcome to KiwiBank");
            Console.WriteLine("Please enter your account name:");
            string userName = (Console.ReadLine());

            foreach (KeyValuePair<int, User> item in DataBase.UserDict)
            {
                if (userName == item.Value.UserName)
                {
                    int userKey = item.Key;
                    CheckPassWord(userKey);
                }
            }
            
        }

        public static void CheckPassWord(int userKey)
        {
            Console.WriteLine("Enter your password");
            string userPassWord = (Console.ReadLine());

            

            if (userPassWord == DataBase.UserDict[userKey].Password)
            {
                Console.WriteLine("congratz petter was right");
            }

            
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Net.Sockets;

namespace KiwiBankomaten
{
    public class DataSaver
    {
        // Checks if DataBase files exists on startup. If they do not,
        // it creates all necessary files from DataBase class. If they do
        // exist it writes to DataBase from files.
        public static void CheckDataBase()
        {

        }

        // Writes info from DataBase to file.
        public static void DSaver(string fileName)
        {
            // CREATING FILE LOCALLY
            StreamWriter sw = new StreamWriter(fileName);
            // Writes data on matching file
            if (fileName == "Customers.txt")
            {
                foreach (KeyValuePair<int, Customer> item in DataBase.CustomerDict)
                {
                    sw.Write("Id: {0} Username: {1} " +
                        "Password: {2} Locked: {3} ", 
                        item.Value.Id, item.Value.UserName, 
                        item.Value.Password, item.Value.Locked); ;
                    sw.WriteLine();
                }
            }
            else if (fileName == "BankAccounts.txt")
            {
                foreach (Customer c in DataBase.CustomerDict.Values)
                {
                    foreach (KeyValuePair<int, BankAccount> item in c.BankAccounts)
                    {
                        sw.Write("Customer ID: {0} Account Key: {1} AccountNr: {2} " +
                            "Name: {3} Amount: {4} Currency: {5} Interest: {6}",
                            c.Id, item.Key, item.Value.AccountNumber,
                            item.Value.AccountName,item.Value.Amount,
                            item.Value.Currency,item.Value.Interest);
                        sw.WriteLine();
                    }
                }

            }

            else if (fileName == "Admins.txt")
            {

            }
            else if (fileName == "Currencies.txt")
            {

            }
            else if (fileName == "BankAccountTypes.txt")
            {

            }
            else if (fileName == "LoanAccountTypes.txt")
            {

            }
            else
            {
                Console.WriteLine("File doesn't exist.");
            }
            // closes stream
            sw.Close();
            Console.WriteLine("Fil skapades");
        }

        public static void UpdateFromFile(string fileName)
        {
            StreamReader sr = new StreamReader(fileName);

            // Writes data on matching file
            if (fileName == "Customers.txt")
            {
                // Clear dictionary
                DataBase.CustomerDict.Clear();
                string[] lines = sr.ReadToEnd().Split("\n");
                foreach (string item in lines)
                {
                    string[] temp = item.Split(" ");
                    DataBase.CustomerDict.Add(Convert.ToInt32(temp[1]),
                        new Customer(Convert.ToInt32(temp[1]), temp[3],
                        temp[5], Convert.ToBoolean(temp[7])));
                }
            }
            else if (fileName == "BankAccounts.txt")
            {

            }

            else if (fileName == "Admins.txt")
            {

            }
            else if (fileName == "Currencies.txt")
            {

            }
            else if (fileName == "BankAccountTypes.txt")
            {

            }
            else if (fileName == "LoanAccountTypes.txt")
            {

            }
            else
            {
                Console.WriteLine("File doesn't exist.");
            }

            sr.Close();
        }

        //Tasks:
        // - primary
        //    X    Make DataSaver possible for other files than File1
        //    X    Connect the "DataBase"-Files to each other.
        //    X    hur välförståeligt behöver detta vara för admin/användare?

        // - secondary
        //    X    Implement DataReading Method to admin menu, to see files and read them     när den funkar fullständigt
        //    X    Make DataSaver not public to the user, only workable       efter all testning, när det funkar
        //    X    Implement DataSaver method in program so that it will sync files during changes and when pressing exit
        //         på passande platser osv.





        // fil 1  customerdictionary  - innehåller 6 st key, id, username, isadmin, locked samt tillhörande värden

        // fil 2
        /// Customer
        /// har dictionary bankokonton
        /// id 4
        /// username michael
        /// password  abc
        /// isadamin false
        /// locked false

        //if property is changed, write on file 2 and save
        //press to read whole customerdict, read on file 2

        // fil 3
        /// Bankaccounts  
        /// bankaccount
        /// int accountnr
        /// string accountname
        /// decimal amount
        /// string currency
        /// decimal interest
        /// list log

        //if account is added  write on file 3 and save
        //if property is changed    write on file 3 and save
        //if log is changed   write on file 3 and save
        // press to read accounts read on file 3





        // Method to read and show data from chosen file.
        // DataSaver.DataReading("Customer.txt");  HOW TO USE
        public static void DataReading(string fileName)
        {
            // Takes in parameter which is the name of the file. Example, write "File1" 
            StreamReader sr = new StreamReader(fileName);
            Console.WriteLine($"Content of the File ({fileName}): \n");

            // This is use to specify from where to start reading input stream
            sr.BaseStream.Seek(0, SeekOrigin.Begin);

            // To read line from input stream
            string textLine = sr.ReadLine();

            // To read the whole file line by line
            while (textLine != null)
            {
                Console.WriteLine(textLine);
                textLine = sr.ReadLine();
            }
            Console.ReadLine();
            sr.Close(); // Must close streamreader after use
        }
    }
}


using System;
using System.Collections.Generic;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace ProblematicProblem
{
    class Program
    {
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = Console.ReadLine().ToLower() == "yes" ? true : false;

            Console.WriteLine();

            if (!cont)
            {
                Environment.Exit(0);
            }

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            bool seeList = Console.ReadLine().ToLower() == "sure" ? true : false;

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} * ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("\nWould you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} * ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine().ToLower() == "yes" ? true : false;
                }
            }


            while (cont)
            {
                Console.Write("\nConnecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("\nChoosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Random rng = new Random();
                int randomNumber = rng.Next(activities.Count);

                string randomActivity = activities[randomNumber];

                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"\nOh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("\nPick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rng.Next(activities.Count);

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"\nAh got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                cont = Console.ReadLine().ToLower() == "keep" ? false : true;
            }
        }
    }
}

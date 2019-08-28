using ClassLibraryFitness.Controller;
using ClassLibraryFitness.Model;
using System;
using FitnessConsole.CMD.Languages;
using System.Globalization;
using System.Resources;
using System.Reflection;

namespace FitnessConsole.CMD
{
    // Please Comment as much as Possible!!!
    //Always
    class Program
    {
        static void Main(string[] args)
        {
            //Culture mainly for languages
            var culture = new CultureInfo("cz");
            Assembly a = Assembly.Load("FitnessConsole.CMD");
            var resourceManager = new ResourceManager("FitnessConsole.CMD.Languages.Messages", a);

            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            //Console.WriteLine("Enter Gender");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Enter bith date");
            //var birthdate = DateTime.Parse(Console.ReadLine()); // todo: try parse

            //Console.WriteLine("Enter Weight");
            //var weight =double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Height");
            //var height =double.Parse(Console.ReadLine());

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            // check if this user is new(true)
            if (userController.IsNewUser)
            {
                Console.WriteLine(Messages_RU.NewUser);
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");
                
                userController.SetNewUserData(gender, birthDate, weight, height);

            }
             
            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("What you want to do?");
            Console.WriteLine("E - enter eating event");
            Console.WriteLine();
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.ffood, foods.wweight);

                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
                
            }

            Console.ReadLine();
        }

        private static (Food ffood, double wweight) EnterEating()
        {
            Console.WriteLine("Enter product name: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Calories");
            var proteins = ParseDouble("Proteins");
            var fets = ParseDouble("Fets");
            var carbonates = ParseDouble("Carbonates");

            var weight = ParseDouble("weight of the portion");
            var product = new Food(food, calories, proteins, fets, carbonates);
            return (ffood: product, wweight: weight);
        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Enter bith date (dd.MM.yyyy): ");
                // if the date is correct we can parse it then we break
                // if parse not possible than date was in wrong format
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not correct format of the birth date");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string _name)
        {
            while (true)
            {
                Console.Write($"Enter {_name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Not correct format of the field {_name}");
                }
            }
        }
    }
}

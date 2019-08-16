using ClassLibraryFitness.Controller;
using System;

namespace FitnessConsole.CMD
{
    // Please Comment as much as Possible!!!
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello from App ConsoleFitness");
            Console.WriteLine("Enter User Name");
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
            // check if this user is new(true)
            if (userController.IsNewUser)
            {
                Console.WriteLine("You are New User, Please type Gender: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Weight");
                var height = ParseDouble("Height");
                
                userController.SetNewUserData(gender, birthDate, weight, height);

            }
             
            Console.WriteLine(userController.CurrentUser);

            Console.ReadLine();
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
                    Console.WriteLine($"Not correct format of {_name}");
                }
            }
        }
    }
}

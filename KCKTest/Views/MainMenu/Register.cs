using System;

namespace KCKTest.Views.Activity
{
    internal class Register
    {
        public Register()
        {
            Name = null;
            Password = null;
            RePassword = null;
            GetValues();
        }

        public string Name { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Goal { get; set; }
        public string BikeDivider { get; set; }
        public string SwimDivider { get; set; }

        private void GetValues()
        {
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            Password = Console.ReadLine();
            Console.WriteLine("Reenter Password:");
            RePassword = Console.ReadLine();
            Console.WriteLine("Enter your monthly goal(km):");
            Goal = Console.ReadLine();
            Console.WriteLine("Enter your divider for bike workout: ");
            BikeDivider = Console.ReadLine();
            Console.WriteLine("Enter your divider for swim workout: ");
            SwimDivider = Console.ReadLine();
            Console.Clear();
        }

        public void WrongData()
        {
            Console.WriteLine("Wrong data, type again.");
        }

        public void Registered()
        {
            Console.WriteLine("User created.");
        }
    }
}
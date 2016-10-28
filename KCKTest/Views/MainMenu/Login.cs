using System;

namespace KCKTest.Views.MainMenu
{
    internal class Login
    {
        public Login()
        {
            Name = null;
            Password = null;
            GetValues();
        }

        public string Name { get; set; }
        public string Password { get; set; }

        private void GetValues()
        {
            Console.WriteLine("Enter Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            Password = Console.ReadLine();
            Console.Clear();
        }

        public void WrongData()
        {
            Console.WriteLine("Wrong name or password");
        }
    }
}
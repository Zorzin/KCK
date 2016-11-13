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
            Console.Clear();
            if (!GetName())
            {
                return;
            }
            if (!GetPassword())
            {
                return;
            }
            Console.Clear();
        }
        private bool CheckEsc(string s)
        {
            if (s == "esc")
            {
                return false;
            }
            return true;
        }
        private void ShowOnConsole(string s)
        {
            Console.Clear();
            int middle = (Console.WindowWidth-21)/2;
            Console.SetCursorPosition(middle,Console.CursorTop);
            Console.WriteLine("Type \"esc\" to cancel.");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter " + s + ":");
            Console.SetCursorPosition(middle, Console.CursorTop);
        }
        public void WrongData()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Wrong name or password");
        }

        private bool GetName()
        {
            ShowOnConsole("login");
            Name = Console.ReadLine();
            if (CheckEsc(Name))
            {
                return true;
            }
            return false;
        }

        private bool GetPassword()
        {
            ShowOnConsole("password");
            Password = Console.ReadLine();
            if (CheckEsc(Password))
            {
                return true;
            }
            return false;
        }
    }
}
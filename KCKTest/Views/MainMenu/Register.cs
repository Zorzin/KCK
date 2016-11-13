using System;
using KCKTest.Controllers;
using KCKTest.Logic;

namespace KCKTest.Views.MainMenu
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
        private bool exit = false;

        private void GetValues()
        {
            while (true)
            {
                Console.Clear();
                if (!GetName())
                {
                    return;
                }
                Console.Clear();
                if (!GetPassword())
                {
                    return;
                }
                Console.Clear();
                if (!GetRePassword())
                {
                    return;
                }
                Console.Clear();
                if (!GetGoal())
                {
                    return;
                }
                Console.Clear();
                if (!GetBike())
                {
                    return;
                }
                Console.Clear();
                if (!GetSwim())
                {
                    return;
                }
                break;
            }
            
            Console.Clear();
        }

        public void WrongData()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Wrong data, type again.");
        }

        public void Registered()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("User created.");
        }

        private bool CheckEsc(string s)
        {
            if (s=="esc")
            {
                return false;
            }
            return true;
        }
        private void ShowOnConsole(string s)
        {
            int middle = (Console.WindowWidth-21)/2;
            Console.SetCursorPosition(middle, Console.CursorTop+1);
            Console.WriteLine("Type \"esc\" to cancel.");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter "+s+":");
            Console.SetCursorPosition(middle, Console.CursorTop);
        }
        private bool GetName()
        {
            while (true)
            {
                ShowOnConsole("your Name");
                Name = Console.ReadLine();
                if (!CheckEsc(Name))
                {
                    return false;
                }
                if (CheckRegister.CheckName(Name))
                {
                    return true;
                }
                Console.Clear();
                string s = "Your name must be at least 5 characters long.";
                int middle = (Console.WindowWidth-s.Length)/2;
                Console.SetCursorPosition(middle, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        private bool GetPassword()
        {
            while (true)
            {
                ShowOnConsole("Password");
                Password = Console.ReadLine();
                if (!CheckEsc(Password))
                {
                    return false;
                }
                if (CheckRegister.CheckPassword(Password))
                {
                    return true;
                }
                Console.Clear();
                string s = "Your password must be at least 6 characters long.";
                int middle = (Console.WindowWidth-s.Length)/2;
                Console.SetCursorPosition(middle, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        private bool GetRePassword()
        {
            while (true)
            {
                ShowOnConsole("Password again");
                RePassword = Console.ReadLine();
                if (!CheckEsc(RePassword))
                {
                    return false;
                }
                if (CheckRegister.CheckRePassword(Password,RePassword))
                {
                    return true;
                }
                Console.Clear();
                string s = "Passwords are not the same.";
                int middle = (Console.WindowWidth-s.Length)/2;
                Console.SetCursorPosition(middle, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        private bool GetGoal()
        {
            while (true)
            {
                ShowOnConsole("your monthly goal(km)");
                Goal = CheckData.ChengeDot(Console.ReadLine());
                if (!CheckEsc(Goal))
                {
                    return false;
                }
                if (CheckRegister.CheckFloat(Goal))
                {
                    return true;
                }
                Console.Clear();
                string s = "Goal must be bigger than 0.";
                int middle = (Console.WindowWidth-s.Length)/2;
                Console.SetCursorPosition(middle, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        private bool GetBike()
        {
            while (true)
            {
                ShowOnConsole("your divider for bike workout");
                BikeDivider = CheckData.ChengeDot(Console.ReadLine());
                if (!CheckEsc(BikeDivider))
                {
                    return false;
                }
                if (CheckRegister.CheckFloat(BikeDivider))
                {
                    return true;
                }
                Console.Clear();
                string s = "Divider must be bigger than 0.";
                int middle = (Console.WindowWidth-s.Length)/2;
                Console.SetCursorPosition(middle, Console.CursorTop);
                Console.WriteLine(s);
            }
        }

        private bool GetSwim()
        {
            while (true)
            {
                ShowOnConsole("your divider for swim workout");
                SwimDivider = CheckData.ChengeDot(Console.ReadLine());
                if (!CheckEsc(SwimDivider))
                {
                    return false;
                }
                if (CheckRegister.CheckFloat(SwimDivider))
                {
                    return true;
                }
                Console.Clear();
                string s = "Divider must be bigger than 0.";
                int middle = (Console.WindowWidth-s.Length)/2;
                Console.SetCursorPosition(middle, Console.CursorTop);
                Console.WriteLine(s);
            }
        }
    }
}
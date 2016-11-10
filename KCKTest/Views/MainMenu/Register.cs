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
                if (!GetName())
                {
                    return;
                }
                if (!GetPassword())
                {
                    return;
                }
                if (!GetRePassword())
                {
                    return;
                }
                if (!GetGoal())
                {
                    return;
                }
                if (!GetBike())
                {
                    return;
                }
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
            Console.WriteLine("Wrong data, type again.");
        }

        public void Registered()
        {
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("Type \"esc\" to cancel.");
            Console.WriteLine("Enter "+s+":");
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
            }
        }
    }
}
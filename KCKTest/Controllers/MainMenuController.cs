using System;
using System.Linq;
using KCKTest.Models;
using KCKTest.Views.MainMenu;

namespace KCKTest.Controllers
{
    internal class MainMenuController
    {
        private readonly Model db = new Model();

        /**
         * Kontroler do głownego menu z loginem i rejestracja
         **/
        public MainMenuController()
        {
            while (true)
            {
                var index = new Index();
                switch (index.Selected)
                {
                    case 0:
                        var login = new Login();
                        var user = CheckData.Login(login.Name, login.Password);
                        if (user != null)
                        {
                            var calendarController = new CalendarController(user);
                            break;
                        }
                        login.WrongData();
                        break;
                    case 1:
                        var register = new Register();
                        if (CheckData.Register(register.Name, register.Password, register.RePassword, register.Goal,
                            register.BikeDivider, register.SwimDivider))
                            register.Registered();
                        else
                            register.WrongData();
                        break;
                    case 2:
                        Environment.Exit(0);
                        //exit
                        break;
                }
            }
        }

        
    }
}
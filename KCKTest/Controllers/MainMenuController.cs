using System;
using System.Linq;
using KCKTest.Models;
using KCKTest.Views.Activity;

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
                        var user = Login(login.Name, login.Password);
                        if (user != null)
                        {
                            var calendarController = new CalendarController(user);
                            break;
                        }
                        login.WrongData();
                        break;
                    case 1:
                        var register = new Register();
                        if (Register(register.Name, register.Password, register.RePassword, register.Goal,
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

        /** 
         * prawdopodobnie do zmiany
         * pobieramy z konsoli jako stringi
         * kolejno sprawdzamy tryparsami czy dobrze wpisane
         * trzeba zmienic na wybor poprzez menu/inne rzeczy ulatwiajace wybor
         * na koniec zapis do bazy mySQL poprzez entity
         * id auto increment, nie trzeba podawac
         * return true jak sie udalo
         * false jak nie
        **/ 
        public bool Register(string name, string password, string repassword, string goal, string bikedivider,
            string swimdivider)
        {
            try
            {
                var check_user = db.users.FirstOrDefault(x => x.name == name);
                if (check_user == null)
                    if (password == repassword)
                    {
                        float check_goal;
                        if (float.TryParse(goal, out check_goal))
                        {
                            float check_bikedivider, check_swimdivider;
                            if (float.TryParse(bikedivider, out check_bikedivider) &&
                                float.TryParse(swimdivider, out check_swimdivider))
                            {
                                db.users.Add(new User(name, password, check_goal, check_bikedivider, check_swimdivider));
                                db.SaveChanges();
                                return true;
                            }
                        }
                    }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
        /**
         * To samo co Register
        **/
        public User Login(string name, string password)
        {
            try
            {
                var check_user = db.users.FirstOrDefault(x => (x.name == name) && (x.password == password));
                if (check_user != null)
                {
                    var user = new User(name, password, check_user.goal, check_user.bikedivider, check_user.swimdivider,
                        check_user.idusers);
                    return user;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
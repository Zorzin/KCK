using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.MainMenu
{
    internal class Index
    {
        public Index()
        {
            var menustring = new List<string>();
            menustring.Add("login");
            menustring.Add("register");
            menustring.Add("exit");
            Menu.ShowMenu(menustring);
            Selected = Menu.Selected;
        }

        public int Selected { get; set; }
    }
}
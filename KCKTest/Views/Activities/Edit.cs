using System;
using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Activities
{
    internal static class Edit
    {
        public static int Choose()
        {
            Console.Clear();
            var menuList = new List<string> {"Back", "Type", "Distance", "Date", "Note"};
            Menu.ShowMenu(menuList);
            return Menu.Selected;
        }

        public static void Done()
        {
            Console.Clear();
            Console.WriteLine("Activity edited.");
        }

        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Something goes wrong.");
        }
    }
}
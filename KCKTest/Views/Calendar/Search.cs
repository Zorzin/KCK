using System;
using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    internal static class Search
    {
        public static int Choose()
        {
            Console.Clear();
            Console.WriteLine("Where you want to search?");
            var menuList = new List<string> {"Back", "Date", "Type", "Distance", "Note"};
            Menu.ShowMenu(menuList);
            return Menu.Selected;
        }

        public static string EnterValue()
        {
            Console.Clear();
            Console.WriteLine("Enter what are you looking for:");
            return Console.ReadLine();
        }

        public static void BadValue()
        {
            Console.Clear();
            Console.WriteLine("Bad value.");
        }

        public static void Empty()
        {
            Console.Clear();
            Console.WriteLine("Nothing to show or bad value.");
        }
    }
}
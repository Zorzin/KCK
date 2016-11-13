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
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Where you want to search?");
            Console.CursorTop++;
            var menuList = new List<string> {"Back", "Date", "Type", "Distance", "Note"};
            Menu.ShowMenu(menuList);
            return Menu.Selected;
        }

        public static string EnterValue()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Enter what are you looking for:");
            return Console.ReadLine();
        }

        public static void BadValue()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Bad value.");
        }

        public static void Empty()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Nothing to show or bad value.");
        }
    }
}
using System;
using System.Collections.Generic;
using KCKTest.Controllers;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    internal static class Divider
    {
        public static string Divide { get; set; }

        public static void GetValues()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Enter new divider: ");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Divide = CheckData.ChengeDot(Console.ReadLine());
        }

        public static void Done()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Divider changed.");
        }

        public static void BadValue()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Bad value, divider unchanged.");
        }

        public static int WhichDivider()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Which divider do you want to edit?");
            Console.CursorTop ++;
            var menuList = new List<string>();
            menuList.Add("Exit");
            menuList.Add("Bike");
            menuList.Add("Swim");
            Menu.ShowMenu(menuList);
            return Menu.Selected;
        }
    }
}
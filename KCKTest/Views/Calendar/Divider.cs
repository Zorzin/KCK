using System;
using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    internal static class Divider
    {
        public static string Divide { get; set; }

        public static void GetValues()
        {
            Console.Clear();
            Console.WriteLine("Enter new divider: ");
            Divide = Console.ReadLine();
        }

        public static void Done()
        {
            Console.Clear();
            Console.WriteLine("Divider changed.");
        }

        public static void BadValue()
        {
            Console.Clear();
            Console.WriteLine("Bad value, divider unchanged.");
        }

        public static int WhichDivider()
        {
            Console.Clear();
            Console.WriteLine("Which divider do you want to edit?");
            var menuList = new List<string>();
            menuList.Add("Bike");
            menuList.Add("Swim");
            Menu.ShowMenu(menuList);
            return Menu.Selected;
        }
    }
}
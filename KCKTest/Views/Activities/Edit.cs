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

        public static string EditType()
        {
            Console.Clear();
            Console.WriteLine("Enter new type: ");
            return Console.ReadLine();
        }

        public static string EditDistance()
        {
            Console.Clear();
            Console.WriteLine("Enter new distance: ");
            return Console.ReadLine();
        }

        public static string EditDate()
        {
            Console.Clear();
            Console.WriteLine("Enter new date: ");
            return Console.ReadLine();
        }

        public static string EditNote()
        {
            Console.Clear();
            Console.WriteLine("Enter new note: ");
            return Console.ReadLine();
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
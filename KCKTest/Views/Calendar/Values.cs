using System;
using System.Collections.Generic;
using KCKTest.Models;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    internal static class Values
    {
        public static void ShowValues(User user, float score, int numberofactivities, string lastdate)
        {
            Console.Clear();
            Console.WriteLine("User: " + user.name);
            Console.WriteLine("Goal: " + user.goal);
            Console.WriteLine("Actual score: " + score);
            Console.WriteLine("Swim divider: " + user.swimdivider);
            Console.WriteLine("Bike divider: " + user.bikedivider);
            Console.WriteLine("Number of activities: " + numberofactivities);
            Console.WriteLine("Last activity: " + lastdate);
            var menuList = new List<string> {"Back"};
            Menu.ShowMenu(menuList, Console.CursorTop);
        }
    }
}
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
            int maxlength = 22;
            int length = numberofactivities.ToString().Length;
            int middle = (Console.WindowWidth - (maxlength + length))/2;
            Console.CursorTop++;
            ShowOnMiddle("User: ",middle);
            ShowOnMiddleValues(user.name,middle,maxlength);
            ShowOnMiddle("Goal: ", middle);
            ShowOnMiddleValues(user.goal + " km", middle, maxlength);
            ShowOnMiddle("Actual score: ", middle);
            ShowOnMiddleValues(score +" km", middle, maxlength);
            ShowOnMiddle("Swim divider: ", middle);
            ShowOnMiddleValues(user.swimdivider.ToString(), middle, maxlength);
            ShowOnMiddle("Bike divider: ", middle);
            ShowOnMiddleValues(user.bikedivider.ToString(), middle, maxlength);
            ShowOnMiddle("Number of activities: ", middle);
            ShowOnMiddleValues(numberofactivities.ToString(), middle, maxlength);
            ShowOnMiddle("Last activity: ", middle);
            ShowOnMiddleValues(lastdate, middle, maxlength);


           /* Console.WriteLine(user.name);
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Goal: " + user.goal + " km");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Actual score: " + score + " km");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Swim divider: " + user.swimdivider);
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Bike divider: " + user.bikedivider);
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Number of activities: " + numberofactivities);
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Last activity: " + lastdate);
            Console.SetCursorPosition(middle, Console.CursorTop);*/
            var menuList = new List<string> {"Back"};
            Menu.ShowMenu(menuList, Console.CursorTop);
        }

        private static void ShowOnMiddleValues(string s,int middle,int maxlength)
        {
            Console.SetCursorPosition(middle + maxlength, Console.CursorTop);
            Console.WriteLine(s);
        }

        private static void ShowOnMiddle(string s, int middle)
        {
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.Write(s);
        }
    }
}
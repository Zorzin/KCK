using System;
using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Activities
{
    internal class Info
    {
        public int Selected { get; set; }

        public void ShowValue(Models.Activity activity)
        {
            Console.Clear();
            int maxlength = 10;
            int middle = (Console.WindowWidth - 17)/2;
            ShowOnMiddle("Type: ",middle);
            ShowOnMiddleValues(activity.type,middle,maxlength);

            ShowOnMiddle("Distance: ", middle);
            ShowOnMiddleValues(activity.distance + " km", middle, maxlength);

            ShowOnMiddle("Date: ", middle);
            ShowOnMiddleValues(activity.date.Value.ToString("dd-MM-yyyy"), middle, maxlength);

            ShowOnMiddle("Note: ", middle);
            ShowOnMiddleValues(activity.note, middle, maxlength);
            /*
            Console.WriteLine("Type: " + activity.type);
            Console.WriteLine("Distance: " + activity.distance + " km");
            Console.WriteLine("Date: " + activity.date.Value.ToString("dd-MM-yyyy"));
            Console.WriteLine("Note: " + activity.note);
            */
            var position = Console.CursorTop;
            var menuList = new List<string> {"Edit", "Delete", "Back"};
            Menu.ShowMenu(menuList, position);
            Selected = Menu.Selected;
        }
        private static void ShowOnMiddleValues(string s, int middle, int maxlength)
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
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
            Console.WriteLine("Type: " + activity.type);
            Console.WriteLine("Distance: " + activity.distance);
            Console.WriteLine("Date: " + activity.date.Value.ToString("dd-MM-yyyy"));
            Console.WriteLine("Note: " + activity.note);
            var position = Console.CursorTop;
            var menuList = new List<string> {"Edit", "Delete", "Back"};
            Menu.ShowMenu(menuList, position);
            Selected = Menu.Selected;
        }
    }
}
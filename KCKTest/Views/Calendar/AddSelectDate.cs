using System;
using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    static class AddSelectDate
    {
        public static int GetDate()
        {
            Console.Clear();
            Console.WriteLine("Select date: ");
            var yearList = new List<string> {"Back", "Today", "Yesterday", "Another date"};
            Menu.ShowMenu(yearList);
            return Menu.Selected;
        }
    }
}
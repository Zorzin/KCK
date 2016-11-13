using System;
using System.Collections.Generic;
using System.Globalization;
using KCKTest.Controllers;

namespace KCKTest.Views.layouts
{
    static class AddActivity
    {
        public static int GetDay(int month, int year)
        {
            Console.Clear();
            List<string> dayList = new List<string>();
            dayList.Add("Back");
            for (int i = 0; i < DateTime.DaysInMonth(year, month); i++)
            {
                dayList.Add((i + 1).ToString());
            }
            Menu.ShowMenu(dayList);
            return Menu.Selected;
        }

        public static string GetDistance()
        {
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter \"esc\" to exit.");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter distance [km]: ");
            Console.SetCursorPosition(middle, Console.CursorTop);
            return CheckData.ChengeDot(Console.ReadLine());

        }

        public static int GetMonth()
        {
            Console.Clear();
            List<string> monthList = new List<string>();
            monthList.Add("Exit");
            for (int i = 0; i < 12; i++)
            {
                monthList.Add(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames [i]);
            }
            Menu.ShowMenu(monthList);
            return Menu.Selected;
        }

        public static string GetNote()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter \"esc\" to exit.");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter Note: ");
            Console.SetCursorPosition(middle, Console.CursorTop);
            return Console.ReadLine();
        }

        public static int GetDate()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Select date: ");
            var yearList = new List<string> {"Exit", "Today", "Yesterday", "Another date"};
            Menu.ShowMenu(yearList);
            return Menu.Selected;
        }

        public static int GetActivityType()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Select type: ");
            List<string> typeList = new List<string>() {"Exit","Run","Swim","Bike"};
            Menu.ShowMenu(typeList);
            Console.SetCursorPosition(middle, Console.CursorTop);
            return Menu.Selected;
        }

        public static string GetYear()
        {
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter \"esc\" to exit.");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter Year: ");
            Console.SetCursorPosition(middle, Console.CursorTop);
            return CheckData.ChengeDot(Console.ReadLine());
        }
    }
}

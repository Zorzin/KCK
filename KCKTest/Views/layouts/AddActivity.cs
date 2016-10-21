using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
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
            Console.Clear();
            Console.WriteLine("Enter distance [km]: ");
            Console.WriteLine("Enter \"esc\" to exit.");
            return Console.ReadLine();
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
            Console.WriteLine("Enter Note: ");
            Console.WriteLine("Enter \"esc\" to exit.");
            return Console.ReadLine();
        }

        public static int GetDate()
        {
            Console.Clear();
            Console.WriteLine("Select date: ");
            var yearList = new List<string> {"Exit", "Today", "Yesterday", "Another date"};
            Menu.ShowMenu(yearList);
            return Menu.Selected;
        }

        public static int GetActivityType()
        {
            Console.Clear();
            Console.WriteLine("Select type: ");
            List<string> typeList = new List<string>() {"Exit","Run","Swim","Bike"};
            Menu.ShowMenu(typeList);
            return Menu.Selected;
        }

        public static string GetYear()
        {
            Console.Clear();
            Console.WriteLine("Enter Year: ");
            Console.WriteLine("Enter \"esc\" to exit.");
            return Console.ReadLine();
        }
    }
}

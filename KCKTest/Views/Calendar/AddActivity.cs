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
            return Console.ReadLine();
        }

        public static int GetMonth()
        {
            List<string> monthList = new List<string>();
            monthList.Add("Back");
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
            return Console.ReadLine();
        }

        public static int GetDate()
        {
            Console.Clear();
            Console.WriteLine("Select date: ");
            var yearList = new List<string> {"Back", "Today", "Yesterday", "Another date"};
            Menu.ShowMenu(yearList);
            return Menu.Selected;
        }

        public static int GetActivityType()
        {
            Console.Clear();
            Console.WriteLine("Select type: ");
            List<string> typeList = new List<string>() {"back","run","swim","bike"};
            Menu.ShowMenu(typeList);
            return Menu.Selected;
        }

        public static string GetYear()
        {
            Console.Clear();
            Console.WriteLine("Enter Year: ");
            return Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Views.layouts;

namespace KCKTest.Controllers
{
    static class GetFromUser
    {
        public static string GetTypeFromUser()
        {
            string type=null;
            int i_type = AddActivity.GetActivityType();
            switch (i_type)
            {
                case 0:
                    return null;
                    break;
                case 1:
                    type = "run";
                    break;
                case 2:
                    type = "swim";
                    break;
                case 3:
                    type = "bike";
                    break;
            }
            return type;
        }

        public static DateTime? GetDateFromUser()
        {
            DateTime date = DateTime.Today.AddYears(-500);
            int i_date = AddActivity.GetDate();
            switch (i_date)
            {
                case 0:
                    return null;
                    break;
                case 1:
                    date = DateTime.Today;
                    break;
                case 2:
                    date = DateTime.Today.AddDays(-1);
                    break;
                case 3:
                    DateTime? d_date = GetDate();

                    if (d_date == null) // czyli exit
                    {
                        return null;
                    }
                    date = d_date.Value;
                    break;
            }
            return date;
        }

        public static float? GetDistanceFromUser()
        {
            float? d_distance = GetDistance();
            if (d_distance == null)
            {
                return null;
            }
            return d_distance;
            
        }

        public static string GetNoteFromUser()
        {
            string note = AddActivity.GetNote();
            return note;
        }

        private static DateTime? GetDate()
        {
            DateTime date;
            int year;
            Console.Clear();
            while (true) //dopoki sie uda lub wpisze "esc"
            {
                string s_year = AddActivity.GetYear();

                if (s_year == "esc")
                {
                    return null;
                }
                else if (!int.TryParse(s_year, out year))
                {
                    Console.Clear();
                    string s = "Year must be bigger than 0.";
                    int middle = (Console.WindowWidth-s.Length)/2;
                    Console.SetCursorPosition(middle, Console.CursorTop);
                    Console.WriteLine(s);
                }
                else if (year<1 || year>DateTime.Today.Year)
                {
                    Console.Clear();
                    string s = "Year must be bigger than 0 and not bigger than actual year.";
                    int middle = (Console.WindowWidth-s.Length)/2;
                    Console.SetCursorPosition(middle, Console.CursorTop);
                    Console.WriteLine(s);
                }
                else
                {
                    break;
                }
            }
            int month = AddActivity.GetMonth();
            if (month == 0) //back
            {
                return null;
            }
            int day = AddActivity.GetDay(month, year);
            if (day == 0)
            {
                return null;
            }
            date = new DateTime(year, month, day);
            return date;
        }
        private static float? GetDistance()
        {
            Console.Clear();
            while (true)
            {
                string s_distance = AddActivity.GetDistance();
                if (s_distance == "esc")
                {
                    return null;
                }
                float distance;
                if (!float.TryParse(s_distance, out distance))
                {
                    Console.Clear();
                    string s = "Distance must be bigger than 0";
                    int middle = (Console.WindowWidth-s.Length)/2;
                    Console.SetCursorPosition(middle, Console.CursorTop);
                    Console.WriteLine(s);
                }
                else if (distance<0)
                {
                    Console.Clear();
                    string s = "Distance must be bigger than 0";
                    int middle = (Console.WindowWidth-s.Length)/2;
                    Console.SetCursorPosition(middle, Console.CursorTop);
                    Console.WriteLine(s);
                }
                else
                {
                    return distance;
                }
            }
        }
    }
}

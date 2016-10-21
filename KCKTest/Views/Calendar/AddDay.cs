using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    static class AddDay
    {
        public static int GetDay(int month, int year)
        {
            List<string> dayList = new List<string>();
            for (int i = 0; i < DateTime.DaysInMonth(year,month); i++)
            {
                dayList.Add((i+1).ToString());
            }
            Menu.ShowMenu(dayList);
            return Menu.Selected;
        }
    }
}

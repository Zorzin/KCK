using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    static class AddMonth
    {
        public static int GetMonth()
        {
            List<string> monthList = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                monthList.Add(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames [i]);
            }
            Menu.ShowMenu(monthList);
            return Menu.Selected;
        }
    }
}

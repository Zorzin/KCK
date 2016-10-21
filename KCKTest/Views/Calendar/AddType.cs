using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    static class AddType
    {
        public static int GetType()
        {
            Console.Clear();
            Console.WriteLine("Select type: ");
            List<string> typeList = new List<string>() {"back","run","swim","bike"};
            Menu.ShowMenu(typeList);
            return Menu.Selected;
        }
    }
}

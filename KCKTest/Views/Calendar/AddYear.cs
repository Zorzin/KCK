using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCKTest.Views.Calendar
{
    static class AddYear
    {
        public static string GetYear()
        {
            Console.Clear();
            Console.WriteLine("Enter Year: ");
            return Console.ReadLine();
        }
    }
}

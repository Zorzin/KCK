using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCKTest.Views.Calendar
{
    static class AddDistance
    {
        public static string GetDistance()
        {
            Console.Clear();
            Console.WriteLine("Enter distance [km]: ");
            return Console.ReadLine();
        }
    }
}

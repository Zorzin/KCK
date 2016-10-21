using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCKTest.Views.Calendar
{
    static class AddNote
    {
        public static string GetNote()
        {
            Console.Clear();
            Console.WriteLine("Enter Note: ");
            return Console.ReadLine();
        }
    }
}

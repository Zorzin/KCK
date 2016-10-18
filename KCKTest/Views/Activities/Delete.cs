using System;

namespace KCKTest.Views.Activities
{
    internal static class Delete
    {
        public static void Deleted()
        {
            Console.Clear();
            Console.WriteLine("Activity deleted.");
        }

        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Something goes wrong.");
        }
    }
}
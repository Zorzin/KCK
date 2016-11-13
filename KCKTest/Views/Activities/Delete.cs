using System;

namespace KCKTest.Views.Activities
{
    internal static class Delete
    {
        public static void Deleted()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Activity deleted.");
        }

        public static void Error()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Something goes wrong.");
        }
    }
}
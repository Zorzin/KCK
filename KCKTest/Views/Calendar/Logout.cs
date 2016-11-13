using System;

namespace KCKTest.Views.Calendar
{
    internal static class Logout
    {
        public static void Done()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Logout done");
        }
    }
}
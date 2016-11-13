using System;
using KCKTest.Controllers;

namespace KCKTest.Views.Calendar
{
    internal static class Goal
    {
        public static string Newgoal { get; set; }

        public static void GetValues()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Enter new goal [km]: ");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Newgoal = CheckData.ChengeDot(Console.ReadLine());
        }

        public static void BadValue()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Bad vlaue, goal unchanged.");
        }

        public static void Done()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Goal changed.");
        }
    }
}
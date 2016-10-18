using System;

namespace KCKTest.Views.Calendar
{
    internal static class Goal
    {
        public static string Newgoal { get; set; }

        public static void GetValues()
        {
            Console.Clear();
            Console.WriteLine("Enter new goal: ");
            Newgoal = Console.ReadLine();
        }

        public static void BadValue()
        {
            Console.Clear();
            Console.WriteLine("Bad vlaue, goal unchanged.");
        }

        public static void Done()
        {
            Console.Clear();
            Console.WriteLine("Goal changed.");
        }
    }
}
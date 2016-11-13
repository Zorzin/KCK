using System;

namespace KCKTest.Views.Calendar
{
    internal static class ChangePassword
    {
        public static string Password { get; set; }
        public static string Repassword { get; set; }

        public static void Change()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Enter new Password: ");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Password = Console.ReadLine();
            Console.SetCursorPosition(middle, Console.CursorTop);
            Console.WriteLine("Enter new password again:");
            Console.SetCursorPosition(middle, Console.CursorTop);
            Repassword = Console.ReadLine();
        }

        public static void Done()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Password changed.");
        }

        public static void WrongData()
        {
            Console.Clear();
            int middle = (Console.WindowWidth-20)/2;
            Console.SetCursorPosition(middle, Console.CursorTop + 1);
            Console.WriteLine("Wrong data, password unchanged.");
        }
    }
}
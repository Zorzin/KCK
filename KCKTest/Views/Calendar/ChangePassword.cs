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
            Console.WriteLine("Enter new Password: ");
            Password = Console.ReadLine();
            Console.WriteLine("Enter new password again:");
            Repassword = Console.ReadLine();
        }

        public static void Done()
        {
            Console.Clear();
            Console.WriteLine("Password changed.");
        }

        public static void WrongData()
        {
            Console.Clear();
            Console.WriteLine("Wrong data, password unchanged.");
        }
    }
}
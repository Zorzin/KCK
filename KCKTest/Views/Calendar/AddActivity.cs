using System;

namespace KCKTest.Views.Calendar
{
    internal class AddActivity
    {
        public AddActivity()
        {
            Type = null;
            Distance = null;
            Date = null;
            GetValues();
        }

        public string Type { get; set; }
        public string Distance { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }

        public void GetValues()
        {
            Console.Clear();
            Console.WriteLine("Enter Type(run/bike/swim): ");
            Type = Console.ReadLine();
            Console.WriteLine("Enter Distance: ");
            Distance = Console.ReadLine();
            Console.WriteLine("Enter Date(YYYY-MM-DD):");
            Date = Console.ReadLine();
            Console.WriteLine("Enter note to activity: ");
            Note = Console.ReadLine();
        }

        public void WrongData()
        {
            Console.Clear();
            Console.WriteLine("Wrong data, please enter again");
        }

        public void Added()
        {
            Console.Clear();
            Console.WriteLine("Activity successful added.");
        }
    }
}
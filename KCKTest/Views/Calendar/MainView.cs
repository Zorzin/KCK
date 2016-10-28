using System;
using System.Collections.Generic;
using KCKTest.Models;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Calendar
{
    internal class MainView
    {
        public float score;
        public User user;

        public int Selected { get; set; }

        public void Show()
        {
            ShowScore();
            ShowValues();
        }

        private void ShowScore()
        {
            Console.SetCursorPosition(0, 1);
            Console.Write("Goal: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(user.goal + "km" + Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Score: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(score + "km" + Environment.NewLine);
        }

        private void ShowValues()
        {
            var menustring = new List<string>
            {
                "Add",
                "Search activities",
                "Show activities",
                "Logout",
                "Change goal",
                "Change dividers",
                "Change password",
                "Show informations",
                "Exit"
            };
            Menu.ShowMenu(menustring, Console.CursorTop);
            Selected = Menu.Selected;
        }
    }
}
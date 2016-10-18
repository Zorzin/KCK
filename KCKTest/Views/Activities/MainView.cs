using System.Collections.Generic;
using KCKTest.Views.layouts;

namespace KCKTest.Views.Activities
{
    internal class MainView
    {
        private readonly List<string> activities;

        public MainView(List<string> activities)
        {
            this.activities = activities;
            ShowValues();
        }

        public int Selected { get; set; }

        public void ShowValues()
        {
            Menu.ShowMenu(activities);
            Selected = Menu.Selected;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using KCKTest.Models;
using KCKTest.Views.Activities;
using KCKTest.Views.Calendar;
using MainView = KCKTest.Views.Calendar.MainView;

namespace KCKTest.Controllers
{
    internal class CalendarController
    {
        private readonly Model db = new Model();
        public User user;

        /**
         * Kontroler do drugiego menu, po zalogowaniu
        **/
        public CalendarController(User user)
        {
            this.user = user;
            while (true)
            {
                var mainView = new MainView();
                mainView.user = user;
                mainView.score = GetScore();
                mainView.Show();
                switch (mainView.Selected)
                {
                    case 0: //add

                        AddActivity();
                        break;
                    case 1: //search
                        var search = Search.Choose();
                        if (search == 0)
                        {
                            Back.Clear();
                            break;
                        }
                        var searchlist = GetSearchList(search);
                        if ((searchlist == null) || (searchlist.Count == 0))
                        {
                            Search.Empty();
                        }
                        else
                        {
                            var searchactivitiesController = new ActivitiesContoller(searchlist);
                        }
                        break;
                    case 2: //show
                        var activitiesController = new ActivitiesContoller(LoadList());
                        break;
                    case 3: //logout
                        user = null;
                        Logout.Done();
                        return;
                    case 4: //changegoal
                        Goal.GetValues();
                        if (CheckGoal())
                            Goal.Done();
                        else
                            Goal.BadValue();
                        break;
                    case 5: //setdivider
                        var whichdivider = Divider.WhichDivider();
                        Divider.GetValues();
                        switch (whichdivider)
                        {
                            case 0:
                                if (CheckBikeDivider())
                                    Divider.Done();
                                else
                                    Divider.BadValue();
                                break;
                            case 1:
                                if (CheckSwimDivider())
                                    Divider.Done();
                                else
                                    Divider.BadValue();
                                break;
                        }
                        break;
                    case 6: //changepassword
                        ChangePassword.Change();
                        if (CheckPassword())
                            ChangePassword.Done();
                        else
                            ChangePassword.WrongData();
                        break;
                    case 7: //Show values
                        Values.ShowValues(user, GetScore(), GetNumberOfActivities(), GetLastDate());
                        Back.Clear();
                        break;
                    case 8: //exit
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddActivity()
        {
            string type;
            int i_type = Views.Calendar.AddActivity.GetActivityType();
            switch (i_type)
            {
                case 0:
                    return;
                    break;
                case 1:
                    type = "run";
                    break;
                case 2:
                    type = "swim";
                    break;
                case 3:
                    type = "bike";
                    break;
            }
            DateTime date;
            int i_date = Views.Calendar.AddActivity.GetDate();
            switch (i_date)
            {
                case 0:
                    return;
                    break;
                case 1:
                    date = DateTime.Today;
                    break;
                case 2:
                    date = DateTime.Today.AddDays(1); //minus jeden?
                    break;
                case 3:
                    if (GetDate()==null)
                    {
                        return;
                    }
                    break;
            }
            float distance;
            string s_distance = Views.Calendar.AddActivity.GetDistance();
            if (!float.TryParse(s_distance, out distance))
            {
                return;
            }
            string note = Views.Calendar.AddActivity.GetNote();
        }

        private DateTime? GetDate()
        {
            DateTime date;
            string s_year = Views.Calendar.AddActivity.GetYear();
            int year;
            if (!int.TryParse(s_year,out year))
            {
                return null;
            }
            int month = Views.Calendar.AddActivity.GetMonth();
            if (month==0) //back
            {
                return null;
            }
            int day = Views.Calendar.AddActivity.GetDay(month, year);
            if (day==0)
            {
                return null;
            }
            date = new DateTime(year,month,day);
            return date;
        }

        private int GetNumberOfActivities()
        {
            var result = db.activities.Where(x => x.userid == user.idusers);
            return result.Count();
        }

        private float GetScore()
        {
            var result =
                db.activities.Where(x => (x.userid == user.idusers) && (x.date.Value.Month == DateTime.Today.Month));
            float score = 0;
            foreach (var activity in result)
            {
                switch (activity.type)
                {
                    case "run":
                        score += activity.distance;
                        break;
                    case "swim":
                        score += (activity.distance / user.swimdivider);
                        break;
                    case "bike":
                        score += (activity.distance / user.bikedivider);
                        break;
                }
                
            }
                
            return score;
        }

        private string GetLastDate()
        {
            var date = (from m in db.activities select m.date).Max();
            if (date != null)
                return date.Value.ToString("dd-MM-yyyy");
            return null;
        }

        /**
         * Mysle ze trzeba to bedzie zmienic na bardziej przyjazne, ale:
         * @search: opcja ktora zostala wybrana do wyszukiwania
         * switch po @search
         * sprawdzanie czy zostalo dobrze podane, jesli tak to zapis do bazy
        **/
        private List<Activity> GetSearchList(int search)
        {
            var activities = new List<Activity>();
            switch (search)
            {
                case 1: //date
                    DateTime date;
                    if (DateTime.TryParse(Search.EnterValue(), out date))
                    {
                        var dateresult = db.activities.Where(x => (x.userid == user.idusers) && (x.date == date));
                        foreach (var activity in dateresult)
                            activities.Add(activity);
                    }
                    else
                    {
                        Search.BadValue();
                        return null;
                    }
                    break;
                case 2: //type
                    var type = Search.EnterValue();
                    if ((type == "run") || (type == "bike") || (type == "swim"))
                    {
                        var typeresult = db.activities.Where(x => (x.userid == user.idusers) && (x.type == type));
                        foreach (var activity in typeresult)
                            activities.Add(activity);
                    }
                    else
                    {
                        Search.BadValue();
                        return null;
                    }
                    break;
                case 3: //distance
                    float distance;
                    if (float.TryParse(Search.EnterValue(), out distance))
                    {
                        var distanceresult =
                            db.activities.Where(
                                x => (x.userid == user.idusers) && (Math.Abs(x.distance - distance) < 0.0001));
                        foreach (var activity in distanceresult)
                            activities.Add(activity);
                    }
                    else
                    {
                        Search.BadValue();
                        return null;
                    }
                    break;
                case 4: //note
                    var note = Search.EnterValue();
                    var noteresult = from m in db.activities
                        where m.note.Contains(note) && (m.userid == user.idusers)
                        select m;
                    foreach (var activity in noteresult)
                        activities.Add(activity);
                    break;
            }
            return activities;
        }

        private bool CheckGoal()
        {
            float goal;
            if (float.TryParse(Goal.Newgoal, out goal))
            {
                var result = db.users.FirstOrDefault(x => x.idusers == user.idusers);
                result.goal = goal;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CheckSwimDivider()
        {
            float divider;
            if (float.TryParse(Divider.Divide, out divider))
            {
                var result = db.users.FirstOrDefault(x => x.idusers == user.idusers);
                result.swimdivider = divider;
                user.swimdivider = divider;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CheckBikeDivider()
        {
            float divider;
            if (float.TryParse(Divider.Divide, out divider))
            {
                var result = db.users.FirstOrDefault(x => x.idusers == user.idusers);
                result.bikedivider = divider;
                user.bikedivider = divider;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private bool CheckPassword()
        {
            if (ChangePassword.Password == ChangePassword.Repassword)
            {
                var result = db.users.FirstOrDefault(x => x.idusers == user.idusers);
                result.password = ChangePassword.Password;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        private List<Activity> LoadList()
        {
            var ActivityList = new List<Activity>();
            var activities = db.activities.Where(a => a.userid == user.idusers);
            foreach (var activity in activities)
                ActivityList.Add(activity);
            return ActivityList;
        }

        private bool CheckActivity(string type, string distance, string date, string note)
        {
            if ((type == "bike") || (type == "run") || (type == "swim"))
            {
                float f_distance;
                if (float.TryParse(distance, out f_distance))
                {
                    DateTime dt_date;
                    if (DateTime.TryParse(date, out dt_date))
                        try
                        {
                            db.activities.Add(new Activity(type, f_distance, dt_date, user.idusers, note));
                            db.SaveChanges();
                            return true;
                        }
                        catch (Exception e)
                        {
                            return false;
                        }
                }
            }
            return false;
        }
    }
}
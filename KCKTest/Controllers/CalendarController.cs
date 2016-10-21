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
                mainView.score = GetFromDB.GetScore(user);
                mainView.Show();
                switch (mainView.Selected)
                {
                    case 0: //add
                        if (AddActivity())
                        {
                            //powodzenia
                            Back.Clear();
                        }
                        else
                        {
                            //niepowodzenie
                            Back.Clear();
                        }
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
                        var activitiesController = new ActivitiesContoller(GetFromDB.LoadList(user));
                        break;
                    case 3: //logout
                        user = null;
                        Logout.Done();
                        return;
                    case 4: //changegoal
                        Goal.GetValues();
                        if (Check.CheckGoal(user))
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
                                if (Check.CheckBikeDivider(user))
                                    Divider.Done();
                                else
                                    Divider.BadValue();
                                break;
                            case 1:
                                if (Check.CheckSwimDivider(user))
                                    Divider.Done();
                                else
                                    Divider.BadValue();
                                break;
                        }
                        break;
                    case 6: //changepassword
                        ChangePassword.Change();
                        if (Check.CheckPassword(user))
                            ChangePassword.Done();
                        else
                            ChangePassword.WrongData();
                        break;
                    case 7: //Show values
                        Values.ShowValues(user, GetFromDB.GetScore(user), GetFromDB.GetNumberOfActivities(user), GetFromDB.GetLastDate(user));
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


        /**
         * dodawanie aktywnosci
        **/
        private bool AddActivity()
        {
            var type = GetFromUser.GetTypeFromUser();
            if (type==null)
            {
                return false;
            }

            var d_date = GetFromUser.GetDateFromUser();
            if (d_date==null)
            {
                return false;
            }
            DateTime date = d_date.Value;

            var d_distance = GetFromUser.GetDistanceFromUser();
            if (d_distance==null)
            {
                return false;
            }
            var distance = d_distance.Value;

            var note = GetFromUser.GetNoteFromUser();
            if (note == "esc")
            {
                return false;
            }

            return AddActivityToDB(type, distance, date, note);
        }

        
        private bool AddActivityToDB(string type, float distance, DateTime date, string note)
        {
            try
            {
                db.activities.Add(new Models.Activity(type, distance, date, user.idusers, note));
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /**
         * koniec dodawania
        **/

        /**
         * Wyszukiwanie
         * Ten sam mechanizm co przy dodawaniu
        **/
        private List<Models.Activity> GetSearchList(int search)
        {
            var activities = new List<Models.Activity>();
            switch (search)
            {
                case 1: //date
                    DateTime? d_date = GetFromUser.GetDateFromUser();
                    if (d_date==null)
                    {
                        return null;
                    }
                    DateTime date = d_date.Value;
                    var dateresult = db.activities.Where(x => (x.userid == user.idusers) && (x.date == date));
                    foreach (var activity in dateresult)
                        activities.Add(activity);
                    break;
                case 2: //type
                    var type = GetFromUser.GetTypeFromUser();
                    if (type == null)
                    {
                        return null;
                    }
                    var typeresult = db.activities.Where(x => (x.userid == user.idusers) && (x.type == type));
                    foreach (var activity in typeresult)
                    {
                        activities.Add(activity);
                    }
                    break;
                case 3: //distance
                    var d_distance = GetFromUser.GetDistanceFromUser();
                    if (d_distance == null)
                    {
                        return null;
                    }
                    var distance = d_distance.Value;
                    var distanceresult = db.activities.Where( x => (x.userid == user.idusers) && (Math.Abs(x.distance - distance) < 0.0001));
                    foreach (var activity in distanceresult)
                    {
                        activities.Add(activity);
                    }
                    break;
                case 4: //note
                    var note = GetFromUser.GetNoteFromUser();
                    if (note == "esc")
                    {
                        return null;
                    }
                    var noteresult = from m in db.activities
                        where m.note.Contains(note) && (m.userid == user.idusers)
                        select m;
                    foreach (var activity in noteresult)
                        activities.Add(activity);
                    break;
            }
            return activities;
        }

        
    }
}
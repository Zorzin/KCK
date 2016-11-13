using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Models;

namespace KCKTest.Logic
{
    static class SearchDB
    {
        public static Model db = new Model();
        public static List<Activity> SearchDate(DateTime date, User user)
        {
            List<Activity> activities = new List<Activity>();
            var dateresult = db.activities.Where(x => (x.userid == user.idusers) && (x.date == date));
            foreach (var activity in dateresult)
                activities.Add(activity);
            return activities;
        }

        public static List<Activity> SearchType(string type, User user)
        {
            List<Activity> activities = new List<Activity>();
            var typeresult = db.activities.Where(x => (x.userid == user.idusers) && (x.type == type));
            foreach (var activity in typeresult)
            {
                activities.Add(activity);
            }
            return activities;
        }
        public static List<Activity> SearchDistance(float distance, User user)
        {
            List<Activity> activities = new List<Activity>();
            var distanceresult = db.activities.Where( x => (x.userid == user.idusers) && (Math.Abs(x.distance - distance) < 0.0001));
            foreach (var activity in distanceresult)
            {
                activities.Add(activity);
            }
            return activities;
        }
        public static List<Activity> SearchNote(string note, User user)
        {
            List<Activity> activities = new List<Activity>();
            var noteresult = from m in db.activities
                             where m.note.Contains(note) && (m.userid == user.idusers)
                             select m;
            foreach (var activity in noteresult)
                activities.Add(activity);
            return activities;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Models;

namespace KCKTest.Controllers
{
    static class GetFromDB
    {
        static Model db = new Model();

        public static int GetNumberOfActivities(User user)
        {
            var result = db.activities.Where(x => x.userid == user.idusers);
            return result.Count();
        }

        public static float GetScore(User user)
        {
            var result =
                db.activities.Where(x => (x.userid == user.idusers) && (x.date.Value.Month == DateTime.Today.Month) && (x.date.Value.Year == DateTime.Today.Year));
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

        public static string GetLastDate(User user)
        {
            var date = (from m in db.activities where m.userid == user.idusers select m.date).Max();
            if (date != null)
                return date.Value.ToString("dd-MM-yyyy");
            return null;
        }

        public static List<Activity> LoadList(User user)
        {
            var ActivityList = new List<Activity>();
            var activities = db.activities.Where(a => a.userid == user.idusers);
            foreach (var activity in activities)
                ActivityList.Add(activity);
            return ActivityList;
        }
    }
}

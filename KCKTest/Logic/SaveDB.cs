using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Models;

namespace KCKTest.Logic
{
    static class SaveDB
    {
        public static Model db = new Model();
        public static bool SaveEditType(Activity activity, string type)
        {
            if (type != null)
            {
                var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
                if (result != null)
                {
                    result.type = type;
                    activity.type = type;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        public static bool SaveEditDistance(Activity activity, float? d_distance)
        {
            if (d_distance == null)
                return false;
            var distance = d_distance.Value;
            var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
            if (result != null)
            {
                result.distance = distance;
                activity.distance = distance;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool SaveEditDate(Activity activity, DateTime? d_date)
        {
            if (d_date == null)
                return false;
            var date = d_date.Value;
            var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
            if (result != null)
            {
                result.date = date;
                activity.date = date;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool SaveEditNote(Activity activity, string note)
        {
            if (note == null)
            {
                return false;
            }
            var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
            if (result != null)
            {
                result.note = note;
                activity.note = note;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public static bool DeleteActivity(Activity activity, List<Activity> Activities)
        {
            try
            {
                var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
                db.activities.Remove(result);
                Activities.Remove(activity);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static bool AddActivityToDB(User user,string type, float distance, DateTime date, string note)
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using KCKTest.Models;
using KCKTest.Views.Activities;

namespace KCKTest.Controllers
{
    public class ActivitiesContoller
    {
        private readonly Model db = new Model();
        public List<Activity> Activities;

        /**
         * Kotroler do wyswietlania i edycji aktywnosci
        **/
        public ActivitiesContoller(List<Activity> activities)
        {
            Back.Clear();
            Activities = activities;
            var stringactivitiesList = new List<string>();
            while (true)
            {
                /** 
                 * Tutaj, bo przy edycji musi sie zaktualizowac, 
                 * wiec za kazdym razem trzeba czyscic i tworzyc liste stringow na nowo  
                **/
                stringactivitiesList.Clear();
                stringactivitiesList.Add("Back");
                foreach (var activity in Activities)
                    stringactivitiesList.Add(activity.ToString());
                /** END  **/

                var mainView = new MainView(stringactivitiesList);
                if (mainView.Selected == 0) //back
                {
                    Back.Clear();
                    return;
                }

                var info = new Info();
                var currentactivity = Activities[mainView.Selected - 1];
                info.ShowValue(currentactivity); //wyswietl dane o wybranej aktywnosci
                switch (info.Selected)
                {
                    case 0:
                        //edit
                        switch (Edit.Choose())
                        {
                            case 0: //back
                                Back.Clear();
                                break;
                            case 1: //type
                                if (CheckEditType(currentactivity, Edit.EditType()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 2: //distance
                                if (CheckEditDistance(currentactivity, Edit.EditDistance()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 3: //date
                                if (CheckEditDate(currentactivity, Edit.EditDate()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 4: //note
                                if (CheckEditNote(currentactivity, Edit.EditNote()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                        }
                        break;
                    case 1: //delete
                        if (DeleteActivity(currentactivity))
                        {
                            Delete.Deleted();
                            currentactivity = null;
                        }
                        else
                            Delete.Error();
                        break;
                    case 2: //back
                        Back.Clear();
                        break;
                }
            }
        }

        private bool CheckEditType(Activity activity, string type)
        {
            if ((type == "run") || (type == "bike") || (type == "swim"))
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

        private bool CheckEditDistance(Activity activity, string distance)
        {
            float ch_distance;
            if (float.TryParse(distance, out ch_distance))
            {
                var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
                if (result != null)
                {
                    result.distance = ch_distance;
                    activity.distance = ch_distance;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool CheckEditDate(Activity activity, string date)
        {
            DateTime ch_date;
            if (DateTime.TryParse(date, out ch_date))
            {
                var result = db.activities.FirstOrDefault(x => x.idactivities == activity.idactivities);
                if (result != null)
                {
                    result.date = ch_date;
                    activity.date = ch_date;
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool CheckEditNote(Activity activity, string note)
        {
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

        private bool DeleteActivity(Activity activity)
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
    }
}
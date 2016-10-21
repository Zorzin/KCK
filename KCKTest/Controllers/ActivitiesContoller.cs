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
                                if (SaveEditType(currentactivity, GetFromUser.GetTypeFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 2: //distance
                                if (SaveEditDistance(currentactivity, GetFromUser.GetDistanceFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 3: //date
                                if (SaveEditDate(currentactivity, GetFromUser.GetDateFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 4: //note
                                if (SaveEditNote(currentactivity, GetFromUser.GetNoteFromUser()))
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

        private bool SaveEditType(Activity activity, string type)
        {
            if (type == null)
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

        private bool SaveEditDistance(Activity activity, float? d_distance)
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

        private bool SaveEditDate(Activity activity, DateTime? d_date)
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

        private bool SaveEditNote(Activity activity, string note)
        {
            if (note==null)
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
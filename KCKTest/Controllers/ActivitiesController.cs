using System;
using System.Collections.Generic;
using System.Linq;
using KCKTest.Logic;
using KCKTest.Models;
using KCKTest.Views.Activities;
using KCKTest.Views.layouts;

namespace KCKTest.Controllers
{
    public class ActivitiesController
    {
        private readonly Model db = new Model();
        public List<Activity> Activities;

        /**
         * Kotroler do wyswietlania i edycji aktywnosci
        **/

        public ActivitiesController(List<Activity> activities)
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
                                if (SaveDB.SaveEditType(currentactivity, GetFromUser.GetTypeFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 2: //distance
                                if (SaveDB.SaveEditDistance(currentactivity, GetFromUser.GetDistanceFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 3: //date
                                if (SaveDB.SaveEditDate(currentactivity, GetFromUser.GetDateFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                            case 4: //note
                                if (SaveDB.SaveEditNote(currentactivity, GetFromUser.GetNoteFromUser()))
                                    Edit.Done();
                                else
                                    Edit.Error();
                                break;
                        }
                        break;
                    case 1: //delete
                        if (SaveDB.DeleteActivity(currentactivity,Activities))
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

       
    }
}
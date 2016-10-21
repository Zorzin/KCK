using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Models;
using KCKTest.Views.Calendar;

namespace KCKTest.Controllers
{
    static class Check
    {
        public static readonly Model db = new Model();

        public static bool CheckPassword(User user)
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

        public static bool CheckBikeDivider(User user)
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

        public static bool CheckSwimDivider(User user)
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

        public static bool CheckGoal(User user)
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


    }
}

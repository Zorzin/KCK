using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCKTest.Models;

namespace KCKTest.Controllers
{
    class CheckData
    {
        private static Model db = new Model();
        
        public static string ChengeDot(string number)
        {
            string input =  number.Replace('.', ',');
            string[] output = new string[input.Length];
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input [i] == ',')
                {
                    if (count == 0)
                    {
                        count++;
                    }
                    else
                    {
                        output [i] = "";
                        continue;
                    }
                }
                output [i] = input [i].ToString();
            }
            StringBuilder sb = new StringBuilder();
            foreach (var s in output)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public static bool Register(string name, string password, string repassword, string goal, string bikedivider,
            string swimdivider)
        {
            try
            {
                var check_user = db.users.FirstOrDefault(x => x.name == name);
                if (check_user == null)
                    if (password == repassword)
                    {
                        float check_goal;
                        if (float.TryParse(goal, out check_goal))
                        {
                            float check_bikedivider, check_swimdivider;
                            if (float.TryParse(bikedivider, out check_bikedivider) &&
                                float.TryParse(swimdivider, out check_swimdivider))
                            {
                                db.users.Add(new User(name, password, check_goal, check_bikedivider, check_swimdivider));
                                db.SaveChanges();
                                return true;
                            }
                        }
                    }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
        /**
         * To samo co Register
        **/
        public static User Login(string name, string password)
        {
            try
            {
                var check_user = db.users.FirstOrDefault(x => (x.name == name) && (x.password == password));
                if (check_user != null)
                {
                    var user = new User(name, password, check_user.goal, check_user.bikedivider, check_user.swimdivider,
                        check_user.idusers);
                    return user;
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KCKTest.Logic
{
    class CheckRegister
    {
        public static bool CheckName(string name)
        {
            if (name.Length<5)
            {
                return false;
            }
            return true;
        }

        public static bool CheckPassword(string password)
        {
            if (password.Length<6)
            {
                return false;
            }
            return true;
        }

        public static bool CheckRePassword(string password,string repassword)
        {
            if (password!=repassword)
            {
                return false;
            }
            return true;
        }

        public static bool CheckFloat(string test)
        {
            float result;
            if (!float.TryParse(test, out result))
            {
                return false;
            }
            if (result < 0)
            {
                return false;
            }
            return true;
        }
    }
}

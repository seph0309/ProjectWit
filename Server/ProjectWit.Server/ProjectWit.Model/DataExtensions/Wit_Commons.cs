using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWit.Model
{
    public static class Wit_Commons
    {
        public const string LoginPath = "/Account/Login";
        public static bool IsStringGUID(string guid)
        {
            try
            {
                new Guid(guid);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}

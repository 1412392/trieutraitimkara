using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrieuTraiTimKara.Common
{
    public class Helper
    {
        public static int GetRandom()
        {
            Random a = new Random();
            return a.Next(1, int.MaxValue) - 1;
        }
    }
}
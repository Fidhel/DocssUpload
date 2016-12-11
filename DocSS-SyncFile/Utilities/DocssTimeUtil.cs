using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocSS_SyncFile.Utilities
{
    class DocssTimeUtil
    {
         private static DateTime startTime = DateTime.Now;
         private static bool checkDir = true;
         private static int x = 0;

         public static bool isTimeCheckDir() {
            bool b = checkDir;

            if (x != 0)
            {
                DateTime t = startTime.AddHours(4);
                if (DateTime.Now > t)
                {
                    b = true;
                    checkDir = false;
                }
            }else {
                x++;
                checkDir = false;
            }
            return b;
         }

    }
}

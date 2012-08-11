/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: hard disk stuff
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace sysup
{
    class HardDrive
    {
        public string DoHardDrive()
        {
            string ReturnHD = "";
           foreach (DriveInfo labol in DriveInfo.GetDrives())
          
              if (labol.IsReady)
              {
                   ReturnHD = ReturnHD + String.Format("{0} - Total Size: {1} GB\n", labol.Name, labol.TotalSize / 1073741824);
              }
         

            return ReturnHD;
        }

    }
}

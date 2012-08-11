/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: video card stuff. sadly no support for ibm pga
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Management.Instrumentation;

namespace sysup
{
    class VideoCard
    {
        public string GetVideoCardWMI()
        {
            string ReturnGFX = "IBM MDA";
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_VideoController");

            foreach (ManagementObject GFXObject in Search.Get())
            {
                //double RAMBytes = Convert.ToDouble(Mobject["TotalPhysicalMemory"])); //i don't remember why the ram code was in here to begin with
                //double RAMBytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                string devid = (Convert.ToString(GFXObject["Description"]));
                int cur_horiz = (Convert.ToInt32(GFXObject["CurrentHorizontalResolution"]));
                int cur_vert = (Convert.ToInt32(GFXObject["CurrentVerticalResolution"]));
                ReturnGFX = String.Format("{0} ({1}x{2})",devid,cur_horiz,cur_vert);
                //ReturnRAM = String.Format("{0} MB", RAMBytes / 1048576);
            }
            return ReturnGFX;
        }
    }
}

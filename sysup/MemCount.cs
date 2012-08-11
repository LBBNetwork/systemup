/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: memory stuff
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Management.Instrumentation;

namespace sysup
{
    class MemCount
    {
        public string GetMemCount()
        {
            string ReturnRAM = "0 MB";
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_ComputerSystem");

            foreach (ManagementObject Mobject in Search.Get())
            {
                //double RAMBytes = Convert.ToDouble(Mobject["TotalPhysicalMemory"]));
                double RAMBytes = (Convert.ToDouble(Mobject["TotalPhysicalMemory"])); //too precise, fix in a later build
                ReturnRAM = String.Format("{0} MB", RAMBytes / 1048576);
            }
            return ReturnRAM;
        }
    }
}

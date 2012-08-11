/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: this is how we get your windows version
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace sysup
{
    class GetWinVersion
    {
        public string WindowsVersion()
        {
              
            string BitLength;
            string CheckWinVer = "Unknown Windows";

            System.OperatingSystem osInfo =System.Environment.OSVersion;

            if (Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Hardware\\Description\\System\\CentralProcessor\\0").GetValue("Identifier").ToString().Contains("x86"))
            {
                BitLength = "32-bit";
            }
            else
            {
                BitLength = "64-bit";
            }

            switch (osInfo.Platform)
            {
                case System.PlatformID.Win32NT:
                    switch (osInfo.Version.Major)
                    {
                        case 5:
                            {
                                if (osInfo.Version.Minor == 0)
                                    CheckWinVer = "Windows 2000 ";
                                else if (osInfo.Version.Minor == 1)
                                    CheckWinVer = "Windows XP ";
                                else if (osInfo.Version.Minor == 2)
                                    CheckWinVer = "Windows Server 2003/Windows XP 64-bit Edition ";
                                else
                                    CheckWinVer = "Unknown Windows ";
                                break;
                            }

                        case 6:
                            {
                                if (osInfo.Version.Minor == 0)
                                    CheckWinVer = "Windows Vista ";
                                else if (osInfo.Version.Minor == 1)
                                    CheckWinVer = "Windows 7 ";
                                else if (osInfo.Version.Minor == 2)
                                    CheckWinVer = "Windows 8 ";
                                else
                                    CheckWinVer = "Unknown Windows ";
                                break;
                            }
                    }
                    break;
            }
            

            return CheckWinVer + BitLength;
        }
    }
}

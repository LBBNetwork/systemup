/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: buildstring handler
 */

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
//using System.Windows.Forms;

namespace sysup
{
    class buildstring
    {
        public string DebugStrFull = "Version {0}_m1.opensource(debug), Alpha 1";
        public string ReleaseStrFull = "Version {0}_m1.opensource, Alpha 1";
        public string DebugStr = "Version {0}(debug), Alpha 1";
        public string ReleaseStr = "Version {0}, Alpha 1";

        public string SetEvalNotice(int BldType, out int BldTypeHandler)
        {
            switch (BldType)
            {
                case 0:
                    BldTypeHandler = 0;
#if DEBUG
                    return (String.Format(DebugStrFull, AssemblyVersion));

#else
                    return (String.Format(ReleaseStrFull, AssemblyVersion));
#endif
                case 1:
                    BldTypeHandler = 1;
                    return "Confidential - do not distribute or disclose.";
                case 2:
                    BldTypeHandler = 2;
#if DEBUG
                    return (String.Format("Private testing only. " + DebugStrFull, AssemblyVersion));
#else
                    return (String.Format("Private testing only. " + ReleaseStrFull, AssemblyVersion));
#endif

                case 3:
                    BldTypeHandler = 3;
#if DEBUG
                    return (String.Format("Experimental build. " + DebugStrFull, AssemblyVersion));
#else
                    return (String.Format("Experimental build. " + ReleaseStrFull, AssemblyVersion));
#endif
                default:
                    BldTypeHandler = -1;
                    return "";
            }

        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
    }
}

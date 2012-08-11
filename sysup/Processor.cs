/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: GenuineIntel AuthenticAmd CyrixInstead
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Management.Instrumentation;

namespace sysup
{
    class Processor
    {
        public string DoProcessor()
        {
            string ReturnCPU = "Zilog Z80";
            ManagementObjectSearcher Search = new ManagementObjectSearcher("Select * From Win32_Processor");

            foreach (ManagementObject CPUObject in Search.Get())
            {
                string cpu_name = (Convert.ToString(CPUObject["Name"]));
                int cpu_speed = (Convert.ToInt32(CPUObject["CurrentClockSpeed"]));
                int cpu_cores = (Convert.ToInt32(CPUObject["NumberOfCores"]));
                int num_of_cpu = (Convert.ToInt32(CPUObject["NumberOfLogicalProcessors"]));
                ReturnCPU = String.Format("{0}\n{1} MHz, {2} processor(s), {3} core(s)", cpu_name, cpu_speed, cpu_cores, num_of_cpu);
                
            }
            return ReturnCPU;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Diagnostics;
using System.Threading;

namespace sysup
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static String[] mArgs;
        private void SUPStartup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length > 0)
            {
                //mArgs = e.Args;
                foreach (string arg in e.Args)
                {
                    switch (arg)
                    {
			//THIS IS TEMPORARY
                        case "/upgrade":
                            try
                            {
                                System.IO.File.Delete("sysup.exe");

                            }
                            catch (System.IO.IOException)
                            {
                                System.Windows.MessageBox.Show("fail to delete file");
                            }
                            try
                            {
                                System.IO.File.Move("sup.exe", "sysup.exe");
                                System.Windows.MessageBox.Show("Upgrade complete.");
                            }
                            catch (System.IO.IOException)
                            {
                                System.Windows.MessageBox.Show("fail to move file");
                            }
                            break;
                    }
                }
            }

        }
    }
}

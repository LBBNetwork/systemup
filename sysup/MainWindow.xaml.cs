/* SystemUp Alpha 1
 * Copyright (c) 2012 The Little Beige Box, http://www.beige-box.com
 * 
 * This software licensed under the GNU GPL v3.
 * 
 * Description: main part of the program
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace sysup
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private buildstring SetBuildStr = new buildstring();
        private UpdateProduct UpdateClient = new UpdateProduct();

        private GetWinVersion DoGetWinVer = new GetWinVersion();
        private MemCount GetMemory = new MemCount();
        private HardDrive GetHardDrive = new HardDrive();
        private VideoCard GetVideoCard = new VideoCard();
        private Processor GetProcessor = new Processor();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.InfoTabs.SelectedItem = (TabItem)InfoTabs.FindName("BasInfo"); 
            BasicMode.Foreground = Brushes.Black;
            GenStats();
        }

        public void GenStats()
        {
            string WindowsVersion, InstalledRAM, InstalledProcessor;
            int BldHandler;
            this.eval_label.Content = SetBuildStr.SetEvalNotice(0, out BldHandler);
            this.AboutVersion.Content = SetBuildStr.SetEvalNotice(0, out BldHandler);

            Thread.Sleep(1000);

            WindowsVersion = DoGetWinVer.WindowsVersion();
            InstalledRAM = GetMemory.GetMemCount();
            InstalledProcessor = GetProcessor.DoProcessor();

            this.WinTest.Content = WindowsVersion; //DoGetWinVer.WindowsVersion();
            this.LabelRAM.Content = InstalledRAM; //GetMemory.GetMemCount();
            this.LabelHDD.Content = GetHardDrive.DoHardDrive();
            this.LabelGFX.Content = GetVideoCard.GetVideoCardWMI();
            this.LabelCPU.Content = InstalledProcessor; //GetProcessor.DoProcessor();

            this.BasWinVer.Content = WindowsVersion;
            this.BasInfoProc.Content = InstalledProcessor;
            this.BasInfoRAM.Content = InstalledRAM;

            this.StatGenTime.Content = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();
        }

        private void genagain_Click(object sender, RoutedEventArgs e)
        {
            GenStats(); 
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            //UpdateClient.CheckForUpdates();
        }
        void BasicMode_Click(object sender, RoutedEventArgs e)
        {
            AboutMode.Foreground = Brushes.LightGray;
            BasicMode.Foreground = Brushes.Black;
            AdvancedMode.Foreground = Brushes.LightGray;
            UpdateMode.Foreground = Brushes.LightGray;
            this.InfoTabs.SelectedItem = (TabItem)InfoTabs.FindName("BasInfo");
        }
        void AdvancedMode_Click(object sender, RoutedEventArgs e)
        {
            AboutMode.Foreground = Brushes.LightGray;
            BasicMode.Foreground = Brushes.LightGray;
            AdvancedMode.Foreground = Brushes.Black;
            UpdateMode.Foreground = Brushes.LightGray;
            this.InfoTabs.SelectedItem = (TabItem)InfoTabs.FindName("AdvInfo");
        }
        void UpdateMode_Click(object sender, RoutedEventArgs e)
        {
            AboutMode.Foreground = Brushes.LightGray;
            BasicMode.Foreground = Brushes.LightGray;
            AdvancedMode.Foreground = Brushes.LightGray;
            UpdateMode.Foreground = Brushes.Black;
            this.InfoTabs.SelectedItem = (TabItem)InfoTabs.FindName("UpdateInfo");
        }
        void AboutMode_Click(object sender, RoutedEventArgs e)
        {
            AboutMode.Foreground = Brushes.Black;
            BasicMode.Foreground = Brushes.LightGray;
            AdvancedMode.Foreground = Brushes.LightGray;
            UpdateMode.Foreground = Brushes.LightGray;
            this.InfoTabs.SelectedItem = (TabItem)InfoTabs.FindName("AboutInfo");
            //System.Windows.MessageBox.Show("Online Updating is currently disabled.", "Online Update", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
           // UpdateClient.CheckForUpdates();
        }
    }
}

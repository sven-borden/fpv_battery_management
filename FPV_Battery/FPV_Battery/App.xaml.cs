using FPV_Battery.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace FPV_Battery
{
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzI1MTc2QDMxMzgyZTMzMmUzMFEvand1SHd0cjhxYmlEbFYxSjdJdS9xNmtYRmdUQUJFVnU1djJESEduNUE9");
            InitializeComponent();

            MainPage = new NavigationPage(new MainContainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

using FPV_Battery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FPV_Battery.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        private void Export_pressed(object sender, EventArgs e)
        {
            StorageHelper.Share();
        }

        private async void Load_pressed(object sender, EventArgs e)
        {
            await DisplayAlert("Oups", "Not supported yet!", "OK");
        }
    }
}
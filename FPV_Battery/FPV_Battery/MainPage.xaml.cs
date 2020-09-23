using FPV_Battery.Model;
using FPV_Battery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FPV_Battery
{
    public partial class MainPage : ContentPage
    {
        public MainViewModel viewModel;
        private Battery last_battery_swiped;
        public MainPage()
        {

            InitializeComponent();
            BindingContext = viewModel = new MainViewModel();

            viewModel.Navigation = Navigation;
        }


        private void BatteryListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            viewModel.OpenItem((e.ItemData as Battery).SerialNumber);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            viewModel.AddCycleFromSwipe(last_battery_swiped.SerialNumber);
        }

        private void BatteryListView_SwipeStarted(object sender, Syncfusion.ListView.XForms.SwipeStartedEventArgs e)
        {
            last_battery_swiped = (e.ItemData as Battery);
        }
    }
}

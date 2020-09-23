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
    }
}

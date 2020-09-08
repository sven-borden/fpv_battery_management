using FPV_Battery.Model;
using FPV_Battery.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
namespace FPV_Battery.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<Battery> batteries;

        #endregion

        #region Command
        public Command AddCommand { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            AddCommand = new Command(AddClicked);
            Batteries = new ObservableCollection<Battery>()
            {
                new Battery()
                {
                    Model = "6928493384565",
                    SerialNumber = "K02007692",
                    BoughtDate = DateTime.Now,
                    Cycles = 0,
                }
            };
        }
        #endregion

        #region Properties

        public ObservableCollection<Battery> Batteries
        {
            get
            {
                return batteries;
            }
            set
            {
                batteries = value;
                this.NotifyPropertyChanged();
            }
        }

        public INavigation Navigation { get; set; }
        #endregion

        #region Methods
        private async void AddClicked(object obj)
        {
            var page = new AddView();
            page.viewModel.BatteryAdd += ViewModel_BatteryAdd;
            await Navigation.PushAsync(page);
        }

        private void ViewModel_BatteryAdd(object sender, EventArgs e)
        {
            Batteries.Add((e as BatteryCreatedEventArgs).Bat);
        }


        #endregion
    }
}

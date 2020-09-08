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
                    Id = 0
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
            await Navigation.PushAsync(new AddView());
        }
        #endregion
    }
}

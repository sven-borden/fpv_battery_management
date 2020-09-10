using FPV_Battery.Model;
using FPV_Battery.Services;
using FPV_Battery.Views;
using Syncfusion.Data.Extensions;
using Syncfusion.XForms.RichTextEditor;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
namespace FPV_Battery.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Fields
        private ObservableCollection<Battery> batteries = new ObservableCollection<Battery>();

        #endregion

        #region Command
        public Command AddCommand { get; set; }
        #endregion

        #region Constructor
        public MainViewModel()
        {
            AddCommand = new Command(AddClicked);
            Batteries = StorageHelper.GetBatteries();
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
            var b = (e as BatteryCreatedEventArgs).Bat;
            if (b != null)
            {
                Batteries.Add(b);
                StorageHelper.SaveBatteries(Batteries);
                Batteries = StorageHelper.GetBatteries();
            }
        }

        private void ViewModel_Edit(object sender, EventArgs e)
        {
            var previous = (e as BatteryEditedEventArgs).preBat;
            var newBat = (e as BatteryEditedEventArgs).newBat;
            Batteries.Remove(previous);
            Batteries.Add(newBat);
            StorageHelper.SaveBatteries(Batteries);
            Batteries = StorageHelper.GetBatteries();
        }

        public async void OpenItem(string _serialNumber)
        {
            var Battery = Batteries.Where(b => b.SerialNumber == _serialNumber).FirstOrDefault();
            var page = new EditView(Battery);
            page.viewModel.BatteryEdited += ViewModel_Edit;
            await Navigation.PushModalAsync(page);
        }

        #endregion
    }
}

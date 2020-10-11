using FPV_Battery.Model;
using FPV_Battery.Services;
using FPV_Battery.Views;
using Syncfusion.Data.Extensions;
using Syncfusion.XForms.RichTextEditor;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
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

        public Command ScanCycle { get; set; }

        #endregion

        #region Constructor
        public MainViewModel()
        {
            AddCommand = new Command(AddClicked);
            ScanCycle = new Command(ScanAddCycle);
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

        public void AddCycleFromSwipe(string serial)
        {
            Battery o = Batteries.Where(b => b.SerialNumber == serial).FirstOrDefault();
            Batteries.Remove(o);
            o.Cycles += 1;
            Batteries.Add(o);
            StorageHelper.SaveBatteries(Batteries);
        }
        private async void AddClicked(object obj)
        {
            var page = new AddView();
            page.viewModel.BatteryAdd += ViewModel_BatteryAdd;
            await Navigation.PushAsync(page);
        }

        private async void ScanAddCycle(object obj)
        {
            ZXing.Result result = await ScanHelper.ScanCode(false);
            if (result == null)
                return;
            try
            {
                var SerialNumber = result.Text;

                Battery p = Batteries.Where(b => b.SerialNumber == SerialNumber).FirstOrDefault();

                //Display confirmation
                bool confirm = await Application.Current.MainPage.DisplayAlert("Add a cycle?", "Would you like to add a cycle to battery?", "Yes", "No");
                if (confirm)
                {
                    Batteries.Remove(p);
                    p.Cycles += 1;
                    Batteries.Add(p);
                    StorageHelper.SaveBatteries(Batteries);
                }
            }
            catch(Exception e)
            {
                
            }
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

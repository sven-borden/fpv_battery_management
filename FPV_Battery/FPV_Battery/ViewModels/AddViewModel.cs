using FPV_Battery.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FPV_Battery.ViewModels
{
    public class AddViewModel : BaseViewModel
    {
        private string model;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
                this.NotifyPropertyChanged();
            }
        }

        private string serialNumber;
        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                serialNumber = value;
                this.NotifyPropertyChanged();
            }
        }

        private int cycle;
        public int Cycle
        {
            get
            {
                return cycle;
            }
            set
            {
                cycle = value;
                this.NotifyPropertyChanged();
            }
        }

        private DateTime bought;
        public DateTime Bought
        {
            get
            {
                return bought;
            }
            set
            {
                bought = value;
                this.NotifyPropertyChanged();
            }
        }

        public INavigation Navigation;

        #region Command
        public Command ScanModelCommand { get; set; }
        public Command ScanSerialCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command SaveCommand { get; set; }
        #endregion
        public AddViewModel()
        {

            Bought = DateTime.Now;
            Cycle = 0;
            Model = string.Empty;
            SerialNumber = string.Empty;
            ScanModelCommand = new Command(ScanModelClicked);
            ScanSerialCommand = new Command(ScanSerialClicked);
            CancelCommand = new Command(CancelClicked);
            SaveCommand = new Command(SaveClicked);
        }

        #region Methods
        private async void ScanModelClicked(object obj)
        {
            //TODO
        }
        private async void ScanSerialClicked(object obj)
        {
            //TODO
        }
        private async void CancelClicked(object obj)
        {
            await Navigation.PopAsync();
        }

        private async void SaveClicked(object obj)
        {
            //TODO need to save
            await Navigation.PopAsync();
        }

        #endregion
    }
}

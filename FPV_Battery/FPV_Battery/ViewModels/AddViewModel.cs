using FPV_Battery.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        #region Properties
        public event EventHandler BatteryAdd;
        #endregion

        #region Methods
        private async void ScanModelClicked(object obj)
        {
            ZXing.Result result = await ScanCode(true);
            Model = result.Text;
        }
        private async void ScanSerialClicked(object obj)
        {
            ZXing.Result result = await ScanCode(false);
            SerialNumber = result.Text;
        }
        private async void CancelClicked(object obj)
        {
            await Navigation.PopAsync();
        }

        private async void SaveClicked(object obj)
        {
            BatteryCreatedEventArgs e = new BatteryCreatedEventArgs()
            {
                Bat = new Battery()
                {
                    BoughtDate = Bought,
                    Cycles = Cycle,
                    Model = Model,
                    SerialNumber = SerialNumber
                }
            };
            OnBatteryAdd(e);
            await Navigation.PopAsync();
        }

        private async Task<ZXing.Result> ScanCode(bool linear)
        {

#if __ANDROID__
	            // Initialize the scanner first so it can track the current context
	            MobileBarcodeScanner.Initialize (Application);
#endif
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            if (linear == true)
            {
                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                    options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                        ZXing.BarcodeFormat.All_1D
                };

                var result = await scanner.Scan(options);

                return result;
            }
            else
            {
                var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                        ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.AZTEC
                };

                var result = await scanner.Scan(options);

                return result;
            }
        }

        private void OnBatteryAdd(BatteryCreatedEventArgs e)
        {
            BatteryAdd?.Invoke(this, e);
        }
        #endregion
    }

    public class BatteryCreatedEventArgs : EventArgs
    {
        public Battery Bat { get; set; }
    }
}

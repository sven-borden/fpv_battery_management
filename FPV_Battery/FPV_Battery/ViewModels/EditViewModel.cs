﻿using FPV_Battery.Model;
using FPV_Battery.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FPV_Battery.ViewModels
{
    public class EditViewModel : BaseViewModel
    {
        #region properties
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

        private Battery preBat;

        public INavigation Navigation;

        #endregion

        #region Command
        public Command ScanModelCommand { get; set; }
        public Command ScanSerialCommand { get; set; }
        public Command CancelCommand { get; set; }
        public Command SaveCommand { get; set; }
        #endregion

        #region Constructor

        public EditViewModel()
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
        public EditViewModel(Battery preBat) : this()
        {
            this.preBat = preBat;
            Bought = preBat.BoughtDate;
            Cycle = preBat.Cycles;
            Model = preBat.Model;
            serialNumber = preBat.SerialNumber;
        }
        #endregion
        #region Properties
        public event EventHandler BatteryEdited;
        #endregion

        #region Methods
        private async void ScanModelClicked(object obj)
        {
            ZXing.Result result = await ScanHelper.ScanCode(true);
            Model = result.Text;
        }
        private async void ScanSerialClicked(object obj)
        {
            ZXing.Result result = await ScanHelper.ScanCode(false);
            SerialNumber = result.Text;
        }
        private async void CancelClicked(object obj)
        {
            await Navigation.PopModalAsync();
        }

        private async void SaveClicked(object obj)
        {
            BatteryEditedEventArgs e = new BatteryEditedEventArgs()
            {
                preBat = this.preBat,
                newBat = new Battery()
                {
                    BoughtDate = Bought,
                    Cycles = Cycle,
                    Model = Model,
                    SerialNumber = SerialNumber
                }
            };
            OnBatteryEdited(e);
            await Navigation.PopModalAsync();
        }

        private void OnBatteryEdited(BatteryEditedEventArgs e)
        {
            BatteryEdited?.Invoke(this, e);
        }
        #endregion
    }

    public class BatteryEditedEventArgs : EventArgs
    {
        public Battery newBat { get; set; }
        public Battery preBat { get; set; }
    }
}
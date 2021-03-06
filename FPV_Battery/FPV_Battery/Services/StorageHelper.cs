﻿using FPV_Battery.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace FPV_Battery.Services
{
    public class StorageHelper
    {
        private static string filename = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "batteries.json");

        public static void SaveBatteries(ObservableCollection<Battery> batteries)
        {
            var s = JsonConvert.SerializeObject(batteries);
            File.WriteAllText(filename, s);
        }


        public static ObservableCollection<Battery> GetBatteries()
        {
            if (File.Exists(filename) == false)
            {
                Debug.Print("Created file");
                File.Create(filename);
                return new ObservableCollection<Battery>();
            }
            else
            {

                try
                {
                    var s = File.ReadAllText(filename);

                    var batteries = new ObservableCollection<Battery>(JsonConvert.DeserializeObject<ObservableCollection<Battery>>(s));
                    if (batteries == null)
                        batteries = new ObservableCollection<Battery>();
                    return batteries;
                }
                catch(Exception e)
                {
                    Debug.Print("File Empty");
                    return new ObservableCollection<Battery>();
                }

            }

        }

        public async static void Share()
        {
            if (File.Exists(filename))
            {
                await Xamarin.Essentials.Share.RequestAsync(new Xamarin.Essentials.ShareFileRequest
                {
                    Title = "batteries.json",
                    File = new Xamarin.Essentials.ShareFile(filename)
                });
            }
        }
    }
}

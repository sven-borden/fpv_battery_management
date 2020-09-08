using System;
using System.Collections.Generic;
using System.Text;

namespace FPV_Battery.Model
{
    public class Battery
    {
        public string Model { get; set; }

        public string SerialNumber { get; set; }

        public int Cycles { get; set; }

        public DateTime BoughtDate { get; set; }
    }
}

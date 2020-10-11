using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FPV_Battery.Services
{
    public static class ScanHelper
    {

        public static async Task<ZXing.Result> ScanCode(bool linear)
        {

#if __ANDROID__
	            // Initialize the scanner first so it can track the current context
	            MobileBarcodeScanner.Initialize (Application);
#endif
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

            try
            {
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
                    //var options = new ZXing.Mobile.MobileBarcodeScanningOptions();
                    //options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                    //        ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.AZTEC
                    //};

                    var result = await scanner.Scan();

                    return result;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}

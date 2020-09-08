using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Syncfusion.SfPicker.XForms.iOS;

using Syncfusion.SfPdfViewer.XForms.iOS; 

using Syncfusion.SfRangeSlider.XForms.iOS; 

using Syncfusion.SfGauge.XForms.iOS;

using Syncfusion.XForms.iOS.ProgressBar; 

using Syncfusion.SfAutoComplete.XForms.iOS;

using Syncfusion.SfBusyIndicator.XForms.iOS;

using Syncfusion.SfNavigationDrawer.XForms.iOS;

using Syncfusion.SfNumericTextBox.XForms.iOS;

using Syncfusion.SfNumericUpDown.XForms.iOS;

using Syncfusion.SfPullToRefresh.XForms.iOS;

using Syncfusion.ListView.XForms.iOS;

using Syncfusion.SfBarcode.XForms.iOS;

using Syncfusion.XForms.iOS.Buttons;

using Syncfusion.XForms.iOS.ComboBox;

using Syncfusion.XForms.iOS.Border;

using Syncfusion.XForms.iOS.ParallaxView;

using Syncfusion.XForms.iOS.BadgeView;

using Syncfusion.XForms.iOS.Cards;

using Syncfusion.XForms.iOS.Accordion;

using Syncfusion.XForms.iOS.EffectsView;

using Syncfusion.XForms.iOS.Core;

namespace fpv_batteries.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            
			SfPickerRenderer.Init();
			
			
			SfPdfDocumentViewRenderer.Init(); 
			
			
			SfRangeSliderRenderer.Init(); 
			
			
			SfGaugeRenderer.Init();
			
			
			SfDigitalGaugeRenderer.Init();
			
			
			SfLinearGaugeRenderer.Init();
			
			
			SfLinearProgressBarRenderer.Init(); 
			
			
			SfCircularProgressBarRenderer.Init(); 
			
			
			SfAutoCompleteRenderer.Init();
			
			
			SfBusyIndicatorRenderer.Init();
			
			
			SfNavigationDrawerRenderer.Init();
			
			
			SfNumericTextBoxRenderer.Init();
			
			
			SfNumericUpDownRenderer.Init();
			
			
			SfPullToRefreshRenderer.Init();
			
			
			SfListViewRenderer.Init();
			
			
			SfBarcodeRenderer.Init();
			
			
			SfCheckBoxRenderer.Init();
			
			
			SfComboBoxRenderer.Init();
			
			
			SfButtonRenderer.Init();
			
			
			SfBorderRenderer.Init();
			
			
			SfParallaxViewRenderer.Init();
			
			
			SfBadgeViewRenderer.Init();
			
			
			SfCardViewRenderer.Init();
			
			
			SfAccordionRenderer.Init();
			
			
			SfEffectsViewRenderer.Init();
			
			
			SfAvatarViewRenderer.Init();
			
			LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}

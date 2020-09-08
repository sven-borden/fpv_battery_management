using FPV_Battery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FPV_Battery.Views
{
    public partial class AddView : ContentPage
    {
        public AddViewModel viewModel;
        public AddView()
        {
            InitializeComponent();
            BindingContext = viewModel = new AddViewModel();
            viewModel.Navigation = Navigation;
        }
    }
}
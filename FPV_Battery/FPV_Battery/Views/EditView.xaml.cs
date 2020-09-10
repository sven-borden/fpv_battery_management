using FPV_Battery.Model;
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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditView : ContentPage
    {
        public EditViewModel viewModel;
        public EditView(Battery preBat)
        {
            InitializeComponent();
            BindingContext = viewModel = new EditViewModel(preBat);
            viewModel.Navigation = Navigation;
        }
    }
}
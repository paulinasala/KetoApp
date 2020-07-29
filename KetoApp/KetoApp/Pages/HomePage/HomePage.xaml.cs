using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KetoApp.Pages.HomePage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage(HomePageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
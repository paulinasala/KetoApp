using KetoApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace KetoApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MenuPage : ContentPage
    {
        public MenuPage(MenuPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
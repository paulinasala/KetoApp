using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KetoApp.Pages.DiaryPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiaryPage : ContentPage
    {
        public DiaryPage(DiaryPageViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
using KetoApp.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace KetoApp.ViewModels
{

    public class MenuPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;


       
        public ICommand ButtonCommand { get; set; }

        private string _buttonText;
        public string ButtonText
        {
            get { return _buttonText; }
            set { SetPropertyValue(ref _buttonText, value); }
        }
    

        public MenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            ButtonText = "asd";
            ButtonCommand = new Command(ButtonClicked);
        }

        private void ButtonClicked()
        {
            ButtonText = $"{_buttonText}lol";
            _navigationService.PushPage(ApplicationPage.DiaryPage);
        }
    }
}

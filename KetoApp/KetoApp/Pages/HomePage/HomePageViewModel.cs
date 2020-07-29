using KetoApp.Services;
using KetoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KetoApp.Pages.HomePage
{
    public class HomePageViewModel : BaseViewModel

    {
        private readonly INavigationService _navigationService;

        public ICommand DiaryCommand{get;set;}
        public ICommand ProfileCommand { get; set; }
        public ICommand MacroCommand { get; set; }
        public ICommand MicroCommand { get; set; }
        public ICommand GymCommand { get; set; }
        public ICommand OptionsCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DiaryCommand = new Command(DiaryClick);
            ProfileCommand = new Command(ProfileClick);
            MacroCommand = new Command(MacroClick);
            MicroCommand = new Command(MicroClick);
            GymCommand = new Command(GymClick);
            OptionsCommand = new Command(OptionsClick);

        }

        private void OptionsClick()
        {
            _navigationService.PushPage(ApplicationPage.OptionsPage);
        }

        private void GymClick()
        {
            _navigationService.PushPage(ApplicationPage.GymPage);
        }

        private void MicroClick()
        {
            _navigationService.PushPage(ApplicationPage.MicroPage);
        }

        private void MacroClick()
        {
            _navigationService.PushPage(ApplicationPage.MacroPage);
        }

        private void ProfileClick()
        {
            _navigationService.PushPage(ApplicationPage.ProfilePage);
        }

        private void DiaryClick()
        {
            _navigationService.PushPage(ApplicationPage.DiaryPage);
        }
    }
}

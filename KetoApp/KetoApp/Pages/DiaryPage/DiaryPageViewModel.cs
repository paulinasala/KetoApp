using KetoApp.Services;
using KetoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KetoApp.Pages.DiaryPage
{
    public class DiaryPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public ICommand SearchPageCommand { get; set; }

        public DiaryPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SearchPageCommand = new Command(SearchPageClick);

        }

        private void SearchPageClick()
        {
            _navigationService.PushPage(ApplicationPage.SearchPage);
        }
    }
}

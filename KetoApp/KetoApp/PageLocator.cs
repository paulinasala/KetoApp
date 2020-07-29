using KetoApp.Pages.DiaryPage;
using KetoApp.Pages.GymPage;
using KetoApp.Pages.HomePage;
using KetoApp.Pages.MacroPage;
using KetoApp.Pages.MicroPage;
using KetoApp.Pages.OptionsPage;
using KetoApp.Pages.ProfilePage;
using KetoApp.Pages.SearchPage;
using KetoApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace KetoApp
{
    public enum ApplicationPage
    {
        DiaryPage,
        StartPage,
        MainPage,
        HomePage,
        OptionsPage,
        GymPage,
        MicroPage,
        MacroPage,
        ProfilePage,
        MenuPage,
        SearchPage,
    }
    public class PageLocator : IPageLocator
    {
        private readonly IServiceLocator _serviceLocator;

        public static readonly Dictionary<string, Type> PageMap = new Dictionary<string, Type>
        {
            { ApplicationPage.MenuPage.ToString(), typeof(MenuPage) },
            { ApplicationPage.StartPage.ToString(), typeof(StartPage) },
            { ApplicationPage.MainPage.ToString(), typeof(MainPage) },
            { ApplicationPage.HomePage.ToString(), typeof(HomePage) },
            { ApplicationPage.DiaryPage.ToString(), typeof(DiaryPage) },
            { ApplicationPage.ProfilePage.ToString(), typeof(ProfilePage) },
            { ApplicationPage.MacroPage.ToString(), typeof(MacroPage) },
            { ApplicationPage.MicroPage.ToString(), typeof(MicroPage) },
            { ApplicationPage.GymPage.ToString(), typeof(GymPage) },
            { ApplicationPage.OptionsPage.ToString(), typeof(OptionsPage) },
            { ApplicationPage.SearchPage.ToString(), typeof(SearchPage) },
        };

        public PageLocator(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public Page GetPage(string pageName)
        {
            return (Page)_serviceLocator.Get(PageMap[pageName]);
        }

        public string GetPageName(Page page)
        {
            foreach (var registeredPage in PageMap)
            {
                if (page.GetType().IsInstanceOfType(registeredPage.Value))
                {
                    return registeredPage.Key;
                }
            }

            return default;
        }
    }
}

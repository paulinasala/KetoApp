using System.Linq;
using Xamarin.Forms;

namespace KetoApp.Services
{
    class NavigationService : INavigationService
    {
        private readonly INavigation _navigation;
        private readonly IPageLocator _pageLocator;
        public NavigationService(INavigation navigation, IPageLocator pageLocator)
        {
            _navigation = navigation;
            _pageLocator = pageLocator;
        }

        public void PushPage(ApplicationPage page)
        {
            var p = _pageLocator.GetPage(page.ToString());
            _navigation.PushAsync(p);
        }

        public void PopPage()
        {
            _navigation.PopAsync();
        }
    }
}

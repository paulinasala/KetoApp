using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KetoApp.Services
{
    public class AlertService : IAlertService
    {
        private readonly INavigation _navigation;

        public AlertService(INavigation navigation)
        {
            _navigation = navigation;
        }
        public async Task DisplayAlert(string title, string msg, string confirm)
        {
            await _navigation.NavigationStack.Last<Page>().DisplayAlert(title, msg, confirm);
        }
    }
}

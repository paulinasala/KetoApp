using KetoApp.Services;
using KetoApp.ViewModels;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace KetoApp.Pages.SearchPage
{
    public class SearchPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IAlertService _alertService;


        public ICommand SearchButtonCommand { get; set; }

        private ObservableCollection<FoodModel> _foodList;
        public ObservableCollection<FoodModel> FoodList
        {
            get { return _foodList; }
            set { SetPropertyValue(ref _foodList, value); }
        }

        private string _input;
        public string Input
        {
            get { return _input; }
            set { SetPropertyValue(ref _input, value); }
        }

        public SearchPageViewModel(INavigationService navigationService, IAlertService alertService)
        {
            _navigationService = navigationService;
            _alertService = alertService; //TODO change to alertService
            SearchButtonCommand = new Command(async() => await SearchButtonClick());

        }

        private async Task SearchButtonClick()
        {

            try
            {
                var foodList = new ObservableCollection<FoodModel>();
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://api.nal.usda.gov");
                    var response = await client.GetAsync($"fdc/v1/foods/search?api_key=bWgtmnpPDqMLJCHD39bq0WHRjUkeudaAsZSdpUpm&query={Input}");
                    var result = await response.Content.ReadAsStringAsync();
                    var food = JToken.Parse(result);
                    foreach (var item in food["foods"])
                    {
                        var a = item["description"].Value<string>();
                        var b = item["brandOwner"] == null ? string.Empty : item["brandOwner"].Value<string>().Substring(0, 1).ToUpper() + item["brandOwner"].Value<string>().Substring(1).ToLower();
                        var model = new FoodModel() { Name = a.Substring(0, 1).ToUpper() + a.Substring(1).ToLower(), Brand = b };
                        foodList.Add(model);
                    }
                }
                FoodList = foodList;
            }
            catch (HttpRequestException ex)
            {

                await _alertService.DisplayAlert("Exeption", "msg", "ok");
                throw;
            }
        }

    
    }

}

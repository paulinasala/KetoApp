using System.Threading.Tasks;

namespace KetoApp.Services
{
    public interface IAlertService
    {
        Task DisplayAlert(string title, string msg, string confirm);
    }
}
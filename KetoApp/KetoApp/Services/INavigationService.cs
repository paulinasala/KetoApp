namespace KetoApp.Services
{
    public interface INavigationService
    {
        void PushPage(ApplicationPage page);
        void PopPage();
    }
}

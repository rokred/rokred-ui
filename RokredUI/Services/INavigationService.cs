using Xamarin.Forms;

namespace RokredUI.Services
{
    public interface INavigationService
    {
        void NavigateTo<T>(T page) where T : Page;
    }
}
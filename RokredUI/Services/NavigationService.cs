using RokredUI.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(RokredUI.Services.NavigationService))]

namespace RokredUI.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation NavigationContext => Application.Current.MainPage.Navigation;
        
        public void NavigateTo<T>(T page) where T : Page
        {
            NavigationContext.PushAsync(page);
        }
    }
}
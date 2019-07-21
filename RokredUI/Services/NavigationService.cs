using RokredUI.Views;
using Xamarin.Forms;

[assembly: Dependency(typeof(RokredUI.Services.NavigationService))]

namespace RokredUI.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation NavigationContext => Application.Current.MainPage.Navigation;


        public void NavigateToNewOpinionView()
        {
            NavigationContext.PushAsync(new NewOpinionFirstStepView());
        }

        public void NavigateToOpinionsView()
        {
            NavigationContext.PushAsync(new OpinionsView());
        }
    }
}
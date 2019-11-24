using RokredUI.Features.LandingPage;
using RokredUI.Services;
using Splat;
using Xamarin.Forms;

namespace RokredUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            var appBootstrapper = new AppBootstrapper();

            MainPage = new NavigationPage(new LandingView());
        }

        public void NavigateTo(Page page)
        {
            (MainPage as NavigationPage)?.PushAsync(page);
        }
        
        public void PopNavigation()
        {
            (MainPage as NavigationPage)?.PopAsync();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public class AppBootstrapper
    {
        public AppBootstrapper()
        {
            RegisterServices();
        }

        private static void RegisterServices()
        {
            Locator.CurrentMutable.RegisterLazySingleton(() => new RokredService(), typeof(IRokredService));
        }
    }

}
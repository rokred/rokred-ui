using System;
using ReactiveUI;
using RokredUI.Controls;
using RokredUI.POC.LandingPage;
using RokredUI.Services;
using RokredUI.ViewModels;
using RokredUI.Views;
using Splat;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        //    var appBootstrapper = new AppBootstrapper();

        MainPage = new NavigationPage(new LandingView());
        }

        public void NavigateTo(Page page)
        {
            (MainPage as NavigationPage).PushAsync(page);
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
            RegisterViews();
        }

        private static void RegisterViews()
        {
            Locator.CurrentMutable.Register(() => new NewOpinionFirstStepView(),
                typeof(IViewFor<NewOpinionFirstStepViewModel>));
            
            Locator.CurrentMutable.Register(() => new OpinionsView(),
                typeof(IViewFor<OpinionsViewModel>));
            Locator.CurrentMutable.Register(() => new NewOpinionSecondStepView(),
                typeof(IViewFor<NewOpinionSecondStepViewModel>));
        }

        private static void RegisterServices()
        {
            Locator.CurrentMutable.RegisterLazySingleton(() => new ApiService(), typeof(IApiService));
            Locator.CurrentMutable.RegisterLazySingleton(() => new NavigationService(), typeof(INavigationService));
        }
    }
}
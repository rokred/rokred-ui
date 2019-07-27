using System;
using RokredUI.Controls;
using RokredUI.Services;
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

            var appBootstrapper = new AppBootstrapper();

            MainPage = new NavigationPage(new HomeView());
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
            Locator.CurrentMutable.RegisterLazySingleton(() => new ApiService(), typeof(IApiService));
        }
    }
}
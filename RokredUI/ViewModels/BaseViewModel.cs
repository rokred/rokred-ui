using System;
using System.Reactive.Disposables;
using ReactiveUI;
using Xamarin.Forms;

namespace RokredUI.ViewModels
{
    public class BaseViewModel : ReactiveObject, IDisposable
    {
        private INavigation NavigationContext => Application.Current.MainPage.Navigation;

        private CompositeDisposable Disposables { get; }

        protected BaseViewModel()
        {
            Disposables = new CompositeDisposable();
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }

        protected void NavigateTo<T>(T page) where T : Page
        {
            NavigationContext.PushAsync(page);
        }
    }
}
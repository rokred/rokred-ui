using System;
using System.Reactive.Disposables;
using ReactiveUI;
using RokredUI.Services;
using Splat;
using Xamarin.Forms;

namespace RokredUI.ViewModels
{
    public class BaseViewModel : ReactiveObject, IDisposable, IViewModel
    {
        protected readonly INavigationService Navigator;

        private CompositeDisposable Disposables { get; }

        protected BaseViewModel(INavigationService navigationService = null)
        {
            Navigator = navigationService ?? Locator.Current.GetService<INavigationService>();
            Disposables = new CompositeDisposable();
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
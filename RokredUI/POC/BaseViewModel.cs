using System;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.POC.LandingPage;
using RokredUI.Services;
using Splat;

namespace RokredUI.POC
{
    public abstract class BaseViewModel : ReactiveObject, IDisposable, IViewModel
    {
        [Reactive] public UserVmi User { get; set; }

        protected BaseViewModel()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            User = GetUser();
        }
        private UserVmi GetUser()
        {
            return new UserVmi() { Name = "Jake Brown" };
        }
        
        //protected readonly INavigationService Navigator;

        private CompositeDisposable Disposables { get; }

        private BaseViewModel(INavigationService navigationService = null)
        {
            //Navigator = navigationService ?? Locator.Current.GetService<INavigationService>();
            Disposables = new CompositeDisposable();
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
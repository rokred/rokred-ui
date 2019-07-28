using System;
using System.Reactive;
using ReactiveUI;

namespace RokredUI.Services
{
    public interface INavigationService
    {
        IObservable<Unit> Push<T>(T viewModel) where T : class, IViewModel;

        IObservable<Unit> Push<T>() where T : class, IViewModel;
    }
}
using System;
using System.Reactive.Disposables;
using ReactiveUI;

namespace RokredUI.ViewModels
{
    public class BaseViewModel : ReactiveObject, IDisposable
    {
        protected CompositeDisposable Disposables { get; }

        public BaseViewModel()
        {
            Disposables = new CompositeDisposable();
        }
        public void Dispose()
        {
            Disposables.Dispose();
        }
    }
}
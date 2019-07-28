using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Models;
using RokredUI.Services;
using Splat;

namespace RokredUI.ViewModels
{
    public class OpinionsViewModel : BaseViewModel
    {
        public bool Loading { [ObservableAsProperty] get; }

        private readonly SourceList<Opinion> _opinionsData = new SourceList<Opinion>();

        public ReactiveCommand<Unit, IEnumerable<Opinion>> LoadCommand { get; }

        private readonly ReadOnlyObservableCollection<Opinion> _opinions;
        public ReadOnlyObservableCollection<Opinion> Opinions => _opinions;

        public OpinionsViewModel(IApiService apiService = null)
        {
            var resultService = apiService ?? Locator.Current.GetService<IApiService>();

            _opinionsData.Connect()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _opinions)
                .DisposeMany()
                .Subscribe();

            Observable.Return(true)
                .ToPropertyEx(this, x => x.Loading);

            LoadCommand = ReactiveCommand.CreateFromObservable(resultService.GetAll);
            LoadCommand.Subscribe(_opinionsData.AddRange);

            LoadCommand.IsExecuting.ToPropertyEx(this, x => x.Loading);
            LoadCommand.ThrownExceptions.Subscribe(x =>
            {
                //TODO Here we will handle exceptions
            });
        }
    }
}
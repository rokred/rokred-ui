using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.ViewModels;
using Xamarin.Forms.Xaml;
using System;
using Xamarin.Forms;

namespace RokredUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpinionsView : ReactiveContentPage<OpinionsViewModel>
    {
        public OpinionsView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(v => v.ViewModel.LoadCommand).Where(x => x != null)
                    .Select(x => Unit.Default)
                    .InvokeCommand(ViewModel.LoadCommand);

                this.OneWayBind(ViewModel, vm => vm.Opinions, v => v.Opinions.ItemsSource)
                    .DisposeWith(disposables);

                this.WhenAnyValue(v => v.ViewModel.Loading).Where(x => !x).ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(x => { Loader.FadeTo(0, 500, Easing.CubicOut); });
            });
        }
    }
}
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.ViewModels;
using RokredUI.Views.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOpinionSecondStepView : ReactiveContentPage<NewOpinionSecondStepViewModel>
    {
        public NewOpinionSecondStepView()
        {
            InitializeComponent();

            SetupBindings();
        }

        private void SetupBindings()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Subject, v => v.SubjectText.Text).DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Opinion, v => v.OpinionText.Text).DisposeWith(disposables);

                this.BindCommand(ViewModel, vm => vm.RequestOverlayCommand, v => v.OpinionText)
                    .DisposeWith(disposables);

                this.BindCommand(ViewModel, v => v.SendCommand, v => v.SendButton,
                    Observable.Return(OpinionText.Text)).DisposeWith(disposables);

                FocusOnSearchText.DisposeWith(disposables);

                Observable.FromEventPattern<EventArgs>(
                        x => OpinionText.LostFocusEvent += x,
                        x => OpinionText.LostFocusEvent -= x)
                    .Where(e => e.EventArgs != null)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(async ev =>
                    {
                        ViewModel.CloseOverlay();

                        Scroll.ScrollToAsync(0, FirstControl.Y, true)
                          .ToObservable()
                           .ObserveOn(RxApp.MainThreadScheduler)
                           .Subscribe(async f =>
                           {
                               await OpinionContainer.RevertFocus();
                           });
                    });
            });
        }

        private IDisposable FocusOnSearchText => this
            .WhenAnyValue(v => v.ViewModel.RequestOverlayCommand.IsExecuting)
            .Subscribe(isExecuting =>
            {
                isExecuting.Where(x => x)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(x =>
                    {
                        Scroll.ScrollToAsync(0, OpinionText.Y, true)
                           .ToObservable()
                            .ObserveOn(RxApp.MainThreadScheduler)
                            .Subscribe(async f =>
                            {
                                OpinionText.Focus();
                                await OpinionContainer.FocusVisually(OpinionText);
                            });
                    });
            });
    }
}
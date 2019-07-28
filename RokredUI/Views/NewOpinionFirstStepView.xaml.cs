using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOpinionFirstStepView : ReactiveContentPage<NewOpinionFirstStepViewModel>
    {
        public NewOpinionFirstStepView()
        {
            InitializeComponent();
            
            BindingContext = new NewOpinionFirstStepViewModel();

            this.WhenActivated(disposables =>
            {
                this.BindCommand(ViewModel, v => v.RequestOverlayCommand, v => v.OpinionText,
                    Observable.Return(OpinionText.Text)).DisposeWith(disposables);
                
                this.BindCommand(ViewModel, v => v.ApproachSandBoxCommand, v => v.OpinionSandBox,
                    Observable.Return(OpinionText.Text)).DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.SearchText, v => v.OverlayText.Text).DisposeWith(disposables);
                this.OneWayBind(ViewModel, vm => vm.SearchText, v => v.OpinionText.Text).DisposeWith(disposables);

                FadeInOpinionsOverlay.DisposeWith(disposables);

                Observable.FromEventPattern<FocusEventArgs>(
                        x => OverlayText.Unfocused += x,
                        x => OverlayText.Unfocused += x)
                    .Where(e => e.EventArgs != null )
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(ev =>
                    {
                        OpinionContainer.TranslationY = ev.EventArgs.IsFocused ? 200 : 0;
                    });
            });
        }

        private IDisposable FadeInOpinionsOverlay => this
            .WhenAnyValue(v => v.ViewModel.RequestOverlayCommand.IsExecuting)
            .Subscribe(isExecuting =>
            {
                isExecuting.Where(x => x)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(x =>
                    {
                        OpinionsOverlay.IsVisible = true;
                        OpinionsOverlay.FadeTo(1, 1000, Easing.CubicOut)
                            .ToObservable()
                            .ObserveOn(RxApp.MainThreadScheduler)
                            .Subscribe(f =>
                            {
                                OverlayText.Focus();
                            });

                    });
            });

        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            OverlayText.Unfocus();
            OpinionsOverlay.FadeTo(0, 500, Easing.CubicOut);
            OpinionsOverlay.IsVisible = false;
        }
    }
}
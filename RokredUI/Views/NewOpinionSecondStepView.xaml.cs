using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.ViewModels;
using Xamarin.Forms.Xaml;

namespace RokredUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOpinionSecondStepView : ReactiveContentPage<NewOpinionSecondStepViewModel>
    {
        public NewOpinionSecondStepView()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, vm => vm.OpinionText, v => v.OpinionText.Text).DisposeWith(disposables);
            });
        }
    }
}
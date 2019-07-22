using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.ViewModels;
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

            this.WhenActivated(dispose =>
            {
                this.BindCommand(ViewModel, vm => vm.EnterOpinionCommand, v => v.EnterOpinionEntry)
                    .DisposeWith(dispose);
            });
        }
    }
}
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
        }
    }
}
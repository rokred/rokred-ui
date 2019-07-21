using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.ViewModels;
using Xamarin.Forms.Xaml;

namespace RokredUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ReactiveContentPage<HomeViewModel>
    {
        public HomeView()
        {
            InitializeComponent();
            BindingContext = new HomeViewModel();
        }
    }
}
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using RokredUI.Services;
using RokredUI.Views;
using Xamarin.Forms;

namespace RokredUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public ReactiveCommand<Unit, Unit> NewOpinionCommand { get; }

        public ReactiveCommand<Unit, Unit> OpinionsCommand { get; }

        public HomeViewModel()
        {
            _navigationService = DependencyService.Get<INavigationService>();
            NewOpinionCommand = ReactiveCommand.Create(GoToNewOpinion, Observable.Return(true));
            OpinionsCommand = ReactiveCommand.Create(GoToOpinions, Observable.Return(true));
        }

        private void GoToOpinions()
        {
            _navigationService.NavigateTo(new OpinionsView());
        }

        private void GoToNewOpinion()
        {
            _navigationService.NavigateTo(new NewOpinionFirstStepView());
        }
    }
}
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using RokredUI.Services;
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
            _navigationService.NavigateToOpinionsView();
        }

        private void GoToNewOpinion()
        {
            _navigationService.NavigateToNewOpinionView();
        }
    }
}
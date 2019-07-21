using System.Reactive;
using ReactiveUI;
using RokredUI.Services;
using Xamarin.Forms;

namespace RokredUI.ViewModels
{
    public class HomeViewModel : ReactiveObject
    {
        private readonly INavigationService _navigationService;

        public ReactiveCommand<Unit, Unit> NewOpinionCommand { get; }

        public ReactiveCommand<Unit, Unit> OpinionsCommand { get; }

        public HomeViewModel()
        {
            _navigationService = DependencyService.Get<INavigationService>();
            NewOpinionCommand = ReactiveCommand.Create(GoToNewOpinion);
            OpinionsCommand = ReactiveCommand.Create(GoToOpinions);
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
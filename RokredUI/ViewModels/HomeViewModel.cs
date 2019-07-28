using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using RokredUI.Views;

namespace RokredUI.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public ReactiveCommand<Unit, Unit> NewOpinionCommand { get; }

        public ReactiveCommand<Unit, Unit> OpinionsCommand { get; }

        public HomeViewModel()
        {
            NewOpinionCommand = ReactiveCommand.Create(GoToNewOpinion, Observable.Return(true));
            OpinionsCommand = ReactiveCommand.Create(GoToOpinions, Observable.Return(true));
        }

        private void GoToOpinions()
        {
            Navigator.Push<OpinionsViewModel>();
        }

        private void GoToNewOpinion()
        {
            Navigator.Push<NewOpinionFirstStepViewModel>();
        }
    }
}
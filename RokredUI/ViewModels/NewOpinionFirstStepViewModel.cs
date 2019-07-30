using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RokredUI.ViewModels
{
    public class NewOpinionFirstStepViewModel : BaseViewModel
    {
        [Reactive] public string SearchText { get; set; }
        public ReactiveCommand<Unit, Unit> RequestOverlayCommand { get; }

        public ReactiveCommand<Unit, Unit> ApproachSandBoxCommand { get; }

        public NewOpinionFirstStepViewModel()
        {
            SearchText = "THE CRICKET WORLD CUP 2019";
            RequestOverlayCommand = ReactiveCommand.Create(OpenOverlay);
            ApproachSandBoxCommand = ReactiveCommand.Create(GoToSecondStep);
        }

        private void GoToSecondStep()
        {
            Navigator.Push(new NewOpinionSecondStepViewModel {OpinionText = SearchText});
        }

        private void OpenOverlay()
        {
            //We are not using it for now
        }
    }
}
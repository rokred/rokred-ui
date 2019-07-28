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
            RequestOverlayCommand = ReactiveCommand.Create(OpenOverlay, Observable.Return(true));
            ApproachSandBoxCommand = ReactiveCommand.Create(GoToSecondStep, Observable.Return(true));
        }

        private void GoToSecondStep()
        {
        }

        private void OpenOverlay()
        {
            //We are not using it for now
        }
    }
}
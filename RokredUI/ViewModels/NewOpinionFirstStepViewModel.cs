using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Backend;

namespace RokredUI.ViewModels
{
    public class NewOpinionFirstStepViewModel : BaseViewModel
    {
        [Reactive] public string SearchText { get; set; }

        public bool IsInOverlayMode { get; set; }

        public ReactiveCommand<Unit, Unit> RequestOverlayCommand { get; }
        public ReactiveCommand<Unit, Unit> ApproachSandBoxCommand { get; }

        public NewOpinionFirstStepViewModel()
        {
            SearchText = "THE CRICKET WORLD CUP 2019";

            RequestOverlayCommand = ReactiveCommand.Create(OpenOverlay, Observable.Return(true));
            ApproachSandBoxCommand = ReactiveCommand.Create(GoToSecondStep, Observable.Return(true));
        }

        public void CloseOverlay()
        {
            IsInOverlayMode = false;
        }

        private void OpenOverlay()
        {
            IsInOverlayMode = true;
        }

        private void GoToSecondStep()
        {
            CentralStore.StartCreatingNewOpinion();
            CentralStore.BrandNewOpinion.Subject = SearchText;

            Navigator.Push<NewOpinionSecondStepViewModel>();
        }
    }
}
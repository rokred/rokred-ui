using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using RokredUI.Services;
using Xamarin.Forms;

namespace RokredUI.ViewModels
{
    public class NewOpinionFirstStepViewModel: ReactiveObject
    {
        public ReactiveCommand<Unit, Unit> EnterOpinionCommand { get; }
        

        public NewOpinionFirstStepViewModel()
        {
           
            EnterOpinionCommand = ReactiveCommand.Create(EnterOpinion, Observable.Return(false));
        }

        private void EnterOpinion()
        {
        }
    }
}
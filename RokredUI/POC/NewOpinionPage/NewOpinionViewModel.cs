using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.POC.LandingPage;
using RokredUI.POC.OpinionPage;
using RokredUI.POC.SubjectPage;

namespace RokredUI.POC.NewOpinionPage
{
    public class NewOpinionViewModel : BaseViewModel
    {
        [Reactive] public OpinionVmi CurrentOpinion { get; set; }

        public ReactiveCommand<Unit, Unit> PostNewOpinionCommand { get; set; }
        
        public NewOpinionViewModel()
        {
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            PostNewOpinionCommand = ReactiveCommand.Create(OnPostNewOpinion, Observable.Return(true));
        }
        
        private void OnPostNewOpinion()
        {
            // todo: should go back to subject or opinion it came from
            App.Current.MainPage = new LandingView();
        }
    }
}
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.POC.LandingPage;
using RokredUI.POC.NewOpinionPage;
using RokredUI.POC.OpinionPage;

namespace RokredUI.POC.SubjectPage
{
    public class SubjectViewModel : BaseViewModel
    {
        [Reactive] public SubjectVmi CurrentSubject { get; set; }
        
        [Reactive] public List<OpinionVmi> Opinions { get; set; }
        [Reactive] public OpinionVmi SelectedChildOpinion { get; set; }
        
        public ReactiveCommand<Unit, Unit> SelectChildOpinionCommand { get; set; }
        public ReactiveCommand<Unit, Unit> PostNewOpinionCommand { get; set; }
        
        public SubjectViewModel(SubjectVmi selectedChildSubject) : base()
        {
            CurrentSubject = selectedChildSubject;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            SelectChildOpinionCommand = ReactiveCommand.Create(OnSelectChildOpinion, Observable.Return(true));
            PostNewOpinionCommand = ReactiveCommand.Create(OnPostNewOpinion, Observable.Return(true));
        }
        
        private void OnSelectChildOpinion()
        {
            App.Current.MainPage = new OpinionView(SelectedChildOpinion);
        }
        
        private void OnPostNewOpinion()
        {
            App.Current.MainPage = new NewOpinionView();
        }
    }
}
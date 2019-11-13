using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.POC.LandingPage;
using RokredUI.POC.NewOpinionPage;

namespace RokredUI.POC.OpinionPage
{
    public class OpinionViewModel : BaseViewModel
    {
         [Reactive] public OpinionVmi CurrentOpinion { get; set; }
        
        [Reactive]  public List<OpinionVmi> Opinions { get; set; }
        [Reactive] public OpinionVmi SelectedChildOpinion { get; set; }
        
        public ReactiveCommand<Unit, Unit> SelectChildOpinionCommand { get; set; }
        public ReactiveCommand<Unit, Unit> PostNewOpinionCommand { get; set; }

        
        public OpinionViewModel(OpinionVmi selectedChildOpinion)
        {
            CurrentOpinion = selectedChildOpinion;
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
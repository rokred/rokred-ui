using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.Features.NewOpinionPage;
using RokredUI.Features.OpinionPage;

namespace RokredUI.Features.SubjectPage
{
    public class SubjectViewModel : BaseViewModel
    {
        [Reactive] public SubjectVmi CurrentSubject { get; set; }
        
        [Reactive] public IList<IRokredListChildDataSource> Opinions { get; set; }
        [Reactive] public IRokredListChildDataSource SelectedChildOpinion { get; set; }

        public ReactiveCommand<Unit, Unit> PostNewOpinionCommand { get; set; }
        
        public ReactiveCommand<IRokredListChildDataSource, Unit> OpinionTappedCommand { get; set; }

        
        public SubjectViewModel(SubjectVmi selectedChildSubject) : base(selectedChildSubject)
        {
            
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            CurrentSubject = base._currentContext as SubjectVmi;
            
            var opinions = base.GetOpinions(CurrentSubject);
            Opinions = new ObservableCollection<IRokredListChildDataSource>(opinions);

            OpinionTappedCommand = ReactiveCommand.Create(
                new Action<IRokredListChildDataSource>(
                    async ds => await OnSelectOpinion(ds)));
            
            PostNewOpinionCommand = ReactiveCommand.Create(OnPostNewOpinion, Observable.Return(true));
        }
        
        private async Task OnSelectOpinion(IRokredListChildDataSource vmi)
        {
            SelectedChildOpinion = vmi;
            SetInternalSelectedStates();
            
            base.AddContext(vmi);

            (App.Current as App).NavigateTo(
                new OpinionView(base.DataSourceContext, CurrentSubject, vmi as OpinionVmi));
        }
        
        private void OnPostNewOpinion()
        {
            base.AddContext(new OpinionVmi(true));

            (App.Current as App).NavigateTo(
                new NewOpinionView(base.DataSourceContext, CurrentSubject, null, OnReturnFromNewOpinion));
        }
        
        private void SetInternalSelectedStates()
        {
            foreach (var vmi in Opinions)
                ((OpinionVmi) vmi).IsSelected = vmi == SelectedChildOpinion;
        }
        
        private void OnReturnFromNewOpinion(OpinionVmi opinion)
        {
            Opinions.Insert(0,opinion);
        }
    }
}
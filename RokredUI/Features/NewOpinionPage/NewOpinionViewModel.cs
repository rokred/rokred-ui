using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.Features.EditTextPage;
using RokredUI.Features.OpinionPage;
using RokredUI.Features.SubjectPage;
using Xamarin.Forms;

namespace RokredUI.Features.NewOpinionPage
{
    public class NewOpinionViewModel : BaseViewModel
    {
        [Reactive] public OpinionVmi CurrentOpinion { get; set; }
        [Reactive] public SubjectVmi CurrentSubject { get; set; }
        
        [Reactive] public OpinionVmi NewOpinion { get; set; } = new OpinionVmi();
          
        public ReactiveCommand<Unit, Unit> EditTitleCommand { get; set; }
        public ReactiveCommand<Unit, Unit> EditBodyCommand { get; set; }

        public IRokredListChildDataSource ParentVmi {
            get
            {
                if (CurrentOpinion == null)
                    return CurrentSubject;
                else
                    return CurrentOpinion;
            }} 
        
        public Action<OpinionVmi> ReturnAction { get; set; }
        
        public ReactiveCommand<Unit, Unit> PostNewOpinionCommand { get; set; }
        

        public NewOpinionViewModel(SubjectVmi selectedChildSubject, 
            OpinionVmi selectedChildOpinion, Action<OpinionVmi> returnAction) : base()
        {
            CurrentSubject = selectedChildSubject;
            CurrentOpinion = selectedChildOpinion;
            ReturnAction = returnAction;
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            PostNewOpinionCommand = ReactiveCommand.Create(OnPostNewOpinion, Observable.Return(CanPostOpinion()));
            EditTitleCommand = ReactiveCommand.Create(OnEditTitle, Observable.Return(true));
            EditBodyCommand = ReactiveCommand.Create(OnEditBody, Observable.Return(true));

            Device.BeginInvokeOnMainThread(OnEditTitle);
        }
        
        private void OnPostNewOpinion()
        {
            (App.Current as App).PopNavigation();
            ReturnAction?.Invoke(NewOpinion);
        }

        private void OnEditTitle()
        {
            (App.Current as App).NavigateTo(new EditTextView(NewOpinion.Title, OnReturnFromEditTitle));
        }
        
        private void OnEditBody()
        {
            (App.Current as App).NavigateTo(new EditTextView(NewOpinion.Body, OnReturnFromEditBody));
        }

        private void OnReturnFromEditTitle(string text)
        {
            NewOpinion.Title = text;
        }
        
        private void OnReturnFromEditBody(string text)
        {
            NewOpinion.Body = text;
        }

        private bool CanPostOpinion() => !string.IsNullOrWhiteSpace(NewOpinion.Title);
    }
}
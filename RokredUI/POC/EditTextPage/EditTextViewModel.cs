using System;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RokredUI.POC.EditTextPage
{
    public class EditTextViewModel : BaseViewModel
    {
        [Reactive] public  string CurrentText { get; set; }
        
        [Reactive] public ReactiveCommand<Unit, Unit> DoneCommand { get; set; }
        
        public Action<string> ReturnAction { get; set; }
        
        public EditTextViewModel(string text, Action<string> returnAction) : base()
        {
            CurrentText = text;
            ReturnAction = returnAction;
        }

        protected override void Initialize()
        {
            base.Initialize();
            
            DoneCommand = ReactiveCommand.Create(OnDone, Observable.Return(CanSaveOpinion()));
        }

        private void OnDone()
        {
            (App.Current as App).PopNavigation();
            ReturnAction?.Invoke(CurrentText);
        }

        private bool CanSaveOpinion() => !string.IsNullOrWhiteSpace(CurrentText);
    }
}
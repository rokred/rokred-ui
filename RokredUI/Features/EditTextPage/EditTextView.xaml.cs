using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Features.EditTextPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTextView : ReactiveContentPage<EditTextViewModel>
    {
        public EditTextView(string text, Action<string> returnAction)
        {
            InitializeComponent();
            
            ViewModel = new EditTextViewModel(text, returnAction);
            
            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.CurrentText, v => v.EditorText.Text);
                this.BindCommand(ViewModel, vm => vm.DoneCommand, v => v.ButtonDone);

                EditorText.Focus();
            });
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.POC.SubjectPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectView : ReactiveContentPage<SubjectViewModel>
    {
        public SubjectView(SubjectVmi selectedChildSubject)
        {
            InitializeComponent();
            
            ViewModel = new SubjectViewModel(selectedChildSubject);
            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                // post opinion
                this.BindCommand(ViewModel, 
                        vm => vm.PostNewOpinionCommand, 
                        v => v.PostOpinionButton)
                    .DisposeWith(disposables);
                
                // select child opinion (todo: activate fromm list of opinions)
                this.BindCommand(ViewModel, 
                        vm => vm.SelectChildOpinionCommand, 
                        v => v.SelectChildOpinionButton)
                    .DisposeWith(disposables);
            });
        }
    }
}
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

namespace RokredUI.POC.OpinionPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpinionView : ReactiveContentPage<OpinionViewModel>
    {
        public OpinionView(OpinionVmi selectedChildOpinion)
        {
            InitializeComponent();
            
            ViewModel = new OpinionViewModel(selectedChildOpinion);
            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                // post new child opinion 
                this.BindCommand(ViewModel, 
                        vm => vm.PostNewOpinionCommand, 
                        v => v.PostNewOpinionButton)
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
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

namespace RokredUI.POC.NewOpinionPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOpinionView : ReactiveContentPage<NewOpinionViewModel>
    {
        public NewOpinionView()
        {
            InitializeComponent();
            
            ViewModel = new NewOpinionViewModel();
            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                // post new child opinion 
                this.BindCommand(ViewModel, 
                        vm => vm.PostNewOpinionCommand, 
                        v => v.LandingPageButton)
                    .DisposeWith(disposables);
                
            });
        }
    }
}
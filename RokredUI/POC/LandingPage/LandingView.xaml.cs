using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using DynamicData.Annotations;
using ReactiveUI;
using ReactiveUI.XamForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.POC.LandingPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingView : ReactiveContentPage<LandingViewModel>
    {
        public LandingView()
        {
            InitializeComponent();
            
            ViewModel = new LandingViewModel();
            BindControls();
        }

        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                // select child category (todo: activate fromm list of categories)
                this.BindCommand(ViewModel, 
                        vm => vm.SelectChildCategoryCommand, 
                        v => v.SelectChildCategoryButton)
                    .DisposeWith(disposables);
            });
        }
    }
}
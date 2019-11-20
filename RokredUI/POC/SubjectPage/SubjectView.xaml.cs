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
        public SubjectView(DataSourceContext dataSourceContext, SubjectVmi selectedChildSubject)
        {
            InitializeComponent();
            
            ViewModel = new SubjectViewModel(selectedChildSubject);
            ViewModel.DataSourceContext = dataSourceContext;
            ViewModel.DataSourceContextIndex = ViewModel.DataSourceContext.ContextItems.Count;
            
            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Opinions,
                    v => v.ListOpinions.Source).DisposeWith(disposables);
                
                this.Bind(ViewModel, vm => vm.OpinionTappedCommand,
                    v => v.ListOpinions.ListItemTappedCommand).DisposeWith(disposables);


                this.Bind(ViewModel, vm => vm.SelectedChildOpinion,
                    v => v.ListOpinions.SelectedItem).DisposeWith(disposables);

                // post opinion
                this.BindCommand(ViewModel,vm => vm.PostNewOpinionCommand, 
                    v => v.ButtonNewOpinion).DisposeWith(disposables);
            });
        }
    }
}
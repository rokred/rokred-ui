using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.Features.SubjectPage;
using Xamarin.Forms.Xaml;

namespace RokredUI.Features.OpinionPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpinionView : ReactiveContentPage<OpinionViewModel>
    {
        public OpinionView(DataSourceContext dataSourceContext, SubjectVmi selectedChildSubject, OpinionVmi selectedChildOpinion)
        {
            InitializeComponent();
            
            ViewModel = new OpinionViewModel(selectedChildSubject, selectedChildOpinion);
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
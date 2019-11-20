using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.POC.OpinionPage;
using RokredUI.POC.SubjectPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.POC.NewOpinionPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOpinionView : ReactiveContentPage<NewOpinionViewModel>
    {
        public NewOpinionView(DataSourceContext dataSourceContext, 
            SubjectVmi selectedChildSubject, 
            OpinionVmi selectedChildOpinion,
            Action<OpinionVmi> returnAction)
        {
            InitializeComponent();

            ViewModel = new NewOpinionViewModel(selectedChildSubject, selectedChildOpinion, returnAction);
            ViewModel.DataSourceContext = dataSourceContext;
            ViewModel.DataSourceContextIndex = ViewModel.DataSourceContext.ContextItems.Count;

            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.NewOpinion.Title, v => v.LabelOpinionTitle.Text);
                this.Bind(ViewModel, vm => vm.NewOpinion.Body, v => v.LabelOpinionBody.Text);

                this.Bind(ViewModel, vm => vm.NewOpinion.EmptyTitle, 
                    v => v.LabelOpinionTitleHelper.IsVisible);
                this.Bind(ViewModel, vm => vm.NewOpinion.EmptyBody, 
                    v => v.LabelOpinionBodyHelper.IsVisible);

                this.BindCommand(ViewModel, vm => vm.EditTitleCommand,
                    v => v.ButtonEditTitle);
                this.BindCommand(ViewModel, vm => vm.EditBodyCommand,
                    v => v.ButtonEditBody);
                this.BindCommand(ViewModel, vm => vm.PostNewOpinionCommand, v => v.ButtonNewOpinion);


               
            });
        }
    }
}
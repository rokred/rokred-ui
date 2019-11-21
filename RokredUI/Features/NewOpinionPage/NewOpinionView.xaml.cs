using System;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.Features.OpinionPage;
using RokredUI.Features.SubjectPage;
using Xamarin.Forms.Xaml;

namespace RokredUI.Features.NewOpinionPage
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
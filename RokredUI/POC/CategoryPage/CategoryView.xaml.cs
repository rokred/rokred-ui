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

namespace RokredUI.POC.CategoryPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryView : ReactiveContentPage<CategoryViewModel>
    {
        public CategoryView(DataSourceContext dataSourceContext, CategoryVmi selectedChildCategory)
        {
            InitializeComponent();
            
            ViewModel = new CategoryViewModel(selectedChildCategory);
            ViewModel.DataSourceContext = dataSourceContext;
            ViewModel.DataSourceContextIndex = ViewModel.DataSourceContext.ContextItems.Count;
            BindControls();
        }
        
        private void BindControls()
        {
            this.WhenActivated(disposables =>
            {
                this.Bind(ViewModel, vm => vm.Categories,
                    v => v.ListCategories.Source).DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Subjects,
                    v => v.ListSubjects.Source).DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.CategoryTappedCommand,
                    v => v.ListCategories.ListItemTappedCommand).DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.SubjectTappedCommand,
                    v => v.ListSubjects.ListItemTappedCommand).DisposeWith(disposables);
                
                this.Bind(ViewModel, vm => vm.SelectedChildCategory,
                    v => v.ListCategories.SelectedItem).DisposeWith(disposables);

                this.Bind(ViewModel, vm => vm.SelectedChildSubject,
                    v => v.ListSubjects.SelectedItem).DisposeWith(disposables);
           
            });
        }
    }
}
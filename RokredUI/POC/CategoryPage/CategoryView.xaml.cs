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
        public CategoryView(CategoryVmi selectedChildCategory)
        {
            InitializeComponent();
            
            ViewModel = new CategoryViewModel(selectedChildCategory);
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
                
                // select child subject (todo: activate fromm list of subjects)
                this.BindCommand(ViewModel, 
                        vm => vm.SelectChildSubjectCommand, 
                        v => v.SelectChildSubjectButton)
                    .DisposeWith(disposables);
            });
        }
    }
}
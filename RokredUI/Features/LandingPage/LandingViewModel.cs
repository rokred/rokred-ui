using System;
using System.Collections.Generic;
using System.Reactive;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.Features.CategoryPage;

namespace RokredUI.Features.LandingPage
{
    public class LandingViewModel : BaseViewModel
    {
        private List<CategoryVmi> _categories { get; set; }
        [Reactive] public IList<IRokredListChildDataSource> Categories { get; set; }
        [Reactive] public IRokredListChildDataSource SelectedChildCategory { get; set; }
        public ReactiveCommand<IRokredListChildDataSource, Unit> CategoryTappedCommand { get; set; }
        
        public LandingViewModel() : base()
        {
        }
        
        protected override void Initialize()
        {
            base.Initialize();

            _categories = base.GetCategories(null);
            Categories = new List<IRokredListChildDataSource>(_categories);
            
            CategoryTappedCommand = ReactiveCommand.Create(
                new Action<IRokredListChildDataSource>(
                    async ds => await OnSelectCategory(ds)));
        }
        
        private async Task OnSelectCategory(IRokredListChildDataSource category)
        {
            SelectedChildCategory = category;
            SetInternalSelectedStates();

            base.AddContext(category);

            (App.Current as App).NavigateTo(new CategoryView(base.DataSourceContext, category as CategoryVmi));
        }

        private void SetInternalSelectedStates()
        {
            foreach (var category in _categories)
                category.IsSelected = category == SelectedChildCategory;
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.POC.LandingPage;
using RokredUI.POC.SubjectPage;

namespace RokredUI.POC.CategoryPage
{
    public class CategoryViewModel : BaseViewModel
    {
        private List<CategoryVmi> _categories { get; set; }
        private List<SubjectVmi> _subjects { get; set; }

        private SubjectVmi _selectedChildSubject;
        private CategoryVmi _selectedChildCategory;
        
        [Reactive] public CategoryVmi CurrentCategory { get; set; }
        
        [Reactive] public IList<IRokredListChildDataSource> Categories { get; set; }
        [Reactive] public IList<IRokredListChildDataSource> Subjects { get; set; }

        [Reactive] public IRokredListChildDataSource SelectedChildCategory
        {
            get => _selectedChildCategory;
            set
            {
                _selectedChildCategory = value as CategoryVmi;
                if (value != null) SelectedChildSubject = null;
            }
        }

        [Reactive] public IRokredListChildDataSource SelectedChildSubject
        {
            get => _selectedChildSubject;
            set
            {
                _selectedChildSubject = value as SubjectVmi;
                if (value != null) SelectedChildCategory = null;
            }
        }
   
        public ReactiveCommand<IRokredListChildDataSource, Unit> CategoryTappedCommand { get; set; }

        public ReactiveCommand<IRokredListChildDataSource, Unit> SubjectTappedCommand { get; set; }
        
        public CategoryViewModel(CategoryVmi selectedChildCategory)
            : base(selectedChildCategory)
        {
            
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            CurrentCategory = _currentContext as CategoryVmi;
            
            _categories = base.GetCategories(CurrentCategory);
            Categories = new List<IRokredListChildDataSource>(_categories);
            
            _subjects = base.GetSubjects(CurrentCategory);
            Subjects = new List<IRokredListChildDataSource>(_subjects);
            
            CategoryTappedCommand = ReactiveCommand.Create(
                new Action<IRokredListChildDataSource>(
                    async ds => await OnSelectCategory(ds)));
            SubjectTappedCommand = ReactiveCommand.Create(
                new Action<IRokredListChildDataSource>(
                    async ds => await OnSelectSubject(ds)));
        }
        
        private async Task OnSelectCategory(IRokredListChildDataSource category)
        {
            SelectedChildCategory = category;
            SetInternalSelectedStates();

            (App.Current as App).NavigateTo(new CategoryView(category as CategoryVmi));
        }
        
        private async Task OnSelectSubject(IRokredListChildDataSource subject)
        {
            SelectedChildSubject = subject;
            SetInternalSelectedStates();

            (App.Current as App).NavigateTo(new SubjectView(subject as SubjectVmi));
        }
        

        private void SetInternalSelectedStates()
        {
            foreach (var category in _categories)
                category.IsSelected = category == SelectedChildCategory;
        }
        
        
    }
}
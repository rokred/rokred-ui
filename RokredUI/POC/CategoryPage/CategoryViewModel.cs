using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.POC.LandingPage;
using RokredUI.POC.SubjectPage;

namespace RokredUI.POC.CategoryPage
{
    public class CategoryViewModel : BaseViewModel
    {
        private SubjectVmi _selectedChildSubject;
        private CategoryVmi _selectedChildCategory;
        
        [Reactive] public CategoryVmi CurrentCategory { get; set; }
        
        [Reactive] public List<CategoryVmi> Categories { get; set; }
        [Reactive] public List<SubjectVmi> Subjects { get; set; }

        [Reactive] public CategoryVmi SelectedChildCategory
        {
            get => _selectedChildCategory;
            set
            {
                _selectedChildCategory = value;
                if (value != null) SelectedChildSubject = null;
            }
        }

        [Reactive] public SubjectVmi SelectedChildSubject
        {
            get => _selectedChildSubject;
            set
            {
                _selectedChildSubject = value;
                if (value != null) SelectedChildCategory = null;
            }
        }
        
        public ReactiveCommand<Unit, Unit> SelectChildCategoryCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SelectChildSubjectCommand { get; set; }
        
        public CategoryViewModel(CategoryVmi selectedChildCategory)
        {
            CurrentCategory = selectedChildCategory;
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            SelectChildCategoryCommand = ReactiveCommand.Create(OnSelectCategory, Observable.Return(true));
            SelectChildSubjectCommand = ReactiveCommand.Create(OnSelectSubject, Observable.Return(true));
        }
        
        private void OnSelectCategory()
        {
            App.Current.MainPage = new CategoryView(SelectedChildCategory);
        }
        
        private void OnSelectSubject()
        {
            App.Current.MainPage = new SubjectView(SelectedChildSubject);
        }
    }
}
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.POC.CategoryPage;

namespace RokredUI.POC.LandingPage
{
    public class LandingViewModel : BaseViewModel
    {
        [Reactive] public List<CategoryVmi> Categories { get; set; }
        [Reactive] public CategoryVmi SelectedChildCategory { get; set; }
        
        public ReactiveCommand<Unit, Unit> SelectChildCategoryCommand { get; set; }
        
        public LandingViewModel()
        {
        }
        
        protected override void Initialize()
        {
            base.Initialize();
            
            SelectChildCategoryCommand = ReactiveCommand.Create(OnSelectCategory, Observable.Return(true));
        }
        
        private void OnSelectCategory()
        {
            App.Current.MainPage = new CategoryView(SelectedChildCategory);
        }
    }
}
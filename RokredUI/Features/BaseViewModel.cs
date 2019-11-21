using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.Features.CategoryPage;
using RokredUI.Features.LandingPage;
using RokredUI.Features.OpinionPage;
using RokredUI.Features.SubjectPage;

namespace RokredUI.Features
{
    public abstract class BaseViewModel : ReactiveObject, IDisposable, IViewModel
    {
        protected IRokredListChildDataSource _currentContext;
      
        public int DataSourceContextIndex { get; set; }
        
        [Reactive] public DataSourceContext DataSourceContext { get; set; }
        [Reactive] public UserVmi User { get; set; }

        protected BaseViewModel(IRokredListChildDataSource currentContext = null)
        {
            _currentContext = currentContext;
            Initialize();
        }

        protected virtual void Initialize()
        {
            User = GetUser();
        }
        private UserVmi GetUser()
        {
            return new UserVmi() { Name = "Kris Adams" };
        }
        
        //protected readonly INavigationService Navigator;

        private CompositeDisposable Disposables { get; }

        private BaseViewModel()
        {
            Disposables = new CompositeDisposable();
        }

        public void Dispose()
        {
            Disposables.Dispose();
        }

        protected List<CategoryVmi> GetCategories(CategoryVmi parent)
        {
            if (parent == null)
                return new List<CategoryVmi>()
                {
                    new CategoryVmi(1, "People"){ IsNew = true},
                    new CategoryVmi(2, "Entertainment"){ IsNew = true},
                    new CategoryVmi(3, "Sport"){ IsNew = true},
                    new CategoryVmi(4, "Places of the Earth"),
                    new CategoryVmi(5, "Events in my and everyone else's lives"),
                    new CategoryVmi( 6, "Science and Technology"),
                    new CategoryVmi(7, "History and Literature"),
                };
            else if (parent.Id == 1)
                return new List<CategoryVmi>()
                {
                    new CategoryVmi(8, parent.Id, "People in Entertainment") {IsNew = true},
                    new CategoryVmi(9, parent.Id, "People in Business") {IsNew = true},
                    new CategoryVmi(10, parent.Id, "All About Me") {IsNew = true},
                };
            else if (parent.Id == 2)
                return new List<CategoryVmi>()
                {
                    new CategoryVmi(11, parent.Id, "Movies and TV") {IsNew = true},
                    new CategoryVmi(12, parent.Id, "Music") {IsNew = true},
                };
            else if (parent.Id == 3)
                return new List<CategoryVmi>()
                {
                    new CategoryVmi(13, parent.Id, "MMA") {IsNew = true},
                };
            else
            {
                return new List<CategoryVmi>();
            }
        }

        protected List<SubjectVmi> GetSubjects(CategoryVmi currentCategory)
        {
            if (currentCategory.Id == 8)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Sexiest Man Alive 2019 - John Legend") {IsNew = true},
                    new SubjectVmi("Favourite Actor / Actress") {IsNew = true},
                };
            if (currentCategory.Id == 9)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Elon Musk") {IsNew = true},
                    new SubjectVmi("Richard Branson") {IsNew = true},
                };
            if (currentCategory.Id == 10)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Self-Development and how to win at life") {IsNew = true},
                };
            if (currentCategory.Id == 11)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Favourite Movies") {IsNew = true},
                    new SubjectVmi("Movies that stuck with me") {IsNew = true},
                };
            if (currentCategory.Id == 12)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Current favourite song") {IsNew = true},
                };
            if (currentCategory.Id == 3)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Favourite Sport") {IsNew = true},
                };
            if (currentCategory.Id == 13)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Upcoming Fights") {IsNew = true},
                    new SubjectVmi("Favourite Fighter") {IsNew = true},
                    new SubjectVmi("Dream Matchups") {IsNew = true},
                };
            if (currentCategory.Id == 4)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Summer vs. Winter") {IsNew = true},
                    new SubjectVmi("Best Beaches") {IsNew = true},
                    new SubjectVmi("Worst place to live") {IsNew = true},
                    new SubjectVmi("Best place to live") {IsNew = true},
                };
            if (currentCategory.Id == 5)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Christmas Time") {IsNew = true},
                    new SubjectVmi("Commuting to work") {IsNew = true},
                    new SubjectVmi("Most embarrassing moment") {IsNew = true},
                };
            if (currentCategory.Id == 6)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("Colonising the moon. The Lunar Gateway.") {IsNew = true},
                    new SubjectVmi("iPhone vs. Android") {IsNew = true},
                };
            if (currentCategory.Id == 7)
                return new List<SubjectVmi>()
                {
                    new SubjectVmi("When did humanity really start?") {IsNew = true},
                    new SubjectVmi("Best books and why") {IsNew = true},
                };
            else return new List<SubjectVmi>();
        }

        protected List<OpinionVmi> GetOpinions(SubjectVmi currentSubject)
        {
            return new List<OpinionVmi>()
            {
            };
        }
        
        protected List<OpinionVmi> GetOpinions(OpinionVmi currentOpinion)
        {
            return new List<OpinionVmi>()
            {
            };
        }

        protected void AddContext(IRokredListChildDataSource item)
        {
           if (DataSourceContext == null)
               DataSourceContext = new DataSourceContext();

           while (DataSourceContext.ContextItems.Count >= DataSourceContextIndex + 1)
           {
               DataSourceContext.ContextItems.RemoveAt(DataSourceContext.ContextItems.Count - 1);
           }
           
           DataSourceContext.ContextItems.Add(item);
        } 
    }
}
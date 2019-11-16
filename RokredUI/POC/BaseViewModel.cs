using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.POC.CategoryPage;
using RokredUI.POC.LandingPage;
using RokredUI.POC.OpinionPage;
using RokredUI.POC.SubjectPage;
using RokredUI.Services;
using Splat;

namespace RokredUI.POC
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

        private BaseViewModel(INavigationService navigationService = null)
        {
            //Navigator = navigationService ?? Locator.Current.GetService<INavigationService>();
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
                    new CategoryVmi("Science"){ IsNew = true},
                    new CategoryVmi("Sport"){ IsNew = true},
                    new CategoryVmi("Geography"){ IsNew = true},
                    new CategoryVmi("History"),
                    new CategoryVmi("Let's make sure that these things wrap. For now, we will let them have no limit."),
                    new CategoryVmi("examples to show colors"),
                };
            else
                return new List<CategoryVmi>()
                {
                    new CategoryVmi("Child Category 1"){ IsNew = true},
                    new CategoryVmi("Child Category 2"){ IsNew = true},
                    new CategoryVmi("Child Category 3"){ IsNew = true},
                    new CategoryVmi("Child Category 4"){ },
                    new CategoryVmi("Child Category 5"){ },
                 
                };
        }

        protected List<SubjectVmi> GetSubjects(CategoryVmi currentCategory)
        {
            return new List<SubjectVmi>()
            {
                new SubjectVmi("Some SUBJECT in this category"){ IsNew = true},
                new SubjectVmi("these are static for now"){ IsNew = true},
                new SubjectVmi("hopefully will have some real ones soon"){ IsNew = true},
                new SubjectVmi("Let's make sure that these things wrap. For now, we will let them have no limit."),
                new SubjectVmi("examples to show colors"),
            };
        }

        protected List<OpinionVmi> GetOpinions(SubjectVmi currentSubject)
        {
            return new List<OpinionVmi>()
            {
                new OpinionVmi("Some OPINION here"){ IsNew = true},
                new OpinionVmi("These should be arranged by date", "This is the body"){ IsNew = true},
                new OpinionVmi("hopefully will have some real ones soon"){ IsNew = true},
                new OpinionVmi("Let's make sure that these things wrap. For now, we will let them have no limit."),
                new OpinionVmi("examples to show colors", "This has a body"),
            };
        }
        
        protected List<OpinionVmi> GetOpinions(OpinionVmi currentOpinion)
        {
            return new List<OpinionVmi>()
            {
                new OpinionVmi("From a PARENT OPINION", "This is the body of that opinion."){ IsNew = true },
                new OpinionVmi("Some OPINION here"){ IsNew = true},
                new OpinionVmi("These should be arranged by date. I have no idea how we will handle super long ones for now.", "So I will just let them be as long as they wish. But I guess we should concat them in the list"){},
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
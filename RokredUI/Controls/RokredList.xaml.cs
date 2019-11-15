using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.POC.CategoryPage;
using RokredUI.POC.OpinionPage;
using RokredUI.POC.SubjectPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RokredList
    {
        public RokredList()
        {
            InitializeComponent();
        }

        protected void SourceChanged(IList<IRokredListChildDataSource> val)
        {
            StackChildren.Children.Clear();
            
            if (val != null)
            {
                AddViews(val);
            }
        }

        private void AddViews(IEnumerable<IRokredListChildDataSource> source)
        {
            foreach (var category in source.OfType<CategoryVmi>())
            {
                var view = new CategoryListItem(category);
                view.SelectedCategory = SelectedItem as CategoryVmi;
                var button = new RokredButton();
                button.Content = view;
                
                button.Command = ListItemTappedCommand;
                button.CommandParameter = category;
                
                StackChildren.Children.Add(button);
            }
            
            foreach (var subject in source.OfType<SubjectVmi>())
            {
                var view = new SubjectListItem(subject);
                var button = new RokredButton();
                button.Content = view;
                                      
                button.Command = ListItemTappedCommand;
                button.CommandParameter = subject;
                                      
                StackChildren.Children.Add(button);
            }
            foreach (var opinion in source.OfType<OpinionVmi>())
            {
                var view = new OpinionListItem(opinion);
                var button = new RokredButton();
                button.Content = view;
                                    
                button.Command = ListItemTappedCommand;
                button.CommandParameter = opinion;
                                    
                StackChildren.Children.Add(button);
            }
            
        }

        protected void ListItemTappedCommandChanged(ReactiveCommand<IRokredListChildDataSource, Unit> val)
        {
            foreach (var child in StackChildren.Children)
                if (child is RokredButton button)
                    button.Command = val;
        }

        protected void SelectedItemChanged(IRokredListChildDataSource val)
        {
            foreach (var child in StackChildren.Children)
                if (child is RokredButton button)
                   if (button.Content is IRokredListChildView view)
                       view.SetIsSelected(val == view.DataSource);
        }



        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(
                "SelectedItem",
                typeof(IRokredListChildDataSource),
                typeof(RokredList),
                default(IRokredListChildDataSource),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredList) bindable;
                    thisControl.SelectedItemChanged((IRokredListChildDataSource) newValue);
                });

        public IRokredListChildDataSource SelectedItem
        {
            get => (IRokredListChildDataSource) GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

     

     


        public static readonly BindableProperty ListItemTappedCommandProperty =
            BindableProperty.Create(
                "ListItemTappedCommand",
                typeof(ReactiveCommand<IRokredListChildDataSource, Unit>),
                typeof(RokredList),
                default(ReactiveCommand<IRokredListChildDataSource, Unit>),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredList) bindable;
                    thisControl.ListItemTappedCommandChanged((ReactiveCommand<IRokredListChildDataSource, Unit>) newValue);
                });

        public ReactiveCommand<IRokredListChildDataSource, Unit> ListItemTappedCommand
        {
            get => (ReactiveCommand<IRokredListChildDataSource, Unit>) GetValue(ListItemTappedCommandProperty);
            set => SetValue(ListItemTappedCommandProperty, value);
        }

     

     


        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                "Source",
                typeof(IList<IRokredListChildDataSource>),
                typeof(RokredList),
                default(IList<IRokredListChildDataSource>),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredList) bindable;
                    thisControl.SourceChanged((IList<IRokredListChildDataSource>) newValue);
                });

        public IList<IRokredListChildDataSource> Source
        {
            get => (IList<IRokredListChildDataSource>) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

     

    }
}
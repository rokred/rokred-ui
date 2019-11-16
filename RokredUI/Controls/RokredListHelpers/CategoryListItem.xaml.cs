using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RokredUI.POC.CategoryPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls.RokredListHelpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryListItem : IRokredListChildView
    {
        private readonly CategoryVmi _category;

        public IRokredListChildDataSource DataSource => _category;
        
        public CategoryListItem(CategoryVmi category)
        {
            InitializeComponent();

            _category = category;
            
            IconView.Context = category;
            LabelText.Text = category.Name;
            LabelText.IsBold = category.IsNew;
            
            SetSelectedState();
        }

        protected void SelectedCategoryChanged(CategoryVmi val)
        {
            _category.IsSelected = _category == val;
            SetSelectedState();
        }

        public void SetIsSelected(bool isSelected)
        {
            _category.IsSelected = isSelected;
            SetSelectedState();
        }

        
        private void SetSelectedState()
        {
            IconView.IsSelected = _category.IsSelected;
            
            if (_category.IsSelected)
            {
                BackgroundColor = Color.Red;
                LabelText.TextColor = Color.White;
                ImageChevron.Source = "chevron-icon.svg";
                IconView.Opacity = 1f;
            }
            else
            {
                BackgroundColor = _category.IsNew ? Color.White : Color.FromHex("F5F5F5");
                IconView.Opacity = _category.IsNew ? 1f : 0.1f;
                
                LabelText.TextColor = Color.Black;
                ImageChevron.Source = "chevron-dark.svg";
            }
            
        }


        public static readonly BindableProperty SelectedCategoryProperty =
            BindableProperty.Create(
                "SelectedCategory",
                typeof(CategoryVmi),
                typeof(CategoryListItem),
                default(CategoryVmi),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (CategoryListItem) bindable;
                    thisControl.SelectedCategoryChanged((CategoryVmi) newValue);
                });

        public CategoryVmi SelectedCategory
        {
            get => (CategoryVmi) GetValue(SelectedCategoryProperty);
            set => SetValue(SelectedCategoryProperty, value);
        }


      
    }
}
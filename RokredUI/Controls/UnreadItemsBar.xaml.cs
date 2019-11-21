using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.POC.CategoryPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UnreadItemsBar 
    {
        public UnreadItemsBar()
        {
            InitializeComponent();
        }

        protected void ReferenceItemChanged(IRokredListChildDataSource val)
        {
            if (val is CategoryVmi category)
            {
                
            }
        }

        private void AddUnreadCategories()
        {
            
        }



        public static readonly BindableProperty ReferenceItemProperty =
            BindableProperty.Create(
                "ReferenceItem",
                typeof(IRokredListChildDataSource),
                typeof(UnreadItemsBar),
                default(IRokredListChildDataSource),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (UnreadItemsBar) bindable;
                    thisControl.ReferenceItemChanged((IRokredListChildDataSource) newValue);
                });

        public IRokredListChildDataSource ReferenceItem
        {
            get => (IRokredListChildDataSource) GetValue(ReferenceItemProperty);
            set => SetValue(ReferenceItemProperty, value);
        }

     

    }
}
using Xamarin.Forms;

namespace RokredUI.Controls.RokredListHelpers
{
    public class DynamicListItem : ContentView
    {
        public DynamicListItem(IRokredListChildDataSource data)
        {
            BoundDataSource = data;
        }
        
        public DynamicListItem()
        {
            
        }

        protected void BoundDataSourceChanged(IRokredListChildDataSource val)
        {
            var view = val.CreateDynamicListItem(true);
            Content = view as View;
        }
        
        public static readonly BindableProperty BoundDataSourceProperty =
            BindableProperty.Create(
                "BoundDataSource",
                typeof(IRokredListChildDataSource),
                typeof(DynamicListItem),
                default(IRokredListChildDataSource),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (DynamicListItem) bindable;
                    thisControl.BoundDataSourceChanged((IRokredListChildDataSource) newValue);
                });

        public IRokredListChildDataSource BoundDataSource
        {
            get => (IRokredListChildDataSource) GetValue(BoundDataSourceProperty);
            set => SetValue(BoundDataSourceProperty, value);
        }

     

    }
}
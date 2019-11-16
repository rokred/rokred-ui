using System.Linq;
using RokredUI.POC;
using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class BreadcrumbBar : ContentView
    {
        private StackLayout _stack;
        private ScrollView _scroll;
        
        public BreadcrumbBar()
        {
            BackgroundColor = Color.Black;
            HeightRequest = 50;
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Start;

            _stack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            _scroll = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                VerticalScrollBarVisibility = ScrollBarVisibility.Never,
                
                Content = _stack
            };
            
            
            Content = _scroll;
        }

        protected void DataSourceContextChanged(DataSourceContext val)
        {
            _stack.Children.Clear();
            
            if (val.ContextItems.Any())
            {
                foreach (var contextItem in val.ContextItems)
                {
                    var label = new RokredLabel()
                    { 
                        Margin = 10, 
                        TextColor = Color.White,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Start,
                        Text = contextItem.ToString()
                    };  
                    
                    _stack.Children.Add(label);
                }
            }
            else
            {
                var label = new RokredLabel()
                { 
                    Margin = 10, 
                    TextColor = Color.White,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Start,
                    Text = "SELECT A CATEGORY"
                };  
                    
                _stack.Children.Add(label);
            }
            
            Device.BeginInvokeOnMainThread(async ()=> 
                await _scroll.ScrollToAsync(_stack.Children.Last(), ScrollToPosition.End, true));
        }
        
        public static readonly BindableProperty DataSourceContextProperty =
            BindableProperty.Create(
                "DataSourceContext",
                typeof(DataSourceContext),
                typeof(BreadcrumbBar),
                default(DataSourceContext),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (BreadcrumbBar) bindable;
                    thisControl.DataSourceContextChanged((DataSourceContext) newValue);
                });

        public DataSourceContext DataSourceContext
        {
            get => (DataSourceContext) GetValue(DataSourceContextProperty);
            set => SetValue(DataSourceContextProperty, value);
        }
    }
}
using System.Linq;
using FFImageLoading.Forms;
using RokredUI.Controls.BreadcrumbBarHelpers;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.Features;
using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class BreadcrumbBar : ContentView
    {
        private StackLayout _stack;
        private Grid _grid;
        private ScrollView _scroll;
        private CachedImage _leftGradient;
        
        public BreadcrumbBar()
        {
            BackgroundColor = Color.FromHex("2A2A2A");
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Start;

            _grid = new Grid
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
            };
            
            _stack = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                Margin = new Thickness(5,15)
            };
           
            _scroll = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                VerticalScrollBarVisibility = ScrollBarVisibility.Never,
                
                Content = _stack
            };
            
            _grid.Children.Add(_scroll);

            _leftGradient = new CachedImage
            {
                Source = "shadow-breadcrumbs.png",
                Aspect = Aspect.Fill,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Fill,
                WidthRequest = 80,
                Opacity = 0f,
                InputTransparent = true
            };
            _grid.Children.Add(_leftGradient);
            
            // the shadow shows we have scrolled
            _scroll.Scrolled += (sender, args) =>
            {
                Device.BeginInvokeOnMainThread(() => 
                { 
                    _leftGradient.Opacity = (args.ScrollX > 0) ? 0.8f : 0f;
                    //  _leftGradient.FadeTo( (args.ScrollX > 0) ? 1f : 0f, 100, Easing.CubicInOut);
                });
            };
            
            Content = _grid;
            DataSourceContextChanged(DataSourceContext);
        }

        protected void DataSourceContextChanged(DataSourceContext val)
        {
            _stack.Children.Clear();
            
            if (val != null && val.ContextItems.Any())
            {
                foreach (var contextItem in val.ContextItems)
                {
                    if (contextItem is IRokredListChildDataSource iData)
                    {
                        var view = iData.CreateBreadcrumbView();
                        _stack.Children.Add(view);
                    }
                }
            }
            else
            {
                var label = new RokredLabel()
                { 
                    Margin = new Thickness(25,10,10,10), 
                    IsBold = true,
                    FontSize = 12,
                    TextColor = Color.FromHex("DCDCDC"),
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
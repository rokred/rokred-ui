using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class BreadcrumbBar : ContentView
    {
        private RokredLabel _label;
        
        public BreadcrumbBar()
        {
            BackgroundColor = Color.Black;
            HeightRequest = 50;
            HorizontalOptions = LayoutOptions.Fill;
            VerticalOptions = LayoutOptions.Start;

            _label = new RokredLabel()
                { 
                    Margin = 10, 
                    TextColor = Color.White ,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center
                };

            Content = _label;
        }

        protected void TextChanged(string val)
        {
            _label.Text = val;
        }



        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                "Text",
                typeof(string),
                typeof(BreadcrumbBar),
                default(string),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (BreadcrumbBar) bindable;
                    thisControl.TextChanged((string) newValue);
                });

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

     

    }
}
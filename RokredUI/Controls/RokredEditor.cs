using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class RokredEditor : Editor
    {
        private const string BoldFont = "futura-bold";
        private const string MediumFont = "futura-medium";
        
        public RokredEditor()
        {
            BackgroundColor = Color.Transparent;
            FontFamily = BoldFont;
            VerticalOptions = LayoutOptions.FillAndExpand;
            TextChanged += (sender, args) => IsEmptyText = string.IsNullOrWhiteSpace(Text);
            
            Text = " "; // force a line height
        }

        protected void IsEmptyTextChanged(bool val)
        {
            
        }



        public static readonly BindableProperty IsEmptyTextProperty =
            BindableProperty.Create(
                "IsEmptyText",
                typeof(bool),
                typeof(RokredEditor),
                default(bool),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredEditor) bindable;
                    thisControl.IsEmptyTextChanged((bool) newValue);
                });

        public bool IsEmptyText
        {
            get => (bool) GetValue(IsEmptyTextProperty);
            set => SetValue(IsEmptyTextProperty, value);
        }
    }
}
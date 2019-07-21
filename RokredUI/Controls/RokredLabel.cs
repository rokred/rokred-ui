using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class RokredLabel : Label
    {
        private const string BoldFont = "futura-bold";
        private const string MediumFont = "futura-medium";

        private const double MediumSize = 17d;
        private const double BoldSize = 22d;

        public RokredLabel()
        {
            OnIsBoldChanged(IsBold);
            //  TextColor = Color.FromHex("#8EAFFF");
        }

        protected void OnIsBoldChanged(bool value)
        {
            FontFamily = value ? BoldFont : MediumFont;
            FontSize = ImplyFontSize ? (value ? BoldSize : MediumSize)
                : FontSize ;
        }

        public static readonly BindableProperty IsBoldProperty =
            BindableProperty.Create(
                "IsBold",
                typeof(bool),
                typeof(RokredLabel),
                default(bool),
                propertyChanged:
                (b, o, n) =>
                {
                    var thisControl = (RokredLabel)b;
                    thisControl.OnIsBoldChanged((bool)n);
                });

        public bool IsBold
        {
            get { return (bool)GetValue(IsBoldProperty); }
            set { SetValue(IsBoldProperty, value); }
        }

        protected void OnImplyFontSizeChanged(bool value)
        {

        }

        public static readonly BindableProperty ImplyFontSizeProperty =
            BindableProperty.Create(
                "ImplyFontSize",
                typeof(bool),
                typeof(RokredLabel),
                default(bool),
                propertyChanged:
                (b, o, n) =>
                {
                    var thisControl = (RokredLabel)b;
                    thisControl.OnImplyFontSizeChanged((bool)n);
                });

        public bool ImplyFontSize
        {
            get { return (bool)GetValue(ImplyFontSizeProperty); }
            set { SetValue(ImplyFontSizeProperty, value); }
        }
    }
}
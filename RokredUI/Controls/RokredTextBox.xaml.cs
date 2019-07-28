using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RokredTextBox
    {
        public RokredTextBox()
        {
            InitializeComponent();

            CommandParameter = this;

            OnTextChanged(Text);
        }

        private void OnTextChanged(string value)
        {
            var gold = (Color) Application.Current.Resources["HighlightGold"];
            var grey = (Color) Application.Current.Resources["DarkGrey"];

            OpinionLabel.Text = string.IsNullOrWhiteSpace(value) ? "nothing yet" : value.ToUpper();
            OpinionLabel.TextColor = string.IsNullOrWhiteSpace(value) ? grey : gold;
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(
                nameof(Text),
                typeof(string),
                typeof(RokredTextBox),
                default(string),
                propertyChanged:
                (b, o, n) =>
                {
                    var thisControl = (RokredTextBox) b;
                    thisControl.OnTextChanged((string) n);
                });

        public string Text
        {
            get => (string) GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }
}
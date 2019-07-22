using System.Threading.Tasks;

using Xamarin.Forms;

namespace RokredUI.Controls
{
    public partial class RokredTextBox
    {
        public RokredTextBox()
        {
            InitializeComponent();
            
                CommandParameter= this;

            OnTextChanged(Text);
        }

        protected void OnTextChanged(string value)
        {
            var gold = (Color)Application.Current.Resources["HighlightGold"];
            var grey = (Color)Application.Current.Resources["DarkGrey"];

            PART_Label.Text = string.IsNullOrWhiteSpace(value) ? "nothing yet" : value.ToUpper();
            PART_Label.TextColor = string.IsNullOrWhiteSpace(value) ? grey : gold;
        }

        protected async Task OnBoundPropertyStringNameChgd(string value)
        {

        }

        public static readonly BindableProperty BoundPropertyStringNameProperty =
          BindableProperty.Create(
            "BoundPropertyStringName",
            typeof(string),
            typeof(RokredTextBox),
            default(string),
            propertyChanged:
            async (b, o, n) =>
            {
                var thisControl = (RokredTextBox)b;
                await thisControl.OnBoundPropertyStringNameChgd((string)n);
            });

        public string BoundPropertyStringName
        {
            get => (string)GetValue(BoundPropertyStringNameProperty);
            set => SetValue(BoundPropertyStringNameProperty, value);
        }

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
            "Text",
            typeof(string),
            typeof(RokredTextBox),
            default(string),
            propertyChanged:
            (b, o, n) =>
            {
                var thisControl = (RokredTextBox)b;
                thisControl.OnTextChanged((string)n);
            });

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }
    }

}
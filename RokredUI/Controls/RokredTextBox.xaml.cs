using System;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RokredTextBox
    {
        public event EventHandler<EventArgs> LostFocusEvent;

        public RokredTextBox()
        {
            InitializeComponent();

         //   CommandParameter = this;

            Observable.FromEventPattern<FocusEventArgs>(
                        x => InvisibleEntry.Unfocused += x,
                        x => InvisibleEntry.Unfocused -= x)
                    .Where(e => e.EventArgs != null)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(ev =>
                    {
                        LostFocusEvent?.Invoke(ev.Sender, ev.EventArgs);
                    });

            Observable.FromEventPattern<TextChangedEventArgs>(
                        x => InvisibleEntry.TextChanged += x,
                        x => InvisibleEntry.TextChanged -= x)
                    .Where(e => e.EventArgs != null)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(ev =>
                    {
                        Text = InvisibleEntry.Text;
                    });

            OnTextChanged(Text);
        }

        public new void Focus()
        {
            InvisibleEntry.IsVisible = true;
            InvisibleEntry.Focus();
        }

        private void OnTextChanged(string value)
        {
            var gold = (Color) Application.Current.Resources["HighlightGold"];
            var grey = (Color) Application.Current.Resources["DarkGrey"];

            OpinionLabel.Text = string.IsNullOrWhiteSpace(value) ? "nothing yet" : value.ToUpper();
            OpinionLabel.TextColor = string.IsNullOrWhiteSpace(value) ? grey : gold;

            InvisibleEntry.Text = value;
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
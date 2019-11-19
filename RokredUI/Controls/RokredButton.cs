using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Windows.Input;
using ReactiveUI;
using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class RokredButton : ContentView
    {
        private TapGestureRecognizer TapRecognizer { get; } = new TapGestureRecognizer();

        public RokredButton()
        {
            TapRecognizer.Tapped += TappedCommandOnTapped;
            GestureRecognizers.Add(TapRecognizer);
        }

        private void TappedCommandOnTapped(object sender, EventArgs e)
        {
             Command?.Execute(CommandParameter);
             
          //  this.ScaleTo(0.96f, 100, Easing.CubicInOut).ToObservable()
          //      .ObserveOn(RxApp.MainThreadScheduler)
         //       .Subscribe(async x =>
         //       {
         //           await this.ScaleTo(1f, 100, Easing.CubicInOut);
         //           Command?.Execute(CommandParameter);
         //       });
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(
                nameof(CommandParameter),
                typeof(object),
                typeof(RokredButton));

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                nameof(Command),
                typeof(ICommand),
                typeof(RokredButton));

        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }
    }
}
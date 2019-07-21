using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class RokredButton: ContentView
    {
        public delegate void TouchDownDelegate();
        public delegate void TouchUpDelegate();

        public event TouchDownDelegate TouchDown;
        public event TouchUpDelegate TouchUp;

        public RokredButton()
        {
            GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(OnTapped),
                CommandParameter = TappedCommandParameter
            });
        }

        public void FireTouchUpEvent()
        {
            TouchUp?.Invoke();
            AnimateTouchUp().ConfigureAwait(false);
        }

        public void FireTouchDownEvent()
        {
            TouchDown?.Invoke();
            AnimateTouchDown().ConfigureAwait(false);
        }

        private void OnTapped()
        {
            if (IsEnabled)
                TappedCommand?.Execute(TappedCommandParameter);
        }

        private async Task AnimateTouchDown()
        {
            try
            {
             //   await this.ScaleTo(1.05, 75, Easing.CubicInOut);
                await this.ScaleTo(0.95f, 150, Easing.CubicInOut);
            }
            catch (Exception ex)
            {
                Scale = 0.95f;
            }
        }

        private async Task AnimateTouchUp()
        {
            try
            {
              //  await this.ScaleTo(1.05, 150, Easing.CubicInOut);
                await this.ScaleTo(1f, 200, Easing.CubicInOut);
            }
            catch (Exception ex)
            {
                Scale = 1f;
            }

        }

        protected void TappedCommandParameterChanged(object val)
        {
        }


        protected void TappedCommandChanged(Command val)
        {

        }

        protected void OnCornerRadiusChanged(float value)
        {

        }
        
        public static readonly BindableProperty TappedCommandParameterProperty =
            BindableProperty.Create(
                "TappedCommandParameter",
                typeof(object),
                typeof(RokredButton),
                default(object),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredButton)bindable;
                    thisControl.TappedCommandParameterChanged((object)newValue);
                });

        public object TappedCommandParameter
        {
            get => (object)GetValue(TappedCommandParameterProperty);
            set => SetValue(TappedCommandParameterProperty, value);
        }

        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create(
                "TappedCommand",
                typeof(Command),
                typeof(RokredButton),
                default(Command),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredButton)bindable;
                    thisControl.TappedCommandChanged((Command)newValue);
                });

        public Command TappedCommand
        {
            get => (Command)GetValue(TappedCommandProperty);
            set => SetValue(TappedCommandProperty, value);
        }
    }
}
using System.ComponentModel;
using Android.Content;
using Android.Views;
using RokredUI.Controls;
using RokredUI.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;

[assembly: ExportRenderer(typeof(RokredButton), typeof(RokredButtonRenderer))]

namespace RokredUI.Droid.Renderers
{
    public class RokredButtonRenderer : VisualElementRenderer<RokredButton>, View.IOnTouchListener
    {
        private RokredButton _storedButton;

        public RokredButtonRenderer(Context context)
            : base(context)
        {
        }
        
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (sender is RokredButton button)
            {
                _storedButton = button;
                SetOnTouchListener(this);
            }
        }

        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    _storedButton?.FireTouchDownEvent();
                    return true;
                case MotionEventActions.Up:
                    _storedButton?.FireTouchUpEvent();
                    return true;
                default:
                    return false;
            }
        }
    }
}

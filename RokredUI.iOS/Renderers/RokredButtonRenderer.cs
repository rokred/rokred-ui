using System.ComponentModel;
using Foundation;
using RokredUI.Controls;
using RokredUI.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RokredButton), typeof(RokredButtonRenderer))]
namespace RokredUI.iOS.Renderers
{
    public class RokredButtonRenderer : VisualElementRenderer<RokredButton>
    {
        private RokredButton _storedButton;

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (sender is RokredButton button)
            {
                _storedButton = button;
            }
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

            if (touches.AnyObject is UITouch)
            {
                _storedButton?.FireTouchDownEvent();
            }
        }

        public override void TouchesEnded(NSSet touches, UIEvent evt)
        {
            base.TouchesEnded(touches, evt);

            if (touches.AnyObject is UITouch)
            {
                _storedButton?.FireTouchUpEvent();
            }
        }

        public override void TouchesCancelled(NSSet touches, UIEvent evt)
        {
            base.TouchesCancelled(touches, evt);

            if (touches.AnyObject is UITouch)
            {
                _storedButton?.FireTouchUpEvent();
            }
        }
    }
}

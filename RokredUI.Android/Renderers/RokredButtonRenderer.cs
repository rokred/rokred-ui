using System.ComponentModel;
using Android.Content;
using RokredUI.Controls;
using RokredUI.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(RokredButton), typeof(RokredButtonRenderer))]

namespace RokredUI.Droid.Renderers
{
    public class RokredButtonRenderer : VisualElementRenderer<RokredButton>
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
                // do custom button code
                _storedButton = button;

                DoRoundedCorners(button);
            }
        }

        private void DoRoundedCorners(RokredButton button)
        {
            
        }
    }
}
using System;
using System.ComponentModel;
using RokredUI.Controls;
using RokredUI.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RoundedView), typeof(RoundedViewRenderer))]
namespace RokredUI.iOS.Renderers
{
    public class RoundedViewRenderer : VisualElementRenderer<ContentView>
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
         
            try
            {
                if (Layer == null || sender == null)
                    return;
         
                if (sender is RoundedView)
                {
                    var roundedView = sender as RoundedView;
                    var cornerRadius = roundedView.CornerRadius;
                    Layer.CornerRadius = cornerRadius;
                    Layer.MasksToBounds = true;
                    Layer.BackgroundColor = roundedView.BackgroundColor.ToCGColor();
         
                    if (Layer.Sublayers != null)
                        foreach (var child in Layer.Sublayers)
                            child.MasksToBounds = true;
                }
            }
            catch (Exception ex)
            {
                // ex.Log();
            }
        }
    }
}
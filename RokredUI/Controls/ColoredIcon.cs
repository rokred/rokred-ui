using FFImageLoading.Svg.Forms;
using RokredUI.Features.CategoryPage;
using RokredUI.Features.OpinionPage;
using RokredUI.Features.SubjectPage;
using Xamarin.Forms;

namespace RokredUI.Controls
{
    public class ColoredIcon : SvgCachedImage
    {
        private const float SizeOfIcon = 20f;
        
        public ColoredIcon()
        {
            BackgroundColor = Color.Transparent;
            WidthRequest = SizeOfIcon;
            HeightRequest = SizeOfIcon;
            VerticalOptions = LayoutOptions.CenterAndExpand;
            HorizontalOptions = LayoutOptions.CenterAndExpand;

            SetImageBasedOnContext(Context);
        }

        protected void ContextChanged(object val)
        {
            SetImageBasedOnContext(Context);
        }
        
        protected void IsSelectedChanged(bool val)
        {
            SetImageBasedOnContext(Context);
        }
        
        private void SetImageBasedOnContext(object val)
        {
            var result = string.Empty;

            if (val is CategoryVmi) result = IsSelected ? "category-icon-selected.svg" : "category-icon.svg";
            if (val is SubjectVmi) result = IsSelected ? "subject-icon-selected.svg" : "subject-icon.svg";
            if (val is OpinionVmi) result = IsSelected ? "opinion-icon-selected.svg" : "opinion-icon.svg";

            Source = result;
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(
                "IsSelected",
                typeof(bool),
                typeof(ColoredIcon),
                default(bool),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (ColoredIcon) bindable;
                    thisControl.IsSelectedChanged((bool) newValue);
                });

        public bool IsSelected
        {
            get => (bool) GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }

     


        public static readonly BindableProperty ContextProperty =
            BindableProperty.Create(
                "Context",
                typeof(object),
                typeof(ColoredIcon),
                default(object),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (ColoredIcon) bindable;
                    thisControl.ContextChanged((object) newValue);
                });

        public object Context
        {
            get => (object) GetValue(ContextProperty);
            set => SetValue(ContextProperty, value);
        }

     

    }
}
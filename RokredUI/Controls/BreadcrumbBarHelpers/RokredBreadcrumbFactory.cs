using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using RokredUI.Controls.RokredListHelpers;
using RokredUI.Features.CategoryPage;
using RokredUI.Features.OpinionPage;
using RokredUI.Features.SubjectPage;
using Xamarin.Forms;

namespace RokredUI.Controls.BreadcrumbBarHelpers
{
    public static class RokredBreadcrumbFactory
    {
         public static View CreateBreadcrumbView(this IRokredListChildDataSource context, ICommand command = null)
        {
            //if there is no command, this is the outside most view
            var mainStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal, Spacing = 0, 
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Fill
            };
            
            var insideView = new RoundedView { CornerRadius = 5 };
            
            // this stack contains the bordered text of the item plus the chevron
            var insideStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0, VerticalOptions = LayoutOptions.Center
            };
            
            var label = new RokredLabel
            {
                FontSize = 16, IsBold = true, 
                Margin = new Thickness(15,5,15,5), 
                VerticalOptions = LayoutOptions.Center
            };
            var chevron = new SvgCachedImage
            {
                Source = "chevron-dark.svg", WidthRequest = 10, HeightRequest = 15,
                Margin = new Thickness(15,5,0,5)
            };
               
            if (context is CategoryVmi category)
            {
                insideView.BackgroundColor = Color.White;
                label.TextColor = Color.Black;
                label.Text = category.Name;
                label.Margin = new Thickness(5, 5, 10, 5);
                label.FontSize = 12;
                
                // category has an icon
                var categoryIcon = new SvgCachedImage
                {
                    WidthRequest = 15, HeightRequest = 20, Margin = new Thickness(10,5,5,5), 
                    Source = context.GetImageBasedOnContext(false)
                };
                
                insideStack.Children.Add(categoryIcon);
            }
            else if (context is SubjectVmi)
            {
                insideView.BackgroundColor = Color.FromHex("4A44F2");
                label.TextColor = Color.White;
                label.Text = "S";
            }
            else if (context is OpinionVmi && !(context as OpinionVmi).IsDirty)
            {
                insideView.BackgroundColor = Color.FromHex("F2BE22");
                label.TextColor = Color.Black;
                label.Text = "O";
            }
            else if (context is OpinionVmi && (context as OpinionVmi).IsDirty)
            {
                chevron.IsVisible = false;
                label.IsVisible = false;
                
                insideView.BackgroundColor = Color.Transparent;
                
                var star = new SvgCachedImage
                {
                    Source = "star-icon.svg", WidthRequest = 35, HeightRequest = 35,
                    Margin = new Thickness(0,0,0,0)
                };
                
                insideStack.Children.Add(star);
            }
            
            insideStack.Children.Add(label);

            mainStackLayout.HorizontalOptions = LayoutOptions.Start;
            mainStackLayout.VerticalOptions = LayoutOptions.Center;
            mainStackLayout.Margin = new Thickness(10);

            insideView.Content = insideStack;
            mainStackLayout.Children.Add(insideView);
            mainStackLayout.Children.Add(chevron);

            if (command != null)
            {
                var button = new RokredButton();
                button.Content = mainStackLayout;
                button.Command = command;
                button.CommandParameter = context;

                return button;
            }

            return mainStackLayout;
        }
    }
}
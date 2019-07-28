using System;
using ReactiveUI;
using Splat;
using Xamarin.Forms;

namespace RokredUI.Services
{
    public static class NavigationExtensions
    {
        public static Page GetView<T>(this T viewModel) where T : class, IViewModel
        {
            var view = Locator.Current.GetService<IViewFor<T>>();

            if (view == null)
            {
                throw new Exception($"The view: {view.GetType().Name} is not registered. Please register your view");
            }

            view.ViewModel = viewModel;

            if (!(view is Page page))
            {
                throw new TypeAccessException("IViewFor must be a Page type");
            }

            return page;
        }
    }
}
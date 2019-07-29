using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using Xamarin.Forms;

namespace RokredUI.Services
{
    public class NavigationService : INavigationService
    {
        private INavigation Navigator => Application.Current.MainPage.Navigation;

        public IObservable<Unit> Push<T>(object parameter) where T : class, IViewModel
        {
            var page = GetView<T>(parameter);

            return Navigator.PushAsync(page, true).ToObservable();
        }
        
        public IObservable<Unit> Push<T>() where T : class, IViewModel
        {
            var page = GetView<T>();
            return Navigator.PushAsync(page, true).ToObservable();
        }

        private Page GetView<T>(object parameter = null) where T : class, IViewModel
        {
            var constructor = typeof(T).GetTypeInfo().DeclaredConstructors.First();
            var args = new object[constructor.GetParameters().Length];

            var vm = (T) Activator.CreateInstance(typeof(T), args);

            if (parameter != null)
                vm.SetParameter(parameter);

            return vm.GetView();
        }
    }
}
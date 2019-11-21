using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RokredUI.Extensions
{
    public static class FocusExtensions
    {
        private const uint _slowSpeed = 350;
        private const uint _fastSpeed = 150;
        private const double _fadedOut = 0.1;
        private const double _fullVisible = 1;

        public static async Task FocusVisually(this StackLayout parent, View focus)
        {
            var tasks = new List<Task>
            {
                focus.FadeTo(_fullVisible, _fastSpeed)
            };

            foreach (var child in parent.Children)
                if (child != focus)
                {
                    tasks.Add(child.FadeTo(_fadedOut, _fastSpeed));
                    child.IsEnabled = false;
                }

            await Task.WhenAll(tasks);
        }

        public static async Task RevertFocus(this StackLayout parent)
        {
            // give the keyboard some time before we begin our fades.
            await Task.Delay((int)_slowSpeed);

            var tasks = new List<Task>();

            foreach (var child in parent.Children)
            {
                tasks.Add(child.FadeTo(_fullVisible, _slowSpeed));
                child.IsEnabled = true;
            }

            await Task.WhenAll(tasks);
        }
    }
}
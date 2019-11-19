using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RokredHeader
    {
        public RokredHeader()
        {
            InitializeComponent();
        }

        protected void UserNameChanged(string val)
        {
            LabelUserName.Text = val;
        }



        public static readonly BindableProperty UserNameProperty =
            BindableProperty.Create(
                "UserName",
                typeof(string),
                typeof(RokredHeader),
                default(string),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredHeader) bindable;
                    thisControl.UserNameChanged((string) newValue);
                });

        public string UserName
        {
            get => (string) GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }

     

    }
}
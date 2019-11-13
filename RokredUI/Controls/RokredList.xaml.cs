using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RokredUI.Controls.RokredListHelpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RokredList
    {
        public RokredList()
        {
            InitializeComponent();
        }

        protected void SourceChanged(List<IRokredListSourceItem> val)
        {

        }

        public static readonly BindableProperty SourceProperty =
            BindableProperty.Create(
                "Source",
                typeof(List<IRokredListSourceItem>),
                typeof(RokredList),
                default(List<IRokredListSourceItem>),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (RokredList) bindable;
                    thisControl.SourceChanged((List<IRokredListSourceItem>) newValue);
                });

        public List<IRokredListSourceItem> Source
        {
            get => (List<IRokredListSourceItem>) GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

     

    }
}
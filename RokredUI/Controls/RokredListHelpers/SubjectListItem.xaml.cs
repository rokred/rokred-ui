using RokredUI.Features.SubjectPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls.RokredListHelpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectListItem : IRokredListChildView
    {
        private SubjectVmi _subject;

        public IRokredListChildDataSource DataSource => _subject;
        
        public SubjectListItem()
        {
            InitializeComponent();
        }
        
        public SubjectListItem(SubjectVmi subject)
        {
            InitializeComponent();

            _subject = subject;
            
            IconView.Context = subject;
            LabelText.Text = subject.Name;
            LabelText.IsBold = subject.IsNew;
            
            SetSelectedState();
        }

        public void SetIsSelected(bool isSelected)
        {
            _subject.IsSelected = isSelected;
            SetSelectedState();
        }
        
        public void SetHasChevron(bool hasChevron)
        {
            ImageChevron.IsVisible = hasChevron;
        }
        
        protected void BoundDataSourceChanged(SubjectVmi subject)
        {
            _subject = subject;
            
            IconView.Context = subject;
            LabelText.Text = subject.Name;
            LabelText.IsBold = subject.IsNew;

            // bound ones are in xaml static. not clickable
            SetHasChevron(false);
            
            SetSelectedState();
        }
  
        private void SetSelectedState()
        {
            IconView.IsSelected = _subject.IsSelected;
            
            if (_subject.IsSelected)
            {
                BackgroundColor = Color.FromHex("4A44F2");
                LabelText.TextColor = Color.White;
                IconView.Opacity = 1f;
            }
            else
            {
                BackgroundColor = _subject.IsNew ? Color.FromHex("3E3E3E") : Color.FromHex("2A2A2A");
                IconView.Opacity = _subject.IsNew ? 1f : 0.1f;
                
                LabelText.TextColor = Color.White;
            }
        }

        public static readonly BindableProperty BoundDataSourceProperty =
            BindableProperty.Create(
                "BoundDataSource",
                typeof(SubjectVmi),
                typeof(SubjectListItem),
                default(SubjectVmi),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var thisControl = (SubjectListItem) bindable;
                    thisControl.BoundDataSourceChanged((SubjectVmi) newValue);
                });

        public SubjectVmi BoundDataSource
        {
            get => (SubjectVmi) GetValue(BoundDataSourceProperty);
            set => SetValue(BoundDataSourceProperty, value);
        }

     


      
    }
}
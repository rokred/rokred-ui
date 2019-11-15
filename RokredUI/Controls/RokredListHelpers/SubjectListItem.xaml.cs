using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RokredUI.POC.CategoryPage;
using RokredUI.POC.SubjectPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls.RokredListHelpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubjectListItem : IRokredListChildView
    {
        private readonly SubjectVmi _subject;

        public IRokredListChildDataSource DataSource => _subject;
        
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

        
        private void SetSelectedState()
        {
            IconView.IsSelected = _subject.IsSelected;
            
            if (_subject.IsSelected)
            {
                BackgroundColor = Color.FromHex("4A44F2");
                LabelText.TextColor = Color.White;
            }
            else
            {
                BackgroundColor = _subject.IsNew ? Color.FromHex("3E3E3E") : Color.FromHex("2A2A2A");
                IconView.Opacity = _subject.IsNew ? 1f : 0.4f;
                
                LabelText.TextColor = Color.White;
            }
            
        }


      
    }
}
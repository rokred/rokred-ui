using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RokredUI.POC.CategoryPage;
using RokredUI.POC.OpinionPage;
using RokredUI.POC.SubjectPage;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Controls.RokredListHelpers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OpinionListItem : IRokredListChildView
    {
        private readonly OpinionVmi _opinion;

        public IRokredListChildDataSource DataSource => _opinion;
        
        public OpinionListItem(OpinionVmi opinion)
        {
            InitializeComponent();

            _opinion = opinion;
            
            IconView.Context = opinion;
         
            
            if (string.IsNullOrWhiteSpace(opinion.Body))
                LabelBody.IsVisible = false;
            else 
                LabelBody.Text = opinion.Body;
            
            LabelTitle.Text = opinion.Title;
            LabelTitle.IsBold = opinion.IsNew;
            LabelBody.IsBold = opinion.IsNew;
            
            SetSelectedState();
        }

        public void SetIsSelected(bool isSelected)
        {
            _opinion.IsSelected = isSelected;
            SetSelectedState();
        }
 
        private void SetSelectedState()
        {
            IconView.IsSelected = _opinion.IsSelected;
            
            LabelTitle.TextColor = Color.Black;
            LabelBody.TextColor = Color.Black;
            
            if (_opinion.IsSelected)
            {
                BackgroundColor = Color.FromHex("F2BE22");
            }
            else
            {
                BackgroundColor = _opinion.IsNew ? Color.White : Color.FromHex("F5F5F5");
                IconView.Opacity = _opinion.IsNew ? 1f : 0.4f;
            } 
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using FFImageLoading.Svg.Forms;
using RokredUI.POC.CategoryPage;
using RokredUI.POC.OpinionPage;
using RokredUI.POC.SubjectPage;
using Xamarin.Forms;

namespace RokredUI.Controls.RokredListHelpers
{
    public static class RokredListFactory
    {
        public static IRokredListChildView CreateDynamicListItem(this IRokredListChildDataSource val, bool isSelected)
        {
            IRokredListChildView result;

            if (val is CategoryVmi) result = new CategoryListItem(val as CategoryVmi);
            else if (val is SubjectVmi) result = new SubjectListItem(val as SubjectVmi);
            else if (val is OpinionVmi) result = new OpinionListItem(val as OpinionVmi);
            else throw new NotImplementedException();
            
            result.SetHasChevron(false);
            return result;
        }
        
        public static string GetImageBasedOnContext(this IRokredListChildDataSource val, bool isSelected)
        {
            var result = string.Empty;

            if (val is CategoryVmi) result = isSelected ? "category-icon-selected.svg" : "category-icon.svg";
            if (val is SubjectVmi) result = isSelected ? "subject-icon-selected.svg" : "subject-icon.svg";
            if (val is OpinionVmi) result = isSelected ? "opinion-icon-selected.svg" : "opinion-icon.svg";

            return result;
        }
    }
}
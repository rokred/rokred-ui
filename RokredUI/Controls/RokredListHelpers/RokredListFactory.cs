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
namespace RokredUI.Controls.RokredListHelpers
{
    public interface IRokredListChildView
    {
        IRokredListChildDataSource DataSource { get; }
        
        void SetIsSelected(bool isSelected);

        void SetHasChevron(bool hasChevron);
    }
}
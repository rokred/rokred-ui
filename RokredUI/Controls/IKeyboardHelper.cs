using System.Threading.Tasks;

namespace RokredUI.Controls
{
    public interface IKeyboardHelper
    {
        void HideKeyboard();

        Task<double> GetKeyboardHeight();
    }
}
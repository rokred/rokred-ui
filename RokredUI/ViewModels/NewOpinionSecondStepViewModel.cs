using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace RokredUI.ViewModels
{
    public class NewOpinionSecondStepViewModel : BaseViewModel
    {
        [Reactive] public string OpinionText { get; set; }
    }
}
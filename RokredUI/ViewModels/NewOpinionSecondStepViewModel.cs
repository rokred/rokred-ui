using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using RokredUI.Backend;
using RokredUI.ViewModels.VMI;

namespace RokredUI.ViewModels
{
	public class NewOpinionSecondStepViewModel : BaseViewModel
	{
		[Reactive]
		public SubjectModel Subject { get; set; }
		[Reactive]
		public string Opinion { get; set; }

		public bool IsInOverlayMode { get; set; }

		public ReactiveCommand<Unit, Unit> RequestOverlayCommand { get; }

		public ReactiveCommand<Unit, Unit> SendCommand { get; }

		public NewOpinionSecondStepViewModel()
		{
			if (CentralStore.IsCreatingNewOpinion)
			{
				Subject = CentralStore.BrandNewOpinion.Subject;
				Opinion = CentralStore.BrandNewOpinion.Opinion;
			}

			RequestOverlayCommand = ReactiveCommand.Create(OpenOverlay, Observable.Return(!IsInOverlayMode));
			SendCommand = ReactiveCommand.Create(OnSend, Observable.Return(!string.IsNullOrWhiteSpace(Opinion)));
		}

		public void CloseOverlay()
		{
			IsInOverlayMode = false;
		}

		private void OpenOverlay()
		{
			IsInOverlayMode = true;
		}

		private void OnSend()
		{
			CentralStore.BrandNewOpinion.Opinion = Opinion;

            //todo: edgar
			// post it
			// middle-end.Post(CentralStore.BrandNewOpinion);
		}
	}
}
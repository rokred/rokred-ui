using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using ReactiveUI;
using ReactiveUI.XamForms;
using RokredUI.Controls;
using RokredUI.ViewModels;
using RokredUI.Views.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RokredUI.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewOpinionFirstStepView : ReactiveContentPage<NewOpinionFirstStepViewModel>
	{
		public NewOpinionFirstStepView()
		{
			InitializeComponent();

			BindingContext = new NewOpinionFirstStepViewModel();

			this.WhenActivated(disposables =>
			{
				this.Bind(ViewModel,
					vm => vm.SearchText,
					v => v.SubjectTextbox.Text).DisposeWith(disposables);

				this.BindCommand(ViewModel, vm => vm.RequestOverlayCommand, v => v.SubjectTextbox)
				   .DisposeWith(disposables);

				this.BindCommand(ViewModel, vm => vm.ApproachSandBoxCommand, v => v.ApproachSoapboxButton)
					.DisposeWith(disposables);

				FocusOnSearchText.DisposeWith(disposables);

				Observable.FromEventPattern<EventArgs>(
						x => SubjectTextbox.LostFocusEvent += x,
						x => SubjectTextbox.LostFocusEvent -= x)
					.Where(e => e.EventArgs != null)
					.ObserveOn(RxApp.MainThreadScheduler)
					.Subscribe(async ev =>
					{
						ViewModel.CloseOverlay();

						Scroll.ScrollToAsync(0, FirstControl.Y, true)
						  .ToObservable()
						   .ObserveOn(RxApp.MainThreadScheduler)
						   .Subscribe(async f =>
						   {
							   await OpinionContainer.RevertFocus();
						   });
					});
			});
		}

		private IDisposable FocusOnSearchText => this
			.WhenAnyValue(v => v.ViewModel.RequestOverlayCommand.IsExecuting)
			.Subscribe(isExecuting =>
			{
				isExecuting.Where(x => x)
					.ObserveOn(RxApp.MainThreadScheduler)
					.Subscribe(x =>
					{
						Scroll.ScrollToAsync(0, SubjectTextbox.Y, true)
						   .ToObservable()
							.ObserveOn(RxApp.MainThreadScheduler)
							.Subscribe(async f =>
							{
								SubjectTextbox.Focus();
								await OpinionContainer.FocusVisually(SubjectTextbox);
							});
					});
			});
	}
}
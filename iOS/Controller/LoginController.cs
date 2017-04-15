using System;
using ReactiveUI;
using UIKit;

namespace LoginTraining.iOS
{
	public partial class LoginController : ReactiveViewController, IViewFor<NewViewModel>
	{
		public LoginController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			ViewModel = new NewViewModel();

			UserListPicker.Model = new RolesPicker(RoleButtonName, ViewModel);
			UserListPicker.Hidden = true;
			UserListPicker.Select(1, 0, true);
			UserListPicker.Layer.CornerRadius = 20;

			RoleButtonName.TouchUpInside += ((sender, e) =>
			{
				UserListPicker.Hidden = false;
			});

			this.Bind(ViewModel, vm => vm.PasscodeLabel, v => v.PasscodeLabel.Text);
			this.Bind(ViewModel, vm => vm.RoleButtonName, v => v.RoleButtonName.TitleLabel.Text);
			BindButton();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		private NewViewModel _ViewModel;

		public NewViewModel ViewModel
		{
			get { return _ViewModel; }
			set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
		}

		object IViewFor.ViewModel
		{
			get { return _ViewModel; }
			set { ViewModel = (NewViewModel)value; }
		}

		private void BindButton()
		{
			ViewModel.LoginButton.Subscribe(success =>
			{
				if (success)
				{
					DashboardController dashboardController =
						this.Storyboard.InstantiateViewController("DashboardController") as DashboardController;
					if (dashboardController != null)
					{
						dashboardController.roleName = ViewModel.RoleButtonName;
						this.NavigationController.PushViewController(dashboardController, true);
					}
				}
				else
				{
					var alert = new UIAlertView()
					{
						Title = "Error",
						Message = "Please try another password!"
					};
					alert.AddButton("OK");
					alert.Show();
				}
			});
		}
	}
}


using System;
using ReactiveUI;
using UIKit;
using System.Reactive.Linq;

namespace LoginTraining.iOS
{
	public partial class ViewController : ReactiveViewController, IViewFor<LoginViewModel>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:LoginTraining.iOS.ViewController"/> class.
		/// </summary>
		/// <param name="handle">Handle.</param>
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad()
		{
			// Set border and color for LabelCode
			base.ViewDidLoad();
			ViewModel = new LoginViewModel();

			LoginTitleLabel.BackgroundColor = UIColor.FromRGB(250, 250, 250);

			// Picker binder and display
			RolePickerView.BackgroundColor = UIColor.FromRGB(255, 255, 255);
			RolePickerView.Layer.CornerRadius = 10;
			RolePickerView.Model = new RolesPicker(RoleButton, ViewModel);

			RolePickerView.Hidden = true;
			ViewModel.SelectedRoleIndex = 1;
			RolePickerView.Select(ViewModel.SelectedRoleIndex, 0, true);

			// Set border color for control
			SetBorderControl();

			// Open pickerview when click role button
			RoleButton.TouchUpInside += ((sender, e) =>
			{
				RolePickerView.Hidden = false;
			});
			RoleButton.TouchUpOutside += ((sender, e) =>
			{
				RolePickerView.Hidden = true;
			});

			// Bind top control
			this.Bind(ViewModel, vm => vm.Passcode, v => v.CodeLabel.Text);
			this.Bind(ViewModel, vm => vm.RoleName, v => v.RoleButton.TitleLabel.Text);

			// Bind keypad
			BindCommandControl();

			// Bind all the button to ViewModel
			LoginClickButton();
		}

		///// <summary>
		///// Is called when the view is about to appear on the screen. We use this method to hide the
		///// navigation bar.
		///// </summary>
		//public override void ViewWillAppear(bool animated)
		//{
		//	base.ViewWillAppear(animated);
		//	this.NavigationController.SetNavigationBarHidden(true, animated);
		//}

		///// <summary>
		///// Is called when the another view will appear and this one will be hidden. We use this method
		///// to show the navigation bar again.
		///// </summary>
		//public override void ViewWillDisappear(bool animated)
		//{
		//	base.ViewWillDisappear(animated);
		//	this.NavigationController.SetNavigationBarHidden(false, animated);
		//}

		/// <summary>
		/// The view model.
		/// </summary>
		private LoginViewModel _ViewModel;

		/// <summary>
		/// Gets or sets the view model.
		/// </summary>
		/// <value>The view model.</value>
		public LoginViewModel ViewModel
		{
			get { return _ViewModel; }
			set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
		}

		/// <summary>
		/// Gets or sets the reactive user interface . IV iew for. view model.
		/// </summary>
		/// <value>The reactive user interface . IV iew for. view model.</value>
		object IViewFor.ViewModel
		{
			get { return _ViewModel; }
			set { ViewModel = (LoginViewModel)value; }
		}

		/// <summary>
		/// Dids the receive memory warning.
		/// </summary>
		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		/// <summary>
		/// Binds the button.
		/// </summary>
		private void LoginClickButton()
		{
			ViewModel.LoginCommand.Subscribe(success =>
			{
				if (success)
				{
					WelcomeController welcomeController =
						this.Storyboard.InstantiateViewController("WelcomeController") as WelcomeController;
					if (welcomeController != null)
					{
						welcomeController.roleName = ViewModel.RoleName;
						welcomeController.passcode = ViewModel.Passcode;
						this.NavigationController.PushViewController(welcomeController, true);
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

		/// <summary>
		/// Sets the color of the border.
		/// </summary>
		/// <param name="view">View.</param>
		private void SetBorderColor(UIView view)
		{
			view.Layer.BorderWidth = 1.0f;
			view.Layer.BorderColor = UIColor.FromRGB(250, 250, 250).CGColor;
		}

		/// <summary>
		/// Sets the border control.
		/// </summary>
		/// <param name="view">View.</param>
		private void SetBorderControl()
		{
			SetBorderColor(RoleButton);
			SetBorderColor(CodeLabel);
			SetBorderColor(RolePickerView);
			SetBorderColor(ZeroButton);
			SetBorderColor(LoginButton);
			SetBorderColor(ClearButton);
            SetBorderColor(TwoButton);
            SetBorderColor(ThreeButton);
            SetBorderColor(FourButton);
            SetBorderColor(FiveButton);
            SetBorderColor(SixButton);
            SetBorderColor(SevenButton);
            SetBorderColor(EightButton);
            SetBorderColor(NineButton);
		}

		private void BindCommandControl()
		{
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.OneButton, Observable.Return(OneButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.TwoButton, Observable.Return(TwoButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.ThreeButton, Observable.Return(ThreeButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.FourButton, Observable.Return(FourButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.FiveButton, Observable.Return(FiveButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.SixButton, Observable.Return(SixButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.SevenButton, Observable.Return(SevenButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.EightButton, Observable.Return(EightButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.NineButton, Observable.Return(NineButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.AddKeyPadCommand, v => v.ZeroButton, Observable.Return(ZeroButton.TitleLabel.Text));
			this.BindCommand(this.ViewModel, vm => vm.LoginCommand, v => v.LoginButton);
			this.BindCommand(this.ViewModel, vm => vm.ClearCommand, v => v.ClearButton);
		}
	}
}


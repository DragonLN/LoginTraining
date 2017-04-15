using System;
using ReactiveUI;
using UIKit;

namespace LoginTraining.iOS
{
	public partial class WelcomeController : ReactiveViewController
	{
		public string roleName;
		public string passcode;

		public WelcomeController(IntPtr handle) : base(handle)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			WelcomeRoleName.Text += roleName;
			WelcomePasscode.Text += passcode;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


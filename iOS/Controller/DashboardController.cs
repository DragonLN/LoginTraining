using System;

using UIKit;

namespace LoginTraining.iOS
{
	public partial class DashboardController : UIViewController
	{
		public string roleName;

		public DashboardController() : base("DashboardController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			dashboardLabel.Text = this.roleName;
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


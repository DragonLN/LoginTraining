// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace LoginTraining.iOS
{
    [Register ("WelcomeController")]
    partial class WelcomeController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WelcomePasscode { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel WelcomeRoleName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (WelcomePasscode != null) {
                WelcomePasscode.Dispose ();
                WelcomePasscode = null;
            }

            if (WelcomeRoleName != null) {
                WelcomeRoleName.Dispose ();
                WelcomeRoleName = null;
            }
        }
    }
}
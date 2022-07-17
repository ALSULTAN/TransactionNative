// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace TransactionNative.iOS.Controllers
{
    [Register ("TransactionDetailViewController")]
    partial class TransactionDetailViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField NameText { get; set; }


        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField BankText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (NameText != null) {
                NameText.Dispose ();
                NameText = null;
            }

            if (BankText != null) {
                BankText.Dispose ();
                BankText = null;
            }
        }
    }
}
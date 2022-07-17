using Foundation;
using System;
using UIKit;

namespace TransactionNative.Android.Helpers
{
    /// <summary>
    /// Dialog Methods
    /// </summary>
    internal static class DialogHelper
    {
        /// <summary>
        /// Show Alert Dialog
        /// </summary>
        /// <param name="ViewController">Current ViewController</param>
        /// <param name="Title">Dialogs Title Text</param>
        /// <param name="Message">Dialogs Message Text</param>
        /// <param name="ButtonAction">Event To Be Invoked Uppon OK Click</param>
        internal static void Show(UIViewController ViewController, string Title, string Message, Action ButtonAction = null)
        {
            var ButtonText = NSBundle.MainBundle.GetLocalizedString("OK", "");
            var AlertController = UIAlertController.Create(Title, Message, UIAlertControllerStyle.Alert);
            AlertController.AddAction(UIAlertAction.Create(ButtonText, UIAlertActionStyle.Default, (__) => ButtonAction?.Invoke()));
            ViewController.PresentViewController(AlertController, true, null);
        }
    }
}
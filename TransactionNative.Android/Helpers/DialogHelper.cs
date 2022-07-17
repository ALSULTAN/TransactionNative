using AndroidX.AppCompat.App;
using System;

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
        /// <param name="Activity">Main Application Activity</param>
        /// <param name="Title">Dialogs Title Text</param>
        /// <param name="Message">Dialogs Message Text</param>
        /// <param name="ButtonAction">Event To Be Invoked Uppon OK Click</param>
        internal static void Show(AppCompatActivity Activity, string Title, string Message, Action ButtonAction = null)
        {
            new AlertDialog.Builder(Activity)
                .SetTitle(Title)
                .SetMessage(Message)
                .SetPositiveButton(Resource.String.OK, (_, __) => ButtonAction?.Invoke())
                .Show();
        }
    }
}
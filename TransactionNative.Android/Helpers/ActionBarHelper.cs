using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;

namespace TransactionNative.Android.Helpers
{
    internal static class ActionBarHelper
    {
        /// <summary>
        /// Set Action Bar Title And Back Button
        /// </summary>
        /// <param name="Activity">App Activity</param>
        /// <param name="Title">App Title To Be Displayed</param>
        /// <param name="Home">Is The Current View Home</param>
        internal static void Set(AppCompatActivity Activity, int Title, bool Home)
        {
            var Toolbar = Activity.FindViewById<Toolbar>(Resource.Id.TransactionsToolBar);
            Activity.SetSupportActionBar(Toolbar);
            Activity.SetTitle(Title);

            Activity.SupportActionBar.SetDisplayHomeAsUpEnabled(!Home);

            // Just Showing Back Action
            Toolbar.NavigationClick += (_, E) => Activity.OnBackPressed();
        }
    }
}
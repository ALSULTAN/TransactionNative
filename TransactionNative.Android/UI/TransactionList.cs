using AndroidX.RecyclerView.Widget;
using AndroidX.SwipeRefreshLayout.Widget;
using System;
using TransactionNative.Android.Activities;
using TransactionNative.Android.Adapters;
using TransactionNative.Android.Helpers;

namespace TransactionNative.Android.UI
{
    /// <summary>
    /// Transaction List UI
    /// </summary>
    internal class TransactionList
    {
        readonly TransactionsActivity Activity;
        RecyclerView TransactionsRecyclerView;
        SwipeRefreshLayout Refresher;
        TransactionList(TransactionsActivity Activity) => this.Activity = Activity;

        /// <summary>
        /// Show Transaction List User Interface
        /// </summary>
        /// <param name="Activity">Main Application Activity</param>
        internal static void Show(TransactionsActivity Activity)
        {
            var TransactionList = new TransactionList(Activity);
            Activity.SetContentView(Resource.Layout.TransactionMain);
            TransactionList.InitViews(Activity);
            TransactionList.LoadTransactions(Activity, false);
        }

        void InitViews(TransactionsActivity Activity)
        {
            TransactionsRecyclerView = Activity.FindViewById<RecyclerView>(Resource.Id.TransactionsList);

            Refresher = Activity.FindViewById<SwipeRefreshLayout>(Resource.Id.TransactionsRefresher);
            Refresher.Refreshing = true;
            Refresher.Refresh += (S, E) => { LoadTransactions(Activity, true); };

            ActionBarHelper.Set(Activity, Resource.String.TransactionsList, true);
        }

        async void LoadTransactions(TransactionsActivity Activity, bool ForceRefresh)
        {
            try
            {
                var Transactions = await TransactionHelper.GetTransactionsAsync(ForceRefresh);
                TransactionsRecyclerView = Activity.FindViewById<RecyclerView>(Resource.Id.TransactionsList);
                TransactionAdapter.SetAdapter(TransactionsRecyclerView, Transactions, TransactionTapped);
            }
            catch (Exception Error)
            {
                DialogHelper.Show(Activity, "Load Transactions Failed!", Error.ToString());
            }
            finally
            {
                Refresher.Refreshing = false;
            }
        }

        void TransactionTapped(string TransactionID) => TransactionDetail.Show(Activity, TransactionID, Refresher);
    }
}
using Android.Widget;
using System;
using System.Threading.Tasks;
using TransactionNative.Android.Activities;
using TransactionNative.Android.Helpers;
using TransactionNative.Models;

namespace TransactionNative.Android.UI
{
    /// <summary>
    /// Transaction Detail UI
    /// </summary>
    internal class TransactionDetail
    {

        /// <summary>
        /// Show Transaction Details User Interface
        /// </summary>
        /// <param name="Activity">Main Application Activity</param>
        /// <param name="Transaction">Transaction To View</param>
        internal static async void Show(TransactionsActivity Activity, string TransactionID)
        {
            Activity.SetContentView(Resource.Layout.TransactionDetail);
            ActionBarHelper.Set(Activity, Resource.String.TransactionDetails, false);
            var Transaction = await LoadTransaction(Activity, TransactionID);
            ViewTransaction(Activity, Transaction);
        }

        static async Task<Transaction> LoadTransaction(TransactionsActivity Activity, string TransactionID)
        {
            try
            {
                if (TransactionID != null)
                {
                    return await TransactionHelper.GetTransactionAsync(TransactionID);
                }
                else
                {
                    DialogHelper.Show(Activity, "Transaction Load Failed", "Invalid Transaction ID {NULL}");
                }
            }
            catch (Exception Error)
            {
                DialogHelper.Show(Activity, "Transaction Load Failed", Error.ToString());
            }
            return null;
        }

        static void ViewTransaction(TransactionsActivity Activity, Transaction Transaction)
        {
            try
            {
                if (Transaction == null) return;
                Activity.FindViewById<TextView>(Resource.Id.Name).Text = Transaction.Name;
                Activity.FindViewById<TextView>(Resource.Id.BankName).Text = Transaction.BankName;
            }
            catch (Exception Error)
            {
                // Must Never Occurs
                DialogHelper.Show(Activity, "Transaction View Failed", Error.ToString());
            }
        }
    }
}
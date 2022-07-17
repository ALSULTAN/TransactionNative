using Foundation;
using System;
using System.Collections.Generic;
using TransactionNative.Android.Helpers;
using TransactionNative.iOS.Adapters;
using TransactionNative.Models;
using UIKit;

namespace TransactionNative.iOS.Controllers
{
    public partial class TransactionsViewController : UITableViewController
    {
        public static readonly string TransactionSegueIdentifier = "TransactionSegue";
        public static readonly string TransactionCellIdentifier = "TransactionCell";

        public IEnumerable<Transaction> Transactions = new Transaction[0];

        public TransactionsViewController(IntPtr Handle) : base(Handle) => LoadTransactions();

        public async void LoadTransactions()
        {
            try
            {
                Transactions = await TransactionHelper.GetTransactionsAsync(true);
            }
            catch (Exception Error)
            {
                DialogHelper.Show(this, "Load Transactions Failed!", Error.ToString());
            }
        }

        public override async void PrepareForSegue(UIStoryboardSegue Segue, NSObject Sender)
        {
            if (Segue?.Identifier == TransactionSegueIdentifier && Segue.DestinationViewController is TransactionDetailViewController Controller)
            {
                var Source = TableView.Source as TransactionTableSource;
                var RowPath = TableView.IndexPathForSelectedRow;
                var Transaction = Source.GetTransaction(RowPath.Row);
                await Controller.LoadTransactionAsync(Transaction.ID);
            }
        }

        public override void ViewWillAppear(bool Animated)
        {
            base.ViewWillAppear(Animated);
            TransactionTableSource.SetTableSource(TableView, Transactions, TransactionCellIdentifier);
        }
    }
}
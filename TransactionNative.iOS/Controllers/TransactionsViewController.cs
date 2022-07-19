using Foundation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public TransactionsViewController(IntPtr Handle) : base(Handle) { }

        public async Task LoadTransactions()
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

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await LoadTransactions();
            TransactionTableSource.SetTableSource(TableView, Transactions, TransactionCellIdentifier);
            TableView.ReloadData();
        }
    }
}
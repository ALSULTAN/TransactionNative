using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using TransactionNative.Models;
using UIKit;

namespace TransactionNative.iOS.Adapters
{
    public class TransactionTableSource : UITableViewSource
    {
        /// <summary>
        /// Convenient Way To Set Table Source For Table View
        /// </summary>
        /// <param name="TableView">Transaction Table View</param>
        /// <param name="Transactions">List/Array Of Transactions</param>
        /// <param name="CellIdentifier">Storyboard Reuse Identifier</param>
        public static void SetTableSource(UITableView TableView, IEnumerable<Transaction> Transactions, string CellIdentifier)
        {
            TableView.Source = new TransactionTableSource(Transactions, CellIdentifier);
        }

        /// <summary>
        /// Get Transaction At Specific Position
        /// </summary>
        /// <param name="Position">Transaction Position</param>
        /// <returns></returns>
        public Transaction GetTransaction(int Position) => Transactions.ElementAtOrDefault(Position);

        public IEnumerable<Transaction> Transactions { get; }
        public string CellIdentifier { get; }

        public TransactionTableSource(IEnumerable<Transaction> Transactions, string CellIdentifier)
        {
            this.Transactions = Transactions;
            this.CellIdentifier = CellIdentifier;
        }

        public override nint RowsInSection(UITableView TableView, nint Section) => Transactions.Count();

        public override UITableViewCell GetCell(UITableView TableView, NSIndexPath IndexPath)
        {
            return TransactionTableCell.GetTableCell(TableView, GetTransaction(IndexPath.Row), CellIdentifier);
        }
    }
}

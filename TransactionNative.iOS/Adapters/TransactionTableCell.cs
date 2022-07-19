using TransactionNative.Models;
using UIKit;

namespace TransactionNative.iOS.Adapters
{
    internal class TransactionTableCell
    {
        /// <summary>
        /// Convenient Way To Get Cell Table
        /// </summary>
        /// <param name="TableView">Transaction Table View</param>
        /// <param name="Transaction">Current Transaction</param>
        /// <param name="CellIdentifier">Storyboard Reuse Identifier</param>
        public static UITableViewCell GetTableCell(UITableView TableView, Transaction Transaction, string CellIdentifier)
        {
            var TransactionCell = TableView.DequeueReusableCell(CellIdentifier);
            TransactionCell.TextLabel.Text = Transaction?.Name;
            return TransactionCell;
        }
    }
}
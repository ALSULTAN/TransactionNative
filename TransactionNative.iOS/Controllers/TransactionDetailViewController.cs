using System;
using System.Threading.Tasks;
using TransactionNative.Android.Helpers;
using TransactionNative.Models;
using UIKit;

namespace TransactionNative.iOS.Controllers
{
    public partial class TransactionDetailViewController : UITableViewController
    {
        public Transaction Transaction { get; set; }

        public TransactionDetailViewController(IntPtr Handle) : base(Handle) { }

        public override void ViewWillAppear(bool Animated)
        {
            base.ViewWillAppear(Animated);
            Title = "Transaction Details";
            NameText.Text = Transaction?.Name;
            BankText.Text = Transaction?.BankName;
        }

        /// <summary>
        /// Load Transaction Before Its View Is Displayed
        /// </summary>
        /// <param name="Delegate"></param>
        /// <param name="TransactionID"></param>
        public async Task LoadTransactionAsync(string TransactionID)
        {
            try
            {
                if (TransactionID != null)
                {
                    Transaction = await TransactionHelper.GetTransactionAsync(TransactionID);
                }
                else
                {
                    DialogHelper.Show(this, "Transaction Load Failed", "Invalid Transaction ID {NULL}");
                }
            }
            catch (Exception Error)
            {
                DialogHelper.Show(this, "Transaction Load Failed", Error.ToString());
            }
        }
    }
}
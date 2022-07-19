using Foundation;
using System;
using System.Threading.Tasks;
using TransactionNative.Android.Helpers;
using TransactionNative.Models;
using UIKit;

namespace TransactionNative.iOS.Controllers
{
    public partial class TransactionDetailViewController : UITableViewController
    {
        public string TransactionID { get; set; }

        public TransactionDetailViewController(IntPtr Handle) : base(Handle) { }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            Title = NSBundle.MainBundle.GetLocalizedString("TransactionDetails", "");
            var Transaction = await LoadTransactionAsync(TransactionID);
            NameText.Text = Transaction?.Name;
            BankText.Text = Transaction?.BankName;
        }

        /// <summary>
        /// Load Transaction Before Its View Is Displayed
        /// </summary>
        /// <param name="Delegate"></param>
        /// <param name="TransactionID"></param>
        public async Task<Transaction> LoadTransactionAsync(string TransactionID)
        {
            try
            {
                if (TransactionID != null)
                {
                    return await TransactionHelper.GetTransactionAsync(TransactionID);
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
            return null;
        }
    }
}
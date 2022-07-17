using Android.Views;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using TransactionNative.Models;

namespace TransactionNative.Android.Adapters
{
    internal class TransactionAdapter : RecyclerView.Adapter
    {
        /// <summary>
        /// Convenient Way To Set The Adapter For Transactions ListView
        /// </summary>
        /// <param name="RecyclerView">Transaction List View</param>
        /// <param name="Transactions">List/Array Of Transactions</param>
        /// <param name="TransactionTapped">Action To Be Invoked Upon Transaction Item Click/Tap</param>
        internal static void SetAdapter(RecyclerView RecyclerView, IEnumerable<Transaction> Transactions, Action<string> TransactionTapped)
        {
            RecyclerView.SetLayoutManager(new LinearLayoutManager(RecyclerView.Context));
            RecyclerView.SetAdapter(new TransactionAdapter(Transactions, TransactionTapped));
        }

        TransactionAdapter(IEnumerable<Transaction> Transactions, Action<string> TappedAction)
        {
            this.Transactions = Transactions;
            this.TappedAction = TappedAction;
        }

        internal IEnumerable<Transaction> Transactions { get; set; }
        internal Action<string> TappedAction { get; set; }
        public override int ItemCount => Transactions.Count();

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup Parent, int ViewType)
        {
            var TransactionView = LayoutInflater.From(Parent.Context).Inflate(Resource.Layout.TransactionRow, Parent, false);
            return TransactionViewHolder.CreateHolder(TransactionView, Transactions, TappedAction);
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder Holder, int Position)
        {
            var TransactionHolder = Holder as TransactionViewHolder;
            TransactionHolder.NameView.Text = Transactions.ElementAtOrDefault(Position)?.Name;
            TransactionHolder.BankNameView.Text = Transactions.ElementAtOrDefault(Position)?.BankName;
        }
    }
}
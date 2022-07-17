using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using TransactionNative.Models;

namespace TransactionNative.Android.Adapters
{
    internal class TransactionViewHolder : RecyclerView.ViewHolder
    {
        /// <summary>
        /// Convenient Way To Create Transaction View Holder
        /// </summary>
        /// <param name="TransactionView">Transaction Row Layout</param>
        /// <param name="Transactions">List/Array Of Transactions</param>
        /// <param name="TransactionTapped">Action To Be Invoked Upon Transaction Item Click/Tap</param>
        /// <returns></returns>
        internal static TransactionViewHolder CreateHolder(View TransactionView, IEnumerable<Transaction> Transactions, Action<string> TransactionTapped)
        {
            return new TransactionViewHolder(TransactionView, Transactions, TransactionTapped);
        }

        /// <summary>
        /// TextView Holding Transaction Name
        /// </summary>
        internal TextView NameView { get; set; }

        /// <summary>
        /// TextView Holding Transaction Bank Name
        /// </summary>
        internal TextView BankNameView { get; set; }

        TransactionViewHolder(View TransactionView, IEnumerable<Transaction> Transactions, Action<string> TransactionTapped) : base(TransactionView)
        {
            NameView = TransactionView.FindViewById<TextView>(Resource.Id.Name);
            BankNameView = TransactionView.FindViewById<TextView>(Resource.Id.BankName);
            TransactionView.Click += (_, __) =>
            {
                TransactionTapped?.Invoke(Transactions.ElementAtOrDefault(AdapterPosition)?.ID);
            };
        }
    }
}
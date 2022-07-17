using System.Collections.Generic;
using System.Threading.Tasks;
using TransactionNative.Models;

namespace TransactionNative
{
    public static class TransactionHelper
    {
        static List<Transaction> Transactions;

        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns>List Of Transactions</returns>
        public static async Task<List<Transaction>> GetTransactionsAsync(bool ForceRefresh)
        {
            return Transactions == null || ForceRefresh ?
                Transactions = await Services.TransactionAPI.GetTransactionsAsync() :
                Transactions;
        }

        /// <summary>
        /// Get Transaction Details Using Its ID
        /// </summary>
        /// <param name="ID">Transaction ID</param>
        /// <returns>Transaction</returns>
        public static async Task<Transaction> GetTransactionAsync(string ID)
        {
            return await Services.TransactionAPI.GetTransactionAsync(ID);
        }
    }
}

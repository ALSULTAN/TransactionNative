using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TransactionNative.Models;
using TransactionNative.Shared;

namespace TransactionNative.Services
{

    /// <summary>
    /// Transaction Rest APIs
    /// </summary>
    internal class TransactionAPI
    {
        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <returns>List Of Transaction</returns>
        internal static async Task<List<Transaction>> GetTransactionsAsync()
        {
            using var httpClient = new HttpClient();
            using HttpResponseMessage response = await httpClient.GetAsync(Constants.TransactionsService);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Json = await response.Content.ReadAsStringAsync();
                var Transactions = JsonConvert.DeserializeObject<List<Transaction>>(Json);
                return Transactions;
            }
            throw new System.Exception("Invalid Response Status");
        }

        /// <summary>
        /// Get Transaction Details Using Its ID
        /// </summary>
        /// <param name="ID">Transaction ID</param>
        /// <returns>Transaction</returns>
        internal static async Task<Transaction> GetTransactionAsync(string ID)
        {
            using var httpClient = new HttpClient();
            using HttpResponseMessage response = await httpClient.GetAsync(Constants.TransactionsService + ID);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var Json = await response.Content.ReadAsStringAsync();
                var Transaction = JsonConvert.DeserializeObject<Transaction>(Json);
                return Transaction;
            }
            throw new System.Exception("Invalid Response Status");
        }
    }
}

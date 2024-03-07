using Nethereum.Web3;

namespace Eth02.Utils
{
    public static class TransactionDisplay
    {
        private static bool headerPrinted = false;

        public static async Task DisplayAllOne(Web3 web3)
        {
            try
            {
                var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
                var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);

                // Check if there are any pending transactions to display
                if (filterChanges != null && filterChanges.Any())
                {
                    if (!headerPrinted)
                    {
                        //PrintHeader();
                        headerPrinted = true;
                    }

                    foreach (var txHash in filterChanges)
                    {
                        try
                        {
                            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txHash);

                            // Display transaction details in a table format only if it's pending
                            if (GetTransactionStatus(receipt) != null)
                            {
                                var tx = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(txHash);
                                Console.WriteLine($"| {Format(tx?.TransactionHash, 66)} " +
                                                  $"| {Format(tx?.From, 16)} " +
                                                  $"| {Format(tx?.To, 16)} " +
                                                  $"| {Format(Web3.Convert.FromWei(tx?.Value), 13)} " +
                                                  $"| {Format(Web3.Convert.FromWei(tx?.GasPrice), 11)} " +
                                                  $"| {Format(tx?.Gas, 8)} " +
                                                  $"| {Format(tx?.Nonce, 6)} " +
                                                  $"| {Format(tx?.Type, 6)} " +
                                                  $"| {Format(GetTransactionStatus(receipt), 7)} |");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error while processing transaction: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving pending transactions: {ex.Message}");
            }
        }

        public static async Task DisplayAllEthPending(Web3 web3, bool displayCountdownTimer)
        {
            try
            {
                var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
                var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);

                // Check if there are any pending transactions to display
                if (filterChanges != null && filterChanges.Any())
                {
                    if (!headerPrinted)
                    {
                        //PrintHeaderPending();
                        headerPrinted = true;
                    }

                    if (displayCountdownTimer || !headerPrinted)
                    {
                        // Display countdown timer if requested
                        await DisplayCountdownTimer();
                        //PrintHeaderPending();
                        headerPrinted = false;
                    }

                    foreach (var txHash in filterChanges)
                    {
                        try
                        {
                            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txHash);

                            // Display transaction details in a table format only if it's pending
                            if (receipt != null && GetTransactionStatus(receipt) != null)
                            {
                                var tx = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(txHash);
                                Console.WriteLine($"| {Format(tx?.TransactionHash, 66)} " +
                                                  $"| {Format(tx?.TransactionIndex, 16)} " +
                                                  $"| {Format(tx?.BlockHash, 16)} " +
                                                  $"| {Format(tx?.BlockNumber, 16)} " +
                                                  $"| {Format(tx?.From, 16)} " +
                                                  $"| {Format(tx?.To, 16)} " +
                                                  $"| {Format(Web3.Convert.FromWei(tx?.Value), 13)} " +
                                                  $"| {Format(Web3.Convert.FromWei(tx?.GasPrice), 11)} " +
                                                  $"| {Format(tx?.Gas, 8)} " +
                                                  $"| {Format(tx?.Nonce, 6)} " +
                                                  //$"| {Format(tx?.Value, 6)} " +
                                                  $"| {Format(tx?.Type, 6)} " +
                                                  $"| {Format(GetTransactionStatus(receipt), 7)} |" +
                                                  $"| {DateTime.UtcNow.ToString("dd HH:mm:ss.fff")}" +
                                                  $",-{DateTime.UtcNow.Millisecond.ToString()}mm -");
                            }
                        }
                        catch (Exception ex)
                        {
                            //Console.WriteLine($"Error while processing transaction: {ex.Message}");
                            // No Error Out
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error while retrieving pending transactions: {ex.Message}");
            }
        }

        public static async Task DisplayAllEthTransactions(Web3 web3)
        {
            try
            {
                var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
                var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);

                // Check if there are any transactions to display
                if (filterChanges != null && filterChanges.Any())
                {
                    if (!headerPrinted)
                    {
                        PrintHeader();
                        headerPrinted = true;
                    }

                    foreach (var txHash in filterChanges)
                    {
                        try
                        {
                            var tx = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(txHash);
                            var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txHash);

                            // Display transaction details in a table format
                            Console.WriteLine($"| {Format(tx?.TransactionHash, 66)} " +
                                              $"| {Format(tx?.TransactionIndex, 16)} " +
                                              $"| {Format(tx?.BlockHash, 16)} " +
                                              $"| {Format(tx?.BlockNumber, 16)} " +
                                              $"| {Format(tx?.From, 16)} " +
                                              $"| {Format(tx?.To, 16)} " +
                                              $"| {Format(Web3.Convert.FromWei(tx?.Value), 13)} " +
                                              $"| {Format(Web3.Convert.FromWei(tx?.GasPrice), 11)} " +
                                              $"| {Format(tx?.Gas, 8)} " +
                                              $"| {Format(tx?.Nonce, 6)} " +
                                              //$"| {Format(tx?.Value, 6)} " +
                                              $"| {Format(tx?.Type, 6)} " +
                                              $"| {Format(GetTransactionStatus(receipt), 7)} |" +
                                              $"| {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} ");
                            //Console.WriteLine($"| {Format(tx?.TransactionHash, 66)} " +
                            //                  $"| {Format(tx?.From, 16)} " +
                            //                  $"| {Format(tx?.To, 16)} " +
                            //                  $"| {Format(Web3.Convert.FromWei(tx?.Value), 13)} " +
                            //                  $"| {Format(Web3.Convert.FromWei(tx?.GasPrice), 11)} " +
                            //                  $"| {Format(tx?.Gas, 8)} " +
                            //                  $"| {Format(tx?.Nonce, 6)} " +
                            //                  $"| {Format(tx?.Type, 6)} " +
                            //                  $"| {Format(GetTransactionStatus(receipt), 7)} |" +
                            //                  //$"| {DateTime.N} ");
                            //                  //$"| {DateTime.Now.ToString("HH:mm:ss.fffff")} ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error while processing transaction: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while retrieving pending transactions: {ex.Message}");
            }
        }

        public static void PrintHeader()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                     Transaction Hash                          |       From     |       To      |   Value (ETH)   |  Gas Price  |    Gas   |    Nonce   | Status |                                                      |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public static void PrintHeaderPending()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                         Transaction Hash                         |Transaction Index|   Block Hash  |  Block Number   |  From   |   To   | Value(ETH)| Gas Price|  Gas  | Nonce | Type | Status  |    Time   |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        public static void PrintHeaderPendingTimer()
        {
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"|               Transaction Hash {DisplayCountdownTimer().ToString()}     |Transaction Index|   Block Hash  |  Block Number   |  From   |   To   | Value(ETH)| Gas Price|  Gas  | Nonce | Type | Status  |    Time       |");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }

        // Separate method for countdown timer
        public static async Task DisplayCountdownTimer()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write($"\t\t\t\t\tTIMER {i} s | TIMER:10s , Running: {DateTime.UtcNow.ToString("dd HH:mm:ss.fff")},-{DateTime.UtcNow.Millisecond.ToString("")}mm -");
                await Task.Delay(1000);
                Console.CursorLeft = 0;
            }
            Console.WriteLine();
        }

        //private static string Format(object value, int width)
        //{
        //    return value?.ToString().PadRight(width).Substring(0, Math.Min(value.ToString().Length, width)) ?? "".PadRight(width);
        //}
        private static string Format(object value, int width)
        {
            return (value?.ToString() ?? "").Trim().PadRight(width).Substring(0, Math.Min((value?.ToString() ?? "").Trim().Length, width));
        }


        private static string GetTransactionStatus(Nethereum.RPC.Eth.DTOs.TransactionReceipt receipt)
        {
            return receipt != null ? "Pending" : "null";
        }
    }
}

//public static async Task DisplayAllEthPending(Web3 web3)
//{
//    try
//    {
//        var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
//        var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);

//        // Check if there are any pending transactions to display
//        if (filterChanges != null && filterChanges.Any())
//        {
//            if (!headerPrinted)
//            {
//                PrintHeader();
//                headerPrinted = true;
//            }

//            foreach (var txHash in filterChanges)
//            {
//                try
//                {
//                    var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(txHash);

//                    // Display transaction details in a table format only if it's pending
//                    if (receipt != null && GetTransactionStatus(receipt) != null)
//                    {
//                        var tx = await web3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(txHash);
//                        Console.WriteLine($"| {Format(tx?.TransactionHash, 66)} " +
//                                          $"| {Format(tx?.From, 16)} " +
//                                          $"| {Format(tx?.To, 16)} " +
//                                          $"| {Format(Web3.Convert.FromWei(tx?.Value), 13)} " +
//                                          $"| {Format(Web3.Convert.FromWei(tx?.GasPrice), 11)} " +
//                                          $"| {Format(tx?.Gas, 8)} " +
//                                          $"| {Format(tx?.Nonce, 6)} " +
//                                          $"| {Format(tx?.Type, 6)} " +
//                                          $"| {Format(GetTransactionStatus(receipt), 7)} |");
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine($"Error while processing transaction: {ex.Message}");
//                }
//            }
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Error while retrieving pending transactions: {ex.Message}");
//    }
//}
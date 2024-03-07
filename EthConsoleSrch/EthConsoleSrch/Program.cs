using Nethereum.Web3;

namespace EthConsoleApp
{
    class Program
    {
        private static bool isRunning = true;

        static async Task Main(string[] args)
        {
            Console.CancelKeyPress += (sender, eventArgs) =>
            {
                Console.WriteLine("Stopping...");
                isRunning = false;
                eventArgs.Cancel = true;
            };

            Console.Write("Insert your Node URL: ");
            string nodeUrl = Console.ReadLine();
            string eth_node_URL_WSS = "wss://ethereum-rpc.publicnode.com";

            // Establish connection to the Ethereum node
            var web3 = new Web3(eth_node_URL_WSS);

            // Verify if the connection to the node is successful
            if (await IsConnected(web3))
            {
                Console.WriteLine("Connection Successful");

                // Display the latest block number
                var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                Console.WriteLine($"The latest block number is: {latestBlockNumber.Value}");

                PrintHeader();

                try
                {
                    while (isRunning)
                    {
                        await DisplayPendingTransactions(web3);
                        await Task.Delay(0); // Delay for 5 seconds before checking again
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Connection Failed");
            }
        }

        private static async Task DisplayPendingTransactions(Web3 web3)
        {
            try
            {
                var pendingFilter = await web3.Eth.Filters.NewPendingTransactionFilter.SendRequestAsync();
                var filterChanges = await web3.Eth.Filters.GetFilterChangesForBlockOrTransaction.SendRequestAsync(pendingFilter);

                // Check if there are any pending transactions to display
                if (filterChanges != null && filterChanges.Any())
                {
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

        private static string Format(object value, int width)
        {
            return (value?.ToString() ?? "").Trim().PadRight(width).Substring(0, Math.Min((value?.ToString() ?? "").Trim().Length, width));
        }

        private static string GetTransactionStatus(Nethereum.RPC.Eth.DTOs.TransactionReceipt receipt)
        {
            return receipt != null ? "Pending" : "null";
        }

        private static async Task<bool> IsConnected(Web3 web3)
        {
            try
            {
                var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void PrintHeader()
        {
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                     Transaction Hash                          |       From     |       To      |   Value (ETH)   |  Gas Price  |    Gas   |    Nonce   | Status |                                                      |");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
        }
    }
}

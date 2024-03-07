using Eth02.Models;
using Eth02.Services;
using Eth02.Utils;
using Nethereum.Web3;

namespace Eth02
{
    public class Program
    {
        //[System.Runtime.InteropServices.DllImport("user32.dll")]
        //public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

        public static async Task Main(string[] args)
        {
            //Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            //Console.SetBufferSize(Console.LargestWindowWidth, Console.LargestWindowHeight);

            MessageDisplay.PrintWelcomeMessage();

            string nodeUrl = NodeMenu.ChoseURLnode();
            var ethereumService = new EthereumService();

            var node = new EthereumNode { NodeUrl = nodeUrl }; // Create an instance of EthereumNode
            if (await ethereumService.IsConnected(node))       // Pass the EthereumNode instance to IsConnected method
            {
                Console.WriteLine("\t\t\t\t\t**Connection Successful**");
                MessageDisplay.DisplayCurrentNodeURL(nodeUrl); // Display the currently chosen node URL

                var web3 = new Web3(nodeUrl);
                await BlockDisplay.DisplayLatestBlockNumber(web3);

                await NodeMenu.ProcessUserInput(web3);
            }
            else
            {
                Console.WriteLine("\t\t\t\t\t--Failed to connect to Ethereum node. Exiting program.--");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
// use TransactionReceipt/Transaction 
// 

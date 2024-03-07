using Eth02.Utils;
using Nethereum.Web3;

namespace Eth02.Services
{
    public static class NodeMenu
    {
        public static string ChoseURLnode()
        {
            //https://ethereum-rpc.publicnode.com/
            string eth_node_URL = "https://ethereum-rpc.publicnode.com";
            string eth_node_URL_WSS = "wss://ethereum-rpc.publicnode.com";
            string? nodeUrl = "";

            Console.WriteLine("\t\t\t\t\t###########");
            Console.Write("\t\t\t\t\tEnterNumber: ");
            string choice = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t###########");

            switch (choice)
            {
                case "1":
                    nodeUrl = eth_node_URL;
                    break;
                case "2":
                    nodeUrl = eth_node_URL_WSS;
                    break;
                case "3":
                    nodeUrl = UrlPrompt.GetUserCustomUrl();
                    break;
                case "cls":
                    Console.Clear();
                    break;
                case "7":
                    nodeUrl = string.Empty; // Exit from addresses
                    break;
                default:
                    Console.WriteLine("\t\t\t\t\tInvalid choice. Using default node URL WSS.");
                    nodeUrl = eth_node_URL_WSS;
                    break;
            }

            return nodeUrl;
        }

        public static async Task ProcessUserInput(Web3 web3)
        {
            string addressChoice;
            do
            {
                //TransactionDisplay.PrintHeader();
                addressChoice = MessageDisplay.ChooseAddress();

                string? address = null; // Initialize with a default value

                switch (addressChoice)
                {
                    case "1":
                        address = "0x00000000219ab540356cbb839cbe05303d7705fa";
                        break;
                    case "2":
                        address = "Second address";
                        break;
                    case "3":
                        address = "Third address";
                        break;
                    case "4":
                        Console.Write("Enter custom Ethereum address: ");
                        address = Console.ReadLine();
                        break;
                    case "5":
                        await TransactionDisplay.DisplayAllOne(web3);
                        break;
                    case "p":
                        await ExecutePendingTransactionsEveryHalfSecondWithInput(web3);
                        break;
                    case "cls":
                        Console.Clear();
                        break;
                    case "6":
                        await ExecuteALLTransactionsEveryHalfSecond(web3);
                        continue;
                    case "7":
                        addressChoice = string.Empty; // Exit from addresses
                        continue;
                    default:
                        Console.WriteLine("\t\t\t\t\tInvalid choice. Please try again.");
                        address = null;
                        break;
                }

                if (addressChoice != "5" && addressChoice != "7" && addressChoice != "6")
                {
                    await BalanceDisplay.GetAndDisplayBalance(web3, address);
                }
            } while (!string.IsNullOrWhiteSpace(addressChoice));
        }
        public static async Task ExecuteALLTransactionsEveryHalfSecond(Web3 web3)
        {
            for (int i = 0; i < 65; i++) // Repeat 65 times for 22.75 seconds (0.35 seconds interval)
            {
                await Task.Delay(0); // Wait for 0.35 seconds
                await TransactionDisplay.DisplayAllEthTransactions(web3);
            }
        }

        public static async Task ExecutePendingTransactionsEveryHalfSecondWithInput(Web3 web3)
        {
            Console.Write("\t\t\t\t\t\t\t\t\t\tDo you want to run the loop continuously? (yes/no): ");
            string input = Console.ReadLine().ToLower();

            bool runContinuously = input == "yes";

            while (runContinuously)
            {
                Console.Write("\t\t\t\t\t\t\t\t\t\tDo you want to display the countdown timer? (yes/no): ");
                input = Console.ReadLine().ToLower();

                bool displayCountdownTimer = input == "yes";

                Console.WriteLine();
                TransactionDisplay.PrintHeaderPending();
                Console.WriteLine();

                for (int i = 0; i < 2000000; i++) // Repeat 65 times for 22.75 seconds (0.35 seconds interval)
                {
                    await Task.Delay(0); // Wait for 0.10 seconds
                    await TransactionDisplay.DisplayAllEthPending(web3, displayCountdownTimer);
                }

                //Console.Write("Do you want to continue running the loop? (yes/no): ");
                //input = Console.ReadLine().ToLower();
                //runContinuously = input == "yes";
            }
        }
    }
}

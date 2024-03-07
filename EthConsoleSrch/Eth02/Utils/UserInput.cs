//using Nethereum.Web3;

//namespace Eth02.Utils
//{
//    public static class UserInput
//    {
//        public static async Task HandleUserInput(Web3 web3)
//        {
//            string addressChoice;
//            do
//            {
//                addressChoice = ChooseAddress();

//                string address;
//                switch (addressChoice)
//                {
//                    case "1":
//                        address = "0x00000000219ab540356cbb839cbe05303d7705fa";
//                        break;
//                    case "2":
//                        address = "Second address";
//                        break;
//                    case "3":
//                        address = "Third address";
//                        break;
//                    case "4":
//                        Console.Write("Enter custom Ethereum address: ");
//                        address = Console.ReadLine();
//                        break;
//                    case "5":
//                        await TransactionDisplay.DisplayAllEthTransactions(web3);
//                        continue;
//                    default:
//                        Console.WriteLine("Invalid choice. Please try again.");
//                        address = null;
//                        break;
//                }

//                if (addressChoice != "5")
//                {
//                    await BalanceDisplay.GetAndDisplayBalance(web3, address);
//                }
//            } while (!string.IsNullOrWhiteSpace(addressChoice));
//        }

//        static string ChooseAddress()
//        {
//            Console.WriteLine("Choose an Ethereum address:");
//            Console.WriteLine("1. 0x00000000219ab540356cbb839cbe05303d7705fa");
//            Console.WriteLine("2. Second address");
//            Console.WriteLine("3. Third address");
//            Console.WriteLine("4. Custom address (paste it into the console)");
//            Console.WriteLine("5. Display pending transactions");
//            Console.WriteLine("6. EXIT");
//            Console.Write("Enter choice: ");
//            return Console.ReadLine();
//        }
//    }
//}
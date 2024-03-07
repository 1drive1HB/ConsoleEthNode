namespace Eth02.Utils
{
    public static class MessageDisplay
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|---------------------------------------------------|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|********* NODE LIVE SEARCH Ethereum Mempool *******|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|***************************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| Welcome to the Ethereum Mempool Node Search!      |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| The mempool represents transactions waiting to be |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| included in a block on the Ethereum blockchain.   |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| Please choose an option from the menu below:      |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| FROM: https://ethereum-rpc.publicnode.com/        |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| 1. Use RPC node URL     choose    '1'             |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| 2. Use WS RPC node URL  choose    '2'             |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| 3. ENTER to Exit the program                      |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|***************************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|               ** INSTRUCTIONS **                  |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| - To view ALL live  transactions,    choose '2'   |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|   and then enter '6'.                             |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| - To view live pending transactions, choose '2'   |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|   and then enter 'p'.                             |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| - To exit the program, choose option '20/ENTER'.  |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|***************************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|---------------------------------------------------|\n");
        }

        public static void DisplayCurrentNodeURL(string nodeUrl)
        {
            Console.WriteLine($"\t\t\t\t\t\t\t\t\t\tCurrently using node URL: {nodeUrl}\n");
        }

        public static string ChooseAddress()
        {
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|---------------------------------------------------|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|********* NODE LIVE SEARCH Ethereum Mempool *******|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|***************************************************|");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| Welcome to the Ethereum Mempool Node Search!      |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| The mempool represents transactions waiting to be |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| included in a block on the Ethereum blockchain.   |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| Please choose an option from the menu below:      |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| FROM: https://ethereum-rpc.publicnode.com/        |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| -  1  - Show specific Ethereum address:           |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|    0x00000000219ab540356cbb839cbe05303d7705fa     |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| -  5  - Display a single transaction              |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| -  6  - LoopDisplay All Transactions              |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| -  p  - LoopDisplay Pending Transactions          |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| - cls - LoopDisplay Pending Transactions          |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t| -  7  - EXIT                                      |");
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t|---------------------------------------------------|");
            Console.Write("\t\t\t\t\t\t\t\t\t\tEnter Display choice (1,5,6,p,7,cls): ");
            return Console.ReadLine();
            //Console.WriteLine();
            //TransactionDisplay.PrintHeader();
        }
    }
}

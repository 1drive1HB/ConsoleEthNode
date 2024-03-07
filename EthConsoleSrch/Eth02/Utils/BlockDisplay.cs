using Nethereum.Web3;

namespace Eth02.Utils
{
    public static class BlockDisplay
    {
        public static async Task DisplayLatestBlockNumber(Web3 web3)
        {
            var latestBlockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
            Console.WriteLine($"\t\t\t\t\tThe latest block number is: {latestBlockNumber.Value}");
        }
    }
}

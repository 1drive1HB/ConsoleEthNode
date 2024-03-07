using Nethereum.Web3;

namespace Eth02.Utils
{
    public class BalanceDisplay
    {
        public static async Task GetAndDisplayBalance(Web3 web3, string? address)
        {
            if (!string.IsNullOrWhiteSpace(address))
            {
                var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
                Console.WriteLine($"\t\t\t\t\tBalance of address {address}: {Web3.Convert.FromWei(balance)} ETH");
            }
        }
    }
}

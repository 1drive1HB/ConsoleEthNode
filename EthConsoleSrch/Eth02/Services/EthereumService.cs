using Eth02.Models;
using Nethereum.Web3;

namespace Eth02.Services
{
    public class EthereumService
    {
        public async Task<bool> IsConnected(EthereumNode node)
        {
            try
            {
                var web3 = new Web3(node.NodeUrl);
                var blockNumber = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<decimal?> GetBalance(EthereumNode node, string address)
        {
            try
            {
                var web3 = new Web3(node.NodeUrl);
                var balance = await web3.Eth.GetBalance.SendRequestAsync(address);
                return Web3.Convert.FromWei(balance);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }
}

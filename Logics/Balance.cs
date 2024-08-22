using Nethereum.Web3;

namespace Balance
{
    public class Account_Balance
    {
        public static decimal Get_Balance(string address)
        {
            var web3 = new Web3("https://sepolia.infura.io/v3/591fdde4e4f340659f50e84f7f4d86fb");
            var balanceWei = web3.Eth.GetBalance.SendRequestAsync(address).Result;
            return Web3.Convert.FromWei(balanceWei);
        }
    }
}

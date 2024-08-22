using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace Transactions
{
    public class Transaction
    {
        public static string Start_transaction(string private_key, string receiver_address, decimal amount)
        {
            var account = new Account(private_key);
            var web3 = new Web3(account, "https://sepolia.infura.io/v3/591fdde4e4f340659f50e84f7f4d86fb");

            try
            {
                var transaction = web3.Eth.GetEtherTransferService().TransferEtherAndWaitForReceiptAsync(receiver_address, amount).Result;
                return ($"[Успешно]: Транзакция сформирована, подписана и отправлена в сеть. \nХеш транзакции: {transaction.TransactionHash}");
            }
            catch (Exception ex)
            {
                return ($"[Ошибка]: Возникла ошибка при работе с транзакцией: {ex.Message}");
            }
        }
    }
}

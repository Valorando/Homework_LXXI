using Transactions;
using Nethereum.Web3;
using Nethereum.Util;
using Nethereum.Signer;

namespace Steps
{
    public class Step3
    {
        public static void Start_step3()
        {
            try
            {
                Console.WriteLine("Шаг III - отправка транзакции.");



                Console.Write("Вставьте сюда адрес отправителя: ");
                string sender_address = Console.ReadLine();
                Console.WriteLine("[Внимание]: Выполняется проверка адреса на валидность...");
                if (string.IsNullOrEmpty(sender_address) || sender_address.Length != 42)
                {
                    Console.WriteLine("[Ошибка]: Адрес не прошёл проверку на валидность.");
                    return;
                }
                Console.WriteLine("[Успешно]: Адрес прошёл проверку на валидность.");



                Console.WriteLine("[Внимание]: Выполняется проверка адреса на достоверность...");
                Address_reliability_test(sender_address);



                Console.Write("Вставьте сюда приватный ключ отправителя: ");
                string private_key = Console.ReadLine();
                Console.WriteLine("[Внимание]: Выполняется проверка ключа на валидность...");
                if (string.IsNullOrEmpty(private_key) || private_key.Length != 64)
                {
                    Console.WriteLine("[Ошибка]: Ключ не прошёл проверку на валидность.");
                    return;
                }
                Console.WriteLine("[Успешно]: Ключ прошёл проверку на валидность.");



                Console.WriteLine("[Внимание]: Выполняется проверка ключа на достоверность...");
                Private_key_reliabilyty_test(private_key);



                Console.Write("Вставьте сюда адрес получателя: ");
                string receiver_address = Console.ReadLine();
                Console.WriteLine("[Внимание]: Выполняется проверка адреса на валидность...");
                if (string.IsNullOrEmpty(receiver_address) || receiver_address.Length != 42)
                {
                    Console.WriteLine("[Ошибка]: Количество символов во введённом вами значении не соответствует стандартному ETH адресу.");
                    return;
                }
                Console.WriteLine("[Успешно]: Адрес прошёл проверку на валидность.");



                Console.WriteLine("[Внимание]: Выполняется проверка адреса на достоверность...");
                Address_reliability_test(receiver_address);



                Console.Write("Введите сумму отправки, формат 0,00: ");
                string user_amount = Console.ReadLine();
                Console.WriteLine("[Внимание]: Выполняется проверка суммы на валидность...");
                if (!decimal.TryParse(user_amount, out decimal amount) || amount <= 0)
                {
                    Console.WriteLine("[Ошибка]: Сумма не прошла проверку на валидность.");
                    return;
                }
                Console.WriteLine("[Успешно]: Сумма прошла проверку на валидность.");



                Console.WriteLine("[Внимание]: Выполняется проверка на платёжеспособность...");
                Solvency_test(sender_address, amount);



                Console.WriteLine("[Внимание]: Данные успешно подготовлены и передаются в транзакцию.");
                string transaction_result = Transaction.Start_transaction(private_key, receiver_address, amount);
                Console.WriteLine(transaction_result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }

        private static void Address_reliability_test(string address)
        {
            try
            {
                var web3 = new Web3("https://sepolia.infura.io/v3/591fdde4e4f340659f50e84f7f4d86fb");
                var balanceWei = web3.Eth.GetBalance.SendRequestAsync(address).Result;
                Console.WriteLine("[Успешно]: Адрес прошёл проверку на достоверность.");
            }
            catch (Exception)
            {
                Console.WriteLine("[Ошибка]: Адрес не прошёл проверку на достоверность.");
            }
        }

        private static void Private_key_reliabilyty_test(string private_key)
        {
            try
            {
                var key = new EthECKey(private_key);
                var address = key.GetPublicAddress();
                Console.WriteLine("[Успешно]: Ключ прошёл проверку на достоверность.");
            }
            catch (Exception)
            {
                Console.WriteLine("[Ошибка]: Приватный ключ не прошёл проверку на достоверность.");
            }
        }

        private static void Solvency_test(string address, decimal amount)
        {
            try
            {
                var web3 = new Web3("https://sepolia.infura.io/v3/591fdde4e4f340659f50e84f7f4d86fb");
                var balanceWei = web3.Eth.GetBalance.SendRequestAsync(address).Result;

                decimal balanceInEther = UnitConversion.Convert.FromWei(balanceWei);

                if (balanceInEther < amount)
                {
                    Console.WriteLine("[Ошибка]: Отправитель не прошёл проверку на платёжеспособность.");
                    return;
                }
                Console.WriteLine("[Успешно]: Отправитель прошёл проверку на платёжеспособность.");
            }
            catch (Exception)
            {
                Console.WriteLine("[Ошибка]: Не удалось проверить баланс отправителя.");
            }
        }
    }
}

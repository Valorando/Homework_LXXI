using Balance;

namespace Steps
{
    public class Step2
    {
        public static void Start_Step2()
        {
            Console.WriteLine("Шаг II - получение тестовых денег и проверка баланса.");
            Console.WriteLine("[Подсказка]: Если вы только создали адрес для кошелька, то денег на нём не будет.");
            Console.WriteLine("[Подсказка]: Для получения тестовых денег воспользуйтесь фаусцетом.");
            Console.WriteLine("[Подсказка]: Рекомендуем использовать: https://cloud.google.com/application/web3/faucet/ethereum/sepolia");
            Console.WriteLine("[Подсказка]: После того как фаусцет отправил деньги на адрес вашего кошелька, вам нужно проверить баланс.\n");

            Console.Write("Вставьте сюда адрес кошелька: ");
            string address_for_check_balance = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(address_for_check_balance))
            {
                Console.WriteLine("[Ошибка]: Введённое вами значение не содержит символов.");
                return;
            }

            else if (address_for_check_balance.Length != 42)
            {
                Console.WriteLine("[Ошибка]: Количество символов во введённом вами значении не соответствует стандартному ETH адресу.");
                return;
            }

            Console.WriteLine("[Внимание]: Выполняется получение информации о балансе...");
            try
            {
                var balance = Account_Balance.Get_Balance(address_for_check_balance);
                Console.WriteLine($"[Успешно]: Информация о балансе получена.");
                Console.WriteLine($"На балансе: {balance} Sepolia ETH.");
            }
            catch (AggregateException ex)
            {
                var innerExceptionMessage = ex.InnerException?.Message ?? string.Empty;

                if (innerExceptionMessage.Contains("invalid argument 0: json: cannot unmarshal hex string of odd length", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[Ошибка]: Введённое вами значение не является корректным ETH адресом.");
                }
                else if (innerExceptionMessage.Contains("invalid argument 0: json: cannot unmarshal invalid hex string", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[Ошибка]: Введённое вами значение не является корректным ETH адресом.");
                }
                else if (innerExceptionMessage.Contains("invalid argument 0: hex string has length", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("[Ошибка]: Введённое вами значение не является корректным ETH адресом.");
                }
                else if (ex.InnerException is HttpRequestException)
                {
                    Console.WriteLine("[Ошибка]: Не удалось подключиться к ресурсу.");
                }
                else
                {
                    Console.WriteLine($"[Ошибка]: Произошла неожиданная ошибка: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Ошибка]: Произошла неожиданная ошибка: {ex.Message}");
            }
        }
    }
}

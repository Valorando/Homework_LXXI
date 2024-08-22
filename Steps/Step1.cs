using Generate;

namespace Steps
{
    public class Step1
    {
        public static void Start_Step1()
        {
            Console.WriteLine("ШАГ I: Генерация ключей и адресов.");
            Console.WriteLine("[Внимание]: Выполняется генерация...");

            string private_key1 = Generate_Keys.GeneratePrivateKey();
            string address1 = Generate_Keys.GenerateAddress(private_key1);

            string private_key2 = Generate_Keys.GeneratePrivateKey();
            string address2 = Generate_Keys.GenerateAddress(private_key2);

            Console.WriteLine("[Успешно]: Приватные ключи и адреса сгенерированы.\n");
            Console.WriteLine($"Приватный ключ 1: {private_key1}");
            Console.WriteLine($"Адрес 1: {address1}\n");
            Console.WriteLine($"Приватный ключ 2: {private_key2}");
            Console.WriteLine($"Адрес 2: {address2}\n");
            Console.WriteLine("[Подсказка]: Скопируйте и сохраните у себя эти ключи и адреса, если будете использовать их в работе.");
        }
    }
}
using Steps;

while (true)
{
    Console.WriteLine("Шаг I - генерация ключей и адресов.");
    Console.WriteLine("Шаг II - получение тестовых денег и проверка баланса.");
    Console.WriteLine("Шаг III - отправка транзакции.\n");

    Console.WriteLine("Чтобы перейти к шагу I - нажмите кнопку 1.");
    Console.WriteLine("Чтобы перейти к шагу II - нажмите кнопку 2.");
    Console.WriteLine("Чтобы перейти к шагу III - нажмите кнопку 3.");
    Console.WriteLine("Чтобы выйти - нажмите любую другую кнопку.");

    ConsoleKeyInfo main_menu_key = Console.ReadKey(true);

    if (main_menu_key.Key == ConsoleKey.D1)
    {
        Option1();
    }

    else if (main_menu_key.Key == ConsoleKey.D2)
    {
        Option2();
    }

    else if (main_menu_key.Key == ConsoleKey.D3)
    {
        Option3();
    }

    else
    {
        Environment.Exit(0);
    }
}



void Option1()
{
    while (true)
    {
        Console.Clear();
        Step1.Start_Step1();
        Console.WriteLine();
        Console.WriteLine("Чтобы повторить шаг I - нажмите кнопку 1.");
        Console.WriteLine("Чтобы перейти к шагу II - нажмите кнопку 2.");
        Console.WriteLine("Чтобы вернуться в основное меню - нажмите любую другую кнопку.");

        ConsoleKeyInfo option1_key = Console.ReadKey(true);

        if (option1_key.Key == ConsoleKey.D1)
        {
            continue;
        }

        else if (option1_key.Key == ConsoleKey.D2)
        {
            Option2();
        }

        else
        {
            Console.Clear();
            break;
        }
    }
}

void Option2()
{
    while (true)
    {
        Console.Clear();
        Step2.Start_Step2();
        Console.WriteLine();
        Console.WriteLine("Чтобы повторить шаг II - нажмите кнопку 1.");
        Console.WriteLine("Чтобы перейти к шагу I - нажмите кнопку 2.");
        Console.WriteLine("Чтобы перейти к шагу III - нажмите кнопку 3.");
        Console.WriteLine("Чтобы вернуться в основное меню - нажмите любую другую кнопку.");

        ConsoleKeyInfo option2_key = Console.ReadKey(true);

        if (option2_key.Key == ConsoleKey.D1)
        {
            continue;
        }

        else if (option2_key.Key == ConsoleKey.D2)
        {
            Option1();
        }

        else if (option2_key.Key == ConsoleKey.D3)
        {
            Option3();
        }

        else
        {
            Console.Clear();
            break;
        }
    }
}

void Option3()
{
    while (true)
    {
        Console.Clear();
        Step3.Start_step3();
        Console.WriteLine();
        Console.WriteLine("Чтобы повторить шаг III - нажмите кнопку 1.");
        Console.WriteLine("Чтобы перейти к шагу II - нажмите кнопку 2.");
        Console.WriteLine("Чтобы вернуться в основное меню - нажмите любую другую кнопку.");

        ConsoleKeyInfo option3_key = Console.ReadKey(true);

        if (option3_key.Key == ConsoleKey.D1)
        {
            continue;
        }

        else if (option3_key.Key == ConsoleKey.D2)
        {
            Option2();
        }

        else
        {
            Console.Clear();
            break;
        }
    }
}
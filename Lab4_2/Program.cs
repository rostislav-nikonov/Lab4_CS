using System;

namespace CollectionsLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== Программа работы с классом Money =====\n");

            bool continueProgram = true;

            while (continueProgram)
            {
                Console.WriteLine("\n--- Главное меню ---");
                Console.WriteLine("1. Создать новый объект Money");
                Console.WriteLine("2. Выполнить унарную операцию (++ или --)");
                Console.WriteLine("3. Выполнить сложение");
                Console.WriteLine("4. Выполнить вычитание");
                Console.WriteLine("5. Выполнить приведение типов");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите пункт меню (1-6): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateMoneyObject();
                        break;
                    case "2":
                        PerformUnaryOperation();
                        break;
                    case "3":
                        PerformAddition();
                        break;
                    case "4":
                        PerformSubtraction();
                        break;
                    case "5":
                        PerformTypeConversion();
                        break;
                    case "6":
                        continueProgram = false;
                        Console.WriteLine("\nПрограмма завершена.");
                        break;
                    default:
                        Console.WriteLine("Ошибка: выберите пункт из меню.");
                        break;
                }
            }

            Console.ReadKey();
        }

        static void CreateMoneyObject()
        {
            Console.WriteLine("\n--- Создание объекта Money ---");
            Console.Write("Введите количество рублей: ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение для рублей.");
                return;
            }

            Console.Write("Введите количество копеек: ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение для копеек.");
                return;
            }

            Money money = new Money(rubles, kopeks);
            Console.WriteLine("Создан объект: " + money.ToString());
        }

        static void PerformUnaryOperation()
        {
            Console.WriteLine("\n--- Унарные операции (++ и --) ---");
            Console.Write("Введите количество рублей: ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение для рублей.");
                return;
            }

            Console.Write("Введите количество копеек: ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение для копеек.");
                return;
            }

            Money money = new Money(rubles, kopeks);
            Console.WriteLine("Исходное значение: " + money.ToString());

            Console.WriteLine("\n1. Инкремент (++)");
            Console.WriteLine("2. Декремент (--)");
            Console.Write("Выберите операцию (1 или 2): ");
            string operation = Console.ReadLine();

            if (operation == "1")
            {
                money++;
                Console.WriteLine("Результат после ++: " + money.ToString());
            }
            else if (operation == "2")
            {
                money--; 
                Console.WriteLine("Результат после --: " + money.ToString());
            }
            else
            {
                Console.WriteLine("Ошибка: выберите 1 или 2.");
            }
        }


        static void PerformAddition()
        {
            Console.WriteLine("\n--- Сложение ---");
            Console.WriteLine("1. Money + uint (объект + рубли)");
            Console.WriteLine("2. uint + Money (рубли + объект)");
            Console.WriteLine("3. Money + Money (объект + объект)");
            Console.Write("Выберите тип сложения (1, 2 или 3): ");

            string additionType = Console.ReadLine();

            if (additionType == "1")
            {
                AdditionMoneyUint();
            }
            else if (additionType == "2")
            {
                AdditionUintMoney();
            }
            else if (additionType == "3")
            {
                AdditionMoneyMoney();
            }
            else
            {
                Console.WriteLine("Ошибка: выберите 1, 2 или 3.");
            }
        }

        static void AdditionMoneyUint()
        {
            Console.WriteLine("\n--- Money + uint ---");
            Console.Write("Введите рубли (первого объекта): ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (первого объекта): ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money = new Money(rubles, kopeks);

            Console.Write("Введите рубли для добавления: ");
            string addInput = Console.ReadLine();

            if (!uint.TryParse(addInput, out uint addRubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money result = money + addRubles;

            Console.WriteLine("\n" + money.ToString() + " + " + addRubles + " рублей");
            Console.WriteLine("Результат: " + result.ToString());
        }

        static void AdditionUintMoney()
        {
            Console.WriteLine("\n--- uint + Money ---");
            Console.Write("Введите рубли для добавления: ");
            string addInput = Console.ReadLine();

            if (!uint.TryParse(addInput, out uint addRubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите рубли (второго объекта): ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (второго объекта): ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money = new Money(rubles, kopeks);
            Money result = addRubles + money;

            Console.WriteLine("\n" + addRubles + " рублей + " + money.ToString());
            Console.WriteLine("Результат: " + result.ToString());
        }

        static void AdditionMoneyMoney()
        {
            Console.WriteLine("\n--- Money + Money ---");
            Console.Write("Введите рубли (первого объекта): ");
            string rubleInput1 = Console.ReadLine();

            if (!uint.TryParse(rubleInput1, out uint rubles1))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (первого объекта): ");
            string kopekInput1 = Console.ReadLine();

            if (!byte.TryParse(kopekInput1, out byte kopeks1))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money1 = new Money(rubles1, kopeks1);

            Console.Write("Введите рубли (второго объекта): ");
            string rubleInput2 = Console.ReadLine();

            if (!uint.TryParse(rubleInput2, out uint rubles2))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (второго объекта): ");
            string kopekInput2 = Console.ReadLine();

            if (!byte.TryParse(kopekInput2, out byte kopeks2))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money2 = new Money(rubles2, kopeks2);
            Money result = money1 + money2;

            Console.WriteLine("\n" + money1.ToString() + " + " + money2.ToString());
            Console.WriteLine("Результат: " + result.ToString());
        }

        static void PerformSubtraction()
        {
            Console.WriteLine("\n--- Вычитание ---");
            Console.WriteLine("1. Money - uint (объект - рубли)");
            Console.WriteLine("2. uint - Money (рубли - объект)");
            Console.WriteLine("3. Money - Money (объект - объект)");
            Console.Write("Выберите тип вычитания (1, 2 или 3): ");

            string subtractionType = Console.ReadLine();

            if (subtractionType == "1")
            {
                SubtractionMoneyUint();
            }
            else if (subtractionType == "2")
            {
                SubtractionUintMoney();
            }
            else if (subtractionType == "3")
            {
                SubtractionMoneyMoney();
            }
            else
            {
                Console.WriteLine("Ошибка: выберите 1, 2 или 3.");
            }
        }

        static void SubtractionMoneyUint()
        {
            Console.WriteLine("\n--- Money - uint ---");
            Console.Write("Введите рубли (первого объекта): ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (первого объекта): ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money = new Money(rubles, kopeks);

            Console.Write("Введите рубли для вычитания: ");
            string subInput = Console.ReadLine();

            if (!uint.TryParse(subInput, out uint subRubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money result = money - subRubles;

            Console.WriteLine("\n" + money.ToString() + " - " + subRubles + " рублей");
            Console.WriteLine("Результат: " + result.ToString());
        }

        static void SubtractionUintMoney()
        {
            Console.WriteLine("\n--- uint - Money ---");
            Console.Write("Введите рубли для вычитания из: ");
            string subInput = Console.ReadLine();

            if (!uint.TryParse(subInput, out uint subRubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите рубли (объекта): ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (объекта): ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money = new Money(rubles, kopeks);
            Money result = subRubles - money;

            Console.WriteLine("\n" + subRubles + " рублей - " + money.ToString());
            Console.WriteLine("Результат: " + result.ToString());
        }

        static void SubtractionMoneyMoney()
        {
            Console.WriteLine("\n--- Money - Money ---");
            Console.Write("Введите рубли (первого объекта): ");
            string rubleInput1 = Console.ReadLine();

            if (!uint.TryParse(rubleInput1, out uint rubles1))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (первого объекта): ");
            string kopekInput1 = Console.ReadLine();

            if (!byte.TryParse(kopekInput1, out byte kopeks1))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money1 = new Money(rubles1, kopeks1);

            Console.Write("Введите рубли (второго объекта): ");
            string rubleInput2 = Console.ReadLine();

            if (!uint.TryParse(rubleInput2, out uint rubles2))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки (второго объекта): ");
            string kopekInput2 = Console.ReadLine();

            if (!byte.TryParse(kopekInput2, out byte kopeks2))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money2 = new Money(rubles2, kopeks2);
            Money result = money1 - money2;

            Console.WriteLine("\n" + money1.ToString() + " - " + money2.ToString());
            Console.WriteLine("Результат: " + result.ToString());
        }

        static void PerformTypeConversion()
        {
            Console.WriteLine("\n--- Приведение типов ---");
            Console.Write("Введите рубли: ");
            string rubleInput = Console.ReadLine();

            if (!uint.TryParse(rubleInput, out uint rubles))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Console.Write("Введите копейки: ");
            string kopekInput = Console.ReadLine();

            if (!byte.TryParse(kopekInput, out byte kopeks))
            {
                Console.WriteLine("Ошибка: некорректное значение.");
                return;
            }

            Money money = new Money(rubles, kopeks);
            Console.WriteLine("\nОбъект Money: " + money.ToString());

            // Явное приведение к uint
            uint onlyRubles = (uint)money;
            Console.WriteLine("Явное приведение к uint (только рубли): " + onlyRubles);

            // Неявное приведение к double
            double onlyKopeks = money;
            Console.WriteLine("Неявное приведение к double (только копейки): " + onlyKopeks.ToString("0.00"));
        }
    }
}

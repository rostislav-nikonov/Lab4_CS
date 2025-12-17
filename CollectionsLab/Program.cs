using System;
using System.Collections.Generic;
using CollectionsLab;

internal class Program
{
    private static void Main(string[] args)
    {
        bool flag = true;

        while (flag)
        {
            Console.Write("1 - повторная вставка списка после элемента\n" +
                "2 - вставка элемента в начало и конец списка\n" +
                "3 - определить какие книги прочитали все, а какие не все\n" +
                "4 - символы, которых нет в первом слове, но есть в остальных\n" +
                //"5 - школьная олимпиада по информатике\n" +
                "6 - выход из программы\n" +
                "Ваш выбор: ");

            int choose = Convert.ToInt32(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    Task1();
                    break;

                case 2:
                    Task2();
                    break;

                case 3:
                    Task3();
                    break;

                case 4:
                    Task4();
                    break;

               

                case 6:
                    flag = false;
                    Console.WriteLine("До свидания!");
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.\n");
                    break;
            }
        }
    }

    private static void Task1()
    {
        Console.Write("Введите число элементов списка: ");
        int count = Convert.ToInt32(Console.ReadLine());

        var numbers = new List<int>();

        Console.WriteLine("Введите элементы списка:");

        for (int i = 0; i < count; i++)
        {
            numbers.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Введите элемент списка, после которого надо вставить список повторно: ");
        int element = Convert.ToInt32(Console.ReadLine());

        var result = ListAndHash.InsertAfterElement(element, numbers);

        Console.WriteLine("\nИзмененный список:");

        foreach (var number in result)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();
    }

    private static void Task2()
    {
        Console.Write("Введите число элементов списка: ");
        int count = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите число, которое надо вставить в начало и конец списка: ");
        int element = Convert.ToInt32(Console.ReadLine());

        var numberList = new LinkedList<int>();

        Console.WriteLine("Введите элементы списка:");

        for (int i = 0; i < count; i++)
        {
            numberList.AddLast(Convert.ToInt32(Console.ReadLine()));
        }

        ListAndHash.PrependAndAppend(numberList, element);

        Console.WriteLine("\nИзмененный список:");

        foreach (var number in numberList)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine();
    }

    private static void Task3()
    {
        var libraryCatalog = new[]
        {
            "Гарри Поттер",
            "Хоббит",
            "Властелин колец",
            "Мы",
            "Преступление и наказание",
            "1984"
        };

        ListAndHash.AnalyzeBooks(libraryCatalog);
        Console.WriteLine();
    }

    private static void Task4()
    {
        string filePath = "TextLab.txt";

        ListAndHash.FindSymbols(filePath);

        Console.WriteLine();
    }
    /*
    private static void Task5()
    {
        ListAndHash.ProcessOlympiad();

        Console.WriteLine();
    }
    */
}
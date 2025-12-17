using System;
using System.Collections.Generic;

namespace CollectionsLab;

public class Participant
{
    private string _lastname;
    private string _firstname;
    private int _grade;
    private int _score;
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int Grade { get; set; }
    public int Score { get; set; }
}

public static class ListAndHash
{
    public static List<int> InsertAfterElement(int element, List<int> numbers)
    {
        var result = new List<int>();
        var isInserted = false;

        foreach (var number in numbers)
        {
            result.Add(number);

            if (!isInserted && number == element)
            {
                result.AddRange(numbers);
                isInserted = true;
            }
        }

        return result;
    }

    public static void PrependAndAppend(LinkedList<int> numbers, int element)
    {
        numbers.AddFirst(element);
        numbers.AddLast(element);
    }

    public static void AnalyzeBooks(string[] catalog)
    {
        var readers = new Dictionary<string, HashSet<string>>();
        var catalogSet = new HashSet<string>();

        foreach (var book in catalog)
        {
            catalogSet.Add(book);
        }

        Console.Write("Введите количество читателей: ");
        int readerCount = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < readerCount; i++)
        {
            Console.Write($"Введите имя читателя {i + 1}: ");
            string readerName = Console.ReadLine();

            Console.Write("Сколько книг он прочитал? ");
            int bookCount = Convert.ToInt32(Console.ReadLine());

            var booksRead = new List<string>();

            Console.WriteLine("Введите названия книг:");

            for (int j = 0; j < bookCount; j++)
            {
                booksRead.Add(Console.ReadLine());
            }

            var validBooks = new HashSet<string>();

            foreach (var book in booksRead)
            {
                if (catalogSet.Contains(book))
                {
                    validBooks.Add(book);
                }
            }

            readers[readerName] = validBooks;
        }

        if (readers.Count == 0)
        {
            Console.WriteLine("Нет читателей для анализа.");
            return;
        }

        var readByAtLeastOne = new HashSet<string>();

        foreach (var readerBooks in readers.Values)
        {
            foreach (var book in readerBooks)
            {
                readByAtLeastOne.Add(book);
            }
        }

        var readByAll = new HashSet<string>();
        bool firstReader = true;

        foreach (var readerBooks in readers.Values)
        {
            if (firstReader)
            {
                foreach (var book in readerBooks)
                {
                    readByAll.Add(book);
                }

                firstReader = false;
            }
            else
            {
                var toRemove = new List<string>();

                foreach (var book in readByAll)
                {
                    if (!readerBooks.Contains(book))
                    {
                        toRemove.Add(book);
                    }
                }

                foreach (var book in toRemove)
                {
                    readByAll.Remove(book);
                }
            }
        }

        var readBySome = new HashSet<string>();

        foreach (var book in readByAtLeastOne)
        {
            if (!readByAll.Contains(book))
            {
                readBySome.Add(book);
            }
        }

        var readByNone = new HashSet<string>();

        foreach (var book in catalogSet)
        {
            if (!readByAtLeastOne.Contains(book))
            {
                readByNone.Add(book);
            }
        }

        PrintBookGroup("Прочли все читатели:", readByAll);
        PrintBookGroup("Прочли некоторые (но не все):", readBySome);
        PrintBookGroup("Не прочел никто:", readByNone);
    }

    public static void FindSymbols(string filePath)
    {
        try
        {
            string text = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
            var words = ExtractWords(text);

            if (words.Count == 0)
            {
                Console.WriteLine("В файле нет слов.");
                return;
            }

            var firstWordChars = new HashSet<char>();

            foreach (var ch in words[0].ToLower())
            {
                firstWordChars.Add(ch);
            }

            var commonChars = new HashSet<char>();

            for (int i = 1; i < words.Count; i++)
            {
                var currentWordChars = new HashSet<char>();

                foreach (var ch in words[i].ToLower())
                {
                    currentWordChars.Add(ch);
                }

                var toRemove = new List<char>();

                foreach (var ch in currentWordChars)
                {
                    if (firstWordChars.Contains(ch))
                    {
                        toRemove.Add(ch);
                    }
                }

                foreach (var ch in toRemove)
                {
                    currentWordChars.Remove(ch);
                }

                if (i == 1)
                {
                    foreach (var ch in currentWordChars)
                    {
                        commonChars.Add(ch);
                    }
                }
                else
                {
                    var toRemoveCommon = new List<char>();

                    foreach (var ch in commonChars)
                    {
                        if (!currentWordChars.Contains(ch))
                        {
                            toRemoveCommon.Add(ch);
                        }
                    }

                    foreach (var ch in toRemoveCommon)
                    {
                        commonChars.Remove(ch);
                    }
                }
            }

            if (commonChars.Count == 0)
            {
                Console.WriteLine("Таких символов не найдено.");
            }
            else
            {
                Console.WriteLine("Символы, которых нет в первом слове, но есть в остальных:");

                var sortedChars = new List<char>();

                foreach (var ch in commonChars)
                {
                    sortedChars.Add(ch);
                }

                //SortCharacters(sortedChars);

                foreach (var ch in sortedChars)
                {
                    Console.Write(ch);
                }

                Console.WriteLine();
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден.");
        }
    }
    /*
    public static void ProcessOlympiad()
    {
        Console.Write("Введите число участников олимпиады: ");
        int participantCount = Convert.ToInt32(Console.ReadLine());

        var participants = new List<Participant>();

        Console.WriteLine("Введите данные участников (Фамилия Имя класс баллы):");

        for (int i = 0; i < participantCount; i++)
        {
            Participant participant = null;
            bool isValid = false;

            while (!isValid)
            {
                string line = Console.ReadLine();
                participant = ParseParticipant(line);

                if (participant != null)
                {
                    isValid = true;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода! Проверьте данные и введите снова:");
                }
            }

            participants.Add(participant);
        }

        int minimumPrizeScore = DeterminePrizeScore(participants);
        Dictionary<int, int> prizesByGrade = CountPrizesByGrade(participants, minimumPrizeScore);

        Console.WriteLine("\nРезультаты олимпиады:");
        Console.WriteLine(minimumPrizeScore);

        string output = string.Empty;

        for (int grade = 7; grade <= 11; grade++)
        {
            if (string.IsNullOrEmpty(output))
            {
                output = prizesByGrade[grade].ToString();
            }
            else
            {
                output += " " + prizesByGrade[grade].ToString();
            }
        }

        Console.WriteLine(output);
    }

    private static int DeterminePrizeScore(List<Participant> participants)
    {
        const int MaximumScore = 70;
        const int HalfMaximumScore = 35;
        const double SelectionPercentage = 0.25;

        List<Participant> sortedParticipants = new List<Participant>();

        foreach (var participant in participants)
        {
            sortedParticipants.Add(participant);
        }

        SortParticipantsByScore(sortedParticipants);

        int selectionCount = (int)Math.Ceiling(sortedParticipants.Count * SelectionPercentage);

        int scoreAtSelection = sortedParticipants[selectionCount - 1].Score;

        int lastIndexWithSameScore = selectionCount - 1;

        while (lastIndexWithSameScore + 1 < sortedParticipants.Count &&
               sortedParticipants[lastIndexWithSameScore + 1].Score == scoreAtSelection)
        {
            lastIndexWithSameScore++;
        }

        if (lastIndexWithSameScore > selectionCount - 1)
        {
            if (scoreAtSelection > HalfMaximumScore)
            {
                return scoreAtSelection;
            }
            else
            {
                return scoreAtSelection + 1;
            }
        }

        return scoreAtSelection;
    }

    private static Dictionary<int, int> CountPrizesByGrade(List<Participant> participants, int minimumPrizeScore)
    {
        Dictionary<int, int> result = new Dictionary<int, int>();

        for (int grade = 7; grade <= 11; grade++)
        {
            result[grade] = 0;
        }

        foreach (Participant participant in participants)
        {
            if (participant.Score >= minimumPrizeScore)
            {
                result[participant.Grade]++;
            }
        }

        return result;
    }

    private static Participant ParseParticipant(string line)
    {
        try
        {
            string[] parts = line.Split(' ');

            if (parts.Length != 4)
            {
                return null;
            }

            string lastName = parts[0];
            string firstName = parts[1];
            string gradeStr = parts[2];
            string scoreStr = parts[3];

            if (!IsValidName(lastName))
            {
                Console.WriteLine("Ошибка: Фамилия должна содержать только буквы!");
                return null;
            }

            if (!IsValidName(firstName))
            {
                Console.WriteLine("Ошибка: Имя должно содержать только буквы!");
                return null;
            }

            if (!int.TryParse(gradeStr, out int grade))
            {
                Console.WriteLine("Ошибка: Класс должен быть числом!");
                return null;
            }

            if (grade < 7 || grade > 11)
            {
                Console.WriteLine("Ошибка: Класс должен быть от 7 до 11!");
                return null;
            }

            if (!int.TryParse(scoreStr, out int score))
            {
                Console.WriteLine("Ошибка: Баллы должны быть числом!");
                return null;
            }

            if (score < 0 || score > 70)
            {
                Console.WriteLine("Ошибка: Баллы должны быть от 0 до 70!");
                return null;
            }

            Participant participant = new Participant
            {
                LastName = lastName,
                FirstName = firstName,
                Grade = grade,
                Score = score
            };

            return participant;
        }
        catch (Exception)
        {
            Console.WriteLine("Ошибка при обработке данных!");
            return null;
        }
    }

    private static bool IsValidName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return false;
        }

        foreach (char ch in name)
        {
            if (!char.IsLetter(ch))
            {
                return false;
            }
        }

        return true;
    }

    private static void SortParticipantsByScore(List<Participant> participants)
    {
        for (int i = 0; i < participants.Count - 1; i++)
        {
            for (int j = 0; j < participants.Count - 1 - i; j++)
            {
                if (participants[j].Score < participants[j + 1].Score)
                {
                    Participant temp = participants[j];
                    participants[j] = participants[j + 1];
                    participants[j + 1] = temp;
                }
            }
        }
    }

    private static void SortCharacters(List<char> characters)
    {
        for (int i = 0; i < characters.Count - 1; i++)
        {
            for (int j = 0; j < characters.Count - 1 - i; j++)
            {
                if (characters[j] > characters[j + 1])
                {
                    char temp = characters[j];
                    characters[j] = characters[j + 1];
                    characters[j + 1] = temp;
                }
            }
        }
    }
    */
    private static void PrintBookGroup(string title, HashSet<string> books)
    {
        Console.WriteLine(title);

        if (books.Count == 0)
        {
            Console.WriteLine("  (нет таких книг)");
        }
        else
        {
            foreach (var book in books)
            {
                Console.WriteLine($"  • {book}");
            }
        }

        Console.WriteLine();
    }

    private static List<string> ExtractWords(string text)
    {
        var words = new List<string>();
        string currentWord = string.Empty;

        foreach (var ch in text)
        {
            if (char.IsLetter(ch))
            {
                currentWord += ch;
            }
            else
            {
                if (currentWord.Length > 0)
                {
                    words.Add(currentWord);
                    currentWord = string.Empty;
                }
            }
        }

        if (currentWord.Length > 0)
        {
            words.Add(currentWord);
        }

        return words;
    }
}
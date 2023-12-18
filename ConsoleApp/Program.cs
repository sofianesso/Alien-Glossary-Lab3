using ClassLib;
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {

        PrintWelcomeMessage();

        if (args.Length > 0)
        {
            ProcessArguments(args);
        }
        else
        {
            while (true)
            {
                Console.Clear();
                ShowUsageInstructions(); 
                HandleUserInput(); 
            }
        }
    }

    static void HandleUserInput()
    {
        Console.Clear();
        PrintWelcomeMessage();

        ShowUsageInstructions();

        Console.Write("Ange ett kommando (eller 'exit' för att avsluta): ");
        Console.ForegroundColor = ConsoleColor.White;
        var input = Console.ReadLine();
        Console.ResetColor();

        if (input != null && input.ToLower() == "exit")
        {
            Environment.Exit(0);
        }

        if (input != null)
        {
            var inputArgs = input.Split(' ');
            ProcessArguments(inputArgs);
        }

        Console.WriteLine("Tryck på valfri tangent för att fortsätta...");
        Console.ReadKey(); 
    }

    static bool ProcessArguments(string[] args)
    {
        switch (args[0].ToLower())
        {
            case "-lists":
                ListWordLists();
                break;

            case "-new":
                CreateNewWordList(args);
                break;

            case "-add":
                AddWordsToList(args);
                break;

            case "-remove":
                RemoveWordsFromList(args);
                break;

            case "-words":
                ListWords(args);
                break;

            case "-count":
                CountWordsInList(args);
                break;

            case "-practice":
                PracticeWords(args);
                break;

            default:
                return false;
        }

        return true;
    }
    static void ShowUsageInstructions()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("Kommandon:".PadRight(39) + "|");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("-lists".PadRight(39) + "|");
        Console.WriteLine("-new <list name> <language 1> ...".PadRight(39) + "|");
        Console.WriteLine("-add <list name>".PadRight(39) + "|");
        Console.WriteLine("-remove <list name> <language> <word 1> ...".PadRight(39) + "|");
        Console.WriteLine("-words <list name> [sortByLanguage]".PadRight(39) + "|");
        Console.WriteLine("-count <list name>".PadRight(39) + "|");
        Console.WriteLine("-practice <list name>".PadRight(39) + "|");
        Console.WriteLine(new string('-', 40));
        Console.ResetColor();
    }
    static void ListWordLists()
    {
        var lists = WordList.GetLists();
        foreach (var list in lists)
        {
            Console.WriteLine(list);
        }
    }
    static void CreateNewWordList(string[] args)
    {
        if (args.Length < 3)
        {
            Console.WriteLine("Ogiltiga argument. Exempel: -new <list name> <language 1> <language 2> ...");
            return;
        }

        var newList = new WordList(args[1], args.Skip(2).ToArray());
        newList.Save();
        Console.WriteLine($"Lista '{args[1]}' skapad med språken {String.Join(", ", args.Skip(2))}.");
        AddWordsToWordList(newList);
    }
    static void AddWordsToList(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Ogiltiga argument. Exempel: -add <list name>");
            return;
        }

        var listToAddWords = WordList.LoadList(args[1]);
        AddWordsToWordList(listToAddWords);
        listToAddWords.Save();
    }
    static void RemoveWordsFromList(string[] args)
    {
        if (args.Length < 4)
        {
            Console.WriteLine("Ogiltiga argument. Exempel: -remove <list name> <language> <word 1> <word 2> ...");
            return;
        }

        var listToRemoveWords = WordList.LoadList(args[1]);
        int languageIndex = Array.IndexOf(listToRemoveWords.Languages, args[2]);
        if (languageIndex == -1)
        {
            Console.WriteLine("Språket hittades inte i listan.");
            return;
        }

        foreach (var word in args.Skip(3))
        {
            listToRemoveWords.Remove(languageIndex, word);
        }

        listToRemoveWords.Save();
    }
    static void ListWords(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Ogiltiga argument. Exempel: -words <list name> <sortByLanguage>");
            return;
        }

        var listToDisplay = WordList.LoadList(args[1]);
        int sortByLanguageIndex = args.Length > 2 ? Array.IndexOf(listToDisplay.Languages, args[2]) : 0;

        listToDisplay.List(sortByLanguageIndex, translations =>
        {
            Console.WriteLine(string.Join(", ", translations));
        });
    }
    static void CountWordsInList(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Ogiltiga argument. Exempel: -count <list name>");
            return;
        }

        var listToCount = WordList.LoadList(args[1]);
        Console.WriteLine($"Antal ord i listan: {listToCount.Count()}");
    }
    static void PracticeWords(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Ogiltiga argument. Exempel: -practice <list name>");
            return;
        }

        var listToPractice = WordList.LoadList(args[1]);
        if (listToPractice == null || listToPractice.Count() == 0)
        {
            Console.WriteLine("Listan är tom eller finns inte.");
            return;
        }

        PracticeWithWordList(listToPractice);
    }
    static void AddWordsToWordList(WordList list)
    {

        Console.WriteLine($"Lägger till ord i listan: {list.Name}");
        Console.WriteLine("Ange översättningar för varje språk. Tryck på Enter utan att skriva något för att avsluta.");

        while (true)
        {
            var translations = new string[list.Languages.Length];
            for (int i = 0; i < list.Languages.Length; i++)
            {
                Console.Write($"Ange översättningen på {list.Languages[i]}: ");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    return;
                }

                translations[i] = input;
            }

            list.Add(translations);
            Console.WriteLine("Ord tillagt. Ange nästa ord eller tryck Enter för att avsluta.");
        }
    }
    static void PracticeWithWordList(WordList list)
    {
        int totalAttempts = 0, correctAnswers = 0;
        Console.WriteLine("Öva på ord. Skriv 'exit' för att avsluta och se din poäng.");

        while (true)
        {
            var (wordToPractice, fromLanguageIndex, toLanguageIndex) = list.GetWordToPractice();
            Console.WriteLine($"Översätt ordet '{wordToPractice.Translations[fromLanguageIndex]}' från {list.Languages[fromLanguageIndex]} till {list.Languages[toLanguageIndex]}:");
            var userTranslation = Console.ReadLine();

            if (string.IsNullOrEmpty(userTranslation) || userTranslation.ToLower() == "exit")
            {
                break;
            }

            totalAttempts++;
            if (userTranslation.Equals(wordToPractice.Translations[toLanguageIndex], StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Rätt!");
                correctAnswers++;
            }
            else
            {
                Console.WriteLine($"Fel. Rätt översättning är: {wordToPractice.Translations[toLanguageIndex]}");
            }
        }

        Console.WriteLine($"Du övade på {totalAttempts} ord och hade rätt på {correctAnswers} av dem. Din poäng: {correctAnswers}/{totalAttempts}");

    }
    static void PrintWelcomeMessage()
{
    Console.WriteLine("    .-\"\"\"\"-.        .-\"\"\"\"-.");
    Console.WriteLine("   /        \\      /        \\");
    Console.WriteLine("  /_        _\\    /_        _\\");
    Console.WriteLine(" // \\      / \\\\  // \\      / \\\\");
    Console.WriteLine(" |\\__\\    /__/|  |\\__\\    /__/|");
    Console.WriteLine("  \\    ||    /    \\    ||    /");
    Console.WriteLine("   \\        /      \\        /");
    Console.WriteLine("    \\  __  /        \\  __  /");
    Console.WriteLine("     '.__.'          '.__.'");
    Console.WriteLine(" _____ _               _    _ _                               ");
    Console.WriteLine("|_   _| |__   ___     / \\  | (_) ___ _ __                     ");
    Console.WriteLine("  | | | '_ \\ / _ \\   / _ \\ | | |/ _ \\ '_ \\                    ");
    Console.WriteLine("  | | | | | |  __/  / ___ \\| | |  __/ | | |                   ");
    Console.WriteLine("  |_| |_| |_|\\___| /_/   \\_\\_|_|\\___|_| |_|  _                ");
    Console.WriteLine(" / ___| | ___  ___ ___  __ _ _ __ _   _     / \\   _ __  _ __  ");
    Console.WriteLine("| |  _| |/ _ \\/ __/ __|/ _` | '__| | | |   / _ \\ | '_ \\| '_ \\ ");
    Console.WriteLine("| |_| | | (_) \\__ \\__ \\ (_| | |  | |_| |  / ___ \\| |_) | |_) |");
    Console.WriteLine(" \\____|_|\\___/|___/___/\\__,_|_|   \\__, | /_/   \\_\\ .__/| .__/ ");
    Console.WriteLine("                                  |___/          |_|   |_|    ");
    Console.WriteLine();
}


}

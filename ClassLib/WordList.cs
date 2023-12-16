using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ClassLib
{
    public class WordList
    {
        public string Name { get; private set; }
        public string[] Languages { get; private set; }
        private List<Word> words = new List<Word>();

        public WordList(string name, params string[] languages)
        {
            Name = name;
            Languages = languages;
        }

        public void DisplayAllWords(Action<string[]> displayAction)
        {
            foreach (var word in words)
            {
                displayAction(word.Translations);
            }
        }

        private static string GetDataFolderPath()
        {
            string folderName = "theglossaryapp";
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string folderPath = Path.Combine(localAppData, folderName);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        public static string[] GetLists()
        {
            string directoryPath = GetDataFolderPath();
            string[] files = Directory.GetFiles(directoryPath, "*.dat");
            return files.Select(Path.GetFileNameWithoutExtension).ToArray();
        }

        public static WordList LoadList(string name)
        {
            string filePath = Path.Combine(GetDataFolderPath(), $"{name}.dat");
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Filen '{name}.dat' hittades inte i registret.");

            var lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
                throw new InvalidOperationException("Filformatet är inte giltigt, programmet stödjer endast .dat filer");

            string[] languages = lines[0].Split(';');
            var wordList = new WordList(name, languages);

            for (int i = 1; i < lines.Length; i++)
            {
                var translations = lines[i].Split(';');
                if (translations.Length != languages.Length)
                    throw new InvalidOperationException("Fel antal översättningar i raden.");

                wordList.words.Add(new Word(translations));
            }

            return wordList;
        }

        public void List(int sortByTranslation, Action<string[]> showTranslations)
        {
            if (sortByTranslation < 0 || sortByTranslation >= Languages.Length)
                throw new ArgumentOutOfRangeException(nameof(sortByTranslation));

            var sortedWords = words.OrderBy(w => w.Translations[sortByTranslation]);
            foreach (var word in sortedWords)
                showTranslations?.Invoke(word.Translations);
        }

        public static bool RemoveList(string name)
        {
            string filePath = Path.Combine(GetDataFolderPath(), $"{name}.dat");
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
                return true;
            }
            return false;
        }

        // CRUD + Count & Practice method

        public void Save()
        {
            string filePath = Path.Combine(GetDataFolderPath(), $"{Name}.dat");
            using (var writer = new StreamWriter(filePath))
            {
                writer.WriteLine(string.Join(";", Languages));
                foreach (var word in words)
                    writer.WriteLine(string.Join(";", word.Translations));
            }
        }

        public void Add(params string[] translations)
        {
            if (translations.Length != Languages.Length)
                throw new ArgumentException("Incorrect number of translations.");

            translations = translations.Select(t => t.Trim()).ToArray();
            words.Add(new Word(translations));
        }

        public bool Remove(int translationIndex, string word)
        {
            if (translationIndex < 0 || translationIndex >= Languages.Length)
                throw new ArgumentOutOfRangeException(nameof(translationIndex), "Indexet är utanför intervallet för språken.");

            var wordToRemove = words.FirstOrDefault(w => w.Translations[translationIndex].Equals(word, StringComparison.OrdinalIgnoreCase));
            if (wordToRemove != null)
            {
                words.Remove(wordToRemove);
                return true;
            }
            return false;
        }

        public int Count() => words.Count;

        public (Word word, int fromLanguage, int toLanguage) GetWordToPractice()
        {
            if (words.Count == 0)
                throw new InvalidOperationException("Inga ord tillgängliga för denna listan");

            Random random = new Random();
            Word selectedWord = words[random.Next(words.Count)];

            int fromLanguageIndex = random.Next(Languages.Length);
            int toLanguageIndex;
            do
            {
                toLanguageIndex = random.Next(Languages.Length);
            }
            while (toLanguageIndex == fromLanguageIndex);

            return (selectedWord, fromLanguageIndex, toLanguageIndex);
        }
    }
}

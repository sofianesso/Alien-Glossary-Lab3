using ClassLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadWordLists();
        }



        //Boxes

        private void comboBoxLists_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxLists.SelectedItem == null) return;

            var selectedListName = comboBoxLists.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selectedListName))
            {
                MessageBox.Show("Invalid list name.");
                return;
            }

            try
            {
                var list = WordList.LoadList(selectedListName);
                listBoxWords.Items.Clear();
                list.DisplayAllWords(translations =>
                {
                    listBoxWords.Items.Add(string.Join(", ", translations));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading list: {ex.Message}");
            }
        }

        private void listBoxWords_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //Buttons

        private void btnCount_Click(object sender, EventArgs e)
        {
            if (comboBoxLists.SelectedItem == null)
            {
                MessageBox.Show("Please select a list.");
                return;
            }

            var selectedListName = comboBoxLists.SelectedItem.ToString();

            if (string.IsNullOrWhiteSpace(selectedListName))
            {
                MessageBox.Show("List name cannot be empty");
                return;
            }
            var list = WordList.LoadList(selectedListName);
            MessageBox.Show($"Number of words in the list: {list.Count()}");


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var newListName = ShowPrompt("Enter list name");
            if (string.IsNullOrWhiteSpace(newListName)) return;

            var languages = ShowPrompt("Enter languages separated by space").Split(' ');
            if (languages.Length == 0 || languages.Any(string.IsNullOrWhiteSpace)) return;

            var newList = new WordList(newListName, languages);
            newList.Save();
            comboBoxLists.Items.Add(newListName);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (comboBoxLists.SelectedItem == null)
            {
                MessageBox.Show("Please select a list.");
                return;
            }

            var selectedListName = comboBoxLists.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selectedListName))
            {
                MessageBox.Show("Invalid list name.");
                return;
            }

            var list = WordList.LoadList(selectedListName);
            if (list == null)
            {
                MessageBox.Show("Unable to load the list.");
                return;
            }

            var translations = new string[list.Languages.Length];

            for (int i = 0; i < list.Languages.Length; i++)
            {
                var promptMessage = $"Enter word in {list.Languages[i]}:";
                var translation = ShowPrompt(promptMessage);

                if (translation == null) 
                    return;

                translations[i] = translation.Trim();
            }

            try
            {
                list.Add(translations);
                list.Save();
                UpdateWordListDisplay(selectedListName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding word: {ex.Message}");
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (comboBoxLists.SelectedItem == null)
            {
                MessageBox.Show("Please select a list.");
                return;
            }

            var selectedListName = comboBoxLists.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selectedListName))
            {
                MessageBox.Show("Invalid list name.");
                return;
            }

            try
            {
                var list = WordList.LoadList(selectedListName);
                var wordToRemove = ShowPrompt("Enter word to remove:");
                if (string.IsNullOrWhiteSpace(wordToRemove)) return;

                if (!list.Remove(0, wordToRemove)) 
                {
                    MessageBox.Show("Word not found.");
                    return;
                }

                list.Save();
                UpdateWordListDisplay(selectedListName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnPractice_Click(object sender, EventArgs e)
        {

            if (comboBoxLists.SelectedItem == null)
            {
                MessageBox.Show("Please select a list.");
                return;
            }

            var selectedListName = comboBoxLists.SelectedItem.ToString();
            if (string.IsNullOrWhiteSpace(selectedListName))
            {
                MessageBox.Show("Invalid list name.");
                return;
            }

            try
            {
                var list = WordList.LoadList(selectedListName);
                if (list.Count() == 0)
                {
                    MessageBox.Show("The list is empty.");
                    return;
                }

                int totalAttempts = 0;
                int correctAnswers = 0;

                while (true)
                {
                    var (wordToPractice, fromLanguageIndex, toLanguageIndex) = list.GetWordToPractice();

                    if (string.IsNullOrEmpty(wordToPractice.Translations[fromLanguageIndex]) ||
                        string.IsNullOrEmpty(wordToPractice.Translations[toLanguageIndex]))
                    {
                        continue; 
                    }

                    var prompt = $"Translate the word '{wordToPractice.Translations[fromLanguageIndex]}' from {list.Languages[fromLanguageIndex]} to {list.Languages[toLanguageIndex]}:";
                    var userTranslation = ShowPrompt(prompt);

                    if (userTranslation == null)
                    {
                        MessageBox.Show($"Practice session ended. Your score: {correctAnswers}/{totalAttempts}");
                        break;
                    }

                    totalAttempts++;
                    if (userTranslation.Equals(wordToPractice.Translations[toLanguageIndex], StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("Correct!");
                        correctAnswers++;
                    }
                    else
                    {
                        MessageBox.Show($"Incorrect. The correct translation is: {wordToPractice.Translations[toLanguageIndex]}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }


        }

        private void btnRemoveList_Click(object sender, EventArgs e)
        {
            if (comboBoxLists.SelectedItem == null)
            {
                MessageBox.Show("Please select a list to remove.");
                return;
            }

            var selectedListName = comboBoxLists.SelectedItem.ToString();
            var confirmResult = MessageBox.Show($"Are you sure you want to delete '{selectedListName}'?",
                                                 "Confirm Delete",
                                                 MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                if (WordList.RemoveList(selectedListName))
                {
                    MessageBox.Show($"List '{selectedListName}' has been deleted.");
                    LoadWordLists();
                }
                else
                {
                    MessageBox.Show("Error occurred while deleting the list.");
                }
            }
        }



        //Methods
        public static string ShowPrompt(string message)
        {
            using (var promptForm = new PromptForm())
            {
                promptForm.Message = message;
                return promptForm.ShowDialog() == DialogResult.OK ? promptForm.InputText : null;
            }
        }

        private void UpdateWordListDisplay(string listName)
        {
            var list = WordList.LoadList(listName);
            listBoxWords.Items.Clear();

            list.List(0, translations =>
            {
                listBoxWords.Items.Add(string.Join(", ", translations));
            });
        }

        private void LoadWordLists()
        {
            comboBoxLists.Items.Clear();
            try
            {
                var wordLists = WordList.GetLists();
                comboBoxLists.Items.AddRange(wordLists);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading word lists: " + ex.Message);
            }
        }

       

        //Labels
        private void lblLogo_Click(object sender, EventArgs e)
        {

        }

        private void lblWordsHeader_Click(object sender, EventArgs e)
        {

        }

        private void lblFooter2_Click(object sender, EventArgs e)
        {

        }

        private void lblShowLists_Click(object sender, EventArgs e)
        {

        }

        private void lblFooter1_Click(object sender, EventArgs e)
        {

        }

        private void labelLogoSecond_Click(object sender, EventArgs e)
        {

        }

        private void lblHeader_Click(object sender, EventArgs e)
        {

        }
    }
}

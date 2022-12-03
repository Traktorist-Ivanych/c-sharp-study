using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkillBox10_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LineToWords(object sender, RoutedEventArgs e)
        {
            string inputLine = LineToWordsInputTextBox.Text;
            string[] outputWords = SplitText(inputLine);
            LineToWordsResultListBox.ItemsSource = outputWords;
        }

        private void WordsShaffle(object sender, RoutedEventArgs e)
        {
            string inputLineToRevers = WordsShaffleInputTextBox.Text;
            string outputReversLine = ReversWordsInText(inputLineToRevers);
            WordsShaffleResultLabel.Content = outputReversLine;
        }

        private string[] SplitText(string text)
        {
            string[] wordsResult = text.Split(' ');
            return wordsResult;
        }

        private string ReversWordsInText(string textToRevers)
        {
            string[] wordsToRevers = SplitText(textToRevers);
            string reversTextResult = String.Empty;

            for (int i = wordsToRevers.Length - 1; i >= 0; i--) // перебирает массив слов в обратном порядке для перестановки
            {
                if (i == wordsToRevers.Length - 1) // для первого слова пробел не нужен
                {
                    reversTextResult = wordsToRevers[i];
                }
                else
                {
                    reversTextResult += " " + wordsToRevers[i];
                }
            }

            return reversTextResult;
        }
    }
}

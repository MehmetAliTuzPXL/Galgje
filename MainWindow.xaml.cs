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

namespace Galgje
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int aantalPogingen = 10;
        private string geheimWoord;
        StringBuilder juisteLetters;
        StringBuilder fouteLetters;

        private void nieuwSpel()
        {
            pogingTextBlock.Text = Convert.ToString(aantalPogingen = 10);
            raadButton.IsEnabled = false;
            inputTextBox.Text = "";
            juisteLetters = new StringBuilder();
            fouteLetters = new StringBuilder();
            juistTxtBlock.Text = "";
            foutTxtBlock.Text = "";
        }

        private void verbergButton_Click(object sender, RoutedEventArgs e)
        {
            raadButton.IsEnabled = true;
            geheimWoord = inputTextBox.Text;
            inputTextBox.Text = "";

        }

        private void nieuwButton_Click(object sender, RoutedEventArgs e)
        {
            nieuwSpel();
        }

        private void raadButton_Click(object sender, RoutedEventArgs e)
        {
            string input = inputTextBox.Text;
            inputTextBox.Text = "";
            if (aantalPogingen > 0)
            {
                if (input.Length > 1)
                {
                    Guessword(input);
                }
                else
                {
                    GuessLetter(input);
                }
            }
            else
            {
                raadButton.IsEnabled = false;
                inputTextBox.Text = "Geen pogingen meer over.";
            }
            pogingTextBlock.Text = Convert.ToString(aantalPogingen);
        }

        private void Guessword(string word)
        {
            if (word.Equals(geheimWoord))
            {
                inputTextBox.Text = "U hebt gewonnen";
            }
            else
            {

                aantalPogingen--;
            }
        }

        private void GuessLetter(string letter)
        {

            if (geheimWoord.Contains(letter))
            {
                juisteLetters.Append(letter);
                juistTxtBlock.Text = Convert.ToString(juisteLetters);

            }
            else
            {
                fouteLetters.Append(letter);
                foutTxtBlock.Text = Convert.ToString(fouteLetters);
                aantalPogingen--;
            }
        }
    }
}

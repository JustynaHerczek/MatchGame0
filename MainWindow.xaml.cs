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

namespace MatchGame
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            SetUpGame();
        }

        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐶", "🐶",
                "🦁", "🦁",
                "🦝", "🦝",
                "🐴", "🐴",
                "🐷", "🐷",
                "🦩", "🦩",
                "🐬", "🐬",
                "🐧", "🐧",
            };
            Random random = new Random();
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                int index = random.Next(animalEmoji.Count);
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index);
            }
        
        }
        /* Dodanie do gry obsługi kliknięcia myszą:
         * Jeśli kliknięte zostało pierwsze zwierzę,
         * należy zapisać, która kontrolka TextBlock została kliknięta i usunąć grafikę. 
         * Jeżeli kliknięto drugie zwierzę, 
         * należy albo też usunąć grafikę (dopasowanie) albo ponownie wyświetlić pierwszy rysunek (brak dopasowania)*/
       
        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

         private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textblock = sender as TextBlock;
            if (findingMatch == false)
            {
                textblock.Visibility = Visibility.Hidden;
                lastTextBlockClicked = textblock;
                findingMatch = true;
            }
            else if (textblock.Text == lastTextBlockClicked.Text)
            {
                textblock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Hidden;
                findingMatch = false;
            }
        }
    }
}












          
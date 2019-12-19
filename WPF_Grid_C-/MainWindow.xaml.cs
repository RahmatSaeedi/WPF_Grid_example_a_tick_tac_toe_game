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

namespace WPF_Grid_C_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean isPlayerOneTurn = true;
        private Boolean isGameOver = false;
        private UInt16 numberOfSquaresRemaining = 8;
        private Boolean CheckIfGameOver()
        {

            isGameOver = (
                (button00.Content == button01.Content && button01.Content == button02.Content && button00.Content != null) ||
                (button10.Content == button11.Content && button11.Content == button12.Content && button10.Content != null) ||
                (button20.Content == button21.Content && button21.Content == button22.Content && button20.Content != null) ||

                (button00.Content == button10.Content && button10.Content == button20.Content && button00.Content != null) ||
                (button01.Content == button11.Content && button11.Content == button21.Content && button01.Content != null) ||
                (button02.Content == button12.Content && button12.Content == button22.Content && button02.Content != null) ||

                (button00.Content == button11.Content && button11.Content == button22.Content && button00.Content != null) ||
                (button20.Content == button11.Content && button11.Content == button02.Content && button20.Content != null)
                );

            if (isGameOver)
            {
                infoBox.Text = "Game Over. " + (isPlayerOneTurn ? "O" : "X") + " won the game.";
            }

            return isGameOver;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (numberOfSquaresRemaining > 0)
            {
                if (!isGameOver)
                {
                    Button button = (Button)e.Source;
                    if ((String) button.Content != "X" && (String) button.Content != "O")
                    {
                        if (isPlayerOneTurn)
                        {
                            button.Content = "X";
                            infoBox.Text = "O";
                        }
                        else
                        {
                            button.Content = "O";
                            infoBox.Text = "X";
                        }
                        isPlayerOneTurn = !isPlayerOneTurn;
                        numberOfSquaresRemaining--;
                    }
                    CheckIfGameOver();
                }
            }
            else
            {
                infoBox.Text = "Game Over. The game ended in a draw.";
            }

        }
    }
}

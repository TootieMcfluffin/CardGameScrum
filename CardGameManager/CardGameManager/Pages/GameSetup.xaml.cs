using CardGameManager.Models;
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

namespace CardGameManager.Pages
{
    /// <summary>
    /// Interaction logic for GameSetup.xaml
    /// </summary>
    public partial class GameSetup : Page
    {
        TextBox playerOneName;  
        TextBox playerTwoName;  
        TextBox playerThreeName;  
        TextBox playerFourName;  
        TextBox playerFiveName;  
        TextBox playerSixName;
        string game;
        List<string> names = new List<string>();
        public GameSetup(int players, string gameName)
        {
            InitializeComponent();
            Layout(players);
            game = gameName;
        }

        /// <summary>
        /// Creates the layout for the page. Generates text boxes based on the amount of players playing.
        /// </summary>
        /// <param name="players">The amount of players that will play. Used to determine how many labels and text boxes are needed.</param>
        public void Layout(int players)
        {
            for (int i = 0; i < players; i++)
            {
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.VerticalAlignment = VerticalAlignment.Center;
                panel.HorizontalAlignment = HorizontalAlignment.Center;
                Label tempLabel = new Label();
                tempLabel.Content = $"Player {i+1}: ";
                tempLabel.FontFamily = new FontFamily("Onyx");
                tempLabel.FontSize = 20;
                tempLabel.Margin = new Thickness(2, 5, 2, 5);
                TextBox tempNameBox = new TextBox();
                tempNameBox.Margin = new Thickness(2, 5, 2, 5);
                tempNameBox.Height = 25;
                tempNameBox.VerticalContentAlignment = VerticalAlignment.Center;
                tempNameBox.Width = 150;
                switch(i)
                {
                    case 0:
                        panel.Children.Add(tempLabel);
                        playerOneName = tempNameBox;
                        panel.Children.Add(playerOneName);
                        break;
                    case 1:
                        panel.Children.Add(tempLabel);
                        playerTwoName = tempNameBox;
                        panel.Children.Add(playerTwoName);
                        break;
                    case 2:
                        panel.Children.Add(tempLabel);
                        playerThreeName = tempNameBox;
                        panel.Children.Add(playerThreeName);
                        break;
                    case 3:
                        panel.Children.Add(tempLabel);
                        playerFourName = tempNameBox;
                        panel.Children.Add(playerFourName);
                        break;
                    case 4:
                        panel.Children.Add(tempLabel);
                        playerFiveName = tempNameBox;
                        panel.Children.Add(playerFiveName);
                        break;
                    case 5:
                        panel.Children.Add(tempLabel);
                        playerSixName = tempNameBox;
                        panel.Children.Add(playerSixName);
                        break;
                }
                MainPanel.Children.Add(panel);
            }
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            if(playerOneName != null)
            {
                if(string.IsNullOrEmpty(playerOneName.Text.Trim()))
                {
                    names.Add("Player One");
                }
                else
                {
                    names.Add(playerOneName.Text);
                }
            }
            if (playerTwoName != null)
            {
                if (string.IsNullOrEmpty(playerTwoName.Text.Trim()))
                {
                    names.Add("Player Two");
                }
                else
                {
                    names.Add(playerTwoName.Text);
                }
            }
            if (playerThreeName != null)
            {
                if (string.IsNullOrEmpty(playerThreeName.Text.Trim()))
                {
                    names.Add("Player Three");
                }
                else
                {
                    names.Add(playerThreeName.Text);
                }
            }
            if (playerFourName != null)
            {
                if (string.IsNullOrEmpty(playerFourName.Text.Trim()))
                {
                    names.Add("Player Four");
                }
                else
                {
                    names.Add(playerFourName.Text);
                }
            }
            if (playerFiveName != null)
            {
                if (string.IsNullOrEmpty(playerFiveName.Text.Trim()))
                {
                    names.Add("Player Five");
                }
                else
                {
                    names.Add(playerFiveName.Text);
                }
            }
            if (playerSixName != null)
            {
                if (string.IsNullOrEmpty(playerSixName.Text.Trim()))
                {
                    names.Add("Player Six");
                }
                else
                {
                    names.Add(playerSixName.Text);
                }
            }
            if (game.Equals("blackjack", StringComparison.OrdinalIgnoreCase))
            {
                Blackjack blackjack = new Blackjack(names);
                this.NavigationService.Navigate(blackjack);
            }
            else if(game.Equals("gofish", StringComparison.OrdinalIgnoreCase))
            {
                //GoFish gofish = new GoFish(names);
                //this.NavigationService.Navigate(gofish);
            }
            else if(game.Equals("war", StringComparison.OrdinalIgnoreCase))
            {
                War war = new War(names);
                this.NavigationService.Navigate(war);
            }
        }
    }
}

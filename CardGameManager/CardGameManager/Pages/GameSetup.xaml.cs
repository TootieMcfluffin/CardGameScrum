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
        public GameSetup(int players)
        {
            InitializeComponent();
            Layout(players);
        }

        /// <summary>
        /// Creates the layout for the page. Adds labels and text boxes based on how many players there will be.
        /// </summary>
        /// <param name="players">The amount of players that will play. Used to determine how many labels and text boxes are needed.</param>
        public void Layout(int players)
        {
            switch (players)
            {
                case 1:
                    StackPanel panelOne = new StackPanel();
                    panelOne.Orientation = Orientation.Horizontal;
                    panelOne.VerticalAlignment = VerticalAlignment.Center;
                    panelOne.HorizontalAlignment = HorizontalAlignment.Center;
                    Label labelOne = new Label();
                    labelOne.Content = "Player One's Name: ";
                    labelOne.Width = 112;
                    labelOne.Height = 30;
                    labelOne.FontSize = 12;
                    labelOne.Margin = new Thickness(2, 5, 2, 5);
                    TextBox playerOneName = new TextBox();
                    playerOneName.Margin = new Thickness(2, 5, 2, 5);
                    playerOneName.Height = 30;
                    playerOneName.Width = 150;
                    panelOne.Children.Add(labelOne);
                    panelOne.Children.Add(playerOneName);
                    MainPanel.Children.Add(panelOne);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        
    }
}

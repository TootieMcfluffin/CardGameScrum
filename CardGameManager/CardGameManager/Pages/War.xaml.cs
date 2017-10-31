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
    /// Interaction logic for War.xaml
    /// </summary>
    public partial class War : Page
    {
        public Player playerOne = new Player();
        public Player playerTwo = new Player();
        public War(List<string> names)
        {
            InitializeComponent();
            if(names.Count == 1)
            {
                playerOne.Name = names.ElementAt(0);
                playerTwo.Name = "Computer";
            }
            else
            {
                playerOne.Name = names.ElementAt(0);
                playerTwo.Name = names.ElementAt(1);
            }
            PlayerOneName.Content = playerOne.Name;
            PlayerTwoName.Content = playerTwo.Name;
        }
    }
}

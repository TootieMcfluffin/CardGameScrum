using CardGameManager.Models;
using CardGameManager.Converters;
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
    /// Interaction logic for Bool_check_page.xaml
    /// </summary>
    public partial class Bool_check_page : Page
    {
        Player p1 = new Player();
        DeckModel deck = new DeckModel();

        ImageBrush cardback = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\CARD_BACK.png", UriKind.RelativeOrAbsolute)));

        public Bool_check_page()
        {
            InitializeComponent();
            deck.Shuffle();
            Card1.DataContext = deck.Deck[1];
            Binding newBinding = new Binding();
            newBinding.Path = new PropertyPath("IsFlipped");
            BoolToImageConverter s2i = new BoolToImageConverter();
            s2i.CardBackBrush = cardback;
            s2i.CardBrush = new ImageBrush(new BitmapImage(new Uri(deck.Deck[1].ImagePath, UriKind.RelativeOrAbsolute)));
            newBinding.Converter = s2i;
            newBinding.Mode = BindingMode.OneWay;
            newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(Card1, Label.BackgroundProperty, newBinding);

        }
    }
}

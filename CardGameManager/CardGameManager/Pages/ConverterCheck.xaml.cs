using System;
using CardGameManager.Models;
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
using CardGameManager.Converters;

namespace CardGameManager.Pages
{
    /// <summary>
    /// Interaction logic for ConverterCheck.xaml
    /// </summary>
    public partial class ConverterCheck : Page
    {
        Player p1 = new Player();
        DeckModel deck = new DeckModel();
        ImageBrush cardback = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\CARD_BACK.png", UriKind.RelativeOrAbsolute)));

        public ConverterCheck()
        {
            InitializeComponent();
            Doit();
        }
        public void Doit()
        {
            deck.Shuffle();
            CardModel carddd = deck.Deck[1];
            Card1.DataContext = carddd;
            Binding newBinding = new Binding();
            newBinding.Path = new PropertyPath("IsFlipped");
            BoolToImageConverter s2i = new BoolToImageConverter();
            s2i.CardBackBrush = cardback;
            s2i.CardBrush = new ImageBrush(new BitmapImage(new Uri(carddd.ImagePath, UriKind.RelativeOrAbsolute)));
            newBinding.Converter = s2i;
            newBinding.Mode = BindingMode.OneWay;
            newBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            BindingOperations.SetBinding(Card1, Label.BackgroundProperty, newBinding);
        }
    }
}

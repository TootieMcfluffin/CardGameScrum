using CardGameManager.Converters;
using CardGameManager.GameProcesses;
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
	/// Interaction logic for GoFish.xaml
	/// </summary>
	public partial class GoFish : Page
	{
		public int NumOfPlayers { get; set; }
		public List<string> PlayerNames { get; set; }
		public List<GoFishPlayer> players = new List<GoFishPlayer>();
		public DeckModel deck = new DeckModel();
		GoFishGame game;
		ImageBrush cardBackBrush = new ImageBrush(new BitmapImage(new Uri(@"..\\..\\Images\\CARD_BACK.png", UriKind.RelativeOrAbsolute)));
		public GoFish(List<string> names)
		{
			InitializeComponent();
			PlayerNames = names;
			Startup();
			game = new GoFishGame(players);
//			game.GamePlay();
		}

		public void Startup()
		{
			GoFishGrid.Background = Brushes.Green;
			NumOfPlayers = PlayerNames.Count();
			CreatePlayers();
			DealCards();
			PopulateBoard();
//			CreateCardPile();
		}

		public void PopulateBoard()
		{

			for (int i = 0; i < NumOfPlayers; i++)
			{
				Label lab = new Label();
				lab.Width = 150;
				lab.Height = 62;
				lab.Content = PlayerNames[i];
				lab.Background = Brushes.Red;
				lab.Margin = new Thickness(25);
				lab.FontSize = 25;
				lab.HorizontalContentAlignment = HorizontalAlignment.Center;
				lab.VerticalAlignment = VerticalAlignment.Center;
				lab.BorderBrush = Brushes.Black;
				lab.BorderThickness = new Thickness(5);
				

				if (PlayerNames.Count == 2)
				{
					if (i == 0)
					{
						Grid.SetColumn(lab, 0);
						Grid.SetRow(lab, 0); 

						
					}
					else if (i == 1)
					{
						Grid.SetRow(lab, 0);
						Grid.SetColumn(lab, 1);
					}

				}
				else if(PlayerNames.Count == 3)
				{
					if (i == 0)
					{
						Grid.SetColumn(lab, 0);
						Grid.SetRow(lab, 1);
					}
					else if (i == 1)
					{
						Grid.SetRow(lab, 1);
						Grid.SetColumn(lab, 1);
					}
					else if(i == 2)
					{
						Grid.SetRow(lab, 0);
						Grid.SetColumn(lab, 0);
						Grid.SetColumnSpan(lab, 2);
					}
				}
					
				else if(PlayerNames.Count == 4)
				{
					if (i == 0)
					{
						Grid.SetRow(lab, 0);
						Grid.SetColumn(lab, 0);
					}
					else if (i == 1)
					{
						Grid.SetRow(lab, 1);
						Grid.SetColumn(lab, 0);
					}
					else if (i == 2)
					{
						Grid.SetRow(lab, 0);
						Grid.SetColumn(lab, 1);
					}
					else if (i == 3)
					{
						Grid.SetRow(lab, 1);
						Grid.SetColumn(lab, 1);
					}
				}

				GoFishGrid.Children.Add(lab);

			}
		}

		public void CreatePlayers()
		{
			foreach (string name in PlayerNames)
			{
				GoFishPlayer player = new GoFishPlayer();
				player.Name = name;
				players.Add(player);				
			}
		}

		public void DealCards()
		{
			deck.Shuffle();

			foreach (GoFishPlayer player in players)
			{
				for (int i = 0; i < 5; i++){
					CardModel card = deck.Deck.FirstOrDefault();
					player.hand.Add(card);
					deck.Deck.Remove(card);
				}
					
			}
		
		}

		public void CreateCardPile()
		{
			CardModel card = new CardModel(Enums.Suit.DIAMONDS, Enums.Value.ACE);
			CardHolder.DataContext = card;

			card.IsFlipped = false;
			CardHolder.Content = "Card Pile";
			CardHolder.BorderBrush = Brushes.Black;
			CardHolder.BorderThickness = new Thickness(5);



		}


	}
}

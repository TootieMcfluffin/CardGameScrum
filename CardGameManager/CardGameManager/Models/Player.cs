using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.Models
{
    public class Player
    {
        public string Name { get; set; }

        public List<CardModel> Hand { get; set; }
		
        public int Balance { get; set; }

        public List<CardModel> SecondHand { get; set; }
    }
}

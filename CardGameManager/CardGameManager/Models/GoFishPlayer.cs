using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.Models
{
	public class GoFishPlayer : Player
	{

		public int BookCount { get; set; }

		public GoFishPlayer()
		{
			BookCount = 0;
		}
	}
}

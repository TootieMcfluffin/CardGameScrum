﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameManager.Models
{
    public class Player
    {
        public string Name { get; set; }

        public List<CardModel> hand = new List<CardModel>();
    }
}
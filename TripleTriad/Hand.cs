using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    public class Hand
    {
        private Card[] Cards { get; set; }

        public Card GetCard(int index)
        {
            var card = Cards[index];
            Cards[index] = null;
            return card;
        }

        public Hand(Card[] cards)
        {
            if(cards.Length != 5)
                throw new ArgumentException("A hand must have 5 cards", nameof(cards));
            Cards = cards;
        }
    }
}

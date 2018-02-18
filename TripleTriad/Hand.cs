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

        //todo: justify side effect. How to read hand without emptying it? Why not use a List and remove card after move committed?
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

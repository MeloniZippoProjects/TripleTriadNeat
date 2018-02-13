using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    public class Move
    {
        public uint BoardX { get; set; }
        public uint BoardY { get; set; }
        public Card Card { get; set; }

        public Move(uint x, uint y, Card card)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card), "A card must be specified");

            if (x > 2)
                throw new ArgumentOutOfRangeException(nameof(x), "X coordinate must be in range [0,2]");
            if (y > 2)
                throw new ArgumentOutOfRangeException(nameof(x), "X coordinate must be in range [0,2]");

            BoardX = x;
            BoardY = y;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    public class Move
    {
<<<<<<< HEAD
        public int BoardRow { get; set; }
        public int BoardColumn { get; set; }
        public Card Card { get; set; }

        public Move(uint row, uint column, Card card)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card), "A card must be specified");

            if (row > 2)
                throw new ArgumentOutOfRangeException(nameof(x), "X coordinate must be in range [0,2]");
            if (column > 2)
                throw new ArgumentOutOfRangeException(nameof(x), "X coordinate must be in range [0,2]");

            BoardRow = row;
            BoardColumn = column;
=======
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
>>>>>>> c9149d50d6057c34af575966f6e00589f2176b41
        }
    }
}

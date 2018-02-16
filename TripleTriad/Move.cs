using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    public class Move
    {
        public uint BoardRow { get; set; }
        public uint BoardColumn { get; set; }
        public Card Card { get; set; }

        public Move(uint row, uint column, Card card)
        {
            Card = card ?? throw new ArgumentNullException(nameof(card), "A card must be specified");

            if (row > 2)
                throw new ArgumentOutOfRangeException(nameof(row), "X coordinate must be in range [0,2]");
            if (column > 2)
                throw new ArgumentOutOfRangeException(nameof(column), "X coordinate must be in range [0,2]");

            BoardRow = row;
            BoardColumn = column;
        }
    }
}

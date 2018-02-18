using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TripleTriad.Constants;

namespace TripleTriad
{
    public class Move
    {
        public uint Row { get; set; }
        public uint Column { get; set; }
        public PlayerColor Color { get; set; }
        public Card Card { get; set; }

        public bool IsValid => Card != null && Color != PlayerColor.None && Row <= 2 && Column <= 2;

        public bool IsLegal(Board board)
        {
            return IsValid && board.Fields[Row, Column].IsFree;
        }
    }
}

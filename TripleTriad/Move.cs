using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    public class Move
    {
        public uint Row { get; set; }
        public uint Column { get; set; }
        public Card Card { get; set; }

        public bool IsValid
        {
            get
            {
                if (Card == null || Row > 2 || Column > 2)
                    return false;
                else
                    return true;
            }
        }

        public bool IsLegal(Board board)
        {
            return IsValid && board.Fields[Row, Column].IsFree;
        }
    }
}

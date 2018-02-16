using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TripleTriad.Constants;

namespace TripleTriad
{
    public class Board
    {
        private Field[,] Fields { get; set; } = new Field[3, 3];

        public Board()
        {
            for (int i = 0; i < 3; ++i)
                for(int j = 0; j < 3; ++j)
                    Fields[i,j] = new Field();
        }

        public void PlayMove(Move move)
        {
            var field = Fields[move.BoardRow, move.BoardColumn];

            if(field.Color != PlayerColor.None)
                throw new MoveNotValidException();
        }
    }
}

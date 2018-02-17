﻿using System;
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
        private Field[,] Fields { get; } = new Field[3, 3];
        
        public Rules Rules { get; set; }

        public Board()
        {
            for (int row = 0; row < 3; ++row)
            {
                for (int column = 0; column < 3; ++column)
                {
                    Fields[row, column] = new Field()
                    {
                        Board = this,
                        Row = row,
                        Column = column
                    };
                }
            }
            
            Field wall = new Field()
            {
                Board = this,
                IsWall = true,
                Element = Element.None
            };

            foreach (Field field in Fields)
            {
                field.RightSide = field.Column == 0 ? wall : Fields[field.Row, field.Column - 1];
                field.LeftSide = field.Column == 3 ? wall : Fields[field.Row, field.Column + 1];
                field.Above = field.Row == 0 ? wall : Fields[field.Row - 1, field.Column];
                field.Below = field.Row == 3 ? wall : Fields[field.Row + 1, field.Column];
            }
        }

        public void PlayMove(Move move)
        {
            var field = Fields[move.BoardRow, move.BoardColumn];

            if(field.Color != PlayerColor.None)
                throw new MoveNotValidException();
        }
    }
}

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
        public Field[,] Fields { get; } = new Field[3, 3];

        private Rules rules;

        public Rules Rules
        {
            get => rules;
            set
            {
                rules = value;
                if ((rules | Rules.Elemental) == Rules.Elemental)
                {
                    Random random = new Random(DateTime.Now.Millisecond);
                    foreach (var field in Fields.Cast<Field>().Where(f => !f.IsWall))
                    {
                        if (random.NextDouble() < ElementAppearRate)
                        {
                            field.Element = (Element) random.Next(1, ElementsNumber);
                        }
                    }
                }
                else
                {
                    foreach (var field in Fields.Cast<Field>().Where(f => !f.IsWall))
                    {
                        field.Element = Element.None;
                    }
                }
            }
        }

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
            var field = Fields[move.Row, move.Column];

            if(!move.IsLegal(this))
                throw new MoveNotLegalException();

            field.Color = move.Color;
            field.Card = move.Card;

            ApplyRules(field);
        }

        private void ApplyRules(Field field)
        {
            List<Field> toChange = new List<Field>();
            List<Field> toCombo = new List<Field>();

            foreach (Boundary boundary in field.Boundaries)
            {
                if(boundary.IsBaseRuleCapture)
                    toChange.Add(boundary.Neighbour);
            }

            //fine regola base
        }
    }
}

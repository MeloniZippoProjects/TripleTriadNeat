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
        private Field Wall;

        private Rules rules;

        public Rules Rules
        {
            get => rules;
            set
            {
                rules = value;
                if ((rules & Rules.Elemental) == Rules.Elemental)
                {
                    Random random = new Random(DateTime.Now.Millisecond);
                    foreach (var field in Fields)
                    {
                        if (random.NextDouble() < ElementAppearRate)
                        {
                            field.Element = (Element) random.Next(1, ElementsNumber);
                        }
                    }
                }
                else
                {
                    foreach (var field in Fields)
                    {
                        field.Element = Element.None;
                    }
                }

                if ((rules & Rules.Samewall) == Rules.Samewall)
                {
                    Wall.Card = new Card()
                    {
                        Top = 10,
                        Right = 10,
                        Bottom = 10,
                        Left = 10
                    };
                }
                else
                {
                    Wall.Card = null;
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
            
            Wall = new Field()
            {
                Board = this,
                IsWall = true,
                Element = Element.None
            };

            foreach (Field field in Fields)
            {
                field.RightSide = field.Column == 0 ? Wall : Fields[field.Row, field.Column - 1];
                field.LeftSide = field.Column == 3 ? Wall : Fields[field.Row, field.Column + 1];
                field.Above = field.Row == 0 ? Wall : Fields[field.Row - 1, field.Column];
                field.Below = field.Row == 3 ? Wall : Fields[field.Row + 1, field.Column];
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
            Stack<Field> comboCaptured = new Stack<Field>();
            if((rules & Rules.Same) == Rules.Same)
                foreach (var comboField in ApplySameRule(field))
                    comboCaptured.Push(comboField);

            if ((rules & Rules.Plus) == Rules.Same)
                foreach (var comboField in ApplyPlusRule(field))
                    comboCaptured.Push(comboField);

            while (comboCaptured.Count > 0)
            {
                Field capturedField = comboCaptured.Pop();
                capturedField.Flip();

                foreach (var comboField in ApplyBaseRule(capturedField))
                    comboCaptured.Push(comboField);
            }

            var baseCaptured = ApplyBaseRule(field);
            foreach (Field capturedField in baseCaptured)
                capturedField.Flip();
        }

        private static IEnumerable<Field> ApplyBaseRule(Field field)
        {
            return 
                from boundary in field.Boundaries
                where boundary.IsBaseRuleCapture
                select boundary.Neighbour;
        }

        private static IEnumerable<Field> ApplySameRule(Field field)
        {
            var candidateBoundaries = field.Boundaries.Where(b => b.IsSameCandidate);
            if (candidateBoundaries.Count() > 1)
                return candidateBoundaries
                    .Where(b => b.Origin.Color != b.Neighbour.Color)
                    .Select(b => b.Neighbour);
            else
                return null;
        }

        private static IEnumerable<Field> ApplyPlusRule(Field field)
        {
            return field.ActiveBoundaries
                .Where(b => 
                    field.ActiveBoundaries
                        .Any(b2 => b != b2 && b.Sum == b2.Sum))
                .Select(b => b.Neighbour);
        }
    }
}

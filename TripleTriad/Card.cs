using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static TripleTriad.Constants;

namespace TripleTriad
{
    /// <summary>
    /// Card object, it is composed of 4 integer values from 1 to 10 and one optional element
    /// </summary>
    public class Card
    {
        public Element Element { get; set; }
        public Field ParentField { get; set; }

        public uint GetSide(CardSide side)
        {
            return (uint) typeof(Card).GetRuntimeProperty(side.ToString()).GetValue(this);
        }

        public CardStat Top { get; set; }
        public CardStat Right { get; set; }
        public CardStat Bottom { get; set; }
        public CardStat Left { get; set; }
    }

    public class CardStat
    {
        public Card Card { get; set; }

        private uint score;
        public uint Score
        {
            get => Card.ParentField.Element == Element.None || Card.ParentField.IsWall ? score :
                 Card.Element == Card.ParentField.Element ? score + 1 : score - 1;
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Value must be between 1 and 10");
                score = value;
            }
        }

        public static implicit operator uint(CardStat stat)
        {
            return stat.Score;
        }

        public static implicit operator CardStat(uint value)
        {
            return new CardStat()
            {
                Score = value
            };
        }
    }
}

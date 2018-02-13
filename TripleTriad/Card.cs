using System;
using System.Collections.Generic;
using System.Linq;
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
        public uint Top { get; set; }
        public uint Bot { get; set; }
        public uint Left { get; set; }
        public uint Right { get; set; }
        public Element Element { get; set; }

        public Card(uint top, uint bot, uint left, uint right, Element element)
        {
            if (top > 10)
                throw new ArgumentOutOfRangeException(nameof(top), top, "Top value must be between 1 and 10");
            if (bot > 10)
                throw new ArgumentOutOfRangeException(nameof(top), top, "Bottom value must be between 1 and 10");
            if (left > 10)
                throw new ArgumentOutOfRangeException(nameof(top), top, "Left value must be between 1 and 10");
            if (right > 10)
                throw new ArgumentOutOfRangeException(nameof(top), top, "Right value must be between 1 and 10");

            Top = top;
            Bot = bot;
            Left = left;
            Right = right;
            Element = element;
        }
    }
}

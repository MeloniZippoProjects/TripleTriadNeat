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
        public Element Element { get; set; }
        public Field ParentField { get; set; }

        private uint top;
        public uint Top
        {
            get => ParentField.Element == Element.None ? top : (Element == ParentField.Element ? top + 1 : top - 1);
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Top value must be between 1 and 10");
                top = value;
            }
        }

        private uint bottom;
        public uint Bottom
        {
            get => ParentField.Element == Element.None ? bottom : (Element == ParentField.Element ? bottom + 1 : bottom - 1);
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Bottom value must be between 1 and 10");
                bottom = value;
            }
        }

        private uint left;
        public uint Left
        {
            get => ParentField.Element == Element.None ? left : (Element == ParentField.Element ? left + 1 : left - 1);
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Left value must be between 1 and 10");
                left = value;
            }
        }

        private uint right;
        public uint Right
        {
            get => ParentField.Element == Element.None ? right : (Element == ParentField.Element ? right + 1 : right - 1);
            set
            {
                if (value < 1 || value > 10)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Right value must be between 1 and 10");
                right = value;
            }
        }
    }
}

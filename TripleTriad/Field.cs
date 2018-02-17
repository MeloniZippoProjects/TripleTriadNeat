using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TripleTriad.Constants;

namespace TripleTriad
{
    public class Field
    {
        /// <summary>
        /// If this field is not null, it contains the card placed
        /// on the field.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// The Board which hosts this Field instance
        /// </summary>
        public Board Board { get; set; }

        /// <summary>
        /// The Board row in which this field exists
        /// </summary>
        public int Row { get; set; }

        /// <summary>
        /// The Board column in which this field exists
        /// </summary>
        public int Column { get; set; }

        /// <summary>
        /// If this field is not null, it contains the element
        /// assigned to the field
        /// </summary>
        public Element Element { get; set; }

        /// <summary>
        /// If this field is not null, it contains the
        /// color of the player
        /// </summary>
        public PlayerColor Color { get; set; } = PlayerColor.None;

        public bool IsWall { get; set; }

        public Field Above { get; set; }
        public Field Below { get; set; }
        public Field LeftSide { get; set; }
        public Field RightSide { get; set; }

        public bool IsFree => Color == PlayerColor.None;

        public Field()
        {
            //Randomly put Elements on the board
            Random random = new Random(DateTime.Now.Millisecond);
            //treshold for having an Element appear
            if (random.NextDouble() < ElementAppearRate)
            {
                //choose a random Element
                Element = (Element)random.Next(1, ElementsNumber);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    class Field
    {
        /// <summary>
        /// If this field is not null, it contains the card placed
        /// on the field.
        /// </summary>
        public Card Card { get; set; }

        /// <summary>
        /// If this field is not null, it contains the element
        /// assigned to the field
        /// </summary>
        public Element Element { get; set; }

        /// <summary>
        /// If this field is not null, it contains the
        /// color of the player
        /// </summary>
        public PlayerColor Color { get; set; }
    }
}

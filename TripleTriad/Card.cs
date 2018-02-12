using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    /// <summary>
    /// Card object, it is composed of 4 integer values from 1 to 10 and one optional element
    /// </summary>
    public class Card
    {
        public int Top { get; set; }
        public int Bot { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
        public Element Element { get; set; }
    }
}

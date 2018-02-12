using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripleTriad
{
    public interface IPlayer
    {
        Hand Hand { get; set; }
        Move NextMove { get; set; }
        PlayerColor Color { get; set; }
        Board Board { get; set; }
    }
}
